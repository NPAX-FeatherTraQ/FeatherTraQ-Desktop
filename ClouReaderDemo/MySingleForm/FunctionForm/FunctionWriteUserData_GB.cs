using ClouReaderAPI.ClouInterface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ClouReaderDemo.MySingleForm.TestForm.FunctionForm
{
    public partial class FunctionWriteUserData_GB : BaseOption
    {
        IAsynchronousMessage contextForm = null;
        Int32 AntNum = 0;                          // 所选的天线编号

        String[] EPCdata = new String[] { "", "", "" };  // EPC,TID,UserData   ,当前选择的标签数据

        byte writeType = 0x30;                           // 
        Dictionary<Int32, byte> dic_WriteType = new Dictionary<int, byte>() 
        {
            {0,0x30},
            {1,0x31},
            {2,0x32},
            {3,0x33},
            {4,0x34},
            {5,0x35},
            {6,0x36},
            {7,0x37},
            {8,0x38},
            {9,0x39},
            {10,0x3A},
            {11,0x3B},
            {12,0x3C},
            {13,0x3D},
            {14,0x3E},
            {15,0x3F}
        };

        public FunctionWriteUserData_GB()
        {
            InitializeComponent();
        }

        public FunctionWriteUserData_GB(string readerID, String[] epcData, Int32 antNum, IAsynchronousMessage contextForm)
            : this()
        {
            this.ConnID = readerID;
            this.EPCdata = epcData;
            this.contextForm = contextForm;
            this.AntNum = antNum;
            Init();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public void Init()
        {
            this.tb_SelectEPC.Text = EPCdata[0];
            this.tb_SelectTID.Text = EPCdata[1];
            this.cb_WriteUser_DataType.SelectedIndex = 0;
        }

        private void FunctionWriteUserData_Load(object sender, EventArgs e)
        {
            this.Width = 500;
            this.Height = 300;
        }

        private void tb_WriteEPCData_KeyUp(object sender, KeyEventArgs e)
        {
            if (!e.Handled)
            {
                tb_WriteEPCLength.Text = (tb_WriteUserData.Text.Length % 4 == 0 ? tb_WriteUserData.Text.Length / 4 : tb_WriteUserData.Text.Length / 4 + 1).ToString();
            }
        }

        #region 通用方法
        /// <summary>
        /// 写用户数据
        /// </summary>
        private void WriteUserData()
        {
            String param = "";
            param += AntNum.ToString() + "|";
            param += writeType + "|";
            param += "0004|";
            Int32 iLen = Int32.Parse(tb_WriteEPCLength.Text.Trim());
            string s_UserData = tb_WriteUserData.Text.Replace(" ","").PadRight(iLen * 4, '0');  // 
            param += s_UserData + "|";
            // 必选参数结束
            if (!String.IsNullOrEmpty(tb_SelectTID.Text))               // 匹配TID
            {
                String kx_param_1 = "";
                kx_param_1 += "00";
                kx_param_1 += "0000";
                kx_param_1 += ClouReaderAPI.MyHelper.MyString.ByteToString((Byte)(tb_SelectTID.Text.Trim().Length * 4));
                kx_param_1 += tb_SelectTID.Text.Trim();
                param += "1," + kx_param_1 + "&";
            }
            else                                                        // 匹配EPC
            {
                String kx_param_1 = "";
                kx_param_1 += "10";
                kx_param_1 += "0010";
                kx_param_1 += ClouReaderAPI.MyHelper.MyString.ByteToString((Byte)(tb_SelectEPC.Text.Trim().Length * 4));
                kx_param_1 += tb_SelectEPC.Text.Trim();
                param += "1," + kx_param_1 + "&";
            }
            if (!String.IsNullOrEmpty(tb_AccessPwd.Text.Trim()))        // 访问密码
            {
                param += "2," + tb_AccessPwd.Text.Trim() + "&";
            }
            param = param.TrimEnd('&');

            // 可选参数结束
            param = param.TrimEnd('|');

            String rt = ClouReaderAPI.CLReader.RFID_OPTION.WriteEPC(ConnID, param);
            if (!rt.StartsWith("0"))
            {
                ShowMessage("UserData Write Failed：" + rt);
            }
            else
            {
                ShowMessage("Write OK！");
            }
        }

        #endregion

        private void btn_Write_Click(object sender, EventArgs e)
        {
            WriteUserData();
        }
        //  改变写用户子区下标
        private void cb_WriteUser_DataType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                writeType = dic_WriteType[cb_WriteUser_DataType.SelectedIndex];
            }
            catch { }
        }
    }
}
