using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ClouReaderDemo.MySingleForm.SettingForm
{
    /// <summary>
    /// 网口设置
    /// </summary>
    public partial class SettingReader_TCPPort : BaseOption
    {
        ClouReaderAPI.ClouInterface.IAsynchronousMessage contextForm = null;

        public SettingReader_TCPPort()
        {
            InitializeComponent();
        }
        public SettingReader_TCPPort(string readerID, ClouReaderAPI.ClouInterface.IAsynchronousMessage contextForm)
            : this()
        {
            this.ConnID = readerID;
            this.contextForm = contextForm;
        }

        private void SettingReader_TCPPort_Load(object sender, EventArgs e)
        {
            this.Width = 500;
            this.Height = 300;
            Init();
        }

        private void Init() 
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

        private void btn_Init_Click(object sender, EventArgs e)
        {
            Init();
        }
    }
}
