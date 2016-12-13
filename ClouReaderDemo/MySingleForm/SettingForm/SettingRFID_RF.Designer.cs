namespace ClouReaderDemo.MySingleForm.SettingForm
{
    partial class SettingRFID_RF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingRFID_RF));
            this.cmb_RF = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmb_RFType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gb_List = new System.Windows.Forms.GroupBox();
            this.tb_PointList = new System.Windows.Forms.TextBox();
            this.btn_0010_05_Set = new ClouReaderDemo.MyFormTemplet.QQButton();
            this.btn_Add = new ClouReaderDemo.MyFormTemplet.QQButton();
            this.btn_AddAll = new ClouReaderDemo.MyFormTemplet.QQButton();
            this.btn_Clear = new ClouReaderDemo.MyFormTemplet.QQButton();
            this.lb_AllPoint = new System.Windows.Forms.ListBox();
            this.btn_SetRF = new ClouReaderDemo.MyFormTemplet.QQButton();
            this.gb_List.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmb_RF
            // 
            resources.ApplyResources(this.cmb_RF, "cmb_RF");
            this.cmb_RF.FormattingEnabled = true;
            this.cmb_RF.Items.AddRange(new object[] {
            resources.GetString("cmb_RF.Items"),
            resources.GetString("cmb_RF.Items1"),
            resources.GetString("cmb_RF.Items2"),
            resources.GetString("cmb_RF.Items3"),
            resources.GetString("cmb_RF.Items4"),
            resources.GetString("cmb_RF.Items5"),
            resources.GetString("cmb_RF.Items6")});
            this.cmb_RF.Name = "cmb_RF";
            this.cmb_RF.SelectedIndexChanged += new System.EventHandler(this.cmb_RF_SelectedIndexChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Name = "label1";
            // 
            // cmb_RFType
            // 
            resources.ApplyResources(this.cmb_RFType, "cmb_RFType");
            this.cmb_RFType.FormattingEnabled = true;
            this.cmb_RFType.Items.AddRange(new object[] {
            resources.GetString("cmb_RFType.Items"),
            resources.GetString("cmb_RFType.Items1")});
            this.cmb_RFType.Name = "cmb_RFType";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Name = "label2";
            // 
            // gb_List
            // 
            resources.ApplyResources(this.gb_List, "gb_List");
            this.gb_List.BackColor = System.Drawing.Color.Transparent;
            this.gb_List.Controls.Add(this.tb_PointList);
            this.gb_List.Name = "gb_List";
            this.gb_List.TabStop = false;
            // 
            // tb_PointList
            // 
            resources.ApplyResources(this.tb_PointList, "tb_PointList");
            this.tb_PointList.Name = "tb_PointList";
            this.tb_PointList.ReadOnly = true;
            // 
            // btn_0010_05_Set
            // 
            resources.ApplyResources(this.btn_0010_05_Set, "btn_0010_05_Set");
            this.btn_0010_05_Set.BackColor = System.Drawing.Color.Transparent;
            this.btn_0010_05_Set.DownImage = ((System.Drawing.Image)(resources.GetObject("btn_0010_05_Set.DownImage")));
            this.btn_0010_05_Set.IsShowBorder = true;
            this.btn_0010_05_Set.MoveImage = ((System.Drawing.Image)(resources.GetObject("btn_0010_05_Set.MoveImage")));
            this.btn_0010_05_Set.Name = "btn_0010_05_Set";
            this.btn_0010_05_Set.NormalImage = ((System.Drawing.Image)(resources.GetObject("btn_0010_05_Set.NormalImage")));
            this.btn_0010_05_Set.UseVisualStyleBackColor = false;
            this.btn_0010_05_Set.Click += new System.EventHandler(this.btn_0010_05_Set_Click);
            // 
            // btn_Add
            // 
            resources.ApplyResources(this.btn_Add, "btn_Add");
            this.btn_Add.BackColor = System.Drawing.Color.Transparent;
            this.btn_Add.DownImage = ((System.Drawing.Image)(resources.GetObject("btn_Add.DownImage")));
            this.btn_Add.IsShowBorder = true;
            this.btn_Add.MoveImage = ((System.Drawing.Image)(resources.GetObject("btn_Add.MoveImage")));
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.NormalImage = ((System.Drawing.Image)(resources.GetObject("btn_Add.NormalImage")));
            this.btn_Add.UseVisualStyleBackColor = false;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // btn_AddAll
            // 
            resources.ApplyResources(this.btn_AddAll, "btn_AddAll");
            this.btn_AddAll.BackColor = System.Drawing.Color.Transparent;
            this.btn_AddAll.DownImage = ((System.Drawing.Image)(resources.GetObject("btn_AddAll.DownImage")));
            this.btn_AddAll.IsShowBorder = true;
            this.btn_AddAll.MoveImage = ((System.Drawing.Image)(resources.GetObject("btn_AddAll.MoveImage")));
            this.btn_AddAll.Name = "btn_AddAll";
            this.btn_AddAll.NormalImage = ((System.Drawing.Image)(resources.GetObject("btn_AddAll.NormalImage")));
            this.btn_AddAll.UseVisualStyleBackColor = false;
            this.btn_AddAll.Click += new System.EventHandler(this.btn_AddAll_Click);
            // 
            // btn_Clear
            // 
            resources.ApplyResources(this.btn_Clear, "btn_Clear");
            this.btn_Clear.BackColor = System.Drawing.Color.Transparent;
            this.btn_Clear.DownImage = ((System.Drawing.Image)(resources.GetObject("btn_Clear.DownImage")));
            this.btn_Clear.IsShowBorder = true;
            this.btn_Clear.MoveImage = ((System.Drawing.Image)(resources.GetObject("btn_Clear.MoveImage")));
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.NormalImage = ((System.Drawing.Image)(resources.GetObject("btn_Clear.NormalImage")));
            this.btn_Clear.UseVisualStyleBackColor = false;
            this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click);
            // 
            // lb_AllPoint
            // 
            resources.ApplyResources(this.lb_AllPoint, "lb_AllPoint");
            this.lb_AllPoint.FormattingEnabled = true;
            this.lb_AllPoint.Name = "lb_AllPoint";
            this.lb_AllPoint.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            // 
            // btn_SetRF
            // 
            resources.ApplyResources(this.btn_SetRF, "btn_SetRF");
            this.btn_SetRF.BackColor = System.Drawing.Color.Transparent;
            this.btn_SetRF.DownImage = ((System.Drawing.Image)(resources.GetObject("btn_SetRF.DownImage")));
            this.btn_SetRF.IsShowBorder = true;
            this.btn_SetRF.MoveImage = ((System.Drawing.Image)(resources.GetObject("btn_SetRF.MoveImage")));
            this.btn_SetRF.Name = "btn_SetRF";
            this.btn_SetRF.NormalImage = ((System.Drawing.Image)(resources.GetObject("btn_SetRF.NormalImage")));
            this.btn_SetRF.UseVisualStyleBackColor = false;
            this.btn_SetRF.Click += new System.EventHandler(this.btn_SetRF_Click);
            // 
            // SettingRFID_RF
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_SetRF);
            this.Controls.Add(this.lb_AllPoint);
            this.Controls.Add(this.btn_Clear);
            this.Controls.Add(this.btn_AddAll);
            this.Controls.Add(this.btn_Add);
            this.Controls.Add(this.btn_0010_05_Set);
            this.Controls.Add(this.gb_List);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmb_RFType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmb_RF);
            this.IsResize = false;
            this.Name = "SettingRFID_RF";
            this.ShowIcon = false;
            this.SysButton = ClouReaderDemo.Forms.ESysButton.Close;
            this.Load += new System.EventHandler(this.SettingRFID_RF_Load);
            this.gb_List.ResumeLayout(false);
            this.gb_List.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmb_RF;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmb_RFType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gb_List;
        private MyFormTemplet.QQButton btn_0010_05_Set;
        private System.Windows.Forms.TextBox tb_PointList;
        private MyFormTemplet.QQButton btn_Add;
        private MyFormTemplet.QQButton btn_AddAll;
        private MyFormTemplet.QQButton btn_Clear;
        private System.Windows.Forms.ListBox lb_AllPoint;
        private MyFormTemplet.QQButton btn_SetRF;
    }
}