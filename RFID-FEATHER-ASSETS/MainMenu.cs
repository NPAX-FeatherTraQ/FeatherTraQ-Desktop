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
            RegisterUser.cam.Start();
            registerUser.Show();
            //if (!registerUser.IsCameraConnected)
            //registerUser.InitializeCamera();
            if (RegisterUser.portname == string.Empty)
            {
                serialPortToolStripMenuItem.PerformClick();
            }
        }

        private void registerAssetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ////this.IsMdiContainer = true;
            //AssetRegistration registerAsset = new AssetRegistration();
            //registerAsset.MdiParent = this;
            //registerAsset.FormBorderStyle = FormBorderStyle.None;
            //registerAsset.Dock = DockStyle.Fill;
            //registerAsset.Show();

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
            AssetRegistration.cam.Start();
            registerAsset.Show();
            //if (!registerAsset.IsCameraConnected)
            //registerAsset.InitializeCamera();
            if (AssetRegistration.portname == string.Empty)
            {
                serialPortToolStripMenuItem.PerformClick();
            }
        }

        private void verifyAssetToolStripMenuItem_Click(object sender, EventArgs e)
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

            if (RegisterUser.regOwnerCon) RegisterUser.reader.CloseCom();
            if (RegisterUser.cam != null) RegisterUser.cam.Stop();

            if (AssetRegistration.regAssetCon) AssetRegistration.reader.CloseCom();
            if (AssetRegistration.cam != null) AssetRegistration.cam.Stop();

            this.Hide();
            Verification verifyAsset = new Verification();
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
            tabCtrlMainMenu.TabPages.Add(tp);
            tabCtrlMainMenu.SelectedTab = tp;
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
            e.Graphics.DrawString(this.tabCtrlMainMenu.TabPages[e.Index].Text, e.Font, Brushes.Black, e.Bounds.Left + 10, e.Bounds.Top + 5);
            e.DrawFocusRectangle();
        }

        private void tabControl1_MouseDown(object sender, MouseEventArgs e)
        {
            Rectangle r = tabCtrlMainMenu.GetTabRect(this.tabCtrlMainMenu.SelectedIndex);
            Rectangle closeButton = new Rectangle(r.Left + 15, r.Top + 7, 9, 7);
            if (closeButton.Contains(e.Location))
            {
                if (MessageBox.Show("Close " + tabCtrlMainMenu.SelectedTab.Text + "?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    closeCameraAndReader();
                    this.tabCtrlMainMenu.TabPages.Remove(this.tabCtrlMainMenu.SelectedTab);
                }
            }
            //RegisterUser _registerUser = new RegisterUser(tokenvalue);
            //_registerUser.InitializeCamera();
        }

        private void closeCameraAndReader()
        {
            if (tabCtrlMainMenu.SelectedTab != null)
            {
                //if (tabCtrlMainMenu.SelectedTab.Text.ToLower() == "register owner" && AssetRegistration.IsCameraConnected)
                //{
                //    //if (AssetRegistration.cam != null) AssetRegistration.cam.Stop();
                //    //AssetRegistration.reader.CloseCom();

                //    ////RegisterUser.cam.Start();
                //    if (RegisterUser.cam != null) RegisterUser.cam.Stop();
                //    RegisterUser.reader.CloseCom();
                //}

                //if (tabCtrlMainMenu.SelectedTab.Text.ToLower() == "register asset" && RegisterUser.IsCameraConnected)
                //{
                //    //if (RegisterUser.cam != null) RegisterUser.cam.Stop();
                //    //RegisterUser.reader.CloseCom();

                //    ////AssetRegistration.cam.Start();
                //    if (AssetRegistration.cam != null) AssetRegistration.cam.Stop();
                //    AssetRegistration.reader.CloseCom();

                //}
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
            if (tabCtrlMainMenu.SelectedTab != null)
            {
                //if (tabCtrlMainMenu.SelectedTab.Text.ToLower() == "register owner" && AssetRegistration.IsCameraConnected)
                //{
                //    if (AssetRegistration.cam != null) AssetRegistration.cam.Stop();
                //    AssetRegistration.reader.CloseCom();

                //    //if (RegisterUser.IsCameraConnected)
                //    //    RegisterUser.cam.Start();

                //    //RegisterUser.reader = new Reader.ReaderMethod();
                //    //RegisterUser registerUser = new RegisterUser(tokenvalue);
                //    if (RegisterUser.IsCameraConnected)
                //        RegisterUser.cam.Start();
                //    //registerUser.InitializeCamera();
                //    //registerUser.ReaderMethodProc();
                //    //RegisterUser f2 = new RegisterUser(tokenvalue);
                //    //f2.ReaderMethodProc();
                //    return;
                //}

                //if (tabCtrlMainMenu.SelectedTab.Text.ToLower() == "register asset" && RegisterUser.IsCameraConnected)
                //{
                //    if (RegisterUser.cam != null) RegisterUser.cam.Stop();
                //    RegisterUser.reader.CloseCom();

                //    //if (AssetRegistration.IsCameraConnected)
                //    //    AssetRegistration.cam.Start();

                //    //AssetRegistration.reader = new Reader.ReaderMethod();
                //    //AssetRegistration registerAsset = new AssetRegistration();
                //    if (AssetRegistration.IsCameraConnected)
                //        AssetRegistration.cam.Start();
                //    //registerAsset.InitializeCamera();
                //    //registerAsset.ReaderMethodProc();
                //    return;
                //}

                switch (tabCtrlMainMenu.SelectedTab.Text.ToLower())
                {
                    case "register owner":
                        if (AssetRegistration.cam != null) AssetRegistration.cam.Stop();
                            AssetRegistration.reader.CloseCom();

                        if (RegisterUser.IsCameraConnected)
                            RegisterUser.cam.Start();
                        break;

                    case "register asset":
                        if (RegisterUser.cam != null) RegisterUser.cam.Stop();
                            RegisterUser.reader.CloseCom();

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
    }
}
