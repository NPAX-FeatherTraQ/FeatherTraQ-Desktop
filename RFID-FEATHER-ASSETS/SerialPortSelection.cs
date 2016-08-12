using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RFID_FEATHER_ASSETS
{
    public partial class SerialPortSelection : Form
    {
        string roleValue;
        string tokenvalue;
        string language;
        public SerialPortSelection(string tokenvaluesource, string roleSource)
        {
            InitializeComponent();
            getLanguage();
            languageHandler();
            GetSavedSerialPort();
            tokenvalue = tokenvaluesource;
            roleValue = roleSource;
        }
        private void getLanguage()
        {
            try
            {
                //opening the subkey  
                RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\AssetSystemInfo");

                //if it does exist, retrieve the stored values  
                if (key != null)
                {
                    language = (string)(key.GetValue("Language"));
                    key.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void languageHandler()
        {
            if (language == "Japanese")
            {
                ResourceManager rm = new ResourceManager("RFID_FEATHER_ASSETS.Languages.AssetVerification", Assembly.GetExecutingAssembly());
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("ja-JP");
                lblSerialPort.Text = rm.GetString("lblSerialPort");
                lblConnected.Text = rm.GetString("lblConnected");
                btnCancel.Text = rm.GetString("btnCancel");
                this.Text = rm.GetString("title");
            }
        }
        private void GetSavedSerialPort()
        {
            try
            {
                //opening the subkey  
                RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\AssetSystemInfo");

                //if it does exist, retrieve the stored values  
                if (key != null)
                {
                    cmbComPortList.Text = (string)(key.GetValue("DefaultPortName"));
                    key.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSerialPortOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(cmbComPortList.Text.Trim()))
                {
                    //accessing the CurrentUser root element  
                    //and adding "PortName" subkey to the "SOFTWARE" subkey  
                    RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\AssetSystemInfo");

                    //storing the values  
                    key.SetValue("DefaultPortName", cmbComPortList.Text);
                    key.Close();

                    DialogResult = DialogResult.OK;                    
                    //this.Dispose();
                }
                else
                {
                    ResourceManager rm = new ResourceManager("RFID_FEATHER_ASSETS.Languages.AssetVerification", Assembly.GetExecutingAssembly());
                    if (language == "English") MessageBox.Show("Please select Com Port No.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else MessageBox.Show(rm.GetString("comPort"), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbComPortList.Focus();
                    return;
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //ValidateRule();
            this.Dispose();
            DialogResult = DialogResult.Cancel;
        }

        private void ValidateRule()
        {
            //if (roleValue == "ROLE_ADMIN")
            //{
            //    DialogResult = DialogResult.Cancel;
            //    //this.Dispose();//CallMainMenu();
            //}
            //else if (roleValue == "ROLE_GUARD")
            //{
            //    Environment.Exit(0);
            //}
        }
    }
}
