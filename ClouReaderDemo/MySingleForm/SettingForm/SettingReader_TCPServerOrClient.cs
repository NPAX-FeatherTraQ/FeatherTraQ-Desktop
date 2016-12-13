using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ClouReaderDemo.MySingleForm.SettingForm
{
    public partial class SettingReader_TCPServerOrClient : BaseOption
    {
        ClouReaderAPI.ClouInterface.IAsynchronousMessage contextForm = null;
        public SettingReader_TCPServerOrClient()
        {
            InitializeComponent();
        }
        public SettingReader_TCPServerOrClient(string readerID, ClouReaderAPI.ClouInterface.IAsynchronousMessage contextForm)
            : this()
        {
            this.ConnID = readerID;
            this.contextForm = contextForm;
        }

        private void SettingReader_TCPServerOrClient_Load(object sender, EventArgs e)
        {
            this.Width = 500;
            this.Height = 300;
            Init();
        }
        // 查询
        private void Init() 
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
        // 配置
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

        private void btn_Init_Click(object sender, EventArgs e)
        {
            Init();
        }
    }
}
