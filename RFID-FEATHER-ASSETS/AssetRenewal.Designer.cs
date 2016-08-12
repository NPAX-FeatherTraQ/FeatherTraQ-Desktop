namespace RFID_FEATHER_ASSETS
{
    partial class AssetRenewal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AssetRenewal));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblSubmittingInformation = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.rbtnValidUnlimited = new System.Windows.Forms.RadioButton();
            this.rbtnValidUntil = new System.Windows.Forms.RadioButton();
            this.rbtnValidToday = new System.Windows.Forms.RadioButton();
            this.dtTimePicker = new System.Windows.Forms.DateTimePicker();
            this.dtDatePicker = new System.Windows.Forms.DateTimePicker();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblSubmittingInformation);
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.btnSubmit);
            this.groupBox1.Controls.Add(this.rbtnValidUnlimited);
            this.groupBox1.Controls.Add(this.rbtnValidUntil);
            this.groupBox1.Controls.Add(this.rbtnValidToday);
            this.groupBox1.Controls.Add(this.dtTimePicker);
            this.groupBox1.Controls.Add(this.dtDatePicker);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // lblSubmittingInformation
            // 
            resources.ApplyResources(this.lblSubmittingInformation, "lblSubmittingInformation");
            this.lblSubmittingInformation.ForeColor = System.Drawing.Color.Green;
            this.lblSubmittingInformation.Name = "lblSubmittingInformation";
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.BackColor = System.Drawing.Color.Orange;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSubmit
            // 
            resources.ApplyResources(this.btnSubmit, "btnSubmit");
            this.btnSubmit.BackColor = System.Drawing.Color.Orange;
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // rbtnValidUnlimited
            // 
            resources.ApplyResources(this.rbtnValidUnlimited, "rbtnValidUnlimited");
            this.rbtnValidUnlimited.Name = "rbtnValidUnlimited";
            this.rbtnValidUnlimited.UseVisualStyleBackColor = true;
            // 
            // rbtnValidUntil
            // 
            resources.ApplyResources(this.rbtnValidUntil, "rbtnValidUntil");
            this.rbtnValidUntil.Name = "rbtnValidUntil";
            this.rbtnValidUntil.UseVisualStyleBackColor = true;
            this.rbtnValidUntil.CheckedChanged += new System.EventHandler(this.rbtnValidUntil_CheckedChanged);
            // 
            // rbtnValidToday
            // 
            resources.ApplyResources(this.rbtnValidToday, "rbtnValidToday");
            this.rbtnValidToday.Checked = true;
            this.rbtnValidToday.Name = "rbtnValidToday";
            this.rbtnValidToday.TabStop = true;
            this.rbtnValidToday.UseVisualStyleBackColor = true;
            // 
            // dtTimePicker
            // 
            resources.ApplyResources(this.dtTimePicker, "dtTimePicker");
            this.dtTimePicker.Checked = false;
            this.dtTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtTimePicker.Name = "dtTimePicker";
            this.dtTimePicker.ShowCheckBox = true;
            this.dtTimePicker.ShowUpDown = true;
            this.dtTimePicker.TabStop = false;
            this.dtTimePicker.ValueChanged += new System.EventHandler(this.dtTimePicker_ValueChanged);
            // 
            // dtDatePicker
            // 
            resources.ApplyResources(this.dtDatePicker, "dtDatePicker");
            this.dtDatePicker.Checked = false;
            this.dtDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDatePicker.Name = "dtDatePicker";
            this.dtDatePicker.TabStop = false;
            // 
            // AssetRenewal
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "AssetRenewal";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbtnValidUnlimited;
        private System.Windows.Forms.RadioButton rbtnValidUntil;
        private System.Windows.Forms.RadioButton rbtnValidToday;
        private System.Windows.Forms.DateTimePicker dtTimePicker;
        private System.Windows.Forms.DateTimePicker dtDatePicker;
        private System.Windows.Forms.Label lblSubmittingInformation;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSubmit;
    }
}