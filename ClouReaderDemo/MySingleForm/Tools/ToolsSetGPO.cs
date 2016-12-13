using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ClouReaderDemo.MyFormTemplet;

namespace ClouReaderDemo.MySingleForm.Tools
{
    public partial class ToolsSetGPO : BaseOption
    {
        /// <summary>
        /// 上下文窗体
        /// </summary>
        SingleMainForm contextForm = null;
        public ToolsSetGPO()
        {
            InitializeComponent();
        }
        public ToolsSetGPO(string readerID, SingleMainForm contextForm)
            : this()
        {
            this.ConnID = readerID;
            this.contextForm = contextForm;
        }

        private void ToolsSetGPO_Load(object sender, EventArgs e)
        {
            this.Width = 500;
            this.Height = 300;
            ReadConfig();
        }


        private void SaveConfig()
        {
            try
            {
                foreach (var item in gb_GPO.Controls)
                {
                    if (item is QQTextBoxEx)
                    {
                        QQTextBoxEx tb = (QQTextBoxEx)item;
                        Helper.MyXmlHelper.UpdateInnerText(XMLFIENAME, "Root/" + this.Name, tb.Name, tb.Text.Trim());
                    }
                    else if (item is ComboBox)
                    {
                        ComboBox cb = (ComboBox)item;
                        Helper.MyXmlHelper.UpdateInnerText(XMLFIENAME, "Root/" + this.Name, cb.Name, cb.SelectedIndex.ToString());
                    }
                    else if (item is CheckBox)
                    {
                        CheckBox cb = (CheckBox)item;
                        Helper.MyXmlHelper.UpdateInnerText(XMLFIENAME, "Root/" + this.Name, cb.Name, cb.Checked.ToString());
                    }
                }
            }
            catch (Exception ex) { System.Diagnostics.Debug.WriteLine(ex.Message); }
        }
        private void ReadConfig()
        {
            try
            {
                foreach (var item in gb_GPO.Controls)
                {
                    if (item is QQTextBoxEx)
                    {
                        QQTextBoxEx tb = (QQTextBoxEx)item;
                        tb.Text = Helper.MyXmlHelper.ReadInnerText(XMLFIENAME, "Root/" + this.Name, tb.Name);
                    }
                    else if (item is ComboBox)
                    {
                        ComboBox cb = (ComboBox)item;
                        string value = Helper.MyXmlHelper.ReadInnerText(XMLFIENAME, "Root/" + this.Name, cb.Name);
                        cb.SelectedIndex = Int32.Parse(value);
                    }
                    else if (item is CheckBox)
                    {
                        CheckBox cb = (CheckBox)item;
                        string value = Helper.MyXmlHelper.ReadInnerText(XMLFIENAME, "Root/" + this.Name, cb.Name);
                        cb.Checked = Boolean.Parse(value);
                    }
                }
            }
            catch (Exception ex) { System.Diagnostics.Debug.WriteLine(ex.Message); }
        }

        private void btn_0001_09_Hight_Click(object sender, EventArgs e)
        {
            String param = "";
            String paramStop = "";
            if (chk_GPO_1.Checked)
            {
                param += "1," + cmb_GPO_1.SelectedIndex + "&";
                paramStop += "1,0&";
            }
            if (chk_GPO_2.Checked)
            {
                param += "2," + cmb_GPO_2.SelectedIndex + "&";
                paramStop += "2,0&";
            }
            if (chk_GPO_3.Checked)
            {
                param += "3," + cmb_GPO_3.SelectedIndex + "&";
                paramStop += "3,0&";
            }
            if (chk_GPO_4.Checked)
            {
                param += "4," + cmb_GPO_4.SelectedIndex + "&";
                paramStop += "4,0&";
            }
            param = param.TrimEnd('&');
            paramStop = paramStop.TrimEnd('&');
            contextForm.ReadGPOParam = param;
            contextForm.ReadGPOParam_Stop = paramStop;
            SaveConfig();
            MessageBox.Show("Save Success！");
            this.Close();
            // String rt = ClouReaderAPI.CLReader.PARAM_SET.SetReaderGPOState(ConnID, param);
        }
    }
}
