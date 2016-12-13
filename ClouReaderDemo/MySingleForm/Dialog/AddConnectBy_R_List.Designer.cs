namespace ClouReaderDemo.MySingleForm.TestForm.Dialog
{
    partial class AddConnectBy_R_List
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddConnectBy_R_List));
            this.tb_485Address = new ClouReaderDemo.MyFormTemplet.QQTextBoxEx();
            this.cb_ComNum = new System.Windows.Forms.ComboBox();
            this.cb_BPS = new System.Windows.Forms.ComboBox();
            this.btn_OK = new System.Windows.Forms.Button();
            this.tb_ConnParam = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cb_ConnectType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_ANT_4 = new ClouReaderDemo.MyFormTemplet.QQCheckBox();
            this.cb_ANT_3 = new ClouReaderDemo.MyFormTemplet.QQCheckBox();
            this.cb_ANT_2 = new ClouReaderDemo.MyFormTemplet.QQCheckBox();
            this.cb_ANT_1 = new ClouReaderDemo.MyFormTemplet.QQCheckBox();
            this.SuspendLayout();
            // 
            // tb_485Address
            // 
            resources.ApplyResources(this.tb_485Address, "tb_485Address");
            this.tb_485Address.BackColor = System.Drawing.Color.Transparent;
            this.tb_485Address.Icon = null;
            this.tb_485Address.IconIsButton = false;
            this.tb_485Address.IsPasswordChat = '\0';
            this.tb_485Address.IsSystemPasswordChar = false;
            this.tb_485Address.Lines = new string[] {
        "1"};
            this.tb_485Address.MaxLength = 32767;
            this.tb_485Address.Multiline = false;
            this.tb_485Address.Name = "tb_485Address";
            this.tb_485Address.ReadOnly = false;
            this.tb_485Address.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tb_485Address.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tb_485Address.WaterColor = System.Drawing.Color.DarkGray;
            this.tb_485Address.WaterText = "485";
            this.tb_485Address.WordWrap = true;
            // 
            // cb_ComNum
            // 
            resources.ApplyResources(this.cb_ComNum, "cb_ComNum");
            this.cb_ComNum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ComNum.FormattingEnabled = true;
            this.cb_ComNum.Items.AddRange(new object[] {
            resources.GetString("cb_ComNum.Items")});
            this.cb_ComNum.Name = "cb_ComNum";
            this.cb_ComNum.DropDown += new System.EventHandler(this.cb_ComNum_DropDown);
            // 
            // cb_BPS
            // 
            resources.ApplyResources(this.cb_BPS, "cb_BPS");
            this.cb_BPS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_BPS.FormattingEnabled = true;
            this.cb_BPS.Items.AddRange(new object[] {
            resources.GetString("cb_BPS.Items"),
            resources.GetString("cb_BPS.Items1"),
            resources.GetString("cb_BPS.Items2"),
            resources.GetString("cb_BPS.Items3"),
            resources.GetString("cb_BPS.Items4")});
            this.cb_BPS.Name = "cb_BPS";
            // 
            // btn_OK
            // 
            resources.ApplyResources(this.btn_OK, "btn_OK");
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // tb_ConnParam
            // 
            resources.ApplyResources(this.tb_ConnParam, "tb_ConnParam");
            this.tb_ConnParam.Name = "tb_ConnParam";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Name = "label2";
            // 
            // cb_ConnectType
            // 
            resources.ApplyResources(this.cb_ConnectType, "cb_ConnectType");
            this.cb_ConnectType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ConnectType.FormattingEnabled = true;
            this.cb_ConnectType.Items.AddRange(new object[] {
            resources.GetString("cb_ConnectType.Items"),
            resources.GetString("cb_ConnectType.Items1"),
            resources.GetString("cb_ConnectType.Items2")});
            this.cb_ConnectType.Name = "cb_ConnectType";
            this.cb_ConnectType.SelectedIndexChanged += new System.EventHandler(this.cb_ConnectType_SelectedIndexChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Name = "label1";
            // 
            // cb_ANT_4
            // 
            resources.ApplyResources(this.cb_ANT_4, "cb_ANT_4");
            this.cb_ANT_4.BackColor = System.Drawing.Color.Transparent;
            this.cb_ANT_4.Name = "cb_ANT_4";
            this.cb_ANT_4.Tag = "8";
            this.cb_ANT_4.UseVisualStyleBackColor = false;
            // 
            // cb_ANT_3
            // 
            resources.ApplyResources(this.cb_ANT_3, "cb_ANT_3");
            this.cb_ANT_3.BackColor = System.Drawing.Color.Transparent;
            this.cb_ANT_3.Name = "cb_ANT_3";
            this.cb_ANT_3.Tag = "4";
            this.cb_ANT_3.UseVisualStyleBackColor = false;
            // 
            // cb_ANT_2
            // 
            resources.ApplyResources(this.cb_ANT_2, "cb_ANT_2");
            this.cb_ANT_2.BackColor = System.Drawing.Color.Transparent;
            this.cb_ANT_2.Name = "cb_ANT_2";
            this.cb_ANT_2.Tag = "2";
            this.cb_ANT_2.UseVisualStyleBackColor = false;
            // 
            // cb_ANT_1
            // 
            resources.ApplyResources(this.cb_ANT_1, "cb_ANT_1");
            this.cb_ANT_1.BackColor = System.Drawing.Color.Transparent;
            this.cb_ANT_1.Checked = true;
            this.cb_ANT_1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_ANT_1.Name = "cb_ANT_1";
            this.cb_ANT_1.Tag = "1";
            this.cb_ANT_1.UseVisualStyleBackColor = false;
            // 
            // AddConnectBy_R_List
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ClouReaderDemo.Properties.Resources._100011;
            this.Controls.Add(this.cb_ANT_4);
            this.Controls.Add(this.cb_ANT_3);
            this.Controls.Add(this.cb_ANT_2);
            this.Controls.Add(this.cb_ANT_1);
            this.Controls.Add(this.tb_485Address);
            this.Controls.Add(this.cb_ComNum);
            this.Controls.Add(this.cb_BPS);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.tb_ConnParam);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cb_ConnectType);
            this.Controls.Add(this.label1);
            this.IsResize = false;
            this.Name = "AddConnectBy_R_List";
            this.ShowIcon = false;
            this.SysButton = ClouReaderDemo.Forms.ESysButton.Close;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MyFormTemplet.QQTextBoxEx tb_485Address;
        private System.Windows.Forms.ComboBox cb_ComNum;
        private System.Windows.Forms.ComboBox cb_BPS;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.TextBox tb_ConnParam;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cb_ConnectType;
        private System.Windows.Forms.Label label1;
        private MyFormTemplet.QQCheckBox cb_ANT_4;
        private MyFormTemplet.QQCheckBox cb_ANT_3;
        private MyFormTemplet.QQCheckBox cb_ANT_2;
        private MyFormTemplet.QQCheckBox cb_ANT_1;
    }
}