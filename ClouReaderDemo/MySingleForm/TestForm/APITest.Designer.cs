namespace ClouReaderDemo.MySingleForm.TestForm
{
    partial class APITest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(APITest));
            this.qqButton1 = new ClouReaderDemo.MyFormTemplet.QQButton();
            this.SuspendLayout();
            // 
            // qqButton1
            // 
            this.qqButton1.BackColor = System.Drawing.Color.Transparent;
            this.qqButton1.DownImage = ((System.Drawing.Image)(resources.GetObject("qqButton1.DownImage")));
            this.qqButton1.Image = null;
            this.qqButton1.IsShowBorder = true;
            this.qqButton1.Location = new System.Drawing.Point(64, 58);
            this.qqButton1.MoveImage = ((System.Drawing.Image)(resources.GetObject("qqButton1.MoveImage")));
            this.qqButton1.Name = "qqButton1";
            this.qqButton1.NormalImage = ((System.Drawing.Image)(resources.GetObject("qqButton1.NormalImage")));
            this.qqButton1.Size = new System.Drawing.Size(102, 28);
            this.qqButton1.TabIndex = 0;
            this.qqButton1.Text = "获得读写器信息";
            this.qqButton1.UseVisualStyleBackColor = false;
            // 
            // APITest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 222);
            this.Controls.Add(this.qqButton1);
            this.IsResize = false;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "APITest";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.SysButton = ClouReaderDemo.Forms.ESysButton.Close;
            this.Text = "API功能测试";
            this.ResumeLayout(false);

        }

        #endregion

        private MyFormTemplet.QQButton qqButton1;
    }
}