using ClouReaderAPI.ClouInterface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ClouReaderDemo.MyForm
{
    public partial class Tag_Option : BaseOption
    {
        IAsynchronousMessage contextForm = null;

        String[] EPCdata = new String[] {"","","" };  // EPC,TID,UserData   ,当前选择的标签数据

        #region 读写器能力

        private int minDB = 0;                                            // 最小功率
        private int maxDB = 36;                                           // 最大功率
        private int antCount = 2;                                         // 天线数目
        private List<Int32> bandList = new List<Int32>();                 // 频段列表
        private List<Int32> RFIDProtocolList = new List<Int32>();         // RFID协议列表

        #endregion

        public Tag_Option()
        {
            InitializeComponent();
            Init();
        }

        public Tag_Option(string readerID, String[] epcData, IAsynchronousMessage contextForm)
            : this()
        {
            this.ConnID = readerID;
            this.EPCdata = epcData;
            this.contextForm = contextForm;
            this.Text = readerID.Trim() + "---当前选择标签EPC：" + EPCdata[0] + "    TID：" + EPCdata[1];
            Init();
        }

        public void Init() 
        {
            InitReaderProerty();
            InitWrite();
            InitLock();
        }



        #region 标签写操作集合

        public void InitWrite() 
        {
            cb_0010_11_DataType_EPC_Item.Visible = true;
            cb_0010_11_DataType_EPC_Item.SelectedIndex = 0;
            cb_0010_11_DataType_Pwd_Item.Visible = false;
            cb_0010_11_DataType_Pwd_Item.SelectedIndex = 0;
            cb_0010_11_DataType.SelectedIndex = 1;
            cb_0010_11_MatchType.SelectedIndex = 0;
            cb_0010_11_BlockWrite.Checked = true;
            cb_0010_11_BlockWrite.Checked = false;

            foreach (var item in gb_TagMatch.Controls)
            {
                CheckBox cb = item as CheckBox;
                if (cb != null)
                {
                    int index = Int32.Parse(cb.Name.Substring(cb.Name.Length - 1, 1));
                    if (index >= antCount)
                    {
                        cb.Enabled = false;
                    }
                }
            }
        }

        private void cb_0010_11_MatchType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_0010_11_MatchType.SelectedIndex == 0)
            {
                lb_0010_11_MatchStart.Visible = false;
                tb_0010_11_MatchStart.Visible = false;
            }
            else 
            {
                lb_0010_11_MatchStart.Visible = true;
                tb_0010_11_MatchStart.Visible = true;
            }
        }


        private void cb_0010_11_BlockWrite_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_0010_11_BlockWrite.Checked)
            {
                lb_0010_11_BlockLen.Visible = true;
                tb_0010_11_BlockLen.Visible = true;
            }
            else 
            {
                lb_0010_11_BlockLen.Visible = false;
                tb_0010_11_BlockLen.Visible = false;
            }
        }

        private void btn_0010_11_Click(object sender, EventArgs e)
        {
            String param = "";
            Int32 param_1 = 0;
            foreach (var item in gb_TagMatch.Controls)
            {
                CheckBox cb = item as CheckBox;
                if (cb != null && cb.Checked)
                {
                    int index = Int32.Parse(cb.Tag.ToString());
                    param_1 += index;
                }
            }
            param += param_1.ToString()+"|";
            param += cb_0010_11_DataType.SelectedIndex.ToString() + "|";
            param += tb_0010_11_WriteDataStart.Text.Trim()+"|";
            string param_4 = tb_0010_11_WriteData.Text.Trim();
            if (param_4.Length % 2 != 0) { param_4 += "0"; }
            param += param_4 + "|";
            // 必选参数结束

            if (cb_0010_11_MatchType.SelectedIndex != 0) 
            {
                String kx_param_1 = "";
                kx_param_1 += cb_0010_11_MatchType.SelectedIndex.ToString().PadLeft(2,'0');
                kx_param_1 += tb_0010_11_MatchStart.Text.Trim();
                kx_param_1 += ClouReaderAPI.MyHelper.MyString.ByteToString((Byte)(EPCdata[cb_0010_11_MatchType.SelectedIndex - 1].Length * 4));
                kx_param_1 += EPCdata[cb_0010_11_MatchType.SelectedIndex - 1].Equals("NULL") ? "" : EPCdata[cb_0010_11_MatchType.SelectedIndex - 1];
                param += "1," + kx_param_1 + "&";
            }

            if (!String.IsNullOrEmpty(tb_0010_11_AccessPwd.Text.Trim())) 
            {
                param += "2," + tb_0010_11_AccessPwd.Text.Trim() + "&";
            }
            if (cb_0010_11_BlockWrite.Checked) 
            {
                param += "3," +  tb_0010_11_BlockLen.Text.Trim();
            }

            param = param.TrimEnd('&');

            // 可选参数结束
            param = param.TrimEnd('|');

            ShowMessage(ClouReaderAPI.CLReader.RFID_OPTION.WriteEPC(ConnID, param));

        }

        private void cb_0010_11_DataType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_0010_11_DataType.SelectedIndex == 0)
            {
                cb_0010_11_DataType_EPC_Item.Visible = false;
                cb_0010_11_DataType_Pwd_Item.Visible = true;
                cb_0010_11_DataType_Pwd_Item_SelectedIndexChanged(null, null);
            }
            else if (cb_0010_11_DataType.SelectedIndex == 1)
            {
                cb_0010_11_DataType_EPC_Item.Visible = true;
                cb_0010_11_DataType_Pwd_Item.Visible = false;
                cb_0010_11_DataType_EPC_Item_SelectedIndexChanged(null, null);
            }
            else 
            {
                cb_0010_11_DataType_EPC_Item.Visible = false;
                cb_0010_11_DataType_Pwd_Item.Visible = false;
            }
        }

        private void cb_0010_11_DataType_EPC_Item_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_0010_11_DataType_EPC_Item.SelectedIndex == 0) 
            {
                tb_0010_11_WriteDataStart.Text = "0001";
            }
            else if (cb_0010_11_DataType_EPC_Item.SelectedIndex == 1)
            {
                tb_0010_11_WriteDataStart.Text = "0002";
            }
        }

        private void cb_0010_11_DataType_Pwd_Item_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_0010_11_DataType_Pwd_Item.SelectedIndex == 0)
            {
                tb_0010_11_WriteDataStart.Text = "0000";
            }
            else if (cb_0010_11_DataType_Pwd_Item.SelectedIndex == 1)
            {
                tb_0010_11_WriteDataStart.Text = "0002";
            }
        }

        #endregion

        #region 标签锁操作集合

        public void InitLock() 
        {
            cb_0010_12_LockArea.SelectedIndex = 0;
            cb_0010_12_LockType.SelectedIndex = 0;
        }

        private void btn_0010_12_Click(object sender, EventArgs e)
        {
            String param = "";
            Int32 param_1 = 0;
            foreach (var item in gb_TagMatch.Controls)
            {
                CheckBox cb = item as CheckBox;
                if (cb != null && cb.Checked)
                {
                    int index = Int32.Parse(cb.Tag.ToString());
                    param_1 += index;
                }
            }
            param += param_1.ToString() + "|";
            param += cb_0010_12_LockArea.SelectedIndex.ToString() + "|";
            param += cb_0010_12_LockType.SelectedIndex.ToString() + "|";
            

            // 必选参数结束

            if (cb_0010_11_MatchType.SelectedIndex != 0)
            {
                String kx_param_1 = "";
                kx_param_1 += cb_0010_11_MatchType.SelectedIndex.ToString().PadLeft(2, '0');
                kx_param_1 += tb_0010_11_MatchStart.Text.Trim();
                kx_param_1 += ClouReaderAPI.MyHelper.MyString.ByteToString((Byte)(EPCdata[cb_0010_11_MatchType.SelectedIndex - 1].Length * 4));
                kx_param_1 += EPCdata[cb_0010_11_MatchType.SelectedIndex - 1];
                param += "1," + kx_param_1 + "&";
            }

            if (!String.IsNullOrEmpty(tb_0010_11_AccessPwd.Text.Trim()))
            {
                param += "2," + tb_0010_11_AccessPwd.Text.Trim();
            }

            param = param.TrimEnd('&');

            // 可选参数结束
            param = param.TrimEnd('|');

            ShowMessage(ClouReaderAPI.CLReader.RFID_OPTION.LockEPC(ConnID, param));
        }

        #endregion

        #region 销毁标签操作集合

        private void btn_0010_13_Click(object sender, EventArgs e)
        {
            String param = "";
            Int32 param_1 = 0;
            foreach (var item in gb_TagMatch.Controls)
            {
                CheckBox cb = item as CheckBox;
                if (cb != null && cb.Checked)
                {
                    int index = Int32.Parse(cb.Tag.ToString());
                    param_1 += index;
                }
            }
            param += param_1.ToString() + "|";
            param += tb_0010_13_DestroyPwd.Text.ToString() + "|";


            // 必选参数结束

            if (cb_0010_11_MatchType.SelectedIndex != 0)
            {
                String kx_param_1 = "";
                kx_param_1 += cb_0010_11_MatchType.SelectedIndex.ToString().PadLeft(2, '0');
                kx_param_1 += tb_0010_11_MatchStart.Text.Trim();
                kx_param_1 += ClouReaderAPI.MyHelper.MyString.ByteToString((Byte)(EPCdata[cb_0010_11_MatchType.SelectedIndex - 1].Length * 4));
                kx_param_1 += EPCdata[cb_0010_11_MatchType.SelectedIndex - 1];
                param += "1," + kx_param_1 + "&";
            }

            param = param.TrimEnd('&');

            // 可选参数结束
            param = param.TrimEnd('|');

            ShowMessage(ClouReaderAPI.CLReader.RFID_OPTION.DestroyEPC(ConnID, param));
        }

        #endregion

        
    }
}
