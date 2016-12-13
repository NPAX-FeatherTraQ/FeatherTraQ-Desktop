using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ClouReaderDemo.MySingleForm.SettingForm
{
    public partial class SettingGetGPI : BaseOption
    {
        /// <summary>
        /// 上下文窗体
        /// </summary>
        SingleMainForm contextForm = null;
        public SettingGetGPI()
        {
            InitializeComponent();
        }
        public SettingGetGPI(string readerID, SingleMainForm contextForm)
            : this()
        {
            this.ConnID = readerID;
            this.contextForm = contextForm;
        }

        private void SettingGetGPI_Load(object sender, EventArgs e)
        {
            this.Width = 500;
            this.Height = 300;
            Init();
        }

        private void Init()
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

        private void btn_0001_0A_GET_Click(object sender, EventArgs e)
        {
            Init();
        }
    }
}
