namespace RFID_FEATHER_ASSETS
{
    partial class SerialPortSelection
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
            this.lblSerialPort = new System.Windows.Forms.Label();
            this.cmbComPortList = new System.Windows.Forms.ComboBox();
            this.btnSerialPortOK = new System.Windows.Forms.Button();
            this.lblConnected = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblSerialPort
            // 
            this.lblSerialPort.AutoSize = true;
            this.lblSerialPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSerialPort.Location = new System.Drawing.Point(21, 27);
            this.lblSerialPort.Name = "lblSerialPort";
            this.lblSerialPort.Size = new System.Drawing.Size(79, 15);
            this.lblSerialPort.TabIndex = 8;
            this.lblSerialPort.Text = "Serial Port:";
            // 
            // cmbComPortList
            // 
            this.cmbComPortList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbComPortList.FormattingEnabled = true;
            this.cmbComPortList.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8",
            "COM9",
            "COM10",
            "COM11",
            "COM12",
            "COM13",
            "COM14",
            "COM15",
            "COM16"});
            this.cmbComPortList.Location = new System.Drawing.Point(106, 26);
            this.cmbComPortList.Name = "cmbComPortList";
            this.cmbComPortList.Size = new System.Drawing.Size(62, 21);
            this.cmbComPortList.TabIndex = 7;
            // 
            // btnSerialPortOK
            // 
            this.btnSerialPortOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSerialPortOK.Location = new System.Drawing.Point(24, 62);
            this.btnSerialPortOK.Name = "btnSerialPortOK";
            this.btnSerialPortOK.Size = new System.Drawing.Size(70, 32);
            this.btnSerialPortOK.TabIndex = 9;
            this.btnSerialPortOK.Text = "OK";
            this.btnSerialPortOK.UseVisualStyleBackColor = true;
            this.btnSerialPortOK.Click += new System.EventHandler(this.btnSerialPortOK_Click);
            // 
            // lblConnected
            // 
            this.lblConnected.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConnected.Location = new System.Drawing.Point(0, 5);
            this.lblConnected.Name = "lblConnected";
            this.lblConnected.Size = new System.Drawing.Size(197, 13);
            this.lblConnected.TabIndex = 10;
            this.lblConnected.Text = "Make sure the Reader is connected.";
            this.lblConnected.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(96, 62);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(69, 32);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // SerialPortSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(199, 106);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblConnected);
            this.Controls.Add(this.btnSerialPortOK);
            this.Controls.Add(this.lblSerialPort);
            this.Controls.Add(this.cmbComPortList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "SerialPortSelection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "COM Port Error";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSerialPort;
        private System.Windows.Forms.Button btnSerialPortOK;
        public System.Windows.Forms.ComboBox cmbComPortList;
        private System.Windows.Forms.Label lblConnected;
        private System.Windows.Forms.Button btnCancel;
    }
}