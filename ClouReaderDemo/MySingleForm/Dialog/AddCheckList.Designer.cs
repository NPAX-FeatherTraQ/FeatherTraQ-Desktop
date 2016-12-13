namespace ClouReaderDemo.MySingleForm.TestForm.Dialog
{
    partial class AddCheckList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddCheckList));
            this.btn_AddList = new ClouReaderDemo.MyFormTemplet.QQButton();
            this.tb_Value = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_AddList
            // 
            resources.ApplyResources(this.btn_AddList, "btn_AddList");
            this.btn_AddList.BackColor = System.Drawing.Color.Transparent;
            this.btn_AddList.DownImage = ((System.Drawing.Image)(resources.GetObject("btn_AddList.DownImage")));
            this.btn_AddList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_AddList.IsShowBorder = true;
            this.btn_AddList.MoveImage = ((System.Drawing.Image)(resources.GetObject("btn_AddList.MoveImage")));
            this.btn_AddList.Name = "btn_AddList";
            this.btn_AddList.NormalImage = ((System.Drawing.Image)(resources.GetObject("btn_AddList.NormalImage")));
            this.btn_AddList.Tag = "0";
            this.btn_AddList.UseVisualStyleBackColor = false;
            this.btn_AddList.Click += new System.EventHandler(this.btn_AddList_Click);
            // 
            // tb_Value
            // 
            resources.ApplyResources(this.tb_Value, "tb_Value");
            this.tb_Value.Name = "tb_Value";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Name = "label1";
            // 
            // AddCheckList
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_Value);
            this.Controls.Add(this.btn_AddList);
            this.IsResize = false;
            this.Name = "AddCheckList";
            this.ShowIcon = false;
            this.SysButton = ClouReaderDemo.Forms.ESysButton.Close;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MyFormTemplet.QQButton btn_AddList;
        private System.Windows.Forms.TextBox tb_Value;
        private System.Windows.Forms.Label label1;
    }
}