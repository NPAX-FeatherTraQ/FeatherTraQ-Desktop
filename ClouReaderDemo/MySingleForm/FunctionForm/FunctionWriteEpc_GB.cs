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
    public partial class FunctionWriteEpc_GB : BaseOption
    {
        IAsynchronousMessage contextForm = null;
        Int32 AntNum = 0;                          // 所选的天线编号

        String[] EPCdata = new String[] { "", "", "" };  // EPC,TID,UserData   ,当前选择的标签数据

        public FunctionWriteEpc_GB()
        {
            InitializeComponent();
        }
        public FunctionWriteEpc_GB(string readerID, String[] epcData, Int32 antNum, IAsynchronousMessage contextForm)
            : this()
        {
            this.ConnID = readerID;
            this.EPCdata = epcData;
            this.contextForm = contextForm;
            this.AntNum = antNum;
        }

        private void FunctionWriteEpc_Load(object sender, EventArgs e)
        {
            this.Width = 500;
            this.Height = 300;
            Init();
        }
        /// <summary>
        /// 初始化
        /// </summary>
        public void Init() 
        {
            this.tb_SelectEPC.Text = EPCdata[0];
            this.tb_SelectTID.Text = EPCdata[1];
        }
        // 获取写入EPC的长度
        private void tb_WriteEPCData_KeyUp(object sender, KeyEventArgs e)
        {
            if (!e.Handled)
            {
                tb_WriteEPCLength.Text = (tb_WriteEPCData.Text.Length % 4 == 0 ? tb_WriteEPCData.Text.Length / 4 : tb_WriteEPCData.Text.Length / 4 + 1).ToString();
            }
        }
        // 限制输入
        private void tb_WriteEPCData_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        #region 通用方法
        /// <summary>
        /// 写EPC
        /// </summary>
        private void WriteEPC() 
        {
            String param = "";
            param += AntNum.ToString() + "|";
            param += "16|";
            param += "0000|";
            Int32 iLen = Int32.Parse(tb_WriteEPCLength.Text.Trim());
            Int16 i_PC = (Int16)(iLen << 8);
            string s_PC = Convert.ToString(i_PC, 16).PadLeft(4, '0');
            string s_EPC = (s_PC + tb_WriteEPCData.Text.Replace(" ","")).PadRight((iLen + 1) * 4, '0');  // 加上PC的长度
            param += s_EPC + "|";
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

            String rt = ClouReaderAPI.CLReader.RFID_OPTION.WriteGB(ConnID, param);
            if (!rt.StartsWith("0"))
            {
                ShowMessage("EPC Write Failed：" + rt);
            }
            else 
            {
                ShowMessage("Write OK！");
            }
        }

        #endregion

        private void btn_Write_Click(object sender, EventArgs e)
        {
            WriteEPC();
        }

    }
}
