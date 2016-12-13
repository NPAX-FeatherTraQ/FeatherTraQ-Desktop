namespace ClouReaderDemo.MySingleForm.TestForm
{
    partial class TCP_Server
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TCP_Server));
            this.tb_Port = new ClouReaderDemo.MyFormTemplet.QQTextBoxEx();
            this.gb_Tootip = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_StartOrStopServer = new ClouReaderDemo.MyFormTemplet.QQButton();
            this.label16 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmb_ServerIP = new System.Windows.Forms.ComboBox();
            this.gb_Tootip.SuspendLayout();
            this.SuspendLayout();
            // 
            // tb_Port
            // 
            resources.ApplyResources(this.tb_Port, "tb_Port");
            this.tb_Port.BackColor = System.Drawing.Color.Transparent;
            this.tb_Port.Icon = null;
            this.tb_Port.IconIsButton = false;
            this.tb_Port.IsPasswordChat = '\0';
            this.tb_Port.IsSystemPasswordChar = false;
            this.tb_Port.Lines = new string[] {
        "9090"};
            this.tb_Port.MaxLength = 32767;
            this.tb_Port.Multiline = false;
            this.tb_Port.Name = "tb_Port";
            this.tb_Port.ReadOnly = false;
            this.tb_Port.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tb_Port.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tb_Port.WaterColor = System.Drawing.Color.DarkGray;
            this.tb_Port.WaterText = "9090";
            this.tb_Port.WordWrap = true;
            // 
            // gb_Tootip
            // 
            resources.ApplyResources(this.gb_Tootip, "gb_Tootip");
            this.gb_Tootip.BackColor = System.Drawing.Color.Transparent;
            this.gb_Tootip.Controls.Add(this.label1);
            this.gb_Tootip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.gb_Tootip.Name = "gb_Tootip";
            this.gb_Tootip.TabStop = false;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Name = "label1";
            // 
            // btn_StartOrStopServer
            // 
            resources.ApplyResources(this.btn_StartOrStopServer, "btn_StartOrStopServer");
            this.btn_StartOrStopServer.BackColor = System.Drawing.Color.Transparent;
            this.btn_StartOrStopServer.DownImage = ((System.Drawing.Image)(resources.GetObject("btn_StartOrStopServer.DownImage")));
            this.btn_StartOrStopServer.IsShowBorder = true;
            this.btn_StartOrStopServer.MoveImage = ((System.Drawing.Image)(resources.GetObject("btn_StartOrStopServer.MoveImage")));
            this.btn_StartOrStopServer.Name = "btn_StartOrStopServer";
            this.btn_StartOrStopServer.NormalImage = ((System.Drawing.Image)(resources.GetObject("btn_StartOrStopServer.NormalImage")));
            this.btn_StartOrStopServer.Tag = "0";
            this.btn_StartOrStopServer.UseVisualStyleBackColor = false;
            this.btn_StartOrStopServer.Click += new System.EventHandler(this.btn_StartOrStopServer_Click);
            // 
            // label16
            // 
            resources.ApplyResources(this.label16, "label16");
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Name = "label16";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Name = "label2";
            // 
            // cmb_ServerIP
            // 
            resources.ApplyResources(this.cmb_ServerIP, "cmb_ServerIP");
            this.cmb_ServerIP.FormattingEnabled = true;
            this.cmb_ServerIP.Name = "cmb_ServerIP";
            // 
            // TCP_Server
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmb_ServerIP);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.btn_StartOrStopServer);
            this.Controls.Add(this.gb_Tootip);
            this.Controls.Add(this.tb_Port);
            this.IsResize = false;
            this.Name = "TCP_Server";
            this.ShowIcon = false;
            this.SysButton = ClouReaderDemo.Forms.ESysButton.Close;
            this.Load += new System.EventHandler(this.TCP_Server_Load);
            this.gb_Tootip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MyFormTemplet.QQTextBoxEx tb_Port;
        private System.Windows.Forms.GroupBox gb_Tootip;
        private System.Windows.Forms.Label label1;
        private MyFormTemplet.QQButton btn_StartOrStopServer;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmb_ServerIP;
    }
}