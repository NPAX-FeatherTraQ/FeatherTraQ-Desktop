using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ClouReaderDemo.MySingleForm.TestForm
{
    /// <summary>
    /// 功率较准
    /// </summary>
    public partial class PowerCalibration : BaseOption
    {
        /// <summary>
        /// 上下文窗体
        /// </summary>
        ClouReaderAPI.ClouInterface.IAsynchronousMessage contextForm = null;
        /// <summary>
        /// 
        /// </summary>
        Dictionary<Int32, List<String>> DIC_RF = new Dictionary<int, List<String>>()
        {
            // {0, new List<String>(){"920.625","920.875","921.125","921.375","921.625","921.875","922.125","922.375","922.625","922.875","923.125","923.375","923.625","923.875","924.125","924.375"}},
            // {1, new List<String>(){"840.625","840.875","841.125","841.375","841.625","841.875","842.125","842.375","842.625","842.875","843.125","843.375","843.625","843.875","844.125","844.375"}},   
            // {2, new List<String>(){"840.625","840.875","841.125","841.375","841.625","841.875","842.125","842.375","842.625","842.875","843.125","843.375","843.625","843.875","844.125","844.375","920.625","920.875","921.125","921.375","921.625","921.875","922.125","922.375","922.625","922.875","923.125","923.375","923.625","923.875","924.125","924.375"}},
            // {3, new List<String>(){"902.75","903.25","903.75","904.25","904.75","905.25","905.75","906.25","906.75","907.25","907.75","908.25","908.75","909.25","909.75","910.25","910.75","911.25","911.75","912.25","912.75","913.25","913.75","914.25","914.75","915.25","915.75","916.25","916.75","917.25","917.75","918.25","918.75","919.25","919.75","920.25","920.75","921.25","921.75","922.25","922.75","923.25","923.75","924.25","924.75","925.25","925.75","926.25","926.75","927.25"}},
            // {4, new List<String>(){"866.3","866.9","867.5","868.1"}},
            // {5, new List<String>(){"916.8","918.0","919.2","920.4"}}
        };
        /// <summary>
        /// 子频段列表
        /// </summary>
        Dictionary<Int32, List<String>> DIC_RF_Child = new Dictionary<int, List<String>>()
        {
            {0,new List<String>(){"920.625-922.375","922.625-924.375"}},
            {1,new List<String>(){"840.625-844.375"}},
            {2,new List<String>(){"840.625-924.375"}},
            {3,new List<String>(){"902.750-918.250","918.750-923.750","924.250-927.250","902.750-915.250-C8","915.750-919.250-C8","919.750-921.250-C8","922.750-927.250-C8"}},
            {4,new List<String>(){"866.300-868.000"}},
            {5,new List<String>(){"916.800-920.400"}},
            {6,new List<String>(){"922.250-925.000"}}
        };              // 取中心频段较准


        public PowerCalibration()
        {
            InitializeComponent();
        }

        public PowerCalibration(string readerID, ClouReaderAPI.ClouInterface.IAsynchronousMessage contextForm)
            : this()
        {
            this.ConnID = readerID;
            this.contextForm = contextForm;
        }
        // 窗体加载
        private void PowerCalibration_Load(object sender, EventArgs e)
        {
            InitReaderProerty();        // 获取读写器能力
            InitDIC_RF();               // 
            Init();                     // 初始化
            SearchRF();                 // 查询当前工作频段
            this.Width = 500;
            this.Height = 300;
        }
        // 窗体关闭事件
        private void PowerCalibration_FormClosing(object sender, FormClosingEventArgs e)
        {
            String rt = ClouReaderAPI.CLReader.RFID_OPTION.StopReader(ConnID);
            if(!rt.StartsWith("0"))
            {
                ShowMessage(rt);
            }
        }

        // 选择频段
        private void cmb_0010_03_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string param = cmb_0010_03.SelectedIndex.ToString();
                ClouReaderAPI.CLReader.RFID_OPTION.SetReaderRF(ConnID, param);
                cmb_0101_03_00.Items.Clear();
                cmb_0101_03_00.Items.AddRange(DIC_RF_Child[cmb_0010_03.SelectedIndex].ToArray());
                cmb_0101_03_00.SelectedIndex = 0;
                cmb_0101_03_01.SelectedIndex = 0;
                cmb_0101_03_01_SelectedIndexChanged(null, null);
                // Send_0101_03();
            }catch{};
        }

        // 选择子频段
        private void cmb_0101_03_00_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmb_0101_03_00.Tag = cmb_0101_03_00.SelectedIndex;
            if (cmb_0010_03.SelectedIndex == 3) 
            {
                if (cmb_0101_03_00.SelectedIndex > 3)
                {
                    cmb_0101_03_00.Tag = cmb_0101_03_00.SelectedIndex - 3;
                }
            }
            cmb_0101_03_01_SelectedIndexChanged(null, null);
            cmb_0101_03_01.SelectedIndex = 0;
            dud_0101_03_02.Text = "0";
        }

        // 保存
        private void btn_0101_03_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(ConnID))
            {
                string param = cmb_0101_03_00.Tag.ToString() + "|" + cmb_0101_03_01.SelectedIndex.ToString() + "|" + dud_0101_03_02.Text.ToString() + "|1";

                string rt = ClouReaderAPI.CLReader.RFID_OPTION.Set_0101_03(ConnID, param);
                ShowMessage(rt);

            }
        }
        // 下一功率
        private void btn_0101_04_NextPower_Click(object sender, EventArgs e)
        {
            try
            {
                Int32 nowDB = cmb_0101_03_01.SelectedIndex;
                if (nowDB + 1 <= maxDB)
                {
                    cmb_0101_03_01.SelectedIndex = nowDB + 1;
                    Send_0101_03();                             // 发射载波
                }
            }
            catch { }
        }
        // 改变功率
        private void cmb_0101_03_01_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClouReaderAPI.CLReader.RFID_OPTION.SetANTPowerParam(ConnID, cmb_0010_03.Tag + "," + cmb_0101_03_01.SelectedIndex);
            // 发射载波
            Send_0101_03();

            if (!String.IsNullOrEmpty(ConnID))
            {
                string param = cmb_0101_03_00.Tag.ToString() + "|" + cmb_0101_03_01.SelectedIndex.ToString();
                string rt = ClouReaderAPI.CLReader.RFID_OPTION.Get_0101_04(ConnID, param);
                string[] array_rt = rt.Split('|');
                if (array_rt.Length >= 3)
                {
                    this.dud_0101_03_02.SelectedIndex = dud_0101_03_02.Items.Count - Int32.Parse(array_rt[2].Trim()) - 1; // 从零开始，所以减1;
                }
            }
        }
        
        #region 杂项事件

        private void dud_0101_03_02_MouseUp(object sender, MouseEventArgs e)
        {
            string param = cmb_0101_03_00.Tag.ToString() + "|" + cmb_0101_03_01.SelectedIndex.ToString() + "|" + dud_0101_03_02.Text.ToString() + "|0";
            string rt = ClouReaderAPI.CLReader.RFID_OPTION.Set_0101_03(ConnID, param);
        }

        private void dud_0101_03_02_SelectedItemChanged(object sender, EventArgs e)
        {
            try
            {
                tBar_0101_03_03.Value = Int32.Parse(dud_0101_03_02.Text.Trim());
            }
            catch { }
        }

        private void dud_0101_03_02_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                string param = cmb_0101_03_00.Tag.ToString() + "|" + cmb_0101_03_01.SelectedIndex.ToString() + "|" + dud_0101_03_02.Text.ToString() + "|0";
                string rt = ClouReaderAPI.CLReader.RFID_OPTION.Set_0101_03(ConnID, param);
            }
        }

        private void tBar_0101_03_03_Scroll(object sender, EventArgs e)
        {
            dud_0101_03_02.Text = tBar_0101_03_03.Value.ToString();
        }

        private void tBar_0101_03_03_MouseUp(object sender, MouseEventArgs e)
        {
            string param = cmb_0101_03_00.Tag.ToString() + "|" + cmb_0101_03_01.SelectedIndex.ToString() + "|" + dud_0101_03_02.Text.ToString() + "|0";
            string rt = ClouReaderAPI.CLReader.RFID_OPTION.Set_0101_03(ConnID, param);
        }

        private void rb_0101_00_00_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb != null)
            {
                cmb_0010_03.Tag = rb.Tag;
                Send_0101_03();
            }
        }

        #endregion

        #region 通用辅助方法
        /// <summary>
        /// 初始化
        /// </summary>
        private void Init() 
        {
            cmb_0101_03_01.Items.Clear();
            // 功率
            for (int i = 0; i <= maxDB; i++)
            {
                cmb_0101_03_01.Items.Add(i.ToString());
            }
            // 初始化天线
            foreach (var item in gb_Main.Controls)
            {
                RadioButton rb = item as RadioButton;
                if (rb != null)
                {
                    int index = Int32.Parse(rb.Name.Substring(rb.Name.Length - 1, 1));
                    if (index >= antCount)
                    {
                        rb.Enabled = false;
                    }
                }
            }
            // 较准参数
            for (int i = 255; i >= 0; i--)
            {
                dud_0101_03_02.Items.Add(i.ToString());
            }
        }
        /// <summary>
        /// 查询工作频段
        /// </summary>
        public void SearchRF() 
        {
            if (!String.IsNullOrEmpty(ConnID))
            {
                string rt = ClouReaderAPI.CLReader.RFID_OPTION.GetRederRF(ConnID);
                Int32 index = -1;
                if (Int32.TryParse(rt, out index))
                {
                    this.cmb_0010_03.SelectedIndex = Int32.Parse(rt);
                }
            }
        }
        /// <summary>
        /// 发射载波
        /// </summary>
        public void Send_0101_03(Int32 pointIndex) 
        {
            if (!String.IsNullOrEmpty(ConnID))
            {
                try
                {
                    Dictionary<String, String> DIC_temp = new Dictionary<string, string>() 
                    {
                        {"1","1"},
                        {"2","2"},
                        {"3","4"},
                        {"4","8"},
                        {"5","16"},
                        {"6","32"},
                        {"7","64"},
                        {"8","128"}
                    };
                    string param = "";
                    param = DIC_temp[cmb_0010_03.Tag.ToString()] + "|" + pointIndex;   // 取中间频点发射载波
                    String strTemp = ClouReaderAPI.CLReader.RFID_OPTION.SendCarrier(ConnID, param);
                    // MessageBox.Show("发送参数："+ param);
                    if (!strTemp.StartsWith("0"))
                    {
                        ShowMessage("Failed to launch carrier！");
                    }
                }
                catch { }
            }
        }
        /// <summary>
        /// 发射载波
        /// </summary>
        public void Send_0101_03() 
        {
            Int32 pointIndex = GetCenterPoint(cmb_0010_03.SelectedIndex, cmb_0101_03_00.Text);
            Send_0101_03(pointIndex);
        }

        /// <summary>
        /// 获得子频段的中间频点，920.25-927.25
        /// </summary>
        public Int32 GetCenterPoint(Int32 index, String strParam)
        {
            Int32 rt = -1;
            String[] startAndEnd = strParam.Split('-');
            if (startAndEnd.Length >= 2)
            {
                Int32 startIndex = SearchIndexForDIC(index, startAndEnd[0]);            // 起点下标
                Int32 endIndex = SearchIndexForDIC(index, startAndEnd[1]);              // 结束下标
                Int32 centerIndex = (endIndex - startIndex) / 2 + startIndex;           // 取得中心结点下标
                rt = centerIndex;
            }
            return rt;
        }

        /// <summary>
        /// 根据值找下标
        /// </summary>
        public Int32 SearchIndexForDIC(Int32 index, String val)
        {
            Int32 rt = -1;
            for (int i = 0; i < DIC_RF[index].Count; i++)
            {
                if (DIC_RF[index][i].Equals(val))
                {
                    rt = i;
                    break;
                }
            }
            return rt;
        }

        private void InitDIC_RF()
        {
            DIC_RFAddItem(0, 920.625f, 924.375f, 0.25f);
            DIC_RFAddItem(1, 840.625f, 844.375f, 0.25f);
            DIC_RFAddItem(2, 840.625f, 844.375f, 0.25f);
            DIC_RFAddItem(2, 920.625f, 924.375f, 0.25f);
            DIC_RFAddItem(3, 902.75f, 927.25f, 0.5f);
            DIC_RFAddItem(4, 865.7f, 868.0f, 0.6f);
            DIC_RFAddItem(5, 916.8f, 920.4f, 1.2f);
            DIC_RFAddItem(6, 922.25f, 927.75f, 0.25f);
        }

        private void DIC_RFAddItem(Int32 index, float fStart, float fEnd, float jump)
        {
            List<String> listItem = new List<String>();
            while (fStart <= fEnd)
            {
                listItem.Add(fStart.ToString("F3"));
                fStart += jump;
            }
            if (!DIC_RF.ContainsKey(index))
            {
                DIC_RF.Add(index, listItem);
            }
            else
            {
                foreach (String item in listItem)
                {
                    DIC_RF[index].Add(item);
                }
            }
        }

        #endregion

    }
}
