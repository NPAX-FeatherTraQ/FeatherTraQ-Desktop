namespace ClouReaderDemo
{
    partial class HubMainForm
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
            this.gb_Top = new System.Windows.Forms.GroupBox();
            this.tc_Control = new System.Windows.Forms.TabControl();
            this.tp_Config = new System.Windows.Forms.TabPage();
            this.tp_TagList = new System.Windows.Forms.TabPage();
            this.panel_main = new System.Windows.Forms.Panel();
            this.panel_Right = new System.Windows.Forms.Panel();
            this.gb_Top.SuspendLayout();
            this.tc_Control.SuspendLayout();
            this.panel_main.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb_Top
            // 
            this.gb_Top.BackColor = System.Drawing.Color.Transparent;
            this.gb_Top.Controls.Add(this.tc_Control);
            this.gb_Top.Dock = System.Windows.Forms.DockStyle.Top;
            this.gb_Top.Location = new System.Drawing.Point(3, 26);
            this.gb_Top.Name = "gb_Top";
            this.gb_Top.Size = new System.Drawing.Size(835, 237);
            this.gb_Top.TabIndex = 0;
            this.gb_Top.TabStop = false;
            this.gb_Top.Text = "控制区：";
            // 
            // tc_Control
            // 
            this.tc_Control.Controls.Add(this.tp_Config);
            this.tc_Control.Controls.Add(this.tp_TagList);
            this.tc_Control.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tc_Control.Location = new System.Drawing.Point(3, 17);
            this.tc_Control.Name = "tc_Control";
            this.tc_Control.SelectedIndex = 0;
            this.tc_Control.Size = new System.Drawing.Size(829, 217);
            this.tc_Control.TabIndex = 0;
            // 
            // tp_Config
            // 
            this.tp_Config.Location = new System.Drawing.Point(4, 22);
            this.tp_Config.Name = "tp_Config";
            this.tp_Config.Padding = new System.Windows.Forms.Padding(3);
            this.tp_Config.Size = new System.Drawing.Size(821, 191);
            this.tp_Config.TabIndex = 0;
            this.tp_Config.Text = "集线器配置";
            this.tp_Config.UseVisualStyleBackColor = true;
            // 
            // tp_TagList
            // 
            this.tp_TagList.Location = new System.Drawing.Point(4, 22);
            this.tp_TagList.Name = "tp_TagList";
            this.tp_TagList.Padding = new System.Windows.Forms.Padding(3);
            this.tp_TagList.Size = new System.Drawing.Size(885, 191);
            this.tp_TagList.TabIndex = 1;
            this.tp_TagList.Text = "标签列表";
            this.tp_TagList.UseVisualStyleBackColor = true;
            // 
            // panel_main
            // 
            this.panel_main.BackColor = System.Drawing.Color.Transparent;
            this.panel_main.Controls.Add(this.panel_Right);
            this.panel_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_main.Location = new System.Drawing.Point(3, 263);
            this.panel_main.Name = "panel_main";
            this.panel_main.Size = new System.Drawing.Size(835, 250);
            this.panel_main.TabIndex = 1;
            // 
            // panel_Right
            // 
            this.panel_Right.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Right.Location = new System.Drawing.Point(0, 0);
            this.panel_Right.Name = "panel_Right";
            this.panel_Right.Size = new System.Drawing.Size(835, 250);
            this.panel_Right.TabIndex = 2;
            // 
            // HubMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ClouReaderDemo.Properties.Resources._100011;
            this.ClientSize = new System.Drawing.Size(841, 516);
            this.Controls.Add(this.panel_main);
            this.Controls.Add(this.gb_Top);
            this.Name = "HubMainForm";
            this.Padding = new System.Windows.Forms.Padding(3, 26, 3, 3);
            this.Text = "集线器演示";
            this.Load += new System.EventHandler(this.HubMainForm_Load);
            this.Shown += new System.EventHandler(this.HubMainForm_Shown);
            this.gb_Top.ResumeLayout(false);
            this.tc_Control.ResumeLayout(false);
            this.panel_main.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_Top;
        private System.Windows.Forms.Panel panel_main;
        private System.Windows.Forms.Panel panel_Right;
        private System.Windows.Forms.TabControl tc_Control;
        private System.Windows.Forms.TabPage tp_Config;
        private System.Windows.Forms.TabPage tp_TagList;
    }
}