namespace ClouReaderDemo.MyForm.Dialog
{
    partial class SoftUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SoftUpdate));
            this.tb_file = new System.Windows.Forms.TextBox();
            this.btn_OpenFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_StartUpdate = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lb_Progress = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tb_file
            // 
            resources.ApplyResources(this.tb_file, "tb_file");
            this.tb_file.Name = "tb_file";
            this.tb_file.ReadOnly = true;
            // 
            // btn_OpenFile
            // 
            resources.ApplyResources(this.btn_OpenFile, "btn_OpenFile");
            this.btn_OpenFile.Name = "btn_OpenFile";
            this.btn_OpenFile.UseVisualStyleBackColor = true;
            this.btn_OpenFile.Click += new System.EventHandler(this.btn_OpenFile_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Name = "label1";
            // 
            // btn_StartUpdate
            // 
            resources.ApplyResources(this.btn_StartUpdate, "btn_StartUpdate");
            this.btn_StartUpdate.Name = "btn_StartUpdate";
            this.btn_StartUpdate.UseVisualStyleBackColor = true;
            this.btn_StartUpdate.Click += new System.EventHandler(this.btn_StartUpdate_Click);
            // 
            // progressBar
            // 
            resources.ApplyResources(this.progressBar, "progressBar");
            this.progressBar.Name = "progressBar";
            this.progressBar.Step = 1;
            // 
            // lb_Progress
            // 
            resources.ApplyResources(this.lb_Progress, "lb_Progress");
            this.lb_Progress.BackColor = System.Drawing.Color.Transparent;
            this.lb_Progress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lb_Progress.Name = "lb_Progress";
            // 
            // SoftUpdate
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ClouReaderDemo.Properties.Resources._100011;
            this.Controls.Add(this.lb_Progress);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.btn_StartUpdate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_OpenFile);
            this.Controls.Add(this.tb_file);
            this.Name = "SoftUpdate";
            this.SysButton = ClouReaderDemo.Forms.ESysButton.Close;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_file;
        private System.Windows.Forms.Button btn_OpenFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_StartUpdate;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lb_Progress;
    }
}