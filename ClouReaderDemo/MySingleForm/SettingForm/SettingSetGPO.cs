using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ClouReaderDemo.MySingleForm.SettingForm
{
    public partial class SettingSetGPO : BaseOption
    {
        /// <summary>
        /// 上下文窗体
        /// </summary>
        SingleMainForm contextForm = null;
        public SettingSetGPO()
        {
            InitializeComponent();
        }

        public SettingSetGPO(string readerID, SingleMainForm contextForm)
            : this()
        {
            this.ConnID = readerID;
            this.contextForm = contextForm;
        }

        private void SettingSetGPO_Load(object sender, EventArgs e)
        {
            this.Width = 500;
            this.Height = 300;
            Init();
        }

        private void Init()
        {
            
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
            String rt = ClouReaderAPI.CLReader.PARAM_SET.SetReaderGPOState(ConnID, param);
            ShowMessage(rt);
        }

        private void gb_GPO_Enter(object sender, EventArgs e)
        {

        }
    }
}
