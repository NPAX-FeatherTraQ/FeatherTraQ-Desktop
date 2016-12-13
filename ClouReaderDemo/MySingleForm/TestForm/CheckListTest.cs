using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ClouReaderAPI.ClouInterface;
using ClouReaderAPI.Models;
using System.Threading;
using ClouReaderDemo.MyFormTemplet;
using ClouReaderDemo.MySingleForm.TestForm.Dialog;
using ClouReaderDemo.Forms;

namespace ClouReaderDemo.MySingleForm.TestForm
{
    public partial class CheckListTest : BaseOption, IAsynchronousMessage
    {

        List<String> list_CheckList = new List<String>() { };           // 待检列表


        SingleMainForm contextForm = null;
        Int32 AntNum = 0;                                               // 所选的天线编号
        String ReadParam = "";

        private Int32 _NowTotalCheck = 0;                               // 当前所读到的待检标签个数
        String GPO_Red = "1,";                                          // 红灯 IO口
        String GPO_Yellow = "2,";                                       // 黄灯 IO口
        String GPO_Green = "3,";                                        // 绿灯 IO口
        String GPO_All_Stop = "1,0 & 2,0 & 3,0 & 4,0";                  // 拉低所有GPO口
        public object _LockBeepObject_Yellow = new object();            // 报警锁对象
        public object _LockBeepObject_Green = new object();             // 报警锁对象
        public object _LockBeepObject_Red = new object();               // 报警锁对象
        public String TempAddListValue = "";                            // 添加到黑白名单的EPC


        public Boolean isBeep = true;                                   // 是否报警
        private Int32 nowDebugMessageCount = 0;

        Dictionary<String, DataGridViewRow> dic_Rows = new Dictionary<string, DataGridViewRow>(); // 在DataGridView中显示标签数据

        Boolean IsStartOrStop = true;

        public CheckListTest()
        {
            InitializeComponent();
        }

        public CheckListTest(string readerID, String ReadParam, SingleMainForm contextForm)
            : this()
        {
            this.ConnID = readerID;
            this.contextForm = contextForm;
            this.ReadParam = ReadParam;

        }


        #region 窗体事件
        // 加载
        private void CheckList_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(ConnID))
            {
                ClouReaderAPI.CLReader.DIC_CONNECT[ConnID].log = this;
                StartYellowBeep();
                StartGreenBeep();
                StartRedBeep();
            }
        }
        // 关闭
        private void CheckList_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!String.IsNullOrEmpty(ConnID))
            {
                ClouReaderAPI.CLReader.DIC_CONNECT[ConnID].log = contextForm;
            }
        }

        // 开始测试
        private void btn_StartReadTest_Click(object sender, EventArgs e)
        {
            StartTest();
        }
        // 停止测试
        private void btn_StopTest_Click(object sender, EventArgs e)
        {
            StopTest();
        }
        // 清空
        private void btn_Clear_Click(object sender, EventArgs e)
        {
            try
            {
                dic_Rows.Clear();
                dgv_Tags.Rows.Clear();
                _NowTotalCheck = 0;
                lb_TagCount.Text = "0";
            }
            catch { }
        }

        // 报警测试 - 停止
        private void btn_GPO_Stop_Click(object sender, EventArgs e)
        {
            ClouReaderAPI.CLReader.PARAM_SET.SetReaderGPOState(ConnID, "1,0&2,0&3,0&4,0");
        }
        // 报警测试 - 关闭
        private void btn_GPO_down_Click(object sender, EventArgs e)
        {
            String GPO_Param = "";
            foreach (var item in tp_BeepTest.Controls)
            {
                QQCheckBox cb = item as QQCheckBox;
                if (cb != null && cb.Checked)
                {
                    GPO_Param += cb.Tag + ",0&";
                }
            }
            GPO_Param = GPO_Param.TrimEnd('&');
            ClouReaderAPI.CLReader.PARAM_SET.SetReaderGPOState(ConnID, GPO_Param);
        }
        // 报警测试 - 打开
        private void btn_GPO_up_Click(object sender, EventArgs e)
        {
            String GPO_Param = "";
            foreach (var item in tp_BeepTest.Controls)
            {
                QQCheckBox cb = item as QQCheckBox;
                if (cb != null && cb.Checked)
                {
                    GPO_Param += cb.Tag + ",1&";
                }
            }
            GPO_Param = GPO_Param.TrimEnd('&');
            ClouReaderAPI.CLReader.PARAM_SET.SetReaderGPOState(ConnID, GPO_Param);
        }

        // 添加待检标签
        private void btn_AddCheckList_Click(object sender, EventArgs e)
        {
            AddCheckList addDialog = new AddCheckList(0, this);
            if (addDialog.ShowDialog() == DialogResult.OK)
            {
                if (!String.IsNullOrEmpty(TempAddListValue))
                {
                    foreach (var item in list_CheckList)
                    {
                        if (item.Equals(TempAddListValue)) return;
                    }
                    list_CheckList.Add(TempAddListValue.ToUpper());
                    FlushCheckList();
                }
            }
        }
        // 移除待检标签
        private void btn_RemoveCheckList_Click(object sender, EventArgs e)
        {
            if (lb_CheckList.SelectedIndex >= 0)
            {
                String selectValue = lb_CheckList.SelectedItem.ToString();
                list_CheckList.Remove(selectValue);
                FlushCheckList();
            }
        }
        // 清除待检标签
        private void btn_ClearCheckList_Click(object sender, EventArgs e)
        {
            try
            {
                list_CheckList.Clear();
                FlushCheckList();
            }
            catch { }
        }
        // 批量添加35个标签
        private void btn__Click(object sender, EventArgs e)
        {
            for (int i = 1; i <= 35; i++)
            {
                list_CheckList.Add(i.ToString().PadLeft(4, '0'));
            }
            FlushCheckList();
        }

        // 重置报警
        private void btn_Reset_Click(object sender, EventArgs e)
        {
            try 
            {
                _NowTotalCheck = 0;
                lb_TagCount.Text = "0";
                ClouReaderAPI.CLReader.PARAM_SET.SetReaderGPOState(ConnID, GPO_All_Stop);
                
            }
            catch { }
        }

        #endregion

        #region IAsynchronousMessage 成员

        public void WriteDebugMsg(string msg)
        {
            if (tb_Msg.InvokeRequired)
            {
                tb_Msg.BeginInvoke(new WriteDebug(WriteDebugMsg), msg);
                return;
            }
            if (nowDebugMessageCount >= 10000)
            {
                nowDebugMessageCount = 0;
                tb_Msg.Clear();
            }
            tb_Msg.AppendText(msg + Environment.NewLine);
            lb_TagCount.Text = _NowTotalCheck + "";
            nowDebugMessageCount++;
        }

        public void WriteLog(string msg)
        {
            
        }

        public void PortConneting(string connID)
        {
            
        }

        public void PortClosing(string connID)
        {
            
        }

        public void OutPutTags(ClouReaderAPI.Models.Tag_Model tag_Model)
        {
            lock (dic_Rows)
            {
                if (!IsStartOrStop) return;
                if (tag_Model == null || tag_Model.Result != 0x00) return;
                bool isNew = false;
                DataGridViewRow dgvr = null;

                try
                {
                    if (!dic_Rows.ContainsKey(tag_Model.EPC + "|" + tag_Model.TID))
                    {
                        dgvr = new DataGridViewRow();
                        dgvr.CreateCells(dgv_Tags, new object[] { tag_Model.TagType, tag_Model.EPC, tag_Model.TID, tag_Model.UserData, tag_Model.TagetData, tag_Model.TotalCount, tag_Model.ANT1_COUNT, tag_Model.ANT2_COUNT, tag_Model.ANT3_COUNT, tag_Model.ANT4_COUNT, tag_Model.RSSI });
                        dic_Rows.Add(tag_Model.EPC + "|" + tag_Model.TID, dgvr);
                        isNew = true;
                        if (Check(tag_Model) && dgvr != null)           // 判断是否是待检测标签
                        {
                            dgvr.DefaultCellStyle.BackColor = Color.Green;
                            lock (_LockBeepObject_Yellow) { Monitor.Pulse(_LockBeepObject_Yellow); }
                            _NowTotalCheck++;
                        }
                    }
                    else
                    {
                        dgvr = dic_Rows[tag_Model.EPC + "|" + tag_Model.TID];
                    }
                }
                catch { }
                AddSingleTag(tag_Model, dgvr, isNew);
            }
        }

        public void OutPutTagsOver()
        {
            
        }

        public void GPIControlMsg(int gpiIndex, int gpiState, int startOrStop)
        {
            
        }

        #endregion

        #region DataGridView操作方法及事件

        // 添加单个标签
        public void AddSingleTag(Tag_Model tag_6C, DataGridViewRow dgvr, Boolean isNew)
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
                    dgvr.Cells["clm_ANT" + tag_6C.ANT_NUM].Value = (Int64)dgvr.Cells["clm_ANT" + tag_6C.ANT_NUM].Value + 1;
                    dgvr.Cells["clm_RSSI"].Value = tag_6C.RSSI;
                }
                else
                {
                    dgv_Tags.Rows.Add(dgvr);
                }
            }
            catch { }
        }

        #endregion

        #region 通用辅助方法

        public Boolean Check(Tag_Model tagModel) 
        {
            Boolean rt = false;
            foreach (var item in list_CheckList)
            {
                if (tagModel.EPC.IndexOf(item) >= 0) 
                {
                    rt = true;
                }
            }
            return rt;
        }

        // 黄灯控制的IO
        public void Yellow_IO(String upOrDown)
        {
            if (!String.IsNullOrEmpty(GPO_Yellow))
            {
                ClouReaderAPI.CLReader.PARAM_SET.SetReaderGPOState(ConnID, GPO_Yellow + upOrDown);
            }
        }

        // 绿灯控制的IO 
        public void Green_IO(String upOrDown)
        {
            if (!String.IsNullOrEmpty(GPO_Green))
            {
                ClouReaderAPI.CLReader.PARAM_SET.SetReaderGPOState(ConnID, GPO_Green + upOrDown);
            }
        }

        // 红灯控制的IO 
        public void Read_IO(String upOrDown)
        {
            if (!String.IsNullOrEmpty(GPO_Red))
            {
                ClouReaderAPI.CLReader.PARAM_SET.SetReaderGPOState(ConnID, GPO_Red + upOrDown);
            }
        }

        // 刷新列表
        public void FlushCheckList()
        {
            lb_CheckList.Items.Clear();
            foreach (var item in list_CheckList)
            {
                lb_CheckList.Items.Add(item);
            }
        }

        #endregion

        #region 线程方法

        // 线程-黄色报警
        public void StartYellowBeep()
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(delegate(object o)
            {
                while (isBeep)
                {
                    lock (_LockBeepObject_Yellow)
                    {
                        Monitor.Wait(_LockBeepObject_Yellow);
                    }
                    Yellow_IO("1");     // 控制IO
                }
            }));
        }
        // 线程-绿色报警
        public void StartGreenBeep()
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(delegate(object o)
            {
                while (isBeep)
                {
                    lock (_LockBeepObject_Green)
                    {
                        Monitor.Wait(_LockBeepObject_Green);
                    }
                    Green_IO("1");     // 控制IO
                }
            }));
        }
        // 线程-红色报警
        public void StartRedBeep()
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(delegate(object o)
            {
                while (isBeep)
                {
                    lock (_LockBeepObject_Red)
                    {
                        Monitor.Wait(_LockBeepObject_Red);
                    }
                    Read_IO("1");     // 控制IO
                }
            }));
        }

        #endregion

        // 开始测试
        public void StartTest()
        {
            btn_Clear_Click(null, null);
            btn_Reset_Click(null, null);
            _NowTotalCheck = 0;
            if (ClouReaderAPI.CLReader.RFID_OPTION.GetEPC(ConnID, ReadParam).StartsWith("0"))
            {
                lock (_LockBeepObject_Yellow) { Monitor.Pulse(_LockBeepObject_Yellow); }
                btn_StopTest.Enabled = true;
                btn_StartReadTest.Enabled = false;
            }
        }

        // 停止测试
        public void StopTest()
        {
            ClouReaderAPI.CLReader.RFID_OPTION.StopReader(ConnID);
            if (_NowTotalCheck != 0 && _NowTotalCheck >= list_CheckList.Count)         // 亮绿灯
            {
                lock (_LockBeepObject_Green) { Monitor.Pulse(_LockBeepObject_Green); }
            }
            else                                                // 亮红灯
            {
                lock (_LockBeepObject_Red) { Monitor.Pulse(_LockBeepObject_Red); }
            }
            ClouReaderAPI.CLReader.PARAM_SET.SetReaderGPOState(ConnID, GPO_Yellow + "0");
            btn_StopTest.Enabled = false;
            btn_StartReadTest.Enabled = true;
        }

        

    }
}
