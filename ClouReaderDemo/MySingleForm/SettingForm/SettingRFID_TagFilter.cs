using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ClouReaderDemo.MySingleForm.SettingForm
{
    /// <summary>
    /// 重复标签过滤
    /// </summary>
    public partial class SettingRFID_TagFilter : BaseOption
    {
        ClouReaderAPI.ClouInterface.IAsynchronousMessage contextForm = null;
        public SettingRFID_TagFilter()
        {
            InitializeComponent();
        }

        public SettingRFID_TagFilter(string readerID, ClouReaderAPI.ClouInterface.IAsynchronousMessage contextForm)
            : this()
        {
            this.ConnID = readerID;
            this.contextForm = contextForm;
        }

        private void SettingRFID_TagFilter_Load(object sender, EventArgs e)
        {
            this.Width = 500;
            this.Height = 300;
            Init();
        }
        // 查询
        private void Init() 
        {
            String rtStr = ClouReaderAPI.CLReader.RFID_OPTION.GetTagUpdateParam(ConnID);
            String[] varStr = rtStr.Split('|');
            if (varStr.Length == 2)
            {
                tb_0010_09_00.Text = varStr[0];
                tb_0010_09_01.Text = varStr[1];
            }
        }
        // 配置
        private void btn_0010_09_Set_Click(object sender, EventArgs e)
        {
            String sendParam = "";
            try
            {
                if (!String.IsNullOrEmpty(tb_0010_09_00.Text))
                {
                    sendParam += "1," + tb_0010_09_00.Text + "&";
                }
                if (!String.IsNullOrEmpty(tb_0010_09_01.Text))
                {
                    sendParam += "2," + tb_0010_09_01.Text;
                }
                sendParam = sendParam.TrimEnd('&');
            }
            catch { }
            String rtStr = ClouReaderAPI.CLReader.RFID_OPTION.SetTagUpdateParam(ConnID, sendParam);
            ShowMessage(rtStr);
        }

        private void btn_Init_Click(object sender, EventArgs e)
        {
            Init();
        }
    }
}
