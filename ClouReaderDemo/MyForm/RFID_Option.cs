using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ClouReaderAPI;
using ClouReaderAPI.ClouInterface;

namespace ClouReaderDemo.MyForm
{
    public partial class RFID_Option : BaseOption
    {
        IAsynchronousMessage contextForm = null;

        public RFID_Option()
        {
            InitializeComponent();
        }

        public RFID_Option(string readerID, IAsynchronousMessage contextForm)
            : this()
        {
            this.ConnID = readerID;
            this.contextForm = contextForm;
            this.Text = readerID.Trim() + " --配置";
        }

        private void RFID_Option_Load(object sender, EventArgs e)
        {
            Init();
        }

        private void Init() 
        {
            InitReaderProerty();
            InitTestControl();
            for (int i = -127; i <= 127; i++)
            {
                dud_0101_01.Items.Add(i.ToString());
            }
        }

        private void InitTestControl() 
        {
            foreach (var item in gb_SendCarrier.Controls)
	        {
                RadioButton rb = item as RadioButton;
                if (rb != null)
                {
                    int index = Int32.Parse(rb.Name.Substring(rb.Name.Length - 1, 1));
                    if (index >= antCount)
                    {
                        rb.Enabled = false;
                    }
                }
	        }

            dud_0101_01.Text = ClouReaderAPI.CLReader.RFID_OPTION.Get_0101_02(ConnID);
            
        }


        private void RFID_Option_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                // CLReader.DIC_CONNECT[readerID].CloseConnect();
                // CLReader.DIC_CONNECT.Remove(readerID);
            }
            catch(Exception ex) {}
        }

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
            ShowMessage(ClouReaderAPI.CLReader.PARAM_SET.SetReaderSerialPortParam(ConnID, param));
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

        
        #endregion

        #region 测试命令

        private void btn_Set_0010_03_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(ConnID))
            {
                string param = cb_0010_03.SelectedIndex.ToString();
                ShowMessage(ClouReaderAPI.CLReader.RFID_OPTION.SetReaderRF(ConnID, param));
            }
        }

        private void btn_Get_0010_04_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(ConnID))
            {
                string rt = ClouReaderAPI.CLReader.RFID_OPTION.GetRederRF(ConnID);
                Int32 index = -1;
                if (Int32.TryParse(rt, out index))
                {
                    this.cb_0010_03.SelectedIndex = Int32.Parse(rt);
                    ShowMessage("OK!");
                }
                else
                    ShowMessage("失败!");
            }
        }

        private void btn_0101_00_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(ConnID))
            {
                string param = btn_0101_00.Tag.ToString() + "|" + cb_0101_00_1.SelectedIndex.ToString();

                ShowMessage(ClouReaderAPI.CLReader.RFID_OPTION.SendCarrier(ConnID, param));
            }
        }

        private void dud_0101_01_SelectedItemChanged(object sender, EventArgs e)
        {
            string param = dud_0101_01.Text.ToString() + "|0";
            string rt = ClouReaderAPI.CLReader.RFID_OPTION.Set_0101_01(ConnID, param);
        }

        private void btn_0101_01_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(ConnID))
            {
                string param = dud_0101_01.Text.ToString() + "|1";
                string rt = ClouReaderAPI.CLReader.RFID_OPTION.Set_0101_01(ConnID, param);
                ShowMessage(rt);
            }
        }

        private void btn_0101_03_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(ConnID))
            {
                string param = tb_0101_03_00.Text.ToString() + "|" + tb_0101_03_01.Text.ToString() + "|" + tb_0101_03_02.Text.ToString();

                if (btn_0101_03.Tag.Equals("0"))
                {
                    param += "|0";
                    string rt = ClouReaderAPI.CLReader.RFID_OPTION.Set_0101_03(ConnID, param);
                    ShowMessage(rt);
                    if (rt.StartsWith("0"))
                    {
                        btn_0101_03.Text = "结束较准";
                        btn_0101_03.Tag = "1";
                    }
                }
                else
                {

                    param += "|1";
                    string rt = ClouReaderAPI.CLReader.RFID_OPTION.Set_0101_03(ConnID, param);
                    ShowMessage(rt);
                    if (rt.StartsWith("0"))
                    {
                        btn_0101_03.Text = "开始较准";
                        btn_0101_03.Tag = "0";
                    }
                }
            }
        }

        private void btn_0101_04_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(ConnID))
            {
                string param = tb_0101_03_00.Text.ToString() + "|" + tb_0101_03_01.Text.ToString();
                string rt = ClouReaderAPI.CLReader.RFID_OPTION.Get_0101_04(ConnID, param);
                ShowMessage(rt);
                string[] array_rt = rt.Split('|');
                if (array_rt.Length >= 3)
                {
                    this.tb_0101_03_00.Text = array_rt[0];
                    this.tb_0101_03_01.Text = array_rt[1];
                    this.tb_0101_03_02.Text = array_rt[2];
                }
            }
        }

        private void btn_0101_05_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(ConnID))
            {
                string rt = ClouReaderAPI.CLReader.RFID_OPTION.Get_0101_05(ConnID);
                ShowMessage(rt);
                string[] array_rt = rt.Split('|');
                if (array_rt.Length >= 2)
                {
                    this.tb_0101_05_00.Text = array_rt[0];
                    this.tb_0101_05_01.Text = array_rt[1];
                }
            }
        }

        private void rb_0101_00_00_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb != null)
            {
                btn_0101_00.Tag = rb.Tag;
            }
        }

        private void btn_StopReader_Click(object sender, EventArgs e)
        {
            ShowMessage(ClouReaderAPI.CLReader.RFID_OPTION.StopReader(ConnID));
        }

        #endregion


    }
}
