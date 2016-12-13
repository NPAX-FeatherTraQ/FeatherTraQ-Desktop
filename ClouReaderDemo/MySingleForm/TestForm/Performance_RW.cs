using ClouReaderAPI.ClouInterface;
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
    public partial class Performance_RW : BaseOption, IAsynchronousMessage
    {
        /// <summary>
        /// 返回结果字典
        /// </summary>
        public static Dictionary<byte, String> DIC_RESPONSE_CODE = new Dictionary<byte, string>() 
        {
            {0x00,"0|OK"},
            {0x01,"1|标签无响应"},
            {0x02,"2|CRC错误"},
            {0x03,"3|数据区被锁定"},
            {0x04,"4|数据区溢出"},
            {0x05,"5|访问密码错误"},
            {0x06,"6|其他标签错误"},
            {0x07,"7|其他读写器错误"}
        };
        SingleMainForm contextForm = null;
        Int32 AntNum = 0;                          // 所选的天线编号
        private Int32 nowDebugMessageCount = 0;
        private Int32 nowtTestMessageCount = 0;

        ClouReaderAPI.Models.Tag_Model readModel = null;
        Object readModelLock = new Object();
        Object readTagObjectLock = new Object();       // 读对象锁
        Int32 iReadTimeOut = 2000;                     // 读超时时间
        Boolean IsStartOrStop = true;                  // 是否继续测试
        Int32 maxTestCount = 0;                        // 测试次数
        Int32 writeType = 0;                           // 1，EPC区,3，用户数据区
        Boolean IsTestRead = false;
        Boolean IsTestWrite = false;
        Int32 ReadTagCount = 0;
        Int32 ReadSuccessCount = 0;
        Int32 WriteSuccessCount = 0;
        double ts_avg = 0f;
        double ts_total = 0f;

        Boolean IsGBTest = false;                                           // GB 测试参数启用
        List<GBTestModel> listResults = new List<GBTestModel>();            // 
        Double maxRate = 0f;
        int maxX = 0;
        int maxY = 0;

        String[] EPCdata = new String[] { "", "", "" };     // EPC, TID, UserData   ,当前选择的标签数据

        public Performance_RW()
        {
            InitializeComponent();
        }

        public Performance_RW(string readerID, String[] epcData, Int32 antNum, SingleMainForm contextForm)
            : this()
        {
            this.ConnID = readerID;
            this.EPCdata = epcData;
            this.contextForm = contextForm;
            this.AntNum = antNum;
        }
        // 开始测试
        public void StartTest()
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(delegate(object o)
            {
                if (IsGBTest)               // 如果是国军标参数测试
                {
                    maxRate = 0f; maxX = 0; maxY = 0;
                    if (CheckGBParam())     // 检查参数合法性
                    {
                        GBTestModel testModel = GetGBTestParam();   // 获取测试参数
                        if (testModel != null)
                        {
                            for (int i = testModel.GardnerXMin; i <= testModel.GardnerXMax; i++)
                            {
                                for (int j = testModel.GardnerYMin; j <= testModel.GardnerYMax; j++)
                                {
                                    testModel = GetGBTestParam();
                                    WriteMsgToForm("---新一轮测试， 当前比例参数：" + i + " 积分参数：" + j + " ---");
                                    WriteMsgToForm("正在下发参数设置...");
                                    String strRT = ClouReaderAPI.CLReader.RFID_OPTION.SetGBGardner(ConnID, i + "|" + j);
                                    if (strRT.StartsWith("0"))
                                    {
                                        WriteMsgToForm("下发参数成功...");
                                    }
                                    else
                                    {
                                        WriteMsgToForm("下发参数失败...");
                                        continue;
                                    }
                                    RunGardnerTest(testModel);
                                    WriteMsgToForm("--- 当前次测试结束，正在计算结果 ---");
                                    WriteMsgToForm("当前参数是否有效：" + testModel.IsOK);
                                    if (testModel.IsOK)
                                    {
                                        listResults.Add(testModel);
                                        if (testModel.Rate > maxRate) { maxX = i; maxY = j; maxRate = testModel.Rate; }
                                        WriteMsgToForm("当前参数成功率为：" + testModel.Rate);
                                    }
                                    WriteMsgToForm("目前最优成功率为：" + maxRate.ToString("F2") + "目前最优比例参数:" + maxX + "目前最优积分参数:" + maxY);
                                    if (!IsStartOrStop) break;
                                }
                                if (!IsStartOrStop) break;
                            }

                            if (testModel.NowTestCount >= testModel.TestCount)
                            {
                                btn_StartTest_Click(null, null);
                            }
                        }
                    }
                }
                else// 普通测试
                {
                    RunTest();
                }
            }), new object());
        }

        public void RunTest()
        {
            Int32 iTestCount = 1;
            String errorMsg = "";
            ts_avg = 0f; ts_total = 0f;
            while (IsStartOrStop && iTestCount <= maxTestCount)
            {
                // Thread.Sleep(5000);
                Helper.Helper_Timers.Restart();
                if (IsTestWrite)            // 写
                {
                    tb_WriteData.Text = GetRandomToHex(Int32.Parse(tb_WriteLength.Text.Trim()));
                    Boolean rtWrite = false;
                    if (cmb_WriteType.SelectedIndex == 0)     // 写EPC
                    {
                        rtWrite = WriteEPC(out errorMsg);
                    }
                    else if (cmb_WriteType.SelectedIndex > 0) // 写用户数据
                    {
                        rtWrite = WriteUserData(out errorMsg);
                    }
                    if (rtWrite)
                    {
                        WriteMsgToForm("No." + iTestCount + "Write OK！");
                        WriteSuccessCount++;
                    }
                    else
                    {
                        WriteMsgToForm("No." + iTestCount + "Write Failure！Msg：" + errorMsg);
                    }
                }
                if (IsTestRead)             // 读
                {
                    if (ReadSingle(out errorMsg))
                    {
                        WriteMsgToForm("No." + iTestCount + "Read OK！");
                        ReadSuccessCount++;
                    }
                    else
                    {
                        WriteMsgToForm("No." + iTestCount + "Read Failure！Msg：" + errorMsg);
                    }
                }
                if (!CheckWriteRead())            // 检查读写一致性
                {
                    WriteMsgToForm("No." + iTestCount + "Test！Read and write data is inconsistent！");
                }
                iTestCount++;
                WriteMsgToForm("No." + iTestCount + "Test！Time(ms)：" + Helper.Helper_Timers.GetElapsed().TotalMilliseconds);
                ts_total = ts_total + Helper.Helper_Timers.GetElapsed().TotalMilliseconds;
                ts_avg = ts_total / iTestCount;
                FlushState();
            }
            if (iTestCount >= maxTestCount)
            {
                btn_StartTest_Click(null, null);
            }
        }

        public void RunGardnerTest(GBTestModel testModel)
        {
            Int32 iTestCount = 1;
            String errorMsg = "";
            ts_avg = 0f; ts_total = 0f;
            while (IsStartOrStop && iTestCount <= testModel.SingleWhileTestCount)
            {
                // Thread.Sleep(5000);
                Helper.Helper_Timers.Restart();
                if (IsTestWrite)                              // 写
                {
                    tb_WriteData.Text = GetRandomToHex(Int32.Parse(tb_WriteLength.Text.Trim()));
                    Boolean rtWrite = false;
                    if (cmb_WriteType.SelectedIndex == 0)     // 写EPC
                    {
                        rtWrite = WriteEPC(out errorMsg);
                    }
                    else if (cmb_WriteType.SelectedIndex > 0) // 写用户数据
                    {
                        rtWrite = WriteUserData(out errorMsg);
                    }
                    if (rtWrite)
                    {
                        WriteMsgToForm("No." + iTestCount + "写入成功！");
                        WriteSuccessCount++;
                    }
                    else
                    {
                        WriteMsgToForm("No." + iTestCount + "写入失败！Msg：" + errorMsg);
                    }
                }
                if (IsTestRead)             // 读
                {
                    if (ReadSingle(out errorMsg))
                    {
                        WriteMsgToForm("No." + iTestCount + "读成功！");
                        ReadSuccessCount++;
                        testModel.SuccessCount++;       // 成功次数累加
                        testModel.ContinuousFailureCount = 0;
                    }
                    else
                    {
                        testModel.ContinuousFailureCount++;     // 失败次数累加及判断
                        if (testModel.ContinuousFailureCount >= testModel.ContinuousFailureMax)
                        {
                            testModel.IsOK = false;
                            break;
                        }
                        testModel.FailureCount++;
                        WriteMsgToForm("No." + iTestCount + "读失败！Msg：" + errorMsg);
                    }
                }
                if (!CheckWriteRead())            // 检查读写一致性
                {
                    WriteMsgToForm("No." + iTestCount + "测试，读写数据不一致！");
                }
                iTestCount++;
                WriteMsgToForm("No." + iTestCount + "Test！Time(ms)：" + Helper.Helper_Timers.GetElapsed().TotalMilliseconds);
                ts_total = ts_total + Helper.Helper_Timers.GetElapsed().TotalMilliseconds;
                ts_avg = ts_total / iTestCount;
                FlushState();
            }
        }

        #region 接口实现

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

        public void OutPutTags(ClouReaderAPI.Models.Tag_Model tag)
        {
            lock (readModelLock)
            {
                try
                {
                    ReadTagCount++;
                    if (readModel == null)
                    {
                        if (tag.Result == 0x00)
                        {
                            readModel = tag;
                            if (cmb_WriteType.SelectedIndex == 0)
                            {
                                WriteMsgToForm("序号：" + ReadTagCount + "读到标签EPC：" + tag.EPC);
                            }
                            else if (cmb_WriteType.SelectedIndex == 1)
                            {
                                WriteMsgToForm("序号：" + ReadTagCount + " UserData:" + tag.UserData);
                            }
                        }
                        else
                        {
                            WriteMsgToForm("序号：" + ReadTagCount + "标签返回结果异常：" + DIC_RESPONSE_CODE[tag.Result]);
                        }
                    }
                }
                catch { }
            }
        }

        public void OutPutTagsOver()
        {
            lock (readTagObjectLock) 
            {
                Monitor.Pulse(readTagObjectLock);
                lock (readModelLock)
                {
                    WriteDebugMsg("----Read Over!----");
                }
            }
        }

        public void GPIControlMsg(int gpiIndex, int gpiState, int startOrStop)
        {
            
        }

        #endregion

        #region 事件
        // 窗体加载事件
        private void Performance_RW_Load(object sender, EventArgs e)
        {
            tb_SelectEPC.Text = EPCdata[0];
            tb_SelectTID.Text = EPCdata[1];
            cmb_WriteType.SelectedIndex = 1;
            if (!String.IsNullOrEmpty(ConnID))
            {
                ClouReaderAPI.CLReader.DIC_CONNECT[ConnID].log = this;
            }
        }
        // 切换数据类型
        private void cmb_WriteType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmb_WriteType.SelectedIndex == 0)
                {
                    if (String.IsNullOrEmpty(tb_SelectTID.Text.Trim())) 
                    {
                        ShowMessage("data can not be empty！");
                        cmb_WriteType.SelectedIndex = 1;
                        return;
                    }
                }
                tb_WriteData.Text = GetRandomToHex(Int32.Parse(tb_WriteLength.Text.Trim()));
            }
            catch { }
        }
        // 开始测试
        private void btn_StartTest_Click(object sender, EventArgs e)
        {
            if (btn_StartTest.Tag.Equals("0") && Int32.TryParse(tb_TestMaxCount.Text.Trim(), out maxTestCount) && (cb_Read.Checked || cb_Write.Checked)) // 开始测试
            {
                IsTestRead = cb_Read.Checked;
                IsTestWrite = cb_Write.Checked;
                ReadTagCount = 0;
                ReadSuccessCount = 0;
                WriteSuccessCount = 0;
                writeType = cmb_WriteType.SelectedIndex == 0 ? 1 : 3;
                IsStartOrStop = true;                                       // 开始测试
                StartTest();
                btn_StartTest.Tag = "1";
                btn_StartTest.Text = "Stop";
            }
            else                                                            // 中止测试
            {
                StopTest();
                btn_StartTest.Tag = "0";
                btn_StartTest.Text = "Start";
            }
        }
        // 窗体关闭
        private void Performance_RW_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!String.IsNullOrEmpty(ConnID))
            {
                StopTest();
                ClouReaderAPI.CLReader.DIC_CONNECT[ConnID].log = contextForm;
            }
        }
        #endregion

        #region 通用辅助方法

        /// <summary>
        /// 获得随机数据区内容
        /// </summary>
        /// <param name="b_Len">字长度（字 = 2个字节）</param>
        /// <returns>00FF</returns>
        private String GetRandomToHex(Int32 w_Len) 
        {
            StringBuilder sb = new StringBuilder();
            Random r = new Random();
            for (int i = 0; i < w_Len; i++)
            {
                sb.Append(string.Format("{0:X2}", ((Byte)r.Next(0, 255))) + string.Format("{0:X2}", ((Byte)r.Next(0, 255))));
            }
            return sb.ToString();
        }
        /// <summary>
        /// 读单次
        /// </summary>
        /// <returns>是否成功</returns>
        private Boolean ReadSingle(out String errorMsg) 
        {
            Boolean rt = false;
            errorMsg = "";
            lock (readModelLock) { readModel = null; }
            String readParam = AntNum + "|0|" + GetReadVarParam();
            String rtStr = ClouReaderAPI.CLReader.RFID_OPTION.GetEPC(ConnID, readParam);
            if (rtStr.StartsWith("0"))
            {
                lock (readTagObjectLock)
                {
                    if (Monitor.Wait(readTagObjectLock, iReadTimeOut))             // 收到读停止指令，并且读到标签
                    {
                        if (readModel != null)
                        {
                            rt = true;
                        }
                        else 
                        {
                            errorMsg = "No Data Upload！";
                        }
                    }
                    else
                    {
                        ClouReaderAPI.CLReader.RFID_OPTION.StopReader(ConnID);
                        errorMsg = "Timeout！";
                    }
                }
            }
            return rt;
        }
        /// <summary>
        /// 写单次
        /// </summary>
        /// <returns>是否成功</returns>
        private Boolean WriteSingle()
        {
            Boolean rt = false;

            return rt;
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
        /// 获得读可选参数
        /// </summary>
        /// <returns>参数</returns>
        private String GetReadVarParam() 
        {
            String rt = "";
            // 必选参数结束
            if (!String.IsNullOrEmpty(tb_SelectTID.Text))               // 匹配TID
            {
                String kx_param_1 = "";
                kx_param_1 += "02";
                kx_param_1 += "0000";
                kx_param_1 += ClouReaderAPI.MyHelper.MyString.ByteToString((Byte)(tb_SelectTID.Text.Trim().Length * 4));
                kx_param_1 += tb_SelectTID.Text.Trim();
                rt += "1," + kx_param_1 + "&";
            }
            else                                                        // 匹配EPC
            {
                String kx_param_1 = "";
                kx_param_1 += "01";
                kx_param_1 += "0020";
                kx_param_1 += ClouReaderAPI.MyHelper.MyString.ByteToString((Byte)(tb_SelectEPC.Text.Trim().Length * 4));
                kx_param_1 += tb_SelectEPC.Text.Trim();
                rt += "1," + kx_param_1 + "&";
            }
            // 读TID
            // rt += "2," + ClouReaderAPI.MyHelper.MyString.ByteToString((Byte)0) + ClouReaderAPI.MyHelper.MyString.ByteToString(Byte.Parse(tb_WriteLength.Text.Trim())) + "&";
            // 读用户数据 ,重复读写用户数据的时候才能读用户数据
            if (cmb_WriteType.SelectedIndex == 1)
            {
                rt += "3," + tb_StartPostion.Text.Trim() + ClouReaderAPI.MyHelper.MyString.ByteToString(Byte.Parse(tb_WriteLength.Text.Trim())) + "&";
            }
            if (!String.IsNullOrEmpty(tb_AccessPwd.Text.Trim()))        // 访问密码
            {
                rt += "5," + tb_AccessPwd.Text.Trim() + "&";
            }
            rt = rt.TrimEnd('&');
            // 可选参数结束
            rt = rt.TrimEnd('|');
            return rt;
        }
        /// <summary>
        /// 写EPC
        /// </summary>
        /// <returns></returns>
        private Boolean WriteEPC(out String errorMsg)
        {
            String param = "";
            errorMsg = "";
            param += AntNum.ToString() + "|";
            param += "1|";
            param += "0001|";
            Int32 iLen = Int32.Parse(tb_WriteLength.Text.Trim());
            Int16 i_PC = (Int16)(iLen << 11);
            string s_PC = Convert.ToString(i_PC, 16).PadLeft(4, '0');
            string s_EPC = (s_PC + tb_WriteData.Text.Trim()).PadRight((iLen + 1) * 4, '0');  // 加上PC的长度
            param += s_EPC + "|";
            // 必选参数结束
            if (!String.IsNullOrEmpty(tb_SelectTID.Text))               // 匹配TID
            {
                String kx_param_1 = "";
                kx_param_1 += "02";
                kx_param_1 += "0000";
                kx_param_1 += ClouReaderAPI.MyHelper.MyString.ByteToString((Byte)(tb_SelectTID.Text.Trim().Length * 4));
                kx_param_1 += tb_SelectTID.Text.Trim();
                param += "1," + kx_param_1 + "&";
            }
            else                                                        // 匹配EPC
            {
                String kx_param_1 = "";
                kx_param_1 += "01";
                kx_param_1 += "0020";
                kx_param_1 += ClouReaderAPI.MyHelper.MyString.ByteToString((Byte)(tb_SelectEPC.Text.Trim().Length * 4));
                kx_param_1 += tb_SelectEPC.Text.Trim();
                param += "1," + kx_param_1 + "&";
            }
            if (!String.IsNullOrEmpty(tb_AccessPwd.Text.Trim()))        // 访问密码
            {
                param += "2," + tb_AccessPwd.Text.Trim() + "&";
            }
            param = param.TrimEnd('&');

            // 可选参数结束
            param = param.TrimEnd('|');
            String rt = ClouReaderAPI.CLReader.RFID_OPTION.WriteEPC(ConnID, param);
            if (!rt.StartsWith("0"))
            {
                errorMsg = rt;
                return false;
            }
            else
            {
                return true;
            }
        }
        /// <summary>
        /// 写用户数据
        /// </summary>
        private Boolean WriteUserData(out String errorMsg)
        {
            String param = "";
            errorMsg = "";
            param += AntNum.ToString() + "|";
            param += "3|";
            param += "0000|";
            Int32 iLen = Int32.Parse(tb_WriteLength.Text.Trim());
            string s_UserData = tb_WriteData.Text.Trim().PadRight(iLen * 4, '0');  // 
            param += s_UserData + "|";
            // 必选参数结束
            if (!String.IsNullOrEmpty(tb_SelectTID.Text))               // 匹配TID
            {
                String kx_param_1 = "";
                kx_param_1 += "02";
                kx_param_1 += "0000";
                kx_param_1 += ClouReaderAPI.MyHelper.MyString.ByteToString((Byte)(tb_SelectTID.Text.Trim().Length * 4));
                kx_param_1 += tb_SelectTID.Text.Trim();
                param += "1," + kx_param_1 + "&";
            }
            else                                                        // 匹配EPC
            {
                String kx_param_1 = "";
                kx_param_1 += "01";
                kx_param_1 += "0020";
                kx_param_1 += ClouReaderAPI.MyHelper.MyString.ByteToString((Byte)(tb_SelectEPC.Text.Trim().Length * 4));
                kx_param_1 += tb_SelectEPC.Text.Trim();
                param += "1," + kx_param_1 + "&";
            }
            if (!String.IsNullOrEmpty(tb_AccessPwd.Text.Trim()))        // 访问密码
            {
                param += "2," + tb_AccessPwd.Text.Trim() + "&";
            }
            param = param.TrimEnd('&');

            // 可选参数结束
            param = param.TrimEnd('|');

            String rt = ClouReaderAPI.CLReader.RFID_OPTION.WriteEPC(ConnID, param);
            if (!rt.StartsWith("0"))
            {
                errorMsg = rt;
                return false;
            }
            else
            {
                return true;
            }
        }
        /// <summary>
        ///  打印信息
        /// </summary>
        /// <param name="msg"></param>
        private void WriteMsgToForm(String msg) 
        {
            if (tb_TestMsg.InvokeRequired)
            {
                tb_TestMsg.BeginInvoke(new WriteDebug(WriteMsgToForm), msg);
                return;
            }
            if (nowtTestMessageCount >= 10000)
            {
                nowtTestMessageCount = 0;
                tb_TestMsg.Clear();
            }
            tb_TestMsg.AppendText(msg + Environment.NewLine);
            nowtTestMessageCount++;
        }
        /// <summary>
        /// 刷当前信息
        /// </summary>
        public void FlushState() 
        {
            lb_ReadCount.Text = ReadSuccessCount.ToString();
            lb_WriteCount.Text = WriteSuccessCount.ToString();
        }
        /// <summary>
        /// 检查写读是否一致
        /// </summary>
        /// <returns></returns>
        public Boolean CheckWriteRead() 
        {
            Boolean rt = true;
            if (cb_Write.Checked && cb_Read.Checked) 
            {
                if (cmb_WriteType.SelectedIndex == 0)               // 检查EPC
                {
                    if (readModel != null) 
                    {
                        if (!readModel.EPC.Equals(tb_WriteData.Text)) 
                        {
                            rt = false;
                        }
                    }
                }
                else if (cmb_WriteType.SelectedIndex == 1)          // 检查用户数据
                {
                    if (readModel != null)
                    {
                        if (!readModel.UserData.Equals(tb_WriteData.Text))
                        {
                            rt = false;
                        }
                    }
                }
            }
            return rt;
        }
        #endregion

        #region GB标签参数测试

        /// <summary>
        /// 检查GB标签测试参数
        /// </summary>
        public Boolean CheckGBParam()
        {
            Boolean rt = false;
            try
            {
                if (Int32.Parse(tb_GBGardnerXMax.Text) - Int32.Parse(tb_GBGardnerXMin.Text) >= 0
                    && Int32.Parse(tb_GBGardnerYMax.Text) - Int32.Parse(tb_GBGardnerYMin.Text) >= 0)
                {
                    rt = true;
                }
            }
            catch
            {
                rt = false;
            }
            return rt;
        }
        /// <summary>
        /// 获取国标测试
        /// </summary>
        /// <returns></returns>
        public GBTestModel GetGBTestParam()
        {
            GBTestModel rt = new GBTestModel();
            try
            {
                rt.GardnerXMin = Int32.Parse(tb_GBGardnerXMin.Text);
                rt.GardnerXMax = Int32.Parse(tb_GBGardnerXMax.Text);
                rt.GardnerYMin = Int32.Parse(tb_GBGardnerYMin.Text);
                rt.GardnerYMax = Int32.Parse(tb_GBGardnerYMax.Text);

                rt.SingleWhileTestCount = Int32.Parse(tb_TestMaxCount.Text);
                rt.ContinuousFailureMax = 10;
                rt.ContinuousFailureCount = 0;
                rt.SuccessCount = 0;
                rt.FailureCount = 0;
                rt.IsOK = true;
            }
            catch { rt = null; }
            return rt;
        }

        private void cb_GBGardnerEnable_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_GBGardnerEnable.Checked)
            {
                IsGBTest = true;
            }
            else 
            {
                IsGBTest = false;
            }
        }

        #endregion

        
    }
}
