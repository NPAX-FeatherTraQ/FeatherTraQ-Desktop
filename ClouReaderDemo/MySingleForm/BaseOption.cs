using ClouReaderDemo.Forms;
using ClouReaderDemo.MyFormTemplet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ClouReaderDemo.MySingleForm
{
    public partial class BaseOption : _360Form
    {
        protected String ConnID = "";

        #region 读写器能力

        protected int minDB = 0;                                            // 最小功率
        protected int maxDB = 36;                                           // 最大功率
        protected int antCount = 2;                                         // 天线数目
        protected List<Int32> bandList = new List<Int32>();                 // 频段列表
        protected List<Int32> RFIDProtocolList = new List<Int32>();         // RFID协议列表

        #endregion

        public BaseOption()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// 读取读写器属性
        /// </summary>
        protected void InitReaderProerty()
        {
            string strReaderProperty = ClouReaderAPI.CLReader.RFID_OPTION.GetReaderProperty(ConnID);
            string[] str_array = strReaderProperty.Split('|');
            if (str_array.Length == 5)
            {
                try
                {
                    minDB = Int32.Parse(str_array[0]);
                    maxDB = Int32.Parse(str_array[1]);
                    antCount = Int32.Parse(str_array[2]);
                    string[] str_bandList = str_array[3].Split(',');
                    string[] str_RFIDProtocolList = str_array[4].Split(',');
                    for (int i = 0; i < str_bandList.Length; i++)
                    {
                        bandList.Add(Int32.Parse(str_bandList[i]));
                    }
                    for (int i = 0; i < str_RFIDProtocolList.Length; i++)
                    {
                        RFIDProtocolList.Add(Int32.Parse(str_RFIDProtocolList[i]));
                    }
                }
                catch { }
            }
        }

        private void BaseOption_Load(object sender, EventArgs e)
        {
            this.ShowIcon = false;
            base.IsResize = false;
            this.SysButton = ESysButton.Normal;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Width = 800; this.Height = 460;
            // this.TopMost = true;
        }

        private void BaseOption_Shown(object sender, EventArgs e)
        {
            
        }
    }
}
