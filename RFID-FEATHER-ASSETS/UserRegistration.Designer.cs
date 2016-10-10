namespace RFID_FEATHER_ASSETS
{
    partial class RegisterUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterUser));
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.imagePathDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CaptureImg = new System.Windows.Forms.Button();
            this.chkBoxChangeCamera = new System.Windows.Forms.CheckBox();
            this.lblNoCameraAvailable = new System.Windows.Forms.Label();
            this.comVideoDeviceBox = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtSaveImageDir = new System.Windows.Forms.TextBox();
            this.btnBrowseImageDir = new System.Windows.Forms.Button();
            this.cameraBox = new System.Windows.Forms.PictureBox();
            this.capturedPhotos = new System.Windows.Forms.GroupBox();
            this.lblOwnerPhoto = new System.Windows.Forms.Label();
            this.chkUpdateValidIDPhoto = new System.Windows.Forms.CheckBox();
            this.chkUpdateOwnerPhoto = new System.Windows.Forms.CheckBox();
            this.lblOwnerPic = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblValidIDPhoto = new System.Windows.Forms.Label();
            this.imgValidIDPhotoEmpty = new System.Windows.Forms.PictureBox();
            this.imgOwnerPhotoEmpty = new System.Windows.Forms.PictureBox();
            this.imgValidIDPhoto = new System.Windows.Forms.PictureBox();
            this.imgOwnerPhoto = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblSubmittingInformation = new System.Windows.Forms.Label();
            this.lblLoadingInformation = new System.Windows.Forms.Label();
            this.grpExpiration = new System.Windows.Forms.GroupBox();
            this.dtStartTimePicker = new System.Windows.Forms.DateTimePicker();
            this.dtStartDate = new System.Windows.Forms.DateTimePicker();
            this.lblStart = new System.Windows.Forms.Label();
            this.rbtnNoExpiration = new System.Windows.Forms.RadioButton();
            this.rbtnValidUntil = new System.Windows.Forms.RadioButton();
            this.rbtnValidToday = new System.Windows.Forms.RadioButton();
            this.dtTimePicker = new System.Windows.Forms.DateTimePicker();
            this.dtDatePicker = new System.Windows.Forms.DateTimePicker();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnEditInfo = new System.Windows.Forms.Button();
            this.btnGetRFIDTag = new System.Windows.Forms.Button();
            this.txtRFIDTag = new System.Windows.Forms.TextBox();
            this.lblTag = new System.Windows.Forms.Label();
            this.cmbauthorities = new System.Windows.Forms.ComboBox();
            this.lblAuthorities = new System.Windows.Forms.Label();
            this.txtcpassword = new System.Windows.Forms.TextBox();
            this.lblCpassword = new System.Windows.Forms.Label();
            this.txtpassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtemail = new System.Windows.Forms.TextBox();
            this.txtlastName = new System.Windows.Forms.TextBox();
            this.txtposition = new System.Windows.Forms.TextBox();
            this.description = new System.Windows.Forms.TextBox();
            this.txtfirstName = new System.Windows.Forms.TextBox();
            this.lblLname = new System.Windows.Forms.Label();
            this.lblPosition = new System.Windows.Forms.Label();
            this.lblDesc = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblFname = new System.Windows.Forms.Label();
            this.toolTipUpdatePhoto = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cameraBox)).BeginInit();
            this.capturedPhotos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgValidIDPhotoEmpty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgOwnerPhotoEmpty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgValidIDPhoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgOwnerPhoto)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.grpExpiration.SuspendLayout();
            this.SuspendLayout();
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileName = "image.jpg";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Size = new System.Drawing.Size(884, 592);
            this.splitContainer1.SplitterDistance = 471;
            this.splitContainer1.TabIndex = 39;
            this.splitContainer1.TabStop = false;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.capturedPhotos);
            this.splitContainer2.Size = new System.Drawing.Size(471, 592);
            this.splitContainer2.SplitterDistance = 375;
            this.splitContainer2.TabIndex = 63;
            this.splitContainer2.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CaptureImg);
            this.groupBox1.Controls.Add(this.chkBoxChangeCamera);
            this.groupBox1.Controls.Add(this.lblNoCameraAvailable);
            this.groupBox1.Controls.Add(this.comVideoDeviceBox);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtSaveImageDir);
            this.groupBox1.Controls.Add(this.btnBrowseImageDir);
            this.groupBox1.Controls.Add(this.cameraBox);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(471, 375);
            this.groupBox1.TabIndex = 41;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Camera Preview";
            // 
            // CaptureImg
            // 
            this.CaptureImg.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CaptureImg.BackColor = System.Drawing.Color.Orange;
            this.CaptureImg.BackgroundImage = global::RFID_FEATHER_ASSETS.Properties.Resources.camera;
            this.CaptureImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.CaptureImg.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CaptureImg.Location = new System.Drawing.Point(95, 330);
            this.CaptureImg.Name = "CaptureImg";
            this.CaptureImg.Size = new System.Drawing.Size(282, 30);
            this.CaptureImg.TabIndex = 12;
            this.CaptureImg.TabStop = false;
            this.CaptureImg.Text = "Take Photo";
            this.CaptureImg.UseVisualStyleBackColor = false;
            this.CaptureImg.Click += new System.EventHandler(this.CaptureImg_Click);
            // 
            // chkBoxChangeCamera
            // 
            this.chkBoxChangeCamera.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chkBoxChangeCamera.AutoSize = true;
            this.chkBoxChangeCamera.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.chkBoxChangeCamera.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chkBoxChangeCamera.Location = new System.Drawing.Point(261, 29);
            this.chkBoxChangeCamera.Name = "chkBoxChangeCamera";
            this.chkBoxChangeCamera.Size = new System.Drawing.Size(116, 20);
            this.chkBoxChangeCamera.TabIndex = 37;
            this.chkBoxChangeCamera.Text = "Select Camera";
            this.chkBoxChangeCamera.UseVisualStyleBackColor = true;
            this.chkBoxChangeCamera.CheckedChanged += new System.EventHandler(this.chkBoxChangeCamera_CheckedChanged);
            // 
            // lblNoCameraAvailable
            // 
            this.lblNoCameraAvailable.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblNoCameraAvailable.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoCameraAvailable.Location = new System.Drawing.Point(107, 165);
            this.lblNoCameraAvailable.Name = "lblNoCameraAvailable";
            this.lblNoCameraAvailable.Size = new System.Drawing.Size(261, 28);
            this.lblNoCameraAvailable.TabIndex = 17;
            this.lblNoCameraAvailable.Text = "There is no camera connected.";
            this.lblNoCameraAvailable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comVideoDeviceBox
            // 
            this.comVideoDeviceBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comVideoDeviceBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comVideoDeviceBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comVideoDeviceBox.FormattingEnabled = true;
            this.comVideoDeviceBox.Location = new System.Drawing.Point(97, 28);
            this.comVideoDeviceBox.Name = "comVideoDeviceBox";
            this.comVideoDeviceBox.Size = new System.Drawing.Size(158, 21);
            this.comVideoDeviceBox.TabIndex = 2;
            this.comVideoDeviceBox.Visible = false;
            this.comVideoDeviceBox.SelectedIndexChanged += new System.EventHandler(this.comVideoDeviceBox_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Gray;
            this.label9.Location = new System.Drawing.Point(83, 364);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(96, 15);
            this.label9.TabIndex = 34;
            this.label9.Text = "Image Directory:";
            this.label9.Visible = false;
            // 
            // txtSaveImageDir
            // 
            this.txtSaveImageDir.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtSaveImageDir.Enabled = false;
            this.txtSaveImageDir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSaveImageDir.Location = new System.Drawing.Point(77, 402);
            this.txtSaveImageDir.MaxLength = 45;
            this.txtSaveImageDir.Name = "txtSaveImageDir";
            this.txtSaveImageDir.Size = new System.Drawing.Size(222, 21);
            this.txtSaveImageDir.TabIndex = 33;
            this.txtSaveImageDir.Visible = false;
            // 
            // btnBrowseImageDir
            // 
            this.btnBrowseImageDir.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnBrowseImageDir.BackColor = System.Drawing.Color.Wheat;
            this.btnBrowseImageDir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowseImageDir.Location = new System.Drawing.Point(365, 364);
            this.btnBrowseImageDir.Name = "btnBrowseImageDir";
            this.btnBrowseImageDir.Size = new System.Drawing.Size(42, 22);
            this.btnBrowseImageDir.TabIndex = 1;
            this.btnBrowseImageDir.Text = "...";
            this.btnBrowseImageDir.UseVisualStyleBackColor = false;
            this.btnBrowseImageDir.Visible = false;
            // 
            // cameraBox
            // 
            this.cameraBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cameraBox.Location = new System.Drawing.Point(97, 50);
            this.cameraBox.Name = "cameraBox";
            this.cameraBox.Size = new System.Drawing.Size(280, 280);
            this.cameraBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.cameraBox.TabIndex = 13;
            this.cameraBox.TabStop = false;
            // 
            // capturedPhotos
            // 
            this.capturedPhotos.Controls.Add(this.lblOwnerPhoto);
            this.capturedPhotos.Controls.Add(this.chkUpdateValidIDPhoto);
            this.capturedPhotos.Controls.Add(this.chkUpdateOwnerPhoto);
            this.capturedPhotos.Controls.Add(this.lblOwnerPic);
            this.capturedPhotos.Controls.Add(this.label6);
            this.capturedPhotos.Controls.Add(this.lblValidIDPhoto);
            this.capturedPhotos.Controls.Add(this.imgValidIDPhotoEmpty);
            this.capturedPhotos.Controls.Add(this.imgOwnerPhotoEmpty);
            this.capturedPhotos.Controls.Add(this.imgValidIDPhoto);
            this.capturedPhotos.Controls.Add(this.imgOwnerPhoto);
            this.capturedPhotos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.capturedPhotos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.capturedPhotos.Location = new System.Drawing.Point(0, 0);
            this.capturedPhotos.Name = "capturedPhotos";
            this.capturedPhotos.Size = new System.Drawing.Size(471, 213);
            this.capturedPhotos.TabIndex = 43;
            this.capturedPhotos.TabStop = false;
            this.capturedPhotos.Text = "Captured Photos";
            // 
            // lblOwnerPhoto
            // 
            this.lblOwnerPhoto.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblOwnerPhoto.AutoSize = true;
            this.lblOwnerPhoto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOwnerPhoto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblOwnerPhoto.Location = new System.Drawing.Point(112, 99);
            this.lblOwnerPhoto.Name = "lblOwnerPhoto";
            this.lblOwnerPhoto.Size = new System.Drawing.Size(84, 16);
            this.lblOwnerPhoto.TabIndex = 57;
            this.lblOwnerPhoto.Text = "Owner Photo";
            this.lblOwnerPhoto.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // chkUpdateValidIDPhoto
            // 
            this.chkUpdateValidIDPhoto.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chkUpdateValidIDPhoto.AutoSize = true;
            this.chkUpdateValidIDPhoto.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.chkUpdateValidIDPhoto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chkUpdateValidIDPhoto.Location = new System.Drawing.Point(308, 27);
            this.chkUpdateValidIDPhoto.Name = "chkUpdateValidIDPhoto";
            this.chkUpdateValidIDPhoto.Size = new System.Drawing.Size(15, 14);
            this.chkUpdateValidIDPhoto.TabIndex = 62;
            this.chkUpdateValidIDPhoto.UseVisualStyleBackColor = true;
            this.chkUpdateValidIDPhoto.Visible = false;
            this.chkUpdateValidIDPhoto.CheckedChanged += new System.EventHandler(this.chkUpdateValidIDPhoto_CheckedChanged);
            this.chkUpdateValidIDPhoto.MouseHover += new System.EventHandler(this.chkUpdateValidIDPhoto_MouseHover);
            // 
            // chkUpdateOwnerPhoto
            // 
            this.chkUpdateOwnerPhoto.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chkUpdateOwnerPhoto.AutoSize = true;
            this.chkUpdateOwnerPhoto.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.chkUpdateOwnerPhoto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chkUpdateOwnerPhoto.Location = new System.Drawing.Point(149, 27);
            this.chkUpdateOwnerPhoto.Name = "chkUpdateOwnerPhoto";
            this.chkUpdateOwnerPhoto.Size = new System.Drawing.Size(15, 14);
            this.chkUpdateOwnerPhoto.TabIndex = 61;
            this.chkUpdateOwnerPhoto.UseVisualStyleBackColor = true;
            this.chkUpdateOwnerPhoto.Visible = false;
            this.chkUpdateOwnerPhoto.CheckedChanged += new System.EventHandler(this.chkUpdateOwnerPhoto_CheckedChanged);
            this.chkUpdateOwnerPhoto.MouseHover += new System.EventHandler(this.chkUpdateOwnerPhoto_MouseHover);
            // 
            // lblOwnerPic
            // 
            this.lblOwnerPic.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblOwnerPic.AutoSize = true;
            this.lblOwnerPic.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.lblOwnerPic.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblOwnerPic.Location = new System.Drawing.Point(180, 18);
            this.lblOwnerPic.Name = "lblOwnerPic";
            this.lblOwnerPic.Size = new System.Drawing.Size(111, 16);
            this.lblOwnerPic.TabIndex = 60;
            this.lblOwnerPic.Text = "Owner Pictures";
            this.lblOwnerPic.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.BackColor = System.Drawing.Color.Orange;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(75, 203);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(322, 10);
            this.label6.TabIndex = 59;
            // 
            // lblValidIDPhoto
            // 
            this.lblValidIDPhoto.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblValidIDPhoto.AutoSize = true;
            this.lblValidIDPhoto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValidIDPhoto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblValidIDPhoto.Location = new System.Drawing.Point(272, 99);
            this.lblValidIDPhoto.Name = "lblValidIDPhoto";
            this.lblValidIDPhoto.Size = new System.Drawing.Size(93, 16);
            this.lblValidIDPhoto.TabIndex = 58;
            this.lblValidIDPhoto.Text = "Valid ID Photo";
            this.lblValidIDPhoto.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // imgValidIDPhotoEmpty
            // 
            this.imgValidIDPhotoEmpty.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.imgValidIDPhotoEmpty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imgValidIDPhotoEmpty.Location = new System.Drawing.Point(236, 43);
            this.imgValidIDPhotoEmpty.Name = "imgValidIDPhotoEmpty";
            this.imgValidIDPhotoEmpty.Size = new System.Drawing.Size(160, 160);
            this.imgValidIDPhotoEmpty.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgValidIDPhotoEmpty.TabIndex = 64;
            this.imgValidIDPhotoEmpty.TabStop = false;
            this.imgValidIDPhotoEmpty.Visible = false;
            // 
            // imgOwnerPhotoEmpty
            // 
            this.imgOwnerPhotoEmpty.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.imgOwnerPhotoEmpty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imgOwnerPhotoEmpty.Location = new System.Drawing.Point(75, 43);
            this.imgOwnerPhotoEmpty.Name = "imgOwnerPhotoEmpty";
            this.imgOwnerPhotoEmpty.Size = new System.Drawing.Size(160, 160);
            this.imgOwnerPhotoEmpty.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgOwnerPhotoEmpty.TabIndex = 63;
            this.imgOwnerPhotoEmpty.TabStop = false;
            this.imgOwnerPhotoEmpty.Visible = false;
            // 
            // imgValidIDPhoto
            // 
            this.imgValidIDPhoto.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.imgValidIDPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imgValidIDPhoto.Location = new System.Drawing.Point(236, 43);
            this.imgValidIDPhoto.Name = "imgValidIDPhoto";
            this.imgValidIDPhoto.Size = new System.Drawing.Size(160, 160);
            this.imgValidIDPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgValidIDPhoto.TabIndex = 29;
            this.imgValidIDPhoto.TabStop = false;
            // 
            // imgOwnerPhoto
            // 
            this.imgOwnerPhoto.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.imgOwnerPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imgOwnerPhoto.Location = new System.Drawing.Point(75, 43);
            this.imgOwnerPhoto.Name = "imgOwnerPhoto";
            this.imgOwnerPhoto.Size = new System.Drawing.Size(160, 160);
            this.imgOwnerPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgOwnerPhoto.TabIndex = 28;
            this.imgOwnerPhoto.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblSubmittingInformation);
            this.groupBox2.Controls.Add(this.grpExpiration);
            this.groupBox2.Controls.Add(this.btnEditInfo);
            this.groupBox2.Controls.Add(this.btnGetRFIDTag);
            this.groupBox2.Controls.Add(this.txtRFIDTag);
            this.groupBox2.Controls.Add(this.lblTag);
            this.groupBox2.Controls.Add(this.cmbauthorities);
            this.groupBox2.Controls.Add(this.lblAuthorities);
            this.groupBox2.Controls.Add(this.txtcpassword);
            this.groupBox2.Controls.Add(this.lblCpassword);
            this.groupBox2.Controls.Add(this.txtpassword);
            this.groupBox2.Controls.Add(this.lblPassword);
            this.groupBox2.Controls.Add(this.txtemail);
            this.groupBox2.Controls.Add(this.txtlastName);
            this.groupBox2.Controls.Add(this.txtposition);
            this.groupBox2.Controls.Add(this.description);
            this.groupBox2.Controls.Add(this.txtfirstName);
            this.groupBox2.Controls.Add(this.lblLname);
            this.groupBox2.Controls.Add(this.lblPosition);
            this.groupBox2.Controls.Add(this.lblEmail);
            this.groupBox2.Controls.Add(this.lblFname);
            this.groupBox2.Controls.Add(this.lblLoadingInformation);
            this.groupBox2.Controls.Add(this.btnSubmit);
            this.groupBox2.Controls.Add(this.btnCancel);
            this.groupBox2.Controls.Add(this.lblDesc);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(409, 592);
            this.groupBox2.TabIndex = 38;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Owner Information";
            // 
            // lblSubmittingInformation
            // 
            this.lblSubmittingInformation.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblSubmittingInformation.AutoSize = true;
            this.lblSubmittingInformation.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubmittingInformation.ForeColor = System.Drawing.Color.Green;
            this.lblSubmittingInformation.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblSubmittingInformation.Location = new System.Drawing.Point(28, 489);
            this.lblSubmittingInformation.Name = "lblSubmittingInformation";
            this.lblSubmittingInformation.Size = new System.Drawing.Size(352, 24);
            this.lblSubmittingInformation.TabIndex = 66;
            this.lblSubmittingInformation.Text = "Submitting Information. Please wait...";
            this.lblSubmittingInformation.Visible = false;
            // 
            // lblLoadingInformation
            // 
            this.lblLoadingInformation.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblLoadingInformation.AutoSize = true;
            this.lblLoadingInformation.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoadingInformation.ForeColor = System.Drawing.Color.Green;
            this.lblLoadingInformation.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblLoadingInformation.Location = new System.Drawing.Point(44, 489);
            this.lblLoadingInformation.Name = "lblLoadingInformation";
            this.lblLoadingInformation.Size = new System.Drawing.Size(320, 24);
            this.lblLoadingInformation.TabIndex = 67;
            this.lblLoadingInformation.Text = "Getting Information. Please wait...";
            this.lblLoadingInformation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblLoadingInformation.Visible = false;
            // 
            // grpExpiration
            // 
            this.grpExpiration.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.grpExpiration.Controls.Add(this.dtStartTimePicker);
            this.grpExpiration.Controls.Add(this.dtStartDate);
            this.grpExpiration.Controls.Add(this.lblStart);
            this.grpExpiration.Controls.Add(this.rbtnNoExpiration);
            this.grpExpiration.Controls.Add(this.rbtnValidUntil);
            this.grpExpiration.Controls.Add(this.rbtnValidToday);
            this.grpExpiration.Controls.Add(this.dtTimePicker);
            this.grpExpiration.Controls.Add(this.dtDatePicker);
            this.grpExpiration.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.grpExpiration.Location = new System.Drawing.Point(74, 29);
            this.grpExpiration.Name = "grpExpiration";
            this.grpExpiration.Size = new System.Drawing.Size(264, 91);
            this.grpExpiration.TabIndex = 68;
            this.grpExpiration.TabStop = false;
            this.grpExpiration.Text = "Validity Period";
            // 
            // dtStartTimePicker
            // 
            this.dtStartTimePicker.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtStartTimePicker.Checked = false;
            this.dtStartTimePicker.CustomFormat = "\'Time\'";
            this.dtStartTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.dtStartTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtStartTimePicker.Location = new System.Drawing.Point(155, 17);
            this.dtStartTimePicker.Name = "dtStartTimePicker";
            this.dtStartTimePicker.ShowCheckBox = true;
            this.dtStartTimePicker.ShowUpDown = true;
            this.dtStartTimePicker.Size = new System.Drawing.Size(98, 22);
            this.dtStartTimePicker.TabIndex = 71;
            this.dtStartTimePicker.TabStop = false;
            this.dtStartTimePicker.ValueChanged += new System.EventHandler(this.dtStartTimePicker_ValueChanged);
            // 
            // dtStartDate
            // 
            this.dtStartDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtStartDate.Checked = false;
            this.dtStartDate.CustomFormat = "MM/dd/yyyy";
            this.dtStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.dtStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtStartDate.Location = new System.Drawing.Point(69, 17);
            this.dtStartDate.Name = "dtStartDate";
            this.dtStartDate.Size = new System.Drawing.Size(85, 22);
            this.dtStartDate.TabIndex = 70;
            this.dtStartDate.TabStop = false;
            // 
            // lblStart
            // 
            this.lblStart.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblStart.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblStart.Location = new System.Drawing.Point(22, 22);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(44, 19);
            this.lblStart.TabIndex = 69;
            this.lblStart.Text = "Start";
            this.lblStart.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // rbtnNoExpiration
            // 
            this.rbtnNoExpiration.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rbtnNoExpiration.AutoSize = true;
            this.rbtnNoExpiration.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.rbtnNoExpiration.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbtnNoExpiration.Location = new System.Drawing.Point(11, 66);
            this.rbtnNoExpiration.Name = "rbtnNoExpiration";
            this.rbtnNoExpiration.Size = new System.Drawing.Size(103, 20);
            this.rbtnNoExpiration.TabIndex = 8;
            this.rbtnNoExpiration.Text = "No End Date";
            this.rbtnNoExpiration.UseVisualStyleBackColor = true;
            // 
            // rbtnValidUntil
            // 
            this.rbtnValidUntil.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rbtnValidUntil.AutoSize = true;
            this.rbtnValidUntil.Checked = true;
            this.rbtnValidUntil.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.rbtnValidUntil.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbtnValidUntil.Location = new System.Drawing.Point(11, 43);
            this.rbtnValidUntil.Name = "rbtnValidUntil";
            this.rbtnValidUntil.Size = new System.Drawing.Size(52, 20);
            this.rbtnValidUntil.TabIndex = 7;
            this.rbtnValidUntil.TabStop = true;
            this.rbtnValidUntil.Text = "Until";
            this.rbtnValidUntil.UseVisualStyleBackColor = true;
            this.rbtnValidUntil.CheckedChanged += new System.EventHandler(this.rbtnValidUntil_CheckedChanged);
            // 
            // rbtnValidToday
            // 
            this.rbtnValidToday.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rbtnValidToday.AutoSize = true;
            this.rbtnValidToday.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.rbtnValidToday.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbtnValidToday.Location = new System.Drawing.Point(11, 22);
            this.rbtnValidToday.Name = "rbtnValidToday";
            this.rbtnValidToday.Size = new System.Drawing.Size(66, 20);
            this.rbtnValidToday.TabIndex = 6;
            this.rbtnValidToday.Text = "Today";
            this.rbtnValidToday.UseVisualStyleBackColor = true;
            this.rbtnValidToday.Visible = false;
            // 
            // dtTimePicker
            // 
            this.dtTimePicker.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtTimePicker.Checked = false;
            this.dtTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.dtTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtTimePicker.Location = new System.Drawing.Point(155, 40);
            this.dtTimePicker.Name = "dtTimePicker";
            this.dtTimePicker.ShowCheckBox = true;
            this.dtTimePicker.ShowUpDown = true;
            this.dtTimePicker.Size = new System.Drawing.Size(98, 22);
            this.dtTimePicker.TabIndex = 10;
            this.dtTimePicker.TabStop = false;
            this.dtTimePicker.ValueChanged += new System.EventHandler(this.dtTimePicker_ValueChanged);
            // 
            // dtDatePicker
            // 
            this.dtDatePicker.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtDatePicker.Checked = false;
            this.dtDatePicker.CustomFormat = "";
            this.dtDatePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.dtDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDatePicker.Location = new System.Drawing.Point(69, 40);
            this.dtDatePicker.Name = "dtDatePicker";
            this.dtDatePicker.Size = new System.Drawing.Size(85, 22);
            this.dtDatePicker.TabIndex = 9;
            this.dtDatePicker.TabStop = false;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSubmit.BackColor = System.Drawing.Color.Orange;
            this.btnSubmit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSubmit.BackgroundImage")));
            this.btnSubmit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.Location = new System.Drawing.Point(74, 487);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(131, 28);
            this.btnSubmit.TabIndex = 10;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCancel.BackColor = System.Drawing.Color.Orange;
            this.btnCancel.BackgroundImage = global::RFID_FEATHER_ASSETS.Properties.Resources.cancel;
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(208, 487);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(131, 28);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnEditInfo
            // 
            this.btnEditInfo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnEditInfo.BackColor = System.Drawing.Color.Orange;
            this.btnEditInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditInfo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnEditInfo.Location = new System.Drawing.Point(243, 126);
            this.btnEditInfo.Name = "btnEditInfo";
            this.btnEditInfo.Size = new System.Drawing.Size(95, 24);
            this.btnEditInfo.TabIndex = 12;
            this.btnEditInfo.Text = "Update User";
            this.btnEditInfo.UseVisualStyleBackColor = false;
            this.btnEditInfo.Click += new System.EventHandler(this.btnEditInfo_Click);
            // 
            // btnGetRFIDTag
            // 
            this.btnGetRFIDTag.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnGetRFIDTag.BackColor = System.Drawing.Color.Orange;
            this.btnGetRFIDTag.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetRFIDTag.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnGetRFIDTag.Location = new System.Drawing.Point(144, 126);
            this.btnGetRFIDTag.Name = "btnGetRFIDTag";
            this.btnGetRFIDTag.Size = new System.Drawing.Size(95, 24);
            this.btnGetRFIDTag.TabIndex = 2;
            this.btnGetRFIDTag.Text = "Scan RFID";
            this.btnGetRFIDTag.UseVisualStyleBackColor = false;
            this.btnGetRFIDTag.Click += new System.EventHandler(this.btnGetRFIDTag_Click);
            // 
            // txtRFIDTag
            // 
            this.txtRFIDTag.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtRFIDTag.BackColor = System.Drawing.SystemColors.Control;
            this.txtRFIDTag.Enabled = false;
            this.txtRFIDTag.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.txtRFIDTag.Location = new System.Drawing.Point(74, 150);
            this.txtRFIDTag.MaxLength = 45;
            this.txtRFIDTag.Name = "txtRFIDTag";
            this.txtRFIDTag.Size = new System.Drawing.Size(265, 21);
            this.txtRFIDTag.TabIndex = 27;
            // 
            // lblTag
            // 
            this.lblTag.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTag.AutoSize = true;
            this.lblTag.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTag.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblTag.Location = new System.Drawing.Point(71, 132);
            this.lblTag.Name = "lblTag";
            this.lblTag.Size = new System.Drawing.Size(67, 16);
            this.lblTag.TabIndex = 26;
            this.lblTag.Text = "RFID Tag";
            this.lblTag.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cmbauthorities
            // 
            this.cmbauthorities.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbauthorities.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbauthorities.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbauthorities.FormattingEnabled = true;
            this.cmbauthorities.Location = new System.Drawing.Point(75, 369);
            this.cmbauthorities.Name = "cmbauthorities";
            this.cmbauthorities.Size = new System.Drawing.Size(265, 24);
            this.cmbauthorities.TabIndex = 7;
            this.cmbauthorities.Tag = "";
            this.cmbauthorities.SelectedIndexChanged += new System.EventHandler(this.authorities_SelectedIndexChanged);
            // 
            // lblAuthorities
            // 
            this.lblAuthorities.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblAuthorities.AutoSize = true;
            this.lblAuthorities.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAuthorities.Location = new System.Drawing.Point(71, 351);
            this.lblAuthorities.Name = "lblAuthorities";
            this.lblAuthorities.Size = new System.Drawing.Size(75, 16);
            this.lblAuthorities.TabIndex = 24;
            this.lblAuthorities.Text = "User Type:";
            // 
            // txtcpassword
            // 
            this.txtcpassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtcpassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcpassword.Location = new System.Drawing.Point(75, 460);
            this.txtcpassword.Name = "txtcpassword";
            this.txtcpassword.PasswordChar = '•';
            this.txtcpassword.Size = new System.Drawing.Size(265, 22);
            this.txtcpassword.TabIndex = 9;
            this.txtcpassword.Visible = false;
            // 
            // lblCpassword
            // 
            this.lblCpassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCpassword.AutoSize = true;
            this.lblCpassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCpassword.Location = new System.Drawing.Point(71, 442);
            this.lblCpassword.Name = "lblCpassword";
            this.lblCpassword.Size = new System.Drawing.Size(119, 16);
            this.lblCpassword.TabIndex = 22;
            this.lblCpassword.Text = "Confirm Password:";
            this.lblCpassword.Visible = false;
            // 
            // txtpassword
            // 
            this.txtpassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtpassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpassword.Location = new System.Drawing.Point(75, 416);
            this.txtpassword.Name = "txtpassword";
            this.txtpassword.PasswordChar = '•';
            this.txtpassword.Size = new System.Drawing.Size(265, 22);
            this.txtpassword.TabIndex = 8;
            this.txtpassword.Visible = false;
            // 
            // lblPassword
            // 
            this.lblPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.Location = new System.Drawing.Point(71, 398);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(74, 16);
            this.lblPassword.TabIndex = 20;
            this.lblPassword.Text = "Password: ";
            this.lblPassword.Visible = false;
            // 
            // txtemail
            // 
            this.txtemail.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtemail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtemail.Location = new System.Drawing.Point(75, 325);
            this.txtemail.Name = "txtemail";
            this.txtemail.Size = new System.Drawing.Size(265, 22);
            this.txtemail.TabIndex = 6;
            // 
            // txtlastName
            // 
            this.txtlastName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtlastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtlastName.Location = new System.Drawing.Point(75, 237);
            this.txtlastName.Name = "txtlastName";
            this.txtlastName.Size = new System.Drawing.Size(265, 22);
            this.txtlastName.TabIndex = 4;
            // 
            // txtposition
            // 
            this.txtposition.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtposition.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtposition.Location = new System.Drawing.Point(75, 281);
            this.txtposition.Name = "txtposition";
            this.txtposition.Size = new System.Drawing.Size(265, 22);
            this.txtposition.TabIndex = 5;
            // 
            // description
            // 
            this.description.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.description.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.description.Location = new System.Drawing.Point(250, 534);
            this.description.Multiline = true;
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(53, 17);
            this.description.TabIndex = 13;
            this.description.Visible = false;
            // 
            // txtfirstName
            // 
            this.txtfirstName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtfirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtfirstName.Location = new System.Drawing.Point(75, 193);
            this.txtfirstName.Name = "txtfirstName";
            this.txtfirstName.Size = new System.Drawing.Size(265, 22);
            this.txtfirstName.TabIndex = 3;
            // 
            // lblLname
            // 
            this.lblLname.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblLname.AutoSize = true;
            this.lblLname.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLname.Location = new System.Drawing.Point(71, 219);
            this.lblLname.Name = "lblLname";
            this.lblLname.Size = new System.Drawing.Size(79, 16);
            this.lblLname.TabIndex = 16;
            this.lblLname.Text = "Last Name: ";
            // 
            // lblPosition
            // 
            this.lblPosition.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPosition.AutoSize = true;
            this.lblPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPosition.Location = new System.Drawing.Point(71, 263);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(59, 16);
            this.lblPosition.TabIndex = 14;
            this.lblPosition.Text = "Position:";
            // 
            // lblDesc
            // 
            this.lblDesc.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDesc.AutoSize = true;
            this.lblDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesc.Location = new System.Drawing.Point(243, 492);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(93, 20);
            this.lblDesc.TabIndex = 12;
            this.lblDesc.Text = "Description:";
            this.lblDesc.Visible = false;
            // 
            // lblEmail
            // 
            this.lblEmail.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.Location = new System.Drawing.Point(71, 307);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(49, 16);
            this.lblEmail.TabIndex = 10;
            this.lblEmail.Text = "E-Mail:";
            // 
            // lblFname
            // 
            this.lblFname.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblFname.AutoSize = true;
            this.lblFname.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFname.Location = new System.Drawing.Point(71, 175);
            this.lblFname.Name = "lblFname";
            this.lblFname.Size = new System.Drawing.Size(79, 16);
            this.lblFname.TabIndex = 8;
            this.lblFname.Text = "First Name: ";
            // 
            // RegisterUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(884, 592);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(900, 630);
            this.Name = "RegisterUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Owner Registration";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RegisterUser_FormClosed);
            this.Load += new System.EventHandler(this.RegisterUser_Load);
            this.Leave += new System.EventHandler(this.RegisterUser_Leave);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cameraBox)).EndInit();
            this.capturedPhotos.ResumeLayout(false);
            this.capturedPhotos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgValidIDPhotoEmpty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgOwnerPhotoEmpty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgValidIDPhoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgOwnerPhoto)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.grpExpiration.ResumeLayout(false);
            this.grpExpiration.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog imagePathDialog;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnGetRFIDTag;
        private System.Windows.Forms.TextBox txtRFIDTag;
        private System.Windows.Forms.Label lblTag;
        private System.Windows.Forms.ComboBox cmbauthorities;
        private System.Windows.Forms.Label lblAuthorities;
        private System.Windows.Forms.TextBox txtcpassword;
        private System.Windows.Forms.Label lblCpassword;
        private System.Windows.Forms.TextBox txtpassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.TextBox txtemail;
        private System.Windows.Forms.TextBox txtlastName;
        private System.Windows.Forms.TextBox txtposition;
        private System.Windows.Forms.TextBox description;
        private System.Windows.Forms.TextBox txtfirstName;
        private System.Windows.Forms.Label lblLname;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblFname;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkBoxChangeCamera;
        private System.Windows.Forms.Label lblNoCameraAvailable;
        private System.Windows.Forms.ComboBox comVideoDeviceBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtSaveImageDir;
        private System.Windows.Forms.Button btnBrowseImageDir;
        private System.Windows.Forms.PictureBox cameraBox;
        private System.Windows.Forms.GroupBox capturedPhotos;
        private System.Windows.Forms.PictureBox imgValidIDPhoto;
        private System.Windows.Forms.PictureBox imgOwnerPhoto;
        private System.Windows.Forms.Button btnEditInfo;
        private System.Windows.Forms.Button CaptureImg;
        private System.Windows.Forms.Label lblSubmittingInformation;
        private System.Windows.Forms.Label lblLoadingInformation;
        private System.Windows.Forms.Label lblValidIDPhoto;
        private System.Windows.Forms.Label lblOwnerPhoto;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox grpExpiration;
        private System.Windows.Forms.DateTimePicker dtStartTimePicker;
        private System.Windows.Forms.DateTimePicker dtStartDate;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.RadioButton rbtnNoExpiration;
        private System.Windows.Forms.RadioButton rbtnValidUntil;
        private System.Windows.Forms.RadioButton rbtnValidToday;
        private System.Windows.Forms.DateTimePicker dtTimePicker;
        private System.Windows.Forms.DateTimePicker dtDatePicker;
        private System.Windows.Forms.Label lblOwnerPic;
        private System.Windows.Forms.CheckBox chkUpdateValidIDPhoto;
        private System.Windows.Forms.CheckBox chkUpdateOwnerPhoto;
        private System.Windows.Forms.ToolTip toolTipUpdatePhoto;
        private System.Windows.Forms.PictureBox imgValidIDPhotoEmpty;
        private System.Windows.Forms.PictureBox imgOwnerPhotoEmpty;
    }
}