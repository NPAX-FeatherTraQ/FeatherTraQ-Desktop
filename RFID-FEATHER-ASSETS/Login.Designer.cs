namespace RFID_FEATHER_ASSETS
{
    partial class LoginActivity
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginActivity));
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblUserPasswordRequired = new System.Windows.Forms.Label();
            this.lblLogin = new System.Windows.Forms.Label();
            this.lblSigningIn = new System.Windows.Forms.Label();
            this.lblLanguage = new System.Windows.Forms.Label();
            this.selectLanguage = new System.Windows.Forms.ComboBox();
            this.cmbLocation = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblLocation = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtUserName
            // 
            resources.ApplyResources(this.txtUserName, "txtUserName");
            this.txtUserName.Name = "txtUserName";
            // 
            // txtPassword
            // 
            resources.ApplyResources(this.txtPassword, "txtPassword");
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);
            // 
            // lblUsername
            // 
            resources.ApplyResources(this.lblUsername, "lblUsername");
            this.lblUsername.ForeColor = System.Drawing.Color.Black;
            this.lblUsername.Name = "lblUsername";
            // 
            // lblPassword
            // 
            resources.ApplyResources(this.lblPassword, "lblPassword");
            this.lblPassword.Name = "lblPassword";
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.Orange;
            resources.ApplyResources(this.btnLogin, "btnLogin");
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Orange;
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblUserPasswordRequired
            // 
            this.lblUserPasswordRequired.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblUserPasswordRequired.ForeColor = System.Drawing.Color.Red;
            resources.ApplyResources(this.lblUserPasswordRequired, "lblUserPasswordRequired");
            this.lblUserPasswordRequired.Name = "lblUserPasswordRequired";
            // 
            // lblLogin
            // 
            resources.ApplyResources(this.lblLogin, "lblLogin");
            this.lblLogin.ForeColor = System.Drawing.Color.Black;
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Click += new System.EventHandler(this.lblLogin_Click);
            // 
            // lblSigningIn
            // 
            resources.ApplyResources(this.lblSigningIn, "lblSigningIn");
            this.lblSigningIn.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblSigningIn.Name = "lblSigningIn";
            // 
            // lblLanguage
            // 
            resources.ApplyResources(this.lblLanguage, "lblLanguage");
            this.lblLanguage.ForeColor = System.Drawing.Color.Black;
            this.lblLanguage.Name = "lblLanguage";
            // 
            // selectLanguage
            // 
            this.selectLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.selectLanguage, "selectLanguage");
            this.selectLanguage.FormattingEnabled = true;
            this.selectLanguage.Items.AddRange(new object[] {
            resources.GetString("selectLanguage.Items"),
            resources.GetString("selectLanguage.Items1")});
            this.selectLanguage.Name = "selectLanguage";
            this.selectLanguage.TabStop = false;
            this.selectLanguage.SelectedIndexChanged += new System.EventHandler(this.selectLanguage_SelectedIndexChanged_1);
            // 
            // cmbLocation
            // 
            this.cmbLocation.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbLocation.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            resources.ApplyResources(this.cmbLocation, "cmbLocation");
            this.cmbLocation.FormattingEnabled = true;
            this.cmbLocation.Name = "cmbLocation";
            this.cmbLocation.Leave += new System.EventHandler(this.cmbLocation_Leave);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Name = "label1";
            // 
            // lblLocation
            // 
            this.lblLocation.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblLocation.ForeColor = System.Drawing.Color.Red;
            resources.ApplyResources(this.lblLocation, "lblLocation");
            this.lblLocation.Name = "lblLocation";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::RFID_FEATHER_ASSETS.Properties.Resources.logo;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // LoginActivity
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ControlBox = false;
            this.Controls.Add(this.lblSigningIn);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.cmbLocation);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.selectLanguage);
            this.Controls.Add(this.lblLanguage);
            this.Controls.Add(this.lblLogin);
            this.Controls.Add(this.lblUserPasswordRequired);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "LoginActivity";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LoginActivity_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblUserPasswordRequired;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.Label lblSigningIn;
        private System.Windows.Forms.Label lblLanguage;
        private System.Windows.Forms.ComboBox selectLanguage;
        private System.Windows.Forms.ComboBox cmbLocation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

