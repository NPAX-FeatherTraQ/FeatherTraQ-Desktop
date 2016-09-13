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
        string companyName;
        string location;
        string displaySystemInfo;
        private RegisterUser _registerUser;  

        public MainMenu(string tokenvaluesource, /*string portnamesource,*/ string roleSource)
        {
            InitializeComponent();
            //cmbComPort.Text = portnamesource;
            tokenvalue = tokenvaluesource;
            roleValue = roleSource;
            getSystemInfo();
            //company.Text = companyName;
            //locationTxt.Text = location;
            languageHandler();
        }

        private void getSystemInfo()
        {
            try
            {
                //opening the subkey  
                RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\AssetSystemInfo");

                //if it does exist, retrieve the stored values  
                if (key != null)
                {
                    language = (string)(key.GetValue("Language"));
                    //companyName = (string)(key.GetValue("companyName"));
                    //location = (string)(key.GetValue("readerInfo"));
                    displaySystemInfo = "User ID: " + (string)(key.GetValue("UserName")).ToString().ToUpper() + " | Company: " + (string)(key.GetValue("companyName").ToString().ToUpper()) + " | Location: " + (string)(key.GetValue("readerInfo")).ToString().ToUpper(); //+ " | " + DateTime.Now.ToString("MM/dd/yyyy h:mm:ss tt");
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

        private void CurrentDateTimer_Tick(object sender, EventArgs e)
        {
            lblSystemInfo.Text = displaySystemInfo + " | Date: " + DateTime.Now.ToString("MM/dd/yyyy h:mm:ss tt"); ;
        }

        private void registerOwnerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ////this.IsMdiContainer = true;
            //RegisterUser registerUser = new RegisterUser(tokenvalue);
            //registerUser.MdiParent = this;
            //registerUser.FormBorderStyle = FormBorderStyle.None;
            ////registerUser.WindowState = FormWindowState.Maximized;
            //registerUser.Dock = DockStyle.Fill; 
            //registerUser.Show();

            RegisterUser registerUser = new RegisterUser(tokenvalue);
            registerUser.TopLevel = false;
            TabPage tp = new TabPage(registerOwnerToolStripMenuItem.Text);
            tabControl1.TabPages.Add(tp);
            tabControl1.SelectedTab = tp;
            tp.ImageIndex = 0;
            registerUser.Parent = tp;
            registerUser.FormBorderStyle = FormBorderStyle.None;
            registerUser.Dock = DockStyle.Fill;
            registerUser.Show();
        }

        private void registerAssetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ////this.IsMdiContainer = true;
            //AssetRegistration registerAsset = new AssetRegistration();
            //registerAsset.MdiParent = this;
            //registerAsset.FormBorderStyle = FormBorderStyle.None;
            //registerAsset.Dock = DockStyle.Fill;
            //registerAsset.Show();

            AssetRegistration registerAsset = new AssetRegistration();
            registerAsset.TopLevel = false;
            TabPage tp = new TabPage(registerAssetToolStripMenuItem.Text);
            tabControl1.TabPages.Add(tp);
            tabControl1.SelectedTab = tp;
            tp.ImageIndex = 0;
            registerAsset.Parent = tp;
            registerAsset.FormBorderStyle = FormBorderStyle.None;
            registerAsset.Dock = DockStyle.Fill;
            registerAsset.Show();
        }

        private void verifyAssetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ////this.IsMdiContainer = true;
            //Verification verifyAsset = new Verification();
            //verifyAsset.MdiParent = this;
            //verifyAsset.FormBorderStyle = FormBorderStyle.None;
            //verifyAsset.Dock = DockStyle.Fill;
            //verifyAsset.Show();

            Verification verifyAsset = new Verification();
            verifyAsset.TopLevel = false;
            TabPage tp = new TabPage(verifyAssetToolStripMenuItem.Text);
            tabControl1.TabPages.Add(tp);
            tabControl1.SelectedTab = tp;
            tp.ImageIndex = 0;
            verifyAsset.Parent = tp;
            verifyAsset.FormBorderStyle = FormBorderStyle.None;
            verifyAsset.Dock = DockStyle.Fill;
            verifyAsset.Show();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginActivity LoginForm = new LoginActivity();
            LoginForm.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void transactionHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TransactionHistory transactionHistory = new TransactionHistory();
            ////transactionHistory.MdiParent = this;
            //transactionHistory.FormBorderStyle = FormBorderStyle.None;
            //transactionHistory.Dock = DockStyle.Fill;
            //transactionHistory.Show();

            TransactionHistory transactionHistory = new TransactionHistory();
            transactionHistory.TopLevel = false;
            TabPage tp = new TabPage(transactionHistoryToolStripMenuItem.Text);
            tabControl1.TabPages.Add(tp);
            tabControl1.SelectedTab = tp;
            tp.ImageIndex = 0;
            transactionHistory.Parent = tp;
            transactionHistory.FormBorderStyle = FormBorderStyle.None;
            transactionHistory.Dock = DockStyle.Fill;
            transactionHistory.Show();
        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            //This code will render a "x" mark at the end of the Tab caption. 
            e.Graphics.DrawString("x", e.Font, Brushes.Black, e.Bounds.Left, e.Bounds.Top + 10);
            e.Graphics.DrawString(this.tabControl1.TabPages[e.Index].Text, e.Font, Brushes.Black, e.Bounds.Left + 10, e.Bounds.Top + 5);
            e.DrawFocusRectangle();
        }

        private void tabControl1_MouseDown(object sender, MouseEventArgs e)
        {
            Rectangle r = tabControl1.GetTabRect(this.tabControl1.SelectedIndex);
            Rectangle closeButton = new Rectangle(r.Left + 15, r.Top + 7, 9, 7);
            if (closeButton.Contains(e.Location))
            {
                if (MessageBox.Show("Close " + tabControl1.SelectedTab.Text + "?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.tabControl1.TabPages.Remove(this.tabControl1.SelectedTab);
                }
            }
            _registerUser.StartCamera();  
        }
    }
}
