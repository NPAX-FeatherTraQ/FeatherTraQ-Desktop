namespace RFID_FEATHER_ASSETS
{
    partial class Verification
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Verification));
            this.lblCurrentDateTime = new System.Windows.Forms.Label();
            this.VerifyTimer = new System.Windows.Forms.Timer(this.components);
            this.BackgroundTimer = new System.Windows.Forms.Timer(this.components);
            this.CurrentDateTimer = new System.Windows.Forms.Timer(this.components);
            this.ClearTimer = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblLoadingInformation = new System.Windows.Forms.Label();
            this.lblSubmittingInformation = new System.Windows.Forms.Label();
            this.lblAssetPhoto3 = new System.Windows.Forms.Label();
            this.lblAssetPhoto2 = new System.Windows.Forms.Label();
            this.lblAssetPhoto1 = new System.Windows.Forms.Label();
            this.lblValidIDPhoto = new System.Windows.Forms.Label();
            this.lblOwnerPhoto = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.lblLoginUserName = new System.Windows.Forms.Label();
            this.lblOwnerPic = new System.Windows.Forms.Label();
            this.lblAssetPic = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.imgCapture5 = new System.Windows.Forms.PictureBox();
            this.imgCapture4 = new System.Windows.Forms.PictureBox();
            this.imgCapture3 = new System.Windows.Forms.PictureBox();
            this.imgCapture2 = new System.Windows.Forms.PictureBox();
            this.imgCapture1 = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtValidUntil = new System.Windows.Forms.TextBox();
            this.lblValidUntil = new System.Windows.Forms.Label();
            this.lblDesc = new System.Windows.Forms.Label();
            this.txtTakeOutNote = new System.Windows.Forms.TextBox();
            this.lblMemo = new System.Windows.Forms.Label();
            this.txtAssetName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtRFIDTag = new System.Windows.Forms.TextBox();
            this.lblTag = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.grpBoxReportedInfo = new System.Windows.Forms.GroupBox();
            this.txtReportedNote = new System.Windows.Forms.TextBox();
            this.picPersonBroughtOut = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtOwnerDescription = new System.Windows.Forms.TextBox();
            this.btnVerifyAsset = new System.Windows.Forms.Button();
            this.txtOwnerPosition = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.picOwner = new System.Windows.Forms.PictureBox();
            this.txtOwnerName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgCapture5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCapture4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCapture3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCapture2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCapture1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.grpBoxReportedInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPersonBroughtOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOwner)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCurrentDateTime
            // 
            resources.ApplyResources(this.lblCurrentDateTime, "lblCurrentDateTime");
            this.lblCurrentDateTime.BackColor = System.Drawing.SystemColors.Control;
            this.lblCurrentDateTime.Name = "lblCurrentDateTime";
            // 
            // VerifyTimer
            // 
            this.VerifyTimer.Tick += new System.EventHandler(this.VerifyTimer_Tick);
            // 
            // BackgroundTimer
            // 
            this.BackgroundTimer.Tick += new System.EventHandler(this.BackgroundTimer_Tick);
            // 
            // CurrentDateTimer
            // 
            this.CurrentDateTimer.Tick += new System.EventHandler(this.CurrentTimer_Tick);
            // 
            // ClearTimer
            // 
            this.ClearTimer.Tick += new System.EventHandler(this.ClearTimer_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblLoadingInformation);
            this.groupBox1.Controls.Add(this.lblSubmittingInformation);
            this.groupBox1.Controls.Add(this.lblAssetPhoto3);
            this.groupBox1.Controls.Add(this.lblAssetPhoto2);
            this.groupBox1.Controls.Add(this.lblAssetPhoto1);
            this.groupBox1.Controls.Add(this.lblValidIDPhoto);
            this.groupBox1.Controls.Add(this.lblOwnerPhoto);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnBack);
            this.groupBox1.Controls.Add(this.btnReport);
            this.groupBox1.Controls.Add(this.btnSubmit);
            this.groupBox1.Controls.Add(this.lblLoginUserName);
            this.groupBox1.Controls.Add(this.lblOwnerPic);
            this.groupBox1.Controls.Add(this.lblAssetPic);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.imgCapture5);
            this.groupBox1.Controls.Add(this.imgCapture4);
            this.groupBox1.Controls.Add(this.imgCapture3);
            this.groupBox1.Controls.Add(this.imgCapture2);
            this.groupBox1.Controls.Add(this.imgCapture1);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.grpBoxReportedInfo);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // lblLoadingInformation
            // 
            resources.ApplyResources(this.lblLoadingInformation, "lblLoadingInformation");
            this.lblLoadingInformation.ForeColor = System.Drawing.Color.Green;
            this.lblLoadingInformation.Name = "lblLoadingInformation";
            // 
            // lblSubmittingInformation
            // 
            resources.ApplyResources(this.lblSubmittingInformation, "lblSubmittingInformation");
            this.lblSubmittingInformation.ForeColor = System.Drawing.Color.Green;
            this.lblSubmittingInformation.Name = "lblSubmittingInformation";
            // 
            // lblAssetPhoto3
            // 
            resources.ApplyResources(this.lblAssetPhoto3, "lblAssetPhoto3");
            this.lblAssetPhoto3.Name = "lblAssetPhoto3";
            // 
            // lblAssetPhoto2
            // 
            resources.ApplyResources(this.lblAssetPhoto2, "lblAssetPhoto2");
            this.lblAssetPhoto2.Name = "lblAssetPhoto2";
            // 
            // lblAssetPhoto1
            // 
            resources.ApplyResources(this.lblAssetPhoto1, "lblAssetPhoto1");
            this.lblAssetPhoto1.Name = "lblAssetPhoto1";
            // 
            // lblValidIDPhoto
            // 
            resources.ApplyResources(this.lblValidIDPhoto, "lblValidIDPhoto");
            this.lblValidIDPhoto.Name = "lblValidIDPhoto";
            // 
            // lblOwnerPhoto
            // 
            resources.ApplyResources(this.lblOwnerPhoto, "lblOwnerPhoto");
            this.lblOwnerPhoto.Name = "lblOwnerPhoto";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.BackColor = System.Drawing.Color.Orange;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Name = "label3";
            // 
            // btnBack
            // 
            resources.ApplyResources(this.btnBack, "btnBack");
            this.btnBack.BackColor = System.Drawing.Color.Orange;
            this.btnBack.Name = "btnBack";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnReport
            // 
            resources.ApplyResources(this.btnReport, "btnReport");
            this.btnReport.BackColor = System.Drawing.Color.Orange;
            this.btnReport.Name = "btnReport";
            this.btnReport.UseVisualStyleBackColor = false;
            this.btnReport.Click += new System.EventHandler(this.btnCreateReport_Click);
            // 
            // btnSubmit
            // 
            resources.ApplyResources(this.btnSubmit, "btnSubmit");
            this.btnSubmit.BackColor = System.Drawing.Color.Orange;
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // lblLoginUserName
            // 
            resources.ApplyResources(this.lblLoginUserName, "lblLoginUserName");
            this.lblLoginUserName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblLoginUserName.Name = "lblLoginUserName";
            // 
            // lblOwnerPic
            // 
            resources.ApplyResources(this.lblOwnerPic, "lblOwnerPic");
            this.lblOwnerPic.Name = "lblOwnerPic";
            // 
            // lblAssetPic
            // 
            resources.ApplyResources(this.lblAssetPic, "lblAssetPic");
            this.lblAssetPic.Name = "lblAssetPic";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.BackColor = System.Drawing.Color.Orange;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Name = "label6";
            // 
            // imgCapture5
            // 
            resources.ApplyResources(this.imgCapture5, "imgCapture5");
            this.imgCapture5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imgCapture5.Name = "imgCapture5";
            this.imgCapture5.TabStop = false;
            // 
            // imgCapture4
            // 
            resources.ApplyResources(this.imgCapture4, "imgCapture4");
            this.imgCapture4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imgCapture4.Name = "imgCapture4";
            this.imgCapture4.TabStop = false;
            // 
            // imgCapture3
            // 
            resources.ApplyResources(this.imgCapture3, "imgCapture3");
            this.imgCapture3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imgCapture3.Name = "imgCapture3";
            this.imgCapture3.TabStop = false;
            // 
            // imgCapture2
            // 
            resources.ApplyResources(this.imgCapture2, "imgCapture2");
            this.imgCapture2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imgCapture2.Name = "imgCapture2";
            this.imgCapture2.TabStop = false;
            // 
            // imgCapture1
            // 
            resources.ApplyResources(this.imgCapture1, "imgCapture1");
            this.imgCapture1.BackColor = System.Drawing.SystemColors.Control;
            this.imgCapture1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imgCapture1.Name = "imgCapture1";
            this.imgCapture1.TabStop = false;
            // 
            // groupBox2
            // 
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Controls.Add(this.txtValidUntil);
            this.groupBox2.Controls.Add(this.lblValidUntil);
            this.groupBox2.Controls.Add(this.lblDesc);
            this.groupBox2.Controls.Add(this.txtTakeOutNote);
            this.groupBox2.Controls.Add(this.lblMemo);
            this.groupBox2.Controls.Add(this.txtAssetName);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtRFIDTag);
            this.groupBox2.Controls.Add(this.lblTag);
            this.groupBox2.Controls.Add(this.txtDescription);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // txtValidUntil
            // 
            resources.ApplyResources(this.txtValidUntil, "txtValidUntil");
            this.txtValidUntil.BackColor = System.Drawing.Color.White;
            this.txtValidUntil.Name = "txtValidUntil";
            this.txtValidUntil.ReadOnly = true;
            this.txtValidUntil.TabStop = false;
            // 
            // lblValidUntil
            // 
            resources.ApplyResources(this.lblValidUntil, "lblValidUntil");
            this.lblValidUntil.Name = "lblValidUntil";
            // 
            // lblDesc
            // 
            resources.ApplyResources(this.lblDesc, "lblDesc");
            this.lblDesc.Name = "lblDesc";
            // 
            // txtTakeOutNote
            // 
            resources.ApplyResources(this.txtTakeOutNote, "txtTakeOutNote");
            this.txtTakeOutNote.BackColor = System.Drawing.Color.White;
            this.txtTakeOutNote.Name = "txtTakeOutNote";
            this.txtTakeOutNote.ReadOnly = true;
            this.txtTakeOutNote.TabStop = false;
            // 
            // lblMemo
            // 
            resources.ApplyResources(this.lblMemo, "lblMemo");
            this.lblMemo.Name = "lblMemo";
            // 
            // txtAssetName
            // 
            resources.ApplyResources(this.txtAssetName, "txtAssetName");
            this.txtAssetName.BackColor = System.Drawing.Color.White;
            this.txtAssetName.Name = "txtAssetName";
            this.txtAssetName.ReadOnly = true;
            this.txtAssetName.TabStop = false;
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // txtRFIDTag
            // 
            resources.ApplyResources(this.txtRFIDTag, "txtRFIDTag");
            this.txtRFIDTag.BackColor = System.Drawing.Color.White;
            this.txtRFIDTag.Name = "txtRFIDTag";
            this.txtRFIDTag.ReadOnly = true;
            this.txtRFIDTag.TabStop = false;
            // 
            // lblTag
            // 
            resources.ApplyResources(this.lblTag, "lblTag");
            this.lblTag.Name = "lblTag";
            // 
            // txtDescription
            // 
            resources.ApplyResources(this.txtDescription, "txtDescription");
            this.txtDescription.BackColor = System.Drawing.Color.White;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.TabStop = false;
            // 
            // grpBoxReportedInfo
            // 
            resources.ApplyResources(this.grpBoxReportedInfo, "grpBoxReportedInfo");
            this.grpBoxReportedInfo.Controls.Add(this.txtReportedNote);
            this.grpBoxReportedInfo.Controls.Add(this.picPersonBroughtOut);
            this.grpBoxReportedInfo.Controls.Add(this.label5);
            this.grpBoxReportedInfo.Controls.Add(this.txtOwnerDescription);
            this.grpBoxReportedInfo.Controls.Add(this.btnVerifyAsset);
            this.grpBoxReportedInfo.Controls.Add(this.txtOwnerPosition);
            this.grpBoxReportedInfo.Controls.Add(this.label2);
            this.grpBoxReportedInfo.Controls.Add(this.picOwner);
            this.grpBoxReportedInfo.Controls.Add(this.txtOwnerName);
            this.grpBoxReportedInfo.Controls.Add(this.label1);
            this.grpBoxReportedInfo.Name = "grpBoxReportedInfo";
            this.grpBoxReportedInfo.TabStop = false;
            // 
            // txtReportedNote
            // 
            resources.ApplyResources(this.txtReportedNote, "txtReportedNote");
            this.txtReportedNote.BackColor = System.Drawing.Color.White;
            this.txtReportedNote.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtReportedNote.Name = "txtReportedNote";
            this.txtReportedNote.ReadOnly = true;
            this.txtReportedNote.TabStop = false;
            // 
            // picPersonBroughtOut
            // 
            resources.ApplyResources(this.picPersonBroughtOut, "picPersonBroughtOut");
            this.picPersonBroughtOut.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picPersonBroughtOut.Name = "picPersonBroughtOut";
            this.picPersonBroughtOut.TabStop = false;
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // txtOwnerDescription
            // 
            this.txtOwnerDescription.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.txtOwnerDescription, "txtOwnerDescription");
            this.txtOwnerDescription.Name = "txtOwnerDescription";
            this.txtOwnerDescription.ReadOnly = true;
            this.txtOwnerDescription.TabStop = false;
            // 
            // btnVerifyAsset
            // 
            this.btnVerifyAsset.BackColor = System.Drawing.Color.Orange;
            resources.ApplyResources(this.btnVerifyAsset, "btnVerifyAsset");
            this.btnVerifyAsset.Name = "btnVerifyAsset";
            this.btnVerifyAsset.UseVisualStyleBackColor = false;
            // 
            // txtOwnerPosition
            // 
            this.txtOwnerPosition.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.txtOwnerPosition, "txtOwnerPosition");
            this.txtOwnerPosition.Name = "txtOwnerPosition";
            this.txtOwnerPosition.ReadOnly = true;
            this.txtOwnerPosition.TabStop = false;
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // picOwner
            // 
            this.picOwner.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.picOwner, "picOwner");
            this.picOwner.Name = "picOwner";
            this.picOwner.TabStop = false;
            // 
            // txtOwnerName
            // 
            this.txtOwnerName.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.txtOwnerName, "txtOwnerName");
            this.txtOwnerName.Name = "txtOwnerName";
            this.txtOwnerName.ReadOnly = true;
            this.txtOwnerName.TabStop = false;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // Verification
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblCurrentDateTime);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Verification";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Verification_FormClosed);
            this.Load += new System.EventHandler(this.Verification_Load);
            this.Shown += new System.EventHandler(this.Verification_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgCapture5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCapture4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCapture3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCapture2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCapture1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.grpBoxReportedInfo.ResumeLayout(false);
            this.grpBoxReportedInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPersonBroughtOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOwner)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblCurrentDateTime;
        private System.Windows.Forms.Timer VerifyTimer;
        private System.Windows.Forms.Timer BackgroundTimer;
        private System.Windows.Forms.Timer CurrentDateTimer;
        private System.Windows.Forms.Timer ClearTimer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox grpBoxReportedInfo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtOwnerDescription;
        private System.Windows.Forms.Button btnVerifyAsset;
        private System.Windows.Forms.TextBox txtOwnerPosition;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox picOwner;
        private System.Windows.Forms.TextBox txtOwnerName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblLoadingInformation;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox imgCapture5;
        private System.Windows.Forms.PictureBox imgCapture4;
        private System.Windows.Forms.PictureBox imgCapture3;
        private System.Windows.Forms.PictureBox imgCapture2;
        private System.Windows.Forms.PictureBox imgCapture1;
        private System.Windows.Forms.Label lblOwnerPic;
        private System.Windows.Forms.Label lblAssetPic;
        private System.Windows.Forms.Label lblLoginUserName;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtTakeOutNote;
        private System.Windows.Forms.Label lblMemo;
        private System.Windows.Forms.TextBox txtAssetName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtRFIDTag;
        private System.Windows.Forms.Label lblTag;
        private System.Windows.Forms.PictureBox picPersonBroughtOut;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblValidIDPhoto;
        private System.Windows.Forms.Label lblOwnerPhoto;
        private System.Windows.Forms.Label lblAssetPhoto3;
        private System.Windows.Forms.Label lblAssetPhoto2;
        private System.Windows.Forms.Label lblAssetPhoto1;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label lblSubmittingInformation;
        private System.Windows.Forms.TextBox txtReportedNote;
        private System.Windows.Forms.TextBox txtValidUntil;
        private System.Windows.Forms.Label lblValidUntil;


    }
}