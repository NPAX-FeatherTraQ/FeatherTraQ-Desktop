namespace RFID_FEATHER_ASSETS
{
    partial class ConnectDeviceT
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
            this.tb_485Address = new System.Windows.Forms.TextBox();
            this.cb_ComNum = new System.Windows.Forms.ComboBox();
            this.cb_BPS = new System.Windows.Forms.ComboBox();
            this.btn_OK = new System.Windows.Forms.Button();
            this.tb_ConnParam = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cb_ConnectType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tb_485Address
            // 
            this.tb_485Address.Location = new System.Drawing.Point(210, 109);
            this.tb_485Address.Name = "tb_485Address";
            this.tb_485Address.Size = new System.Drawing.Size(44, 20);
            this.tb_485Address.TabIndex = 15;
            this.tb_485Address.Text = "1";
            this.tb_485Address.Visible = false;
            // 
            // cb_ComNum
            // 
            this.cb_ComNum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ComNum.FormattingEnabled = true;
            this.cb_ComNum.Items.AddRange(new object[] {
            "COM1"});
            this.cb_ComNum.Location = new System.Drawing.Point(71, 83);
            this.cb_ComNum.Name = "cb_ComNum";
            this.cb_ComNum.Size = new System.Drawing.Size(62, 21);
            this.cb_ComNum.TabIndex = 14;
            // 
            // cb_BPS
            // 
            this.cb_BPS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_BPS.FormattingEnabled = true;
            this.cb_BPS.Items.AddRange(new object[] {
            "9600",
            "19200",
            "115200",
            "230400",
            "460800"});
            this.cb_BPS.Location = new System.Drawing.Point(132, 83);
            this.cb_BPS.Name = "cb_BPS";
            this.cb_BPS.Size = new System.Drawing.Size(72, 21);
            this.cb_BPS.TabIndex = 13;
            // 
            // btn_OK
            // 
            this.btn_OK.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_OK.Location = new System.Drawing.Point(71, 131);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(133, 23);
            this.btn_OK.TabIndex = 12;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // tb_ConnParam
            // 
            this.tb_ConnParam.Location = new System.Drawing.Point(71, 83);
            this.tb_ConnParam.Name = "tb_ConnParam";
            this.tb_ConnParam.Size = new System.Drawing.Size(112, 20);
            this.tb_ConnParam.TabIndex = 11;
            this.tb_ConnParam.Text = "COM1:115200";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(6, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Parameter：";
            // 
            // cb_ConnectType
            // 
            this.cb_ConnectType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ConnectType.FormattingEnabled = true;
            this.cb_ConnectType.Items.AddRange(new object[] {
            "RS232/Serial",
            "TCP",
            "RS485"});
            this.cb_ConnectType.Location = new System.Drawing.Point(71, 42);
            this.cb_ConnectType.Name = "cb_ConnectType";
            this.cb_ConnectType.Size = new System.Drawing.Size(133, 21);
            this.cb_ConnectType.TabIndex = 9;
            this.cb_ConnectType.SelectedIndexChanged += new System.EventHandler(this.cb_ConnectType_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(6, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Type：";
            // 
            // ConnectDeviceT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(213, 174);
            this.Controls.Add(this.tb_485Address);
            this.Controls.Add(this.cb_ComNum);
            this.Controls.Add(this.cb_BPS);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.tb_ConnParam);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cb_ConnectType);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConnectDeviceT";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Connect Device";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_485Address;
        private System.Windows.Forms.ComboBox cb_ComNum;
        private System.Windows.Forms.ComboBox cb_BPS;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.TextBox tb_ConnParam;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cb_ConnectType;
        private System.Windows.Forms.Label label1;

    }
}