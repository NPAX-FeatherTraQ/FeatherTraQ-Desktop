using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;

namespace ClouReaderDemo.MySingleForm.SettingForm
{
    public partial class SettingGPI : BaseOption
    {
        /// <summary>
        /// 上下文窗体
        /// </summary>
        SingleMainForm contextForm = null;
        Dictionary<Int32, String> Dic_CommandToIndex = new Dictionary<Int32, String>();
        // private String SendCommandHex = "";         // 命令内容
        Int32 CommandCount = 9;                     // 自定义命令长度
        public String readVarParam_6C = "";         // 读标签时候的可选参数，可由配置文件保存、读取
        public String readVarParam_6B = "";


        public SettingGPI()
        {
            InitializeComponent();
        }
        public SettingGPI(string readerID, SingleMainForm contextForm)
            : this()
        {
            this.ConnID = readerID;
            this.contextForm = contextForm;
        }

        private void SettingGPI_Load(object sender, EventArgs e)
        {
            this.Width = 500;
            this.Height = 300;
            Init();
            this.cb_0001_0B_00.SelectedIndex = 0;
        }
        // 初始化
        private void Init() 
        {
            try
            {
                Dic_CommandToIndex.Clear();
                for (int i = 0; i < CommandCount; i++)
                {
                    Dic_CommandToIndex.Add(i, Helper.MyXmlHelper.ReadInnerText(XMLFIENAME, "Root/" + this.Name, "Command_" + i));
                }
            }
            catch { }
        }
        // 查询
        private void cb_0001_0B_00_SelectedIndexChanged(object sender, EventArgs e)
        {
            String param = cb_0001_0B_00.SelectedIndex.ToString();
            String rtStr = ClouReaderAPI.CLReader.PARAM_SET.GetReaderGPIParam(ConnID, param);
            String[] arrParam = rtStr.Split('|');
            if (arrParam.Length == 4)
            {
                try
                {
                    cb_0001_0B_01.SelectedIndex = byte.Parse(arrParam[0]);
                    cmb_CommandList.SelectedIndex = GetCommadIndex(arrParam[1]);
                    cb_0001_0B_03.SelectedIndex = byte.Parse(arrParam[2]);
                    tb_0001_0B_04.Text = arrParam[3];
                }
                catch { }
            }
            else
            {
                ShowMessage(rtStr);
            }
        }
        // 编辑命令
        private void btn_EditCommand_Click(object sender, EventArgs e)
        {
            if (cmb_CommandList.SelectedIndex >= 2)
            {
                SettingGPI_ReadParam readParam = new SettingGPI_ReadParam(this, cmb_CommandList.SelectedIndex - 6);
                if (DialogResult.OK == readParam.ShowDialog(this))
                {
                    if (!String.IsNullOrEmpty(readVarParam_6C))
                    {
                        String commandText = ClouReaderAPI.CLReader.RFID_OPTION.GetEPC_Command(ConnID, contextForm.GetReadTagParam(readVarParam_6C));
                        Helper.MyXmlHelper.UpdateInnerText(XMLFIENAME, "Root/" + this.Name, "Command_" + cmb_CommandList.SelectedIndex, commandText);
                    }
                    else if (!String.IsNullOrEmpty(readVarParam_6B))
                    {
                        String commandText = ClouReaderAPI.CLReader.RFID_OPTION.Get6B_Command(ConnID, contextForm.GetReadTagParam(readVarParam_6B));
                        Helper.MyXmlHelper.UpdateInnerText(XMLFIENAME, "Root/" + this.Name, "Command_" + cmb_CommandList.SelectedIndex, commandText);
                    }
                    Init();
                }
            }
            else 
            {
                ShowMessage("只能编辑自定义命令！");
            }
        }
        // 根据命令获得索引
        private Int32 GetCommadIndex(String commandText) 
        {
            Int32 rt = -1;
            foreach (var item in Dic_CommandToIndex)
            {
                if (commandText.Equals(item.Value)) 
                {
                    rt = item.Key;
                    break;
                }
            }
            return rt;
        }
        // 配置
        private void btn_SetGPI_Click(object sender, EventArgs e)
        {
            if (cb_0001_0B_01.SelectedIndex > 0 && cb_0001_0B_01.SelectedIndex == cb_0001_0B_03.SelectedIndex) 
            {
                MessageBox.Show("开始条件，与触发条件不能一样！");
                return;
            }
            String strParam = "";
            try
            {
                strParam += cb_0001_0B_00.SelectedIndex + "|";
                strParam += cb_0001_0B_01.SelectedIndex + "|";
                strParam += Dic_CommandToIndex[cmb_CommandList.SelectedIndex].Trim() + "|";
                strParam += cb_0001_0B_03.SelectedIndex + "|";
                if (cb_0001_0B_03.SelectedIndex == 6)
                {
                    strParam += "1," + tb_0001_0B_04.Text.Trim();
                }
            }
            catch { }
            strParam = strParam.TrimEnd('|');
            ShowMessage(ClouReaderAPI.CLReader.PARAM_SET.SetReaderGPIParam(ConnID, strParam));
        }

        private void btn_Init_Click(object sender, EventArgs e)
        {
            cb_0001_0B_00_SelectedIndexChanged(null, null);
        }

        private void cb_0001_0B_03_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_0001_0B_03.SelectedIndex == 6)
            {
                tb_0001_0B_04.Visible = true;
                lb_DelayTime.Visible = true;
                lb_DelayTime_1.Visible = true;
            }
            else 
            {
                tb_0001_0B_04.Visible = false;
                lb_DelayTime.Visible = false;
                lb_DelayTime_1.Visible = false;
            }
        }
    }
}
