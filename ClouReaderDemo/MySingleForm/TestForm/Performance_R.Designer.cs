namespace ClouReaderDemo.MySingleForm.TestForm
{
    partial class Performance_R
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Performance_R));
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
            this.gb_ImmediateMsg = new System.Windows.Forms.GroupBox();
            this.lb_ProcessCount = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.pb_Read = new System.Windows.Forms.ProgressBar();
            this.lb_ReadTime = new System.Windows.Forms.Label();
            this.lb_SuccessReadTagsCount = new System.Windows.Forms.Label();
            this.lb_AverageSpeed = new System.Windows.Forms.Label();
            this.lb_ImmediateSpeed = new System.Windows.Forms.Label();
            this.lb_TagCount = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.gb_Read_Control = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_ReadMaxCount = new ClouReaderDemo.MyFormTemplet.QQTextBoxEx();
            this.label1 = new System.Windows.Forms.Label();
            this.rb_ReadByCount = new ClouReaderDemo.MyFormTemplet.QQRadioButton();
            this.rb_ReadByTime = new ClouReaderDemo.MyFormTemplet.QQRadioButton();
            this.tb_ReadMaxTime = new ClouReaderDemo.MyFormTemplet.QQTextBoxEx();
            this.btn_StartReadTest = new ClouReaderDemo.MyFormTemplet.QQButton();
            this.tp_Debug = new System.Windows.Forms.TabPage();
            this.tb_Msg = new System.Windows.Forms.TextBox();
            this.tp_Test = new System.Windows.Forms.TabPage();
            this.tc_Main.SuspendLayout();
            this.tp_TagRead.SuspendLayout();
            this.gb_Read_Result.SuspendLayout();
            this.gb_TagList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Tags)).BeginInit();
            this.gb_ImmediateMsg.SuspendLayout();
            this.gb_Read_Control.SuspendLayout();
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
            this.tc_Main.Controls.Add(this.tp_Debug);
            this.tc_Main.Controls.Add(this.tp_Test);
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
            this.gb_Read_Result.Controls.Add(this.gb_ImmediateMsg);
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
            // gb_ImmediateMsg
            // 
            resources.ApplyResources(this.gb_ImmediateMsg, "gb_ImmediateMsg");
            this.gb_ImmediateMsg.Controls.Add(this.lb_ProcessCount);
            this.gb_ImmediateMsg.Controls.Add(this.label11);
            this.gb_ImmediateMsg.Controls.Add(this.pb_Read);
            this.gb_ImmediateMsg.Controls.Add(this.lb_ReadTime);
            this.gb_ImmediateMsg.Controls.Add(this.lb_SuccessReadTagsCount);
            this.gb_ImmediateMsg.Controls.Add(this.lb_AverageSpeed);
            this.gb_ImmediateMsg.Controls.Add(this.lb_ImmediateSpeed);
            this.gb_ImmediateMsg.Controls.Add(this.lb_TagCount);
            this.gb_ImmediateMsg.Controls.Add(this.label8);
            this.gb_ImmediateMsg.Controls.Add(this.label7);
            this.gb_ImmediateMsg.Controls.Add(this.label6);
            this.gb_ImmediateMsg.Controls.Add(this.label5);
            this.gb_ImmediateMsg.Controls.Add(this.label4);
            this.gb_ImmediateMsg.Name = "gb_ImmediateMsg";
            this.gb_ImmediateMsg.TabStop = false;
            // 
            // lb_ProcessCount
            // 
            resources.ApplyResources(this.lb_ProcessCount, "lb_ProcessCount");
            this.lb_ProcessCount.ForeColor = System.Drawing.Color.Red;
            this.lb_ProcessCount.Name = "lb_ProcessCount";
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.BackColor = System.Drawing.Color.White;
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.label11.Name = "label11";
            // 
            // pb_Read
            // 
            resources.ApplyResources(this.pb_Read, "pb_Read");
            this.pb_Read.Name = "pb_Read";
            // 
            // lb_ReadTime
            // 
            resources.ApplyResources(this.lb_ReadTime, "lb_ReadTime");
            this.lb_ReadTime.ForeColor = System.Drawing.Color.Red;
            this.lb_ReadTime.Name = "lb_ReadTime";
            // 
            // lb_SuccessReadTagsCount
            // 
            resources.ApplyResources(this.lb_SuccessReadTagsCount, "lb_SuccessReadTagsCount");
            this.lb_SuccessReadTagsCount.ForeColor = System.Drawing.Color.Red;
            this.lb_SuccessReadTagsCount.Name = "lb_SuccessReadTagsCount";
            // 
            // lb_AverageSpeed
            // 
            resources.ApplyResources(this.lb_AverageSpeed, "lb_AverageSpeed");
            this.lb_AverageSpeed.ForeColor = System.Drawing.Color.Red;
            this.lb_AverageSpeed.Name = "lb_AverageSpeed";
            // 
            // lb_ImmediateSpeed
            // 
            resources.ApplyResources(this.lb_ImmediateSpeed, "lb_ImmediateSpeed");
            this.lb_ImmediateSpeed.ForeColor = System.Drawing.Color.Red;
            this.lb_ImmediateSpeed.Name = "lb_ImmediateSpeed";
            // 
            // lb_TagCount
            // 
            resources.ApplyResources(this.lb_TagCount, "lb_TagCount");
            this.lb_TagCount.ForeColor = System.Drawing.Color.Red;
            this.lb_TagCount.Name = "lb_TagCount";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label8.Name = "label8";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label7.Name = "label7";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label6.Name = "label6";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label5.Name = "label5";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label4.Name = "label4";
            // 
            // gb_Read_Control
            // 
            resources.ApplyResources(this.gb_Read_Control, "gb_Read_Control");
            this.gb_Read_Control.Controls.Add(this.label2);
            this.gb_Read_Control.Controls.Add(this.tb_ReadMaxCount);
            this.gb_Read_Control.Controls.Add(this.label1);
            this.gb_Read_Control.Controls.Add(this.rb_ReadByCount);
            this.gb_Read_Control.Controls.Add(this.rb_ReadByTime);
            this.gb_Read_Control.Controls.Add(this.tb_ReadMaxTime);
            this.gb_Read_Control.Controls.Add(this.btn_StartReadTest);
            this.gb_Read_Control.Name = "gb_Read_Control";
            this.gb_Read_Control.TabStop = false;
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // tb_ReadMaxCount
            // 
            resources.ApplyResources(this.tb_ReadMaxCount, "tb_ReadMaxCount");
            this.tb_ReadMaxCount.BackColor = System.Drawing.Color.Transparent;
            this.tb_ReadMaxCount.Icon = null;
            this.tb_ReadMaxCount.IconIsButton = false;
            this.tb_ReadMaxCount.IsPasswordChat = '\0';
            this.tb_ReadMaxCount.IsSystemPasswordChar = false;
            this.tb_ReadMaxCount.Lines = new string[] {
        "50"};
            this.tb_ReadMaxCount.MaxLength = 32767;
            this.tb_ReadMaxCount.Multiline = false;
            this.tb_ReadMaxCount.Name = "tb_ReadMaxCount";
            this.tb_ReadMaxCount.ReadOnly = false;
            this.tb_ReadMaxCount.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tb_ReadMaxCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tb_ReadMaxCount.WaterColor = System.Drawing.Color.DarkGray;
            this.tb_ReadMaxCount.WaterText = "50";
            this.tb_ReadMaxCount.WordWrap = true;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // rb_ReadByCount
            // 
            resources.ApplyResources(this.rb_ReadByCount, "rb_ReadByCount");
            this.rb_ReadByCount.BackColor = System.Drawing.Color.Transparent;
            this.rb_ReadByCount.Name = "rb_ReadByCount";
            this.rb_ReadByCount.UseVisualStyleBackColor = false;
            // 
            // rb_ReadByTime
            // 
            resources.ApplyResources(this.rb_ReadByTime, "rb_ReadByTime");
            this.rb_ReadByTime.BackColor = System.Drawing.Color.Transparent;
            this.rb_ReadByTime.Checked = true;
            this.rb_ReadByTime.Name = "rb_ReadByTime";
            this.rb_ReadByTime.TabStop = true;
            this.rb_ReadByTime.UseVisualStyleBackColor = false;
            // 
            // tb_ReadMaxTime
            // 
            resources.ApplyResources(this.tb_ReadMaxTime, "tb_ReadMaxTime");
            this.tb_ReadMaxTime.BackColor = System.Drawing.Color.Transparent;
            this.tb_ReadMaxTime.Icon = null;
            this.tb_ReadMaxTime.IconIsButton = false;
            this.tb_ReadMaxTime.IsPasswordChat = '\0';
            this.tb_ReadMaxTime.IsSystemPasswordChar = false;
            this.tb_ReadMaxTime.Lines = new string[] {
        "5000"};
            this.tb_ReadMaxTime.MaxLength = 32767;
            this.tb_ReadMaxTime.Multiline = false;
            this.tb_ReadMaxTime.Name = "tb_ReadMaxTime";
            this.tb_ReadMaxTime.ReadOnly = false;
            this.tb_ReadMaxTime.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tb_ReadMaxTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tb_ReadMaxTime.WaterColor = System.Drawing.Color.DarkGray;
            this.tb_ReadMaxTime.WaterText = "5000";
            this.tb_ReadMaxTime.WordWrap = true;
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
            // tp_Test
            // 
            resources.ApplyResources(this.tp_Test, "tp_Test");
            this.tp_Test.BackColor = System.Drawing.Color.White;
            this.tp_Test.Name = "tp_Test";
            // 
            // Performance_R
            // 
            this.AcceptButton = this.btn_StartReadTest;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tc_Main);
            this.IsResize = false;
            this.Name = "Performance_R";
            this.ShowIcon = false;
            this.SysButton = ClouReaderDemo.Forms.ESysButton.Close;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Performance_FormClosing);
            this.tc_Main.ResumeLayout(false);
            this.tp_TagRead.ResumeLayout(false);
            this.gb_Read_Result.ResumeLayout(false);
            this.gb_TagList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Tags)).EndInit();
            this.gb_ImmediateMsg.ResumeLayout(false);
            this.gb_ImmediateMsg.PerformLayout();
            this.gb_Read_Control.ResumeLayout(false);
            this.gb_Read_Control.PerformLayout();
            this.tp_Debug.ResumeLayout(false);
            this.tp_Debug.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MyFormTemplet.QQTabControl tc_Main;
        private System.Windows.Forms.TabPage tp_TagRead;
        private System.Windows.Forms.GroupBox gb_Read_Control;
        private MyFormTemplet.QQRadioButton rb_ReadByTime;
        private MyFormTemplet.QQTextBoxEx tb_ReadMaxTime;
        private MyFormTemplet.QQButton btn_StartReadTest;
        private System.Windows.Forms.Label label1;
        private MyFormTemplet.QQRadioButton rb_ReadByCount;
        private MyFormTemplet.QQTextBoxEx tb_ReadMaxCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gb_Read_Result;
        private System.Windows.Forms.GroupBox gb_ImmediateMsg;
        private System.Windows.Forms.Label lb_ReadTime;
        private System.Windows.Forms.Label lb_SuccessReadTagsCount;
        private System.Windows.Forms.Label lb_AverageSpeed;
        private System.Windows.Forms.Label lb_ImmediateSpeed;
        private System.Windows.Forms.Label lb_TagCount;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabPage tp_Debug;
        private System.Windows.Forms.TextBox tb_Msg;
        private System.Windows.Forms.GroupBox gb_TagList;
        private System.Windows.Forms.ProgressBar pb_Read;
        private System.Windows.Forms.Label label11;
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
        private System.Windows.Forms.Label lb_ProcessCount;
        private System.Windows.Forms.TabPage tp_Test;
    }
}