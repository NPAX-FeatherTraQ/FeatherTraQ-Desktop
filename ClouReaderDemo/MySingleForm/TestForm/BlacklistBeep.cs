using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ClouReaderAPI.Models;
using ClouReaderAPI.ClouInterface;
using ClouReaderDemo.MyFormTemplet;
using ClouReaderDemo.MySingleForm.TestForm.Dialog;
using System.Threading;

namespace ClouReaderDemo.MySingleForm.TestForm
{
    public partial class BlacklistBeep : BaseOption, IAsynchronousMessage
    {
        List<String> list_BlackList = new List<String>() { };        // 黑名单列表

        List<String> list_WiteList = new List<String>() { };        // 白名单列表

        SingleMainForm contextForm = null;
        Int32 AntNum = 0;                          // 所选的天线编号
        String ReadParam = "";
        public String TempAddListValue = "";       // 添加到黑白名单的EPC
        public Boolean isBeep = true;              // 是否报警
        public object _LockBeepObject_B = new object();   // 报警锁对象
        public object _LockBeepObject_W = new object();   // 报警锁对象

        String GPO_B_Param = "";                   // 读到黑名单GPO控制
        String GPO_W_Param = "";                   // 读到白名单GPO控制

        private Int32 nowDebugMessageCount = 0;

        Dictionary<String, DataGridViewRow> dic_Rows = new Dictionary<string, DataGridViewRow>(); // 在DataGridView中显示标签数据

        Boolean IsStartOrStop = true;


        public BlacklistBeep()
        {
            InitializeComponent();
        }

        public BlacklistBeep(string readerID, String ReadParam, SingleMainForm contextForm)
            : this()
        {
            this.ConnID = readerID;
            this.contextForm = contextForm;
            this.ReadParam = ReadParam;
            StartBlackBeep();
            StartWiteBeep();
        }


        #region 窗体事件

        // 加载
        private void BlacklistBeep_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(ConnID))
            {
                ClouReaderAPI.CLReader.DIC_CONNECT[ConnID].log = this;
            }
        }

        // 窗体关闭
        private void BlacklistBeep_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!String.IsNullOrEmpty(ConnID))
            {
                StopTest();
                ClouReaderAPI.CLReader.DIC_CONNECT[ConnID].log = contextForm;
            }
        }

        // 开始测试 
        private void btn_StartReadTest_Click(object sender, EventArgs e)
        {
            if (ClouReaderAPI.CLReader.RFID_OPTION.GetEPC(ConnID, ReadParam).StartsWith("0")) 
            {
                GetGPOParam();                  // 获得GPO输出参数
                btn_StopTest.Enabled = true;
                btn_StartReadTest.Enabled = false;
            }
        }

        // 停止测试
        private void btn_StopTest_Click(object sender, EventArgs e)
        {
            ClouReaderAPI.CLReader.RFID_OPTION.StopReader(ConnID);
            ClouReaderAPI.CLReader.PARAM_SET.SetReaderGPOState(ConnID, "1,0&2,0&3,0&4,0");
            btn_StopTest.Enabled = false;
            btn_StartReadTest.Enabled = true;
        }

        // 
        private void btn_Clear_Click(object sender, EventArgs e)
        {
            try
            {
                dic_Rows.Clear();
                dgv_Tags.Rows.Clear();
            }
            catch{}
        }


        // 添加黑名单
        private void btn_AddBlackList_Click(object sender, EventArgs e)
        {
            AddBlack_WriteList addDialog = new AddBlack_WriteList(0, this);
            if (addDialog.ShowDialog() == DialogResult.OK)
            {
                if (!String.IsNullOrEmpty(TempAddListValue)) 
                {
                    foreach (var item in list_BlackList)
                    {
                        if (item.Equals(TempAddListValue)) return;
                    }
                    list_BlackList.Add(TempAddListValue.ToUpper());
                    FlushBlackList();
                }
            }
        }
        // 移除黑名单
        private void btn_RemoveBlackList_Click(object sender, EventArgs e)
        {
            if (lb_BlackList.SelectedIndex >= 0) 
            {
                String selectValue = lb_BlackList.SelectedItem.ToString();
                list_BlackList.Remove(selectValue);
                FlushBlackList();
            }
        }
        // 清空黑名单
        private void btn_ClearBlackList_Click(object sender, EventArgs e)
        {
            try
            {
                list_BlackList.Clear();
                FlushBlackList();
            }
            catch { }
        }
        
        // 刷新黑名单列表
        private void FlushBlackList() 
        {
            lb_BlackList.Items.Clear();
            foreach (var item in list_BlackList)
            {
                lb_BlackList.Items.Add(item);
            }
        }

        // 添加白名单
        private void btn_AddWiteList_Click(object sender, EventArgs e)
        {
            AddBlack_WriteList addDialog = new AddBlack_WriteList(1, this);
            if (addDialog.ShowDialog() == DialogResult.OK)
            {
                if (!String.IsNullOrEmpty(TempAddListValue))
                {
                    foreach (var item in list_WiteList)
                    {
                        if (item.Equals(TempAddListValue)) return;
                    }
                    list_WiteList.Add(TempAddListValue.ToUpper());
                    FlushWiteList();
                }
            }
        }
        // 移除白名单
        private void btn_RemoveWiteList_Click(object sender, EventArgs e)
        {
            if ( lb_Witelist.SelectedIndex >= 0)
            {
                String selectValue = lb_BlackList.SelectedItem.ToString();
                list_WiteList.Remove(selectValue);
                FlushWiteList();
            }
        }
        // 清空白名单
        private void btn_ClearWiteList_Click(object sender, EventArgs e)
        {
            try
            {
                list_WiteList.Clear();
                FlushWiteList();
            }
            catch (Exception){}
        }
        // 刷新白名单列表
        private void FlushWiteList() 
        {
            lb_Witelist.Items.Clear();
            foreach (var item in list_WiteList)
            {
                lb_Witelist.Items.Add(item);
            }
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

        public void OutPutTags(Tag_Model tag_Model)
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
                    }
                    else
                    {
                        dgvr = dic_Rows[tag_Model.EPC + "|" + tag_Model.TID];
                    }

                    #region 黑白名单控制
                    
                    if (CheckWriteList(tag_Model))          // 判断白名单
                    {
                        dgvr.DefaultCellStyle.BackColor = Color.Green;
                        lock (_LockBeepObject_W) { Monitor.Pulse(_LockBeepObject_W); }
                    }
                    else if(CheckBlackList(tag_Model))      // 判断黑名单
                    {
                        dgvr.DefaultCellStyle.BackColor = Color.Red;
                        lock (_LockBeepObject_B) { Monitor.Pulse(_LockBeepObject_B); }
                    }

                    #endregion
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
        // 检查黑名单
        public Boolean CheckBlackList(Tag_Model tagModel) 
        {
            Boolean rt = false;
            foreach (var item in list_BlackList)
            {
                if (tagModel.EPC.IndexOf(item) >= 0) 
                {
                    rt = true;
                }
            }
            return rt;
        }
        // 检查白名单
        public Boolean CheckWriteList(Tag_Model tagModel)
        {
            Boolean rt = false;
            foreach (var item in list_WiteList)
            {
                if (tagModel.EPC.IndexOf(item) >= 0)
                {
                    rt = true;
                }
            }
            return rt;
        }

        // 读到黑名单控制的IO
        public void Black_IO() 
        {
            if (!String.IsNullOrEmpty(GPO_B_Param))
            {
                ClouReaderAPI.CLReader.PARAM_SET.SetReaderGPOState(ConnID, GPO_B_Param);
            }
        }

        // 读到白名单控制的IO 
        public void Write_IO() 
        {
            if (!String.IsNullOrEmpty(GPO_B_Param))
            {
                ClouReaderAPI.CLReader.PARAM_SET.SetReaderGPOState(ConnID, GPO_W_Param);
            }
        }
        // 获得GPO参数
        public void GetGPOParam() 
        {
            GPO_B_Param = "";
            GPO_W_Param = "";
            foreach (var item in tp_BlackList.Controls)
            {
                QQCheckBox cb = item as QQCheckBox;
                if (cb != null && cb.Checked)
                {
                    GPO_B_Param += cb.Tag + ",1&";
                }
            }
            GPO_B_Param = GPO_B_Param.TrimEnd('&');
            foreach (var item in tp_WhiteList.Controls)
            {
                QQCheckBox cb = item as QQCheckBox;
                if (cb != null && cb.Checked)
                {
                    GPO_W_Param += cb.Tag + ",1&";
                }
            }
            GPO_W_Param = GPO_W_Param.TrimEnd('&');

        }

        #endregion

        #region 线程方法
        
        // 线程-黑名单报警
        public void StartBlackBeep() 
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(delegate(object o) 
            {
                while (isBeep) 
                {
                    lock (_LockBeepObject_B) 
                    {
                        Monitor.Wait(_LockBeepObject_B);
                    }
                    Black_IO();     // 控制IO
                }
            }));
        }
        // 线程-白名单报警
        public void StartWiteBeep() 
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(delegate(object o)
            {
                while (isBeep)
                {
                    lock (_LockBeepObject_W)
                    {
                        Monitor.Wait(_LockBeepObject_W);
                    }
                    Write_IO();     // 控制IO
                }
            }));
        }

        #endregion

        // 开始测试
        private void StartTest() 
        {

        }
        
        // 停止测试
        private void StopTest()
        {

        }

    }
}
