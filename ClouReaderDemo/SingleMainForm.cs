using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ClouReaderAPI.ClouInterface;
using ClouReaderAPI;
using System.Threading;
using ClouReaderAPI.MyConnect;
using ClouReaderAPI.Models;
using System.Collections;
using ClouReaderDemo.MyFormTemplet;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClouReaderDemo
{
    public delegate void AddTag(Tag_Model tag_6C, DataGridViewRow dgvr, Boolean isNew);      // 更新标签信息invoke
    public delegate void FlushState();                                                       // 更新实时状态invoke
    public delegate void UpdateGPI(RoundButton rb, Color cl);
    public delegate void TCPPortConn(String connID);                                         // 读写器主动连接服务器回调
    public partial class SingleMainForm : _360Form, IAsynchronousMessage
    {
        public static Boolean IsEnglish = false;
        public Boolean IsMultiConnect = false;          // 是否是多读写器连接
        private const int MAX_DEBUG_MESSAGE = 1000;     // 调试消息大于1000条时，自动清空
        private int nowDebugMessageCount = 0;
        private bool IsFlush = false;                   // 是否继续循环刷新状态（结束刷新线程）
        private bool IsStartRead = false;               // 是否正在读取标签
        private bool IsWriteDebug = false;              // 是否开启DEBUG模式 
        private bool IsShowTag = true;                  // 是否在DataGridView中显示标签数据
        public String readVarParam_6C = "";             // 读标签时候的可选参数，可由配置文件保存、读取
        public String readVarParam_6B = "";
        public String readVarParam_GB = "";
        public string ConnID = "";                      // 当前连接的ID
        Dictionary<String, DataGridViewRow> dic_Rows = new Dictionary<string, DataGridViewRow>(); // 在DataGridView中显示标签数据
        DateTime TJ_Run_Start = DateTime.Now;           // 开始读标签时间，用来统计标签读取速度
        long TJ_LastTagcount = 0;                       // 连续读标签的时候，上一秒钟的已读标签总数，用来统计标签读实时速率
        System.Windows.Forms.Timer[] TJ_GPI_Timers = new System.Windows.Forms.Timer[4];// 控制GPI灯的Timer对象
        List<RoundButton> TJ_List_GPI_Button = new List<RoundButton>();                // GPI灯按钮集合
        public String ReadGPOParam = "";                    // 读标签控制GPO
        public String ReadGPOParam_Stop = "";
        public object ReadGPOObject = new object();         // 控制读标签时的锁对象

        MySingleForm.SearchDevice sDevice = null;           // 搜索设备窗口对象

        [DllImport("kernel32.dll", EntryPoint = "Beep")]
        // 第一个参数是指频率的高低，越大越高，第二个参数是指响的时间多长  
        public static extern int Beep(
        int dwFreq,
        int dwDuration
        );  

        #region 读写器能力

        private int minDB = 0;                                            // 最小功率
        private int maxDB = 36;                                           // 最大功率
        private int antCount = 2;                                         // 天线数目
        private List<Int32> bandList = new List<Int32>();                 // 频段列表
        private List<Int32> RFIDProtocolList = new List<Int32>();         // RFID协议列表

        #endregion

        public SingleMainForm()
        {
            
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        #region 窗体事件

        private void SingleMainForm_Shown(object sender, EventArgs e)
        {
            tsmi_SerialConn_Click(null, null);
            //MySingleForm.TestForm.Dialog.AddConnect formAddConnect = new MySingleForm.TestForm.Dialog.AddConnect(this, 0);
            //DialogResult dr = formAddConnect.ShowDialog(this);
            //this.Focus();
            //if (dr == DialogResult.OK)
            //{
            //    if (ClouReaderAPI.CLReader.DIC_CONNECT.Count == 1)
            //    {
            //        tssl_NowConnID.Text = ConnID;
            //        Init();
            //    }
            //}
        }

        private void SingleMainForm_Load(object sender, EventArgs e)
        {
            Rectangle clientRectangle = ClientRectangle;
            Point clientPoint = PointToScreen(new Point(0, 0));
            clientRectangle.Offset(clientPoint.X - Left, clientPoint.Y - Top - 5);
            Region = new Region(clientRectangle);
            this.Height = 650;
            this.Width = 1024;
            ReadConfig();
            if (IsEnglish)
            {
                tsmi_Debug.Visible = false;
            }
            CheckEnableButton();
            InitGPI();
        }
        // 窗体关闭事件
        private void SingleMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ClouReaderAPI.CLReader.RFID_OPTION.StopReader(ConnID);
        }


        #endregion

        #region 初始化过程
        /// <summary>
        /// 窗体初始化
        /// </summary>
        private void Init()
        {
            InitReaderProerty();

            CheckEnableButton();

            InitMultiConnect();

            StartWaitBeep();

            #region 天线能力

            foreach (var item in gb_ReadControl.Controls)
            {
                CheckBox cb = item as CheckBox;
                if (cb != null)
                {
                    int index = Int32.Parse(cb.Name.Substring(cb.Name.Length - 1, 1));
                    if (index > antCount)
                    {
                        cb.Enabled = false;
                        cb.Checked = false;
                    }
                    else 
                    {
                        cb.Enabled = true;
                    }
                }
            }

            #endregion

            dgv_Tags.AutoGenerateColumns = false;
            Type type = dgv_Tags.GetType();
            System.Reflection.PropertyInfo pi = type.GetProperty("DoubleBuffered",
            System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            pi.SetValue(dgv_Tags, true, null);

        }
        /// <summary>
        /// 标签回调
        /// </summary>
        /// <param name="bf">标签数据</param>
        public void CallBackTags(ClouReaderAPI.Protocol.BaseFrame bf)
        {
            Tag_Model tag_6C = null;
            try
            {
                tag_6C = new Tag_Model(bf.Data, 0);
            }
            catch (Exception ex) { System.Diagnostics.Debug.WriteLine(ex.Message + "!!!!"); }
            if (tag_6C == null || tag_6C.Result != 0x00) return;
            bool isNew = false;
            DataGridViewRow dgvr =null;
            lock (dic_Rows)
            {
                try
                {
                    if (!dic_Rows.ContainsKey(tag_6C.EPC + "|" + tag_6C.TID))
                    {
                        dgvr = new DataGridViewRow();
                        dgvr.CreateCells(dgv_Tags, new object[] { tag_6C.EPC, tag_6C.TID, tag_6C.UserData, tag_6C.TotalCount, tag_6C.ANT1_COUNT, tag_6C.ANT2_COUNT, tag_6C.ANT3_COUNT, tag_6C.ANT4_COUNT, tag_6C.ANT5_COUNT, tag_6C.ANT6_COUNT, tag_6C.ANT7_COUNT, tag_6C.ANT8_COUNT, tag_6C.RSSI });
                        dic_Rows.Add(tag_6C.EPC + "|" + tag_6C.TID, dgvr);
                        isNew = true;
                    }
                    else 
                    {
                        dgvr = dic_Rows[tag_6C.EPC + "|" + tag_6C.TID];
                    }
                }
                catch { }
            }
            AddSingleTag(tag_6C, dgvr, isNew);
            //Application.DoEvents();
        }
        /// <summary>
        /// 读取读写器属性
        /// </summary>
        private void InitReaderProerty()
        {
            string strReaderProperty = ClouReaderAPI.CLReader.RFID_OPTION.GetReaderProperty(ConnID);
            string[] str_array = strReaderProperty.Split('|');
            if (str_array.Length == 5)
            {
                try
                {
                    minDB = Int32.Parse(str_array[0]);
                    maxDB = Int32.Parse(str_array[1]);
                    antCount = Int32.Parse(str_array[2]);
                    string[] str_bandList = str_array[3].Split(',');
                    string[] str_RFIDProtocolList = str_array[4].Split(',');
                    for (int i = 0; i < str_bandList.Length; i++)
                    {
                        bandList.Add(Int32.Parse(str_bandList[i]));
                    }
                    for (int i = 0; i < str_RFIDProtocolList.Length; i++)
                    {
                        RFIDProtocolList.Add(Int32.Parse(str_RFIDProtocolList[i]));
                    }
                }
                catch { }
            }
        }
        /// <summary>
        /// 绑定数据源到表格
        /// </summary>
        private void InitDataGridView()
        {
            if (dgv_Tags.InvokeRequired)
            {
                dgv_Tags.BeginInvoke(new MethodInvoker(InitDataGridView), null);
                return;
            }
            try
            {
                Int32 scrollHeight = dgv_Tags.FirstDisplayedScrollingRowIndex;
                BindingSource bs = new BindingSource();
                bs.DataSource = ClouReaderAPI.CLReader.DIC_CONNECT[ConnID].dic_NowTags.Values;
                bs.SuspendBinding();
                dgv_Tags.DataSource = bs;
                dgv_Tags.FirstDisplayedScrollingRowIndex = scrollHeight;
            }
            catch { }
        }

        #endregion

        #region DataGridView操作方法及事件

        // 添加单个标签
        public void AddSingleTag(Tag_Model tag_6C, DataGridViewRow dgvr ,Boolean isNew)
        {
            if (this.dgv_Tags.InvokeRequired)
            {
                this.dgv_Tags.BeginInvoke(new AddTag(AddSingleTag), tag_6C, dgvr, isNew);
                return;
            }
            try
            {
                if (!isNew)
                {
                    Int64 newStr = (Int64)dgvr.Cells["clm_TotalCount"].Value + 1;
                    dgvr.Cells["clm_TotalCount"].Value = newStr;
                    if (tag_6C.ANT_NUM <= 8)
                    {
                        dgvr.Cells["clm_ANT" + tag_6C.ANT_NUM].Value = (Int64)dgvr.Cells["clm_ANT" + tag_6C.ANT_NUM].Value + 1;
                    }
                    dgvr.Cells["clm_RSSI"].Value = tag_6C.RSSI;
                    dgvr.Cells["clm_ReadTime"].Value = tag_6C.ReadTime;
                }
                else
                {
                    dgv_Tags.Rows.Add(dgvr);
                }
                this.led_Tag_ReadCount.Text = CLReader.DIC_CONNECT[ConnID].ProcessCount.ToString(); 
            }
            catch { }
        }

        // 单元格单击事件
        private void dgv_Tags_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                try
                {
                    if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                    {
                        dgv_Tags.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
                    }
                    else if (e.RowIndex >= 0 && e.ColumnIndex < 0)
                    {
                        dgv_Tags.Rows[e.RowIndex].Selected = true;
                        dgv_Tags.CurrentCell = dgv_Tags.Rows[e.RowIndex].Cells[0];
                    }
                }
                catch { }
            }
        }
        // 控制单击事件
        private void dgv_Tags_MouseDown(object sender, MouseEventArgs e)
        {
            dgv_Tags.CurrentCell = null;
        }
        // 右键菜单打开
        private void cmsForGridView_Opening(object sender, CancelEventArgs e)
        {
            if (GetNowSelectRow() == null || IsStartRead == true)
            {
                cms_tsmi_Copy.Enabled = false;
                cms_tsmi_WriteEpc.Enabled = false;
                cms_tsmi_WriteUserData.Enabled = false;
            }
            else 
            {
                cms_tsmi_Copy.Enabled = true;
                cms_tsmi_WriteEpc.Enabled = true;
                cms_tsmi_WriteUserData.Enabled = true;
            }
        }
        // 写EPC
        private void cms_tsmi_WriteEpc_Click(object sender, EventArgs e)
        {
            tsb_Write_EPC_Click(null, null);
        }
        // 写用户数据
        private void cms_tsmi_WriteUserData_Click(object sender, EventArgs e)
        {
            tsb_Write_UserData_Click(null, null);
        }
        // 复制单元格
        private void cms_tsmi_Copy_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetDataObject(dgv_Tags.SelectedCells[0].Value.ToString());
            }
            catch { }
        }
        // 清空列表
        private void cms_tsmi_ClearList_Click(object sender, EventArgs e)
        {
            tsb_ClearList_Click(null, null);
        }
        // 获得当前选择的列
        private DataGridViewRow GetNowSelectRow() 
        {
            DataGridViewRow dgr_Select = null;
            if (dgv_Tags.CurrentCell != null)
            {
                dgr_Select = dgv_Tags.CurrentRow;
            }
            else if (dgv_Tags.SelectedRows.Count > 0)
            {
                dgr_Select = dgv_Tags.SelectedRows[0];
            }
            return dgr_Select;
        }

        #endregion

        #region 通用辅助方法
        /// <summary>
        /// 关闭当前连接
        /// </summary>
        public void CloseNowConnect()
        {
            if (!String.IsNullOrEmpty(ConnID))
            {
                try
                {
                    if (IsStartRead)         // 正在读取标签的情况断开连接
                    {
                        ClouReaderAPI.CLReader.RFID_OPTION.StopReader(ConnID);
                        IsStartRead = false;
                    }
                    ClouReaderAPI.CLReader.CloseConn(ConnID);
                    ConnID = "";
                    tssl_NowConnID.Text = "---";
                }
                catch { }
            }
            CheckEnableButton();
        }
        /// <summary>
        /// 检查当前是否连接读写器
        /// </summary>
        private Boolean CheckNowConnect() 
        {
            if (String.IsNullOrEmpty(ConnID))
            {
                ShowMessage("Please connect the reader first！");
                return false;
            }
            else 
            {
                return true;
            }
        }
        /// <summary>
        /// 读写器主动连接服务器调用事件，单读写器模式
        /// </summary>
        private void TCPPortConnectting(string newConnID) 
        {
            if (this.InvokeRequired) 
            {
                this.BeginInvoke(new TCPPortConn(TCPPortConnectting), newConnID);
                return;
            }
            if (!String.IsNullOrEmpty(ConnID))
            {
                if (DialogResult.OK == ShowQuestion("A new reader is actively connected to the PC, whether to close the current connection？"))
                {
                    CloseNowConnect();
                    this.ConnID = newConnID;
                    tssl_NowConnID.Text = ConnID;
                    Init();
                }
                else
                {
                    try
                    {
                        ClouReaderAPI.CLReader.CloseConn(newConnID);
                    }
                    catch { }
                }
            }
            else
            {
                CloseNowConnect();
                this.ConnID = newConnID;
                tssl_NowConnID.Text = ConnID;
                Init();
            }
        }
        /// <summary>
        /// 获得读取TAG的参数
        /// </summary>
        /// <returns></returns>
        private String GetReadTagParam() 
        {
            String rt = "";

            #region 获取天线号 & 单次读取/循环读取

            Int32 antNUM = 0;
            Int32 singleOrWhile = -1;
            foreach (var item in gb_ReadControl.Controls)
            {
                CheckBox control = item as CheckBox;
                if (control != null && control.Checked)
                {
                    antNUM += Int32.Parse(control.Tag.ToString());
                }
            }
            foreach (var item in gb_ReadType.Controls)
            {
                 RadioButton control = item as RadioButton;
                 if (control != null && control.Checked)
                 {
                     singleOrWhile = Byte.Parse(control.Tag.ToString());
                 }
            }
            rt += (Byte)antNUM + "|" + singleOrWhile + "|";

            #endregion

            #region 可选参数

            if (!String.IsNullOrEmpty(readVarParam_6C)) 
            {
                rt += readVarParam_6C;
            }

            #endregion
            rt = rt.TrimEnd('|');
            return rt;
        }
        /// <summary>
        /// 获得天线编号
        /// </summary>
        /// <returns></returns>
        private Int32 GetAntNum() 
        {
            Int32 antNUM = 0;
            foreach (var item in gb_ReadControl.Controls)               // 获取天线编号
            {
                CheckBox control = item as CheckBox;
                if (control != null && control.Checked)
                {
                    antNUM += Int32.Parse(control.Tag.ToString());
                }
            }
            return antNUM;
        }
        /// <summary>
        /// 更新状态栏
        /// </summary>
        public void StartFlush()
        {
            if (IsFlush == true) return;
            ThreadPool.QueueUserWorkItem(new WaitCallback(delegate(object o)
            {
                IsFlush = true;
                long flushCount = 0;
                while (IsFlush)
                {
                    if (flushCount % 2 == 0) FlushState();
                    flushCount++;
                    System.Threading.Thread.Sleep(500);
                    // Application.DoEvents();
                }
            }));
        }
        /// <summary>
        /// 将DataGridView的数据导出成逗号文件
        /// </summary>
        /// <param name="fileName">文件名称</param>
        /// <param name="myDGV">控件ID</param>
        public void ExportTXT(string fileName, DataGridView myDGV) 
        {
            string saveFileName = "";
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.DefaultExt = "csv";
            saveDialog.Filter = "csv file|*.csv";
            saveDialog.FileName = fileName;
            saveDialog.ShowDialog(this);
            this.Focus();
            saveFileName = saveDialog.FileName;
            if (saveFileName.IndexOf(":") < 0) return; //被点了取消
            using(FileStream fs = File.Open(saveFileName, FileMode.Create,FileAccess.ReadWrite))
            {
                StreamWriter sw = new StreamWriter(fs);
                //写入数值
                for (int r = 0; r < myDGV.Rows.Count; r++)
                {
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < myDGV.ColumnCount; i++)
                    {
                        if (myDGV.Columns[i].Visible == true)
                        {
                            sb.Append(myDGV.Rows[r].Cells[i].Value + ",");
                        }
                    }
                    sw.WriteLine(sb.ToString().TrimEnd(','));
                }
                sw.Close();
            }
            ShowMessage("csv Save Success！");
        }
        /// <summary>
        /// 将DataGridView的数据导出成Excel
        /// </summary>
        /// <param name="fileName">文件名称</param>
        /// <param name="myDGV">控件ID</param>
        private void ExportExcel(string fileName, DataGridView myDGV)
        {
            string saveFileName = "";
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.DefaultExt = "xls";
            saveDialog.Filter = "Excel File|*.xls";
            saveDialog.FileName = fileName;
            saveDialog.ShowDialog(this);
            this.Focus();
            saveFileName = saveDialog.FileName;
            if (saveFileName.IndexOf(":") < 0) return; //被点了取消
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            if (xlApp == null)
            {
                ShowMessage("Excel Create Error，Excel No support");
                return;
            }
            Microsoft.Office.Interop.Excel.Workbooks workbooks = xlApp.Workbooks;
            Microsoft.Office.Interop.Excel.Workbook workbook = workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
            Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];//取得sheet1
            //写入标题
            for (int i = 0; i < myDGV.ColumnCount; i++)
            {
                if(myDGV.Columns[i].Visible ==true)
                    worksheet.Cells[1, i + 1] = myDGV.Columns[i].HeaderText;
            }
            //写入数值
            for (int r = 0; r < myDGV.Rows.Count; r++)
            {
                for (int i = 0; i < myDGV.ColumnCount; i++)
                {
                    if (myDGV.Columns[i].Visible == true)
                        worksheet.Cells[r + 2, i + 1] = "'" + myDGV.Rows[r].Cells[i].Value.ToString();
                }
                System.Windows.Forms.Application.DoEvents();
            }
            worksheet.Columns.EntireColumn.AutoFit();//列宽自适应
            if (saveFileName != "")
            {
                try
                {
                    workbook.Saved = true;
                    workbook.SaveCopyAs(saveFileName);
                }
                catch (Exception ex)
                {
                    ShowMessage("Error when exporting the file. The file may be open！\n" + ex.Message);
                }
            }
            xlApp.Quit();
            GC.Collect();//强行销毁
            ShowMessage("xls Save Success!");
        }
        /// <summary>
        /// 更新当前状态下的按钮的可操作性
        /// </summary>
        private void CheckEnableButton()
        {
            #region 还原控制状态

            foreach (ToolStripItem item in menuStrip.Items)
            {
                item.Enabled = true;
            }
            foreach (ToolStripItem item in tsm_Main.Items)
            {
                item.Enabled = true;
            }

            #endregion
            
            if (String.IsNullOrEmpty(ConnID))
            {
                foreach (ToolStripItem item in menuStrip.Items)
                {
                    item.Enabled = false;
                }
                tsmi_Connect.Enabled = true;
                tsmi_SearchDevice.Enabled = true;
                tsmi_Language.Enabled = true;
                foreach (ToolStripItem item in tsm_Main.Items)
                {
                    item.Enabled = false;
                }
            }
            else 
            {
                if (IsStartRead)
                {

                    foreach (ToolStripItem item in menuStrip.Items)
                    {
                        item.Enabled = false;
                    }
                    tsmi_Connect.Enabled = true;
                    tsmi_Helper.Enabled = true;
                    tsb_Read_Epc.Enabled = false;
                    tsb_Read_EPCTID.Enabled = false;
                    tsb_Read_Global.Enabled = false;
                    tsb_Write_EPC.Enabled = false;
                    tsb_Write_UserData.Enabled = false;
                    tsb_WriteGlobal.Enabled = false;
                }
            }
            
        }
        /// <summary>
        /// 获取标签读取参数
        /// </summary>
        /// <param name="varParam">可选参数</param>
        /// <returns></returns>
        public String GetReadTagParam(String varParam) 
        {
            String rt = "";

            #region 获取天线号 & 单次读取/循环读取

            Int32 antNUM = 0;
            Int32 singleOrWhile = -1;
            foreach (var item in gb_ReadControl.Controls)
            {
                CheckBox control = item as CheckBox;
                if (control != null && control.Checked)
                {
                    antNUM += Int32.Parse(control.Tag.ToString());
                }
            }
            foreach (var item in gb_ReadType.Controls)
            {
                RadioButton control = item as RadioButton;
                if (control != null && control.Checked)
                {
                    singleOrWhile = Byte.Parse(control.Tag.ToString());
                }
            }
            rt += (Byte)antNUM + "|" + singleOrWhile + "|";

            #endregion

            #region 可选参数

            if (!String.IsNullOrEmpty(varParam))
            {
                rt += varParam;
            }

            #endregion

            rt = rt.TrimEnd('|');
            return rt;
        }

        #endregion

        #region 菜单栏事件
        
        #region 切换连接

        // 打开串口连接
        private void tsmi_SerialConn_Click(object sender, EventArgs e)
        {
            if (!IsMultiConnect) { CloseNowConnect(); }
            MySingleForm.TestForm.Dialog.AddConnect addConnForm = new MySingleForm.TestForm.Dialog.AddConnect(this, 0);
            DialogResult dr = addConnForm.ShowDialog(this);
            this.Focus();
            if (dr == DialogResult.OK)
            {
                tssl_NowConnID.Text = ConnID;
                Init();
            }
            else if (dr == DialogResult.No)
            {
                ShowMessage("Open Connect Failure！");
            }
        }
        // 打开TCP连接
        private void tsmi_TCPClient_Click(object sender, EventArgs e)
        {
            if (!IsMultiConnect) { CloseNowConnect(); }
            MySingleForm.TestForm.Dialog.AddConnect addConnForm = new MySingleForm.TestForm.Dialog.AddConnect(this, 1);
            DialogResult dr = addConnForm.ShowDialog(this);
            this.Focus();
            if (dr == DialogResult.OK)
            {
                tssl_NowConnID.Text = ConnID;
                Init();
            }
            else if (dr == DialogResult.No)
            {
                ShowMessage("Open Connect Failure！");
            }
        }
        // 打开485连接
        private void tsmi_485Conn_Click(object sender, EventArgs e)
        {
            if (!IsMultiConnect) { CloseNowConnect(); }
            MySingleForm.TestForm.Dialog.AddConnect addConnForm = new MySingleForm.TestForm.Dialog.AddConnect(this, 2);
            DialogResult dr = addConnForm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                tssl_NowConnID.Text = ConnID;
                Init();
            }
            else if(dr == DialogResult.No)
            {
                ShowMessage("Open Connect Failure！");
            }
        }
        // 启动TCP服务器
        private void tsmi_TCPServer_Click(object sender, EventArgs e)
        {
            MySingleForm.TestForm.TCP_Server serverForm = new MySingleForm.TestForm.TCP_Server(ConnID, this);
            serverForm.ShowDialog(this);
            this.Focus();
        }
        // 多读写器轮循
        private void tsmi_StepRead_Click(object sender, EventArgs e)
        {
            MySingleForm.TestForm.Performance_R_List rListForm = new MySingleForm.TestForm.Performance_R_List();
            rListForm.ShowDialog(this);
            this.Focus();
        }
        // 从搜索到的设备连接读写器
        public void searchDeviceConnect(string connParam) 
        {
            try
            {
                if (!IsMultiConnect) { CloseNowConnect(); }
                bool isConnect = CLReader.CreateTcpConn(connParam, this);
                if (isConnect)
                {
                    ConnID = connParam;
                    tssl_NowConnID.Text = ConnID;
                    Init();
                    this.Focus();
                }
                else
                {
                    ShowMessage("Open Connect Failure！");
                }
            }
            catch { }
        }

        // 退出
        private void tsmi_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion
        
        #region 配置
        // 串口设置
        private void tsmi_Reader_Serial_Click(object sender, EventArgs e)
        {
            MySingleForm.SettingForm.SettingReader_SerialPort serialForm = new MySingleForm.SettingForm.SettingReader_SerialPort(ConnID,this);
            serialForm.ShowDialog(this);
            this.Focus();
        }
        // 网口设置
        private void tsmi_Reader_TCP_Click(object sender, EventArgs e)
        {
            MySingleForm.SettingForm.SettingReader_TCPPort tcpForm = new MySingleForm.SettingForm.SettingReader_TCPPort(ConnID, this);
            tcpForm.ShowDialog(this);
            this.Focus();
        }
        // 485设置
        private void tsmi_Reader_485_Click(object sender, EventArgs e)
        {
            MySingleForm.SettingForm.SettingReader_485Port _485Form = new MySingleForm.SettingForm.SettingReader_485Port(ConnID, this);
            _485Form.ShowDialog(this);
            this.Focus();
        }
        // TCP服务端与客户端模式切换
        private void tsmi_Reader_TCPServerOrClient_Click(object sender, EventArgs e)
        {
            MySingleForm.SettingForm.SettingReader_TCPServerOrClient serverOrClient = new MySingleForm.SettingForm.SettingReader_TCPServerOrClient(ConnID, this);
            serverOrClient.ShowDialog(this);
            this.Focus();
        }
        // 跳频管理
        private void tsmi_RIFD_RF_Click(object sender, EventArgs e)
        {
            MySingleForm.SettingForm.SettingRFID_RF rfForm = new MySingleForm.SettingForm.SettingRFID_RF(ConnID, this);
            rfForm.ShowDialog(this);
            this.Focus();
        }
        // 重复标签过渡
        private void tsmi_RFID_TagFilter_Click(object sender, EventArgs e)
        {
            MySingleForm.SettingForm.SettingRFID_TagFilter filterForm = new MySingleForm.SettingForm.SettingRFID_TagFilter(ConnID, this);
            filterForm.ShowDialog(this);
            this.Focus();
        }
        // 自动空闲
        private void tsmi_RFID_AutoFree_Click(object sender, EventArgs e)
        {
            MySingleForm.SettingForm.SettingRFID_AutoFree freeForm = new MySingleForm.SettingForm.SettingRFID_AutoFree(ConnID, this);
            freeForm.ShowDialog(this);
            this.Focus();
        }
        // GPI设置
        private void tsmi_GPISetting_Click(object sender, EventArgs e)
        {
            MySingleForm.SettingForm.SettingGPI settingGPIForm = new MySingleForm.SettingForm.SettingGPI(ConnID, this);
            settingGPIForm.Show();
        }
        // GPI查询
        private void tsmi_GPISearch_Click(object sender, EventArgs e)
        {
            MySingleForm.SettingForm.SettingGetGPI settingGetGPI = new MySingleForm.SettingForm.SettingGetGPI(ConnID, this);
            settingGetGPI.Show();
        }
        // GPO配置
        private void tsmi_GPOSetting_Click(object sender, EventArgs e)
        {
            MySingleForm.SettingForm.SettingSetGPO settingSetGPOForm = new MySingleForm.SettingForm.SettingSetGPO(ConnID, this);
            settingSetGPOForm.Show();
        }
        // 韦根控制
        private void tsmi_WG_Click(object sender, EventArgs e)
        {
            MySingleForm.SettingForm.SettingSetWG settingSetWG = new MySingleForm.SettingForm.SettingSetWG(ConnID, this);
            settingSetWG.Show();
        }

        // 恢复出厂设置
        private void tsmi_RestoreFactory_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == ShowQuestion("Confrim Restore？"))
            {
                ShowMessage(ClouReaderAPI.CLReader.PARAM_SET.SetReaderRestoreFactory(ConnID, "5AA5A55A"));
            }
        }

        // 获取标签缓存数据
        private void tsmi_GetCacheTag_Click(object sender, EventArgs e)
        {
            if (CheckNowConnect())
            {
                String rtStr = ClouReaderAPI.CLReader.PARAM_SET.GetBreakPointCacheTag(ConnID);
                if (rtStr.Equals("0"))
                {
                    ShowMessage("Success！");
                }
                else if (rtStr.Equals("1"))
                {
                    ShowMessage("Null！");
                }
                else if(rtStr.Equals("2"))
                {
                    ShowMessage("Recive Over！");
                }
                else 
                {
                    ShowMessage(rtStr);
                }
            }
        }
        // 清空标签缓存数据
        private void tsmi_ClearCacheTag_Click(object sender, EventArgs e)
        {
            if (CheckNowConnect()) 
            {
                String rtStr = ClouReaderAPI.CLReader.PARAM_SET.ClearBreakPointCache(ConnID);
                ShowMessage(rtStr);
            }
        }

        // 高级
        private void tsmi_AdvancedSettings_Click(object sender, EventArgs e)
        {
            if (CheckNowConnect())
            {
                MySingleForm.TestForm.RFID_Option form_Opion = new MySingleForm.TestForm.RFID_Option(ConnID, this);
                form_Opion.ShowDialog(this);
                this.Focus();
            }
        }

        #endregion

        #region 测试
        // 调试开关
        private void tsmi_DebugOn_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem tsmi = sender as ToolStripMenuItem;
            if (tsmi != null)
            {
                if (!tsmi.Checked)
                {
                    tsmi.Checked = true;
                    IsWriteDebug = true;
                    panel_Debug.Height = 90;
                }
                else
                {
                    tsmi.Checked = false;
                    IsWriteDebug = false;
                    panel_Debug.Height = 20;
                }
            }
        }
        // 功率较准
        private void tsmi_PowerCalibration_Click(object sender, EventArgs e)
        {
            MySingleForm.TestForm.PowerCalibration pcForm = new MySingleForm.TestForm.PowerCalibration(ConnID, this);
            pcForm.Show();
        }
        // 性能读测试
        private void tsmi_TagReadTest_Click(object sender, EventArgs e)
        {
            MySingleForm.TestForm.Performance_R perForm = null;
            if (rb_6c.Checked)
            {
                perForm = new MySingleForm.TestForm.Performance_R(this, 0, GetReadTagParam());
            }
            else if(rb_6b.Checked)
            {
                perForm = new MySingleForm.TestForm.Performance_R(this, 1, GetReadTagParam());
            }
            else if (rb_gb.Checked) 
            {
                perForm = new MySingleForm.TestForm.Performance_R(this, 2, GetReadTagParam());
            }
            perForm.ShowDialog(this);
            this.Focus();
        }
        // 性能写测试
        private void tsmi_TagReadWriteTest_Click(object sender, EventArgs e)
        {
            DataGridViewRow dgvr = GetNowSelectRow();
            if (dgvr != null)
            {
                Int32 antNUM = 0;
                String[] args = new String[] { "", "", "" };
                args[0] = dgvr.Cells["clm_EPC"].Value.ToString();
                args[1] = dgvr.Cells["clm_TID"].Value.ToString();
                args[2] = dgvr.Cells["clm_UserData"].Value.ToString();
                antNUM = GetAntNum();
                if (dgvr.Cells["clm_TagType"].Value.Equals("6C"))           // 读写6C标签
                {
                    MySingleForm.TestForm.Performance_RW performance_RW = new MySingleForm.TestForm.Performance_RW(ConnID, args, antNUM, this);
                    performance_RW.ShowDialog(this);
                    this.Focus();
                }
                else if (dgvr.Cells["clm_TagType"].Value.Equals("GB"))      // 读写GB标签
                {
                    MySingleForm.TestForm.Performance_RW_GB performance_rw = new MySingleForm.TestForm.Performance_RW_GB(ConnID, args, antNUM, this);
                    performance_rw.ShowDialog(this);
                    this.Focus();
                }
                else
                {
                    ShowMessage("Parameter error！");
                }
            }
            else
            {
                ShowMessage("Please select a data column！");
            }
        }
        // 6B_6C读测试
        private void tsmi_TagRead6B_6C_Click(object sender, EventArgs e)
        {
            rb_Single.Checked = true;
            rb_While.Checked = false;
            MySingleForm.TestForm.Performmance_R_6B_6C perForm = new MySingleForm.TestForm.Performmance_R_6B_6C(this, 0, GetReadTagParam("2,0006"), GetReadTagParam("0"));
            perForm.Show();
        }
        
        // API功能测试
        private void tsmi_API_Test_Click(object sender, EventArgs e)
        {
            MySingleForm.TestForm.APITest apiTestForm = new MySingleForm.TestForm.APITest(ConnID, this);
            apiTestForm.Show();
        }

        // 黑白名单测试
        private void tsmi_BlacklistBeep_Click(object sender, EventArgs e)
        {
            MySingleForm.TestForm.BlacklistBeep blackForm = null;
            if (rb_6c.Checked)
            {
                blackForm = new MySingleForm.TestForm.BlacklistBeep(ConnID, GetReadTagParam(),this);
            }
            blackForm.ShowDialog(this);
            this.Focus();
        }

        private void tsmi_CheckListBeep_Click(object sender, EventArgs e)
        {
            MySingleForm.TestForm.CheckListTest checkForm = null;
            if (rb_6c.Checked)
            {
                checkForm = new MySingleForm.TestForm.CheckListTest(ConnID, GetReadTagParam(), this);
                checkForm.ShowDialog(this);
                this.Focus();
            }
            else 
            {
                ShowMessage("Only supports 6C Tags！");
            }
        }
        // 测试高级选项卡
        private void tsmi_Test_gj_Click(object sender, EventArgs e)
        {
            if (CheckNowConnect())
            {
                MySingleForm.Test_Option form_Opion = new MySingleForm.Test_Option(ConnID, this);
                form_Opion.ShowDialog(this);
                this.Focus();
            }
        }
        // 外接集线器测试
        private void tsms_HubTest_Click(object sender, EventArgs e)
        {
            HubMainForm hmForm = new HubMainForm();
            hmForm.Show();
        }

        #endregion

        #region 工具

        // 基带软件升级
        private void tsmi_BasebandSoftUpdate_Click(object sender, EventArgs e)
        {
            if (CheckNowConnect())
            {
                MyForm.Dialog.SoftUpdate softUpdate = new MyForm.Dialog.SoftUpdate(ConnID, "Baseband");
                softUpdate.ShowDialog(this);
                this.Focus();
            }
        }
        // 应用软件升级
        private void tsmi_ApplicationSoftUpdate_Click(object sender, EventArgs e)
        {
            if (CheckNowConnect())
            {
                MyForm.Dialog.SoftUpdate softUpdate = new MyForm.Dialog.SoftUpdate(ConnID, "Application");
                softUpdate.ShowDialog(this);
                this.Focus();
            }
        }
        // 查看读写器信息
        private void tsmi_GetReaderMsg_Click(object sender, EventArgs e)
        {
            if (CheckNowConnect())
            {
                try
                {
                    String vStr = ClouReaderAPI.CLReader.PARAM_SET.GetReaderInformation(ConnID);
                    String[] arrStr = vStr.Split('|');
                    if (arrStr.Length == 3)
                    {
                        UInt32 sdTime = 1;
                        if (UInt32.TryParse(arrStr[2], out sdTime))
                        {
                            UInt32 iDay = sdTime / (24 * 60 * 60);
                            UInt32 iHours = (sdTime % (24 * 60 * 60)) / (60 * 60);
                            UInt32 iMinute = ((sdTime % (24 * 60 * 60)) % (60 * 60)) / 60;
                            UInt32 iSecond = ((sdTime % (24 * 60 * 60)) % (60 * 60)) % 60;
                            // ShowSearchResult("应用软件版本：" + arrStr[0] + "\r\n读写器名称：" + arrStr[1].Substring(2, arrStr[1].Length - 2) + "\r\n读写器上电时间：" + iDay + "天 " + iHours + "时 " + iMinute + "分");
                            ShowSearchResult("Application version：" + arrStr[0] + "\r\n Reader Name：" + arrStr[1].Substring(2, arrStr[1].Length - 2) + "\r\nPower on Time：" + iDay + " D " + iHours + " M " + iMinute + " S");
                        }
                    }
                    else
                    {
                        MessageBox.Show(vStr);
                    }
                }
                catch { }
            }
        }
        // 查看基带软件版本
        private void tsmi_GetBaseBandVersion_Click(object sender, EventArgs e)
        {
            if (CheckNowConnect())
            {
                String vStr = ClouReaderAPI.CLReader.PARAM_SET.GetReaderBaseBandSoftVersion(ConnID);
                ShowSearchResult("Baseband software version：" + vStr);
            }
        }
        // 导出Excel
        private void tsmi_Export_Excel_Click(object sender, EventArgs e)
        {
            try
            {
                ExportExcel("clou-exportTags.xls", dgv_Tags);
            }
            catch
            {
                ShowMessage("Export failure!，Microsoft.Excel not Found!");
            }
        }
        // 导出CSV
        private void tmsi_Export_Text_Click(object sender, EventArgs e)
        {
            try
            {
                ExportTXT("clou-exportTags.csv", dgv_Tags);
            }
            catch
            {
                ShowMessage("Export failure!");
            }
        }
        // 声音控制
        private void tsmi_Sound_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripMenuItem tsmi = e.ClickedItem as ToolStripMenuItem;
            if (tsmi != null) 
            {
                foreach (var item in tsmi_Sound.DropDownItems)
                {
                    ToolStripMenuItem tsmi_Item = item as ToolStripMenuItem;
                    if (tsmi_Item != null) 
                    {
                        tsmi_Item.Checked = false;
                    }
                }
                tsmi.Checked = true;
                this.beepType = Int32.Parse(tsmi.Tag.ToString());
            }
        }

        // 读标签时拉高GPO
        private void tsmi_ReadGPO_Click(object sender, EventArgs e)
        {
            MySingleForm.Tools.ToolsSetGPO toolsSetGPO = new MySingleForm.Tools.ToolsSetGPO(ConnID, this);
            toolsSetGPO.Show();
        }


        #endregion

        #endregion

        #region 实现接口方法
        /// <summary>
        /// 输出调试信息
        /// </summary>
        /// <param name="msg">调试信息</param>
        public void WriteDebugMsg(string msg)
        {
            if (!IsWriteDebug) return;
            if (tb_DebugMsg.InvokeRequired)
            {
                tb_DebugMsg.BeginInvoke(new WriteDebug(WriteDebugMsg), msg);
                return;
            }
            if (nowDebugMessageCount >= 1000)
            {
                nowDebugMessageCount = 0;
                tb_DebugMsg.Clear();
            }
            tb_DebugMsg.AppendText(msg + Environment.NewLine);
            nowDebugMessageCount++;
        }
        /// <summary>
        /// 输出日志消息
        /// </summary>
        /// <param name="msg"></param>
        public void WriteLog(string msg)
        {
            // throw new NotImplementedException();
        }
        /// <summary>
        /// TCP客户端模式的读写器主动连接
        /// </summary>
        /// <param name="connID"></param>
        public void PortConneting(String connID)
        {
            if (IsMultiConnect)                     // 多读写器模式
            {
                WriteDebugMsg("New Reader Connected：" + connID);
                InitMultiConnect();
            }
            else                                    // 单读写器模式
            {
                TCPPortConnectting(connID);
            }
        }
        /// <summary>
        /// TCP对方主动关闭连接
        /// </summary>
        public void PortClosing(String connID)
        {
            if (this.ConnID.Equals(connID)) 
            {
                CloseNowConnect();
                Init();
            }
            WriteDebugMsg(connID + "Disconnect...");
        }
        /// <summary>
        ///  标签信息输出
        /// </summary>
        /// <param name="tag_Model"></param>
        public void OutPutTags(Tag_Model tag_Model)
        {
            ReadTagBeep();
            if(!IsShowTag) return;
            if (tag_Model == null || tag_Model.Result != 0x00) return;
            bool isNew = false;
            DataGridViewRow dgvr = null;
            lock (dic_Rows)
            {
                try
                {
                    if (!dic_Rows.ContainsKey(tag_Model.EPC + "|" + tag_Model.TID))
                    {
                        dgvr = new DataGridViewRow();
                        dgvr.CreateCells(dgv_Tags, new object[] { tag_Model.ReaderName, tag_Model.TagType, tag_Model.EPC, tag_Model.TID, tag_Model.UserData, tag_Model.TagetData, tag_Model.TotalCount, tag_Model.ANT1_COUNT, tag_Model.ANT2_COUNT, tag_Model.ANT3_COUNT, tag_Model.ANT4_COUNT, tag_Model.ANT5_COUNT, tag_Model.ANT6_COUNT, tag_Model.ANT7_COUNT, tag_Model.ANT8_COUNT, tag_Model.RSSI, tag_Model.Frequency, tag_Model.Phase, tag_Model.ReadTime });
                        dic_Rows.Add(tag_Model.EPC + "|" + tag_Model.TID, dgvr);
                        isNew = true;
                    }
                    else
                    {
                        dgvr = dic_Rows[tag_Model.EPC + "|" + tag_Model.TID];
                    }
                }
                catch { }
            }
            AddSingleTag(tag_Model, dgvr, isNew);
        }
        /// <summary>
        ///  读标签结束消息
        /// </summary>
        public void OutPutTagsOver()
        {
            // lb_tagTotalCount.Text = dic_Rows.Count.ToString();
            this.led_Tag_Count.Text = dic_Rows.Count.ToString();
            IsFlush = false;
        }
        /// <summary>
        /// GPIO触发消息
        /// </summary>
        /// <param name="gpiIndex"></param>
        /// <param name="gpiState"></param>
        /// <param name="startOrStop"></param>
        public void GPIControlMsg(int gpiIndex, int gpiState, int startOrStop)
        {
            if (startOrStop == 0)
            {
                GPI_Start(gpiIndex, gpiState);
            }
            else 
            {
                GPI_End(gpiIndex, gpiState);
            }
        }
        /// <summary>
        /// 实时数据显示
        /// </summary>
        public void FlushState()
        {
            if (this.lb_ReceiveCount.InvokeRequired)
            {
                this.dgv_Tags.BeginInvoke(new FlushState(FlushState), null);
                return;
            }
            Monitor.Enter(dgv_Tags);
            try
            {
                long nowTagCount = CLReader.DIC_CONNECT[ConnID].ProcessCount;
                this.lb_ReceiveCount.Text = nowTagCount.ToString();
                this.tssl_CacheSize.Text = CLReader.DIC_CONNECT[ConnID].receiveBufferManager.DataCount.ToString();
                // this.lb_tagTotalCount.Text = CLReader.DIC_CONNECT[ConnID].dic_NowTags.Count.ToString();
                // this.lb_tagTotalCount.Text = dic_Rows.Count.ToString();
                this.led_Tag_Count.Text = dic_Rows.Count.ToString();
                Int32 totalMinutes = (Int32)((DateTime.Now - TJ_Run_Start).TotalMilliseconds / 1000);
                // lb_ReadTime.Text = totalMinutes +" S";
                led_Time.Text = totalMinutes.ToString();
                long l_Speed = Math.Abs(nowTagCount - TJ_LastTagcount);
                // lb_ReadTagSpeed.Text = (l_Speed < 0 ? 0 : l_Speed) + " T/S";
                led_Speed.Text = l_Speed.ToString();
                TJ_LastTagcount = CLReader.DIC_CONNECT[ConnID].ProcessCount;

                float cpuLoad = pc_Processor.NextValue();
                tssl_CPULoad.Text = cpuLoad.ToString("F2") + "%";           // CPU使用率

            }
            catch { }
            Monitor.Exit(dgv_Tags);
        }
        /// <summary>
        /// 显示查询结果
        /// </summary>
        /// <param name="msg">结果信息</param>
        public void ShowSearchResult(String msg) 
        {
            MySingleForm.TestForm.Dialog.SearchResult srForm = new MySingleForm.TestForm.Dialog.SearchResult(msg);
            srForm.Show();
        }

        #endregion

        #region 工具栏事件
        
        // 读EPC
        private void tsb_Read_Epc_Click(object sender, EventArgs e)
        {
            String rt = "";
            ClouReaderAPI.CLReader.RFID_OPTION.StopReader(ConnID);
            tsb_ClearList_Click(null, null);            // 清空列表
            if (rb_6c.Checked)
            {
                rt = ClouReaderAPI.CLReader.RFID_OPTION.GetEPC(ConnID, GetReadTagParam(""));
            }
            else if (rb_6b.Checked)
            {
                rt = ClouReaderAPI.CLReader.RFID_OPTION.Get6B(ConnID, GetReadTagParam("0"));
            }
            else if (rb_gb.Checked)
            {
                rt = ClouReaderAPI.CLReader.RFID_OPTION.GetGB(ConnID, GetReadTagParam(""));
            }
            if (!rt.StartsWith("0")) { ShowMessage("Read failed，Timeout or Antenna not selected！"); return; }
            tsb_Read_Enable();
        }
        // 读EPC&TID
        private void tsb_Read_EPCTID_Click(object sender, EventArgs e)
        {
            String rt = "";
            ClouReaderAPI.CLReader.RFID_OPTION.StopReader(ConnID);
            tsb_ClearList_Click(null, null);            // 清空列表
            if (rb_6c.Checked)
            {
                rt = ClouReaderAPI.CLReader.RFID_OPTION.GetEPC(ConnID, GetReadTagParam("2,0006"));
            }
            else if (rb_6b.Checked)
            {
                rt = ClouReaderAPI.CLReader.RFID_OPTION.Get6B(ConnID, GetReadTagParam("0"));
            }
            else if (rb_gb.Checked)
            {
                rt = ClouReaderAPI.CLReader.RFID_OPTION.GetGB(ConnID, GetReadTagParam("2,0006"));
            }
            if (!rt.StartsWith("0")) { ShowMessage("Read failed，Timeout or Antenna not selected！"); return; }
            tsb_Read_Enable();
        }
        // 自定义读
        private void tsb_Read_Global_Click(object sender, EventArgs e)
        {
            String rtStr = "";
            tsb_ClearList_Click(null, null);            // 清空列表
            if (rb_6c.Checked)                          // 6C
            {
                MySingleForm.TestForm.ReadTag_Param readTagParam = new MySingleForm.TestForm.ReadTag_Param(this, 0);
                DialogResult rt = readTagParam.ShowDialog(this);
                this.Focus();
                if (rt == DialogResult.OK) 
                {
                    rtStr = ClouReaderAPI.CLReader.RFID_OPTION.GetEPC(ConnID, GetReadTagParam(readVarParam_6C));
                }
            }
            else if (rb_6b.Checked)                     // 6B
            {
                MySingleForm.TestForm.ReadTag_Param readTagParam = new MySingleForm.TestForm.ReadTag_Param(this, 1);
                DialogResult rt = readTagParam.ShowDialog(this);
                this.Focus();
                if (rt == DialogResult.OK)
                {
                    rtStr = ClouReaderAPI.CLReader.RFID_OPTION.Get6B(ConnID, GetReadTagParam(readVarParam_6B));
                }
            }
            else if (rb_gb.Checked)                    // GB
            {
                MySingleForm.TestForm.ReadTag_Param readTagParam = new MySingleForm.TestForm.ReadTag_Param(this, 2);
                DialogResult rt = readTagParam.ShowDialog(this);
                this.Focus();
                if (rt == DialogResult.OK)
                {
                    rtStr = ClouReaderAPI.CLReader.RFID_OPTION.GetGB(ConnID, GetReadTagParam(readVarParam_GB));
                }
            }
            if (rtStr.StartsWith("0"))
            {
                tsb_Read_Enable();
            }
            else if(!String.IsNullOrEmpty(rtStr))
            {
                ShowMessage(rtStr);
            }
        }
        // 读控制状态
        private void tsb_Read_Enable() 
        {
            CLReader.DIC_CONNECT[ConnID].ProcessCount = 0;  // 该连接的计数器清零。
            TJ_LastTagcount = 0;
            StartFlush();                                   // 开始刷新状态
            if (rb_While.Checked)
            {
                IsStartRead = true;
                CheckEnableButton();
            }
        }
        // 写EPC
        private void tsb_Write_EPC_Click(object sender, EventArgs e)
        {
            DataGridViewRow dgvr = GetNowSelectRow();
            if (dgvr != null)
            {
                Int32 antNUM = 0;
                String[] args = new String[] { "", "", "" };
                args[0] = dgvr.Cells["clm_EPC"].Value.ToString();
                args[1] = dgvr.Cells["clm_TID"].Value.ToString();
                args[2] = dgvr.Cells["clm_UserData"].Value.ToString();
                antNUM = GetAntNum();
                if (dgvr.Cells["clm_TagType"].Value.Equals("6C"))           // 写6C标签
                {
                    MySingleForm.TestForm.FunctionForm.FunctionWriteEpc formWriteEPC = new MySingleForm.TestForm.FunctionForm.FunctionWriteEpc(ConnID, args, antNUM, this);
                    formWriteEPC.ShowDialog(this);
                    this.Focus();
                }
                else if (dgvr.Cells["clm_TagType"].Value.Equals("GB"))
                {
                    MySingleForm.TestForm.FunctionForm.FunctionWriteEpc_GB formWriteEPC = new MySingleForm.TestForm.FunctionForm.FunctionWriteEpc_GB(ConnID, args, antNUM, this);
                    formWriteEPC.ShowDialog(this);
                    this.Focus();
                }
                else 
                {
                    ShowMessage("6B tags only support custom write！");
                }
            }
            else 
            {
                ShowMessage("Please select a data column！");
            }
        }
        // 写用户数据
        private void tsb_Write_UserData_Click(object sender, EventArgs e)
        {
            DataGridViewRow dgvr = GetNowSelectRow();
            if (dgvr != null)
            {
                Int32 antNUM = 0;
                String[] args = new String[] { "", "", "" };
                args[0] = dgvr.Cells["clm_EPC"].Value.ToString();
                args[1] = dgvr.Cells["clm_TID"].Value.ToString();
                args[2] = dgvr.Cells["clm_UserData"].Value.ToString();
                antNUM = GetAntNum();
                if (dgvr.Cells["clm_TagType"].Value.Equals("6C"))           // 写6C标签
                {
                    MySingleForm.TestForm.FunctionForm.FunctionWriteUserData formWriteUserData = new MySingleForm.TestForm.FunctionForm.FunctionWriteUserData(ConnID, args, antNUM, this);
                    formWriteUserData.ShowDialog(this);
                    this.Focus();
                }
                else if (dgvr.Cells["clm_TagType"].Value.Equals("GB"))
                {
                    MySingleForm.TestForm.FunctionForm.FunctionWriteUserData_GB formWriteUserData = new MySingleForm.TestForm.FunctionForm.FunctionWriteUserData_GB(ConnID, args, antNUM, this);
                    formWriteUserData.ShowDialog(this);
                    this.Focus();
                }
                else
                {
                    ShowMessage("6B tags only support custom write！");
                }
            }
            else
            {
                ShowMessage("Please select a data column！");
            }
        }
        // 自定义写
        private void tsb_WriteGlobal_Click(object sender, EventArgs e)
        {
            if (CheckNowConnect())
            {
                String[] args = new String[] { "", "", "" };
                DataGridViewRow dgvr = GetNowSelectRow();
                if (dgvr != null)                        // 获取标签数据
                {
                    args[0] = dgvr.Cells["clm_EPC"].Value.ToString();
                    args[1] = dgvr.Cells["clm_TID"].Value.ToString();
                    args[2] = dgvr.Cells["clm_UserData"].Value.ToString();
                }
                Int32 antNUM = 0;
                foreach (var item in gb_ReadControl.Controls)               // 获取天线编号
                {
                    CheckBox control = item as CheckBox;
                    if (control != null && control.Checked)
                    {
                        antNUM += Int32.Parse(control.Tag.ToString());
                    }
                }
                if (rb_6c.Checked)
                {
                    MySingleForm.TestForm.Tag_Option formTagOption = new MySingleForm.TestForm.Tag_Option(ConnID, args, antNUM, this);
                    formTagOption.ShowDialog(this);
                    this.Focus();
                }
                else if (rb_6b.Checked)
                {
                    MySingleForm.TestForm.Tag_Option6B formTagOption = new MySingleForm.TestForm.Tag_Option6B(ConnID, args, antNUM, this);
                    formTagOption.ShowDialog(this);
                    this.Focus();
                }
                else if (rb_gb.Checked) 
                {
                    MySingleForm.TestForm.Tag_OptionGB formTagOption = new MySingleForm.TestForm.Tag_OptionGB(ConnID, args, antNUM, this);
                    formTagOption.ShowDialog(this);
                    this.Focus();
                }
            }
        }
        // 选择列
        private void tsddb_SelectColumn_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            
            ToolStripMenuItem tsmi = e.ClickedItem as ToolStripMenuItem;
            if (tsmi != null)
            {
                if (!tsmi.Checked)
                {
                    dgv_Tags.Columns["clm_" + e.ClickedItem.Text].Visible = true;
                }
                else 
                {
                    dgv_Tags.Columns["clm_" + e.ClickedItem.Text].Visible = false;
                }
            }
        }
        // 重启读写器
        private void tsb_ResetReader_Click(object sender, EventArgs e)
        {
            if (CheckNowConnect())
            {
                ClouReaderAPI.CLReader.PARAM_SET.ReSetReader(ConnID);
            }
        }
        // 停止读写器
        private void tsb_Stop_Click(object sender, EventArgs e)
        {
            IsStartRead = false;
            IsFlush = false;
            ClouReaderAPI.CLReader.RFID_OPTION.StopReader(ConnID);
            CheckEnableButton();
        }
        // 清空列表
        private void tsb_ClearList_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckNowConnect())
                {
                    lock (dic_Rows)
                    {
                        dgv_Tags.Rows.Clear();
                        dic_Rows.Clear();
                    }
                    TJ_Run_Start = DateTime.Now;
                    ClouReaderAPI.CLReader.DIC_CONNECT[ConnID].ClearTagData();
                }
                led_Speed.Text = "0";
                led_Tag_Count.Text = "0";
                led_Tag_ReadCount.Text = "0";
                led_Time.Text = "0";
            }
            catch { }
        }
        // 关闭当前连接
        private void tsb_CloseNowConnect_Click(object sender, EventArgs e)
        {
            if (IsMultiConnect)                             // 多连接模式关闭
            {

            }
            else                                            // 单连接关闭
            {
                CloseNowConnect();
            }
        }

        #endregion

        #region GPI控制方法
        /// <summary>
        /// 初始化GPI操作
        /// </summary>
        public void InitGPI() 
        {
            TJ_List_GPI_Button.Add(btn_GPI_0);
            TJ_List_GPI_Button.Add(btn_GPI_1);
            TJ_List_GPI_Button.Add(btn_GPI_2);
            TJ_List_GPI_Button.Add(btn_GPI_3);
        }
        /// <summary>
        /// 改变GPI状态
        /// </summary>
        /// <param name="rb"></param>
        /// <param name="cl"></param>
        public void UpdateGPIState(RoundButton rb, Color cl) 
        {
            if (rb.InvokeRequired) 
            {
                rb.BeginInvoke(new UpdateGPI(UpdateGPIState), rb, cl);
                return;
            }
            rb.Invalidate();
            rb.BackColor = cl;
        }
        /// <summary>
        /// GPI触发开始
        /// </summary>
        /// <param name="gpiIndex">GPI口下标</param>
        /// <param name="gpiState">GPI状态，0低1高</param>
        public void GPI_Start(Int32 gpiIndex, Int32 gpiState)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(delegate(object o) {
                if (TJ_List_GPI_Button[gpiIndex].Tag.Equals("0")) return;
                lock (TJ_List_GPI_Button[gpiIndex])
                {
                    TJ_List_GPI_Button[gpiIndex].Tag = "0";
                }
                while (TJ_List_GPI_Button[gpiIndex].Tag.Equals("0"))
                {
                    if (gpiState == 0)
                    {
                        TJ_List_GPI_Button[gpiIndex].BackColor = Color.Red;
                    }
                    else 
                    {
                        TJ_List_GPI_Button[gpiIndex].BackColor = Color.DimGray;
                    }
                    lock (TJ_List_GPI_Button[gpiIndex])
                    {
                        if (Monitor.Wait(TJ_List_GPI_Button[gpiIndex],500))              // 如果被唤醒就终止闪烁
                        {
                            break;
                        }
                    }
                    if (TJ_List_GPI_Button[gpiIndex].Tag.Equals("0"))
                    {
                        TJ_List_GPI_Button[gpiIndex].BackColor = Color.White;
                    }
                    else
                    {
                        break;
                    }
                    lock (TJ_List_GPI_Button[gpiIndex])
                    {
                        if (Monitor.Wait(TJ_List_GPI_Button[gpiIndex], 500))              // 如果被唤醒就终止闪烁
                        {
                            break;
                        }
                    }
                }
            }), new object());
        }
        /// <summary>
        /// GPI触发结束
        /// </summary>
        /// <param name="gpiIndex"></param>
        /// <param name="gpiState"></param>
        public void GPI_End(Int32 gpiIndex, Int32 gpiState)
        {
            lock (TJ_List_GPI_Button[gpiIndex])
            {
                Monitor.PulseAll(TJ_List_GPI_Button[gpiIndex]);
            }
            lock (TJ_List_GPI_Button[gpiIndex])
            {
                TJ_List_GPI_Button[gpiIndex].Tag = "1";
            }
            if (gpiState == 0)
            {
                TJ_List_GPI_Button[gpiIndex].BackColor = Color.Red;
            }
            else
            {
                TJ_List_GPI_Button[gpiIndex].BackColor = Color.DimGray;
            }
        }

        #endregion

        #region 主页面事件

        private void tsmi_Send_Command_Click(object sender, EventArgs e)
        {
            MySingleForm.TestForm.Dialog.SendCommand commandForm = new MySingleForm.TestForm.Dialog.SendCommand(this);
            commandForm.ShowDialog(this);
            this.Focus();
        }

        private void btn_ReadTagParam_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_TagOption_Click(object sender, EventArgs e)
        {
            if (CheckNowConnect())
            {
                String[] args = new String[] { "", "", ""};
                if (dgv_Tags.SelectedRows.Count > 0)                        // 获取标签数据
                {
                    DataGridViewRow dgvr = dgv_Tags.SelectedRows[0];
                    args[0] = dgvr.Cells["clm_EPC"].Value.ToString();
                    args[1] = dgvr.Cells["clm_TID"].Value.ToString();
                    args[2] = dgvr.Cells["clm_UserData"].Value.ToString();
                }
                Int32 antNUM = 0;
                foreach (var item in gb_ReadControl.Controls)               // 获取天线编号
                {
                    CheckBox control = item as CheckBox;
                    if (control != null && control.Checked)
                    {
                        antNUM += Int32.Parse(control.Tag.ToString());
                    }
                }
                if (rb_6c.Checked)
                {
                    MySingleForm.TestForm.Tag_Option formTagOption = new MySingleForm.TestForm.Tag_Option(ConnID, args, antNUM, this);
                    formTagOption.ShowDialog(this);
                    this.Focus();
                }
                else if (rb_6b.Checked) 
                {
                    MySingleForm.TestForm.Tag_Option6B formTagOption = new MySingleForm.TestForm.Tag_Option6B(ConnID, args, antNUM, this);
                    formTagOption.ShowDialog(this);
                    this.Focus();
                }
            }
        }

        #endregion

        #region 配置文件操作

        public void SaveConfig()
        {
            Helper.MyXmlHelper.UpdateInnerText(XMLFIENAME, "Root/" + this.Name, "ReadVarParam_6C", readVarParam_6C);
            Helper.MyXmlHelper.UpdateInnerText(XMLFIENAME, "Root/" + this.Name, "ReadVarParam_6B", readVarParam_6B);
        }

        public void ReadConfig()
        {
            readVarParam_6C = Helper.MyXmlHelper.ReadInnerText(XMLFIENAME, "Root/" + this.Name, "ReadVarParam_6C");
            readVarParam_6B = Helper.MyXmlHelper.ReadInnerText(XMLFIENAME, "Root/" + this.Name, "ReadVarParam_6B");
        }

        #endregion

        #region 多连接模式处理
        /// <summary>
        /// 初始化显示多连接模式
        /// </summary>
        public void InitMultiConnect() 
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new MethodInvoker(InitMultiConnect));
                return;
            }
            if (IsMultiConnect)                                 // 多连接模式初始化
            {
                tssl_TotalCountName.Visible = true;
                tssl_TotalConnect.Visible = true;
                tsddb_ConnectList.DropDownItems.Clear();
                foreach (String item in ClouReaderAPI.CLReader.DIC_CONNECT.Keys)
                {
                    ToolStripMenuItem tsmi = new ToolStripMenuItem(item);
                    tsmi.CheckOnClick = true;
                    if (item.Equals(this.ConnID))
                    {
                        tsmi.Checked = true;
                    }
                    tsddb_ConnectList.DropDownItems.Add(tsmi);
                }
                tssl_TotalConnect.Text = ClouReaderAPI.CLReader.DIC_CONNECT.Count.ToString();
            }
        }
        // 切换连接事件
        private void tsddb_ConnectList_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripMenuItem tsmi = e.ClickedItem as ToolStripMenuItem;
            if (tsmi != null && !tsmi.Checked) 
            {
                foreach (var item in tsddb_ConnectList.DropDownItems)
                {
                    ToolStripMenuItem tsmiItem = item as ToolStripMenuItem;
                    if (tsmiItem != null) 
                    {
                        tsmiItem.Checked = false;
                    }
                }
                tsmi.Checked = true;
                ChangeConnect(tsmi.Text.Trim());        // 切换连接
            }
        }

        /// <summary>
        /// 切换当前连接
        /// </summary>
        public void ChangeConnect(String newConnID) 
        {
            ClouReaderAPI.CLReader.RFID_OPTION.StopReader(ConnID);
            ClouReaderAPI.CLReader.DIC_CONNECT[ConnID].log = null;
            ConnID = newConnID;
            tssl_NowConnID.Text = ConnID;
            this.IsStartRead = false;
            ClouReaderAPI.CLReader.DIC_CONNECT[newConnID].log = this;
            Init();
        }
        
        #endregion

        #region 读标签声音控制蜂鸣器

        object lockBeep = new object();
        Int32 beepType = -1;             // -1  不响， 0 为蜂鸣器响声，1 为音箱响声
        Boolean isStartOrStopBeep = true;
        /// <summary>
        /// 读标签声音回调
        /// </summary>
        public void ReadTagBeep()
        {
            lock (lockBeep) 
            {
                Monitor.Pulse(lockBeep);
            }
        }
        /// <summary>
        /// 开始等待发声
        /// </summary>
        public void StartWaitBeep() 
        {
            for (int i = 0; i < 2; i++)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(
                delegate(object o)
                {
                    while (isStartOrStopBeep)                               //  
                    {
                        lock (lockBeep)
                        {
                            Monitor.Wait(lockBeep);
                        }
                        lock (ReadGPOObject) 
                        {
                            Monitor.Pulse(ReadGPOObject);
                        }
                        if (beepType == 0)
                        {
                            Beep(500,2000);
                        }
                        else if (beepType == 1)
                        {
                            Console.Beep(500, 2000);
                        }
                    }
                }), new object());
            }
            StartReadGPO();
        }
        /// <summary>
        /// 开始拉高GPO口
        /// </summary>
        public void StartReadGPO() 
        {
            System.Diagnostics.Debug.WriteLine("GPO Thread running...");
            ThreadPool.QueueUserWorkItem(new WaitCallback(
                delegate(object o)
                {
                    while (isStartOrStopBeep)                           //  
                    {
                        Boolean isGPO = false;
                        Boolean isGPO_Stop = false;
                        lock (ReadGPOObject)
                        {
                            if (!Monitor.Wait(ReadGPOObject, 2000) && !isGPO_Stop) // 2S没读到标签将发送拉低指令 
                            {
                                if (!String.IsNullOrEmpty(ReadGPOParam_Stop))
                                {
                                    ClouReaderAPI.CLReader.PARAM_SET.SetReaderGPOState(ConnID, ReadGPOParam_Stop);  // 拉低
                                    WriteDebugMsg("GPO low...");
                                }
                                isGPO_Stop = true;
                                isGPO = false;
                                continue;
                            }
                        }
                        if (!isGPO && !String.IsNullOrEmpty(ReadGPOParam)) 
                        {
                            String rt = ClouReaderAPI.CLReader.PARAM_SET.SetReaderGPOState(ConnID, ReadGPOParam);// 拉高
                            WriteDebugMsg("GPO high...");
                            isGPO = true;
                            isGPO_Stop = false;
                        }
                    }
                }), new object());
        }

        #endregion

        #region 搜索设备

        private void tsmi_SearchDevice_Click(object sender, EventArgs e)
        {
            if (sDevice == null)
            {
                sDevice = new MySingleForm.SearchDevice(this);
                sDevice.Show();
            }
            else 
            {
                if (sDevice.IsDisposed) 
                {
                    sDevice = new MySingleForm.SearchDevice(this);
                    sDevice.Show();
                }
                sDevice.Focus();
            }
            
        }

        #endregion

        #region 语言

        private void tsmi_Language_EN_Click(object sender, EventArgs e)
        {
            try
            {
                Helper.ConfigHelper.SetValue("Language", "en");
                Application.Restart();
            }
            catch { }
        }


        private void tsmi_Language_CN_Click(object sender, EventArgs e)
        {
            try
            {
                Helper.ConfigHelper.SetValue("Language", "cn");
                Application.Restart();
            }
            catch { }
        }

        #endregion

        private void dgv_Tags_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }

    public class DataGridViewPlus : DataGridView
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            try { base.OnPaint(e); }
            catch { Invalidate(); }
        }
    }

    [Flags]
    public enum SoundFlags
    {
        /// <summary>play synchronously (default)</summary>
        SND_SYNC = 0x0000,
        /// <summary>play asynchronously</summary>
        SND_ASYNC = 0x0001,
        /// <summary>silence (!default) if sound not found</summary>
        SND_NODEFAULT = 0x0002,
        /// <summary>pszSound points to a memory file</summary>
        SND_MEMORY = 0x0004,
        /// <summary>loop the sound until next sndPlaySound</summary>
        SND_LOOP = 0x0008,
        /// <summary>don’t stop any currently playing sound</summary>
        SND_NOSTOP = 0x0010,
        /// <summary>Stop Playing Wave</summary>
        SND_PURGE = 0x40,
        /// <summary>don’t wait if the driver is busy</summary>
        SND_NOWAIT = 0x00002000,
        /// <summary>name is a registry alias</summary>
        SND_ALIAS = 0x00010000,
        /// <summary>alias is a predefined id</summary>
        SND_ALIAS_ID = 0x00110000,
        /// <summary>name is file name</summary>
        SND_FILENAME = 0x00020000,
        /// <summary>name is resource name or atom</summary>
        SND_RESOURCE = 0x00040004
    }
}