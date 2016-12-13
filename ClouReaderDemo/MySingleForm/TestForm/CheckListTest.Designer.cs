namespace ClouReaderDemo.MySingleForm.TestForm
{
    partial class CheckListTest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CheckListTest));
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
            this.label1 = new System.Windows.Forms.Label();
            this.lb_TagCount = new System.Windows.Forms.Label();
            this.btn_Reset = new ClouReaderDemo.MyFormTemplet.QQButton();
            this.btn_Clear = new ClouReaderDemo.MyFormTemplet.QQButton();
            this.btn_StopTest = new ClouReaderDemo.MyFormTemplet.QQButton();
            this.btn_StartReadTest = new ClouReaderDemo.MyFormTemplet.QQButton();
            this.tp_CheckList = new System.Windows.Forms.TabPage();
            this.btn_ = new ClouReaderDemo.MyFormTemplet.QQButton();
            this.btn_ClearCheckList = new ClouReaderDemo.MyFormTemplet.QQButton();
            this.btn_RemoveCheckList = new ClouReaderDemo.MyFormTemplet.QQButton();
            this.btn_AddCheckList = new ClouReaderDemo.MyFormTemplet.QQButton();
            this.lb_CheckList = new System.Windows.Forms.ListBox();
            this.tp_BeepTest = new System.Windows.Forms.TabPage();
            this.cb_out_w_4 = new ClouReaderDemo.MyFormTemplet.QQCheckBox();
            this.cb_out_w_3 = new ClouReaderDemo.MyFormTemplet.QQCheckBox();
            this.cb_out_w_2 = new ClouReaderDemo.MyFormTemplet.QQCheckBox();
            this.cb_out_w_1 = new ClouReaderDemo.MyFormTemplet.QQCheckBox();
            this.btn_GPO_Stop = new ClouReaderDemo.MyFormTemplet.QQButton();
            this.btn_GPO_down = new ClouReaderDemo.MyFormTemplet.QQButton();
            this.btn_GPO_up = new ClouReaderDemo.MyFormTemplet.QQButton();
            this.tp_Debug = new System.Windows.Forms.TabPage();
            this.tb_Msg = new System.Windows.Forms.TextBox();
            this.tc_Main.SuspendLayout();
            this.tp_TagRead.SuspendLayout();
            this.gb_Read_Result.SuspendLayout();
            this.gb_TagList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Tags)).BeginInit();
            this.gb_Read_Control.SuspendLayout();
            this.tp_CheckList.SuspendLayout();
            this.tp_BeepTest.SuspendLayout();
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
            this.tc_Main.Controls.Add(this.tp_CheckList);
            this.tc_Main.Controls.Add(this.tp_BeepTest);
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
            this.gb_Read_Control.Controls.Add(this.label1);
            this.gb_Read_Control.Controls.Add(this.lb_TagCount);
            this.gb_Read_Control.Controls.Add(this.btn_Reset);
            this.gb_Read_Control.Controls.Add(this.btn_Clear);
            this.gb_Read_Control.Controls.Add(this.btn_StopTest);
            this.gb_Read_Control.Controls.Add(this.btn_StartReadTest);
            this.gb_Read_Control.Name = "gb_Read_Control";
            this.gb_Read_Control.TabStop = false;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // lb_TagCount
            // 
            resources.ApplyResources(this.lb_TagCount, "lb_TagCount");
            this.lb_TagCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lb_TagCount.Name = "lb_TagCount";
            // 
            // btn_Reset
            // 
            resources.ApplyResources(this.btn_Reset, "btn_Reset");
            this.btn_Reset.BackColor = System.Drawing.Color.Transparent;
            this.btn_Reset.DownImage = ((System.Drawing.Image)(resources.GetObject("btn_Reset.DownImage")));
            this.btn_Reset.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_Reset.IsShowBorder = true;
            this.btn_Reset.MoveImage = ((System.Drawing.Image)(resources.GetObject("btn_Reset.MoveImage")));
            this.btn_Reset.Name = "btn_Reset";
            this.btn_Reset.NormalImage = ((System.Drawing.Image)(resources.GetObject("btn_Reset.NormalImage")));
            this.btn_Reset.Tag = "0";
            this.btn_Reset.UseVisualStyleBackColor = false;
            this.btn_Reset.Click += new System.EventHandler(this.btn_Reset_Click);
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
            // tp_CheckList
            // 
            resources.ApplyResources(this.tp_CheckList, "tp_CheckList");
            this.tp_CheckList.BackColor = System.Drawing.Color.White;
            this.tp_CheckList.Controls.Add(this.btn_);
            this.tp_CheckList.Controls.Add(this.btn_ClearCheckList);
            this.tp_CheckList.Controls.Add(this.btn_RemoveCheckList);
            this.tp_CheckList.Controls.Add(this.btn_AddCheckList);
            this.tp_CheckList.Controls.Add(this.lb_CheckList);
            this.tp_CheckList.Name = "tp_CheckList";
            // 
            // btn_
            // 
            resources.ApplyResources(this.btn_, "btn_");
            this.btn_.BackColor = System.Drawing.Color.Transparent;
            this.btn_.DownImage = ((System.Drawing.Image)(resources.GetObject("btn_.DownImage")));
            this.btn_.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_.IsShowBorder = true;
            this.btn_.MoveImage = ((System.Drawing.Image)(resources.GetObject("btn_.MoveImage")));
            this.btn_.Name = "btn_";
            this.btn_.NormalImage = ((System.Drawing.Image)(resources.GetObject("btn_.NormalImage")));
            this.btn_.Tag = "0";
            this.btn_.UseVisualStyleBackColor = false;
            this.btn_.Click += new System.EventHandler(this.btn__Click);
            // 
            // btn_ClearCheckList
            // 
            resources.ApplyResources(this.btn_ClearCheckList, "btn_ClearCheckList");
            this.btn_ClearCheckList.BackColor = System.Drawing.Color.Transparent;
            this.btn_ClearCheckList.DownImage = ((System.Drawing.Image)(resources.GetObject("btn_ClearCheckList.DownImage")));
            this.btn_ClearCheckList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_ClearCheckList.IsShowBorder = true;
            this.btn_ClearCheckList.MoveImage = ((System.Drawing.Image)(resources.GetObject("btn_ClearCheckList.MoveImage")));
            this.btn_ClearCheckList.Name = "btn_ClearCheckList";
            this.btn_ClearCheckList.NormalImage = ((System.Drawing.Image)(resources.GetObject("btn_ClearCheckList.NormalImage")));
            this.btn_ClearCheckList.Tag = "0";
            this.btn_ClearCheckList.UseVisualStyleBackColor = false;
            this.btn_ClearCheckList.Click += new System.EventHandler(this.btn_ClearCheckList_Click);
            // 
            // btn_RemoveCheckList
            // 
            resources.ApplyResources(this.btn_RemoveCheckList, "btn_RemoveCheckList");
            this.btn_RemoveCheckList.BackColor = System.Drawing.Color.Transparent;
            this.btn_RemoveCheckList.DownImage = ((System.Drawing.Image)(resources.GetObject("btn_RemoveCheckList.DownImage")));
            this.btn_RemoveCheckList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_RemoveCheckList.IsShowBorder = true;
            this.btn_RemoveCheckList.MoveImage = ((System.Drawing.Image)(resources.GetObject("btn_RemoveCheckList.MoveImage")));
            this.btn_RemoveCheckList.Name = "btn_RemoveCheckList";
            this.btn_RemoveCheckList.NormalImage = ((System.Drawing.Image)(resources.GetObject("btn_RemoveCheckList.NormalImage")));
            this.btn_RemoveCheckList.Tag = "0";
            this.btn_RemoveCheckList.UseVisualStyleBackColor = false;
            this.btn_RemoveCheckList.Click += new System.EventHandler(this.btn_RemoveCheckList_Click);
            // 
            // btn_AddCheckList
            // 
            resources.ApplyResources(this.btn_AddCheckList, "btn_AddCheckList");
            this.btn_AddCheckList.BackColor = System.Drawing.Color.Transparent;
            this.btn_AddCheckList.DownImage = ((System.Drawing.Image)(resources.GetObject("btn_AddCheckList.DownImage")));
            this.btn_AddCheckList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_AddCheckList.IsShowBorder = true;
            this.btn_AddCheckList.MoveImage = ((System.Drawing.Image)(resources.GetObject("btn_AddCheckList.MoveImage")));
            this.btn_AddCheckList.Name = "btn_AddCheckList";
            this.btn_AddCheckList.NormalImage = ((System.Drawing.Image)(resources.GetObject("btn_AddCheckList.NormalImage")));
            this.btn_AddCheckList.Tag = "0";
            this.btn_AddCheckList.UseVisualStyleBackColor = false;
            this.btn_AddCheckList.Click += new System.EventHandler(this.btn_AddCheckList_Click);
            // 
            // lb_CheckList
            // 
            resources.ApplyResources(this.lb_CheckList, "lb_CheckList");
            this.lb_CheckList.FormattingEnabled = true;
            this.lb_CheckList.Name = "lb_CheckList";
            // 
            // tp_BeepTest
            // 
            resources.ApplyResources(this.tp_BeepTest, "tp_BeepTest");
            this.tp_BeepTest.BackColor = System.Drawing.Color.White;
            this.tp_BeepTest.Controls.Add(this.cb_out_w_4);
            this.tp_BeepTest.Controls.Add(this.cb_out_w_3);
            this.tp_BeepTest.Controls.Add(this.cb_out_w_2);
            this.tp_BeepTest.Controls.Add(this.cb_out_w_1);
            this.tp_BeepTest.Controls.Add(this.btn_GPO_Stop);
            this.tp_BeepTest.Controls.Add(this.btn_GPO_down);
            this.tp_BeepTest.Controls.Add(this.btn_GPO_up);
            this.tp_BeepTest.Name = "tp_BeepTest";
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
            // btn_GPO_Stop
            // 
            resources.ApplyResources(this.btn_GPO_Stop, "btn_GPO_Stop");
            this.btn_GPO_Stop.BackColor = System.Drawing.Color.Transparent;
            this.btn_GPO_Stop.DownImage = ((System.Drawing.Image)(resources.GetObject("btn_GPO_Stop.DownImage")));
            this.btn_GPO_Stop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_GPO_Stop.IsShowBorder = true;
            this.btn_GPO_Stop.MoveImage = ((System.Drawing.Image)(resources.GetObject("btn_GPO_Stop.MoveImage")));
            this.btn_GPO_Stop.Name = "btn_GPO_Stop";
            this.btn_GPO_Stop.NormalImage = ((System.Drawing.Image)(resources.GetObject("btn_GPO_Stop.NormalImage")));
            this.btn_GPO_Stop.Tag = "0";
            this.btn_GPO_Stop.UseVisualStyleBackColor = false;
            this.btn_GPO_Stop.Click += new System.EventHandler(this.btn_GPO_Stop_Click);
            // 
            // btn_GPO_down
            // 
            resources.ApplyResources(this.btn_GPO_down, "btn_GPO_down");
            this.btn_GPO_down.BackColor = System.Drawing.Color.Transparent;
            this.btn_GPO_down.DownImage = ((System.Drawing.Image)(resources.GetObject("btn_GPO_down.DownImage")));
            this.btn_GPO_down.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_GPO_down.IsShowBorder = true;
            this.btn_GPO_down.MoveImage = ((System.Drawing.Image)(resources.GetObject("btn_GPO_down.MoveImage")));
            this.btn_GPO_down.Name = "btn_GPO_down";
            this.btn_GPO_down.NormalImage = ((System.Drawing.Image)(resources.GetObject("btn_GPO_down.NormalImage")));
            this.btn_GPO_down.Tag = "0";
            this.btn_GPO_down.UseVisualStyleBackColor = false;
            this.btn_GPO_down.Click += new System.EventHandler(this.btn_GPO_down_Click);
            // 
            // btn_GPO_up
            // 
            resources.ApplyResources(this.btn_GPO_up, "btn_GPO_up");
            this.btn_GPO_up.BackColor = System.Drawing.Color.Transparent;
            this.btn_GPO_up.DownImage = ((System.Drawing.Image)(resources.GetObject("btn_GPO_up.DownImage")));
            this.btn_GPO_up.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_GPO_up.IsShowBorder = true;
            this.btn_GPO_up.MoveImage = ((System.Drawing.Image)(resources.GetObject("btn_GPO_up.MoveImage")));
            this.btn_GPO_up.Name = "btn_GPO_up";
            this.btn_GPO_up.NormalImage = ((System.Drawing.Image)(resources.GetObject("btn_GPO_up.NormalImage")));
            this.btn_GPO_up.Tag = "0";
            this.btn_GPO_up.UseVisualStyleBackColor = false;
            this.btn_GPO_up.Click += new System.EventHandler(this.btn_GPO_up_Click);
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
            // CheckListTest
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tc_Main);
            this.IsResize = false;
            this.Name = "CheckListTest";
            this.ShowIcon = false;
            this.SysButton = ClouReaderDemo.Forms.ESysButton.Close;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CheckList_FormClosing);
            this.Load += new System.EventHandler(this.CheckList_Load);
            this.tc_Main.ResumeLayout(false);
            this.tp_TagRead.ResumeLayout(false);
            this.gb_Read_Result.ResumeLayout(false);
            this.gb_TagList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Tags)).EndInit();
            this.gb_Read_Control.ResumeLayout(false);
            this.gb_Read_Control.PerformLayout();
            this.tp_CheckList.ResumeLayout(false);
            this.tp_BeepTest.ResumeLayout(false);
            this.tp_BeepTest.PerformLayout();
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
        private System.Windows.Forms.TabPage tp_CheckList;
        private MyFormTemplet.QQButton btn_ClearCheckList;
        private MyFormTemplet.QQButton btn_RemoveCheckList;
        private MyFormTemplet.QQButton btn_AddCheckList;
        private System.Windows.Forms.ListBox lb_CheckList;
        private System.Windows.Forms.TabPage tp_BeepTest;
        private MyFormTemplet.QQCheckBox cb_out_w_4;
        private MyFormTemplet.QQCheckBox cb_out_w_3;
        private MyFormTemplet.QQCheckBox cb_out_w_2;
        private MyFormTemplet.QQCheckBox cb_out_w_1;
        private MyFormTemplet.QQButton btn_GPO_Stop;
        private MyFormTemplet.QQButton btn_GPO_down;
        private MyFormTemplet.QQButton btn_GPO_up;
        private System.Windows.Forms.TabPage tp_Debug;
        private System.Windows.Forms.TextBox tb_Msg;
        private MyFormTemplet.QQButton btn_Reset;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lb_TagCount;
        private MyFormTemplet.QQButton btn_;
    }
}