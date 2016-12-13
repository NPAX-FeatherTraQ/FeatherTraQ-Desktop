namespace ClouReaderDemo.MySingleForm.TestForm
{
    partial class Performance_R_List_Back
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Performance_R_List_Back));
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
            this.ANT5_COUNT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ANT6_COUNT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ANT7_COUNT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ANT8_COUNT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm_RSSI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm_ReadTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gb_Read_Control = new System.Windows.Forms.GroupBox();
            this.btn_Clear = new ClouReaderDemo.MyFormTemplet.QQButton();
            this.tb_WaitTime = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_ReadType = new System.Windows.Forms.ComboBox();
            this.lb_TagCount = new System.Windows.Forms.Label();
            this.cb_IsTID = new ClouReaderDemo.MyFormTemplet.QQCheckBox();
            this.btn_StopTest = new ClouReaderDemo.MyFormTemplet.QQButton();
            this.btn_StartReadTest = new ClouReaderDemo.MyFormTemplet.QQButton();
            this.tp_Device_List = new System.Windows.Forms.TabPage();
            this.btn_ClearDevice = new ClouReaderDemo.MyFormTemplet.QQButton();
            this.btn_RemoveDevice = new ClouReaderDemo.MyFormTemplet.QQButton();
            this.btn_AddDevice = new ClouReaderDemo.MyFormTemplet.QQButton();
            this.lb_ReaderList = new System.Windows.Forms.ListBox();
            this.tp_Debug = new System.Windows.Forms.TabPage();
            this.tb_Msg = new System.Windows.Forms.TextBox();
            this.tc_Main.SuspendLayout();
            this.tp_TagRead.SuspendLayout();
            this.gb_Read_Result.SuspendLayout();
            this.gb_TagList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Tags)).BeginInit();
            this.gb_Read_Control.SuspendLayout();
            this.tp_Device_List.SuspendLayout();
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
            this.tc_Main.Controls.Add(this.tp_Device_List);
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
            this.ANT5_COUNT,
            this.ANT6_COUNT,
            this.ANT7_COUNT,
            this.ANT8_COUNT,
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
            // ANT5_COUNT
            // 
            resources.ApplyResources(this.ANT5_COUNT, "ANT5_COUNT");
            this.ANT5_COUNT.Name = "ANT5_COUNT";
            this.ANT5_COUNT.ReadOnly = true;
            // 
            // ANT6_COUNT
            // 
            resources.ApplyResources(this.ANT6_COUNT, "ANT6_COUNT");
            this.ANT6_COUNT.Name = "ANT6_COUNT";
            this.ANT6_COUNT.ReadOnly = true;
            // 
            // ANT7_COUNT
            // 
            resources.ApplyResources(this.ANT7_COUNT, "ANT7_COUNT");
            this.ANT7_COUNT.Name = "ANT7_COUNT";
            this.ANT7_COUNT.ReadOnly = true;
            // 
            // ANT8_COUNT
            // 
            resources.ApplyResources(this.ANT8_COUNT, "ANT8_COUNT");
            this.ANT8_COUNT.Name = "ANT8_COUNT";
            this.ANT8_COUNT.ReadOnly = true;
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
            this.gb_Read_Control.Controls.Add(this.tb_WaitTime);
            this.gb_Read_Control.Controls.Add(this.label1);
            this.gb_Read_Control.Controls.Add(this.cb_ReadType);
            this.gb_Read_Control.Controls.Add(this.lb_TagCount);
            this.gb_Read_Control.Controls.Add(this.cb_IsTID);
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
            // tb_WaitTime
            // 
            resources.ApplyResources(this.tb_WaitTime, "tb_WaitTime");
            this.tb_WaitTime.Name = "tb_WaitTime";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // cb_ReadType
            // 
            resources.ApplyResources(this.cb_ReadType, "cb_ReadType");
            this.cb_ReadType.AutoCompleteCustomSource.AddRange(new string[] {
            resources.GetString("cb_ReadType.AutoCompleteCustomSource"),
            resources.GetString("cb_ReadType.AutoCompleteCustomSource1")});
            this.cb_ReadType.FormattingEnabled = true;
            this.cb_ReadType.Items.AddRange(new object[] {
            resources.GetString("cb_ReadType.Items"),
            resources.GetString("cb_ReadType.Items1")});
            this.cb_ReadType.Name = "cb_ReadType";
            this.cb_ReadType.SelectedIndexChanged += new System.EventHandler(this.cb_ReadType_SelectedIndexChanged);
            // 
            // lb_TagCount
            // 
            resources.ApplyResources(this.lb_TagCount, "lb_TagCount");
            this.lb_TagCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lb_TagCount.Name = "lb_TagCount";
            // 
            // cb_IsTID
            // 
            resources.ApplyResources(this.cb_IsTID, "cb_IsTID");
            this.cb_IsTID.BackColor = System.Drawing.Color.Transparent;
            this.cb_IsTID.Name = "cb_IsTID";
            this.cb_IsTID.Tag = "8";
            this.cb_IsTID.UseVisualStyleBackColor = false;
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
            // tp_Device_List
            // 
            resources.ApplyResources(this.tp_Device_List, "tp_Device_List");
            this.tp_Device_List.BackColor = System.Drawing.Color.White;
            this.tp_Device_List.Controls.Add(this.btn_ClearDevice);
            this.tp_Device_List.Controls.Add(this.btn_RemoveDevice);
            this.tp_Device_List.Controls.Add(this.btn_AddDevice);
            this.tp_Device_List.Controls.Add(this.lb_ReaderList);
            this.tp_Device_List.Name = "tp_Device_List";
            // 
            // btn_ClearDevice
            // 
            resources.ApplyResources(this.btn_ClearDevice, "btn_ClearDevice");
            this.btn_ClearDevice.BackColor = System.Drawing.Color.Transparent;
            this.btn_ClearDevice.DownImage = ((System.Drawing.Image)(resources.GetObject("btn_ClearDevice.DownImage")));
            this.btn_ClearDevice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_ClearDevice.IsShowBorder = true;
            this.btn_ClearDevice.MoveImage = ((System.Drawing.Image)(resources.GetObject("btn_ClearDevice.MoveImage")));
            this.btn_ClearDevice.Name = "btn_ClearDevice";
            this.btn_ClearDevice.NormalImage = ((System.Drawing.Image)(resources.GetObject("btn_ClearDevice.NormalImage")));
            this.btn_ClearDevice.Tag = "0";
            this.btn_ClearDevice.UseVisualStyleBackColor = false;
            this.btn_ClearDevice.Click += new System.EventHandler(this.btn_ClearDevice_Click);
            // 
            // btn_RemoveDevice
            // 
            resources.ApplyResources(this.btn_RemoveDevice, "btn_RemoveDevice");
            this.btn_RemoveDevice.BackColor = System.Drawing.Color.Transparent;
            this.btn_RemoveDevice.DownImage = ((System.Drawing.Image)(resources.GetObject("btn_RemoveDevice.DownImage")));
            this.btn_RemoveDevice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_RemoveDevice.IsShowBorder = true;
            this.btn_RemoveDevice.MoveImage = ((System.Drawing.Image)(resources.GetObject("btn_RemoveDevice.MoveImage")));
            this.btn_RemoveDevice.Name = "btn_RemoveDevice";
            this.btn_RemoveDevice.NormalImage = ((System.Drawing.Image)(resources.GetObject("btn_RemoveDevice.NormalImage")));
            this.btn_RemoveDevice.Tag = "0";
            this.btn_RemoveDevice.UseVisualStyleBackColor = false;
            this.btn_RemoveDevice.Click += new System.EventHandler(this.btn_RemoveDevice_Click);
            // 
            // btn_AddDevice
            // 
            resources.ApplyResources(this.btn_AddDevice, "btn_AddDevice");
            this.btn_AddDevice.BackColor = System.Drawing.Color.Transparent;
            this.btn_AddDevice.DownImage = ((System.Drawing.Image)(resources.GetObject("btn_AddDevice.DownImage")));
            this.btn_AddDevice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_AddDevice.IsShowBorder = true;
            this.btn_AddDevice.MoveImage = ((System.Drawing.Image)(resources.GetObject("btn_AddDevice.MoveImage")));
            this.btn_AddDevice.Name = "btn_AddDevice";
            this.btn_AddDevice.NormalImage = ((System.Drawing.Image)(resources.GetObject("btn_AddDevice.NormalImage")));
            this.btn_AddDevice.Tag = "0";
            this.btn_AddDevice.UseVisualStyleBackColor = false;
            this.btn_AddDevice.Click += new System.EventHandler(this.btn_AddDevice_Click);
            // 
            // lb_ReaderList
            // 
            resources.ApplyResources(this.lb_ReaderList, "lb_ReaderList");
            this.lb_ReaderList.FormattingEnabled = true;
            this.lb_ReaderList.Name = "lb_ReaderList";
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
            // Performance_R_List_Back
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tc_Main);
            this.IsResize = false;
            this.Name = "Performance_R_List_Back";
            this.ShowIcon = false;
            this.SysButton = ClouReaderDemo.Forms.ESysButton.Close;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Performance_R_List_FormClosing);
            this.Load += new System.EventHandler(this.Performance_R_List_Load);
            this.tc_Main.ResumeLayout(false);
            this.tp_TagRead.ResumeLayout(false);
            this.gb_Read_Result.ResumeLayout(false);
            this.gb_TagList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Tags)).EndInit();
            this.gb_Read_Control.ResumeLayout(false);
            this.gb_Read_Control.PerformLayout();
            this.tp_Device_List.ResumeLayout(false);
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
        private System.Windows.Forms.GroupBox gb_Read_Control;
        private System.Windows.Forms.TabPage tp_Debug;
        private System.Windows.Forms.TextBox tb_Msg;
        private MyFormTemplet.QQButton btn_StartReadTest;
        private System.Windows.Forms.TabPage tp_Device_List;
        private MyFormTemplet.QQButton btn_StopTest;
        private System.Windows.Forms.ListBox lb_ReaderList;
        private MyFormTemplet.QQButton btn_ClearDevice;
        private MyFormTemplet.QQButton btn_RemoveDevice;
        private MyFormTemplet.QQButton btn_AddDevice;
        private MyFormTemplet.QQCheckBox cb_IsTID;
        private System.Windows.Forms.Label lb_TagCount;
        private System.Windows.Forms.ComboBox cb_ReadType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_WaitTime;
        private MyFormTemplet.QQButton btn_Clear;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn ANT5_COUNT;
        private System.Windows.Forms.DataGridViewTextBoxColumn ANT6_COUNT;
        private System.Windows.Forms.DataGridViewTextBoxColumn ANT7_COUNT;
        private System.Windows.Forms.DataGridViewTextBoxColumn ANT8_COUNT;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_RSSI;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_ReadTime;
    }
}