using ClouReaderAPI.ClouInterface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ClouReaderDemo.MySingleForm.TestForm
{
    public partial class Tag_Option6B : BaseOption
    {
        IAsynchronousMessage contextForm = null;
        Int32 AntNum = 0;                          // 所选的天线编号

        String[] EPCdata = new String[] { "", "", "" };  // EPC,TID,UserData   ,当前选择的标签数据

        #region 读写器能力

        private int minDB = 0;                                            // 最小功率
        private int maxDB = 36;                                           // 最大功率
        private int antCount = 2;                                         // 天线数目
        private List<Int32> bandList = new List<Int32>();                 // 频段列表
        private List<Int32> RFIDProtocolList = new List<Int32>();         // RFID协议列表

        #endregion

        public Tag_Option6B()
        {
            InitializeComponent();
        }

        public Tag_Option6B(string readerID, String[] epcData, Int32 antNum, IAsynchronousMessage contextForm)
            : this()
        {
            this.ConnID = readerID;
            this.EPCdata = epcData;
            this.contextForm = contextForm;
            this.AntNum = antNum;
            this.Text = readerID.Trim() + " GB Tag（Write/Lock/Destroy)";
            this.tb_TID.Text = this.EPCdata[1];
        }

        private void btn_0010_41_Click(object sender, EventArgs e)
        {
            String param = "";
            try 
            {
                param += AntNum + "|";
                param += tb_TID.Text.Trim() + "|";
                param += Int32.Parse(tb_0010_41_00.Text.Trim()) + "|";
                param += tb_0010_41_01.Text.Trim();
                ShowMessage(ClouReaderAPI.CLReader.RFID_OPTION.Write6B(ConnID,param));
            }
            catch { }
        }

        private void btn_0010_42_Click(object sender, EventArgs e)
        {
            String param = "";
            try
            {
                param += AntNum + "|";
                param += tb_TID.Text.Trim() + "|";
                param += Int32.Parse(tb_0010_42_00.Text.Trim());
                ShowMessage(ClouReaderAPI.CLReader.RFID_OPTION.Lock6B(ConnID, param));
            }
            catch { }
        }

        private void btn_0010_43_Click(object sender, EventArgs e)
        {
            String param = "";
            try
            {
                param += AntNum + "|";
                param += tb_TID.Text.Trim() + "|";
                param += Int32.Parse(tb_0010_42_00.Text.Trim());
                ShowMessage(ClouReaderAPI.CLReader.RFID_OPTION.GetLock6B(ConnID, param));
            }
            catch 
            {
                MessageBox.Show("参数错误！");
            }
        }

    }
}
