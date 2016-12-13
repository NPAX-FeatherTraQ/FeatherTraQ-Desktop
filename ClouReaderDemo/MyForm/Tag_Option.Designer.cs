namespace ClouReaderDemo.MyForm
{
    partial class Tag_Option
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tp_Main = new System.Windows.Forms.TabPage();
            this.gb_WriteTag = new System.Windows.Forms.GroupBox();
            this.cb_0010_11_DataType_Pwd_Item = new System.Windows.Forms.ComboBox();
            this.cb_0010_11_DataType_EPC_Item = new System.Windows.Forms.ComboBox();
            this.lb_0010_11_BlockLen = new System.Windows.Forms.Label();
            this.tb_0010_11_BlockLen = new System.Windows.Forms.TextBox();
            this.cb_0010_11_BlockWrite = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_0010_11_WriteDataStart = new System.Windows.Forms.TextBox();
            this.btn_0010_11 = new System.Windows.Forms.Button();
            this.tb_0010_11_WriteData = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_0010_11_DataType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_0010_12 = new System.Windows.Forms.Button();
            this.cb_0010_12_LockType = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cb_0010_12_LockArea = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btn_0010_13 = new System.Windows.Forms.Button();
            this.tb_0010_13_DestroyPwd = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.gb_TagMatch = new System.Windows.Forms.GroupBox();
            this.tb_0010_11_AccessPwd = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chk_0010_11_Ant3 = new System.Windows.Forms.CheckBox();
            this.chk_0010_11_Ant2 = new System.Windows.Forms.CheckBox();
            this.chk_0010_11_Ant1 = new System.Windows.Forms.CheckBox();
            this.chk_0010_11_Ant0 = new System.Windows.Forms.CheckBox();
            this.cb_0010_11_MatchType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_0010_11_MatchStart = new System.Windows.Forms.TextBox();
            this.lb_0010_11_MatchStart = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tp_Main.SuspendLayout();
            this.gb_WriteTag.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.gb_TagMatch.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tp_Main);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabControl1.Location = new System.Drawing.Point(3, 208);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(899, 317);
            this.tabControl1.TabIndex = 0;
            // 
            // tp_Main
            // 
            this.tp_Main.Controls.Add(this.gb_WriteTag);
            this.tp_Main.Location = new System.Drawing.Point(4, 22);
            this.tp_Main.Name = "tp_Main";
            this.tp_Main.Padding = new System.Windows.Forms.Padding(3);
            this.tp_Main.Size = new System.Drawing.Size(891, 291);
            this.tp_Main.TabIndex = 0;
            this.tp_Main.Text = "- 写 -";
            this.tp_Main.UseVisualStyleBackColor = true;
            // 
            // gb_WriteTag
            // 
            this.gb_WriteTag.Controls.Add(this.cb_0010_11_DataType_Pwd_Item);
            this.gb_WriteTag.Controls.Add(this.cb_0010_11_DataType_EPC_Item);
            this.gb_WriteTag.Controls.Add(this.lb_0010_11_BlockLen);
            this.gb_WriteTag.Controls.Add(this.tb_0010_11_BlockLen);
            this.gb_WriteTag.Controls.Add(this.cb_0010_11_BlockWrite);
            this.gb_WriteTag.Controls.Add(this.label6);
            this.gb_WriteTag.Controls.Add(this.tb_0010_11_WriteDataStart);
            this.gb_WriteTag.Controls.Add(this.btn_0010_11);
            this.gb_WriteTag.Controls.Add(this.tb_0010_11_WriteData);
            this.gb_WriteTag.Controls.Add(this.label3);
            this.gb_WriteTag.Controls.Add(this.cb_0010_11_DataType);
            this.gb_WriteTag.Controls.Add(this.label2);
            this.gb_WriteTag.Dock = System.Windows.Forms.DockStyle.Top;
            this.gb_WriteTag.Location = new System.Drawing.Point(3, 3);
            this.gb_WriteTag.Name = "gb_WriteTag";
            this.gb_WriteTag.Size = new System.Drawing.Size(885, 186);
            this.gb_WriteTag.TabIndex = 0;
            this.gb_WriteTag.TabStop = false;
            this.gb_WriteTag.Text = "标签写：";
            // 
            // cb_0010_11_DataType_Pwd_Item
            // 
            this.cb_0010_11_DataType_Pwd_Item.FormattingEnabled = true;
            this.cb_0010_11_DataType_Pwd_Item.Items.AddRange(new object[] {
            "销毁密码",
            "访问密码"});
            this.cb_0010_11_DataType_Pwd_Item.Location = new System.Drawing.Point(370, 36);
            this.cb_0010_11_DataType_Pwd_Item.Name = "cb_0010_11_DataType_Pwd_Item";
            this.cb_0010_11_DataType_Pwd_Item.Size = new System.Drawing.Size(74, 20);
            this.cb_0010_11_DataType_Pwd_Item.TabIndex = 28;
            this.cb_0010_11_DataType_Pwd_Item.SelectedIndexChanged += new System.EventHandler(this.cb_0010_11_DataType_Pwd_Item_SelectedIndexChanged);
            // 
            // cb_0010_11_DataType_EPC_Item
            // 
            this.cb_0010_11_DataType_EPC_Item.FormattingEnabled = true;
            this.cb_0010_11_DataType_EPC_Item.Items.AddRange(new object[] {
            "PC",
            "EPC"});
            this.cb_0010_11_DataType_EPC_Item.Location = new System.Drawing.Point(374, 36);
            this.cb_0010_11_DataType_EPC_Item.Name = "cb_0010_11_DataType_EPC_Item";
            this.cb_0010_11_DataType_EPC_Item.Size = new System.Drawing.Size(42, 20);
            this.cb_0010_11_DataType_EPC_Item.TabIndex = 27;
            this.cb_0010_11_DataType_EPC_Item.SelectedIndexChanged += new System.EventHandler(this.cb_0010_11_DataType_EPC_Item_SelectedIndexChanged);
            // 
            // lb_0010_11_BlockLen
            // 
            this.lb_0010_11_BlockLen.AutoSize = true;
            this.lb_0010_11_BlockLen.Location = new System.Drawing.Point(37, 79);
            this.lb_0010_11_BlockLen.Name = "lb_0010_11_BlockLen";
            this.lb_0010_11_BlockLen.Size = new System.Drawing.Size(53, 12);
            this.lb_0010_11_BlockLen.TabIndex = 26;
            this.lb_0010_11_BlockLen.Text = "块大小：";
            // 
            // tb_0010_11_BlockLen
            // 
            this.tb_0010_11_BlockLen.Location = new System.Drawing.Point(96, 76);
            this.tb_0010_11_BlockLen.Name = "tb_0010_11_BlockLen";
            this.tb_0010_11_BlockLen.Size = new System.Drawing.Size(60, 21);
            this.tb_0010_11_BlockLen.TabIndex = 25;
            this.tb_0010_11_BlockLen.Text = "1";
            // 
            // cb_0010_11_BlockWrite
            // 
            this.cb_0010_11_BlockWrite.AutoSize = true;
            this.cb_0010_11_BlockWrite.Location = new System.Drawing.Point(162, 78);
            this.cb_0010_11_BlockWrite.Name = "cb_0010_11_BlockWrite";
            this.cb_0010_11_BlockWrite.Size = new System.Drawing.Size(48, 16);
            this.cb_0010_11_BlockWrite.TabIndex = 24;
            this.cb_0010_11_BlockWrite.Tag = "8";
            this.cb_0010_11_BlockWrite.Text = "块写";
            this.cb_0010_11_BlockWrite.UseVisualStyleBackColor = true;
            this.cb_0010_11_BlockWrite.CheckedChanged += new System.EventHandler(this.cb_0010_11_BlockWrite_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(213, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 12);
            this.label6.TabIndex = 17;
            this.label6.Text = "内容起始地址(H)：";
            // 
            // tb_0010_11_WriteDataStart
            // 
            this.tb_0010_11_WriteDataStart.AccessibleDescription = "";
            this.tb_0010_11_WriteDataStart.Location = new System.Drawing.Point(329, 36);
            this.tb_0010_11_WriteDataStart.Name = "tb_0010_11_WriteDataStart";
            this.tb_0010_11_WriteDataStart.Size = new System.Drawing.Size(39, 21);
            this.tb_0010_11_WriteDataStart.TabIndex = 16;
            this.tb_0010_11_WriteDataStart.Text = "0001";
            // 
            // btn_0010_11
            // 
            this.btn_0010_11.Location = new System.Drawing.Point(601, 60);
            this.btn_0010_11.Name = "btn_0010_11";
            this.btn_0010_11.Size = new System.Drawing.Size(84, 31);
            this.btn_0010_11.TabIndex = 11;
            this.btn_0010_11.Text = "确认写标签";
            this.btn_0010_11.UseVisualStyleBackColor = true;
            this.btn_0010_11.Click += new System.EventHandler(this.btn_0010_11_Click);
            // 
            // tb_0010_11_WriteData
            // 
            this.tb_0010_11_WriteData.Location = new System.Drawing.Point(329, 76);
            this.tb_0010_11_WriteData.Multiline = true;
            this.tb_0010_11_WriteData.Name = "tb_0010_11_WriteData";
            this.tb_0010_11_WriteData.Size = new System.Drawing.Size(196, 65);
            this.tb_0010_11_WriteData.TabIndex = 10;
            this.tb_0010_11_WriteData.Text = "00000000";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(238, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "写入内容(H)：";
            // 
            // cb_0010_11_DataType
            // 
            this.cb_0010_11_DataType.FormattingEnabled = true;
            this.cb_0010_11_DataType.Items.AddRange(new object[] {
            "保留区",
            "EPC区",
            "TID区",
            "用户数据区"});
            this.cb_0010_11_DataType.Location = new System.Drawing.Point(94, 37);
            this.cb_0010_11_DataType.Name = "cb_0010_11_DataType";
            this.cb_0010_11_DataType.Size = new System.Drawing.Size(99, 20);
            this.cb_0010_11_DataType.TabIndex = 6;
            this.cb_0010_11_DataType.SelectedIndexChanged += new System.EventHandler(this.cb_0010_11_DataType_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "写入区域：";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(859, 291);
            this.tabPage1.TabIndex = 1;
            this.tabPage1.Text = "- 锁 -";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_0010_12);
            this.groupBox1.Controls.Add(this.cb_0010_12_LockType);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cb_0010_12_LockArea);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(853, 154);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "标签锁：";
            // 
            // btn_0010_12
            // 
            this.btn_0010_12.Location = new System.Drawing.Point(500, 50);
            this.btn_0010_12.Name = "btn_0010_12";
            this.btn_0010_12.Size = new System.Drawing.Size(95, 31);
            this.btn_0010_12.TabIndex = 12;
            this.btn_0010_12.Text = "确认操作标签";
            this.btn_0010_12.UseVisualStyleBackColor = true;
            this.btn_0010_12.Click += new System.EventHandler(this.btn_0010_12_Click);
            // 
            // cb_0010_12_LockType
            // 
            this.cb_0010_12_LockType.AutoCompleteCustomSource.AddRange(new string[] {
            "解锁",
            "锁定",
            "永久解锁",
            "永久锁定"});
            this.cb_0010_12_LockType.FormattingEnabled = true;
            this.cb_0010_12_LockType.Items.AddRange(new object[] {
            "解锁",
            "锁定",
            "永久解锁",
            "永久锁定"});
            this.cb_0010_12_LockType.Location = new System.Drawing.Point(349, 56);
            this.cb_0010_12_LockType.Name = "cb_0010_12_LockType";
            this.cb_0010_12_LockType.Size = new System.Drawing.Size(99, 20);
            this.cb_0010_12_LockType.TabIndex = 10;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(266, 59);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 12);
            this.label8.TabIndex = 9;
            this.label8.Text = "锁操作类型：";
            // 
            // cb_0010_12_LockArea
            // 
            this.cb_0010_12_LockArea.AutoCompleteCustomSource.AddRange(new string[] {
            "灭活密码区",
            "访问密码区",
            "EPC区",
            "TID区",
            "用户数据区"});
            this.cb_0010_12_LockArea.FormattingEnabled = true;
            this.cb_0010_12_LockArea.Items.AddRange(new object[] {
            "灭活密码区",
            "访问密码区",
            "EPC区",
            "TID区",
            "用户数据区"});
            this.cb_0010_12_LockArea.Location = new System.Drawing.Point(131, 56);
            this.cb_0010_12_LockArea.Name = "cb_0010_12_LockArea";
            this.cb_0010_12_LockArea.Size = new System.Drawing.Size(99, 20);
            this.cb_0010_12_LockArea.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(62, 59);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 7;
            this.label7.Text = "锁定区域：";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btn_0010_13);
            this.tabPage2.Controls.Add(this.tb_0010_13_DestroyPwd);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(859, 291);
            this.tabPage2.TabIndex = 2;
            this.tabPage2.Text = "- 销毁 -";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btn_0010_13
            // 
            this.btn_0010_13.Location = new System.Drawing.Point(412, 94);
            this.btn_0010_13.Name = "btn_0010_13";
            this.btn_0010_13.Size = new System.Drawing.Size(95, 31);
            this.btn_0010_13.TabIndex = 29;
            this.btn_0010_13.Text = "确认销毁标签";
            this.btn_0010_13.UseVisualStyleBackColor = true;
            this.btn_0010_13.Click += new System.EventHandler(this.btn_0010_13_Click);
            // 
            // tb_0010_13_DestroyPwd
            // 
            this.tb_0010_13_DestroyPwd.Location = new System.Drawing.Point(278, 100);
            this.tb_0010_13_DestroyPwd.Name = "tb_0010_13_DestroyPwd";
            this.tb_0010_13_DestroyPwd.Size = new System.Drawing.Size(100, 21);
            this.tb_0010_13_DestroyPwd.TabIndex = 28;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(189, 103);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 12);
            this.label9.TabIndex = 27;
            this.label9.Text = "销毁密码(H)：";
            // 
            // gb_TagMatch
            // 
            this.gb_TagMatch.BackColor = System.Drawing.Color.Transparent;
            this.gb_TagMatch.Controls.Add(this.tb_0010_11_AccessPwd);
            this.gb_TagMatch.Controls.Add(this.label4);
            this.gb_TagMatch.Controls.Add(this.label1);
            this.gb_TagMatch.Controls.Add(this.chk_0010_11_Ant3);
            this.gb_TagMatch.Controls.Add(this.chk_0010_11_Ant2);
            this.gb_TagMatch.Controls.Add(this.chk_0010_11_Ant1);
            this.gb_TagMatch.Controls.Add(this.chk_0010_11_Ant0);
            this.gb_TagMatch.Controls.Add(this.cb_0010_11_MatchType);
            this.gb_TagMatch.Controls.Add(this.label5);
            this.gb_TagMatch.Controls.Add(this.tb_0010_11_MatchStart);
            this.gb_TagMatch.Controls.Add(this.lb_0010_11_MatchStart);
            this.gb_TagMatch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb_TagMatch.Location = new System.Drawing.Point(3, 26);
            this.gb_TagMatch.Name = "gb_TagMatch";
            this.gb_TagMatch.Size = new System.Drawing.Size(899, 182);
            this.gb_TagMatch.TabIndex = 1;
            this.gb_TagMatch.TabStop = false;
            this.gb_TagMatch.Text = "标签匹配参数：";
            // 
            // tb_0010_11_AccessPwd
            // 
            this.tb_0010_11_AccessPwd.Location = new System.Drawing.Point(567, 31);
            this.tb_0010_11_AccessPwd.Name = "tb_0010_11_AccessPwd";
            this.tb_0010_11_AccessPwd.Size = new System.Drawing.Size(100, 21);
            this.tb_0010_11_AccessPwd.TabIndex = 26;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(487, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 12);
            this.label4.TabIndex = 25;
            this.label4.Text = "访问密码(H)：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 24;
            this.label1.Text = "天线号：";
            // 
            // chk_0010_11_Ant3
            // 
            this.chk_0010_11_Ant3.AutoSize = true;
            this.chk_0010_11_Ant3.Location = new System.Drawing.Point(204, 35);
            this.chk_0010_11_Ant3.Name = "chk_0010_11_Ant3";
            this.chk_0010_11_Ant3.Size = new System.Drawing.Size(48, 16);
            this.chk_0010_11_Ant3.TabIndex = 23;
            this.chk_0010_11_Ant3.Tag = "8";
            this.chk_0010_11_Ant3.Text = "ANT4";
            this.chk_0010_11_Ant3.UseVisualStyleBackColor = true;
            // 
            // chk_0010_11_Ant2
            // 
            this.chk_0010_11_Ant2.AutoSize = true;
            this.chk_0010_11_Ant2.Location = new System.Drawing.Point(157, 35);
            this.chk_0010_11_Ant2.Name = "chk_0010_11_Ant2";
            this.chk_0010_11_Ant2.Size = new System.Drawing.Size(48, 16);
            this.chk_0010_11_Ant2.TabIndex = 22;
            this.chk_0010_11_Ant2.Tag = "4";
            this.chk_0010_11_Ant2.Text = "ANT3";
            this.chk_0010_11_Ant2.UseVisualStyleBackColor = true;
            // 
            // chk_0010_11_Ant1
            // 
            this.chk_0010_11_Ant1.AutoSize = true;
            this.chk_0010_11_Ant1.Location = new System.Drawing.Point(110, 35);
            this.chk_0010_11_Ant1.Name = "chk_0010_11_Ant1";
            this.chk_0010_11_Ant1.Size = new System.Drawing.Size(48, 16);
            this.chk_0010_11_Ant1.TabIndex = 21;
            this.chk_0010_11_Ant1.Tag = "2";
            this.chk_0010_11_Ant1.Text = "ANT2";
            this.chk_0010_11_Ant1.UseVisualStyleBackColor = true;
            // 
            // chk_0010_11_Ant0
            // 
            this.chk_0010_11_Ant0.AutoSize = true;
            this.chk_0010_11_Ant0.Location = new System.Drawing.Point(62, 35);
            this.chk_0010_11_Ant0.Name = "chk_0010_11_Ant0";
            this.chk_0010_11_Ant0.Size = new System.Drawing.Size(48, 16);
            this.chk_0010_11_Ant0.TabIndex = 20;
            this.chk_0010_11_Ant0.Tag = "1";
            this.chk_0010_11_Ant0.Text = "ANT1";
            this.chk_0010_11_Ant0.UseVisualStyleBackColor = true;
            // 
            // cb_0010_11_MatchType
            // 
            this.cb_0010_11_MatchType.AutoCompleteCustomSource.AddRange(new string[] {
            "不匹配",
            "匹配EPC区",
            "匹配TID区",
            "匹配用户数据区"});
            this.cb_0010_11_MatchType.FormattingEnabled = true;
            this.cb_0010_11_MatchType.Items.AddRange(new object[] {
            "不匹配",
            "匹配EPC区",
            "匹配TID区",
            "匹配用户数据区"});
            this.cb_0010_11_MatchType.Location = new System.Drawing.Point(374, 33);
            this.cb_0010_11_MatchType.Name = "cb_0010_11_MatchType";
            this.cb_0010_11_MatchType.Size = new System.Drawing.Size(99, 20);
            this.cb_0010_11_MatchType.TabIndex = 17;
            this.cb_0010_11_MatchType.SelectedIndexChanged += new System.EventHandler(this.cb_0010_11_MatchType_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(304, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 16;
            this.label5.Text = "匹配方式：";
            // 
            // tb_0010_11_MatchStart
            // 
            this.tb_0010_11_MatchStart.AccessibleDescription = "";
            this.tb_0010_11_MatchStart.Location = new System.Drawing.Point(375, 69);
            this.tb_0010_11_MatchStart.Name = "tb_0010_11_MatchStart";
            this.tb_0010_11_MatchStart.Size = new System.Drawing.Size(100, 21);
            this.tb_0010_11_MatchStart.TabIndex = 19;
            this.tb_0010_11_MatchStart.Text = "0000";
            // 
            // lb_0010_11_MatchStart
            // 
            this.lb_0010_11_MatchStart.AutoSize = true;
            this.lb_0010_11_MatchStart.Location = new System.Drawing.Point(263, 72);
            this.lb_0010_11_MatchStart.Name = "lb_0010_11_MatchStart";
            this.lb_0010_11_MatchStart.Size = new System.Drawing.Size(107, 12);
            this.lb_0010_11_MatchStart.TabIndex = 18;
            this.lb_0010_11_MatchStart.Text = "匹配起始地址(H)：";
            // 
            // Tag_Option
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 528);
            this.Controls.Add(this.gb_TagMatch);
            this.Controls.Add(this.tabControl1);
            this.IsResize = false;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "Tag_Option";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.SysButton = ClouReaderDemo.Forms.ESysButton.Close_Mini;
            this.Text = "标签写/锁/毁";
            this.tabControl1.ResumeLayout(false);
            this.tp_Main.ResumeLayout(false);
            this.gb_WriteTag.ResumeLayout(false);
            this.gb_WriteTag.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.gb_TagMatch.ResumeLayout(false);
            this.gb_TagMatch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tp_Main;
        private System.Windows.Forms.GroupBox gb_TagMatch;
        private System.Windows.Forms.ComboBox cb_0010_11_MatchType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_0010_11_MatchStart;
        private System.Windows.Forms.Label lb_0010_11_MatchStart;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox gb_WriteTag;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tb_0010_11_WriteDataStart;
        private System.Windows.Forms.Button btn_0010_11;
        private System.Windows.Forms.TextBox tb_0010_11_WriteData;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cb_0010_11_DataType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chk_0010_11_Ant3;
        private System.Windows.Forms.CheckBox chk_0010_11_Ant2;
        private System.Windows.Forms.CheckBox chk_0010_11_Ant1;
        private System.Windows.Forms.CheckBox chk_0010_11_Ant0;
        private System.Windows.Forms.CheckBox cb_0010_11_BlockWrite;
        private System.Windows.Forms.TextBox tb_0010_11_BlockLen;
        private System.Windows.Forms.Label lb_0010_11_BlockLen;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cb_0010_12_LockArea;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cb_0010_12_LockType;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btn_0010_12;
        private System.Windows.Forms.TextBox tb_0010_11_AccessPwd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_0010_13;
        private System.Windows.Forms.TextBox tb_0010_13_DestroyPwd;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cb_0010_11_DataType_EPC_Item;
        private System.Windows.Forms.ComboBox cb_0010_11_DataType_Pwd_Item;
    }
}