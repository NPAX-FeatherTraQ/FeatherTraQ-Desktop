using ClouReaderAPI.ClouInterface;
using ClouReaderAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ClouReaderDemo.MySingleForm.TestForm
{
    public partial class Performance_R : BaseOption, IAsynchronousMessage
    {
        private SingleMainForm parentForm = null;
        private Boolean IsWriteDebug = true;              // 是否打印Debug消息
        private Int32 nowDebugMessageCount = 0;
        private Int32 Tagtype = 0;                        // 0-代表6C标签，1-6B标签, 2 代表国标求签
        private String ReadParam = "";                    // 继承自父窗体的读标签参数
        Dictionary<String, DataGridViewRow> dic_Rows = new Dictionary<string, DataGridViewRow>(); // 在DataGridView中显示标签数据

        /// <summary>
        /// 是否开始测试
        /// </summary>
        Boolean IsStartOrStop = false;                    // 
        Int32 MaxTime = 0;                                // 按时间测试，最大时间
        object MaxTimeObject = new object();              // 同步结束计时器
        Int32 MaxCount = 0;                               // 按标签数测试，最大标签数
        object MaxCountObject = new object();
        Int32 StartTime = System.Environment.TickCount;   // 开始测试的时间
        private long TotalReadTagCount = 0;               // 读取总次数

        public Performance_R()
        {
            InitializeComponent();
        }

        public Performance_R(SingleMainForm parentForm, Int32 tagType, String readParam) :this()
        {
            this.parentForm = parentForm;
            this.Tagtype = tagType;
            this.ReadParam = readParam;
            this.ConnID = parentForm.ConnID;
            ClouReaderAPI.CLReader.DIC_CONNECT[parentForm.ConnID].log = this;
        }

        #region 接口实现方法

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
            tb_Msg.AppendText(msg + Environment.NewLine);
            nowDebugMessageCount++;
            
        }

        public void WriteLog(string msg)
        {
            //throw new NotImplementedException();
        }

        public void PortConneting(string connID)
        {
            //throw new NotImplementedException();
        }

        public void PortClosing(String connID)
        {
            //throw new NotImplementedException();
        }

        public void OutPutTags(ClouReaderAPI.Models.Tag_Model tag_Model)
        {
            lock (dic_Rows)
            {
                if (!IsStartOrStop) return;
                if (MaxCount > 0 && dic_Rows.Count == MaxCount)                 // 限张数读取
                {
                    lb_TagCount.Text = dic_Rows.Count.ToString();
                    pb_Read.Value = pb_Read.Maximum;
                    lb_ProcessCount.Text = "100%";
                    btn_StartReadTest_Click(null, null);
                    return;
                }
                ImmediateFlush();
                TotalReadTagCount++;
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
                }
                catch { }
                AddSingleTag(tag_Model, dgvr, isNew);
            }
        }

        public void OutPutTagsOver()
        {
            WriteDebugMsg("-------------标签读取结束--------------");
        }

        public void GPIControlMsg(int gpiIndex, int gpiState, int startOrStop)
        {
            //throw new NotImplementedException();
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

        #region  回调/窗体事件
        /// <summary>
        /// 即时消息刷新
        /// </summary>
        private void ImmediateFlush() 
        {
            if (lb_SuccessReadTagsCount.InvokeRequired) 
            {
                lb_SuccessReadTagsCount.BeginInvoke(new MethodInvoker(delegate() {
                    ImmediateFlush();
                }));
                return;
            }
            lb_TagCount.Text = dic_Rows.Count.ToString();
            lb_SuccessReadTagsCount.Text = TotalReadTagCount.ToString();
            lb_ReadTime.Text = (System.Environment.TickCount - StartTime) + " ms";
            pb_Read.Value = GetProcess();
            lb_ProcessCount.Text = pb_Read.Value + " %";
        }
        // 窗体关闭
        private void Performance_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (parentForm != null)
            {
                StopTest();
                ClouReaderAPI.CLReader.DIC_CONNECT[parentForm.ConnID].log = parentForm;
            }
        }

        #endregion

        #region 读测试

        private void btn_StartReadTest_Click(object sender, EventArgs e)
        {
            if (btn_StartReadTest.Tag.Equals("0"))                          // 开始测试
            {
                StartTime = System.Environment.TickCount;                   // 重置计时器
                MaxCount = 0;                                               // 重置最大标签数
                if (rb_ReadByTime.Checked && Int32.TryParse(tb_ReadMaxTime.Text.Trim(), out MaxTime))
                {
                    StartTimer();                                           // 到时间准时发送停止指令
                }
                else if (rb_ReadByCount.Checked && Int32.TryParse(tb_ReadMaxCount.Text.Trim(), out MaxCount))
                {
                    
                }
                else { ShowMessage("参数错误！"); return; }
                IsStartOrStop = true;                                       // 开始测试
                ClearReaderImmediateMsg();                                  // 清除显示数据
                StartFlushState();                                          // 开始定时刷新状态线程
                WhileRead();                                                // 发送循环读取指令
                btn_StartReadTest.Tag = "1";
                btn_StartReadTest.Text = "Stop";
                tb_ReadMaxCount.Enabled = false;
                tb_ReadMaxTime.Enabled = false;
            }
            else                                                            // 中止测试
            {
                StopTest();
                btn_StartReadTest.Tag = "0";
                btn_StartReadTest.Text = "Start";
                tb_ReadMaxCount.Enabled = true;
                tb_ReadMaxTime.Enabled = true;
                lock (MaxTimeObject)
                {
                    Monitor.PulseAll(MaxTimeObject);
                }
            }
        }

        #endregion

        #region 通用方法
        /// <summary>
        /// 启用定时器，限时停止测试
        /// </summary>
        public void StartTimer() 
        {
            ThreadPool.QueueUserWorkItem(delegate(object o) {
                lock (MaxTimeObject) 
                {
                    Monitor.Wait(MaxTimeObject, MaxTime);
                }
                if (IsStartOrStop)
                {
                    btn_StartReadTest_Click(null,null);
                    lb_TagCount.Text = dic_Rows.Count.ToString();           // 同步标签总数
                    lb_ReadTime.Text = MaxTime.ToString() + " ms";
                    lb_ProcessCount.Text = "100 %";
                    pb_Read.Value = pb_Read.Maximum;
                }
            },new object());
        }
        /// <summary>
        /// 停止测试
        /// </summary>
        public void StopTest()
        {
            IsStartOrStop = false;
            ClouReaderAPI.CLReader.RFID_OPTION.StopReader(ConnID);
        }
        /// <summary>
        /// 循环读取标签
        /// </summary>
        public void WhileRead() 
        {
            if (Tagtype == 0)       // 6C
            {
                ClouReaderAPI.CLReader.RFID_OPTION.GetEPC(ConnID, ReadParam);
            }
            else if (Tagtype == 1)
            {
                ClouReaderAPI.CLReader.RFID_OPTION.Get6B(ConnID, ReadParam);
            }
            else if (Tagtype == 2)
            {
                ClouReaderAPI.CLReader.RFID_OPTION.GetGB(ConnID, ReadParam);
            }
        }
        /// <summary>
        /// 单次读取标签
        /// </summary>
        public void SingleRead() 
        {

        }
        /// <summary>
        /// 启动刷新状态
        /// </summary>
        public void StartFlushState() 
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(delegate(object o) {
                while (IsStartOrStop)
                {
                    FlushState();
                    Thread.Sleep(1000);
                }
            }), new object());
        }
        /// <summary>
        /// 刷新状态
        /// </summary>
        public void FlushState() 
        {
            if (gb_Read_Result.InvokeRequired)
            {
                gb_Read_Result.BeginInvoke(new MethodInvoker(delegate()
                {
                    FlushState();
                    return;
                }));
            }
        }
        /// <summary>
        /// 获取测试进度
        /// </summary>
        /// <returns>百分比</returns>
        public Int32 GetProcess() 
        {
            Int32 rt = 0;
            if (rb_ReadByTime.Checked) 
            {
                rt = (System.Environment.TickCount - StartTime) * 100 / MaxTime;
            }
            else if(rb_ReadByCount.Checked)
            {
                rt = dic_Rows.Count * 100 / MaxCount;
            }
            rt = rt > pb_Read.Maximum ? 100 : rt;
            return rt;
        }
        /// <summary>
        /// 清除读测试即时消息
        /// </summary>
        public void ClearReaderImmediateMsg() 
        {
            if (gb_Read_Result.InvokeRequired) 
            {
                gb_Read_Result.BeginInvoke(new MethodInvoker(delegate()
                {
                    ClearReaderImmediateMsg();
                }));
                return;
            }
            lb_TagCount.Text = "0";
            lb_ImmediateSpeed.Text = "0 /s";
            lb_AverageSpeed.Text = "0 /s";
            lb_SuccessReadTagsCount.Text = "0";
            lb_ReadTime.Text = "0 ms";
            lb_ProcessCount.Text = "0 %";

            TotalReadTagCount = 0;                          // 读取总数清零
            dgv_Tags.Rows.Clear();                          // 清除标签数据
            dic_Rows.Clear();                               // 清除标签数据
            pb_Read.Value = 0;                              // 清除进度
        }
        
        #endregion

        #region 高性能DataGrid
        

        #endregion
    }
}