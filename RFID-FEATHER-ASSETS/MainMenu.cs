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
using System.Windows.Forms;

namespace RFID_FEATHER_ASSETS
{
    public partial class MainMenu : Form
    {
        string tokenvalue;
        string roleValue;
        string language;
        public MainMenu(string tokenvaluesource, /*string portnamesource,*/ string roleSource)
        {
            InitializeComponent();
            //cmbComPort.Text = portnamesource;
            tokenvalue = tokenvaluesource;
            roleValue = roleSource;
            getLanguage();
            languageHandler();
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
                //Console.WriteLine(Properties.mainmenu.btnScan);
                ResourceManager rm = new ResourceManager("RFID_FEATHER_ASSETS.Languages.mainmenu", Assembly.GetExecutingAssembly());
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("ja-JP");
                btnRegisterUser.Text = rm.GetString("btnRegisterUser");
                btnRegisterAsset.Text = rm.GetString("btnRegisterAsset");
                btnScan.Text = rm.GetString("btnScan");
                btnTransactionHistory.Text = rm.GetString("btnTransactionHistory");
                btnLogout.Text = rm.GetString("btnLogout");
                this.Text = rm.GetString("MainMenu");
            }
        }
        private void btnScan_Click(object sender, EventArgs e)
        {
                this.Hide();
                Verification m = new Verification();//tokenvalue, roleValue);
                m.Show();
        }

        private void btnRegisterAsset_Click(object sender, EventArgs e)
        {
                this.Hide();
                AssetRegistration registerAsset = new AssetRegistration();
                registerAsset.Show();
        }

        private void btnRegisterUser_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegisterUser registerUser = new RegisterUser(tokenvalue);
            registerUser.Show();
        }

        private void MainMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnMyAssets_Click(object sender, EventArgs e)
        {
            this.Hide();
            Assets assets = new Assets(/*tokenvalue, roleValue*/);
            assets.Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginActivity LoginForm = new LoginActivity();
            LoginForm.Show();
        }

        private void btnTransactionHistory_Click(object sender, EventArgs e)
        {
            this.Hide();
            TransactionHistory transactionHistory = new TransactionHistory();
            transactionHistory.Show();
        }
    }
}
