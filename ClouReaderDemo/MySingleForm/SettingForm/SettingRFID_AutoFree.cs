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
    /// 自动空闲
    /// </summary>
    public partial class SettingRFID_AutoFree : BaseOption
    {
        ClouReaderAPI.ClouInterface.IAsynchronousMessage contextForm = null;
        public SettingRFID_AutoFree()
        {
            InitializeComponent();
        }

        public SettingRFID_AutoFree(string readerID, ClouReaderAPI.ClouInterface.IAsynchronousMessage contextForm):this()
        {
            this.ConnID = readerID;
            this.contextForm = contextForm;
        }

        private void SettingRFID_AutoFree_Load(object sender, EventArgs e)
        {
            this.Width = 500;
            this.Height = 300;
            Init();
        }
        // 查询
        private void Init() 
        {
            String rtStr = ClouReaderAPI.CLReader.RFID_OPTION.GetReaderAutoSleepParam(ConnID);
            String[] varStr = rtStr.Split('|');
            if (varStr.Length == 2)
            {
                cb_0010_0D_00.SelectedIndex = byte.Parse(varStr[0]);
                tb_0010_0D_01.Text = varStr[1];
            }
        }
        // 配置
        private void btn_0010_0D_Set_Click(object sender, EventArgs e)
        {
            String sendParam = "";
            try
            {
                if (cb_0010_0D_00.SelectedIndex == 0)
                {
                    sendParam += cb_0010_0D_00.SelectedIndex;
                }
                else
                {
                    sendParam += cb_0010_0D_00.SelectedIndex + "|1," + tb_0010_0D_01.Text.Trim();
                }
            }
            catch { }
            String rtStr = ClouReaderAPI.CLReader.RFID_OPTION.SetReaderAutoSleepParam(ConnID, sendParam);
            ShowMessage(rtStr);
        }

        private void btn_Init_Click(object sender, EventArgs e)
        {
            Init();
        }
    }
}
