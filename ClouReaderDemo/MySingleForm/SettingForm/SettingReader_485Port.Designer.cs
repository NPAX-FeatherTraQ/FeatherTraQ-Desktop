namespace ClouReaderDemo.MySingleForm.SettingForm
{
    partial class SettingReader_485Port
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingReader_485Port));
            this.btn_0001_15_Set = new ClouReaderDemo.MyFormTemplet.QQButton();
            this.label39 = new System.Windows.Forms.Label();
            this.tb_0001_15_00 = new ClouReaderDemo.MyFormTemplet.QQTextBoxEx();
            this.label1 = new System.Windows.Forms.Label();
            this.cmb_0001_15_01 = new System.Windows.Forms.ComboBox();
            this.btn_Init = new ClouReaderDemo.MyFormTemplet.QQButton();
            this.SuspendLayout();
            // 
            // btn_0001_15_Set
            // 
            resources.ApplyResources(this.btn_0001_15_Set, "btn_0001_15_Set");
            this.btn_0001_15_Set.BackColor = System.Drawing.Color.Transparent;
            this.btn_0001_15_Set.DownImage = ((System.Drawing.Image)(resources.GetObject("btn_0001_15_Set.DownImage")));
            this.btn_0001_15_Set.IsShowBorder = true;
            this.btn_0001_15_Set.MoveImage = ((System.Drawing.Image)(resources.GetObject("btn_0001_15_Set.MoveImage")));
            this.btn_0001_15_Set.Name = "btn_0001_15_Set";
            this.btn_0001_15_Set.NormalImage = ((System.Drawing.Image)(resources.GetObject("btn_0001_15_Set.NormalImage")));
            this.btn_0001_15_Set.UseVisualStyleBackColor = false;
            this.btn_0001_15_Set.Click += new System.EventHandler(this.btn_0001_15_Set_Click);
            // 
            // label39
            // 
            resources.ApplyResources(this.label39, "label39");
            this.label39.BackColor = System.Drawing.Color.Transparent;
            this.label39.Name = "label39";
            // 
            // tb_0001_15_00
            // 
            resources.ApplyResources(this.tb_0001_15_00, "tb_0001_15_00");
            this.tb_0001_15_00.BackColor = System.Drawing.Color.Transparent;
            this.tb_0001_15_00.Icon = null;
            this.tb_0001_15_00.IconIsButton = false;
            this.tb_0001_15_00.IsPasswordChat = '\0';
            this.tb_0001_15_00.IsSystemPasswordChar = false;
            this.tb_0001_15_00.Lines = new string[0];
            this.tb_0001_15_00.MaxLength = 32767;
            this.tb_0001_15_00.Multiline = false;
            this.tb_0001_15_00.Name = "tb_0001_15_00";
            this.tb_0001_15_00.ReadOnly = false;
            this.tb_0001_15_00.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tb_0001_15_00.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tb_0001_15_00.WaterColor = System.Drawing.Color.DarkGray;
            this.tb_0001_15_00.WaterText = "0-255";
            this.tb_0001_15_00.WordWrap = true;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Name = "label1";
            // 
            // cmb_0001_15_01
            // 
            resources.ApplyResources(this.cmb_0001_15_01, "cmb_0001_15_01");
            this.cmb_0001_15_01.FormattingEnabled = true;
            this.cmb_0001_15_01.Items.AddRange(new object[] {
            resources.GetString("cmb_0001_15_01.Items"),
            resources.GetString("cmb_0001_15_01.Items1"),
            resources.GetString("cmb_0001_15_01.Items2"),
            resources.GetString("cmb_0001_15_01.Items3"),
            resources.GetString("cmb_0001_15_01.Items4")});
            this.cmb_0001_15_01.Name = "cmb_0001_15_01";
            // 
            // btn_Init
            // 
            resources.ApplyResources(this.btn_Init, "btn_Init");
            this.btn_Init.BackColor = System.Drawing.Color.Transparent;
            this.btn_Init.DownImage = ((System.Drawing.Image)(resources.GetObject("btn_Init.DownImage")));
            this.btn_Init.IsShowBorder = true;
            this.btn_Init.MoveImage = ((System.Drawing.Image)(resources.GetObject("btn_Init.MoveImage")));
            this.btn_Init.Name = "btn_Init";
            this.btn_Init.NormalImage = ((System.Drawing.Image)(resources.GetObject("btn_Init.NormalImage")));
            this.btn_Init.UseVisualStyleBackColor = false;
            this.btn_Init.Click += new System.EventHandler(this.btn_Init_Click);
            // 
            // SettingReader_485Port
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_Init);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmb_0001_15_01);
            this.Controls.Add(this.btn_0001_15_Set);
            this.Controls.Add(this.label39);
            this.Controls.Add(this.tb_0001_15_00);
            this.IsResize = false;
            this.Name = "SettingReader_485Port";
            this.ShowIcon = false;
            this.SysButton = ClouReaderDemo.Forms.ESysButton.Close;
            this.Load += new System.EventHandler(this.SettingReader_485Port_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MyFormTemplet.QQButton btn_0001_15_Set;
        private System.Windows.Forms.Label label39;
        private MyFormTemplet.QQTextBoxEx tb_0001_15_00;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmb_0001_15_01;
        private MyFormTemplet.QQButton btn_Init;
    }
}