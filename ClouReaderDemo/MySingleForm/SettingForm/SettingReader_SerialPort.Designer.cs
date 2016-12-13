namespace ClouReaderDemo.MySingleForm.SettingForm
{
    partial class SettingReader_SerialPort
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingReader_SerialPort));
            this.btn_0001_02_Set = new ClouReaderDemo.MyFormTemplet.QQButton();
            this.cb_0001_02_00 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Init = new ClouReaderDemo.MyFormTemplet.QQButton();
            this.SuspendLayout();
            // 
            // btn_0001_02_Set
            // 
            resources.ApplyResources(this.btn_0001_02_Set, "btn_0001_02_Set");
            this.btn_0001_02_Set.BackColor = System.Drawing.Color.Transparent;
            this.btn_0001_02_Set.DownImage = ((System.Drawing.Image)(resources.GetObject("btn_0001_02_Set.DownImage")));
            this.btn_0001_02_Set.IsShowBorder = true;
            this.btn_0001_02_Set.MoveImage = ((System.Drawing.Image)(resources.GetObject("btn_0001_02_Set.MoveImage")));
            this.btn_0001_02_Set.Name = "btn_0001_02_Set";
            this.btn_0001_02_Set.NormalImage = ((System.Drawing.Image)(resources.GetObject("btn_0001_02_Set.NormalImage")));
            this.btn_0001_02_Set.UseVisualStyleBackColor = false;
            this.btn_0001_02_Set.Click += new System.EventHandler(this.btn_0001_02_Set_Click);
            // 
            // cb_0001_02_00
            // 
            resources.ApplyResources(this.cb_0001_02_00, "cb_0001_02_00");
            this.cb_0001_02_00.FormattingEnabled = true;
            this.cb_0001_02_00.Items.AddRange(new object[] {
            resources.GetString("cb_0001_02_00.Items"),
            resources.GetString("cb_0001_02_00.Items1"),
            resources.GetString("cb_0001_02_00.Items2"),
            resources.GetString("cb_0001_02_00.Items3"),
            resources.GetString("cb_0001_02_00.Items4")});
            this.cb_0001_02_00.Name = "cb_0001_02_00";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Name = "label1";
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
            // SettingReader_SerialPort
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_Init);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_0001_02_Set);
            this.Controls.Add(this.cb_0001_02_00);
            this.IsResize = false;
            this.Name = "SettingReader_SerialPort";
            this.ShowIcon = false;
            this.SysButton = ClouReaderDemo.Forms.ESysButton.Close;
            this.Load += new System.EventHandler(this.SettingReader_SerialPort_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MyFormTemplet.QQButton btn_0001_02_Set;
        private System.Windows.Forms.ComboBox cb_0001_02_00;
        private System.Windows.Forms.Label label1;
        private MyFormTemplet.QQButton btn_Init;
    }
}