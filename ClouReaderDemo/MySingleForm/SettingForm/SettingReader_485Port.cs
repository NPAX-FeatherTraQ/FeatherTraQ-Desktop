using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ClouReaderDemo.MySingleForm.SettingForm
{
    public partial class SettingReader_485Port : BaseOption
    {
        ClouReaderAPI.ClouInterface.IAsynchronousMessage contextForm = null;
        public SettingReader_485Port()
        {
            InitializeComponent();
        }
        public SettingReader_485Port(string readerID, ClouReaderAPI.ClouInterface.IAsynchronousMessage contextForm)
            : this()
        {
            this.ConnID = readerID;
            this.contextForm = contextForm;
        }

        private void SettingReader_485Port_Load(object sender, EventArgs e)
        {
            this.Width = 500;
            this.Height = 300;
            Init();
        }

        private void Init() 
        {
            String rtParam = ClouReaderAPI.CLReader.PARAM_SET.GetReader485(ConnID);
            String[] arrParam = rtParam.Split('|');
            if (arrParam.Length == 2)
            {
                try
                {
                    tb_0001_15_00.Text = arrParam[0];
                    cmb_0001_15_01.SelectedIndex = byte.Parse(arrParam[1]);
                }
                catch { }
            }
        }

        private void btn_0001_15_Set_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(tb_0001_15_00.Text.Trim()))
            {
                String rt = ClouReaderAPI.CLReader.PARAM_SET.SetReader485(ConnID, tb_0001_15_00.Text.Trim() + "|1," + cmb_0001_15_01.SelectedIndex);
                ShowMessage(rt);
            }
        }

        private void btn_Init_Click(object sender, EventArgs e)
        {
            Init();
        }
    }
}
