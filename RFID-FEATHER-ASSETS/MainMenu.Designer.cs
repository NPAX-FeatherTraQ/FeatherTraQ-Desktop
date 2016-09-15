namespace RFID_FEATHER_ASSETS
{
    partial class MainMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.CurrentDateTimer = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registrationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registerOwnerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registerAssetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verificationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verifyAssetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transactionHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnRegisterAsset = new System.Windows.Forms.Button();
            this.btnRegisterUser = new System.Windows.Forms.Button();
            this.btnScan = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblSystemInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnTransactionHistory = new System.Windows.Forms.Button();
            this.tabCtrlMainMenu = new System.Windows.Forms.TabControl();
            this.imagebtnClose = new System.Windows.Forms.ImageList(this.components);
            this.maintenanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serialPortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CurrentDateTimer
            // 
            this.CurrentDateTimer.Enabled = true;
            this.CurrentDateTimer.Tick += new System.EventHandler(this.CurrentDateTimer_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.registrationToolStripMenuItem,
            this.verificationToolStripMenuItem,
            this.reportsToolStripMenuItem,
            this.maintenanceToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(393, 24);
            this.menuStrip1.TabIndex = 31;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logOutToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // logOutToolStripMenuItem
            // 
            this.logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            this.logOutToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.logOutToolStripMenuItem.Text = "Log Out";
            this.logOutToolStripMenuItem.Click += new System.EventHandler(this.logOutToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(114, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // registrationToolStripMenuItem
            // 
            this.registrationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registerOwnerToolStripMenuItem,
            this.registerAssetToolStripMenuItem});
            this.registrationToolStripMenuItem.Name = "registrationToolStripMenuItem";
            this.registrationToolStripMenuItem.Size = new System.Drawing.Size(82, 20);
            this.registrationToolStripMenuItem.Text = "Registration";
            // 
            // registerOwnerToolStripMenuItem
            // 
            this.registerOwnerToolStripMenuItem.Name = "registerOwnerToolStripMenuItem";
            this.registerOwnerToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.registerOwnerToolStripMenuItem.Text = "Register Owner";
            this.registerOwnerToolStripMenuItem.Click += new System.EventHandler(this.registerOwnerToolStripMenuItem_Click);
            // 
            // registerAssetToolStripMenuItem
            // 
            this.registerAssetToolStripMenuItem.Name = "registerAssetToolStripMenuItem";
            this.registerAssetToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.registerAssetToolStripMenuItem.Text = "Register Asset";
            this.registerAssetToolStripMenuItem.Click += new System.EventHandler(this.registerAssetToolStripMenuItem_Click);
            // 
            // verificationToolStripMenuItem
            // 
            this.verificationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verifyAssetToolStripMenuItem});
            this.verificationToolStripMenuItem.Name = "verificationToolStripMenuItem";
            this.verificationToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.verificationToolStripMenuItem.Text = "Verification";
            // 
            // verifyAssetToolStripMenuItem
            // 
            this.verifyAssetToolStripMenuItem.Name = "verifyAssetToolStripMenuItem";
            this.verifyAssetToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.verifyAssetToolStripMenuItem.Text = "Verify Asset";
            this.verifyAssetToolStripMenuItem.Click += new System.EventHandler(this.verifyAssetToolStripMenuItem_Click);
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.transactionHistoryToolStripMenuItem});
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.reportsToolStripMenuItem.Text = "Reports";
            // 
            // transactionHistoryToolStripMenuItem
            // 
            this.transactionHistoryToolStripMenuItem.Name = "transactionHistoryToolStripMenuItem";
            this.transactionHistoryToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.transactionHistoryToolStripMenuItem.Text = "Transaction History";
            this.transactionHistoryToolStripMenuItem.Click += new System.EventHandler(this.transactionHistoryToolStripMenuItem_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.Red;
            this.btnLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.SystemColors.Window;
            this.btnLogout.Location = new System.Drawing.Point(119, 233);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(143, 32);
            this.btnLogout.TabIndex = 33;
            this.btnLogout.Text = "LOG OUT";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Visible = false;
            // 
            // btnRegisterAsset
            // 
            this.btnRegisterAsset.BackColor = System.Drawing.Color.Orange;
            this.btnRegisterAsset.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegisterAsset.Location = new System.Drawing.Point(119, 96);
            this.btnRegisterAsset.Name = "btnRegisterAsset";
            this.btnRegisterAsset.Size = new System.Drawing.Size(143, 35);
            this.btnRegisterAsset.TabIndex = 40;
            this.btnRegisterAsset.Text = "REGISTER ASSET";
            this.btnRegisterAsset.UseVisualStyleBackColor = false;
            this.btnRegisterAsset.Visible = false;
            // 
            // btnRegisterUser
            // 
            this.btnRegisterUser.BackColor = System.Drawing.Color.Orange;
            this.btnRegisterUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegisterUser.Location = new System.Drawing.Point(119, 55);
            this.btnRegisterUser.Name = "btnRegisterUser";
            this.btnRegisterUser.Size = new System.Drawing.Size(143, 35);
            this.btnRegisterUser.TabIndex = 39;
            this.btnRegisterUser.Text = "REGISTER OWNER";
            this.btnRegisterUser.UseVisualStyleBackColor = false;
            this.btnRegisterUser.Visible = false;
            // 
            // btnScan
            // 
            this.btnScan.BackColor = System.Drawing.Color.Orange;
            this.btnScan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnScan.Location = new System.Drawing.Point(119, 137);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(143, 32);
            this.btnScan.TabIndex = 41;
            this.btnScan.Text = "VERIFY ASSET";
            this.btnScan.UseVisualStyleBackColor = false;
            this.btnScan.Visible = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblSystemInfo});
            this.statusStrip1.Location = new System.Drawing.Point(0, 284);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(393, 22);
            this.statusStrip1.TabIndex = 42;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblSystemInfo
            // 
            this.lblSystemInfo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSystemInfo.Name = "lblSystemInfo";
            this.lblSystemInfo.Size = new System.Drawing.Size(378, 17);
            this.lblSystemInfo.Spring = true;
            this.lblSystemInfo.Text = "Display System Information";
            this.lblSystemInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnTransactionHistory
            // 
            this.btnTransactionHistory.BackColor = System.Drawing.Color.Orange;
            this.btnTransactionHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTransactionHistory.Location = new System.Drawing.Point(119, 190);
            this.btnTransactionHistory.Name = "btnTransactionHistory";
            this.btnTransactionHistory.Size = new System.Drawing.Size(143, 37);
            this.btnTransactionHistory.TabIndex = 43;
            this.btnTransactionHistory.Text = "TRANSACTION HISTORY";
            this.btnTransactionHistory.UseVisualStyleBackColor = false;
            this.btnTransactionHistory.Visible = false;
            // 
            // tabCtrlMainMenu
            // 
            this.tabCtrlMainMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabCtrlMainMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabCtrlMainMenu.ImageList = this.imagebtnClose;
            this.tabCtrlMainMenu.Location = new System.Drawing.Point(0, 24);
            this.tabCtrlMainMenu.Name = "tabCtrlMainMenu";
            this.tabCtrlMainMenu.SelectedIndex = 0;
            this.tabCtrlMainMenu.Size = new System.Drawing.Size(393, 260);
            this.tabCtrlMainMenu.TabIndex = 45;
            this.tabCtrlMainMenu.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControl1_DrawItem);
            this.tabCtrlMainMenu.SelectedIndexChanged += new System.EventHandler(this.tabCtrlMainMenu_SelectedIndexChanged);
            this.tabCtrlMainMenu.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tabControl1_MouseDown);
            // 
            // imagebtnClose
            // 
            this.imagebtnClose.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imagebtnClose.ImageStream")));
            this.imagebtnClose.TransparentColor = System.Drawing.Color.Transparent;
            this.imagebtnClose.Images.SetKeyName(0, "XMark.png");
            // 
            // maintenanceToolStripMenuItem
            // 
            this.maintenanceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.serialPortToolStripMenuItem});
            this.maintenanceToolStripMenuItem.Name = "maintenanceToolStripMenuItem";
            this.maintenanceToolStripMenuItem.Size = new System.Drawing.Size(88, 20);
            this.maintenanceToolStripMenuItem.Text = "Maintenance";
            // 
            // serialPortToolStripMenuItem
            // 
            this.serialPortToolStripMenuItem.Name = "serialPortToolStripMenuItem";
            this.serialPortToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.serialPortToolStripMenuItem.Text = "Serial Port";
            this.serialPortToolStripMenuItem.Click += new System.EventHandler(this.serialPortToolStripMenuItem_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(393, 306);
            this.Controls.Add(this.tabCtrlMainMenu);
            this.Controls.Add(this.btnTransactionHistory);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnScan);
            this.Controls.Add(this.btnRegisterAsset);
            this.Controls.Add(this.btnRegisterUser);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Feather TraQ - Asset Management Solution";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainMenu_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer CurrentDateTimer;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registrationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registerOwnerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registerAssetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verificationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verifyAssetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transactionHistoryToolStripMenuItem;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnRegisterAsset;
        private System.Windows.Forms.Button btnRegisterUser;
        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblSystemInfo;
        private System.Windows.Forms.Button btnTransactionHistory;
        private System.Windows.Forms.ImageList imagebtnClose;
        public System.Windows.Forms.TabControl tabCtrlMainMenu;
        private System.Windows.Forms.ToolStripMenuItem maintenanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serialPortToolStripMenuItem;

    }
}