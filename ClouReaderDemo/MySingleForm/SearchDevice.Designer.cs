namespace ClouReaderDemo.MySingleForm
{
    partial class SearchDevice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchDevice));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tc_Main = new ClouReaderDemo.MyFormTemplet.QQTabControl();
            this.tp_SearchDevice = new System.Windows.Forms.TabPage();
            this.gb_Read_Result = new System.Windows.Forms.GroupBox();
            this.gb_TagList = new System.Windows.Forms.GroupBox();
            this.dgv_Devices = new ClouReaderDemo.DataGridViewPlus();
            this.clm_MAC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm_IP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm_ServerPort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm_RemoteIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm_RemotePort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm_WorkingMode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm_ConnectState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm_DeviceType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gb_Read_Control = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.gb_Tooltip = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_ClearList = new ClouReaderDemo.MyFormTemplet.QQButton();
            this.tp_Debug = new System.Windows.Forms.TabPage();
            this.tb_Msg = new System.Windows.Forms.TextBox();
            this.tc_Main.SuspendLayout();
            this.tp_SearchDevice.SuspendLayout();
            this.gb_Read_Result.SuspendLayout();
            this.gb_TagList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Devices)).BeginInit();
            this.gb_Read_Control.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.gb_Tooltip.SuspendLayout();
            this.tp_Debug.SuspendLayout();
            this.SuspendLayout();
            // 
            // tc_Main
            // 
            resources.ApplyResources(this.tc_Main, "tc_Main");
            this.tc_Main.BackColor = System.Drawing.Color.Transparent;
            this.tc_Main.BaseColor = System.Drawing.Color.White;
            this.tc_Main.BorderColor = System.Drawing.Color.White;
            this.tc_Main.Controls.Add(this.tp_SearchDevice);
            this.tc_Main.Controls.Add(this.tp_Debug);
            this.tc_Main.Name = "tc_Main";
            this.tc_Main.PageColor = System.Drawing.Color.White;
            this.tc_Main.SelectedIndex = 0;
            this.tc_Main.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            // 
            // tp_SearchDevice
            // 
            resources.ApplyResources(this.tp_SearchDevice, "tp_SearchDevice");
            this.tp_SearchDevice.BackColor = System.Drawing.Color.White;
            this.tp_SearchDevice.Controls.Add(this.gb_Read_Result);
            this.tp_SearchDevice.Controls.Add(this.gb_Read_Control);
            this.tp_SearchDevice.Name = "tp_SearchDevice";
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
            this.gb_TagList.Controls.Add(this.dgv_Devices);
            this.gb_TagList.Name = "gb_TagList";
            this.gb_TagList.TabStop = false;
            // 
            // dgv_Devices
            // 
            resources.ApplyResources(this.dgv_Devices, "dgv_Devices");
            this.dgv_Devices.AllowUserToAddRows = false;
            this.dgv_Devices.AllowUserToDeleteRows = false;
            this.dgv_Devices.AllowUserToResizeRows = false;
            this.dgv_Devices.BackgroundColor = System.Drawing.Color.White;
            this.dgv_Devices.CausesValidation = false;
            this.dgv_Devices.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.dgv_Devices.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clm_MAC,
            this.clm_IP,
            this.clm_ServerPort,
            this.clm_RemoteIP,
            this.clm_RemotePort,
            this.clm_WorkingMode,
            this.clm_ConnectState,
            this.clm_DeviceType});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Devices.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Devices.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.dgv_Devices.MultiSelect = false;
            this.dgv_Devices.Name = "dgv_Devices";
            this.dgv_Devices.ReadOnly = true;
            this.dgv_Devices.RowTemplate.Height = 23;
            this.dgv_Devices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Devices.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Devices_CellDoubleClick);
            // 
            // clm_MAC
            // 
            this.clm_MAC.DataPropertyName = "MAC";
            resources.ApplyResources(this.clm_MAC, "clm_MAC");
            this.clm_MAC.Name = "clm_MAC";
            this.clm_MAC.ReadOnly = true;
            // 
            // clm_IP
            // 
            this.clm_IP.DataPropertyName = "IP";
            resources.ApplyResources(this.clm_IP, "clm_IP");
            this.clm_IP.Name = "clm_IP";
            this.clm_IP.ReadOnly = true;
            // 
            // clm_ServerPort
            // 
            this.clm_ServerPort.DataPropertyName = "ServerPort";
            resources.ApplyResources(this.clm_ServerPort, "clm_ServerPort");
            this.clm_ServerPort.Name = "clm_ServerPort";
            this.clm_ServerPort.ReadOnly = true;
            // 
            // clm_RemoteIP
            // 
            resources.ApplyResources(this.clm_RemoteIP, "clm_RemoteIP");
            this.clm_RemoteIP.Name = "clm_RemoteIP";
            this.clm_RemoteIP.ReadOnly = true;
            // 
            // clm_RemotePort
            // 
            resources.ApplyResources(this.clm_RemotePort, "clm_RemotePort");
            this.clm_RemotePort.Name = "clm_RemotePort";
            this.clm_RemotePort.ReadOnly = true;
            // 
            // clm_WorkingMode
            // 
            resources.ApplyResources(this.clm_WorkingMode, "clm_WorkingMode");
            this.clm_WorkingMode.Name = "clm_WorkingMode";
            this.clm_WorkingMode.ReadOnly = true;
            // 
            // clm_ConnectState
            // 
            resources.ApplyResources(this.clm_ConnectState, "clm_ConnectState");
            this.clm_ConnectState.Name = "clm_ConnectState";
            this.clm_ConnectState.ReadOnly = true;
            // 
            // clm_DeviceType
            // 
            resources.ApplyResources(this.clm_DeviceType, "clm_DeviceType");
            this.clm_DeviceType.Name = "clm_DeviceType";
            this.clm_DeviceType.ReadOnly = true;
            // 
            // gb_Read_Control
            // 
            resources.ApplyResources(this.gb_Read_Control, "gb_Read_Control");
            this.gb_Read_Control.Controls.Add(this.pictureBox1);
            this.gb_Read_Control.Controls.Add(this.gb_Tooltip);
            this.gb_Read_Control.Controls.Add(this.btn_ClearList);
            this.gb_Read_Control.Name = "gb_Read_Control";
            this.gb_Read_Control.TabStop = false;
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::ClouReaderDemo.Properties.Resources._loading;
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // gb_Tooltip
            // 
            resources.ApplyResources(this.gb_Tooltip, "gb_Tooltip");
            this.gb_Tooltip.Controls.Add(this.label1);
            this.gb_Tooltip.Name = "gb_Tooltip";
            this.gb_Tooltip.TabStop = false;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // btn_ClearList
            // 
            resources.ApplyResources(this.btn_ClearList, "btn_ClearList");
            this.btn_ClearList.BackColor = System.Drawing.Color.Transparent;
            this.btn_ClearList.DownImage = ((System.Drawing.Image)(resources.GetObject("btn_ClearList.DownImage")));
            this.btn_ClearList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_ClearList.IsShowBorder = true;
            this.btn_ClearList.MoveImage = ((System.Drawing.Image)(resources.GetObject("btn_ClearList.MoveImage")));
            this.btn_ClearList.Name = "btn_ClearList";
            this.btn_ClearList.NormalImage = ((System.Drawing.Image)(resources.GetObject("btn_ClearList.NormalImage")));
            this.btn_ClearList.Tag = "0";
            this.btn_ClearList.UseVisualStyleBackColor = false;
            this.btn_ClearList.Click += new System.EventHandler(this.btn_ClearList_Click);
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
            // SearchDevice
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tc_Main);
            this.IsResize = false;
            this.Name = "SearchDevice";
            this.ShowIcon = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SearchDevice_FormClosing);
            this.Load += new System.EventHandler(this.SearchDevice_Load);
            this.tc_Main.ResumeLayout(false);
            this.tp_SearchDevice.ResumeLayout(false);
            this.gb_Read_Result.ResumeLayout(false);
            this.gb_TagList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Devices)).EndInit();
            this.gb_Read_Control.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.gb_Tooltip.ResumeLayout(false);
            this.gb_Tooltip.PerformLayout();
            this.tp_Debug.ResumeLayout(false);
            this.tp_Debug.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MyFormTemplet.QQTabControl tc_Main;
        private System.Windows.Forms.TabPage tp_SearchDevice;
        private System.Windows.Forms.GroupBox gb_Read_Result;
        private System.Windows.Forms.GroupBox gb_TagList;
        private DataGridViewPlus dgv_Devices;
        private System.Windows.Forms.GroupBox gb_Read_Control;
        private MyFormTemplet.QQButton btn_ClearList;
        private System.Windows.Forms.TabPage tp_Debug;
        private System.Windows.Forms.TextBox tb_Msg;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_MAC;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_IP;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_ServerPort;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_RemoteIP;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_RemotePort;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_WorkingMode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_ConnectState;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_DeviceType;
        private System.Windows.Forms.GroupBox gb_Tooltip;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
    }
}