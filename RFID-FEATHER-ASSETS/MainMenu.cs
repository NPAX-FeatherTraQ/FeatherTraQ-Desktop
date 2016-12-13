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
        bool isTabExist = false;

        public MainMenu(string tokenvaluesource, /*string portnamesource,*/ string roleSource)
        {
            InitializeComponent();
            //cmbComPort.Text = portnamesource;
            tokenvalue = tokenvaluesource;
            roleValue = roleSource;
            getSystemInfo();
            //company.Text = companyName;
            //locationTxt.Text = location;
            //languageHandler();
            //tabControl1.SelectedIndex = 1;
            picboxLogo.BringToFront(); 
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
                    language = "English";//(string)(key.GetValue("Language"));
                    //companyName = (string)(key.GetValue("companyName"));
                    //location = (string)(key.GetValue("readerInfo"));
                    displaySystemInfo = "User ID: " + (string)(key.GetValue("UserName")).ToString().ToUpper() + " | Company: " + (string)(key.GetValue("companyName").ToString().ToUpper()) + " | PC Location: " + (string)(key.GetValue("readerInfo")).ToString().ToUpper(); //+ " | " + DateTime.Now.ToString("MM/dd/yyyy h:mm:ss tt");
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
            lblSystemInfo.Text = displaySystemInfo + " | Date: " + DateTime.Now.ToString("MM/dd/yyyy h:mm:ss tt");
        }

        private void registerOwnerToolStripMenuItem_Click(object sender, EventArgs e)
        {
           try
           { 
                ////this.IsMdiContainer = true;
                //RegisterUser registerUser = new RegisterUser(tokenvalue);
                //registerUser.MdiParent = this;
                //registerUser.FormBorderStyle = FormBorderStyle.None;
                ////registerUser.WindowState = FormWindowState.Maximized;
                //registerUser.Dock = DockStyle.Fill; 
                //registerUser.Show();

               checkIfTabExist(registerOwnerToolStripMenuItem.Text);

               if (!isTabExist)
               {
                   if (AssetRegistration.IsCameraConnected)
                   {
                       AssetRegistration.cam.Stop();
                       //AssetRegistration.cam = null;
                       //AssetRegistration.reader.CloseCom();
                   }

                   RegisterUser registerUser = new RegisterUser(tokenvalue);
                   registerUser.TopLevel = false;
                   TabPage tp = new TabPage(registerOwnerToolStripMenuItem.Text);
                   tabCtrlMainMenu.TabPages.Add(tp);
                   tabCtrlMainMenu.SelectedTab = tp;
                   tp.ImageIndex = 0;
                   registerUser.Parent = tp;
                   registerUser.FormBorderStyle = FormBorderStyle.None;
                   registerUser.Dock = DockStyle.Fill;

                   if (RegisterUser.IsCameraConnected)
                       RegisterUser.cam.Start();

                   registerUser.Show();

                   if (RegisterUser.portname == string.Empty)
                   {
                       serialPortToolStripMenuItem.PerformClick();
                   }
               }
               
           }
           catch (Exception ex)
           {
               MessageBox.Show(ex.Message);
           }
        }

        private void checkIfTabExist(string tabText)
        {
            picboxLogo.SendToBack();

            foreach (TabPage tab in tabCtrlMainMenu.TabPages)
            {
                if (tabText.Equals(tab.Text))
                {
                    tabCtrlMainMenu.SelectedTab = tab;
                    isTabExist = true;
                    break;
                }
                else isTabExist = false;
            }
        }

        private void registerAssetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            { 
                ////this.IsMdiContainer = true;
                //AssetRegistration registerAsset = new AssetRegistration();
                //registerAsset.MdiParent = this;
                //registerAsset.FormBorderStyle = FormBorderStyle.None;
                //registerAsset.Dock = DockStyle.Fill;
                //registerAsset.Show();

                checkIfTabExist(registerAssetToolStripMenuItem.Text);

                if (!isTabExist)
                {
                    if (RegisterUser.IsCameraConnected)
                    {
                        RegisterUser.cam.Stop();
                        //RegisterUser.cam = null;
                        //RegisterUser.reader.CloseCom();
                    }

                    AssetRegistration registerAsset = new AssetRegistration();
                    registerAsset.TopLevel = false;
                    TabPage tp = new TabPage(registerAssetToolStripMenuItem.Text);
                    tabCtrlMainMenu.TabPages.Add(tp);
                    tabCtrlMainMenu.SelectedTab = tp;
                    tp.ImageIndex = 0;
                    registerAsset.Parent = tp;
                    registerAsset.FormBorderStyle = FormBorderStyle.None;
                    registerAsset.Dock = DockStyle.Fill;

                    if (AssetRegistration.IsCameraConnected)
                        AssetRegistration.cam.Start();

                    registerAsset.Show();

                    if (AssetRegistration.portname == string.Empty)
                    {
                        serialPortToolStripMenuItem.PerformClick();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void verifyAssetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            { 
                //Verification verifyAsset = new Verification();
                //verifyAsset.TopLevel = false;
                //TabPage tp = new TabPage(verifyAssetToolStripMenuItem.Text);
                //tabCtrlMainMenu.TabPages.Add(tp);
                //tabCtrlMainMenu.SelectedTab = tp;
                //tp.ImageIndex = 0;
                //verifyAsset.Parent = tp;
                //verifyAsset.FormBorderStyle = FormBorderStyle.None;
                //verifyAsset.Dock = DockStyle.Fill;
                //verifyAsset.Show();

                logoutCloseCameraReader();

                //this.Hide();
                Verification verifyAsset = new Verification();
                verifyAsset.ShowDialog();//.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void logoutCloseCameraReader()
        {
            if (RegisterUser.regOwnerCon) RegisterUser.reader.CloseCom();
            if (RegisterUser.cam != null) RegisterUser.cam.Stop();

            if (AssetRegistration.regAssetCon) AssetRegistration.reader.CloseCom();
            if (AssetRegistration.cam != null) AssetRegistration.cam.Stop();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try 
            {
                if (tabCtrlMainMenu.TabCount == 0 || (tabCtrlMainMenu.TabCount != 0 && MessageBox.Show("Are you sure you want logout?" + "\n" + "There are active form(s) open.", "Confirm...", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes))
                {
                    logoutCloseCameraReader();

                    this.Hide();
                    LoginActivity LoginForm = new LoginActivity();
                    LoginForm.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabCtrlMainMenu.TabCount == 0 || (tabCtrlMainMenu.TabCount != 0 && MessageBox.Show("Are you sure you want exit the application?" + "\n" + "There are active form(s) open.", "Confirm...", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes))
            {
                Environment.Exit(0);
            }
        }

        private void transactionHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            { 
                //TransactionHistory transactionHistory = new TransactionHistory();
                ////transactionHistory.MdiParent = this;
                //transactionHistory.FormBorderStyle = FormBorderStyle.None;
                //transactionHistory.Dock = DockStyle.Fill;
                //transactionHistory.Show();

                checkIfTabExist(transactionHistoryToolStripMenuItem.Text);

                if (!isTabExist)
                {
                    TransactionHistory transactionHistory = new TransactionHistory();
                    transactionHistory.TopLevel = false;
                    TabPage tp = new TabPage(transactionHistoryToolStripMenuItem.Text);
                    tabCtrlMainMenu.TabPages.Add(tp);
                    tabCtrlMainMenu.SelectedTab = tp;
                    tp.ImageIndex = 0;
                    transactionHistory.Parent = tp;
                    transactionHistory.FormBorderStyle = FormBorderStyle.None;
                    transactionHistory.Dock = DockStyle.Fill;
                    transactionHistory.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            try
            { 
                //This code will render a "x" mark at the end of the Tab caption. 
                e.Graphics.DrawString("x", e.Font, Brushes.Black, e.Bounds.Left, e.Bounds.Top + 10);
                e.Graphics.DrawString(this.tabCtrlMainMenu.TabPages[e.Index].Text, e.Font, Brushes.Black, e.Bounds.Left + 10, e.Bounds.Top + 5);
                e.DrawFocusRectangle();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void closeCameraAndReader()
        {
            if (tabCtrlMainMenu.SelectedTab != null)
            {
                switch (tabCtrlMainMenu.SelectedTab.Text.ToLower())
                {
                    case "register owner":
                        if (RegisterUser.cam != null) RegisterUser.cam.Stop();
                            RegisterUser.reader.CloseCom();
                        break;

                    case "register asset":
                        if (AssetRegistration.cam != null) AssetRegistration.cam.Stop();
                            AssetRegistration.reader.CloseCom();
                        break;

                    //case "verify asset":
                    //    Verification.reader.CloseCom();
                    //    break;
                }  
            }
        }

        private void tabCtrlMainMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            { 
                if (tabCtrlMainMenu.SelectedTab != null)
                {
                    switch (tabCtrlMainMenu.SelectedTab.Text.ToLower())
                    {
                        case "register owner":
                            //if (AssetRegistration.cam != null) AssetRegistration.cam.Stop();
                            //    AssetRegistration.reader.CloseCom();
                            if (AssetRegistration.regAssetCon) AssetRegistration.reader.CloseCom();
                            if (AssetRegistration.cam != null) AssetRegistration.cam.Stop();

                            if (RegisterUser.IsCameraConnected)
                                RegisterUser.cam.Start();
                            break;

                        case "register asset":
                            //if (RegisterUser.cam != null) RegisterUser.cam.Stop();
                            //    RegisterUser.reader.CloseCom();
                            if (RegisterUser.regOwnerCon) RegisterUser.reader.CloseCom();
                            if (RegisterUser.cam != null) RegisterUser.cam.Stop();

                            if (AssetRegistration.IsCameraConnected)
                                AssetRegistration.cam.Start();
                            break;

                        //case "verify asset":
                        //    if (RegisterUser.cam != null) RegisterUser.cam.Stop();
                        //    RegisterUser.reader.CloseCom();

                        //    if (AssetRegistration.cam != null) AssetRegistration.cam.Stop();
                        //    AssetRegistration.reader.CloseCom();
                        //    break;
                    }  
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void serialPortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SerialPortSelection serialPort = new SerialPortSelection(tokenvalue, roleValue);
            serialPort.ShowDialog();
            
            //SerialPortSelection PortSelectionForm = new SerialPortSelection(tokenvalue, roleValue);

            //// Show PortSelectionForm as a modal dialog and determine if DialogResult = OK.
            //if (PortSelectionForm.ShowDialog(this) != DialogResult.OK)
            //{
            //    //if (tabCtrlMainMenu.TabCount != 0)
            //    //{
            //    //    closeCameraAndReader();
            //    //    this.tabCtrlMainMenu.TabPages.Remove(this.tabCtrlMainMenu.SelectedTab);
            //    //}
            //}
        }

        private void trackAssetsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            { 
                logoutCloseCameraReader();

                //this.Hide();
                Tracking trackingAsset = new Tracking();
                trackingAsset.ShowDialog();//.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tabCtrlMainMenu_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                Rectangle r = tabCtrlMainMenu.GetTabRect(this.tabCtrlMainMenu.SelectedIndex);
                Rectangle closeButton = new Rectangle(r.Left + 15, r.Top + 7, 9, 7);
                if (closeButton.Contains(e.Location))
                {
                    if (MessageBox.Show("Close " + tabCtrlMainMenu.SelectedTab.Text + "?", "Confirm...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        logoutCloseCameraReader();//closeCameraAndReader();
                        this.tabCtrlMainMenu.TabPages.Remove(this.tabCtrlMainMenu.SelectedTab);
                        if (tabCtrlMainMenu.TabCount == 0)
                        {
                            picboxLogo.BringToFront();
                            isTabExist = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            };
        }
    }
}
