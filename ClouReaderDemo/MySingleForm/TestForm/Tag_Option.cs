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
    public partial class Tag_Option : BaseOption
    {
        IAsynchronousMessage contextForm = null;
        Int32 AntNum = 0;                          // 所选的天线编号

        String[] EPCdata = new String[] { "", "", "" };  // EPC, TID, UserData,当前选择的标签数据

        public Tag_Option()
        {
            InitializeComponent();
            Init();
        }

        public Tag_Option(string readerID, String[] epcData, Int32 antNum, IAsynchronousMessage contextForm)
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
        }

        private void cb_0010_11_MatchType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_0010_11_MatchType.SelectedIndex == 1)
            {
                tb_0010_11_MatchStart.Text = "0020";
            }
            else 
            {
                tb_0010_11_MatchStart.Text = "0000";
            }

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
            SynchroEPCdata();
            String param = "";
            String errMsg = "";
            if (!CheckWriteData(out errMsg)) {
                MessageBox.Show("写入数据不合法：" + errMsg);
                return;
            }
            
            param += AntNum.ToString() + "|";
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
            SynchroEPCdata();
            String param = "";
            
            param += AntNum.ToString() + "|";
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
            SynchroEPCdata();
            String param = "";
            
            param += AntNum.ToString() + "|";
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
        private bool CheckWriteData(out string errMsg) {
            bool rt = true;
            errMsg = "";
            if (cb_0010_11_DataType.SelectedIndex == 0)         // 检查写保留区内容是否合法
            {         
                if (tb_0010_11_WriteData.Text.Length != 8) 
                {
                    errMsg = "密码长度必须为8位！";
                    rt = false;
                }
            }
            return rt;
        }

        #endregion


    }
}
