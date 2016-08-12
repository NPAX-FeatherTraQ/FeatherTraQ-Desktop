namespace RFID_FEATHER_ASSETS
{
    partial class ReportCreation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportCreation));
            this.grpInformation = new System.Windows.Forms.GroupBox();
            this.chkBoxChangeCamera = new System.Windows.Forms.CheckBox();
            this.comVideoDeviceBox = new System.Windows.Forms.ComboBox();
            this.lblNoCameraAvailable = new System.Windows.Forms.Label();
            this.cameraBox = new System.Windows.Forms.PictureBox();
            this.btnCapturePhoto = new System.Windows.Forms.Button();
            this.lblSubmittingInformation = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblValidIDPhoto = new System.Windows.Forms.Label();
            this.lblPersonPhoto = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.txtExplanationNotes = new System.Windows.Forms.TextBox();
            this.lblNotes = new System.Windows.Forms.Label();
            this.imgCapture1 = new System.Windows.Forms.PictureBox();
            this.imgCapture2 = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSaveImageDir = new System.Windows.Forms.TextBox();
            this.btnBrowseImagePath = new System.Windows.Forms.Button();
            this.txtCapturedImagePath = new System.Windows.Forms.TextBox();
            this.imagePathDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.grpInformation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cameraBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCapture1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCapture2)).BeginInit();
            this.SuspendLayout();
            // 
            // grpInformation
            // 
            this.grpInformation.Controls.Add(this.chkBoxChangeCamera);
            this.grpInformation.Controls.Add(this.comVideoDeviceBox);
            this.grpInformation.Controls.Add(this.lblNoCameraAvailable);
            this.grpInformation.Controls.Add(this.cameraBox);
            this.grpInformation.Controls.Add(this.btnCapturePhoto);
            this.grpInformation.Controls.Add(this.lblSubmittingInformation);
            this.grpInformation.Controls.Add(this.btnCancel);
            this.grpInformation.Controls.Add(this.lblValidIDPhoto);
            this.grpInformation.Controls.Add(this.lblPersonPhoto);
            this.grpInformation.Controls.Add(this.btnSubmit);
            this.grpInformation.Controls.Add(this.txtExplanationNotes);
            this.grpInformation.Controls.Add(this.lblNotes);
            this.grpInformation.Controls.Add(this.imgCapture1);
            this.grpInformation.Controls.Add(this.imgCapture2);
            this.grpInformation.Controls.Add(this.label8);
            this.grpInformation.Controls.Add(this.txtSaveImageDir);
            this.grpInformation.Controls.Add(this.btnBrowseImagePath);
            this.grpInformation.Controls.Add(this.txtCapturedImagePath);
            resources.ApplyResources(this.grpInformation, "grpInformation");
            this.grpInformation.Name = "grpInformation";
            this.grpInformation.TabStop = false;
            // 
            // chkBoxChangeCamera
            // 
            resources.ApplyResources(this.chkBoxChangeCamera, "chkBoxChangeCamera");
            this.chkBoxChangeCamera.Name = "chkBoxChangeCamera";
            this.chkBoxChangeCamera.UseVisualStyleBackColor = true;
            this.chkBoxChangeCamera.CheckedChanged += new System.EventHandler(this.chkBoxChangeCamera_CheckedChanged);
            // 
            // comVideoDeviceBox
            // 
            resources.ApplyResources(this.comVideoDeviceBox, "comVideoDeviceBox");
            this.comVideoDeviceBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comVideoDeviceBox.FormattingEnabled = true;
            this.comVideoDeviceBox.Name = "comVideoDeviceBox";
            this.comVideoDeviceBox.DropDown += new System.EventHandler(this.comVideoDeviceBox_DropDown);
            this.comVideoDeviceBox.SelectedIndexChanged += new System.EventHandler(this.comVideoDeviceBox_SelectedIndexChanged);
            // 
            // lblNoCameraAvailable
            // 
            resources.ApplyResources(this.lblNoCameraAvailable, "lblNoCameraAvailable");
            this.lblNoCameraAvailable.Name = "lblNoCameraAvailable";
            // 
            // cameraBox
            // 
            resources.ApplyResources(this.cameraBox, "cameraBox");
            this.cameraBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cameraBox.Name = "cameraBox";
            this.cameraBox.TabStop = false;
            // 
            // btnCapturePhoto
            // 
            resources.ApplyResources(this.btnCapturePhoto, "btnCapturePhoto");
            this.btnCapturePhoto.BackColor = System.Drawing.Color.Orange;
            this.btnCapturePhoto.Name = "btnCapturePhoto";
            this.btnCapturePhoto.UseVisualStyleBackColor = false;
            this.btnCapturePhoto.Click += new System.EventHandler(this.btnCapturePhoto_Click);
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
            // lblValidIDPhoto
            // 
            resources.ApplyResources(this.lblValidIDPhoto, "lblValidIDPhoto");
            this.lblValidIDPhoto.Name = "lblValidIDPhoto";
            // 
            // lblPersonPhoto
            // 
            resources.ApplyResources(this.lblPersonPhoto, "lblPersonPhoto");
            this.lblPersonPhoto.Name = "lblPersonPhoto";
            // 
            // btnSubmit
            // 
            resources.ApplyResources(this.btnSubmit, "btnSubmit");
            this.btnSubmit.BackColor = System.Drawing.Color.Orange;
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // txtExplanationNotes
            // 
            resources.ApplyResources(this.txtExplanationNotes, "txtExplanationNotes");
            this.txtExplanationNotes.Name = "txtExplanationNotes";
            // 
            // lblNotes
            // 
            resources.ApplyResources(this.lblNotes, "lblNotes");
            this.lblNotes.Name = "lblNotes";
            // 
            // imgCapture1
            // 
            resources.ApplyResources(this.imgCapture1, "imgCapture1");
            this.imgCapture1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.imgCapture1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imgCapture1.Name = "imgCapture1";
            this.imgCapture1.TabStop = false;
            // 
            // imgCapture2
            // 
            resources.ApplyResources(this.imgCapture2, "imgCapture2");
            this.imgCapture2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imgCapture2.Name = "imgCapture2";
            this.imgCapture2.TabStop = false;
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label8.ForeColor = System.Drawing.Color.Gray;
            this.label8.Name = "label8";
            // 
            // txtSaveImageDir
            // 
            resources.ApplyResources(this.txtSaveImageDir, "txtSaveImageDir");
            this.txtSaveImageDir.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtSaveImageDir.Name = "txtSaveImageDir";
            // 
            // btnBrowseImagePath
            // 
            resources.ApplyResources(this.btnBrowseImagePath, "btnBrowseImagePath");
            this.btnBrowseImagePath.BackColor = System.Drawing.Color.Wheat;
            this.btnBrowseImagePath.Name = "btnBrowseImagePath";
            this.btnBrowseImagePath.UseVisualStyleBackColor = false;
            this.btnBrowseImagePath.Click += new System.EventHandler(this.btnBrowseImagePath_Click);
            // 
            // txtCapturedImagePath
            // 
            resources.ApplyResources(this.txtCapturedImagePath, "txtCapturedImagePath");
            this.txtCapturedImagePath.Name = "txtCapturedImagePath";
            // 
            // ReportCreation
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlBox = false;
            this.Controls.Add(this.grpInformation);
            this.MaximizeBox = false;
            this.Name = "ReportCreation";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ReportCreation_FormClosed);
            this.grpInformation.ResumeLayout(false);
            this.grpInformation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cameraBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCapture1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCapture2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpInformation;
        private System.Windows.Forms.Label lblValidIDPhoto;
        private System.Windows.Forms.Label lblPersonPhoto;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.PictureBox imgCapture2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblNoCameraAvailable;
        private System.Windows.Forms.TextBox txtSaveImageDir;
        private System.Windows.Forms.Button btnBrowseImagePath;
        private System.Windows.Forms.Button btnCapturePhoto;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtCapturedImagePath;
        private System.Windows.Forms.Label lblSubmittingInformation;
        private System.Windows.Forms.FolderBrowserDialog imagePathDialog;
        private System.Windows.Forms.PictureBox cameraBox;
        private System.Windows.Forms.PictureBox imgCapture1;
        protected System.Windows.Forms.TextBox txtExplanationNotes;
        private System.Windows.Forms.CheckBox chkBoxChangeCamera;
        private System.Windows.Forms.ComboBox comVideoDeviceBox;


    }
}