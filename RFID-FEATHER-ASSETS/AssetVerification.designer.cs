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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblCurrentDateTime = new System.Windows.Forms.Label();
            this.VerifyTimer = new System.Windows.Forms.Timer(this.components);
            this.BackgroundTimer = new System.Windows.Forms.Timer(this.components);
            this.CurrentDateTimer = new System.Windows.Forms.Timer(this.components);
            this.ClearGridTimer = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnReport = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtOwnerName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtValidityPeriod = new System.Windows.Forms.TextBox();
            this.lblValidUntil = new System.Windows.Forms.Label();
            this.lblDesc = new System.Windows.Forms.Label();
            this.txtTakeOutNote = new System.Windows.Forms.TextBox();
            this.lblMemo = new System.Windows.Forms.Label();
            this.txtAssetName = new System.Windows.Forms.TextBox();
            this.txtRFIDTag = new System.Windows.Forms.TextBox();
            this.lblTag = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lblLoadingInformation = new System.Windows.Forms.Label();
            this.lblSubmittingInformation = new System.Windows.Forms.Label();
            this.lblAssetPhoto3 = new System.Windows.Forms.Label();
            this.lblAssetPhoto2 = new System.Windows.Forms.Label();
            this.lblAssetPhoto1 = new System.Windows.Forms.Label();
            this.lblValidIDPhoto = new System.Windows.Forms.Label();
            this.lblOwnerPhoto = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.lblOwnerPic = new System.Windows.Forms.Label();
            this.lblAssetPic = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.imgCapture5 = new System.Windows.Forms.PictureBox();
            this.imgCapture4 = new System.Windows.Forms.PictureBox();
            this.imgCapture3 = new System.Windows.Forms.PictureBox();
            this.imgCapture2 = new System.Windows.Forms.PictureBox();
            this.imgCapture1 = new System.Windows.Forms.PictureBox();
            this.grpBoxReportedInfo = new System.Windows.Forms.GroupBox();
            this.txtReportedNote = new System.Windows.Forms.TextBox();
            this.picPersonBroughtOut = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtOwnerDescription = new System.Windows.Forms.TextBox();
            this.btnVerifyAsset = new System.Windows.Forms.Button();
            this.txtOwnerPosition = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.picOwner = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grdViewRFIDTag = new System.Windows.Forms.DataGridView();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOwnerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAssetDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTakeOutNote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValidityPeriod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colViewerIcon = new System.Windows.Forms.DataGridViewImageColumn();
            this.colAssetID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIDTag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIDOwner = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAssetTag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAssetOwner = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRFIDTag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIsCompared = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblLoginUserName = new System.Windows.Forms.Label();
            this.ReadLoopTimer = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblSystemInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgCapture5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCapture4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCapture3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCapture2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCapture1)).BeginInit();
            this.grpBoxReportedInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPersonBroughtOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOwner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdViewRFIDTag)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCurrentDateTime
            // 
            resources.ApplyResources(this.lblCurrentDateTime, "lblCurrentDateTime");
            this.lblCurrentDateTime.BackColor = System.Drawing.Color.White;
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
            this.CurrentDateTimer.Tick += new System.EventHandler(this.CurrentDateTimer_Tick);
            // 
            // ClearGridTimer
            // 
            this.ClearGridTimer.Tick += new System.EventHandler(this.ClearGridTimer_Tick);
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.btnReport);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.lblLoadingInformation);
            this.groupBox1.Controls.Add(this.lblSubmittingInformation);
            this.groupBox1.Controls.Add(this.lblAssetPhoto3);
            this.groupBox1.Controls.Add(this.lblAssetPhoto2);
            this.groupBox1.Controls.Add(this.lblAssetPhoto1);
            this.groupBox1.Controls.Add(this.lblValidIDPhoto);
            this.groupBox1.Controls.Add(this.lblOwnerPhoto);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnBack);
            this.groupBox1.Controls.Add(this.btnSubmit);
            this.groupBox1.Controls.Add(this.lblOwnerPic);
            this.groupBox1.Controls.Add(this.lblAssetPic);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.imgCapture5);
            this.groupBox1.Controls.Add(this.imgCapture4);
            this.groupBox1.Controls.Add(this.imgCapture3);
            this.groupBox1.Controls.Add(this.imgCapture2);
            this.groupBox1.Controls.Add(this.imgCapture1);
            this.groupBox1.Controls.Add(this.grpBoxReportedInfo);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // btnReport
            // 
            resources.ApplyResources(this.btnReport, "btnReport");
            this.btnReport.BackColor = System.Drawing.Color.Orange;
            this.btnReport.Name = "btnReport";
            this.btnReport.UseVisualStyleBackColor = false;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // groupBox2
            // 
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Controls.Add(this.txtOwnerName);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtValidityPeriod);
            this.groupBox2.Controls.Add(this.lblValidUntil);
            this.groupBox2.Controls.Add(this.lblDesc);
            this.groupBox2.Controls.Add(this.txtTakeOutNote);
            this.groupBox2.Controls.Add(this.lblMemo);
            this.groupBox2.Controls.Add(this.txtAssetName);
            this.groupBox2.Controls.Add(this.txtRFIDTag);
            this.groupBox2.Controls.Add(this.lblTag);
            this.groupBox2.Controls.Add(this.txtDescription);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // txtOwnerName
            // 
            resources.ApplyResources(this.txtOwnerName, "txtOwnerName");
            this.txtOwnerName.BackColor = System.Drawing.Color.White;
            this.txtOwnerName.Name = "txtOwnerName";
            this.txtOwnerName.ReadOnly = true;
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // txtValidityPeriod
            // 
            resources.ApplyResources(this.txtValidityPeriod, "txtValidityPeriod");
            this.txtValidityPeriod.BackColor = System.Drawing.Color.White;
            this.txtValidityPeriod.Name = "txtValidityPeriod";
            this.txtValidityPeriod.ReadOnly = true;
            this.txtValidityPeriod.TabStop = false;
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
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
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
            // btnSubmit
            // 
            resources.ApplyResources(this.btnSubmit, "btnSubmit");
            this.btnSubmit.BackColor = System.Drawing.Color.Orange;
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
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
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // grdViewRFIDTag
            // 
            this.grdViewRFIDTag.AllowUserToAddRows = false;
            this.grdViewRFIDTag.AllowUserToDeleteRows = false;
            this.grdViewRFIDTag.AllowUserToResizeColumns = false;
            this.grdViewRFIDTag.AllowUserToResizeRows = false;
            this.grdViewRFIDTag.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdViewRFIDTag.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdViewRFIDTag.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            resources.ApplyResources(this.grdViewRFIDTag, "grdViewRFIDTag");
            this.grdViewRFIDTag.ColumnHeadersVisible = false;
            this.grdViewRFIDTag.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDate,
            this.colOwnerName,
            this.colAssetDescription,
            this.colTakeOutNote,
            this.colValidityPeriod,
            this.colStatus,
            this.colViewerIcon,
            this.colAssetID,
            this.colIDTag,
            this.colIDOwner,
            this.colAssetTag,
            this.colAssetOwner,
            this.colRFIDTag,
            this.colIsCompared});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdViewRFIDTag.DefaultCellStyle = dataGridViewCellStyle4;
            this.grdViewRFIDTag.Name = "grdViewRFIDTag";
            this.grdViewRFIDTag.ReadOnly = true;
            this.grdViewRFIDTag.RowHeadersVisible = false;
            this.grdViewRFIDTag.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdViewRFIDTag_CellContentDoubleClick);
            // 
            // colDate
            // 
            this.colDate.FillWeight = 120F;
            resources.ApplyResources(this.colDate, "colDate");
            this.colDate.Name = "colDate";
            this.colDate.ReadOnly = true;
            this.colDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colOwnerName
            // 
            this.colOwnerName.FillWeight = 130F;
            resources.ApplyResources(this.colOwnerName, "colOwnerName");
            this.colOwnerName.Name = "colOwnerName";
            this.colOwnerName.ReadOnly = true;
            this.colOwnerName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colAssetDescription
            // 
            this.colAssetDescription.FillWeight = 130F;
            resources.ApplyResources(this.colAssetDescription, "colAssetDescription");
            this.colAssetDescription.Name = "colAssetDescription";
            this.colAssetDescription.ReadOnly = true;
            this.colAssetDescription.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colTakeOutNote
            // 
            this.colTakeOutNote.FillWeight = 130.6182F;
            resources.ApplyResources(this.colTakeOutNote, "colTakeOutNote");
            this.colTakeOutNote.Name = "colTakeOutNote";
            this.colTakeOutNote.ReadOnly = true;
            this.colTakeOutNote.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colValidityPeriod
            // 
            this.colValidityPeriod.FillWeight = 180F;
            resources.ApplyResources(this.colValidityPeriod, "colValidityPeriod");
            this.colValidityPeriod.Name = "colValidityPeriod";
            this.colValidityPeriod.ReadOnly = true;
            this.colValidityPeriod.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colStatus
            // 
            this.colStatus.FillWeight = 120F;
            resources.ApplyResources(this.colStatus, "colStatus");
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            this.colStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colViewerIcon
            // 
            this.colViewerIcon.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            this.colViewerIcon.FillWeight = 120F;
            resources.ApplyResources(this.colViewerIcon, "colViewerIcon");
            this.colViewerIcon.Image = global::RFID_FEATHER_ASSETS.Properties.Resources.ViewDetailsIcon;
            this.colViewerIcon.Name = "colViewerIcon";
            this.colViewerIcon.ReadOnly = true;
            this.colViewerIcon.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colAssetID
            // 
            resources.ApplyResources(this.colAssetID, "colAssetID");
            this.colAssetID.Name = "colAssetID";
            this.colAssetID.ReadOnly = true;
            // 
            // colIDTag
            // 
            resources.ApplyResources(this.colIDTag, "colIDTag");
            this.colIDTag.Name = "colIDTag";
            this.colIDTag.ReadOnly = true;
            this.colIDTag.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colIDOwner
            // 
            resources.ApplyResources(this.colIDOwner, "colIDOwner");
            this.colIDOwner.Name = "colIDOwner";
            this.colIDOwner.ReadOnly = true;
            // 
            // colAssetTag
            // 
            resources.ApplyResources(this.colAssetTag, "colAssetTag");
            this.colAssetTag.Name = "colAssetTag";
            this.colAssetTag.ReadOnly = true;
            this.colAssetTag.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colAssetOwner
            // 
            resources.ApplyResources(this.colAssetOwner, "colAssetOwner");
            this.colAssetOwner.Name = "colAssetOwner";
            this.colAssetOwner.ReadOnly = true;
            // 
            // colRFIDTag
            // 
            resources.ApplyResources(this.colRFIDTag, "colRFIDTag");
            this.colRFIDTag.Name = "colRFIDTag";
            this.colRFIDTag.ReadOnly = true;
            // 
            // colIsCompared
            // 
            resources.ApplyResources(this.colIsCompared, "colIsCompared");
            this.colIsCompared.Name = "colIsCompared";
            this.colIsCompared.ReadOnly = true;
            this.colIsCompared.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // lblLoginUserName
            // 
            resources.ApplyResources(this.lblLoginUserName, "lblLoginUserName");
            this.lblLoginUserName.BackColor = System.Drawing.Color.White;
            this.lblLoginUserName.Name = "lblLoginUserName";
            // 
            // ReadLoopTimer
            // 
            this.ReadLoopTimer.Tick += new System.EventHandler(this.ReadLoopTimer_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblSystemInfo});
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.Name = "statusStrip1";
            // 
            // lblSystemInfo
            // 
            resources.ApplyResources(this.lblSystemInfo, "lblSystemInfo");
            this.lblSystemInfo.Name = "lblSystemInfo";
            this.lblSystemInfo.Spring = true;
            // 
            // Verification
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lblLoginUserName);
            this.Controls.Add(this.lblCurrentDateTime);
            this.Controls.Add(this.grdViewRFIDTag);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Verification";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Verification_FormClosed);
            this.Load += new System.EventHandler(this.Verification_Load);
            this.Shown += new System.EventHandler(this.Verification_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgCapture5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCapture4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCapture3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCapture2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCapture1)).EndInit();
            this.grpBoxReportedInfo.ResumeLayout(false);
            this.grpBoxReportedInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPersonBroughtOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOwner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdViewRFIDTag)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCurrentDateTime;
        private System.Windows.Forms.Timer VerifyTimer;
        private System.Windows.Forms.Timer BackgroundTimer;
        private System.Windows.Forms.Timer CurrentDateTimer;
        private System.Windows.Forms.Timer ClearGridTimer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox grpBoxReportedInfo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtOwnerDescription;
        private System.Windows.Forms.Button btnVerifyAsset;
        private System.Windows.Forms.TextBox txtOwnerPosition;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox picOwner;
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
        private System.Windows.Forms.PictureBox picPersonBroughtOut;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblValidIDPhoto;
        private System.Windows.Forms.Label lblOwnerPhoto;
        private System.Windows.Forms.Label lblAssetPhoto3;
        private System.Windows.Forms.Label lblAssetPhoto2;
        private System.Windows.Forms.Label lblAssetPhoto1;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label lblSubmittingInformation;
        private System.Windows.Forms.TextBox txtReportedNote;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.DataGridView grdViewRFIDTag;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtOwnerName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtValidityPeriod;
        private System.Windows.Forms.Label lblValidUntil;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.TextBox txtTakeOutNote;
        private System.Windows.Forms.Label lblMemo;
        private System.Windows.Forms.TextBox txtAssetName;
        private System.Windows.Forms.TextBox txtRFIDTag;
        private System.Windows.Forms.Label lblTag;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblLoginUserName;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Timer ReadLoopTimer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOwnerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAssetDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTakeOutNote;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValidityPeriod;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewImageColumn colViewerIcon;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAssetID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIDTag;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIDOwner;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAssetTag;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAssetOwner;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRFIDTag;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIsCompared;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblSystemInfo;


    }
}