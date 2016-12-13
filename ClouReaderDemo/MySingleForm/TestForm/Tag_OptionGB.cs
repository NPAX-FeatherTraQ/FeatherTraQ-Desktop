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
    public partial class Tag_OptionGB : BaseOption
    {
        IAsynchronousMessage contextForm = null;
        Int32 AntNum = 0;                          // 所选的天线编号

        String[] EPCdata = new String[] { "", "", "" };  // EPC, TID, UserData,当前选择的标签数据

        public Dictionary<Int32, byte> dic_DataType = new Dictionary<Int32, byte>()         // 写数据类型
        {
            {0,0x00},
            {1,0x10},
            {2,0x20},
            {3,0x30},
            {4,0x31},
            {5,0x32},
            {6,0x33},
            {7,0x34},
            {8,0x35},
            {9,0x36},
            {10,0x37},
            {11,0x38},
            {12,0x39},
            {13,0x3A},
            {14,0x3B},
            {15,0x3C},
            {16,0x3D},
            {17,0x3E},
            {18,0x3F}
        };

        public Dictionary<Int32, byte> dic_LockType = new Dictionary<Int32, byte>()         // 锁类型
        {
            {0,0x00},
            {1,0x01},
            {2,0x02},
            {3,0x03},
            {4,0x11},
            {5,0x12},
            {6,0x13}
        };

        public Tag_OptionGB()
        {
            InitializeComponent();
        }

        public Tag_OptionGB(string readerID, String[] epcData, Int32 antNum, IAsynchronousMessage contextForm)
            : this()
        {
            this.ConnID = readerID;
            this.EPCdata = epcData;
            this.contextForm = contextForm;
            this.AntNum = antNum;
            this.Text = readerID.Trim() + " GB Tag（Write/Lock/Destroy)";
            this.tb_EPC.Text = this.EPCdata[0];
            this.tb_TID.Text = this.EPCdata[1];
            this.tb_UserData.Text = this.EPCdata[2];
            Init();
        }

        public void Init() 
        {

        }
        //  写标签
        private void btn_0010_51_Click(object sender, EventArgs e)
        {
            SynchroEPCdata();
            String param = "";
            String errMsg = "";
            if (!CheckWriteData(out errMsg))
            {
                MessageBox.Show("写入数据不合法：" + errMsg);
                return;
            }

            param += AntNum.ToString() + "|";
            param += dic_DataType[cb_0010_51_DataType.SelectedIndex] + "|";
            param += Int16.Parse(tb_0010_51_WriteDataStart.Text) + "|";
            // param += tb_0010_51_WriteData.Text.Trim() + "|";
            string param_4 = tb_0010_51_WriteData.Text.Trim();
            if (param_4.Length % 2 != 0) { param_4 += "0"; }
            param += param_4 + "|";

            if (cb_0010_51_MatchType.SelectedIndex != 0 && cb_0010_51_MatchType.SelectedIndex != -1)    // 可选参数1，选择写入参数
            {
                String kx_param_1 = "";
                kx_param_1 += dic_DataType[cb_0010_51_MatchType.SelectedIndex - 1].ToString("x");
                kx_param_1 += tb_0010_51_MatchStart.Text.Trim();
                if (cb_0010_51_MatchType.SelectedIndex == 1) 
                {
                    kx_param_1 += ClouReaderAPI.MyHelper.MyString.ByteToString((Byte)(EPCdata[1].Length * 4));
                    kx_param_1 += EPCdata[1];
                }
                else if (cb_0010_51_MatchType.SelectedIndex == 2)
                {
                    kx_param_1 += ClouReaderAPI.MyHelper.MyString.ByteToString((Byte)(EPCdata[0].Length * 4));
                    kx_param_1 += EPCdata[0];
                }
                else if (cb_0010_51_MatchType.SelectedIndex == 3)
                {
                    kx_param_1 += ClouReaderAPI.MyHelper.MyString.ByteToString((Byte)(EPCdata[2].Length * 4));
                    kx_param_1 += EPCdata[2];
                }
                else 
                {
                    kx_param_1 += ClouReaderAPI.MyHelper.MyString.ByteToString((Byte)(EPCdata[2].Length * 4));
                    kx_param_1 += EPCdata[2];
                }
                param += "1," + kx_param_1 + "&";
            }

            if (!String.IsNullOrEmpty(tb_0010_51_WritePassword.Text.Trim()))
            {
                param += "2," + tb_0010_51_WritePassword.Text.Trim() + "&";
            }
            param = param.TrimEnd('&');

            // 可选参数结束
            param = param.TrimEnd('|');

            ShowMessage(ClouReaderAPI.CLReader.RFID_OPTION.WriteGB(ConnID, param));
        }

        // 锁标签
        private void btn_0010_52_Click(object sender, EventArgs e)
        {
            SynchroEPCdata();
            String param = "";

            param += AntNum.ToString() + "|";
            param += dic_DataType[cb_0010_52_LockArea.SelectedIndex] + "|";
            param += dic_LockType[cb_0010_52_LockType.SelectedIndex] + "|";

            if (cb_0010_51_MatchType.SelectedIndex != 0 && cb_0010_51_MatchType.SelectedIndex != -1)    // 可选参数1，选择写入参数
            {
                String kx_param_1 = "";
                kx_param_1 += dic_DataType[cb_0010_51_MatchType.SelectedIndex - 1].ToString("x");
                kx_param_1 += tb_0010_51_MatchStart.Text.Trim();
                if (cb_0010_51_MatchType.SelectedIndex == 1)
                {
                    kx_param_1 += ClouReaderAPI.MyHelper.MyString.ByteToString((Byte)(EPCdata[1].Length * 4));
                    kx_param_1 += EPCdata[1];
                }
                else if (cb_0010_51_MatchType.SelectedIndex == 2)
                {
                    kx_param_1 += ClouReaderAPI.MyHelper.MyString.ByteToString((Byte)(EPCdata[0].Length * 4));
                    kx_param_1 += EPCdata[0];
                }
                else if (cb_0010_51_MatchType.SelectedIndex == 3)
                {
                    kx_param_1 += ClouReaderAPI.MyHelper.MyString.ByteToString((Byte)(EPCdata[2].Length * 4));
                    kx_param_1 += EPCdata[2];
                }
                else
                {
                    kx_param_1 += ClouReaderAPI.MyHelper.MyString.ByteToString((Byte)(EPCdata[2].Length * 4));
                    kx_param_1 += EPCdata[2];
                }
                param += "1," + kx_param_1 + "&";
            }

            if (!String.IsNullOrEmpty(tb_0010_52_LockPassword.Text.Trim()))
            {
                param += "2," + tb_0010_52_LockPassword.Text.Trim() + "&";
            }
            param = param.TrimEnd('&');

            // 可选参数结束
            param = param.TrimEnd('|');

            ShowMessage(ClouReaderAPI.CLReader.RFID_OPTION.LockGB(ConnID, param));
        }

        // 销毁标签
        private void btn_0010_53_Click(object sender, EventArgs e)
        {
            SynchroEPCdata();
            String param = "";

            param += AntNum.ToString() + "|";
            param += tb_0010_53_DestroyPwd.Text.ToString() + "|";

            if (cb_0010_51_MatchType.SelectedIndex != 0 && cb_0010_51_MatchType.SelectedIndex != -1)    // 可选参数1，选择写入参数
            {
                String kx_param_1 = "";
                kx_param_1 += dic_DataType[cb_0010_51_MatchType.SelectedIndex - 1].ToString("x");
                kx_param_1 += tb_0010_51_MatchStart.Text.Trim();
                kx_param_1 += ClouReaderAPI.MyHelper.MyString.ByteToString((Byte)(EPCdata[cb_0010_51_MatchType.SelectedIndex - 1].Length * 4));
                if (cb_0010_51_MatchType.SelectedIndex == 1)
                {
                    kx_param_1 += ClouReaderAPI.MyHelper.MyString.ByteToString((Byte)(EPCdata[1].Length * 4));
                    kx_param_1 += EPCdata[1];
                }
                else if (cb_0010_51_MatchType.SelectedIndex == 2)
                {
                    kx_param_1 += ClouReaderAPI.MyHelper.MyString.ByteToString((Byte)(EPCdata[0].Length * 4));
                    kx_param_1 += EPCdata[0];
                }
                else if (cb_0010_51_MatchType.SelectedIndex == 3)
                {
                    kx_param_1 += ClouReaderAPI.MyHelper.MyString.ByteToString((Byte)(EPCdata[2].Length * 4));
                    kx_param_1 += EPCdata[2];
                }
                else
                {
                    kx_param_1 += ClouReaderAPI.MyHelper.MyString.ByteToString((Byte)(EPCdata[2].Length * 4));
                    kx_param_1 += EPCdata[2];
                }
                param += "1," + kx_param_1 + "&";
            }
            param = param.TrimEnd('&');

            // 可选参数结束
            param = param.TrimEnd('|');

            ShowMessage(ClouReaderAPI.CLReader.RFID_OPTION.DestroyGB(ConnID, param));


        }


        #region 写入事件

        private void cb_0010_51_DataType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_0010_51_DataType.SelectedIndex == 1)     // 写EPC区时的判断
            {
                cb_0010_11_DataType_EPC_Item.Visible = true;
                cb_0010_51_DataType_Pwd_Item.Visible = false;
            }
            else if(cb_0010_51_DataType.SelectedIndex == 2)
            {
                cb_0010_11_DataType_EPC_Item.Visible = false;
                cb_0010_51_DataType_Pwd_Item.Visible = true;
            }
            else
            {
                cb_0010_51_DataType_Pwd_Item.Visible = false;
                cb_0010_11_DataType_EPC_Item.Visible = false;
            }
            if (cb_0010_51_DataType.SelectedIndex >= 3) 
            {
                tb_0010_51_WriteDataStart.Text = "0004";
            }
        }


        private void cb_0010_11_DataType_EPC_Item_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_0010_11_DataType_EPC_Item.SelectedIndex == 0) 
            {
                tb_0010_51_WriteDataStart.Text = "0000";
            }
            else if (cb_0010_11_DataType_EPC_Item.SelectedIndex == 1)
            {
                tb_0010_51_WriteDataStart.Text = "0001";
            }
        }


        #endregion
        


        #region 通用辅助方法
        /// <summary>
        /// 操作标签之前同步标签数据
        /// </summary>
        private void SynchroEPCdata()
        {
            try
            {
                EPCdata[0] = tb_EPC.Text.Trim();
                EPCdata[1] = tb_TID.Text.Trim();
                EPCdata[2] = tb_UserData.Text.Trim();
            }
            catch { }
        }

        /// <summary>
        /// 检查写入数据是否合法
        /// </summary>
        /// <returns>true合法，false不合法</returns>
        private bool CheckWriteData(out string errMsg)
        {
            bool rt = true;
            errMsg = "";
            if (!String.IsNullOrEmpty(tb_0010_51_WritePassword.Text) && tb_0010_51_WritePassword.Text.Length != 8)
            {
                errMsg = "密码长度必须为8位！";
                rt = false;
            }
            return rt;
        }

        #endregion

        
    }
}
