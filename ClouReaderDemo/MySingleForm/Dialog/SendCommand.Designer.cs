namespace ClouReaderDemo.MySingleForm.TestForm.Dialog
{
    partial class SendCommand
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SendCommand));
            this.tb_Command = new System.Windows.Forms.TextBox();
            this.btn_SendCommand = new ClouReaderDemo.MyFormTemplet.QQButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_TotalCount = new ClouReaderDemo.MyFormTemplet.QQTextBoxEx();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tb_Command
            // 
            resources.ApplyResources(this.tb_Command, "tb_Command");
            this.tb_Command.Name = "tb_Command";
            // 
            // btn_SendCommand
            // 
            resources.ApplyResources(this.btn_SendCommand, "btn_SendCommand");
            this.btn_SendCommand.BackColor = System.Drawing.Color.Transparent;
            this.btn_SendCommand.DownImage = ((System.Drawing.Image)(resources.GetObject("btn_SendCommand.DownImage")));
            this.btn_SendCommand.IsShowBorder = true;
            this.btn_SendCommand.MoveImage = ((System.Drawing.Image)(resources.GetObject("btn_SendCommand.MoveImage")));
            this.btn_SendCommand.Name = "btn_SendCommand";
            this.btn_SendCommand.NormalImage = ((System.Drawing.Image)(resources.GetObject("btn_SendCommand.NormalImage")));
            this.btn_SendCommand.UseVisualStyleBackColor = true;
            this.btn_SendCommand.Click += new System.EventHandler(this.btn_SendCommand_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Name = "label2";
            // 
            // tb_TotalCount
            // 
            resources.ApplyResources(this.tb_TotalCount, "tb_TotalCount");
            this.tb_TotalCount.BackColor = System.Drawing.Color.Transparent;
            this.tb_TotalCount.Icon = null;
            this.tb_TotalCount.IconIsButton = false;
            this.tb_TotalCount.IsPasswordChat = '\0';
            this.tb_TotalCount.IsSystemPasswordChar = false;
            this.tb_TotalCount.Lines = new string[] {
        "1"};
            this.tb_TotalCount.MaxLength = 32767;
            this.tb_TotalCount.Multiline = false;
            this.tb_TotalCount.Name = "tb_TotalCount";
            this.tb_TotalCount.ReadOnly = false;
            this.tb_TotalCount.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tb_TotalCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tb_TotalCount.WaterColor = System.Drawing.Color.DarkGray;
            this.tb_TotalCount.WaterText = "";
            this.tb_TotalCount.WordWrap = true;
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Name = "label3";
            // 
            // SendCommand
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_TotalCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_SendCommand);
            this.Controls.Add(this.tb_Command);
            this.IsResize = false;
            this.Name = "SendCommand";
            this.ShowIcon = false;
            this.SysButton = ClouReaderDemo.Forms.ESysButton.Close;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_Command;
        private MyFormTemplet.QQButton btn_SendCommand;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private MyFormTemplet.QQTextBoxEx tb_TotalCount;
        private System.Windows.Forms.Label label3;
    }
}