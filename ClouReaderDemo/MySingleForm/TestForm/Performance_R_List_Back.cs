using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ClouReaderAPI.ClouInterface;
using ClouReaderAPI.Custom;
using ClouReaderAPI.Models;
using System.Threading;
using ClouReaderDemo.MyFormTemplet;

namespace ClouReaderDemo.MySingleForm.TestForm
{
    public partial class Performance_R_List_Back : BaseOption, IAsynchronousMessage
    {
        ListRead lr = new ListRead();                     // 轮循环读API
        public Int32 _AddConnectType = 0;                 // 新添加的设备类型
        public String _AddConnectID = "";                 // 新添加设备的连接ID
        public String _AddANTParam = "";                  // 天线勾选参数

        public Int32 _ReadType = 0;                      // 0 发单次读指令 1 发循环读指令

        private Boolean IsWriteDebug = true;              // 是否打印Debug消息
        private Int32 nowDebugMessageCount = 0;
        Dictionary<String, DataGridViewRow> dic_Rows = new Dictionary<string, DataGridViewRow>(); // 在DataGridView中显示标签数据

        List<String> list_Tags = new List<String>();         // 标签总列表
        /// <summary>
        /// 是否开始测试
        /// </summary>
        // Boolean IsStartOrStop = false;                    //

        public Performance_R_List_Back()
        {
            InitializeComponent();
        }

        #region IAsynchronousMessage 成员

        public void WriteDebugMsg(string msg)
        {
            if (!IsWriteDebug) return;
            if (tb_Msg.InvokeRequired)
            {
                tb_Msg.BeginInvoke(new WriteDebug(WriteDebugMsg), msg);
                return;
            }
            if (nowDebugMessageCount >= 1000)
            {
                nowDebugMessageCount = 0;
                tb_Msg.Clear();
            }
            lb_TagCount.Text = list_Tags.Count + "";
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

        public void OutPutTags(ClouReaderAPI.Models.Tag_Model tag_Model)
        {
            lock (dic_Rows)
            {
                // if (!IsStartOrStop) return;
                if (tag_Model == null || tag_Model.Result != 0x00) return;
                bool isNew = false;
                DataGridViewRow dgvr = null;
                try
                {
                    if (!list_Tags.Contains(tag_Model.EPC + "|" + tag_Model.TID)) 
                    {
                        list_Tags.Add(tag_Model.EPC + "|" + tag_Model.TID);
                    }// tag_Model.ReaderName + "|" + 
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
                }
                catch { }
                AddSingleTag(tag_Model, dgvr, isNew);
            }
        }

        public void OutPutTagsOver()
        {
            try
            {
                lock (lr._LockStep)
                {
                    if (_ReadType == 0)         // 单次读时才唤醒
                    {
                        Monitor.Pulse(lr._LockStep);
                    }
                }
            }
            catch (Exception)
            {
            }
            WriteDebugMsg("-------------标签读取结束--------------");
        }

        public void GPIControlMsg(int gpiIndex, int gpiState, int startOrStop)
        {
            throw new NotImplementedException();
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

        #region 窗体事件

        private void Performance_R_List_Load(object sender, EventArgs e)
        {
            cb_ReadType.SelectedIndex = 0;
        }


        // 添加设备
        private void btn_AddDevice_Option_Click(object sender, EventArgs e)
        {
            if (this.tc_Main.TabCount > 1)
            {
                this.tc_Main.SelectedIndex = 1;
            }

        }
        // 开始测试
        private void btn_StartReadTest_Click(object sender, EventArgs e)
        {
            if (lr.readerIDList.Count > 0)
            {
                try
                {
                    lr._WaitTime = Int32.Parse(tb_WaitTime.Text);
                    dgv_Tags.Rows.Clear();
                    dic_Rows.Clear();
                    list_Tags.Clear();
                    lr.StartRead(_ReadType, GetReadParam(_ReadType));
                    btn_StartReadTest.Enabled = false;
                    btn_StopTest.Enabled = true;
                }
                catch { }
            }
            else 
            {
                MessageBox.Show("Please add Device！");
            }
        }
        // 停止测试
        private void btn_StopTest_Click(object sender, EventArgs e)
        {
            lr.StopRead();
            btn_StartReadTest.Enabled = true;
            btn_StopTest.Enabled = false;
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            try 
            {
                dgv_Tags.Rows.Clear();
                dic_Rows.Clear();
                list_Tags.Clear();
            }
            catch { }
        }

        // 添加设备
        private void btn_AddDevice_Click(object sender, EventArgs e)
        {
            //MySingleForm.TestForm.Dialog.AddConnectBy_R_List ari = new Dialog.AddConnectBy_R_List(this);
            //if (ari.ShowDialog() == DialogResult.OK) 
            //{
            //    if (lr.AddSingleReader(_AddConnectType, _AddConnectID, this))
            //    {
            //        if (!lr.dic_ReadANTParam.ContainsKey(_AddConnectID)) 
            //        {
            //            lr.dic_ReadANTParam.Add(_AddConnectID,_AddANTParam);        // 添加天线参数
            //        }
            //        lb_ReaderList.Items.Add(_AddConnectID);
            //        MessageBox.Show("添加设备成功！");
            //    }
            //    else 
            //    {
            //        MessageBox.Show("添加设备失败：请检查连接参数或是否已经重新添加！");
            //    }
            //}
        }
        // 移除设备
        private void btn_RemoveDevice_Click(object sender, EventArgs e)
        {
            if (lb_ReaderList.SelectedItems.Count > 0)
            {
                String removeReaderID = lb_ReaderList.SelectedItem.ToString();
                if (!String.IsNullOrEmpty(removeReaderID)) 
                {
                    if (lr.DeleteReader(removeReaderID))
                    {
                        lb_ReaderList.Items.Remove(removeReaderID);
                        MessageBox.Show("Removed！");
                    }
                    else 
                    {
                        MessageBox.Show("Error！");
                    }
                }
            }
            else 
            {
                MessageBox.Show("Please Seelct Device！");
            }
        }
        // 清空列表
        private void btn_ClearDevice_Click(object sender, EventArgs e)
        {
            try
            {
                lb_ReaderList.Items.Clear();
                lr.Release();
            }
            catch { }
        }
        // 窗体关闭事件
        private void Performance_R_List_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                lr.StopRead();
                lr.Release();
                lr.Release();
                lr.Release();
            }
            catch { }
        }

        // 改变读取类型
        private void cb_ReadType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                _ReadType = cb_ReadType.SelectedIndex;
            }
            catch{}
        }

        #endregion

        #region 辅助方法

        public String GetReadParam(Int32 readType)
        {
            String rt = "";
            rt += "|" + readType;
            if (cb_IsTID.Checked)
            {
                rt += "|2,0006";
            }

            return rt;
        }

        #endregion

    }
}
