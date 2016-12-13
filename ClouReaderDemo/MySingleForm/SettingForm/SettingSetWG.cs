using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ClouReaderDemo.MySingleForm.SettingForm
{
    public partial class SettingSetWG : BaseOption
    {
        /// <summary>
        /// 上下文窗体
        /// </summary>
        SingleMainForm contextForm = null;
        public SettingSetWG()
        {
            InitializeComponent();
        }

        public SettingSetWG(string readerID, SingleMainForm contextForm)
            : this()
        {
            this.ConnID = readerID;
            this.contextForm = contextForm;
        }

        private void SettingSetWG_Load(object sender, EventArgs e)
        {
            this.Width = 500;
            this.Height = 300;
            Init();
        }

        private void Init()
        {
            btn_0001_0E_Get_Click(null, null);
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

    }
}
