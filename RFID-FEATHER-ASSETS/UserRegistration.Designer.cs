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
            this.lblValidIDPhoto = new System.Windows.Forms.Label();
            this.lblOwnerPhoto = new System.Windows.Forms.Label();
            this.imgCapture2 = new System.Windows.Forms.PictureBox();
            this.imgCapture1 = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblSubmittingInformation = new System.Windows.Forms.Label();
            this.lblLoadingInformation = new System.Windows.Forms.Label();
            this.btnEditInfo = new System.Windows.Forms.Button();
            this.grpExpiration = new System.Windows.Forms.GroupBox();
            this.dtStartDate = new System.Windows.Forms.DateTimePicker();
            this.rbtnValidUntil = new System.Windows.Forms.Label();
            this.rbtnNoExpiration = new System.Windows.Forms.RadioButton();
            this.rbtnValidStart = new System.Windows.Forms.RadioButton();
            this.rbtnValidToday = new System.Windows.Forms.RadioButton();
            this.dtTimePicker = new System.Windows.Forms.DateTimePicker();
            this.dtDatePicker = new System.Windows.Forms.DateTimePicker();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnGetRFIDTag = new System.Windows.Forms.Button();
            this.txtRFIDTag = new System.Windows.Forms.TextBox();
            this.lblTag = new System.Windows.Forms.Label();
            this.authorities = new System.Windows.Forms.ComboBox();
            this.lblAuthorities = new System.Windows.Forms.Label();
            this.cpassword = new System.Windows.Forms.TextBox();
            this.lblCpassword = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.email = new System.Windows.Forms.TextBox();
            this.lastName = new System.Windows.Forms.TextBox();
            this.position = new System.Windows.Forms.TextBox();
            this.description = new System.Windows.Forms.TextBox();
            this.firstName = new System.Windows.Forms.TextBox();
            this.lblLname = new System.Windows.Forms.Label();
            this.lblPosition = new System.Windows.Forms.Label();
            this.lblDesc = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblFname = new System.Windows.Forms.Label();
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
            ((System.ComponentModel.ISupportInitialize)(this.imgCapture2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCapture1)).BeginInit();
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
            this.splitContainer1.Size = new System.Drawing.Size(959, 750);
            this.splitContainer1.SplitterDistance = 511;
            this.splitContainer1.TabIndex = 39;
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
            this.splitContainer2.Size = new System.Drawing.Size(511, 750);
            this.splitContainer2.SplitterDistance = 460;
            this.splitContainer2.TabIndex = 63;
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
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(511, 460);
            this.groupBox1.TabIndex = 41;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Camera Preview";
            // 
            // CaptureImg
            // 
            this.CaptureImg.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CaptureImg.BackColor = System.Drawing.Color.Orange;
            this.CaptureImg.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CaptureImg.Location = new System.Drawing.Point(79, 403);
            this.CaptureImg.Name = "CaptureImg";
            this.CaptureImg.Size = new System.Drawing.Size(350, 39);
            this.CaptureImg.TabIndex = 38;
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
            this.chkBoxChangeCamera.Location = new System.Drawing.Point(313, 36);
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
            this.lblNoCameraAvailable.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoCameraAvailable.Location = new System.Drawing.Point(64, 216);
            this.lblNoCameraAvailable.Name = "lblNoCameraAvailable";
            this.lblNoCameraAvailable.Size = new System.Drawing.Size(382, 33);
            this.lblNoCameraAvailable.TabIndex = 17;
            this.lblNoCameraAvailable.Text = "There is no camera connected.";
            this.lblNoCameraAvailable.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // comVideoDeviceBox
            // 
            this.comVideoDeviceBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comVideoDeviceBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comVideoDeviceBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comVideoDeviceBox.FormattingEnabled = true;
            this.comVideoDeviceBox.Location = new System.Drawing.Point(79, 32);
            this.comVideoDeviceBox.Name = "comVideoDeviceBox";
            this.comVideoDeviceBox.Size = new System.Drawing.Size(228, 24);
            this.comVideoDeviceBox.TabIndex = 2;
            this.comVideoDeviceBox.Visible = false;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Gray;
            this.label9.Location = new System.Drawing.Point(103, 406);
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
            this.btnBrowseImageDir.Location = new System.Drawing.Point(385, 406);
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
            this.cameraBox.Location = new System.Drawing.Point(79, 58);
            this.cameraBox.Name = "cameraBox";
            this.cameraBox.Size = new System.Drawing.Size(350, 345);
            this.cameraBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.cameraBox.TabIndex = 13;
            this.cameraBox.TabStop = false;
            // 
            // capturedPhotos
            // 
            this.capturedPhotos.Controls.Add(this.lblValidIDPhoto);
            this.capturedPhotos.Controls.Add(this.lblOwnerPhoto);
            this.capturedPhotos.Controls.Add(this.imgCapture2);
            this.capturedPhotos.Controls.Add(this.imgCapture1);
            this.capturedPhotos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.capturedPhotos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.capturedPhotos.Location = new System.Drawing.Point(0, 0);
            this.capturedPhotos.Name = "capturedPhotos";
            this.capturedPhotos.Size = new System.Drawing.Size(511, 286);
            this.capturedPhotos.TabIndex = 43;
            this.capturedPhotos.TabStop = false;
            this.capturedPhotos.Text = "Captured Photos";
            // 
            // lblValidIDPhoto
            // 
            this.lblValidIDPhoto.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblValidIDPhoto.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblValidIDPhoto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblValidIDPhoto.Location = new System.Drawing.Point(254, 131);
            this.lblValidIDPhoto.Name = "lblValidIDPhoto";
            this.lblValidIDPhoto.Size = new System.Drawing.Size(200, 18);
            this.lblValidIDPhoto.TabIndex = 59;
            this.lblValidIDPhoto.Text = "Valid ID Photo";
            this.lblValidIDPhoto.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblOwnerPhoto
            // 
            this.lblOwnerPhoto.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblOwnerPhoto.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblOwnerPhoto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblOwnerPhoto.Location = new System.Drawing.Point(53, 131);
            this.lblOwnerPhoto.Name = "lblOwnerPhoto";
            this.lblOwnerPhoto.Size = new System.Drawing.Size(200, 18);
            this.lblOwnerPhoto.TabIndex = 58;
            this.lblOwnerPhoto.Text = "Owner Photo";
            this.lblOwnerPhoto.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // imgCapture2
            // 
            this.imgCapture2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.imgCapture2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imgCapture2.Location = new System.Drawing.Point(254, 47);
            this.imgCapture2.Name = "imgCapture2";
            this.imgCapture2.Size = new System.Drawing.Size(200, 200);
            this.imgCapture2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgCapture2.TabIndex = 29;
            this.imgCapture2.TabStop = false;
            // 
            // imgCapture1
            // 
            this.imgCapture1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.imgCapture1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imgCapture1.Location = new System.Drawing.Point(53, 47);
            this.imgCapture1.Name = "imgCapture1";
            this.imgCapture1.Size = new System.Drawing.Size(200, 200);
            this.imgCapture1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgCapture1.TabIndex = 28;
            this.imgCapture1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblSubmittingInformation);
            this.groupBox2.Controls.Add(this.lblLoadingInformation);
            this.groupBox2.Controls.Add(this.btnEditInfo);
            this.groupBox2.Controls.Add(this.grpExpiration);
            this.groupBox2.Controls.Add(this.btnCancel);
            this.groupBox2.Controls.Add(this.btnGetRFIDTag);
            this.groupBox2.Controls.Add(this.txtRFIDTag);
            this.groupBox2.Controls.Add(this.lblTag);
            this.groupBox2.Controls.Add(this.authorities);
            this.groupBox2.Controls.Add(this.lblAuthorities);
            this.groupBox2.Controls.Add(this.cpassword);
            this.groupBox2.Controls.Add(this.lblCpassword);
            this.groupBox2.Controls.Add(this.password);
            this.groupBox2.Controls.Add(this.lblPassword);
            this.groupBox2.Controls.Add(this.btnSubmit);
            this.groupBox2.Controls.Add(this.email);
            this.groupBox2.Controls.Add(this.lastName);
            this.groupBox2.Controls.Add(this.position);
            this.groupBox2.Controls.Add(this.description);
            this.groupBox2.Controls.Add(this.firstName);
            this.groupBox2.Controls.Add(this.lblLname);
            this.groupBox2.Controls.Add(this.lblPosition);
            this.groupBox2.Controls.Add(this.lblDesc);
            this.groupBox2.Controls.Add(this.lblEmail);
            this.groupBox2.Controls.Add(this.lblFname);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(444, 750);
            this.groupBox2.TabIndex = 38;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Owner Information";
            // 
            // lblSubmittingInformation
            // 
            this.lblSubmittingInformation.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblSubmittingInformation.AutoSize = true;
            this.lblSubmittingInformation.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubmittingInformation.ForeColor = System.Drawing.Color.Green;
            this.lblSubmittingInformation.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblSubmittingInformation.Location = new System.Drawing.Point(3, 561);
            this.lblSubmittingInformation.Name = "lblSubmittingInformation";
            this.lblSubmittingInformation.Size = new System.Drawing.Size(444, 29);
            this.lblSubmittingInformation.TabIndex = 66;
            this.lblSubmittingInformation.Text = "Submitting Information. Please wait...";
            this.lblSubmittingInformation.Visible = false;
            // 
            // lblLoadingInformation
            // 
            this.lblLoadingInformation.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblLoadingInformation.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoadingInformation.ForeColor = System.Drawing.Color.Green;
            this.lblLoadingInformation.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblLoadingInformation.Location = new System.Drawing.Point(15, 561);
            this.lblLoadingInformation.Name = "lblLoadingInformation";
            this.lblLoadingInformation.Size = new System.Drawing.Size(407, 33);
            this.lblLoadingInformation.TabIndex = 67;
            this.lblLoadingInformation.Text = "Getting Information. Please wait...";
            this.lblLoadingInformation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblLoadingInformation.Visible = false;
            // 
            // btnEditInfo
            // 
            this.btnEditInfo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnEditInfo.BackColor = System.Drawing.Color.Orange;
            this.btnEditInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.6F);
            this.btnEditInfo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnEditInfo.Location = new System.Drawing.Point(260, 169);
            this.btnEditInfo.Name = "btnEditInfo";
            this.btnEditInfo.Size = new System.Drawing.Size(111, 26);
            this.btnEditInfo.TabIndex = 63;
            this.btnEditInfo.Text = "Update User";
            this.btnEditInfo.UseVisualStyleBackColor = false;
            this.btnEditInfo.Click += new System.EventHandler(this.btnEditInfo_Click);
            // 
            // grpExpiration
            // 
            this.grpExpiration.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.grpExpiration.Controls.Add(this.dtStartDate);
            this.grpExpiration.Controls.Add(this.rbtnValidUntil);
            this.grpExpiration.Controls.Add(this.rbtnNoExpiration);
            this.grpExpiration.Controls.Add(this.rbtnValidStart);
            this.grpExpiration.Controls.Add(this.rbtnValidToday);
            this.grpExpiration.Controls.Add(this.dtTimePicker);
            this.grpExpiration.Controls.Add(this.dtDatePicker);
            this.grpExpiration.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.grpExpiration.Location = new System.Drawing.Point(88, 36);
            this.grpExpiration.Name = "grpExpiration";
            this.grpExpiration.Size = new System.Drawing.Size(282, 128);
            this.grpExpiration.TabIndex = 62;
            this.grpExpiration.TabStop = false;
            this.grpExpiration.Text = "Validity Period";
            // 
            // dtStartDate
            // 
            this.dtStartDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtStartDate.Checked = false;
            this.dtStartDate.CustomFormat = "";
            this.dtStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.dtStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtStartDate.Location = new System.Drawing.Point(81, 49);
            this.dtStartDate.Name = "dtStartDate";
            this.dtStartDate.Size = new System.Drawing.Size(85, 22);
            this.dtStartDate.TabIndex = 65;
            this.dtStartDate.TabStop = false;
            // 
            // rbtnValidUntil
            // 
            this.rbtnValidUntil.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rbtnValidUntil.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnValidUntil.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbtnValidUntil.Location = new System.Drawing.Point(31, 76);
            this.rbtnValidUntil.Name = "rbtnValidUntil";
            this.rbtnValidUntil.Size = new System.Drawing.Size(44, 14);
            this.rbtnValidUntil.TabIndex = 64;
            this.rbtnValidUntil.Text = "Until";
            this.rbtnValidUntil.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // rbtnNoExpiration
            // 
            this.rbtnNoExpiration.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rbtnNoExpiration.AutoSize = true;
            this.rbtnNoExpiration.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.rbtnNoExpiration.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbtnNoExpiration.Location = new System.Drawing.Point(20, 99);
            this.rbtnNoExpiration.Name = "rbtnNoExpiration";
            this.rbtnNoExpiration.Size = new System.Drawing.Size(82, 20);
            this.rbtnNoExpiration.TabIndex = 8;
            this.rbtnNoExpiration.Text = "Unlimited";
            this.rbtnNoExpiration.UseVisualStyleBackColor = true;
            // 
            // rbtnValidStart
            // 
            this.rbtnValidStart.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rbtnValidStart.AutoSize = true;
            this.rbtnValidStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.rbtnValidStart.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbtnValidStart.Location = new System.Drawing.Point(20, 53);
            this.rbtnValidStart.Name = "rbtnValidStart";
            this.rbtnValidStart.Size = new System.Drawing.Size(53, 20);
            this.rbtnValidStart.TabIndex = 7;
            this.rbtnValidStart.Text = "Start";
            this.rbtnValidStart.UseVisualStyleBackColor = true;
            this.rbtnValidStart.CheckedChanged += new System.EventHandler(this.rbtnValidUntil_CheckedChanged);
            // 
            // rbtnValidToday
            // 
            this.rbtnValidToday.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rbtnValidToday.AutoSize = true;
            this.rbtnValidToday.Checked = true;
            this.rbtnValidToday.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.rbtnValidToday.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbtnValidToday.Location = new System.Drawing.Point(20, 27);
            this.rbtnValidToday.Name = "rbtnValidToday";
            this.rbtnValidToday.Size = new System.Drawing.Size(66, 20);
            this.rbtnValidToday.TabIndex = 6;
            this.rbtnValidToday.TabStop = true;
            this.rbtnValidToday.Text = "Today";
            this.rbtnValidToday.UseVisualStyleBackColor = true;
            // 
            // dtTimePicker
            // 
            this.dtTimePicker.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtTimePicker.Checked = false;
            this.dtTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.dtTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtTimePicker.Location = new System.Drawing.Point(167, 71);
            this.dtTimePicker.Name = "dtTimePicker";
            this.dtTimePicker.ShowCheckBox = true;
            this.dtTimePicker.ShowUpDown = true;
            this.dtTimePicker.Size = new System.Drawing.Size(113, 22);
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
            this.dtDatePicker.Location = new System.Drawing.Point(81, 71);
            this.dtDatePicker.Name = "dtDatePicker";
            this.dtDatePicker.Size = new System.Drawing.Size(85, 22);
            this.dtDatePicker.TabIndex = 9;
            this.dtDatePicker.TabStop = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCancel.BackColor = System.Drawing.Color.Orange;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(235, 600);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(136, 39);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Back";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnGetRFIDTag
            // 
            this.btnGetRFIDTag.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnGetRFIDTag.BackColor = System.Drawing.Color.Orange;
            this.btnGetRFIDTag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.6F);
            this.btnGetRFIDTag.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnGetRFIDTag.Location = new System.Drawing.Point(169, 169);
            this.btnGetRFIDTag.Name = "btnGetRFIDTag";
            this.btnGetRFIDTag.Size = new System.Drawing.Size(91, 26);
            this.btnGetRFIDTag.TabIndex = 25;
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
            this.txtRFIDTag.Location = new System.Drawing.Point(87, 196);
            this.txtRFIDTag.MaxLength = 45;
            this.txtRFIDTag.Name = "txtRFIDTag";
            this.txtRFIDTag.Size = new System.Drawing.Size(283, 21);
            this.txtRFIDTag.TabIndex = 27;
            // 
            // lblTag
            // 
            this.lblTag.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTag.AutoSize = true;
            this.lblTag.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblTag.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblTag.Location = new System.Drawing.Point(84, 172);
            this.lblTag.Name = "lblTag";
            this.lblTag.Size = new System.Drawing.Size(79, 20);
            this.lblTag.TabIndex = 26;
            this.lblTag.Text = "RFID Tag";
            this.lblTag.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // authorities
            // 
            this.authorities.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.authorities.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.authorities.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.authorities.FormattingEnabled = true;
            this.authorities.Location = new System.Drawing.Point(88, 533);
            this.authorities.Name = "authorities";
            this.authorities.Size = new System.Drawing.Size(282, 24);
            this.authorities.TabIndex = 10;
            this.authorities.Tag = "";
            // 
            // lblAuthorities
            // 
            this.lblAuthorities.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblAuthorities.AutoSize = true;
            this.lblAuthorities.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAuthorities.Location = new System.Drawing.Point(84, 510);
            this.lblAuthorities.Name = "lblAuthorities";
            this.lblAuthorities.Size = new System.Drawing.Size(89, 20);
            this.lblAuthorities.TabIndex = 24;
            this.lblAuthorities.Text = "Authorities:";
            // 
            // cpassword
            // 
            this.cpassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cpassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cpassword.Location = new System.Drawing.Point(88, 484);
            this.cpassword.Name = "cpassword";
            this.cpassword.PasswordChar = '•';
            this.cpassword.Size = new System.Drawing.Size(282, 22);
            this.cpassword.TabIndex = 9;
            // 
            // lblCpassword
            // 
            this.lblCpassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCpassword.AutoSize = true;
            this.lblCpassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCpassword.Location = new System.Drawing.Point(84, 461);
            this.lblCpassword.Name = "lblCpassword";
            this.lblCpassword.Size = new System.Drawing.Size(141, 20);
            this.lblCpassword.TabIndex = 22;
            this.lblCpassword.Text = "Confirm Password:";
            // 
            // password
            // 
            this.password.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.password.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password.Location = new System.Drawing.Point(88, 436);
            this.password.Name = "password";
            this.password.PasswordChar = '•';
            this.password.Size = new System.Drawing.Size(282, 22);
            this.password.TabIndex = 8;
            // 
            // lblPassword
            // 
            this.lblPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.Location = new System.Drawing.Point(84, 413);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(86, 20);
            this.lblPassword.TabIndex = 20;
            this.lblPassword.Text = "Password: ";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSubmit.BackColor = System.Drawing.Color.Orange;
            this.btnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.Location = new System.Drawing.Point(89, 600);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(136, 39);
            this.btnSubmit.TabIndex = 11;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // email
            // 
            this.email.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.email.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.email.Location = new System.Drawing.Point(88, 388);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(282, 22);
            this.email.TabIndex = 7;
            // 
            // lastName
            // 
            this.lastName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastName.Location = new System.Drawing.Point(88, 292);
            this.lastName.Name = "lastName";
            this.lastName.Size = new System.Drawing.Size(282, 22);
            this.lastName.TabIndex = 5;
            // 
            // position
            // 
            this.position.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.position.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.position.Location = new System.Drawing.Point(88, 340);
            this.position.Name = "position";
            this.position.Size = new System.Drawing.Size(282, 22);
            this.position.TabIndex = 6;
            // 
            // description
            // 
            this.description.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.description.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.description.Location = new System.Drawing.Point(268, 624);
            this.description.Multiline = true;
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(53, 17);
            this.description.TabIndex = 13;
            this.description.Visible = false;
            // 
            // firstName
            // 
            this.firstName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.firstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstName.Location = new System.Drawing.Point(88, 244);
            this.firstName.Name = "firstName";
            this.firstName.Size = new System.Drawing.Size(282, 22);
            this.firstName.TabIndex = 4;
            // 
            // lblLname
            // 
            this.lblLname.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblLname.AutoSize = true;
            this.lblLname.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLname.Location = new System.Drawing.Point(84, 269);
            this.lblLname.Name = "lblLname";
            this.lblLname.Size = new System.Drawing.Size(94, 20);
            this.lblLname.TabIndex = 16;
            this.lblLname.Text = "Last Name: ";
            // 
            // lblPosition
            // 
            this.lblPosition.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPosition.AutoSize = true;
            this.lblPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPosition.Location = new System.Drawing.Point(84, 317);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(69, 20);
            this.lblPosition.TabIndex = 14;
            this.lblPosition.Text = "Position:";
            // 
            // lblDesc
            // 
            this.lblDesc.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDesc.AutoSize = true;
            this.lblDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesc.Location = new System.Drawing.Point(264, 601);
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
            this.lblEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.Location = new System.Drawing.Point(84, 365);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(57, 20);
            this.lblEmail.TabIndex = 10;
            this.lblEmail.Text = "E-Mail:";
            // 
            // lblFname
            // 
            this.lblFname.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblFname.AutoSize = true;
            this.lblFname.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFname.Location = new System.Drawing.Point(84, 221);
            this.lblFname.Name = "lblFname";
            this.lblFname.Size = new System.Drawing.Size(94, 20);
            this.lblFname.TabIndex = 8;
            this.lblFname.Text = "First Name: ";
            // 
            // RegisterUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(959, 750);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "RegisterUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Owner Registration";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RegisterUser_FormClosed);
            this.Load += new System.EventHandler(this.RegisterUser_Load);
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
            ((System.ComponentModel.ISupportInitialize)(this.imgCapture2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCapture1)).EndInit();
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
        private System.Windows.Forms.GroupBox grpExpiration;
        private System.Windows.Forms.RadioButton rbtnNoExpiration;
        private System.Windows.Forms.RadioButton rbtnValidStart;
        private System.Windows.Forms.RadioButton rbtnValidToday;
        private System.Windows.Forms.DateTimePicker dtTimePicker;
        private System.Windows.Forms.DateTimePicker dtDatePicker;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnGetRFIDTag;
        private System.Windows.Forms.TextBox txtRFIDTag;
        private System.Windows.Forms.Label lblTag;
        private System.Windows.Forms.ComboBox authorities;
        private System.Windows.Forms.Label lblAuthorities;
        private System.Windows.Forms.TextBox cpassword;
        private System.Windows.Forms.Label lblCpassword;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.TextBox email;
        private System.Windows.Forms.TextBox lastName;
        private System.Windows.Forms.TextBox position;
        private System.Windows.Forms.TextBox description;
        private System.Windows.Forms.TextBox firstName;
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
        private System.Windows.Forms.PictureBox imgCapture2;
        private System.Windows.Forms.PictureBox imgCapture1;
        private System.Windows.Forms.Label lblValidIDPhoto;
        private System.Windows.Forms.Label lblOwnerPhoto;
        private System.Windows.Forms.Button btnEditInfo;
        private System.Windows.Forms.DateTimePicker dtStartDate;
        private System.Windows.Forms.Label rbtnValidUntil;
        private System.Windows.Forms.Button CaptureImg;
        private System.Windows.Forms.Label lblSubmittingInformation;
        private System.Windows.Forms.Label lblLoadingInformation;
    }
}