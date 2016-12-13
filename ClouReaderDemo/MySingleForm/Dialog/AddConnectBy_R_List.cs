using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ClouReaderDemo.MyForm.Dialog;
using System.IO.Ports;
using System.Text.RegularExpressions;
using ClouReaderDemo.MyFormTemplet;

namespace ClouReaderDemo.MySingleForm.TestForm.Dialog
{
    public partial class AddConnectBy_R_List : BaseDialog
    {
        Performance_R_List contextForm = null;

        public AddConnectBy_R_List()
        {
            InitializeComponent();
        }

        public AddConnectBy_R_List(Performance_R_List contextForm)
            : this()
        {
            this.contextForm = contextForm;
            this.Width = 400;
            this.Height = 200;
        }


        public void InitCom()
        {
            //RegistryKey keyCom = Registry.LocalMachine.OpenSubKey("Hardware\\DeviceMap\\SerialComm");
            //if (keyCom != null)
            //{
            //    string[] sSubKeys = keyCom.GetValueNames();
            //    this.cb_ComNum.Items.Clear();
            //    foreach (string sName in sSubKeys)
            //    {
            //        string sValue = (string)keyCom.GetValue(sName);
            //        this.cb_ComNum.Items.Add(sValue);
            //    }
            //}
            try
            {
                this.cb_ComNum.Items.Clear();
                foreach (string vPortName in SerialPort.GetPortNames())
                {
                    String portName = Regex.Match(vPortName, @"COM[0-9]+").Value;
                    this.cb_ComNum.Items.Add(portName);
                }
            }
            catch { }
        }

        private void cb_ConnectType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_ConnectType.SelectedIndex == 0)
            {
                tb_ConnParam.Text = Helper.MyXmlHelper.ReadInnerText(XMLFIENAME, "Root/AddConnect", "SerialConnect");
                if (String.IsNullOrEmpty(tb_ConnParam.Text.Trim()))
                {
                    tb_ConnParam.Text = "COM1:115200";
                }
                tb_485Address.Visible = false;
                cb_BPS.Visible = true;
                cb_ComNum.Visible = true;
            }
            else if (cb_ConnectType.SelectedIndex == 1)
            {
                tb_ConnParam.Text = Helper.MyXmlHelper.ReadInnerText(XMLFIENAME, "Root/AddConnect", "TcpConnect");
                if (String.IsNullOrEmpty(tb_ConnParam.Text.Trim()))
                {
                    tb_ConnParam.Text = "192.168.1.116:9090";
                }
                tb_485Address.Visible = false;
                cb_BPS.Visible = false;
                cb_ComNum.Visible = false;
            }
            else if (cb_ConnectType.SelectedIndex == 2)
            {
                tb_ConnParam.Text = Helper.MyXmlHelper.ReadInnerText(XMLFIENAME, "Root/AddConnect", "_485Connect");
                if (String.IsNullOrEmpty(tb_ConnParam.Text.Trim()))
                {
                    tb_ConnParam.Text = "1:COM1:115200";
                }
                tb_485Address.Visible = true;
                cb_BPS.Visible = true;
                cb_ComNum.Visible = true;
            }
        }

        private void cb_ComNum_DropDown(object sender, EventArgs e)
        {
            InitCom();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (cb_ConnectType.SelectedIndex == 0)
            {
                if (cb_ComNum.SelectedIndex >= 0 && cb_BPS.SelectedIndex >= 0)
                {
                    this.tb_ConnParam.Text = cb_ComNum.Text + ":" + cb_BPS.Text;
                }
                contextForm._AddConnectType = 0;
            }
            else if (cb_ConnectType.SelectedIndex == 1)
            {
                // 直接输出值
                contextForm._AddConnectType = 1;
            }
            else if (cb_ConnectType.SelectedIndex == 2)
            {
                if (cb_ComNum.SelectedIndex >= 0 && cb_BPS.SelectedIndex >= 0 && !String.IsNullOrEmpty(tb_485Address.Text))
                {
                    this.tb_ConnParam.Text = tb_485Address.Text.Trim() + ":" + cb_ComNum.Text + ":" + cb_BPS.Text;
                }
                contextForm._AddConnectType = 2;
            }
            contextForm._AddConnectID = tb_ConnParam.Text.Trim();
            contextForm._AddANTParam = GetReadParam();
            this.DialogResult = DialogResult.OK;
        }

        
        public String GetReadParam()
        {
            String rt = "";
            Int32 antValue = 0;
            foreach (var item in this.Controls)
            {
                QQCheckBox cb = item as QQCheckBox;
                if (cb != null)
                {
                    if (cb.Name.StartsWith("cb_ANT") && cb.Checked)
                    {
                        antValue += Int32.Parse(cb.Tag.ToString());
                    }
                }
            }
            rt += antValue;

            return rt;
        }
    }
}
