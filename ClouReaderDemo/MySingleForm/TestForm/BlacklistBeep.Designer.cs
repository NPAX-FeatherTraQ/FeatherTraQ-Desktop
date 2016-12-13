namespace ClouReaderDemo.MySingleForm.TestForm
{
    partial class BlacklistBeep
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BlacklistBeep));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tc_Main = new ClouReaderDemo.MyFormTemplet.QQTabControl();
            this.tp_TagRead = new System.Windows.Forms.TabPage();
            this.gb_Read_Result = new System.Windows.Forms.GroupBox();
            this.gb_TagList = new System.Windows.Forms.GroupBox();
            this.dgv_Tags = new ClouReaderDemo.DataGridViewPlus();
            this.clm_TagType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm_EPC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm_TID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm_UserData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm_ReserveData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm_TotalCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm_ANT1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm_ANT2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm_ANT3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm_ANT4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm_RSSI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm_ReadTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gb_Read_Control = new System.Windows.Forms.GroupBox();
            this.btn_Clear = new ClouReaderDemo.MyFormTemplet.QQButton();
            this.btn_StopTest = new ClouReaderDemo.MyFormTemplet.QQButton();
            this.btn_StartReadTest = new ClouReaderDemo.MyFormTemplet.QQButton();
            this.tp_BlackList = new System.Windows.Forms.TabPage();
            this.cb_out_b_4 = new ClouReaderDemo.MyFormTemplet.QQCheckBox();
            this.cb_out_b_3 = new ClouReaderDemo.MyFormTemplet.QQCheckBox();
            this.cb_out_b_2 = new ClouReaderDemo.MyFormTemplet.QQCheckBox();
            this.cb_out_b_1 = new ClouReaderDemo.MyFormTemplet.QQCheckBox();
            this.btn_ClearBlackList = new ClouReaderDemo.MyFormTemplet.QQButton();
            this.btn_RemoveBlackList = new ClouReaderDemo.MyFormTemplet.QQButton();
            this.btn_AddBlackList = new ClouReaderDemo.MyFormTemplet.QQButton();
            this.lb_BlackList = new System.Windows.Forms.ListBox();
            this.tp_WhiteList = new System.Windows.Forms.TabPage();
            this.cb_out_w_4 = new ClouReaderDemo.MyFormTemplet.QQCheckBox();
            this.cb_out_w_3 = new ClouReaderDemo.MyFormTemplet.QQCheckBox();
            this.cb_out_w_2 = new ClouReaderDemo.MyFormTemplet.QQCheckBox();
            this.cb_out_w_1 = new ClouReaderDemo.MyFormTemplet.QQCheckBox();
            this.btn_ClearWriteList = new ClouReaderDemo.MyFormTemplet.QQButton();
            this.btn_RemoveWriteList = new ClouReaderDemo.MyFormTemplet.QQButton();
            this.btn_AddWiteList = new ClouReaderDemo.MyFormTemplet.QQButton();
            this.lb_Witelist = new System.Windows.Forms.ListBox();
            this.tp_Debug = new System.Windows.Forms.TabPage();
            this.tb_Msg = new System.Windows.Forms.TextBox();
            this.tc_Main.SuspendLayout();
            this.tp_TagRead.SuspendLayout();
            this.gb_Read_Result.SuspendLayout();
            this.gb_TagList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Tags)).BeginInit();
            this.gb_Read_Control.SuspendLayout();
            this.tp_BlackList.SuspendLayout();
            this.tp_WhiteList.SuspendLayout();
            this.tp_Debug.SuspendLayout();
            this.SuspendLayout();
            // 
            // tc_Main
            // 
            resources.ApplyResources(this.tc_Main, "tc_Main");
            this.tc_Main.BackColor = System.Drawing.Color.Transparent;
            this.tc_Main.BaseColor = System.Drawing.Color.White;
            this.tc_Main.BorderColor = System.Drawing.Color.White;
            this.tc_Main.Controls.Add(this.tp_TagRead);
            this.tc_Main.Controls.Add(this.tp_BlackList);
            this.tc_Main.Controls.Add(this.tp_WhiteList);
            this.tc_Main.Controls.Add(this.tp_Debug);
            this.tc_Main.Name = "tc_Main";
            this.tc_Main.PageColor = System.Drawing.Color.White;
            this.tc_Main.SelectedIndex = 0;
            this.tc_Main.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            // 
            // tp_TagRead
            // 
            resources.ApplyResources(this.tp_TagRead, "tp_TagRead");
            this.tp_TagRead.BackColor = System.Drawing.Color.White;
            this.tp_TagRead.Controls.Add(this.gb_Read_Result);
            this.tp_TagRead.Controls.Add(this.gb_Read_Control);
            this.tp_TagRead.Name = "tp_TagRead";
            // 
            // gb_Read_Result
            // 
            resources.ApplyResources(this.gb_Read_Result, "gb_Read_Result");
            this.gb_Read_Result.BackColor = System.Drawing.Color.White;
            this.gb_Read_Result.Controls.Add(this.gb_TagList);
            this.gb_Read_Result.Name = "gb_Read_Result";
            this.gb_Read_Result.TabStop = false;
            // 
            // gb_TagList
            // 
            resources.ApplyResources(this.gb_TagList, "gb_TagList");
            this.gb_TagList.Controls.Add(this.dgv_Tags);
            this.gb_TagList.Name = "gb_TagList";
            this.gb_TagList.TabStop = false;
            // 
            // dgv_Tags
            // 
            resources.ApplyResources(this.dgv_Tags, "dgv_Tags");
            this.dgv_Tags.AllowUserToAddRows = false;
            this.dgv_Tags.AllowUserToDeleteRows = false;
            this.dgv_Tags.AllowUserToResizeRows = false;
            this.dgv_Tags.BackgroundColor = System.Drawing.Color.White;
            this.dgv_Tags.CausesValidation = false;
            this.dgv_Tags.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.dgv_Tags.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clm_TagType,
            this.clm_EPC,
            this.clm_TID,
            this.clm_UserData,
            this.clm_ReserveData,
            this.clm_TotalCount,
            this.clm_ANT1,
            this.clm_ANT2,
            this.clm_ANT3,
            this.clm_ANT4,
            this.clm_RSSI,
            this.clm_ReadTime});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Tags.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Tags.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.dgv_Tags.MultiSelect = false;
            this.dgv_Tags.Name = "dgv_Tags";
            this.dgv_Tags.ReadOnly = true;
            this.dgv_Tags.RowTemplate.Height = 23;
            // 
            // clm_TagType
            // 
            resources.ApplyResources(this.clm_TagType, "clm_TagType");
            this.clm_TagType.Name = "clm_TagType";
            this.clm_TagType.ReadOnly = true;
            // 
            // clm_EPC
            // 
            this.clm_EPC.DataPropertyName = "EPC";
            resources.ApplyResources(this.clm_EPC, "clm_EPC");
            this.clm_EPC.Name = "clm_EPC";
            this.clm_EPC.ReadOnly = true;
            // 
            // clm_TID
            // 
            this.clm_TID.DataPropertyName = "TID";
            resources.ApplyResources(this.clm_TID, "clm_TID");
            this.clm_TID.Name = "clm_TID";
            this.clm_TID.ReadOnly = true;
            // 
            // clm_UserData
            // 
            this.clm_UserData.DataPropertyName = "UserData";
            resources.ApplyResources(this.clm_UserData, "clm_UserData");
            this.clm_UserData.Name = "clm_UserData";
            this.clm_UserData.ReadOnly = true;
            // 
            // clm_ReserveData
            // 
            resources.ApplyResources(this.clm_ReserveData, "clm_ReserveData");
            this.clm_ReserveData.Name = "clm_ReserveData";
            this.clm_ReserveData.ReadOnly = true;
            // 
            // clm_TotalCount
            // 
            this.clm_TotalCount.DataPropertyName = "TotalCount";
            resources.ApplyResources(this.clm_TotalCount, "clm_TotalCount");
            this.clm_TotalCount.Name = "clm_TotalCount";
            this.clm_TotalCount.ReadOnly = true;
            // 
            // clm_ANT1
            // 
            this.clm_ANT1.DataPropertyName = "ANT1_COUNT";
            resources.ApplyResources(this.clm_ANT1, "clm_ANT1");
            this.clm_ANT1.Name = "clm_ANT1";
            this.clm_ANT1.ReadOnly = true;
            // 
            // clm_ANT2
            // 
            this.clm_ANT2.DataPropertyName = "ANT2_COUNT";
            resources.ApplyResources(this.clm_ANT2, "clm_ANT2");
            this.clm_ANT2.Name = "clm_ANT2";
            this.clm_ANT2.ReadOnly = true;
            // 
            // clm_ANT3
            // 
            this.clm_ANT3.DataPropertyName = "ANT3_COUNT";
            resources.ApplyResources(this.clm_ANT3, "clm_ANT3");
            this.clm_ANT3.Name = "clm_ANT3";
            this.clm_ANT3.ReadOnly = true;
            // 
            // clm_ANT4
            // 
            this.clm_ANT4.DataPropertyName = "ANT4_COUNT";
            resources.ApplyResources(this.clm_ANT4, "clm_ANT4");
            this.clm_ANT4.Name = "clm_ANT4";
            this.clm_ANT4.ReadOnly = true;
            // 
            // clm_RSSI
            // 
            resources.ApplyResources(this.clm_RSSI, "clm_RSSI");
            this.clm_RSSI.Name = "clm_RSSI";
            this.clm_RSSI.ReadOnly = true;
            // 
            // clm_ReadTime
            // 
            resources.ApplyResources(this.clm_ReadTime, "clm_ReadTime");
            this.clm_ReadTime.Name = "clm_ReadTime";
            this.clm_ReadTime.ReadOnly = true;
            // 
            // gb_Read_Control
            // 
            resources.ApplyResources(this.gb_Read_Control, "gb_Read_Control");
            this.gb_Read_Control.Controls.Add(this.btn_Clear);
            this.gb_Read_Control.Controls.Add(this.btn_StopTest);
            this.gb_Read_Control.Controls.Add(this.btn_StartReadTest);
            this.gb_Read_Control.Name = "gb_Read_Control";
            this.gb_Read_Control.TabStop = false;
            // 
            // btn_Clear
            // 
            resources.ApplyResources(this.btn_Clear, "btn_Clear");
            this.btn_Clear.BackColor = System.Drawing.Color.Transparent;
            this.btn_Clear.DownImage = ((System.Drawing.Image)(resources.GetObject("btn_Clear.DownImage")));
            this.btn_Clear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_Clear.IsShowBorder = true;
            this.btn_Clear.MoveImage = ((System.Drawing.Image)(resources.GetObject("btn_Clear.MoveImage")));
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.NormalImage = ((System.Drawing.Image)(resources.GetObject("btn_Clear.NormalImage")));
            this.btn_Clear.Tag = "0";
            this.btn_Clear.UseVisualStyleBackColor = false;
            this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click);
            // 
            // btn_StopTest
            // 
            resources.ApplyResources(this.btn_StopTest, "btn_StopTest");
            this.btn_StopTest.BackColor = System.Drawing.Color.Transparent;
            this.btn_StopTest.DownImage = ((System.Drawing.Image)(resources.GetObject("btn_StopTest.DownImage")));
            this.btn_StopTest.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_StopTest.IsShowBorder = true;
            this.btn_StopTest.MoveImage = ((System.Drawing.Image)(resources.GetObject("btn_StopTest.MoveImage")));
            this.btn_StopTest.Name = "btn_StopTest";
            this.btn_StopTest.NormalImage = ((System.Drawing.Image)(resources.GetObject("btn_StopTest.NormalImage")));
            this.btn_StopTest.Tag = "0";
            this.btn_StopTest.UseVisualStyleBackColor = false;
            this.btn_StopTest.Click += new System.EventHandler(this.btn_StopTest_Click);
            // 
            // btn_StartReadTest
            // 
            resources.ApplyResources(this.btn_StartReadTest, "btn_StartReadTest");
            this.btn_StartReadTest.BackColor = System.Drawing.Color.Transparent;
            this.btn_StartReadTest.DownImage = ((System.Drawing.Image)(resources.GetObject("btn_StartReadTest.DownImage")));
            this.btn_StartReadTest.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_StartReadTest.IsShowBorder = true;
            this.btn_StartReadTest.MoveImage = ((System.Drawing.Image)(resources.GetObject("btn_StartReadTest.MoveImage")));
            this.btn_StartReadTest.Name = "btn_StartReadTest";
            this.btn_StartReadTest.NormalImage = ((System.Drawing.Image)(resources.GetObject("btn_StartReadTest.NormalImage")));
            this.btn_StartReadTest.Tag = "0";
            this.btn_StartReadTest.UseVisualStyleBackColor = false;
            this.btn_StartReadTest.Click += new System.EventHandler(this.btn_StartReadTest_Click);
            // 
            // tp_BlackList
            // 
            resources.ApplyResources(this.tp_BlackList, "tp_BlackList");
            this.tp_BlackList.BackColor = System.Drawing.Color.White;
            this.tp_BlackList.Controls.Add(this.cb_out_b_4);
            this.tp_BlackList.Controls.Add(this.cb_out_b_3);
            this.tp_BlackList.Controls.Add(this.cb_out_b_2);
            this.tp_BlackList.Controls.Add(this.cb_out_b_1);
            this.tp_BlackList.Controls.Add(this.btn_ClearBlackList);
            this.tp_BlackList.Controls.Add(this.btn_RemoveBlackList);
            this.tp_BlackList.Controls.Add(this.btn_AddBlackList);
            this.tp_BlackList.Controls.Add(this.lb_BlackList);
            this.tp_BlackList.Name = "tp_BlackList";
            // 
            // cb_out_b_4
            // 
            resources.ApplyResources(this.cb_out_b_4, "cb_out_b_4");
            this.cb_out_b_4.BackColor = System.Drawing.Color.Transparent;
            this.cb_out_b_4.Name = "cb_out_b_4";
            this.cb_out_b_4.Tag = "4";
            this.cb_out_b_4.UseVisualStyleBackColor = false;
            // 
            // cb_out_b_3
            // 
            resources.ApplyResources(this.cb_out_b_3, "cb_out_b_3");
            this.cb_out_b_3.BackColor = System.Drawing.Color.Transparent;
            this.cb_out_b_3.Name = "cb_out_b_3";
            this.cb_out_b_3.Tag = "3";
            this.cb_out_b_3.UseVisualStyleBackColor = false;
            // 
            // cb_out_b_2
            // 
            resources.ApplyResources(this.cb_out_b_2, "cb_out_b_2");
            this.cb_out_b_2.BackColor = System.Drawing.Color.Transparent;
            this.cb_out_b_2.Name = "cb_out_b_2";
            this.cb_out_b_2.Tag = "2";
            this.cb_out_b_2.UseVisualStyleBackColor = false;
            // 
            // cb_out_b_1
            // 
            resources.ApplyResources(this.cb_out_b_1, "cb_out_b_1");
            this.cb_out_b_1.BackColor = System.Drawing.Color.Transparent;
            this.cb_out_b_1.Name = "cb_out_b_1";
            this.cb_out_b_1.Tag = "1";
            this.cb_out_b_1.UseVisualStyleBackColor = false;
            // 
            // btn_ClearBlackList
            // 
            resources.ApplyResources(this.btn_ClearBlackList, "btn_ClearBlackList");
            this.btn_ClearBlackList.BackColor = System.Drawing.Color.Transparent;
            this.btn_ClearBlackList.DownImage = ((System.Drawing.Image)(resources.GetObject("btn_ClearBlackList.DownImage")));
            this.btn_ClearBlackList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_ClearBlackList.IsShowBorder = true;
            this.btn_ClearBlackList.MoveImage = ((System.Drawing.Image)(resources.GetObject("btn_ClearBlackList.MoveImage")));
            this.btn_ClearBlackList.Name = "btn_ClearBlackList";
            this.btn_ClearBlackList.NormalImage = ((System.Drawing.Image)(resources.GetObject("btn_ClearBlackList.NormalImage")));
            this.btn_ClearBlackList.Tag = "0";
            this.btn_ClearBlackList.UseVisualStyleBackColor = false;
            this.btn_ClearBlackList.Click += new System.EventHandler(this.btn_ClearBlackList_Click);
            // 
            // btn_RemoveBlackList
            // 
            resources.ApplyResources(this.btn_RemoveBlackList, "btn_RemoveBlackList");
            this.btn_RemoveBlackList.BackColor = System.Drawing.Color.Transparent;
            this.btn_RemoveBlackList.DownImage = ((System.Drawing.Image)(resources.GetObject("btn_RemoveBlackList.DownImage")));
            this.btn_RemoveBlackList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_RemoveBlackList.IsShowBorder = true;
            this.btn_RemoveBlackList.MoveImage = ((System.Drawing.Image)(resources.GetObject("btn_RemoveBlackList.MoveImage")));
            this.btn_RemoveBlackList.Name = "btn_RemoveBlackList";
            this.btn_RemoveBlackList.NormalImage = ((System.Drawing.Image)(resources.GetObject("btn_RemoveBlackList.NormalImage")));
            this.btn_RemoveBlackList.Tag = "0";
            this.btn_RemoveBlackList.UseVisualStyleBackColor = false;
            this.btn_RemoveBlackList.Click += new System.EventHandler(this.btn_RemoveBlackList_Click);
            // 
            // btn_AddBlackList
            // 
            resources.ApplyResources(this.btn_AddBlackList, "btn_AddBlackList");
            this.btn_AddBlackList.BackColor = System.Drawing.Color.Transparent;
            this.btn_AddBlackList.DownImage = ((System.Drawing.Image)(resources.GetObject("btn_AddBlackList.DownImage")));
            this.btn_AddBlackList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_AddBlackList.IsShowBorder = true;
            this.btn_AddBlackList.MoveImage = ((System.Drawing.Image)(resources.GetObject("btn_AddBlackList.MoveImage")));
            this.btn_AddBlackList.Name = "btn_AddBlackList";
            this.btn_AddBlackList.NormalImage = ((System.Drawing.Image)(resources.GetObject("btn_AddBlackList.NormalImage")));
            this.btn_AddBlackList.Tag = "0";
            this.btn_AddBlackList.UseVisualStyleBackColor = false;
            this.btn_AddBlackList.Click += new System.EventHandler(this.btn_AddBlackList_Click);
            // 
            // lb_BlackList
            // 
            resources.ApplyResources(this.lb_BlackList, "lb_BlackList");
            this.lb_BlackList.FormattingEnabled = true;
            this.lb_BlackList.Name = "lb_BlackList";
            // 
            // tp_WhiteList
            // 
            resources.ApplyResources(this.tp_WhiteList, "tp_WhiteList");
            this.tp_WhiteList.BackColor = System.Drawing.Color.White;
            this.tp_WhiteList.Controls.Add(this.cb_out_w_4);
            this.tp_WhiteList.Controls.Add(this.cb_out_w_3);
            this.tp_WhiteList.Controls.Add(this.cb_out_w_2);
            this.tp_WhiteList.Controls.Add(this.cb_out_w_1);
            this.tp_WhiteList.Controls.Add(this.btn_ClearWriteList);
            this.tp_WhiteList.Controls.Add(this.btn_RemoveWriteList);
            this.tp_WhiteList.Controls.Add(this.btn_AddWiteList);
            this.tp_WhiteList.Controls.Add(this.lb_Witelist);
            this.tp_WhiteList.Name = "tp_WhiteList";
            // 
            // cb_out_w_4
            // 
            resources.ApplyResources(this.cb_out_w_4, "cb_out_w_4");
            this.cb_out_w_4.BackColor = System.Drawing.Color.Transparent;
            this.cb_out_w_4.Name = "cb_out_w_4";
            this.cb_out_w_4.Tag = "4";
            this.cb_out_w_4.UseVisualStyleBackColor = false;
            // 
            // cb_out_w_3
            // 
            resources.ApplyResources(this.cb_out_w_3, "cb_out_w_3");
            this.cb_out_w_3.BackColor = System.Drawing.Color.Transparent;
            this.cb_out_w_3.Name = "cb_out_w_3";
            this.cb_out_w_3.Tag = "3";
            this.cb_out_w_3.UseVisualStyleBackColor = false;
            // 
            // cb_out_w_2
            // 
            resources.ApplyResources(this.cb_out_w_2, "cb_out_w_2");
            this.cb_out_w_2.BackColor = System.Drawing.Color.Transparent;
            this.cb_out_w_2.Name = "cb_out_w_2";
            this.cb_out_w_2.Tag = "2";
            this.cb_out_w_2.UseVisualStyleBackColor = false;
            // 
            // cb_out_w_1
            // 
            resources.ApplyResources(this.cb_out_w_1, "cb_out_w_1");
            this.cb_out_w_1.BackColor = System.Drawing.Color.Transparent;
            this.cb_out_w_1.Name = "cb_out_w_1";
            this.cb_out_w_1.Tag = "1";
            this.cb_out_w_1.UseVisualStyleBackColor = false;
            // 
            // btn_ClearWriteList
            // 
            resources.ApplyResources(this.btn_ClearWriteList, "btn_ClearWriteList");
            this.btn_ClearWriteList.BackColor = System.Drawing.Color.Transparent;
            this.btn_ClearWriteList.DownImage = ((System.Drawing.Image)(resources.GetObject("btn_ClearWriteList.DownImage")));
            this.btn_ClearWriteList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_ClearWriteList.IsShowBorder = true;
            this.btn_ClearWriteList.MoveImage = ((System.Drawing.Image)(resources.GetObject("btn_ClearWriteList.MoveImage")));
            this.btn_ClearWriteList.Name = "btn_ClearWriteList";
            this.btn_ClearWriteList.NormalImage = ((System.Drawing.Image)(resources.GetObject("btn_ClearWriteList.NormalImage")));
            this.btn_ClearWriteList.Tag = "0";
            this.btn_ClearWriteList.UseVisualStyleBackColor = false;
            this.btn_ClearWriteList.Click += new System.EventHandler(this.btn_ClearWiteList_Click);
            // 
            // btn_RemoveWriteList
            // 
            resources.ApplyResources(this.btn_RemoveWriteList, "btn_RemoveWriteList");
            this.btn_RemoveWriteList.BackColor = System.Drawing.Color.Transparent;
            this.btn_RemoveWriteList.DownImage = ((System.Drawing.Image)(resources.GetObject("btn_RemoveWriteList.DownImage")));
            this.btn_RemoveWriteList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_RemoveWriteList.IsShowBorder = true;
            this.btn_RemoveWriteList.MoveImage = ((System.Drawing.Image)(resources.GetObject("btn_RemoveWriteList.MoveImage")));
            this.btn_RemoveWriteList.Name = "btn_RemoveWriteList";
            this.btn_RemoveWriteList.NormalImage = ((System.Drawing.Image)(resources.GetObject("btn_RemoveWriteList.NormalImage")));
            this.btn_RemoveWriteList.Tag = "0";
            this.btn_RemoveWriteList.UseVisualStyleBackColor = false;
            this.btn_RemoveWriteList.Click += new System.EventHandler(this.btn_RemoveWiteList_Click);
            // 
            // btn_AddWiteList
            // 
            resources.ApplyResources(this.btn_AddWiteList, "btn_AddWiteList");
            this.btn_AddWiteList.BackColor = System.Drawing.Color.Transparent;
            this.btn_AddWiteList.DownImage = ((System.Drawing.Image)(resources.GetObject("btn_AddWiteList.DownImage")));
            this.btn_AddWiteList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_AddWiteList.IsShowBorder = true;
            this.btn_AddWiteList.MoveImage = ((System.Drawing.Image)(resources.GetObject("btn_AddWiteList.MoveImage")));
            this.btn_AddWiteList.Name = "btn_AddWiteList";
            this.btn_AddWiteList.NormalImage = ((System.Drawing.Image)(resources.GetObject("btn_AddWiteList.NormalImage")));
            this.btn_AddWiteList.Tag = "0";
            this.btn_AddWiteList.UseVisualStyleBackColor = false;
            this.btn_AddWiteList.Click += new System.EventHandler(this.btn_AddWiteList_Click);
            // 
            // lb_Witelist
            // 
            resources.ApplyResources(this.lb_Witelist, "lb_Witelist");
            this.lb_Witelist.FormattingEnabled = true;
            this.lb_Witelist.Name = "lb_Witelist";
            // 
            // tp_Debug
            // 
            resources.ApplyResources(this.tp_Debug, "tp_Debug");
            this.tp_Debug.BackColor = System.Drawing.Color.White;
            this.tp_Debug.Controls.Add(this.tb_Msg);
            this.tp_Debug.Name = "tp_Debug";
            // 
            // tb_Msg
            // 
            resources.ApplyResources(this.tb_Msg, "tb_Msg");
            this.tb_Msg.Name = "tb_Msg";
            // 
            // BlacklistBeep
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tc_Main);
            this.IsResize = false;
            this.Name = "BlacklistBeep";
            this.ShowIcon = false;
            this.SysButton = ClouReaderDemo.Forms.ESysButton.Close;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BlacklistBeep_FormClosing);
            this.Load += new System.EventHandler(this.BlacklistBeep_Load);
            this.tc_Main.ResumeLayout(false);
            this.tp_TagRead.ResumeLayout(false);
            this.gb_Read_Result.ResumeLayout(false);
            this.gb_TagList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Tags)).EndInit();
            this.gb_Read_Control.ResumeLayout(false);
            this.tp_BlackList.ResumeLayout(false);
            this.tp_BlackList.PerformLayout();
            this.tp_WhiteList.ResumeLayout(false);
            this.tp_WhiteList.PerformLayout();
            this.tp_Debug.ResumeLayout(false);
            this.tp_Debug.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MyFormTemplet.QQTabControl tc_Main;
        private System.Windows.Forms.TabPage tp_TagRead;
        private System.Windows.Forms.GroupBox gb_Read_Result;
        private System.Windows.Forms.GroupBox gb_TagList;
        private DataGridViewPlus dgv_Tags;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_TagType;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_EPC;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_TID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_UserData;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_ReserveData;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_TotalCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_ANT1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_ANT2;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_ANT3;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_ANT4;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_RSSI;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_ReadTime;
        private System.Windows.Forms.GroupBox gb_Read_Control;
        private MyFormTemplet.QQButton btn_Clear;
        private MyFormTemplet.QQButton btn_StopTest;
        private MyFormTemplet.QQButton btn_StartReadTest;
        private System.Windows.Forms.TabPage tp_BlackList;
        private MyFormTemplet.QQButton btn_ClearBlackList;
        private MyFormTemplet.QQButton btn_RemoveBlackList;
        private MyFormTemplet.QQButton btn_AddBlackList;
        private System.Windows.Forms.ListBox lb_BlackList;
        private System.Windows.Forms.TabPage tp_Debug;
        private System.Windows.Forms.TextBox tb_Msg;
        private System.Windows.Forms.TabPage tp_WhiteList;
        private MyFormTemplet.QQCheckBox cb_out_b_4;
        private MyFormTemplet.QQCheckBox cb_out_b_3;
        private MyFormTemplet.QQCheckBox cb_out_b_2;
        private MyFormTemplet.QQCheckBox cb_out_b_1;
        private MyFormTemplet.QQCheckBox cb_out_w_4;
        private MyFormTemplet.QQCheckBox cb_out_w_3;
        private MyFormTemplet.QQCheckBox cb_out_w_2;
        private MyFormTemplet.QQCheckBox cb_out_w_1;
        private MyFormTemplet.QQButton btn_ClearWriteList;
        private MyFormTemplet.QQButton btn_RemoveWriteList;
        private MyFormTemplet.QQButton btn_AddWiteList;
        private System.Windows.Forms.ListBox lb_Witelist;
    }
}