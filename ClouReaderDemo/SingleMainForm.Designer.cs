namespace ClouReaderDemo
{
    partial class SingleMainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SingleMainForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel_Top = new System.Windows.Forms.Panel();
            this.tsm_Main = new System.Windows.Forms.ToolStrip();
            this.tsb_Read_Epc = new System.Windows.Forms.ToolStripButton();
            this.tsb_Read_EPCTID = new System.Windows.Forms.ToolStripButton();
            this.tsb_Read_Global = new System.Windows.Forms.ToolStripButton();
            this.tsb_Stop = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsb_Write_EPC = new System.Windows.Forms.ToolStripButton();
            this.tsb_Write_UserData = new System.Windows.Forms.ToolStripButton();
            this.tsb_WriteGlobal = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsddb_SelectColumn = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsddm_tsmi_EPC = new System.Windows.Forms.ToolStripMenuItem();
            this.tsddm_tsmi_TID = new System.Windows.Forms.ToolStripMenuItem();
            this.tsddm_tsmi_UserData = new System.Windows.Forms.ToolStripMenuItem();
            this.tsddm_tsmi_ReserveData = new System.Windows.Forms.ToolStripMenuItem();
            this.tsddm_tsmi_ANT1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsddm_tsmi_ANT2 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsddm_tsmi_ANT3 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsddm_tsmi_ANT4 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsddm_tsmi_ANT5 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsddm_tsmi_ANT6 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsddm_tsmi_ANT7 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsddm_tsmi_ANT8 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsddm_tsmi_RSSI = new System.Windows.Forms.ToolStripMenuItem();
            this.tsddm_tsmi_Frequency = new System.Windows.Forms.ToolStripMenuItem();
            this.tsddm_tsmi_Phase = new System.Windows.Forms.ToolStripMenuItem();
            this.tsddm_tsmi_ReadTime = new System.Windows.Forms.ToolStripMenuItem();
            this.tsb_ClearList = new System.Windows.Forms.ToolStripButton();
            this.tsb_ResetReader = new System.Windows.Forms.ToolStripButton();
            this.tsb_CloseNowConnect = new System.Windows.Forms.ToolStripButton();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.tsmi_SearchDevice = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Connect = new System.Windows.Forms.ToolStripMenuItem();
            this.tmsi_SerialConn = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_TCPClient = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_485Conn = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_TCPServer = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_StepRead = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.配置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.读写器配置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Reader_Serial = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Reader_TCP = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Reader_485 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Reader_TCPServerOrClient = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_RFIDSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_RIFD_RF = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_RFID_TagFilter = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_RFID_AutoFree = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_GPIOSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_GPISetting = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_GPISearch = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_GPOSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_WG = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_RestoreFactory = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_GetCacheTag = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_ClearCacheTag = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_AdvancedSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Debug = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Send_Command = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_PowerCalibration = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Performance = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_TagReadTest = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_TagReadWriteTest = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_TagRead6B_6C = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_BlacklistBeep = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_CheckListBeep = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_API_Test = new System.Windows.Forms.ToolStripMenuItem();
            this.tsms_HubTest = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Test_gj = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_ReaderSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_DebugOn = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Sound = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Sound_Beep = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Sound_Speaker = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Sound_Off = new System.Windows.Forms.ToolStripMenuItem();
            this.tmsi_TagsExport = new System.Windows.Forms.ToolStripMenuItem();
            this.tmsi_Export_Text = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Export_Excel = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_SoftUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_ApplicationSoftUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_BasebandSoftUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_ReadGPO = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Helper = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_GetReaderMsg = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_GetBaseBandVersion = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助文档ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bug反馈ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Language = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Language_CN = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Language_EN = new System.Windows.Forms.ToolStripMenuItem();
            this.panel_Debug = new System.Windows.Forms.Panel();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssl_CPULoad = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssl_CacheSize = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssl_TotalCountName = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssl_TotalConnect = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssl_NowConnID = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsddb_ConnectList = new System.Windows.Forms.ToolStripDropDownButton();
            this.tb_DebugMsg = new System.Windows.Forms.TextBox();
            this.panel_Middle = new System.Windows.Forms.Panel();
            this.panel_MiddleCenter = new System.Windows.Forms.Panel();
            this.dgv_Tags = new ClouReaderDemo.DataGridViewPlus();
            this.clm_ReaderName = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.clm_ANT5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm_ANT6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm_ANT7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm_ANT8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm_RSSI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm_Frequency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm_Phase = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm_ReadTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsForGridView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cms_tsmi_Copy = new System.Windows.Forms.ToolStripMenuItem();
            this.cms_tsmi_WriteEpc = new System.Windows.Forms.ToolStripMenuItem();
            this.cms_tsmi_WriteUserData = new System.Windows.Forms.ToolStripMenuItem();
            this.cms_tsmi_ClearList = new System.Windows.Forms.ToolStripMenuItem();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel_MiddleRight = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.led_Time = new BW.BAR2EPC.SERVER.MAIN.LxLedControl();
            this.led_Speed = new BW.BAR2EPC.SERVER.MAIN.LxLedControl();
            this.led_Tag_ReadCount = new BW.BAR2EPC.SERVER.MAIN.LxLedControl();
            this.led_Tag_Count = new BW.BAR2EPC.SERVER.MAIN.LxLedControl();
            this.btn_GPI_3 = new ClouReaderDemo.MyFormTemplet.RoundButton();
            this.btn_GPI_2 = new ClouReaderDemo.MyFormTemplet.RoundButton();
            this.btn_GPI_1 = new ClouReaderDemo.MyFormTemplet.RoundButton();
            this.btn_GPI_0 = new ClouReaderDemo.MyFormTemplet.RoundButton();
            this.label5 = new System.Windows.Forms.Label();
            this.lb_ReceiveCount = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gb_ReadControl = new System.Windows.Forms.GroupBox();
            this.qqCheckBox5 = new ClouReaderDemo.MyFormTemplet.QQCheckBox();
            this.qqCheckBox6 = new ClouReaderDemo.MyFormTemplet.QQCheckBox();
            this.qqCheckBox7 = new ClouReaderDemo.MyFormTemplet.QQCheckBox();
            this.qqCheckBox8 = new ClouReaderDemo.MyFormTemplet.QQCheckBox();
            this.gb_ReadType = new System.Windows.Forms.GroupBox();
            this.rb_Single = new ClouReaderDemo.MyFormTemplet.QQRadioButton();
            this.rb_While = new ClouReaderDemo.MyFormTemplet.QQRadioButton();
            this.gb_TagType = new System.Windows.Forms.GroupBox();
            this.rb_gb = new ClouReaderDemo.MyFormTemplet.QQRadioButton();
            this.rb_6b = new ClouReaderDemo.MyFormTemplet.QQRadioButton();
            this.rb_6c = new ClouReaderDemo.MyFormTemplet.QQRadioButton();
            this.qqCheckBox4 = new ClouReaderDemo.MyFormTemplet.QQCheckBox();
            this.qqCheckBox3 = new ClouReaderDemo.MyFormTemplet.QQCheckBox();
            this.qqCheckBox2 = new ClouReaderDemo.MyFormTemplet.QQCheckBox();
            this.qqCheckBox1 = new ClouReaderDemo.MyFormTemplet.QQCheckBox();
            this.pc_Processor = new System.Diagnostics.PerformanceCounter();
            this.panel_Top.SuspendLayout();
            this.tsm_Main.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.panel_Debug.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.panel_Middle.SuspendLayout();
            this.panel_MiddleCenter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Tags)).BeginInit();
            this.cmsForGridView.SuspendLayout();
            this.panel_MiddleRight.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.led_Time)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.led_Speed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.led_Tag_ReadCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.led_Tag_Count)).BeginInit();
            this.gb_ReadControl.SuspendLayout();
            this.gb_ReadType.SuspendLayout();
            this.gb_TagType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pc_Processor)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_Top
            // 
            resources.ApplyResources(this.panel_Top, "panel_Top");
            this.panel_Top.BackColor = System.Drawing.Color.Transparent;
            this.panel_Top.Controls.Add(this.tsm_Main);
            this.panel_Top.Controls.Add(this.menuStrip);
            this.panel_Top.Name = "panel_Top";
            // 
            // tsm_Main
            // 
            resources.ApplyResources(this.tsm_Main, "tsm_Main");
            this.tsm_Main.BackColor = System.Drawing.Color.Transparent;
            this.tsm_Main.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsm_Main.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.tsm_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsb_Read_Epc,
            this.tsb_Read_EPCTID,
            this.tsb_Read_Global,
            this.tsb_Stop,
            this.toolStripSeparator1,
            this.tsb_Write_EPC,
            this.tsb_Write_UserData,
            this.tsb_WriteGlobal,
            this.toolStripSeparator2,
            this.tsddb_SelectColumn,
            this.tsb_ClearList,
            this.tsb_ResetReader,
            this.tsb_CloseNowConnect});
            this.tsm_Main.Name = "tsm_Main";
            // 
            // tsb_Read_Epc
            // 
            resources.ApplyResources(this.tsb_Read_Epc, "tsb_Read_Epc");
            this.tsb_Read_Epc.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_Read_Epc.Image = global::ClouReaderDemo.Properties.Resources._10010;
            this.tsb_Read_Epc.Margin = new System.Windows.Forms.Padding(0, 1, 10, 2);
            this.tsb_Read_Epc.Name = "tsb_Read_Epc";
            this.tsb_Read_Epc.Click += new System.EventHandler(this.tsb_Read_Epc_Click);
            // 
            // tsb_Read_EPCTID
            // 
            resources.ApplyResources(this.tsb_Read_EPCTID, "tsb_Read_EPCTID");
            this.tsb_Read_EPCTID.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_Read_EPCTID.Image = global::ClouReaderDemo.Properties.Resources._10011;
            this.tsb_Read_EPCTID.Margin = new System.Windows.Forms.Padding(0, 1, 10, 2);
            this.tsb_Read_EPCTID.Name = "tsb_Read_EPCTID";
            this.tsb_Read_EPCTID.Click += new System.EventHandler(this.tsb_Read_EPCTID_Click);
            // 
            // tsb_Read_Global
            // 
            resources.ApplyResources(this.tsb_Read_Global, "tsb_Read_Global");
            this.tsb_Read_Global.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_Read_Global.Image = global::ClouReaderDemo.Properties.Resources._10012;
            this.tsb_Read_Global.Margin = new System.Windows.Forms.Padding(0, 1, 10, 2);
            this.tsb_Read_Global.Name = "tsb_Read_Global";
            this.tsb_Read_Global.Click += new System.EventHandler(this.tsb_Read_Global_Click);
            // 
            // tsb_Stop
            // 
            resources.ApplyResources(this.tsb_Stop, "tsb_Stop");
            this.tsb_Stop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_Stop.Image = global::ClouReaderDemo.Properties.Resources._10013;
            this.tsb_Stop.Margin = new System.Windows.Forms.Padding(0, 1, 10, 2);
            this.tsb_Stop.Name = "tsb_Stop";
            this.tsb_Stop.Click += new System.EventHandler(this.tsb_Stop_Click);
            // 
            // toolStripSeparator1
            // 
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            this.toolStripSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.toolStripSeparator1.ForeColor = System.Drawing.Color.White;
            this.toolStripSeparator1.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            // 
            // tsb_Write_EPC
            // 
            resources.ApplyResources(this.tsb_Write_EPC, "tsb_Write_EPC");
            this.tsb_Write_EPC.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_Write_EPC.Image = global::ClouReaderDemo.Properties.Resources._10015;
            this.tsb_Write_EPC.Margin = new System.Windows.Forms.Padding(0, 1, 10, 2);
            this.tsb_Write_EPC.Name = "tsb_Write_EPC";
            this.tsb_Write_EPC.Click += new System.EventHandler(this.tsb_Write_EPC_Click);
            // 
            // tsb_Write_UserData
            // 
            resources.ApplyResources(this.tsb_Write_UserData, "tsb_Write_UserData");
            this.tsb_Write_UserData.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_Write_UserData.Image = global::ClouReaderDemo.Properties.Resources._10016;
            this.tsb_Write_UserData.Margin = new System.Windows.Forms.Padding(0, 1, 10, 2);
            this.tsb_Write_UserData.Name = "tsb_Write_UserData";
            this.tsb_Write_UserData.Click += new System.EventHandler(this.tsb_Write_UserData_Click);
            // 
            // tsb_WriteGlobal
            // 
            resources.ApplyResources(this.tsb_WriteGlobal, "tsb_WriteGlobal");
            this.tsb_WriteGlobal.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_WriteGlobal.Image = global::ClouReaderDemo.Properties.Resources._10014;
            this.tsb_WriteGlobal.Margin = new System.Windows.Forms.Padding(0, 1, 10, 2);
            this.tsb_WriteGlobal.Name = "tsb_WriteGlobal";
            this.tsb_WriteGlobal.Click += new System.EventHandler(this.tsb_WriteGlobal_Click);
            // 
            // toolStripSeparator2
            // 
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            this.toolStripSeparator2.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            // 
            // tsddb_SelectColumn
            // 
            resources.ApplyResources(this.tsddb_SelectColumn, "tsddb_SelectColumn");
            this.tsddb_SelectColumn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsddb_SelectColumn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsddm_tsmi_EPC,
            this.tsddm_tsmi_TID,
            this.tsddm_tsmi_UserData,
            this.tsddm_tsmi_ReserveData,
            this.tsddm_tsmi_ANT1,
            this.tsddm_tsmi_ANT2,
            this.tsddm_tsmi_ANT3,
            this.tsddm_tsmi_ANT4,
            this.tsddm_tsmi_ANT5,
            this.tsddm_tsmi_ANT6,
            this.tsddm_tsmi_ANT7,
            this.tsddm_tsmi_ANT8,
            this.tsddm_tsmi_RSSI,
            this.tsddm_tsmi_Frequency,
            this.tsddm_tsmi_Phase,
            this.tsddm_tsmi_ReadTime});
            this.tsddb_SelectColumn.Image = global::ClouReaderDemo.Properties.Resources._10017;
            this.tsddb_SelectColumn.Margin = new System.Windows.Forms.Padding(0, 1, 10, 0);
            this.tsddb_SelectColumn.Name = "tsddb_SelectColumn";
            this.tsddb_SelectColumn.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tsddb_SelectColumn_DropDownItemClicked);
            // 
            // tsddm_tsmi_EPC
            // 
            resources.ApplyResources(this.tsddm_tsmi_EPC, "tsddm_tsmi_EPC");
            this.tsddm_tsmi_EPC.Checked = true;
            this.tsddm_tsmi_EPC.CheckOnClick = true;
            this.tsddm_tsmi_EPC.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsddm_tsmi_EPC.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsddm_tsmi_EPC.Name = "tsddm_tsmi_EPC";
            // 
            // tsddm_tsmi_TID
            // 
            resources.ApplyResources(this.tsddm_tsmi_TID, "tsddm_tsmi_TID");
            this.tsddm_tsmi_TID.Checked = true;
            this.tsddm_tsmi_TID.CheckOnClick = true;
            this.tsddm_tsmi_TID.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsddm_tsmi_TID.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsddm_tsmi_TID.Name = "tsddm_tsmi_TID";
            // 
            // tsddm_tsmi_UserData
            // 
            resources.ApplyResources(this.tsddm_tsmi_UserData, "tsddm_tsmi_UserData");
            this.tsddm_tsmi_UserData.Checked = true;
            this.tsddm_tsmi_UserData.CheckOnClick = true;
            this.tsddm_tsmi_UserData.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsddm_tsmi_UserData.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsddm_tsmi_UserData.Name = "tsddm_tsmi_UserData";
            // 
            // tsddm_tsmi_ReserveData
            // 
            resources.ApplyResources(this.tsddm_tsmi_ReserveData, "tsddm_tsmi_ReserveData");
            this.tsddm_tsmi_ReserveData.Checked = true;
            this.tsddm_tsmi_ReserveData.CheckOnClick = true;
            this.tsddm_tsmi_ReserveData.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsddm_tsmi_ReserveData.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsddm_tsmi_ReserveData.Name = "tsddm_tsmi_ReserveData";
            // 
            // tsddm_tsmi_ANT1
            // 
            resources.ApplyResources(this.tsddm_tsmi_ANT1, "tsddm_tsmi_ANT1");
            this.tsddm_tsmi_ANT1.Checked = true;
            this.tsddm_tsmi_ANT1.CheckOnClick = true;
            this.tsddm_tsmi_ANT1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsddm_tsmi_ANT1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsddm_tsmi_ANT1.Name = "tsddm_tsmi_ANT1";
            // 
            // tsddm_tsmi_ANT2
            // 
            resources.ApplyResources(this.tsddm_tsmi_ANT2, "tsddm_tsmi_ANT2");
            this.tsddm_tsmi_ANT2.Checked = true;
            this.tsddm_tsmi_ANT2.CheckOnClick = true;
            this.tsddm_tsmi_ANT2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsddm_tsmi_ANT2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsddm_tsmi_ANT2.Name = "tsddm_tsmi_ANT2";
            // 
            // tsddm_tsmi_ANT3
            // 
            resources.ApplyResources(this.tsddm_tsmi_ANT3, "tsddm_tsmi_ANT3");
            this.tsddm_tsmi_ANT3.Checked = true;
            this.tsddm_tsmi_ANT3.CheckOnClick = true;
            this.tsddm_tsmi_ANT3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsddm_tsmi_ANT3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsddm_tsmi_ANT3.Name = "tsddm_tsmi_ANT3";
            // 
            // tsddm_tsmi_ANT4
            // 
            resources.ApplyResources(this.tsddm_tsmi_ANT4, "tsddm_tsmi_ANT4");
            this.tsddm_tsmi_ANT4.Checked = true;
            this.tsddm_tsmi_ANT4.CheckOnClick = true;
            this.tsddm_tsmi_ANT4.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsddm_tsmi_ANT4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsddm_tsmi_ANT4.Name = "tsddm_tsmi_ANT4";
            // 
            // tsddm_tsmi_ANT5
            // 
            resources.ApplyResources(this.tsddm_tsmi_ANT5, "tsddm_tsmi_ANT5");
            this.tsddm_tsmi_ANT5.CheckOnClick = true;
            this.tsddm_tsmi_ANT5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsddm_tsmi_ANT5.Name = "tsddm_tsmi_ANT5";
            // 
            // tsddm_tsmi_ANT6
            // 
            resources.ApplyResources(this.tsddm_tsmi_ANT6, "tsddm_tsmi_ANT6");
            this.tsddm_tsmi_ANT6.CheckOnClick = true;
            this.tsddm_tsmi_ANT6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsddm_tsmi_ANT6.Name = "tsddm_tsmi_ANT6";
            // 
            // tsddm_tsmi_ANT7
            // 
            resources.ApplyResources(this.tsddm_tsmi_ANT7, "tsddm_tsmi_ANT7");
            this.tsddm_tsmi_ANT7.CheckOnClick = true;
            this.tsddm_tsmi_ANT7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsddm_tsmi_ANT7.Name = "tsddm_tsmi_ANT7";
            // 
            // tsddm_tsmi_ANT8
            // 
            resources.ApplyResources(this.tsddm_tsmi_ANT8, "tsddm_tsmi_ANT8");
            this.tsddm_tsmi_ANT8.CheckOnClick = true;
            this.tsddm_tsmi_ANT8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsddm_tsmi_ANT8.Name = "tsddm_tsmi_ANT8";
            // 
            // tsddm_tsmi_RSSI
            // 
            resources.ApplyResources(this.tsddm_tsmi_RSSI, "tsddm_tsmi_RSSI");
            this.tsddm_tsmi_RSSI.Checked = true;
            this.tsddm_tsmi_RSSI.CheckOnClick = true;
            this.tsddm_tsmi_RSSI.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsddm_tsmi_RSSI.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsddm_tsmi_RSSI.Name = "tsddm_tsmi_RSSI";
            // 
            // tsddm_tsmi_Frequency
            // 
            resources.ApplyResources(this.tsddm_tsmi_Frequency, "tsddm_tsmi_Frequency");
            this.tsddm_tsmi_Frequency.CheckOnClick = true;
            this.tsddm_tsmi_Frequency.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsddm_tsmi_Frequency.Name = "tsddm_tsmi_Frequency";
            // 
            // tsddm_tsmi_Phase
            // 
            resources.ApplyResources(this.tsddm_tsmi_Phase, "tsddm_tsmi_Phase");
            this.tsddm_tsmi_Phase.CheckOnClick = true;
            this.tsddm_tsmi_Phase.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsddm_tsmi_Phase.Name = "tsddm_tsmi_Phase";
            // 
            // tsddm_tsmi_ReadTime
            // 
            resources.ApplyResources(this.tsddm_tsmi_ReadTime, "tsddm_tsmi_ReadTime");
            this.tsddm_tsmi_ReadTime.CheckOnClick = true;
            this.tsddm_tsmi_ReadTime.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsddm_tsmi_ReadTime.Name = "tsddm_tsmi_ReadTime";
            // 
            // tsb_ClearList
            // 
            resources.ApplyResources(this.tsb_ClearList, "tsb_ClearList");
            this.tsb_ClearList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_ClearList.Image = global::ClouReaderDemo.Properties.Resources._10020;
            this.tsb_ClearList.Margin = new System.Windows.Forms.Padding(0, 1, 10, 2);
            this.tsb_ClearList.Name = "tsb_ClearList";
            this.tsb_ClearList.Click += new System.EventHandler(this.tsb_ClearList_Click);
            // 
            // tsb_ResetReader
            // 
            resources.ApplyResources(this.tsb_ResetReader, "tsb_ResetReader");
            this.tsb_ResetReader.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_ResetReader.Image = global::ClouReaderDemo.Properties.Resources._10018;
            this.tsb_ResetReader.Margin = new System.Windows.Forms.Padding(0, 1, 10, 2);
            this.tsb_ResetReader.Name = "tsb_ResetReader";
            this.tsb_ResetReader.Click += new System.EventHandler(this.tsb_ResetReader_Click);
            // 
            // tsb_CloseNowConnect
            // 
            resources.ApplyResources(this.tsb_CloseNowConnect, "tsb_CloseNowConnect");
            this.tsb_CloseNowConnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_CloseNowConnect.Image = global::ClouReaderDemo.Properties.Resources._10022;
            this.tsb_CloseNowConnect.Name = "tsb_CloseNowConnect";
            this.tsb_CloseNowConnect.Click += new System.EventHandler(this.tsb_CloseNowConnect_Click);
            // 
            // menuStrip
            // 
            resources.ApplyResources(this.menuStrip, "menuStrip");
            this.menuStrip.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_SearchDevice,
            this.tsmi_Connect,
            this.配置ToolStripMenuItem,
            this.tsmi_Debug,
            this.tsmi_ReaderSetting,
            this.tsmi_Helper,
            this.tsmi_Language});
            this.menuStrip.Name = "menuStrip";
            // 
            // tsmi_SearchDevice
            // 
            resources.ApplyResources(this.tsmi_SearchDevice, "tsmi_SearchDevice");
            this.tsmi_SearchDevice.Name = "tsmi_SearchDevice";
            this.tsmi_SearchDevice.Click += new System.EventHandler(this.tsmi_SearchDevice_Click);
            // 
            // tsmi_Connect
            // 
            resources.ApplyResources(this.tsmi_Connect, "tsmi_Connect");
            this.tsmi_Connect.BackColor = System.Drawing.Color.Transparent;
            this.tsmi_Connect.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmsi_SerialConn,
            this.tsmi_TCPClient,
            this.tsmi_485Conn,
            this.tsmi_TCPServer,
            this.tsmi_StepRead,
            this.tsmi_Exit});
            this.tsmi_Connect.ForeColor = System.Drawing.Color.Black;
            this.tsmi_Connect.Name = "tsmi_Connect";
            // 
            // tmsi_SerialConn
            // 
            resources.ApplyResources(this.tmsi_SerialConn, "tmsi_SerialConn");
            this.tmsi_SerialConn.Name = "tmsi_SerialConn";
            this.tmsi_SerialConn.Click += new System.EventHandler(this.tsmi_SerialConn_Click);
            // 
            // tsmi_TCPClient
            // 
            resources.ApplyResources(this.tsmi_TCPClient, "tsmi_TCPClient");
            this.tsmi_TCPClient.Name = "tsmi_TCPClient";
            this.tsmi_TCPClient.Click += new System.EventHandler(this.tsmi_TCPClient_Click);
            // 
            // tsmi_485Conn
            // 
            resources.ApplyResources(this.tsmi_485Conn, "tsmi_485Conn");
            this.tsmi_485Conn.Name = "tsmi_485Conn";
            this.tsmi_485Conn.Click += new System.EventHandler(this.tsmi_485Conn_Click);
            // 
            // tsmi_TCPServer
            // 
            resources.ApplyResources(this.tsmi_TCPServer, "tsmi_TCPServer");
            this.tsmi_TCPServer.Name = "tsmi_TCPServer";
            this.tsmi_TCPServer.Click += new System.EventHandler(this.tsmi_TCPServer_Click);
            // 
            // tsmi_StepRead
            // 
            resources.ApplyResources(this.tsmi_StepRead, "tsmi_StepRead");
            this.tsmi_StepRead.Name = "tsmi_StepRead";
            this.tsmi_StepRead.Click += new System.EventHandler(this.tsmi_StepRead_Click);
            // 
            // tsmi_Exit
            // 
            resources.ApplyResources(this.tsmi_Exit, "tsmi_Exit");
            this.tsmi_Exit.Name = "tsmi_Exit";
            this.tsmi_Exit.Click += new System.EventHandler(this.tsmi_Exit_Click);
            // 
            // 配置ToolStripMenuItem
            // 
            resources.ApplyResources(this.配置ToolStripMenuItem, "配置ToolStripMenuItem");
            this.配置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.读写器配置ToolStripMenuItem,
            this.tsmi_RFIDSetting,
            this.tsmi_GPIOSetting,
            this.tsmi_RestoreFactory,
            this.tsmi_GetCacheTag,
            this.tsmi_ClearCacheTag,
            this.tsmi_AdvancedSettings});
            this.配置ToolStripMenuItem.Name = "配置ToolStripMenuItem";
            // 
            // 读写器配置ToolStripMenuItem
            // 
            resources.ApplyResources(this.读写器配置ToolStripMenuItem, "读写器配置ToolStripMenuItem");
            this.读写器配置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_Reader_Serial,
            this.tsmi_Reader_TCP,
            this.tsmi_Reader_485,
            this.tsmi_Reader_TCPServerOrClient});
            this.读写器配置ToolStripMenuItem.Name = "读写器配置ToolStripMenuItem";
            // 
            // tsmi_Reader_Serial
            // 
            resources.ApplyResources(this.tsmi_Reader_Serial, "tsmi_Reader_Serial");
            this.tsmi_Reader_Serial.Name = "tsmi_Reader_Serial";
            this.tsmi_Reader_Serial.Click += new System.EventHandler(this.tsmi_Reader_Serial_Click);
            // 
            // tsmi_Reader_TCP
            // 
            resources.ApplyResources(this.tsmi_Reader_TCP, "tsmi_Reader_TCP");
            this.tsmi_Reader_TCP.Name = "tsmi_Reader_TCP";
            this.tsmi_Reader_TCP.Click += new System.EventHandler(this.tsmi_Reader_TCP_Click);
            // 
            // tsmi_Reader_485
            // 
            resources.ApplyResources(this.tsmi_Reader_485, "tsmi_Reader_485");
            this.tsmi_Reader_485.Name = "tsmi_Reader_485";
            this.tsmi_Reader_485.Click += new System.EventHandler(this.tsmi_Reader_485_Click);
            // 
            // tsmi_Reader_TCPServerOrClient
            // 
            resources.ApplyResources(this.tsmi_Reader_TCPServerOrClient, "tsmi_Reader_TCPServerOrClient");
            this.tsmi_Reader_TCPServerOrClient.Name = "tsmi_Reader_TCPServerOrClient";
            this.tsmi_Reader_TCPServerOrClient.Click += new System.EventHandler(this.tsmi_Reader_TCPServerOrClient_Click);
            // 
            // tsmi_RFIDSetting
            // 
            resources.ApplyResources(this.tsmi_RFIDSetting, "tsmi_RFIDSetting");
            this.tsmi_RFIDSetting.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_RIFD_RF,
            this.tsmi_RFID_TagFilter,
            this.tsmi_RFID_AutoFree});
            this.tsmi_RFIDSetting.Name = "tsmi_RFIDSetting";
            // 
            // tsmi_RIFD_RF
            // 
            resources.ApplyResources(this.tsmi_RIFD_RF, "tsmi_RIFD_RF");
            this.tsmi_RIFD_RF.Name = "tsmi_RIFD_RF";
            this.tsmi_RIFD_RF.Click += new System.EventHandler(this.tsmi_RIFD_RF_Click);
            // 
            // tsmi_RFID_TagFilter
            // 
            resources.ApplyResources(this.tsmi_RFID_TagFilter, "tsmi_RFID_TagFilter");
            this.tsmi_RFID_TagFilter.Name = "tsmi_RFID_TagFilter";
            this.tsmi_RFID_TagFilter.Click += new System.EventHandler(this.tsmi_RFID_TagFilter_Click);
            // 
            // tsmi_RFID_AutoFree
            // 
            resources.ApplyResources(this.tsmi_RFID_AutoFree, "tsmi_RFID_AutoFree");
            this.tsmi_RFID_AutoFree.Name = "tsmi_RFID_AutoFree";
            this.tsmi_RFID_AutoFree.Click += new System.EventHandler(this.tsmi_RFID_AutoFree_Click);
            // 
            // tsmi_GPIOSetting
            // 
            resources.ApplyResources(this.tsmi_GPIOSetting, "tsmi_GPIOSetting");
            this.tsmi_GPIOSetting.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_GPISetting,
            this.tsmi_GPISearch,
            this.tsmi_GPOSetting,
            this.tsmi_WG});
            this.tsmi_GPIOSetting.Name = "tsmi_GPIOSetting";
            // 
            // tsmi_GPISetting
            // 
            resources.ApplyResources(this.tsmi_GPISetting, "tsmi_GPISetting");
            this.tsmi_GPISetting.Name = "tsmi_GPISetting";
            this.tsmi_GPISetting.Click += new System.EventHandler(this.tsmi_GPISetting_Click);
            // 
            // tsmi_GPISearch
            // 
            resources.ApplyResources(this.tsmi_GPISearch, "tsmi_GPISearch");
            this.tsmi_GPISearch.Name = "tsmi_GPISearch";
            this.tsmi_GPISearch.Click += new System.EventHandler(this.tsmi_GPISearch_Click);
            // 
            // tsmi_GPOSetting
            // 
            resources.ApplyResources(this.tsmi_GPOSetting, "tsmi_GPOSetting");
            this.tsmi_GPOSetting.Name = "tsmi_GPOSetting";
            this.tsmi_GPOSetting.Click += new System.EventHandler(this.tsmi_GPOSetting_Click);
            // 
            // tsmi_WG
            // 
            resources.ApplyResources(this.tsmi_WG, "tsmi_WG");
            this.tsmi_WG.Name = "tsmi_WG";
            this.tsmi_WG.Click += new System.EventHandler(this.tsmi_WG_Click);
            // 
            // tsmi_RestoreFactory
            // 
            resources.ApplyResources(this.tsmi_RestoreFactory, "tsmi_RestoreFactory");
            this.tsmi_RestoreFactory.Name = "tsmi_RestoreFactory";
            this.tsmi_RestoreFactory.Click += new System.EventHandler(this.tsmi_RestoreFactory_Click);
            // 
            // tsmi_GetCacheTag
            // 
            resources.ApplyResources(this.tsmi_GetCacheTag, "tsmi_GetCacheTag");
            this.tsmi_GetCacheTag.Name = "tsmi_GetCacheTag";
            this.tsmi_GetCacheTag.Click += new System.EventHandler(this.tsmi_GetCacheTag_Click);
            // 
            // tsmi_ClearCacheTag
            // 
            resources.ApplyResources(this.tsmi_ClearCacheTag, "tsmi_ClearCacheTag");
            this.tsmi_ClearCacheTag.Name = "tsmi_ClearCacheTag";
            this.tsmi_ClearCacheTag.Click += new System.EventHandler(this.tsmi_ClearCacheTag_Click);
            // 
            // tsmi_AdvancedSettings
            // 
            resources.ApplyResources(this.tsmi_AdvancedSettings, "tsmi_AdvancedSettings");
            this.tsmi_AdvancedSettings.Name = "tsmi_AdvancedSettings";
            this.tsmi_AdvancedSettings.Click += new System.EventHandler(this.tsmi_AdvancedSettings_Click);
            // 
            // tsmi_Debug
            // 
            resources.ApplyResources(this.tsmi_Debug, "tsmi_Debug");
            this.tsmi_Debug.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_Send_Command,
            this.tsmi_PowerCalibration,
            this.tsmi_Performance,
            this.tsmi_API_Test,
            this.tsms_HubTest,
            this.tsmi_Test_gj});
            this.tsmi_Debug.ForeColor = System.Drawing.Color.Black;
            this.tsmi_Debug.Name = "tsmi_Debug";
            // 
            // tsmi_Send_Command
            // 
            resources.ApplyResources(this.tsmi_Send_Command, "tsmi_Send_Command");
            this.tsmi_Send_Command.Name = "tsmi_Send_Command";
            this.tsmi_Send_Command.Click += new System.EventHandler(this.tsmi_Send_Command_Click);
            // 
            // tsmi_PowerCalibration
            // 
            resources.ApplyResources(this.tsmi_PowerCalibration, "tsmi_PowerCalibration");
            this.tsmi_PowerCalibration.Name = "tsmi_PowerCalibration";
            this.tsmi_PowerCalibration.Click += new System.EventHandler(this.tsmi_PowerCalibration_Click);
            // 
            // tsmi_Performance
            // 
            resources.ApplyResources(this.tsmi_Performance, "tsmi_Performance");
            this.tsmi_Performance.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_TagReadTest,
            this.tsmi_TagReadWriteTest,
            this.tsmi_TagRead6B_6C,
            this.tsmi_BlacklistBeep,
            this.tsmi_CheckListBeep});
            this.tsmi_Performance.Name = "tsmi_Performance";
            // 
            // tsmi_TagReadTest
            // 
            resources.ApplyResources(this.tsmi_TagReadTest, "tsmi_TagReadTest");
            this.tsmi_TagReadTest.Name = "tsmi_TagReadTest";
            this.tsmi_TagReadTest.Click += new System.EventHandler(this.tsmi_TagReadTest_Click);
            // 
            // tsmi_TagReadWriteTest
            // 
            resources.ApplyResources(this.tsmi_TagReadWriteTest, "tsmi_TagReadWriteTest");
            this.tsmi_TagReadWriteTest.Name = "tsmi_TagReadWriteTest";
            this.tsmi_TagReadWriteTest.Click += new System.EventHandler(this.tsmi_TagReadWriteTest_Click);
            // 
            // tsmi_TagRead6B_6C
            // 
            resources.ApplyResources(this.tsmi_TagRead6B_6C, "tsmi_TagRead6B_6C");
            this.tsmi_TagRead6B_6C.Name = "tsmi_TagRead6B_6C";
            this.tsmi_TagRead6B_6C.Click += new System.EventHandler(this.tsmi_TagRead6B_6C_Click);
            // 
            // tsmi_BlacklistBeep
            // 
            resources.ApplyResources(this.tsmi_BlacklistBeep, "tsmi_BlacklistBeep");
            this.tsmi_BlacklistBeep.Name = "tsmi_BlacklistBeep";
            this.tsmi_BlacklistBeep.Click += new System.EventHandler(this.tsmi_BlacklistBeep_Click);
            // 
            // tsmi_CheckListBeep
            // 
            resources.ApplyResources(this.tsmi_CheckListBeep, "tsmi_CheckListBeep");
            this.tsmi_CheckListBeep.Name = "tsmi_CheckListBeep";
            this.tsmi_CheckListBeep.Click += new System.EventHandler(this.tsmi_CheckListBeep_Click);
            // 
            // tsmi_API_Test
            // 
            resources.ApplyResources(this.tsmi_API_Test, "tsmi_API_Test");
            this.tsmi_API_Test.Name = "tsmi_API_Test";
            this.tsmi_API_Test.Click += new System.EventHandler(this.tsmi_API_Test_Click);
            // 
            // tsms_HubTest
            // 
            resources.ApplyResources(this.tsms_HubTest, "tsms_HubTest");
            this.tsms_HubTest.Name = "tsms_HubTest";
            this.tsms_HubTest.Click += new System.EventHandler(this.tsms_HubTest_Click);
            // 
            // tsmi_Test_gj
            // 
            resources.ApplyResources(this.tsmi_Test_gj, "tsmi_Test_gj");
            this.tsmi_Test_gj.Name = "tsmi_Test_gj";
            this.tsmi_Test_gj.Click += new System.EventHandler(this.tsmi_Test_gj_Click);
            // 
            // tsmi_ReaderSetting
            // 
            resources.ApplyResources(this.tsmi_ReaderSetting, "tsmi_ReaderSetting");
            this.tsmi_ReaderSetting.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_DebugOn,
            this.tsmi_Sound,
            this.tmsi_TagsExport,
            this.tsmi_SoftUpdate,
            this.tsmi_ReadGPO});
            this.tsmi_ReaderSetting.ForeColor = System.Drawing.Color.Black;
            this.tsmi_ReaderSetting.Name = "tsmi_ReaderSetting";
            // 
            // tsmi_DebugOn
            // 
            resources.ApplyResources(this.tsmi_DebugOn, "tsmi_DebugOn");
            this.tsmi_DebugOn.Name = "tsmi_DebugOn";
            this.tsmi_DebugOn.Tag = "0";
            this.tsmi_DebugOn.Click += new System.EventHandler(this.tsmi_DebugOn_Click);
            // 
            // tsmi_Sound
            // 
            resources.ApplyResources(this.tsmi_Sound, "tsmi_Sound");
            this.tsmi_Sound.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_Sound_Beep,
            this.tsmi_Sound_Speaker,
            this.tsmi_Sound_Off});
            this.tsmi_Sound.Image = global::ClouReaderDemo.Properties.Resources._10023;
            this.tsmi_Sound.Name = "tsmi_Sound";
            this.tsmi_Sound.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tsmi_Sound_DropDownItemClicked);
            // 
            // tsmi_Sound_Beep
            // 
            resources.ApplyResources(this.tsmi_Sound_Beep, "tsmi_Sound_Beep");
            this.tsmi_Sound_Beep.Name = "tsmi_Sound_Beep";
            this.tsmi_Sound_Beep.Tag = "0";
            // 
            // tsmi_Sound_Speaker
            // 
            resources.ApplyResources(this.tsmi_Sound_Speaker, "tsmi_Sound_Speaker");
            this.tsmi_Sound_Speaker.Name = "tsmi_Sound_Speaker";
            this.tsmi_Sound_Speaker.Tag = "1";
            // 
            // tsmi_Sound_Off
            // 
            resources.ApplyResources(this.tsmi_Sound_Off, "tsmi_Sound_Off");
            this.tsmi_Sound_Off.Checked = true;
            this.tsmi_Sound_Off.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmi_Sound_Off.Name = "tsmi_Sound_Off";
            this.tsmi_Sound_Off.Tag = "-1";
            // 
            // tmsi_TagsExport
            // 
            resources.ApplyResources(this.tmsi_TagsExport, "tmsi_TagsExport");
            this.tmsi_TagsExport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmsi_Export_Text,
            this.tsmi_Export_Excel});
            this.tmsi_TagsExport.Image = global::ClouReaderDemo.Properties.Resources._10009;
            this.tmsi_TagsExport.Name = "tmsi_TagsExport";
            // 
            // tmsi_Export_Text
            // 
            resources.ApplyResources(this.tmsi_Export_Text, "tmsi_Export_Text");
            this.tmsi_Export_Text.Image = global::ClouReaderDemo.Properties.Resources._10008;
            this.tmsi_Export_Text.Name = "tmsi_Export_Text";
            this.tmsi_Export_Text.Click += new System.EventHandler(this.tmsi_Export_Text_Click);
            // 
            // tsmi_Export_Excel
            // 
            resources.ApplyResources(this.tsmi_Export_Excel, "tsmi_Export_Excel");
            this.tsmi_Export_Excel.Image = global::ClouReaderDemo.Properties.Resources._10007;
            this.tsmi_Export_Excel.Name = "tsmi_Export_Excel";
            this.tsmi_Export_Excel.Click += new System.EventHandler(this.tsmi_Export_Excel_Click);
            // 
            // tsmi_SoftUpdate
            // 
            resources.ApplyResources(this.tsmi_SoftUpdate, "tsmi_SoftUpdate");
            this.tsmi_SoftUpdate.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_ApplicationSoftUpdate,
            this.tsmi_BasebandSoftUpdate});
            this.tsmi_SoftUpdate.Name = "tsmi_SoftUpdate";
            // 
            // tsmi_ApplicationSoftUpdate
            // 
            resources.ApplyResources(this.tsmi_ApplicationSoftUpdate, "tsmi_ApplicationSoftUpdate");
            this.tsmi_ApplicationSoftUpdate.Name = "tsmi_ApplicationSoftUpdate";
            this.tsmi_ApplicationSoftUpdate.Click += new System.EventHandler(this.tsmi_ApplicationSoftUpdate_Click);
            // 
            // tsmi_BasebandSoftUpdate
            // 
            resources.ApplyResources(this.tsmi_BasebandSoftUpdate, "tsmi_BasebandSoftUpdate");
            this.tsmi_BasebandSoftUpdate.Name = "tsmi_BasebandSoftUpdate";
            this.tsmi_BasebandSoftUpdate.Click += new System.EventHandler(this.tsmi_BasebandSoftUpdate_Click);
            // 
            // tsmi_ReadGPO
            // 
            resources.ApplyResources(this.tsmi_ReadGPO, "tsmi_ReadGPO");
            this.tsmi_ReadGPO.Name = "tsmi_ReadGPO";
            this.tsmi_ReadGPO.Click += new System.EventHandler(this.tsmi_ReadGPO_Click);
            // 
            // tsmi_Helper
            // 
            resources.ApplyResources(this.tsmi_Helper, "tsmi_Helper");
            this.tsmi_Helper.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_GetReaderMsg,
            this.tsmi_GetBaseBandVersion,
            this.帮助文档ToolStripMenuItem,
            this.bug反馈ToolStripMenuItem,
            this.关于ToolStripMenuItem});
            this.tsmi_Helper.ForeColor = System.Drawing.Color.Black;
            this.tsmi_Helper.Name = "tsmi_Helper";
            // 
            // tsmi_GetReaderMsg
            // 
            resources.ApplyResources(this.tsmi_GetReaderMsg, "tsmi_GetReaderMsg");
            this.tsmi_GetReaderMsg.Name = "tsmi_GetReaderMsg";
            this.tsmi_GetReaderMsg.Click += new System.EventHandler(this.tsmi_GetReaderMsg_Click);
            // 
            // tsmi_GetBaseBandVersion
            // 
            resources.ApplyResources(this.tsmi_GetBaseBandVersion, "tsmi_GetBaseBandVersion");
            this.tsmi_GetBaseBandVersion.Name = "tsmi_GetBaseBandVersion";
            this.tsmi_GetBaseBandVersion.Click += new System.EventHandler(this.tsmi_GetBaseBandVersion_Click);
            // 
            // 帮助文档ToolStripMenuItem
            // 
            resources.ApplyResources(this.帮助文档ToolStripMenuItem, "帮助文档ToolStripMenuItem");
            this.帮助文档ToolStripMenuItem.Image = global::ClouReaderDemo.Properties.Resources._10005;
            this.帮助文档ToolStripMenuItem.Name = "帮助文档ToolStripMenuItem";
            // 
            // bug反馈ToolStripMenuItem
            // 
            resources.ApplyResources(this.bug反馈ToolStripMenuItem, "bug反馈ToolStripMenuItem");
            this.bug反馈ToolStripMenuItem.Name = "bug反馈ToolStripMenuItem";
            // 
            // 关于ToolStripMenuItem
            // 
            resources.ApplyResources(this.关于ToolStripMenuItem, "关于ToolStripMenuItem");
            this.关于ToolStripMenuItem.Image = global::ClouReaderDemo.Properties.Resources._10006;
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            // 
            // tsmi_Language
            // 
            resources.ApplyResources(this.tsmi_Language, "tsmi_Language");
            this.tsmi_Language.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_Language_CN,
            this.tsmi_Language_EN});
            this.tsmi_Language.Name = "tsmi_Language";
            // 
            // tsmi_Language_CN
            // 
            resources.ApplyResources(this.tsmi_Language_CN, "tsmi_Language_CN");
            this.tsmi_Language_CN.Name = "tsmi_Language_CN";
            this.tsmi_Language_CN.Click += new System.EventHandler(this.tsmi_Language_CN_Click);
            // 
            // tsmi_Language_EN
            // 
            resources.ApplyResources(this.tsmi_Language_EN, "tsmi_Language_EN");
            this.tsmi_Language_EN.Name = "tsmi_Language_EN";
            this.tsmi_Language_EN.Click += new System.EventHandler(this.tsmi_Language_EN_Click);
            // 
            // panel_Debug
            // 
            resources.ApplyResources(this.panel_Debug, "panel_Debug");
            this.panel_Debug.BackColor = System.Drawing.Color.Transparent;
            this.panel_Debug.Controls.Add(this.statusStrip);
            this.panel_Debug.Controls.Add(this.tb_DebugMsg);
            this.panel_Debug.Name = "panel_Debug";
            // 
            // statusStrip
            // 
            resources.ApplyResources(this.statusStrip, "statusStrip");
            this.statusStrip.BackColor = System.Drawing.Color.Transparent;
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.tssl_CPULoad,
            this.toolStripStatusLabel3,
            this.tssl_CacheSize,
            this.tssl_TotalCountName,
            this.tssl_TotalConnect,
            this.toolStripStatusLabel4,
            this.tssl_NowConnID,
            this.tsddb_ConnectList});
            this.statusStrip.Name = "statusStrip";
            // 
            // toolStripStatusLabel1
            // 
            resources.ApplyResources(this.toolStripStatusLabel1, "toolStripStatusLabel1");
            this.toolStripStatusLabel1.ForeColor = System.Drawing.Color.Transparent;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Spring = true;
            // 
            // toolStripStatusLabel2
            // 
            resources.ApplyResources(this.toolStripStatusLabel2, "toolStripStatusLabel2");
            this.toolStripStatusLabel2.ForeColor = System.Drawing.Color.Black;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            // 
            // tssl_CPULoad
            // 
            resources.ApplyResources(this.tssl_CPULoad, "tssl_CPULoad");
            this.tssl_CPULoad.ForeColor = System.Drawing.Color.Black;
            this.tssl_CPULoad.Name = "tssl_CPULoad";
            // 
            // toolStripStatusLabel3
            // 
            resources.ApplyResources(this.toolStripStatusLabel3, "toolStripStatusLabel3");
            this.toolStripStatusLabel3.ForeColor = System.Drawing.Color.Black;
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            // 
            // tssl_CacheSize
            // 
            resources.ApplyResources(this.tssl_CacheSize, "tssl_CacheSize");
            this.tssl_CacheSize.ForeColor = System.Drawing.Color.Black;
            this.tssl_CacheSize.Name = "tssl_CacheSize";
            // 
            // tssl_TotalCountName
            // 
            resources.ApplyResources(this.tssl_TotalCountName, "tssl_TotalCountName");
            this.tssl_TotalCountName.Name = "tssl_TotalCountName";
            // 
            // tssl_TotalConnect
            // 
            resources.ApplyResources(this.tssl_TotalConnect, "tssl_TotalConnect");
            this.tssl_TotalConnect.ForeColor = System.Drawing.Color.Red;
            this.tssl_TotalConnect.Name = "tssl_TotalConnect";
            // 
            // toolStripStatusLabel4
            // 
            resources.ApplyResources(this.toolStripStatusLabel4, "toolStripStatusLabel4");
            this.toolStripStatusLabel4.ForeColor = System.Drawing.Color.Black;
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            // 
            // tssl_NowConnID
            // 
            resources.ApplyResources(this.tssl_NowConnID, "tssl_NowConnID");
            this.tssl_NowConnID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.tssl_NowConnID.Name = "tssl_NowConnID";
            // 
            // tsddb_ConnectList
            // 
            resources.ApplyResources(this.tsddb_ConnectList, "tsddb_ConnectList");
            this.tsddb_ConnectList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsddb_ConnectList.Name = "tsddb_ConnectList";
            this.tsddb_ConnectList.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tsddb_ConnectList_DropDownItemClicked);
            // 
            // tb_DebugMsg
            // 
            resources.ApplyResources(this.tb_DebugMsg, "tb_DebugMsg");
            this.tb_DebugMsg.Name = "tb_DebugMsg";
            // 
            // panel_Middle
            // 
            resources.ApplyResources(this.panel_Middle, "panel_Middle");
            this.panel_Middle.BackColor = System.Drawing.Color.Transparent;
            this.panel_Middle.Controls.Add(this.panel_MiddleCenter);
            this.panel_Middle.Controls.Add(this.splitter1);
            this.panel_Middle.Controls.Add(this.panel_MiddleRight);
            this.panel_Middle.Name = "panel_Middle";
            // 
            // panel_MiddleCenter
            // 
            resources.ApplyResources(this.panel_MiddleCenter, "panel_MiddleCenter");
            this.panel_MiddleCenter.Controls.Add(this.dgv_Tags);
            this.panel_MiddleCenter.Name = "panel_MiddleCenter";
            // 
            // dgv_Tags
            // 
            resources.ApplyResources(this.dgv_Tags, "dgv_Tags");
            this.dgv_Tags.AllowUserToAddRows = false;
            this.dgv_Tags.AllowUserToDeleteRows = false;
            this.dgv_Tags.AllowUserToResizeRows = false;
            this.dgv_Tags.BackgroundColor = System.Drawing.Color.White;
            this.dgv_Tags.CausesValidation = false;
            this.dgv_Tags.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dgv_Tags.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_Tags.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clm_ReaderName,
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
            this.clm_ANT5,
            this.clm_ANT6,
            this.clm_ANT7,
            this.clm_ANT8,
            this.clm_RSSI,
            this.clm_Frequency,
            this.clm_Phase,
            this.clm_ReadTime});
            this.dgv_Tags.ContextMenuStrip = this.cmsForGridView;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Tags.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Tags.GridColor = System.Drawing.Color.Blue;
            this.dgv_Tags.MultiSelect = false;
            this.dgv_Tags.Name = "dgv_Tags";
            this.dgv_Tags.ReadOnly = true;
            this.dgv_Tags.RowTemplate.Height = 23;
            this.dgv_Tags.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Tags_CellContentClick);
            this.dgv_Tags.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_Tags_CellMouseDown);
            this.dgv_Tags.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgv_Tags_MouseDown);
            // 
            // clm_ReaderName
            // 
            resources.ApplyResources(this.clm_ReaderName, "clm_ReaderName");
            this.clm_ReaderName.Name = "clm_ReaderName";
            this.clm_ReaderName.ReadOnly = true;
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
            // clm_ANT5
            // 
            resources.ApplyResources(this.clm_ANT5, "clm_ANT5");
            this.clm_ANT5.Name = "clm_ANT5";
            this.clm_ANT5.ReadOnly = true;
            // 
            // clm_ANT6
            // 
            resources.ApplyResources(this.clm_ANT6, "clm_ANT6");
            this.clm_ANT6.Name = "clm_ANT6";
            this.clm_ANT6.ReadOnly = true;
            // 
            // clm_ANT7
            // 
            resources.ApplyResources(this.clm_ANT7, "clm_ANT7");
            this.clm_ANT7.Name = "clm_ANT7";
            this.clm_ANT7.ReadOnly = true;
            // 
            // clm_ANT8
            // 
            resources.ApplyResources(this.clm_ANT8, "clm_ANT8");
            this.clm_ANT8.Name = "clm_ANT8";
            this.clm_ANT8.ReadOnly = true;
            // 
            // clm_RSSI
            // 
            resources.ApplyResources(this.clm_RSSI, "clm_RSSI");
            this.clm_RSSI.Name = "clm_RSSI";
            this.clm_RSSI.ReadOnly = true;
            // 
            // clm_Frequency
            // 
            resources.ApplyResources(this.clm_Frequency, "clm_Frequency");
            this.clm_Frequency.Name = "clm_Frequency";
            this.clm_Frequency.ReadOnly = true;
            // 
            // clm_Phase
            // 
            resources.ApplyResources(this.clm_Phase, "clm_Phase");
            this.clm_Phase.Name = "clm_Phase";
            this.clm_Phase.ReadOnly = true;
            // 
            // clm_ReadTime
            // 
            resources.ApplyResources(this.clm_ReadTime, "clm_ReadTime");
            this.clm_ReadTime.Name = "clm_ReadTime";
            this.clm_ReadTime.ReadOnly = true;
            // 
            // cmsForGridView
            // 
            resources.ApplyResources(this.cmsForGridView, "cmsForGridView");
            this.cmsForGridView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cms_tsmi_Copy,
            this.cms_tsmi_WriteEpc,
            this.cms_tsmi_WriteUserData,
            this.cms_tsmi_ClearList});
            this.cmsForGridView.Name = "cmsForGridView";
            this.cmsForGridView.Opening += new System.ComponentModel.CancelEventHandler(this.cmsForGridView_Opening);
            // 
            // cms_tsmi_Copy
            // 
            resources.ApplyResources(this.cms_tsmi_Copy, "cms_tsmi_Copy");
            this.cms_tsmi_Copy.Name = "cms_tsmi_Copy";
            this.cms_tsmi_Copy.Click += new System.EventHandler(this.cms_tsmi_Copy_Click);
            // 
            // cms_tsmi_WriteEpc
            // 
            resources.ApplyResources(this.cms_tsmi_WriteEpc, "cms_tsmi_WriteEpc");
            this.cms_tsmi_WriteEpc.Name = "cms_tsmi_WriteEpc";
            this.cms_tsmi_WriteEpc.Click += new System.EventHandler(this.cms_tsmi_WriteEpc_Click);
            // 
            // cms_tsmi_WriteUserData
            // 
            resources.ApplyResources(this.cms_tsmi_WriteUserData, "cms_tsmi_WriteUserData");
            this.cms_tsmi_WriteUserData.Name = "cms_tsmi_WriteUserData";
            this.cms_tsmi_WriteUserData.Click += new System.EventHandler(this.cms_tsmi_WriteUserData_Click);
            // 
            // cms_tsmi_ClearList
            // 
            resources.ApplyResources(this.cms_tsmi_ClearList, "cms_tsmi_ClearList");
            this.cms_tsmi_ClearList.Name = "cms_tsmi_ClearList";
            this.cms_tsmi_ClearList.Click += new System.EventHandler(this.cms_tsmi_ClearList_Click);
            // 
            // splitter1
            // 
            resources.ApplyResources(this.splitter1, "splitter1");
            this.splitter1.Name = "splitter1";
            this.splitter1.TabStop = false;
            // 
            // panel_MiddleRight
            // 
            resources.ApplyResources(this.panel_MiddleRight, "panel_MiddleRight");
            this.panel_MiddleRight.Controls.Add(this.groupBox2);
            this.panel_MiddleRight.Controls.Add(this.gb_ReadControl);
            this.panel_MiddleRight.Name = "panel_MiddleRight";
            // 
            // groupBox2
            // 
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Controls.Add(this.led_Time);
            this.groupBox2.Controls.Add(this.led_Speed);
            this.groupBox2.Controls.Add(this.led_Tag_ReadCount);
            this.groupBox2.Controls.Add(this.led_Tag_Count);
            this.groupBox2.Controls.Add(this.btn_GPI_3);
            this.groupBox2.Controls.Add(this.btn_GPI_2);
            this.groupBox2.Controls.Add(this.btn_GPI_1);
            this.groupBox2.Controls.Add(this.btn_GPI_0);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.lb_ReceiveCount);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // led_Time
            // 
            resources.ApplyResources(this.led_Time, "led_Time");
            this.led_Time.BackColor = System.Drawing.Color.Transparent;
            this.led_Time.BackColor_1 = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.led_Time.BackColor_2 = System.Drawing.Color.DimGray;
            this.led_Time.BevelRate = 0.5F;
            this.led_Time.BorderWidth = 0;
            this.led_Time.FadedColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.led_Time.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.led_Time.HighlightOpaque = ((byte)(50));
            this.led_Time.Name = "led_Time";
            this.led_Time.TotalCharCount = 8;
            // 
            // led_Speed
            // 
            resources.ApplyResources(this.led_Speed, "led_Speed");
            this.led_Speed.BackColor = System.Drawing.Color.Transparent;
            this.led_Speed.BackColor_1 = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.led_Speed.BackColor_2 = System.Drawing.Color.DimGray;
            this.led_Speed.BevelRate = 0.5F;
            this.led_Speed.BorderWidth = 0;
            this.led_Speed.FadedColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.led_Speed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.led_Speed.HighlightOpaque = ((byte)(50));
            this.led_Speed.Name = "led_Speed";
            this.led_Speed.TotalCharCount = 4;
            // 
            // led_Tag_ReadCount
            // 
            resources.ApplyResources(this.led_Tag_ReadCount, "led_Tag_ReadCount");
            this.led_Tag_ReadCount.BackColor = System.Drawing.Color.Transparent;
            this.led_Tag_ReadCount.BackColor_1 = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.led_Tag_ReadCount.BackColor_2 = System.Drawing.Color.DimGray;
            this.led_Tag_ReadCount.BevelRate = 0.5F;
            this.led_Tag_ReadCount.BorderWidth = 0;
            this.led_Tag_ReadCount.FadedColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.led_Tag_ReadCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.led_Tag_ReadCount.HighlightOpaque = ((byte)(50));
            this.led_Tag_ReadCount.Name = "led_Tag_ReadCount";
            this.led_Tag_ReadCount.TotalCharCount = 8;
            // 
            // led_Tag_Count
            // 
            resources.ApplyResources(this.led_Tag_Count, "led_Tag_Count");
            this.led_Tag_Count.BackColor = System.Drawing.Color.Transparent;
            this.led_Tag_Count.BackColor_1 = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.led_Tag_Count.BackColor_2 = System.Drawing.Color.Aqua;
            this.led_Tag_Count.BevelRate = 0.5F;
            this.led_Tag_Count.BorderWidth = 0;
            this.led_Tag_Count.FadedColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.led_Tag_Count.FocusedBorderColor = System.Drawing.Color.Black;
            this.led_Tag_Count.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.led_Tag_Count.HighlightOpaque = ((byte)(50));
            this.led_Tag_Count.Name = "led_Tag_Count";
            this.led_Tag_Count.TotalCharCount = 4;
            // 
            // btn_GPI_3
            // 
            resources.ApplyResources(this.btn_GPI_3, "btn_GPI_3");
            this.btn_GPI_3.BackColor = System.Drawing.Color.Blue;
            this.btn_GPI_3.Name = "btn_GPI_3";
            this.btn_GPI_3.Radius = 15;
            this.btn_GPI_3.Tag = "1";
            this.btn_GPI_3.UseVisualStyleBackColor = false;
            // 
            // btn_GPI_2
            // 
            resources.ApplyResources(this.btn_GPI_2, "btn_GPI_2");
            this.btn_GPI_2.BackColor = System.Drawing.Color.Blue;
            this.btn_GPI_2.Name = "btn_GPI_2";
            this.btn_GPI_2.Radius = 15;
            this.btn_GPI_2.Tag = "1";
            this.btn_GPI_2.UseVisualStyleBackColor = false;
            // 
            // btn_GPI_1
            // 
            resources.ApplyResources(this.btn_GPI_1, "btn_GPI_1");
            this.btn_GPI_1.BackColor = System.Drawing.Color.Blue;
            this.btn_GPI_1.Name = "btn_GPI_1";
            this.btn_GPI_1.Radius = 15;
            this.btn_GPI_1.Tag = "1";
            this.btn_GPI_1.UseVisualStyleBackColor = false;
            // 
            // btn_GPI_0
            // 
            resources.ApplyResources(this.btn_GPI_0, "btn_GPI_0");
            this.btn_GPI_0.BackColor = System.Drawing.Color.Blue;
            this.btn_GPI_0.Name = "btn_GPI_0";
            this.btn_GPI_0.Radius = 15;
            this.btn_GPI_0.Tag = "1";
            this.btn_GPI_0.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // lb_ReceiveCount
            // 
            resources.ApplyResources(this.lb_ReceiveCount, "lb_ReceiveCount");
            this.lb_ReceiveCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lb_ReceiveCount.Name = "lb_ReceiveCount";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // gb_ReadControl
            // 
            resources.ApplyResources(this.gb_ReadControl, "gb_ReadControl");
            this.gb_ReadControl.Controls.Add(this.qqCheckBox5);
            this.gb_ReadControl.Controls.Add(this.qqCheckBox6);
            this.gb_ReadControl.Controls.Add(this.qqCheckBox7);
            this.gb_ReadControl.Controls.Add(this.qqCheckBox8);
            this.gb_ReadControl.Controls.Add(this.gb_ReadType);
            this.gb_ReadControl.Controls.Add(this.gb_TagType);
            this.gb_ReadControl.Controls.Add(this.qqCheckBox4);
            this.gb_ReadControl.Controls.Add(this.qqCheckBox3);
            this.gb_ReadControl.Controls.Add(this.qqCheckBox2);
            this.gb_ReadControl.Controls.Add(this.qqCheckBox1);
            this.gb_ReadControl.Name = "gb_ReadControl";
            this.gb_ReadControl.TabStop = false;
            // 
            // qqCheckBox5
            // 
            resources.ApplyResources(this.qqCheckBox5, "qqCheckBox5");
            this.qqCheckBox5.BackColor = System.Drawing.Color.Transparent;
            this.qqCheckBox5.Name = "qqCheckBox5";
            this.qqCheckBox5.Tag = "128";
            this.qqCheckBox5.UseVisualStyleBackColor = false;
            // 
            // qqCheckBox6
            // 
            resources.ApplyResources(this.qqCheckBox6, "qqCheckBox6");
            this.qqCheckBox6.BackColor = System.Drawing.Color.Transparent;
            this.qqCheckBox6.Name = "qqCheckBox6";
            this.qqCheckBox6.Tag = "64";
            this.qqCheckBox6.UseVisualStyleBackColor = false;
            // 
            // qqCheckBox7
            // 
            resources.ApplyResources(this.qqCheckBox7, "qqCheckBox7");
            this.qqCheckBox7.BackColor = System.Drawing.Color.Transparent;
            this.qqCheckBox7.Name = "qqCheckBox7";
            this.qqCheckBox7.Tag = "32";
            this.qqCheckBox7.UseVisualStyleBackColor = false;
            // 
            // qqCheckBox8
            // 
            resources.ApplyResources(this.qqCheckBox8, "qqCheckBox8");
            this.qqCheckBox8.BackColor = System.Drawing.Color.Transparent;
            this.qqCheckBox8.Name = "qqCheckBox8";
            this.qqCheckBox8.Tag = "16";
            this.qqCheckBox8.UseVisualStyleBackColor = false;
            // 
            // gb_ReadType
            // 
            resources.ApplyResources(this.gb_ReadType, "gb_ReadType");
            this.gb_ReadType.Controls.Add(this.rb_Single);
            this.gb_ReadType.Controls.Add(this.rb_While);
            this.gb_ReadType.Name = "gb_ReadType";
            this.gb_ReadType.TabStop = false;
            // 
            // rb_Single
            // 
            resources.ApplyResources(this.rb_Single, "rb_Single");
            this.rb_Single.BackColor = System.Drawing.Color.Transparent;
            this.rb_Single.Name = "rb_Single";
            this.rb_Single.Tag = "0";
            this.rb_Single.UseVisualStyleBackColor = false;
            // 
            // rb_While
            // 
            resources.ApplyResources(this.rb_While, "rb_While");
            this.rb_While.BackColor = System.Drawing.Color.Transparent;
            this.rb_While.Checked = true;
            this.rb_While.Name = "rb_While";
            this.rb_While.TabStop = true;
            this.rb_While.Tag = "1";
            this.rb_While.UseVisualStyleBackColor = false;
            // 
            // gb_TagType
            // 
            resources.ApplyResources(this.gb_TagType, "gb_TagType");
            this.gb_TagType.Controls.Add(this.rb_gb);
            this.gb_TagType.Controls.Add(this.rb_6b);
            this.gb_TagType.Controls.Add(this.rb_6c);
            this.gb_TagType.Name = "gb_TagType";
            this.gb_TagType.TabStop = false;
            // 
            // rb_gb
            // 
            resources.ApplyResources(this.rb_gb, "rb_gb");
            this.rb_gb.BackColor = System.Drawing.Color.Transparent;
            this.rb_gb.Name = "rb_gb";
            this.rb_gb.Tag = "";
            this.rb_gb.UseVisualStyleBackColor = false;
            // 
            // rb_6b
            // 
            resources.ApplyResources(this.rb_6b, "rb_6b");
            this.rb_6b.BackColor = System.Drawing.Color.Transparent;
            this.rb_6b.Name = "rb_6b";
            this.rb_6b.Tag = "";
            this.rb_6b.UseVisualStyleBackColor = false;
            // 
            // rb_6c
            // 
            resources.ApplyResources(this.rb_6c, "rb_6c");
            this.rb_6c.BackColor = System.Drawing.Color.Transparent;
            this.rb_6c.Checked = true;
            this.rb_6c.Name = "rb_6c";
            this.rb_6c.TabStop = true;
            this.rb_6c.Tag = "";
            this.rb_6c.UseVisualStyleBackColor = false;
            // 
            // qqCheckBox4
            // 
            resources.ApplyResources(this.qqCheckBox4, "qqCheckBox4");
            this.qqCheckBox4.BackColor = System.Drawing.Color.Transparent;
            this.qqCheckBox4.Name = "qqCheckBox4";
            this.qqCheckBox4.Tag = "8";
            this.qqCheckBox4.UseVisualStyleBackColor = false;
            // 
            // qqCheckBox3
            // 
            resources.ApplyResources(this.qqCheckBox3, "qqCheckBox3");
            this.qqCheckBox3.BackColor = System.Drawing.Color.Transparent;
            this.qqCheckBox3.Name = "qqCheckBox3";
            this.qqCheckBox3.Tag = "4";
            this.qqCheckBox3.UseVisualStyleBackColor = false;
            // 
            // qqCheckBox2
            // 
            resources.ApplyResources(this.qqCheckBox2, "qqCheckBox2");
            this.qqCheckBox2.BackColor = System.Drawing.Color.Transparent;
            this.qqCheckBox2.Name = "qqCheckBox2";
            this.qqCheckBox2.Tag = "2";
            this.qqCheckBox2.UseVisualStyleBackColor = false;
            // 
            // qqCheckBox1
            // 
            resources.ApplyResources(this.qqCheckBox1, "qqCheckBox1");
            this.qqCheckBox1.BackColor = System.Drawing.Color.Transparent;
            this.qqCheckBox1.Checked = true;
            this.qqCheckBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.qqCheckBox1.Name = "qqCheckBox1";
            this.qqCheckBox1.Tag = "1";
            this.qqCheckBox1.UseVisualStyleBackColor = false;
            // 
            // pc_Processor
            // 
            this.pc_Processor.CategoryName = "Processor";
            this.pc_Processor.CounterName = "% Processor Time";
            this.pc_Processor.InstanceName = "_Total";
            // 
            // SingleMainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.BackgroundImage = global::ClouReaderDemo.Properties.Resources._100011;
            this.Controls.Add(this.panel_Middle);
            this.Controls.Add(this.panel_Debug);
            this.Controls.Add(this.panel_Top);
            this.ForeColor = System.Drawing.Color.Black;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "SingleMainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SingleMainForm_FormClosing);
            this.Load += new System.EventHandler(this.SingleMainForm_Load);
            this.Shown += new System.EventHandler(this.SingleMainForm_Shown);
            this.panel_Top.ResumeLayout(false);
            this.panel_Top.PerformLayout();
            this.tsm_Main.ResumeLayout(false);
            this.tsm_Main.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.panel_Debug.ResumeLayout(false);
            this.panel_Debug.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.panel_Middle.ResumeLayout(false);
            this.panel_MiddleCenter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Tags)).EndInit();
            this.cmsForGridView.ResumeLayout(false);
            this.panel_MiddleRight.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.led_Time)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.led_Speed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.led_Tag_ReadCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.led_Tag_Count)).EndInit();
            this.gb_ReadControl.ResumeLayout(false);
            this.gb_ReadControl.PerformLayout();
            this.gb_ReadType.ResumeLayout(false);
            this.gb_ReadType.PerformLayout();
            this.gb_TagType.ResumeLayout(false);
            this.gb_TagType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pc_Processor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_Top;
        private System.Windows.Forms.Panel panel_Debug;
        private System.Windows.Forms.Panel panel_Middle;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Connect;
        private System.Windows.Forms.ToolStripMenuItem tmsi_SerialConn;
        private System.Windows.Forms.ToolStripMenuItem tsmi_TCPClient;
        private System.Windows.Forms.ToolStrip tsm_Main;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Debug;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Send_Command;
        private System.Windows.Forms.ToolStripMenuItem tsmi_ReaderSetting;
        private System.Windows.Forms.ToolStripMenuItem tsmi_DebugOn;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel_MiddleRight;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox gb_ReadControl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lb_ReceiveCount;
        private System.Windows.Forms.Panel panel_MiddleCenter;
        private DataGridViewPlus dgv_Tags;
        private System.Windows.Forms.ToolStripDropDownButton tsddb_SelectColumn;
        private System.Windows.Forms.ToolStripMenuItem tsddm_tsmi_EPC;
        private System.Windows.Forms.ToolStripMenuItem tsddm_tsmi_TID;
        private System.Windows.Forms.ToolStripMenuItem tsddm_tsmi_UserData;
        private System.Windows.Forms.ToolStripMenuItem tsddm_tsmi_RSSI;
        private System.Windows.Forms.ToolStripMenuItem tsddm_tsmi_ReadTime;
        private System.Windows.Forms.ToolStripButton tsb_Stop;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Helper;
        private System.Windows.Forms.ToolStripMenuItem tsmi_GetReaderMsg;
        private System.Windows.Forms.ToolStripMenuItem tsmi_GetBaseBandVersion;
        private System.Windows.Forms.ToolStripMenuItem 帮助文档ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmi_SoftUpdate;
        private System.Windows.Forms.ToolStripMenuItem tsmi_ApplicationSoftUpdate;
        private System.Windows.Forms.ToolStripMenuItem tsmi_BasebandSoftUpdate;
        private System.Windows.Forms.ToolStripMenuItem bug反馈ToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton tsb_ClearList;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsb_ResetReader;
        private System.Windows.Forms.TextBox tb_DebugMsg;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel tssl_CPULoad;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel tssl_CacheSize;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel tssl_NowConnID;
        private System.Windows.Forms.ToolStripMenuItem tmsi_TagsExport;
        private MyFormTemplet.QQCheckBox qqCheckBox1;
        private MyFormTemplet.QQCheckBox qqCheckBox4;
        private MyFormTemplet.QQCheckBox qqCheckBox3;
        private MyFormTemplet.QQCheckBox qqCheckBox2;
        private System.Windows.Forms.ToolStripMenuItem tsddm_tsmi_ANT1;
        private System.Windows.Forms.ToolStripMenuItem tsddm_tsmi_ANT2;
        private System.Windows.Forms.ToolStripMenuItem tsddm_tsmi_ANT3;
        private System.Windows.Forms.ToolStripMenuItem tsddm_tsmi_ANT4;
        private System.Windows.Forms.ContextMenuStrip cmsForGridView;
        private System.Windows.Forms.ToolStripMenuItem cms_tsmi_Copy;
        private System.Windows.Forms.ToolStripMenuItem cms_tsmi_ClearList;
        private System.Windows.Forms.ToolStripMenuItem tsddm_tsmi_ReserveData;
        private System.Windows.Forms.ToolStripMenuItem tsmi_485Conn;
        private System.Windows.Forms.ToolStripMenuItem tmsi_Export_Text;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Export_Excel;
        private System.Windows.Forms.ToolStripMenuItem cms_tsmi_WriteEpc;
        private System.Windows.Forms.GroupBox gb_TagType;
        private MyFormTemplet.QQRadioButton rb_6b;
        private MyFormTemplet.QQRadioButton rb_6c;
        private System.Windows.Forms.GroupBox gb_ReadType;
        private MyFormTemplet.QQRadioButton rb_Single;
        private MyFormTemplet.QQRadioButton rb_While;
        private System.Windows.Forms.Label label5;
        private MyFormTemplet.RoundButton btn_GPI_0;
        private MyFormTemplet.RoundButton btn_GPI_3;
        private MyFormTemplet.RoundButton btn_GPI_2;
        private MyFormTemplet.RoundButton btn_GPI_1;
        private System.Windows.Forms.ToolStripMenuItem 配置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 读写器配置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmi_RFIDSetting;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Reader_Serial;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Reader_TCP;
        private System.Windows.Forms.ToolStripMenuItem tsmi_RestoreFactory;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Reader_485;
        private System.Windows.Forms.ToolStripMenuItem tsmi_AdvancedSettings;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Reader_TCPServerOrClient;
        private System.Windows.Forms.ToolStripMenuItem tsmi_RIFD_RF;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Exit;
        private System.Windows.Forms.ToolStripMenuItem tsmi_RFID_TagFilter;
        private System.Windows.Forms.ToolStripMenuItem tsmi_RFID_AutoFree;
        private System.Windows.Forms.ToolStripButton tsb_Read_Global;
        private System.Windows.Forms.ToolStripButton tsb_Read_Epc;
        private System.Windows.Forms.ToolStripButton tsb_Read_EPCTID;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsb_Write_EPC;
        private System.Windows.Forms.ToolStripButton tsb_Write_UserData;
        private System.Windows.Forms.ToolStripButton tsb_WriteGlobal;
        private System.Windows.Forms.ToolStripMenuItem tsmi_PowerCalibration;
        private System.Windows.Forms.ToolStripMenuItem cms_tsmi_WriteUserData;
        private System.Windows.Forms.ToolStripMenuItem tsmi_GPIOSetting;
        private System.Windows.Forms.ToolStripMenuItem tsmi_GPISetting;
        private System.Diagnostics.PerformanceCounter pc_Processor;
        private System.Windows.Forms.ToolStripMenuItem tsmi_TCPServer;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Performance;
        private System.Windows.Forms.ToolStripMenuItem tsmi_TagReadTest;
        private System.Windows.Forms.ToolStripMenuItem tsmi_TagReadWriteTest;
        private System.Windows.Forms.ToolStripDropDownButton tsddb_ConnectList;
        private System.Windows.Forms.ToolStripStatusLabel tssl_TotalCountName;
        private System.Windows.Forms.ToolStripStatusLabel tssl_TotalConnect;
        private System.Windows.Forms.ToolStripButton tsb_CloseNowConnect;
        private System.Windows.Forms.ToolStripMenuItem tsmi_GPISearch;
        private System.Windows.Forms.ToolStripMenuItem tsmi_GPOSetting;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Sound;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Sound_Beep;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Sound_Speaker;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Sound_Off;
        private System.Windows.Forms.ToolStripMenuItem tsmi_API_Test;
        private System.Windows.Forms.ToolStripMenuItem tsmi_WG;
        private System.Windows.Forms.ToolStripMenuItem tsmi_ReadGPO;
        private System.Windows.Forms.ToolStripMenuItem tsmi_TagRead6B_6C;
        private System.Windows.Forms.ToolStripMenuItem tsmi_StepRead;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Test_gj;
        private System.Windows.Forms.ToolStripMenuItem tsmi_BlacklistBeep;
        private System.Windows.Forms.ToolStripMenuItem tsmi_CheckListBeep;
        private MyFormTemplet.QQRadioButton rb_gb;
        private BW.BAR2EPC.SERVER.MAIN.LxLedControl led_Tag_Count;
        private BW.BAR2EPC.SERVER.MAIN.LxLedControl led_Tag_ReadCount;
        private BW.BAR2EPC.SERVER.MAIN.LxLedControl led_Time;
        private BW.BAR2EPC.SERVER.MAIN.LxLedControl led_Speed;
        private System.Windows.Forms.ToolStripMenuItem tsmi_SearchDevice;
        private System.Windows.Forms.ToolStripMenuItem tsms_HubTest;
        private MyFormTemplet.QQCheckBox qqCheckBox5;
        private MyFormTemplet.QQCheckBox qqCheckBox6;
        private MyFormTemplet.QQCheckBox qqCheckBox7;
        private MyFormTemplet.QQCheckBox qqCheckBox8;
        private System.Windows.Forms.ToolStripMenuItem tsddm_tsmi_ANT5;
        private System.Windows.Forms.ToolStripMenuItem tsddm_tsmi_ANT6;
        private System.Windows.Forms.ToolStripMenuItem tsddm_tsmi_ANT7;
        private System.Windows.Forms.ToolStripMenuItem tsddm_tsmi_ANT8;
        private System.Windows.Forms.ToolStripMenuItem tsmi_GetCacheTag;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Language;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Language_CN;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Language_EN;
        private System.Windows.Forms.ToolStripMenuItem tsmi_ClearCacheTag;
        private System.Windows.Forms.ToolStripMenuItem tsddm_tsmi_Frequency;
        private System.Windows.Forms.ToolStripMenuItem tsddm_tsmi_Phase;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_ReaderName;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_ANT5;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_ANT6;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_ANT7;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_ANT8;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_RSSI;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_Frequency;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_Phase;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_ReadTime;
    }
}