namespace ClouReaderDemo
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("串口模式");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("TCP客户端模式");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("TCP服务器端模式");
            this.contextMSforTree = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextItem_addConn = new System.Windows.Forms.ToolStripMenuItem();
            this.contextItem_CloseAllConn = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.tsmi_Connect = new System.Windows.Forms.ToolStripMenuItem();
            this.tmsi_SerialConn = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_TCPClient = new System.Windows.Forms.ToolStripMenuItem();
            this.tCP服务端模式ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Debug = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Param_MID01 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_ReaderSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_RFIDParam = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tb_DebugMsg = new System.Windows.Forms.TextBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssl_ReceiveCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssl_CacheSize = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.tv_ConnectList = new System.Windows.Forms.TreeView();
            this.imageListTree = new System.Windows.Forms.ImageList(this.components);
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.contextMSForConn = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmi_cms_ReaderParam = new System.Windows.Forms.ToolStripMenuItem();
            this.rFID配置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.读写标签ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Connect_Close = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMSforTree.SuspendLayout();
            this.panel1.SuspendLayout();
            this.toolStripMain.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.panel2.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMSForConn.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMSforTree
            // 
            this.contextMSforTree.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextItem_addConn,
            this.contextItem_CloseAllConn});
            this.contextMSforTree.Name = "contextMSforTree";
            this.contextMSforTree.Size = new System.Drawing.Size(149, 48);
            this.contextMSforTree.Opening += new System.ComponentModel.CancelEventHandler(this.contextMSforTree_Opening);
            // 
            // contextItem_addConn
            // 
            this.contextItem_addConn.Name = "contextItem_addConn";
            this.contextItem_addConn.Size = new System.Drawing.Size(148, 22);
            this.contextItem_addConn.Text = "添加连接";
            this.contextItem_addConn.Click += new System.EventHandler(this.contextItem_addConn_Click);
            // 
            // contextItem_CloseAllConn
            // 
            this.contextItem_CloseAllConn.Name = "contextItem_CloseAllConn";
            this.contextItem_CloseAllConn.Size = new System.Drawing.Size(148, 22);
            this.contextItem_CloseAllConn.Text = "关闭所有连接";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.toolStripMain);
            this.panel1.Controls.Add(this.menuStrip);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1008, 48);
            this.panel1.TabIndex = 0;
            // 
            // toolStripMain
            // 
            this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
            this.toolStripMain.Location = new System.Drawing.Point(0, 25);
            this.toolStripMain.Name = "toolStripMain";
            this.toolStripMain.Size = new System.Drawing.Size(1008, 25);
            this.toolStripMain.TabIndex = 1;
            this.toolStripMain.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "查询基带软件版本";
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_Connect,
            this.tsmi_Debug,
            this.tsmi_ReaderSetting});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1008, 25);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // tsmi_Connect
            // 
            this.tsmi_Connect.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmsi_SerialConn,
            this.tsmi_TCPClient,
            this.tCP服务端模式ToolStripMenuItem});
            this.tsmi_Connect.Name = "tsmi_Connect";
            this.tsmi_Connect.Size = new System.Drawing.Size(80, 21);
            this.tsmi_Connect.Text = "连接读写器";
            // 
            // tmsi_SerialConn
            // 
            this.tmsi_SerialConn.Name = "tmsi_SerialConn";
            this.tmsi_SerialConn.Size = new System.Drawing.Size(158, 22);
            this.tmsi_SerialConn.Text = "串口模式";
            this.tmsi_SerialConn.Click += new System.EventHandler(this.tsmi_SerialConn_Click);
            // 
            // tsmi_TCPClient
            // 
            this.tsmi_TCPClient.Name = "tsmi_TCPClient";
            this.tsmi_TCPClient.Size = new System.Drawing.Size(158, 22);
            this.tsmi_TCPClient.Text = "TCP客户端模式";
            this.tsmi_TCPClient.Click += new System.EventHandler(this.tsmi_TCPClient_Click);
            // 
            // tCP服务端模式ToolStripMenuItem
            // 
            this.tCP服务端模式ToolStripMenuItem.Name = "tCP服务端模式ToolStripMenuItem";
            this.tCP服务端模式ToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.tCP服务端模式ToolStripMenuItem.Text = "TCP服务端模式";
            // 
            // tsmi_Debug
            // 
            this.tsmi_Debug.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_Param_MID01});
            this.tsmi_Debug.Name = "tsmi_Debug";
            this.tsmi_Debug.Size = new System.Drawing.Size(59, 21);
            this.tsmi_Debug.Text = "Debug";
            // 
            // tsmi_Param_MID01
            // 
            this.tsmi_Param_MID01.Name = "tsmi_Param_MID01";
            this.tsmi_Param_MID01.Size = new System.Drawing.Size(172, 22);
            this.tsmi_Param_MID01.Text = "查询基带软件版本";
            // 
            // tsmi_ReaderSetting
            // 
            this.tsmi_ReaderSetting.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_RFIDParam});
            this.tsmi_ReaderSetting.Name = "tsmi_ReaderSetting";
            this.tsmi_ReaderSetting.Size = new System.Drawing.Size(80, 21);
            this.tsmi_ReaderSetting.Text = "读写器设置";
            // 
            // tsmi_RFIDParam
            // 
            this.tsmi_RFIDParam.Name = "tsmi_RFIDParam";
            this.tsmi_RFIDParam.Size = new System.Drawing.Size(127, 22);
            this.tsmi_RFIDParam.Text = "RFID配置";
            this.tsmi_RFIDParam.Click += new System.EventHandler(this.tsmi_RFIDParam_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tb_DebugMsg);
            this.panel2.Controls.Add(this.statusStrip);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 448);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1008, 114);
            this.panel2.TabIndex = 1;
            // 
            // tb_DebugMsg
            // 
            this.tb_DebugMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_DebugMsg.Location = new System.Drawing.Point(0, 0);
            this.tb_DebugMsg.Multiline = true;
            this.tb_DebugMsg.Name = "tb_DebugMsg";
            this.tb_DebugMsg.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_DebugMsg.Size = new System.Drawing.Size(1008, 92);
            this.tb_DebugMsg.TabIndex = 1;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.tssl_ReceiveCount,
            this.toolStripStatusLabel3,
            this.tssl_CacheSize});
            this.statusStrip.Location = new System.Drawing.Point(0, 92);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1008, 22);
            this.statusStrip.TabIndex = 0;
            this.statusStrip.Text = "状态栏";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(815, 17);
            this.toolStripStatusLabel1.Spring = true;
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(80, 17);
            this.toolStripStatusLabel2.Text = "读取总次数：";
            // 
            // tssl_ReceiveCount
            // 
            this.tssl_ReceiveCount.Name = "tssl_ReceiveCount";
            this.tssl_ReceiveCount.Size = new System.Drawing.Size(15, 17);
            this.tssl_ReceiveCount.Text = "0";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(68, 17);
            this.toolStripStatusLabel3.Text = "缓存容量：";
            // 
            // tssl_CacheSize
            // 
            this.tssl_CacheSize.Name = "tssl_CacheSize";
            this.tssl_CacheSize.Size = new System.Drawing.Size(15, 17);
            this.tssl_CacheSize.Text = "0";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dataGridView1);
            this.panel3.Controls.Add(this.splitter1);
            this.panel3.Controls.Add(this.tv_ConnectList);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 48);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1008, 400);
            this.panel3.TabIndex = 2;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(182, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(826, 400);
            this.dataGridView1.TabIndex = 1;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(179, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 400);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // tv_ConnectList
            // 
            this.tv_ConnectList.Dock = System.Windows.Forms.DockStyle.Left;
            this.tv_ConnectList.ImageIndex = 0;
            this.tv_ConnectList.ImageList = this.imageListTree;
            this.tv_ConnectList.Location = new System.Drawing.Point(0, 0);
            this.tv_ConnectList.Name = "tv_ConnectList";
            treeNode1.ContextMenuStrip = this.contextMSforTree;
            treeNode1.Name = "SerialRoot";
            treeNode1.Text = "串口模式";
            treeNode2.ContextMenuStrip = this.contextMSforTree;
            treeNode2.Name = "RootTcpClient";
            treeNode2.Text = "TCP客户端模式";
            treeNode3.ContextMenuStrip = this.contextMSforTree;
            treeNode3.Name = "RootTcpServer";
            treeNode3.Text = "TCP服务器端模式";
            this.tv_ConnectList.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3});
            this.tv_ConnectList.SelectedImageIndex = 0;
            this.tv_ConnectList.Size = new System.Drawing.Size(179, 400);
            this.tv_ConnectList.TabIndex = 0;
            this.tv_ConnectList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tv_ConnectList_MouseClick);
            // 
            // imageListTree
            // 
            this.imageListTree.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListTree.ImageStream")));
            this.imageListTree.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListTree.Images.SetKeyName(0, "folder.png");
            // 
            // splitter2
            // 
            this.splitter2.Cursor = System.Windows.Forms.Cursors.HSplit;
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter2.Location = new System.Drawing.Point(0, 445);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(1008, 3);
            this.splitter2.TabIndex = 3;
            this.splitter2.TabStop = false;
            // 
            // contextMSForConn
            // 
            this.contextMSForConn.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_cms_ReaderParam,
            this.rFID配置ToolStripMenuItem,
            this.读写标签ToolStripMenuItem,
            this.tsmi_Connect_Close});
            this.contextMSForConn.Name = "contextMSForConn";
            this.contextMSForConn.Size = new System.Drawing.Size(153, 114);
            // 
            // tsmi_cms_ReaderParam
            // 
            this.tsmi_cms_ReaderParam.Name = "tsmi_cms_ReaderParam";
            this.tsmi_cms_ReaderParam.Size = new System.Drawing.Size(152, 22);
            this.tsmi_cms_ReaderParam.Text = "读写器配置";
            this.tsmi_cms_ReaderParam.Click += new System.EventHandler(this.tsmi_cms_ReaderParam_Click);
            // 
            // rFID配置ToolStripMenuItem
            // 
            this.rFID配置ToolStripMenuItem.Name = "rFID配置ToolStripMenuItem";
            this.rFID配置ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.rFID配置ToolStripMenuItem.Text = "RFID配置";
            // 
            // 读写标签ToolStripMenuItem
            // 
            this.读写标签ToolStripMenuItem.Name = "读写标签ToolStripMenuItem";
            this.读写标签ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.读写标签ToolStripMenuItem.Text = "读/写标签";
            // 
            // tsmi_Connect_Close
            // 
            this.tsmi_Connect_Close.Name = "tsmi_Connect_Close";
            this.tsmi_Connect_Close.Size = new System.Drawing.Size(152, 22);
            this.tsmi_Connect_Close.Text = "关闭连接";
            this.tsmi_Connect_Close.Click += new System.EventHandler(this.tsmi_Connect_Close_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 562);
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.Text = "B2 Demo";
            this.contextMSforTree.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStripMain.ResumeLayout(false);
            this.toolStripMain.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMSForConn.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TreeView tv_ConnectList;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.TextBox tb_DebugMsg;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.ImageList imageListTree;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Connect;
        private System.Windows.Forms.ToolStripMenuItem tmsi_SerialConn;
        private System.Windows.Forms.ToolStripMenuItem tsmi_TCPClient;
        private System.Windows.Forms.ToolStripMenuItem tCP服务端模式ToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel tssl_ReceiveCount;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel tssl_CacheSize;
        private System.Windows.Forms.ToolStrip toolStripMain;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Debug;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Param_MID01;
        private System.Windows.Forms.ToolStripMenuItem tsmi_ReaderSetting;
        private System.Windows.Forms.ToolStripMenuItem tsmi_RFIDParam;
        private System.Windows.Forms.ContextMenuStrip contextMSforTree;
        private System.Windows.Forms.ToolStripMenuItem contextItem_addConn;
        private System.Windows.Forms.ToolStripMenuItem contextItem_CloseAllConn;
        private System.Windows.Forms.ContextMenuStrip contextMSForConn;
        private System.Windows.Forms.ToolStripMenuItem tsmi_cms_ReaderParam;
        private System.Windows.Forms.ToolStripMenuItem rFID配置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 读写标签ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Connect_Close;
    }
}