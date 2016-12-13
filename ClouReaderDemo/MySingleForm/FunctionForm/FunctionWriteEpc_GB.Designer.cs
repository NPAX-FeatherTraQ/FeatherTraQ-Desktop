namespace ClouReaderDemo.MySingleForm.TestForm.FunctionForm
{
    partial class FunctionWriteEpc_GB
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FunctionWriteEpc_GB));
            this.gb_NowSelectTag = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_SelectTID = new ClouReaderDemo.MyFormTemplet.QQTextBoxEx();
            this.tb_SelectEPC = new ClouReaderDemo.MyFormTemplet.QQTextBoxEx();
            this.btn_Write = new ClouReaderDemo.MyFormTemplet.QQButton();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_WriteEPCLength = new ClouReaderDemo.MyFormTemplet.QQTextBoxEx();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_AccessPwd = new ClouReaderDemo.MyFormTemplet.QQTextBoxEx();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_WriteEPCData = new ClouReaderDemo.MyFormTemplet.QQTextBoxEx();
            this.gb_NowSelectTag.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb_NowSelectTag
            // 
            resources.ApplyResources(this.gb_NowSelectTag, "gb_NowSelectTag");
            this.gb_NowSelectTag.BackColor = System.Drawing.Color.Transparent;
            this.gb_NowSelectTag.Controls.Add(this.label2);
            this.gb_NowSelectTag.Controls.Add(this.label1);
            this.gb_NowSelectTag.Controls.Add(this.tb_SelectTID);
            this.gb_NowSelectTag.Controls.Add(this.tb_SelectEPC);
            this.gb_NowSelectTag.Name = "gb_NowSelectTag";
            this.gb_NowSelectTag.TabStop = false;
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // tb_SelectTID
            // 
            resources.ApplyResources(this.tb_SelectTID, "tb_SelectTID");
            this.tb_SelectTID.BackColor = System.Drawing.Color.Transparent;
            this.tb_SelectTID.Icon = null;
            this.tb_SelectTID.IconIsButton = false;
            this.tb_SelectTID.IsPasswordChat = '\0';
            this.tb_SelectTID.IsSystemPasswordChar = false;
            this.tb_SelectTID.Lines = new string[0];
            this.tb_SelectTID.MaxLength = 32767;
            this.tb_SelectTID.Multiline = false;
            this.tb_SelectTID.Name = "tb_SelectTID";
            this.tb_SelectTID.ReadOnly = true;
            this.tb_SelectTID.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tb_SelectTID.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tb_SelectTID.WaterColor = System.Drawing.Color.DarkGray;
            this.tb_SelectTID.WaterText = "";
            this.tb_SelectTID.WordWrap = true;
            // 
            // tb_SelectEPC
            // 
            resources.ApplyResources(this.tb_SelectEPC, "tb_SelectEPC");
            this.tb_SelectEPC.BackColor = System.Drawing.Color.Transparent;
            this.tb_SelectEPC.Icon = null;
            this.tb_SelectEPC.IconIsButton = false;
            this.tb_SelectEPC.IsPasswordChat = '\0';
            this.tb_SelectEPC.IsSystemPasswordChar = false;
            this.tb_SelectEPC.Lines = new string[0];
            this.tb_SelectEPC.MaxLength = 32767;
            this.tb_SelectEPC.Multiline = false;
            this.tb_SelectEPC.Name = "tb_SelectEPC";
            this.tb_SelectEPC.ReadOnly = true;
            this.tb_SelectEPC.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tb_SelectEPC.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tb_SelectEPC.WaterColor = System.Drawing.Color.DarkGray;
            this.tb_SelectEPC.WaterText = "";
            this.tb_SelectEPC.WordWrap = true;
            // 
            // btn_Write
            // 
            resources.ApplyResources(this.btn_Write, "btn_Write");
            this.btn_Write.BackColor = System.Drawing.Color.Transparent;
            this.btn_Write.DownImage = ((System.Drawing.Image)(resources.GetObject("btn_Write.DownImage")));
            this.btn_Write.IsShowBorder = true;
            this.btn_Write.MoveImage = ((System.Drawing.Image)(resources.GetObject("btn_Write.MoveImage")));
            this.btn_Write.Name = "btn_Write";
            this.btn_Write.NormalImage = ((System.Drawing.Image)(resources.GetObject("btn_Write.NormalImage")));
            this.btn_Write.UseVisualStyleBackColor = false;
            this.btn_Write.Click += new System.EventHandler(this.btn_Write_Click);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Name = "label3";
            // 
            // tb_WriteEPCLength
            // 
            resources.ApplyResources(this.tb_WriteEPCLength, "tb_WriteEPCLength");
            this.tb_WriteEPCLength.BackColor = System.Drawing.Color.Transparent;
            this.tb_WriteEPCLength.Icon = null;
            this.tb_WriteEPCLength.IconIsButton = false;
            this.tb_WriteEPCLength.IsPasswordChat = '\0';
            this.tb_WriteEPCLength.IsSystemPasswordChar = false;
            this.tb_WriteEPCLength.Lines = new string[] {
        "0"};
            this.tb_WriteEPCLength.MaxLength = 32767;
            this.tb_WriteEPCLength.Multiline = false;
            this.tb_WriteEPCLength.Name = "tb_WriteEPCLength";
            this.tb_WriteEPCLength.ReadOnly = true;
            this.tb_WriteEPCLength.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tb_WriteEPCLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tb_WriteEPCLength.WaterColor = System.Drawing.Color.DarkGray;
            this.tb_WriteEPCLength.WaterText = "";
            this.tb_WriteEPCLength.WordWrap = true;
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Name = "label4";
            // 
            // tb_AccessPwd
            // 
            resources.ApplyResources(this.tb_AccessPwd, "tb_AccessPwd");
            this.tb_AccessPwd.BackColor = System.Drawing.Color.Transparent;
            this.tb_AccessPwd.Icon = null;
            this.tb_AccessPwd.IconIsButton = false;
            this.tb_AccessPwd.IsPasswordChat = '\0';
            this.tb_AccessPwd.IsSystemPasswordChar = false;
            this.tb_AccessPwd.Lines = new string[0];
            this.tb_AccessPwd.MaxLength = 32767;
            this.tb_AccessPwd.Multiline = false;
            this.tb_AccessPwd.Name = "tb_AccessPwd";
            this.tb_AccessPwd.ReadOnly = false;
            this.tb_AccessPwd.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tb_AccessPwd.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tb_AccessPwd.WaterColor = System.Drawing.Color.DarkGray;
            this.tb_AccessPwd.WaterText = "000000";
            this.tb_AccessPwd.WordWrap = true;
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label5.Name = "label5";
            // 
            // tb_WriteEPCData
            // 
            resources.ApplyResources(this.tb_WriteEPCData, "tb_WriteEPCData");
            this.tb_WriteEPCData.BackColor = System.Drawing.Color.Transparent;
            this.tb_WriteEPCData.Icon = null;
            this.tb_WriteEPCData.IconIsButton = false;
            this.tb_WriteEPCData.IsPasswordChat = '\0';
            this.tb_WriteEPCData.IsSystemPasswordChar = false;
            this.tb_WriteEPCData.Lines = new string[0];
            this.tb_WriteEPCData.MaxLength = 32767;
            this.tb_WriteEPCData.Multiline = true;
            this.tb_WriteEPCData.Name = "tb_WriteEPCData";
            this.tb_WriteEPCData.ReadOnly = false;
            this.tb_WriteEPCData.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tb_WriteEPCData.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tb_WriteEPCData.WaterColor = System.Drawing.Color.DarkGray;
            this.tb_WriteEPCData.WaterText = "0F0F";
            this.tb_WriteEPCData.WordWrap = true;
            this.tb_WriteEPCData.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_WriteEPCData_KeyPress);
            this.tb_WriteEPCData.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tb_WriteEPCData_KeyUp);
            // 
            // FunctionWriteEpc_GB
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tb_WriteEPCData);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tb_AccessPwd);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tb_WriteEPCLength);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_Write);
            this.Controls.Add(this.gb_NowSelectTag);
            this.IsResize = false;
            this.Name = "FunctionWriteEpc_GB";
            this.ShowIcon = false;
            this.SysButton = ClouReaderDemo.Forms.ESysButton.Close;
            this.Load += new System.EventHandler(this.FunctionWriteEpc_Load);
            this.gb_NowSelectTag.ResumeLayout(false);
            this.gb_NowSelectTag.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_NowSelectTag;
        private MyFormTemplet.QQButton btn_Write;
        private MyFormTemplet.QQTextBoxEx tb_SelectEPC;
        private MyFormTemplet.QQTextBoxEx tb_SelectTID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private MyFormTemplet.QQTextBoxEx tb_WriteEPCLength;
        private System.Windows.Forms.Label label4;
        private MyFormTemplet.QQTextBoxEx tb_AccessPwd;
        private System.Windows.Forms.Label label5;
        private MyFormTemplet.QQTextBoxEx tb_WriteEPCData;
    }
}