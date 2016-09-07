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
            this.btnScan = new System.Windows.Forms.Button();
            this.btnRegisterAsset = new System.Windows.Forms.Button();
            this.btnRegisterUser = new System.Windows.Forms.Button();
            this.cmbComPort = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnMyAssets = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnTransactionHistory = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.company = new System.Windows.Forms.Label();
            this.locationTxt = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnScan
            // 
            this.btnScan.BackColor = System.Drawing.Color.Orange;
            this.btnScan.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnScan.Location = new System.Drawing.Point(52, 137);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(178, 32);
            this.btnScan.TabIndex = 2;
            this.btnScan.Text = "SCAN";
            this.btnScan.UseVisualStyleBackColor = false;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // btnRegisterAsset
            // 
            this.btnRegisterAsset.BackColor = System.Drawing.Color.Orange;
            this.btnRegisterAsset.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegisterAsset.Location = new System.Drawing.Point(51, 96);
            this.btnRegisterAsset.Name = "btnRegisterAsset";
            this.btnRegisterAsset.Size = new System.Drawing.Size(178, 35);
            this.btnRegisterAsset.TabIndex = 1;
            this.btnRegisterAsset.Text = "REGISTER ASSET";
            this.btnRegisterAsset.UseVisualStyleBackColor = false;
            this.btnRegisterAsset.Click += new System.EventHandler(this.btnRegisterAsset_Click);
            // 
            // btnRegisterUser
            // 
            this.btnRegisterUser.BackColor = System.Drawing.Color.Orange;
            this.btnRegisterUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegisterUser.Location = new System.Drawing.Point(52, 12);
            this.btnRegisterUser.Name = "btnRegisterUser";
            this.btnRegisterUser.Size = new System.Drawing.Size(178, 37);
            this.btnRegisterUser.TabIndex = 0;
            this.btnRegisterUser.Text = "REGISTER OWNER";
            this.btnRegisterUser.UseVisualStyleBackColor = false;
            this.btnRegisterUser.Click += new System.EventHandler(this.btnRegisterUser_Click);
            // 
            // cmbComPort
            // 
            this.cmbComPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbComPort.FormattingEnabled = true;
            this.cmbComPort.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8",
            "COM9",
            "COM10",
            "COM11",
            "COM12",
            "COM13",
            "COM14",
            "COM15",
            "COM16"});
            this.cmbComPort.Location = new System.Drawing.Point(112, 241);
            this.cmbComPort.Name = "cmbComPort";
            this.cmbComPort.Size = new System.Drawing.Size(77, 21);
            this.cmbComPort.TabIndex = 20;
            this.cmbComPort.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 244);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Serial Port:";
            this.label1.Visible = false;
            // 
            // btnMyAssets
            // 
            this.btnMyAssets.BackColor = System.Drawing.Color.Orange;
            this.btnMyAssets.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMyAssets.Location = new System.Drawing.Point(52, 224);
            this.btnMyAssets.Name = "btnMyAssets";
            this.btnMyAssets.Size = new System.Drawing.Size(178, 32);
            this.btnMyAssets.TabIndex = 21;
            this.btnMyAssets.Text = "MY ASSETS";
            this.btnMyAssets.UseVisualStyleBackColor = false;
            this.btnMyAssets.Visible = false;
            this.btnMyAssets.Click += new System.EventHandler(this.btnMyAssets_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.Red;
            this.btnLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.SystemColors.Window;
            this.btnLogout.Location = new System.Drawing.Point(52, 225);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(178, 32);
            this.btnLogout.TabIndex = 4;
            this.btnLogout.Text = "Log Out";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnTransactionHistory
            // 
            this.btnTransactionHistory.BackColor = System.Drawing.Color.Orange;
            this.btnTransactionHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTransactionHistory.Location = new System.Drawing.Point(52, 172);
            this.btnTransactionHistory.Name = "btnTransactionHistory";
            this.btnTransactionHistory.Size = new System.Drawing.Size(178, 37);
            this.btnTransactionHistory.TabIndex = 3;
            this.btnTransactionHistory.Text = "TRANSACTION HISTORY";
            this.btnTransactionHistory.UseVisualStyleBackColor = false;
            this.btnTransactionHistory.Click += new System.EventHandler(this.btnTransactionHistory_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(12, 260);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Company:";
            // 
            // company
            // 
            this.company.AutoSize = true;
            this.company.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.company.ForeColor = System.Drawing.Color.Black;
            this.company.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.company.Location = new System.Drawing.Point(74, 260);
            this.company.Name = "company";
            this.company.Size = new System.Drawing.Size(56, 13);
            this.company.TabIndex = 23;
            this.company.Text = "Location";
            // 
            // locationTxt
            // 
            this.locationTxt.AutoSize = true;
            this.locationTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.locationTxt.ForeColor = System.Drawing.Color.Black;
            this.locationTxt.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.locationTxt.Location = new System.Drawing.Point(198, 260);
            this.locationTxt.Name = "locationTxt";
            this.locationTxt.Size = new System.Drawing.Size(56, 13);
            this.locationTxt.TabIndex = 25;
            this.locationTxt.Text = "Location";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(136, 260);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Location:";
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(281, 274);
            this.Controls.Add(this.locationTxt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.company);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnTransactionHistory);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnMyAssets);
            this.Controls.Add(this.cmbComPort);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRegisterUser);
            this.Controls.Add(this.btnRegisterAsset);
            this.Controls.Add(this.btnScan);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main Menu";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainMenu_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.Button btnRegisterAsset;
        private System.Windows.Forms.Button btnRegisterUser;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox cmbComPort;
        private System.Windows.Forms.Button btnMyAssets;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnTransactionHistory;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label company;
        private System.Windows.Forms.Label locationTxt;
        private System.Windows.Forms.Label label4;
    }
}