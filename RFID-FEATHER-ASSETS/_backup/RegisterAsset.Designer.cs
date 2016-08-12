namespace RFID_FEATHER_ASSETS
{
    partial class RegisterAsset
    {
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtRFIDTag = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAssetName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.radbtnYes = new System.Windows.Forms.RadioButton();
            this.radbtnNo = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTakeOutNote = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnGetEPC = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.btnRegisterUser = new System.Windows.Forms.Button();
            this.comboOwner = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(40, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "RFID Tag";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtRFIDTag
            // 
            this.txtRFIDTag.Location = new System.Drawing.Point(43, 43);
            this.txtRFIDTag.MaxLength = 45;
            this.txtRFIDTag.Name = "txtRFIDTag";
            this.txtRFIDTag.Size = new System.Drawing.Size(231, 20);
            this.txtRFIDTag.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(40, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 28);
            this.label2.TabIndex = 2;
            this.label2.Text = "Asset Name";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtAssetName
            // 
            this.txtAssetName.Location = new System.Drawing.Point(42, 156);
            this.txtAssetName.MaxLength = 45;
            this.txtAssetName.Name = "txtAssetName";
            this.txtAssetName.Size = new System.Drawing.Size(231, 20);
            this.txtAssetName.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(39, 179);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 28);
            this.label3.TabIndex = 4;
            this.label3.Text = "Description";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(39, 281);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(164, 28);
            this.label4.TabIndex = 6;
            this.label4.Text = "Take Out Allowed?";
            // 
            // radbtnYes
            // 
            this.radbtnYes.AutoSize = true;
            this.radbtnYes.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radbtnYes.Location = new System.Drawing.Point(64, 312);
            this.radbtnYes.Name = "radbtnYes";
            this.radbtnYes.Size = new System.Drawing.Size(50, 27);
            this.radbtnYes.TabIndex = 5;
            this.radbtnYes.TabStop = true;
            this.radbtnYes.Text = "Yes";
            this.radbtnYes.UseVisualStyleBackColor = true;
            // 
            // radbtnNo
            // 
            this.radbtnNo.AutoSize = true;
            this.radbtnNo.Checked = true;
            this.radbtnNo.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radbtnNo.Location = new System.Drawing.Point(121, 312);
            this.radbtnNo.Name = "radbtnNo";
            this.radbtnNo.Size = new System.Drawing.Size(46, 27);
            this.radbtnNo.TabIndex = 6;
            this.radbtnNo.TabStop = true;
            this.radbtnNo.Text = "No";
            this.radbtnNo.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(38, 349);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 28);
            this.label5.TabIndex = 9;
            this.label5.Text = "Take Out Note";
            // 
            // txtTakeOutNote
            // 
            this.txtTakeOutNote.Location = new System.Drawing.Point(42, 380);
            this.txtTakeOutNote.MaxLength = 100;
            this.txtTakeOutNote.Multiline = true;
            this.txtTakeOutNote.Name = "txtTakeOutNote";
            this.txtTakeOutNote.Size = new System.Drawing.Size(230, 68);
            this.txtTakeOutNote.TabIndex = 7;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(42, 210);
            this.txtDescription.MaxLength = 45;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(231, 68);
            this.txtDescription.TabIndex = 4;
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.Orange;
            this.btnSubmit.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.Location = new System.Drawing.Point(64, 463);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(89, 38);
            this.btnSubmit.TabIndex = 8;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Orange;
            this.btnCancel.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(159, 463);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 38);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnGetEPC
            // 
            this.btnGetEPC.BackColor = System.Drawing.Color.Orange;
            this.btnGetEPC.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetEPC.Location = new System.Drawing.Point(198, 14);
            this.btnGetEPC.Name = "btnGetEPC";
            this.btnGetEPC.Size = new System.Drawing.Size(76, 26);
            this.btnGetEPC.TabIndex = 14;
            this.btnGetEPC.Text = "Get EPC";
            this.btnGetEPC.UseVisualStyleBackColor = false;
            this.btnGetEPC.Click += new System.EventHandler(this.btnGetEPC_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(40, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 28);
            this.label6.TabIndex = 15;
            this.label6.Text = "Owner";
            // 
            // btnRegisterUser
            // 
            this.btnRegisterUser.BackColor = System.Drawing.Color.Orange;
            this.btnRegisterUser.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegisterUser.Location = new System.Drawing.Point(181, 70);
            this.btnRegisterUser.Name = "btnRegisterUser";
            this.btnRegisterUser.Size = new System.Drawing.Size(93, 26);
            this.btnRegisterUser.TabIndex = 17;
            this.btnRegisterUser.Text = "Register User";
            this.btnRegisterUser.UseVisualStyleBackColor = false;
            // 
            // comboOwner
            // 
            this.comboOwner.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboOwner.FormattingEnabled = true;
            this.comboOwner.Location = new System.Drawing.Point(43, 99);
            this.comboOwner.Name = "comboOwner";
            this.comboOwner.Size = new System.Drawing.Size(229, 21);
            this.comboOwner.Sorted = true;
            this.comboOwner.TabIndex = 2;
            this.comboOwner.DropDown += new System.EventHandler(this.comboOwner_DropDown);
            this.comboOwner.SelectedIndexChanged += new System.EventHandler(this.comboOwner_SelectedIndexChanged);
            // 
            // RegisterAsset
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(315, 513);
            this.Controls.Add(this.comboOwner);
            this.Controls.Add(this.btnRegisterUser);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnGetEPC);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtTakeOutNote);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.radbtnNo);
            this.Controls.Add(this.radbtnYes);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtAssetName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtRFIDTag);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "RegisterAsset";
            this.Text = "Register Asset";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RegisterAsset_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRFIDTag;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAssetName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton radbtnYes;
        private System.Windows.Forms.RadioButton radbtnNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTakeOutNote;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnGetEPC;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnRegisterUser;
        private System.Windows.Forms.ComboBox comboOwner;

    }
}