using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ClouReaderAPI;
using ClouReaderAPI.ClouInterface;
using ClouReaderDemo.MyFormTemplet;

namespace ClouReaderDemo.MySingleForm.TestForm
{
    public partial class RFID_Option : BaseOption
    {
        IAsynchronousMessage contextForm = null;
        public Int32 rfIndex = 0;               // 当前查询到的读的器的频率范围
        Dictionary<Int32, List<String>> DIC_RF = new Dictionary<int, List<String>>() {
            //    {0, new List<String>(){"920.625","920.875","921.125","921.375","921.625","921.875","922.125","922.375","922.625","922.875","923.125","923.375","923.625","923.875","924.125","924.375"}},
            //    {1, new List<String>(){"840.625","840.875","841.125","841.375","841.625","841.875","842.125","842.375","842.625","842.875","843.125","843.375","843.625","843.875","844.125","844.375"}},   
            //    {2, new List<String>(){"840.625","840.875","841.125","841.375","841.625","841.875","842.125","842.375","842.625","842.875","843.125","843.375","843.625","843.875","844.125","844.375","920.625","920.875","921.125","921.375","921.625","921.875","922.125","922.375","922.625","922.875","923.125","923.375","923.625","923.875","924.125","924.375"}},
            //    {3, new List<String>(){"866.3","866.9","867.5","868.1"}},   
            //    {4, new List<String>(){"902.75","903.25","903.75","904.25","904.75","905.25","905.75","906.25","906.75","907.25","907.75","908.25","908.75","909.25","909.75","910.25","910.75","911.25","911.75","912.25","912.75","913.25","913.75","914.25","914.75","915.25","915.75","916.25","916.75","917.25","917.75","918.25","918.75","919.25","919.75","920.25","920.75","921.25","921.75","922.25","922.75","923.25","923.75","924.25","924.75","925.25","925.75","926.25","926.75","927.25"}}   
        };

        public RFID_Option()
        {
            InitializeComponent();
        }

        public RFID_Option(string readerID, IAsynchronousMessage contextForm)
            : this()
        {
            this.ConnID = readerID;
            this.contextForm = contextForm;
            this.Text = readerID.Trim() + " -- Configuration";
        }

        private void RFID_Option_Load(object sender, EventArgs e)
        {
            InitDIC_RF();
            InitComboBox();
            tc_Main.SelectedIndex = -1;
            tc_Main.SelectedIndex = 0;
        }

        private void RFID_Option_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                
            }
            catch(Exception ex) {}
        }

        #region 通用辅助方法

        private void InitDIC_RF() 
        {
            DIC_RFAddItem(0, 920.625f, 924.375f, 0.25f);
            DIC_RFAddItem(1, 840.625f, 844.375f, 0.25f);
            DIC_RFAddItem(2, 840.625f, 844.375f, 0.25f);
            DIC_RFAddItem(2, 920.625f, 924.375f, 0.25f);
            DIC_RFAddItem(3, 902.75f, 927.25f, 0.5f);
            DIC_RFAddItem(4, 865.7f, 868.1f, 0.6f);
            DIC_RFAddItem(5, 916.8f, 920.4f, 1.2f);
            DIC_RFAddItem(6, 922.25f, 927.75f, 0.25f);
        }

        private void DIC_RFAddItem(Int32 index, float fStart, float fEnd, float jump) 
        {
            List<String> listItem = new List<String>();
            while (fStart <= fEnd) 
            {
                listItem.Add(fStart.ToString("F3"));
                fStart += jump;
            }
            if (!DIC_RF.ContainsKey(index))
            {
                DIC_RF.Add(index,listItem);
            }
            else 
            {
                foreach (String item in listItem)
                {
                    DIC_RF[index].Add(item);
                }
            }
        }

        private void InitComboBox() 
        {
            Int32 index = 0;
            cb_0010_05_01.Items.Clear();
            foreach (String item in DIC_RF[rfIndex])
            {
                cb_0010_05_01.Items.Add(new CCBoxItem(item, index));
                index++;
            }
            cb_0010_05_01.MaxDropDownItems = 8;
            // Make the "Name" property the one to display, rather than the ToString() representation.
            cb_0010_05_01.DisplayMember = "Name";
            cb_0010_05_01.ValueSeparator = ", ";
        }

        #endregion

        #region 读写器设置

        private void btn_0001_02_Get_Click(object sender, EventArgs e)
        {
            Int32 rt = -1;
            String rtStr = ClouReaderAPI.CLReader.PARAM_SET.GetReaderSerialPortParam(ConnID);
            if (Int32.TryParse(rtStr,out rt))
            {
                cb_0001_02_00.SelectedIndex = rt;
            }
            else 
            {
                ShowMessage(rtStr);
            }
        }

        private void btn_0001_02_Set_Click(object sender, EventArgs e)
        {
            ShowMessage(ClouReaderAPI.CLReader.PARAM_SET.SetReaderSerialPortParam(ConnID,cb_0001_02_00.SelectedIndex.ToString()));
        }

        private void btn_0001_04_Get_Click(object sender, EventArgs e)
        {
            String rtStr = ClouReaderAPI.CLReader.PARAM_SET.GetReaderNetworkPortParam(ConnID);
            String[] ipParam = rtStr.Split('|');
            if (ipParam.Length == 3)
            {
                tb_0001_04_00.Text = ipParam[0];
                tb_0001_04_01.Text = ipParam[1];
                tb_0001_04_02.Text = ipParam[2];
            }
            else 
            {
                ShowMessage(rtStr);
            }
        }

        private void btn_0001_05_Set_Click(object sender, EventArgs e)
        {
            String param = "";
            param += tb_0001_04_00.Text.Trim() + "|";
            param += tb_0001_04_01.Text.Trim() + "|";
            param += tb_0001_04_02.Text.Trim();
            ShowMessage(ClouReaderAPI.CLReader.PARAM_SET.SetReaderNetworkPortParam(ConnID, param));
        }

        private void btn_0001_06_Get_Click(object sender, EventArgs e)
        {
            tb_0001_06_00.Text = ClouReaderAPI.CLReader.PARAM_SET.GetReaderMacParam(ConnID);
        }

        private void btn_0001_07_Set_Click(object sender, EventArgs e)
        {
            String param = "";
            param += rb_0001_08_00.Checked == true ? "0|" : "1|";
            if (rb_0001_08_00.Checked && !String.IsNullOrEmpty(tb_0001_08_01.Text)) 
            {
                param += "1," + tb_0001_08_01.Text.Trim();
            }
            else if (rb_0001_08_02.Checked && !String.IsNullOrEmpty(tb_0001_08_03.Text)) 
            {
                param += "2," + tb_0001_08_03.Text.Trim() + "&3," + tb_0001_08_04.Text.Trim();
            }
            param = param.TrimEnd('|');
            ShowMessage(ClouReaderAPI.CLReader.PARAM_SET.SetReaderServerOrClient(ConnID, param));
        }

        private void btn_0001_08_Get_Click(object sender, EventArgs e)
        {
            String searchResult = ClouReaderAPI.CLReader.PARAM_SET.GetReaderServerOrClient(ConnID);
            String[] varParam = searchResult.Split('|');
            if (varParam.Length == 4) 
            {
                if (varParam[0].Equals("0"))
                {
                    rb_0001_08_00.Checked = true;
                    rb_0001_08_02.Checked = false;
                }
                else 
                {
                    rb_0001_08_00.Checked = false;
                    rb_0001_08_02.Checked = true;
                }
                tb_0001_08_01.Text = varParam[1];
                tb_0001_08_03.Text = varParam[2];
                tb_0001_08_04.Text = varParam[3];
            }
        }

        private void btn_0001_13_Set_Click(object sender, EventArgs e)
        {
            ShowMessage(ClouReaderAPI.CLReader.PARAM_SET.SetReaderMacParam(ConnID,tb_0001_06_00.Text.Trim()));
        }

        private void btn_0001_11_Get_Click(object sender, EventArgs e)
        {
            String rtStr = ClouReaderAPI.CLReader.PARAM_SET.GetReaderUTC(ConnID);
            double utc = -1;
            if (Double.TryParse(rtStr, out utc))
            {
                System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
                startTime = startTime.AddSeconds(utc);
                tb_0001_10_00.Text = startTime.ToString("yyyy.MM.dd HH:mm:ss");
            }
            else 
            {
                ShowMessage(rtStr);
            }
        }

        private void btn_0001_10_Set_Click(object sender, EventArgs e)
        {
            try
            {
                double utc = (DateTime.Parse(tb_0001_10_00.Text.Trim()) - TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1, 0, 0, 0))).TotalSeconds;
                ShowMessage(ClouReaderAPI.CLReader.PARAM_SET.SetReaderUTC(ConnID,utc.ToString("f4")));
            }
            catch (Exception ex) 
            {
                ShowMessage("参数错误！");
            }
        }

        private void tb_0001_10_00_MouseClick(object sender, MouseEventArgs e)
        {// 右键更新时间为当前时间
            if (e.Button == System.Windows.Forms.MouseButtons.Right) 
            {
                tb_0001_10_00.Text = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss");
            }
        }

        private void btn_0001_15_Set_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(tb_0001_15_00.Text.Trim())) 
            {
               String rt = ClouReaderAPI.CLReader.PARAM_SET.SetReader485(ConnID, tb_0001_15_00.Text.Trim());
               ShowMessage(rt);
            }
        }

        private void btn_0001_16_Get_Click(object sender, EventArgs e)
        {
            tb_0001_15_00.Text = ClouReaderAPI.CLReader.PARAM_SET.GetReader485(ConnID).Split('|')[0].ToString();
        }

        private void btn_0001_17_Set_Click(object sender, EventArgs e)
        {
            String param = this.cmb_0001_17_00.SelectedIndex.ToString();
            String rt = ClouReaderAPI.CLReader.PARAM_SET.SetBreakPointUpload(ConnID, param);
            ShowMessage(rt);
        }

        private void btn_0001_18_Get_Click(object sender, EventArgs e)
        {
            int selectIndex = -1;
            String param = ClouReaderAPI.CLReader.PARAM_SET.GetBreakPointUpload(ConnID);
            if (Int32.TryParse(param,out selectIndex)) 
            {
                this.cmb_0001_17_00.SelectedIndex = selectIndex;
            }
        }
        #endregion

        #region GPIO

        private void btn_0001_0C_Get_Click(object sender, EventArgs e)
        {
            String param = cb_0001_0B_00.SelectedIndex.ToString();
            String rtStr = ClouReaderAPI.CLReader.PARAM_SET.GetReaderGPIParam(ConnID, param);
            String[] arrParam = rtStr.Split('|');
            if (arrParam.Length == 4)
            {
                try
                {
                    cb_0001_0B_01.SelectedIndex = byte.Parse(arrParam[0]);
                    tb_0001_0B_02.Text = arrParam[1];
                    cb_0001_0B_03.SelectedIndex = byte.Parse(arrParam[2]);
                    tb_0001_0B_04.Text = arrParam[3];
                }
                catch { }
            }
            else
            {
                ShowMessage(rtStr);
            }
        }

        private void btn_0001_0B_Set_Click(object sender, EventArgs e)
        {
            if (cb_0001_0B_01.SelectedIndex > 0 && cb_0001_0B_01.SelectedIndex == cb_0001_0B_03.SelectedIndex)
            {
                MessageBox.Show("开始条件，与触发条件不能一样！");
                return;
            }
            String strParam = "";
            try
            {
                strParam += cb_0001_0B_00.SelectedIndex + "|";
                strParam += cb_0001_0B_01.SelectedIndex + "|";
                strParam += tb_0001_0B_02.Text.Trim() + "|";
                strParam += cb_0001_0B_03.SelectedIndex + "|";
            }
            catch { }
            if (cb_0001_0B_03.SelectedIndex == 6)
            {
                strParam += "1," + tb_0001_0B_04.Text.Trim();
            }
            strParam = strParam.TrimEnd('|');
            ShowMessage(ClouReaderAPI.CLReader.PARAM_SET.SetReaderGPIParam(ConnID, strParam));
        }

        private void cb_0001_0B_00_SelectedIndexChanged(object sender, EventArgs e)
        {
            btn_0001_0C_Get_Click(null, null);
        }

        private void cb_0001_0B_03_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_0001_0B_03.SelectedIndex == 6)
            {
                tb_0001_0B_04.Visible = true;
                lb_DelayTime.Visible = true;
                lb_DelayTime_1.Visible = true;
            }
            else
            {
                tb_0001_0B_04.Visible = false;
                lb_DelayTime.Visible = false;
                lb_DelayTime_1.Visible = false;
            }
        }

        private void btn_0001_09_Hight_Click(object sender, EventArgs e)
        {
            String param = "";
            if (chk_GPO_1.Checked) 
            {
                param += "1," + cmb_GPO_1.SelectedIndex + "&";
            }
            if (chk_GPO_2.Checked)
            {
                param += "2," + cmb_GPO_2.SelectedIndex + "&";
            }
            if (chk_GPO_3.Checked)
            {
                param += "3," + cmb_GPO_3.SelectedIndex + "&";
            }
            if (chk_GPO_4.Checked)
            {
                param += "4," + cmb_GPO_4.SelectedIndex + "&";
            }
            param = param.TrimEnd('&');
            String rt = ClouReaderAPI.CLReader.PARAM_SET.SetReaderGPOState(ConnID,param);
            ShowMessage(rt);
        }

        private void btn_0001_0A_GET_Click(object sender, EventArgs e)
        {
            String rtParam = ClouReaderAPI.CLReader.PARAM_SET.GetReaderGPIState(ConnID);
            String[] arrParam = rtParam.Split('&');
            foreach (String item in arrParam)
            {
                String[] arrItem = item.Split(',');
                if (arrItem.Length == 2) 
                {
                    Control[] arrControl = gb_GPI.Controls.Find("btn_GPI_" + arrItem[0], true);
                    if (arrControl.Length > 0) 
                    {
                        if (arrItem[1].Equals("0"))
                        {
                            ((Button)arrControl[0]).BackColor = Color.DimGray;
                        }
                        else 
                        {
                            ((Button)arrControl[0]).BackColor = Color.Red;
                        }
                    }
                }
            }
        }

        private void btn_0001_0E_Get_Click(object sender, EventArgs e)
        {
            String rtParam = ClouReaderAPI.CLReader.PARAM_SET.GetReaderWG(ConnID);
            String[] arrParam = rtParam.Split('|');
            if (arrParam.Length == 3)
            {
                try
                {
                    cb_0001_0D_00.SelectedIndex = byte.Parse(arrParam[0]);
                    cb_0001_0D_01.SelectedIndex = byte.Parse(arrParam[1]);
                    cb_0001_0D_02.SelectedIndex = byte.Parse(arrParam[2]);
                }
                catch { }
            }
        }

        private void btn_0001_0D_Get_Click(object sender, EventArgs e)
        {
            String param = "";
            param += cb_0001_0D_00.SelectedIndex + "|" + cb_0001_0D_01.SelectedIndex + "|" + cb_0001_0D_02.SelectedIndex;
            String rt = ClouReaderAPI.CLReader.PARAM_SET.SetReaderWG(ConnID, param);
            ShowMessage(rt);
        }

        #endregion

        #region RFID配置

        private void btn_Set_0010_01_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(ConnID))
            {
                //string param = tb_0010_01.Text.Trim();
                //ClouReaderAPI.CLReader.rfidOption.SetReaderPower(ConnID, param);
                ShowMessage("成功！");
            }
        }

        private void btn_Get_0010_02_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(ConnID))
            {
                //string param = tb_0010_01.Text.Trim();
                ShowMessage(ClouReaderAPI.CLReader.RFID_OPTION.GetReaderPower(ConnID));
            }

        }

        private void btn_0010_01_Set_Click(object sender, EventArgs e)
        {
            String sendParam = "";
            try
            {
                if (chk_0010_01_00.Checked)
                {
                    sendParam += "1," + cb_0010_01_00.SelectedIndex + "&";
                }
                if (chk_0010_01_01.Checked)
                {
                    sendParam += "2," + cb_0010_01_01.SelectedIndex + "&";
                }
                if (chk_0010_01_02.Checked)
                {
                    sendParam += "3," + cb_0010_01_02.SelectedIndex + "&";
                }
                if (chk_0010_01_03.Checked)
                {
                    sendParam += "4," + cb_0010_01_03.SelectedIndex + "&";
                }
                if (chk_0010_01_04.Checked)
                {
                    sendParam += "5," + cb_0010_01_04.SelectedIndex + "&";
                }
                if (chk_0010_01_05.Checked)
                {
                    sendParam += "6," + cb_0010_01_05.SelectedIndex + "&";
                }
                if (chk_0010_01_06.Checked)
                {
                    sendParam += "7," + cb_0010_01_06.SelectedIndex + "&";
                }
                if (chk_0010_01_07.Checked)
                {
                    sendParam += "8," + cb_0010_01_07.SelectedIndex;
                }
                sendParam = sendParam.TrimEnd('&');
            }
            catch { }
            String rtStr = ClouReaderAPI.CLReader.RFID_OPTION.SetANTPowerParam(ConnID, sendParam);
            ShowMessage(rtStr);
        }

        private void btn_0010_02_Get_Click(object sender, EventArgs e)
        {
            String rtStr = ClouReaderAPI.CLReader.RFID_OPTION.GetANTPowerParam(ConnID);
            String[] varStr = rtStr.Split('&');
            if (varStr.Length > 0)
            {
                try
                {
                    foreach (String item in varStr)
                    {
                        String[] varItem = item.Split(',');
                        if (varItem[0].Equals("1")) 
                        {
                            cb_0010_01_00.SelectedIndex = Byte.Parse(varItem[1]);
                        }
                        else if (varItem[0].Equals("2"))
                        {
                            cb_0010_01_01.SelectedIndex = Byte.Parse(varItem[1]);
                        }
                        else if (varItem[0].Equals("3"))
                        {
                            cb_0010_01_02.SelectedIndex = Byte.Parse(varItem[1]);
                        }
                        else if (varItem[0].Equals("4"))
                        {
                            cb_0010_01_03.SelectedIndex = Byte.Parse(varItem[1]);
                        }
                        else if (varItem[0].Equals("5"))
                        {
                            cb_0010_01_04.SelectedIndex = Byte.Parse(varItem[1]);
                        }
                        else if (varItem[0].Equals("6"))
                        {
                            cb_0010_01_05.SelectedIndex = Byte.Parse(varItem[1]);
                        }
                        else if (varItem[0].Equals("7"))
                        {
                            cb_0010_01_06.SelectedIndex = Byte.Parse(varItem[1]);
                        }
                        else if (varItem[0].Equals("8"))
                        {
                            cb_0010_01_07.SelectedIndex = Byte.Parse(varItem[1]);
                        }
                    }
                }
                catch { }
            }
            else
            {
                ShowMessage(rtStr);
            }
        }

        private void btn_0010_05_Set_Click(object sender, EventArgs e)
        {
            String sendParam = "";
            if (cb_0010_05_00.SelectedIndex == 1)
            {
                sendParam += cb_0010_05_00.SelectedIndex;
            }
            else 
            {
                StringBuilder sb = new StringBuilder();
                foreach (CCBoxItem item in cb_0010_05_01.CheckedItems)
                {
                    sb.Append(item.Value).Append(",");
                }
                sendParam += cb_0010_05_00.SelectedIndex + "|" + sb.ToString().TrimEnd(',');
            }
            String rtStr = ClouReaderAPI.CLReader.RFID_OPTION.SetReaderWorkFrequency(ConnID, sendParam);
            ShowMessage(rtStr);
        }

        private void btn_0010_06_Get_Click(object sender, EventArgs e)
        {
            String rtStr = ClouReaderAPI.CLReader.RFID_OPTION.GetReaderWorkFrequency(ConnID);
            String[] varStr = rtStr.Split('|');
            if (varStr.Length > 0)
            {
                try
                {
                    InitComboBox();
                    cb_0010_05_00.SelectedIndex = Byte.Parse(varStr[0]);
                    foreach (String item in varStr[1].Split(','))
                    {
                        Int32 ii = -1;
                        if (Int32.TryParse(item, out ii)) 
                        {
                            cb_0010_05_01.SetItemChecked(ii, true);
                        }
                    }
                }
                catch { }
            }
            else
            {
                ShowMessage(rtStr);
            }
        }

        private void cb_0010_05_00_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_0010_05_00.SelectedIndex == 1)
            {
                cb_0010_05_01.Enabled = false;
            }
            else 
            {
                cb_0010_05_01.Enabled = true;
            }
        }

        private void btn_0010_07_Set_Click(object sender, EventArgs e)
        {
            Int32 iParam = 0;
            foreach (var item in gb_ANTEnable.Controls)
            {
                if (item is QQCheckBox) 
                {
                    QQCheckBox cb = (QQCheckBox)item;
                    if (cb.Checked)
                    {
                        iParam += Int32.Parse(cb.Tag.ToString());
                    }
                }
            }
            String rtStr = ClouReaderAPI.CLReader.RFID_OPTION.SetReaderANT(ConnID, iParam.ToString());
            // String rtStr = ClouReaderAPI.CLReader.RFID_OPTION.SetReaderANT(ConnID, "3|1,2-7-13&2,1-2-4-8&");
            ShowMessage(rtStr);
        }

        private void btn_0010_08_Get_Click(object sender, EventArgs e)
        {
            String rtStr = ClouReaderAPI.CLReader.RFID_OPTION.GetReaderANT(ConnID);
            byte index = 255;
            String[] arr_Param = rtStr.Split('|');
            if (byte.TryParse(arr_Param[0], out index))
            {
                foreach (var item in gb_ANTEnable.Controls)
                {
                    if (item is QQCheckBox)
                    {
                        QQCheckBox cb = (QQCheckBox)item;
                        if ((index & byte.Parse(cb.Tag.ToString())) == byte.Parse(cb.Tag.ToString()))
                        {
                            cb.Checked = true;
                        }
                        else
                        {
                            cb.Checked = false;
                        }
                    }
                }
            }
            else
            {
                ShowMessage(rtStr);
            }
        }

        private void btn_0010_0B_Set_Click(object sender, EventArgs e)
        {
            String sendParam = "";
            try
            {
                if (cb_0010_0B_00.SelectedIndex >= 0)
                {
                    if (cb_0010_0B_00.SelectedIndex < 4)
                    {
                        sendParam += "1," + cb_0010_0B_00.SelectedIndex + "&";
                    }
                    else 
                    {
                        sendParam += "1," + 255 + "&";
                    }
                }
                if (cb_0010_0B_01.SelectedIndex >= 0)
                {
                    sendParam += "2," + cb_0010_0B_01.SelectedIndex + "&";
                }
                if (cb_0010_0B_02.SelectedIndex >= 0)
                {
                    sendParam += "3," + cb_0010_0B_02.SelectedIndex + "&";
                }
                if (cb_0010_0B_03.SelectedIndex >= 0)
                {
                    sendParam += "4," + cb_0010_0B_03.SelectedIndex + "&";
                }
            }
            catch { }
            sendParam = sendParam.TrimEnd('&');
            String rtStr = ClouReaderAPI.CLReader.RFID_OPTION.SetEPCBaseBandParam(ConnID,sendParam);
            ShowMessage(rtStr);
        }

        private void btn_0010_0C_Get_Click(object sender, EventArgs e)
        {
            String rtStr = ClouReaderAPI.CLReader.RFID_OPTION.GetEPCBaseBandParam(ConnID);
            String[] varStr = rtStr.Split('|');
            if (varStr.Length == 4)
            {
                try
                {
                    if (varStr[0].Equals("255"))
                    {
                        cb_0010_0B_00.SelectedIndex = 4;
                    }
                    else 
                    {
                        cb_0010_0B_00.SelectedIndex = Byte.Parse(varStr[0]);
                    }
                    cb_0010_0B_01.SelectedIndex = Byte.Parse(varStr[1]);
                    cb_0010_0B_02.SelectedIndex = Byte.Parse(varStr[2]);
                    cb_0010_0B_03.SelectedIndex = Byte.Parse(varStr[3]);
                }
                catch { }
            }
            else
            {
                ShowMessage(rtStr);
            }

        }

        private void btn_0010_09_Set_Click(object sender, EventArgs e)
        {
            String sendParam = "";
            try
            {
                if (!String.IsNullOrEmpty(tb_0010_09_00.Text))
                {
                    sendParam += "1," + tb_0010_09_00.Text + "&";
                }
                if (!String.IsNullOrEmpty(tb_0010_09_01.Text))
                {
                    sendParam += "2," + tb_0010_09_01.Text;
                }
                sendParam = sendParam.TrimEnd('&');
            }
            catch { }
            String rtStr = ClouReaderAPI.CLReader.RFID_OPTION.SetTagUpdateParam(ConnID, sendParam);
            ShowMessage(rtStr);
        }

        private void btn_0010_0A_Get_Click(object sender, EventArgs e)
        {
            String rtStr = ClouReaderAPI.CLReader.RFID_OPTION.GetTagUpdateParam(ConnID);
            String[] varStr = rtStr.Split('|');
            if (varStr.Length == 2)
	        {
                tb_0010_09_00.Text = varStr[0];
                tb_0010_09_01.Text = varStr[1];
	        }
        }

        private void btn_0010_0D_Set_Click(object sender, EventArgs e)
        {
            String sendParam = "";
            try 
            {
                if (cb_0010_0D_00.SelectedIndex == 0)
                {
                    sendParam += cb_0010_0D_00.SelectedIndex;
                }
                else 
                {
                    sendParam += cb_0010_0D_00.SelectedIndex + "|1,"+tb_0010_0D_01.Text.Trim();
                }
            }
            catch { }
            String rtStr = ClouReaderAPI.CLReader.RFID_OPTION.SetReaderAutoSleepParam(ConnID, sendParam);
            ShowMessage(rtStr);
        }

        private void btn_0010_0E_Get_Click(object sender, EventArgs e)
        {
            String rtStr = ClouReaderAPI.CLReader.RFID_OPTION.GetReaderAutoSleepParam(ConnID);
            String[] varStr = rtStr.Split('|');
            if (varStr.Length == 2)
            {
                cb_0010_0D_00.SelectedIndex = byte.Parse(varStr[0]);
                tb_0010_0D_01.Text = varStr[1];
            }
        }

        #endregion

        #region 恢复出厂设置

        private void btn_RestoreFactory_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == ShowQuestion("Restore factory Settings will clear all of the data,confirm？")) 
            {
                ShowMessage(ClouReaderAPI.CLReader.PARAM_SET.SetReaderRestoreFactory(ConnID, "5AA5A55A"));
            }
        }

        #endregion

        private void btn_Set_0010_03_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(ConnID))
            {
                string param = cb_0010_03.SelectedIndex.ToString();
                ShowMessage(ClouReaderAPI.CLReader.RFID_OPTION.SetReaderRF(ConnID, param));
                rfIndex = cb_0010_03.SelectedIndex;
            }
        }

        private void btn_0010_04_Get_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(ConnID))
            {
                string rt = ClouReaderAPI.CLReader.RFID_OPTION.GetRederRF(ConnID);
                Int32 index = -1;
                if (Int32.TryParse(rt, out index))
                {
                    this.cb_0010_03.SelectedIndex = Int32.Parse(rt);
                    rfIndex = index;
                }
            }
        }

        //#region 测试命令

        //private void btn_0010_04_Get_t_Click(object sender, EventArgs e)
        //{
        //    if (!String.IsNullOrEmpty(ConnID))
        //    {
        //        string rt = ClouReaderAPI.CLReader.RFID_OPTION.GetRederRF(ConnID);
        //        Int32 index = -1;
        //        if (Int32.TryParse(rt, out index))
        //        {
        //            try
        //            {
        //                this.cb_0010_03_t.SelectedIndex = Int32.Parse(rt);
        //                rfIndex = index;
        //                cb_0101_00_1.Items.Clear();
        //                cb_0101_00_1.Items.AddRange(DIC_RF[rfIndex].ToArray());
        //            }
        //            catch { }
        //        }
        //    }
            
        //}

        //private void btn_0010_03_Set_t_Click(object sender, EventArgs e)
        //{
        //    if (!String.IsNullOrEmpty(ConnID))
        //    {
        //        string param = cb_0010_03_t.SelectedIndex.ToString();
        //        ShowMessage(ClouReaderAPI.CLReader.RFID_OPTION.SetReaderRF(ConnID, param));
        //        btn_0010_04_Get_t_Click(null, null);
        //    }
        //}
       

        //private void btn_0101_00_Click(object sender, EventArgs e)
        //{
        //    if (!String.IsNullOrEmpty(ConnID))
        //    {
        //        string param = btn_0101_00.Tag.ToString() + "|" + cb_0101_00_1.SelectedIndex.ToString();

        //        ShowMessage(ClouReaderAPI.CLReader.RFID_OPTION.SendCarrier(ConnID, param));
        //    }
        //}

        //private void dud_0101_01_SelectedItemChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        tBar_0101_01.Value = Int32.Parse(dud_0101_01.Text.Trim());
        //    }
        //    catch { }
        //}

        //private void dud_0101_01_Click(object sender, EventArgs e)
        //{
        //    string param = dud_0101_01.Text.ToString() + "|0";
        //    string rt = ClouReaderAPI.CLReader.RFID_OPTION.Set_0101_01(ConnID, param);
        //}

        //private void dud_0101_01_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyValue == 13)
        //    {
        //        dud_0101_01_Click(null, null);
        //    }
        //}

        //private void tBar_0101_01_Scroll(object sender, EventArgs e)
        //{
        //    dud_0101_01.Text = tBar_0101_01.Value.ToString();
        //}

        //private void tBar_0101_01_MouseUp(object sender, MouseEventArgs e)
        //{
        //    dud_0101_01_Click(null,null);
        //}

        //private void dud_0101_03_02_MouseUp(object sender, MouseEventArgs e)
        //{
        //    string param = tb_0101_03_00.Text.ToString() + "|" + tb_0101_03_01.Text.ToString() + "|" + dud_0101_03_02.Text.ToString() + "|0";
        //    string rt = ClouReaderAPI.CLReader.RFID_OPTION.Set_0101_03(ConnID, param);
        //}

        //private void dud_0101_03_02_SelectedItemChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        tBar_0101_03_03.Value = Int32.Parse(dud_0101_03_02.Text.Trim());
        //    }
        //    catch { }
        //}

        //private void dud_0101_03_02_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyValue == 13)
        //    {
        //        string param = tb_0101_03_00.Text.ToString() + "|" + tb_0101_03_01.Text.ToString() + "|" + dud_0101_03_02.Text.ToString() + "|0";
        //        string rt = ClouReaderAPI.CLReader.RFID_OPTION.Set_0101_03(ConnID, param);
        //    }
        //}

        //private void btn_0101_01_Click(object sender, EventArgs e)
        //{
        //    if (!String.IsNullOrEmpty(ConnID))
        //    {
        //        string param = dud_0101_01.Text.ToString() + "|1";
        //        string rt = ClouReaderAPI.CLReader.RFID_OPTION.Set_0101_01(ConnID, param);
        //        ShowMessage(rt);
        //    }
        //}

        //private void tBar_0101_03_03_Scroll(object sender, EventArgs e)
        //{
        //    dud_0101_03_02.Text = tBar_0101_03_03.Value.ToString();
        //}

        //private void tBar_0101_03_03_MouseUp(object sender, MouseEventArgs e)
        //{
        //    string param = tb_0101_03_00.Text.ToString() + "|" + tb_0101_03_01.Text.ToString() + "|" + dud_0101_03_02.Text.ToString() + "|0";
        //    string rt = ClouReaderAPI.CLReader.RFID_OPTION.Set_0101_03(ConnID, param);
        //}

        //private void tb_0101_03_01_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyValue == 13)
        //    {
        //        if (cb_0101_00_1.Items.Count > 0)
        //        {
        //            Int32 selectIndex = cb_0101_00_1.Items.Count / 2;
        //            cb_0101_00_1.SelectedIndex = selectIndex;
        //        }
        //        btn_0101_00_Click(null, null);
        //    }
        //}

        //private void btn_0101_03_Click(object sender, EventArgs e)
        //{
        //    if (!String.IsNullOrEmpty(ConnID))
        //    {
        //        string param = tb_0101_03_00.Text.ToString() + "|" + tb_0101_03_01.Text.ToString() + "|" + dud_0101_03_02.Text.ToString() + "|1";

        //        string rt = ClouReaderAPI.CLReader.RFID_OPTION.Set_0101_03(ConnID, param);
        //        ShowMessage(rt);

        //    }
        //}

        //private void btn_0101_04_Click(object sender, EventArgs e)
        //{
        //    if (!String.IsNullOrEmpty(ConnID))
        //    {
        //        string param = tb_0101_03_00.Text.ToString() + "|" + tb_0101_03_01.Text.ToString();
        //        string rt = ClouReaderAPI.CLReader.RFID_OPTION.Get_0101_04(ConnID, param);
        //        string[] array_rt = rt.Split('|');
        //        if (array_rt.Length >= 3)
        //        {
        //            this.tb_0101_03_00.Text = array_rt[0];
        //            this.tb_0101_03_01.Text = array_rt[1];
        //            int objIndex = dud_0101_03_02.Items.IndexOf(array_rt[2]);
        //            if (objIndex >= 0)
        //            {
        //                dud_0101_03_02.SelectedIndex = objIndex;
        //            }
        //            // this.dud_0101_03_02.Text = array_rt[2];
        //        }
        //    }
        //}

        //private void btn_0101_04_NextPower_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        Int32 nowDB = Int32.Parse(tb_0101_03_01.Text.Trim());
        //        if (nowDB + 1 <= maxDB) 
        //        {
        //            tb_0101_03_01.Text = (nowDB + 1).ToString();
        //            tb_0101_03_01_KeyDown(null, null);
        //        }
        //    }
        //    catch { }
        //}

        //private void btn_0101_05_Click(object sender, EventArgs e)
        //{
        //    if (!String.IsNullOrEmpty(ConnID))
        //    {
        //        string rt = ClouReaderAPI.CLReader.RFID_OPTION.Get_0101_05(ConnID);
        //        ShowMessage(rt);
        //        string[] array_rt = rt.Split('|');
        //        if (array_rt.Length >= 2)
        //        {
        //            this.tb_0101_05_00.Text = array_rt[0];
        //            this.tb_0101_05_01.Text = array_rt[1];
        //        }
        //    }
        //}

        //private void rb_0101_00_00_CheckedChanged(object sender, EventArgs e)
        //{
        //    RadioButton rb = sender as RadioButton;
        //    if (rb != null)
        //    {
        //        btn_0101_00.Tag = rb.Tag;
        //    }
        //}

        //private void btn_StopReader_Click(object sender, EventArgs e)
        //{
        //    ShowMessage(ClouReaderAPI.CLReader.RFID_OPTION.StopReader(ConnID));
        //}


        //#region pr9200外部PA反馈参数


        //private void dud_RES_1_SelectedItemChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        tBar_RES_1.Value = Int32.Parse(dud_RES_1.Text.Trim());
        //    }
        //    catch { }
        //}

        //private void dud_RES_2_SelectedItemChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        tBar_RES_2.Value = Int32.Parse(dud_RES_2.Text.Trim());
        //    }
        //    catch { }
        //}

        //private void tBar_RES_1_Scroll(object sender, EventArgs e)
        //{
        //    dud_RES_1.Text = tBar_RES_1.Value.ToString();
        //}

        //private void tBar_RES_2_Scroll(object sender, EventArgs e)
        //{
        //    dud_RES_2.Text = tBar_RES_2.Value.ToString();
        //}

        //private void tBar_RES_1_MouseUp(object sender, MouseEventArgs e)
        //{
        //    try
        //    {
        //        Int32 i_RES1 = Int32.Parse(dud_RES_1.Text.ToString());
        //        Int32 i_RES2 = Int32.Parse(dud_RES_2.Text.ToString());
        //        Byte RES1_RES2 = (Byte)((i_RES1 << 4) + i_RES2);

        //        string param = RES1_RES2 + "|0";
        //        string rt = ClouReaderAPI.CLReader.RFID_OPTION.Set_0101_06(ConnID, param);
        //    }
        //    catch { }
        //}

        //private void tBar_RES_2_MouseUp(object sender, MouseEventArgs e)
        //{
        //    tBar_RES_1_MouseUp(null, null);
        //}


        //private void btn_0101_06_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        Int32 i_RES1 = Int32.Parse(dud_RES_1.Text.ToString());
        //        Int32 i_RES2 = Int32.Parse(dud_RES_2.Text.ToString());
        //        Byte RES1_RES2 = (Byte)((i_RES1 << 4) + i_RES2);

        //        string param = RES1_RES2 + "|1";
        //        string rt = ClouReaderAPI.CLReader.RFID_OPTION.Set_0101_06(ConnID, param);
        //    }
        //    catch { }
        //}

        //private void btn_0101_07_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        String RES1_RES2 = ClouReaderAPI.CLReader.RFID_OPTION.Get_0101_07(ConnID);
        //        String[] arrRES = RES1_RES2.Split('|');
        //        dud_RES_1.Text = arrRES[0];
        //        dud_RES_2.Text = arrRES[1];
        //    }catch(Exception ex){}
        //}


        //private void dud_RES_1_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        Int32 i_RES1 = Int32.Parse(dud_RES_1.Text.ToString());
        //        Int32 i_RES2 = Int32.Parse(dud_RES_2.Text.ToString());
        //        Byte RES1_RES2 = (Byte)((i_RES1 << 4) + i_RES2);

        //        string param = RES1_RES2 + "|0";
        //        string rt = ClouReaderAPI.CLReader.RFID_OPTION.Set_0101_06(ConnID, param);
        //    }
        //    catch { }
        //}

        //private void dud_RES_2_Click(object sender, EventArgs e)
        //{
        //    dud_RES_1_Click(null, null);
        //}



        //#endregion

        //#endregion

        #region 参数初始化

        private void InitRFIDControl() 
        {
            foreach (var item in gb_SetANTPower.Controls)
            {
                CheckBox cb = item as CheckBox;
                if (cb != null)
                {
                    int index = Int32.Parse(cb.Name.Substring(cb.Name.Length - 1, 1));
                    if (index >= antCount)
                    {
                        cb.Enabled = false;
                    }
                }
            }
            foreach (var item in gb_ANTEnable.Controls)
            {
                CheckBox cb = item as CheckBox;
                if (cb != null)
                {
                    int index = Int32.Parse(cb.Name.Substring(cb.Name.Length - 1, 1));
                    if (index >= antCount)
                    {
                        cb.Enabled = false;
                    }
                }
            }
            
            btn_0010_02_Get_Click(null, null);
            btn_0010_04_Get_Click(null,null);
            btn_0010_0C_Get_Click(null, null);
            btn_0010_06_Get_Click(null, null);
            btn_0010_08_Get_Click(null, null);
            btn_0010_0A_Get_Click(null, null);
            btn_0010_0E_Get_Click(null, null);
        }

        private void InitReaderSetControl() 
        {
            btn_0001_02_Get_Click(null, null);
            btn_0001_04_Get_Click(null, null);
            btn_0001_06_Get_Click(null, null);
            btn_0001_08_Get_Click(null, null);
            btn_0001_11_Get_Click(null, null);
            //btn_0001_0C_Get_Click(null, null);
            btn_0001_16_Get_Click(null, null);
            btn_0001_18_Get_Click(null, null);
        }

        //private void InitTestControl()
        //{
        //    foreach (var item in gb_SendCarrier.Controls)
        //    {
        //        RadioButton rb = item as RadioButton;
        //        if (rb != null)
        //        {
        //            int index = Int32.Parse(rb.Name.Substring(rb.Name.Length - 1, 1));
        //            if (index >= antCount)
        //            {
        //                rb.Enabled = false;
        //            }
        //        }
        //    }
        //    for (int i = 127; i >= -127; i--)
        //    {
        //        dud_0101_01.Items.Add(i.ToString());
        //    }
        //    for (int i = 255; i >= 0; i--)
        //    {
        //        dud_0101_03_02.Items.Add(i.ToString());
        //    }
        //    String rtStr = ClouReaderAPI.CLReader.RFID_OPTION.Get_0101_02(ConnID);
        //    int objIndex = dud_0101_01.Items.IndexOf(rtStr);
        //    if (objIndex >= 0) 
        //    {
        //        dud_0101_01.SelectedIndex = objIndex;
        //    }

        //    // dud_0101_01.Text = ClouReaderAPI.CLReader.RFID_OPTION.Get_0101_02(ConnID);

        //    btn_0010_04_Get_t_Click(null, null);
        //    btn_0101_04_Click(null, null);

        //}

        //private void InitTestControl_1()
        //{
        //    for (int i = 7; i >= 0; i--)
        //    {
        //        dud_RES_1.Items.Add(i.ToString());
        //    }

        //    for (int i = 15; i >= 0; i--)
        //    {
        //        dud_RES_2.Items.Add(i.ToString());
        //    }
        //    try
        //    {
        //        String RES1_RES2 = ClouReaderAPI.CLReader.RFID_OPTION.Get_0101_07(ConnID);
        //        String[] arrRES = RES1_RES2.Split('|');
        //        int objIndex_1 = dud_RES_1.Items.IndexOf(arrRES[0]);
        //        if (objIndex_1 >= 0)
        //        {
        //            dud_RES_1.SelectedIndex = objIndex_1;
        //        }
        //        int objIndex_2 = dud_RES_2.Items.IndexOf(arrRES[1]);
        //        if (objIndex_2 >= 0)
        //        {
        //            dud_RES_2.SelectedIndex = objIndex_2;
        //        }
        //        // dud_RES_1.Text = arrRES[0];
        //        // dud_RES_2.Text = arrRES[1];
        //    }
        //    catch { }
        //}

        #endregion

        // 选项卡切换时，初始化查询所的数据
        private void tc_Main_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tc_Main.SelectedIndex == 0)
            {
                InitReaderProerty();
                InitRFIDControl();
            }
            else if (tc_Main.SelectedIndex == 1) 
            {
                InitReaderProerty();
                InitReaderSetControl();
            }
            //else if (tc_Main.SelectedIndex == 4)
            //{
            //    InitReaderProerty();
            //    InitTestControl();
            //}
            //else if (tc_Main.SelectedIndex == 5)
            //{
            //    InitReaderProerty();
            //    InitTestControl_1();
            //}
            else
            {

            }
        }

    }

   internal class CCBoxItem
    {
        private int val;
        public int Value
        {
            get { return val; }
            set { val = value; }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public CCBoxItem()
        {
        }

        public CCBoxItem(string name, int val)
        {
            this.name = name;
            this.val = val;
        }

        public override string ToString()
        {
            return string.Format("name: '{0}', value: {1}", name, val);
        }
    }
}
