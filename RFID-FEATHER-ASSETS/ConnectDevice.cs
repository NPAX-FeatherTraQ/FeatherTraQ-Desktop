using ClouReaderAPI;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RFID_FEATHER_ASSETS
{
    public partial class ConnectDevice : Form
    {
        Verification contextForm = null;
        //string connectionType;
        //string connectionParam;
        //string connectionParam2;

        public ConnectDevice()
        {
            InitializeComponent();
            this.DialogResult = DialogResult.No;
            //GetAssetSystemInfo(); 
        }

        public ConnectDevice(Verification contextForm)
            : this()
        {
            this.contextForm = contextForm;
            cb_ConnectType.SelectedIndex = 0;
            //this.Width = 450;
            //this.Height = 200;
            cb_BPS.SelectedIndex = 2;
            cb_BPS.Enabled = false;
        }
        public ConnectDevice(Verification contextForm, Int32 connType): this(contextForm)
        {
            InitCom();
            if (connType == 0)
            {
                cb_ConnectType.SelectedIndex = 1;
                cb_ConnectType.SelectedIndex = 0;
            }
            else if (connType == 1)
                cb_ConnectType.SelectedIndex = 1;
            else if (connType == 2)
                cb_ConnectType.SelectedIndex = 2;
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

        private void btn_OK_Click(object sender, EventArgs e)
        {
            bool isConnect = false;                                 // 连接是否成功
            if (cb_ConnectType.SelectedIndex == 0)
            {
                if (cb_ComNum.SelectedIndex >= 0 && cb_BPS.SelectedIndex >= 0)
                {
                    this.tb_ConnParam.Text = cb_ComNum.Text + ":" + cb_BPS.Text;
                    isConnect = CLReader.CreateSerialConn(this.tb_ConnParam.Text, contextForm);
                }
                // Helper.MyXmlHelper.UpdateInnerText(XMLFIENAME, "Root/ConnectDevice", "SerialConnect", tb_ConnParam.Text.Trim());
            }
            else if (cb_ConnectType.SelectedIndex == 1)
            {
                isConnect = CLReader.CreateTcpConn(tb_ConnParam.Text.Trim(), contextForm);
                ////Helper.MyXmlHelper.UpdateInnerText(XMLFIENAME, "Root/ConnectDevice", "TcpConnect", tb_ConnParam.Text.Trim());
            }
            else if (cb_ConnectType.SelectedIndex == 2) 
            {
                if (cb_ComNum.SelectedIndex >= 0 && cb_BPS.SelectedIndex >= 0 && !String.IsNullOrEmpty(tb_485Address.Text))
                {
                    this.tb_ConnParam.Text = tb_485Address.Text.Trim() + ":" + cb_ComNum.Text + ":" + cb_BPS.Text;
                    isConnect = CLReader.Create485Conn(this.tb_ConnParam.Text, contextForm);
                }
                // Helper.MyXmlHelper.UpdateInnerText(XMLFIENAME, "Root/ConnectDevice", "_485Connect", tb_ConnParam.Text.Trim());
            }
            if (isConnect)                                          // 如果连接成功
            {
                ////if (contextForm.IsMultiConnect == false)            // 单读写器模式
                ////{
                ////    contextForm.CloseNowConnect();
                ////}
                ////else
                ////{
                    if (!String.IsNullOrEmpty(contextForm.ConnID))
                    {
                        ClouReaderAPI.CLReader.DIC_CONNECT[contextForm.ConnID].log = null;
                    }
                ////}
                contextForm.ConnID = tb_ConnParam.Text.Trim();
                this.DialogResult = DialogResult.OK;

                //if (this.DialogResult != DialogResult.OK)
                //{
                    ////Save to Registry for the connection type  
                    //RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\AssetSystemInfo");

                    ////storing the values  
                    //key.SetValue("ConnectionType", cb_ConnectType.Text);
                    //key.SetValue("ConnectionParam", cb_ComNum.Text);
                    //key.SetValue("ConnectionParam2", cb_BPS.Text);
                    //key.Close();
                //}
            }
            else 
            {
                this.DialogResult = DialogResult.No;
            }
        }

        private void cb_ConnectType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_ConnectType.SelectedIndex == 0)
            {
                ////tb_ConnParam.Text = Helper.MyXmlHelper.ReadInnerText(XMLFIENAME, "Root/ConnectDevice", "SerialConnect");
                //if (String.IsNullOrEmpty(tb_ConnParam.Text.Trim()))
                //{
                    tb_ConnParam.Text = "COM1:115200";
                //}
                tb_485Address.Visible = false;
                cb_BPS.Visible = true;
                cb_ComNum.Visible = true;
            }
            else if (cb_ConnectType.SelectedIndex == 1)
            {
                ////tb_ConnParam.Text = Helper.MyXmlHelper.ReadInnerText(XMLFIENAME, "Root/ConnectDevice", "TcpConnect");
                //if (String.IsNullOrEmpty(tb_ConnParam.Text.Trim()))
                //{
                    tb_ConnParam.Text = "192.168.1.116:9090";
                //}
                tb_485Address.Visible = false;
                cb_BPS.Visible = false;
                cb_ComNum.Visible = false;
            }
            else if (cb_ConnectType.SelectedIndex == 2) 
            {
                ////tb_ConnParam.Text = Helper.MyXmlHelper.ReadInnerText(XMLFIENAME, "Root/ConnectDevice", "_485Connect");
                //if (String.IsNullOrEmpty(tb_ConnParam.Text.Trim()))
                //{
                    tb_ConnParam.Text = "1:COM1:115200";
                //}
                tb_485Address.Visible = true;
                cb_BPS.Visible = true;
                cb_ComNum.Visible = true;
            }
        }

        private void cb_ComNum_DropDown(object sender, EventArgs e)
        {
            InitCom();
        }
    }
}
