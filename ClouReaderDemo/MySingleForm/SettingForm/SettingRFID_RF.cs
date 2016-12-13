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
    /// 跳频管理
    /// </summary>
    public partial class SettingRFID_RF : BaseOption
    {
        ClouReaderAPI.ClouInterface.IAsynchronousMessage contextForm = null;
        /// <summary>
        /// 所以频点
        /// </summary>
        Dictionary<Int32, List<String>> DIC_RF = new Dictionary<Int32, List<String>>()
        {
            // {0, new List<String>(){"920.625","920.875","921.125","921.375","921.625","921.875","922.125","922.375","922.625","922.875","923.125","923.375","923.625","923.875","924.125","924.375"}},
            // {1, new List<String>(){"840.625","840.875","841.125","841.375","841.625","841.875","842.125","842.375","842.625","842.875","843.125","843.375","843.625","843.875","844.125","844.375"}},   
            // {2, new List<String>(){"840.625","840.875","841.125","841.375","841.625","841.875","842.125","842.375","842.625","842.875","843.125","843.375","843.625","843.875","844.125","844.375","920.625","920.875","921.125","921.375","921.625","921.875","922.125","922.375","922.625","922.875","923.125","923.375","923.625","923.875","924.125","924.375"}},
            // {3, new List<String>(){"902.75","903.25","903.75","904.25","904.75","905.25","905.75","906.25","906.75","907.25","907.75","908.25","908.75","909.25","909.75","910.25","910.75","911.25","911.75","912.25","912.75","913.25","913.75","914.25","914.75","915.25","915.75","916.25","916.75","917.25","917.75","918.25","918.75","919.25","919.75","920.25","920.75","921.25","921.75","922.25","922.75","923.25","923.75","924.25","924.75","925.25","925.75","926.25","926.75","927.25"}},
            // {4, new List<String>(){"866.3","866.9","867.5","868.1"}},
            // {5, new List<String>(){"916.8","918.0","919.2","920.4"}}
        };
        // 当前选择的频点下标
        List<PointItem> List_NowPoint = new List<PointItem>();

        public SettingRFID_RF()
        {
            InitializeComponent();
        }

        public SettingRFID_RF(string readerID, ClouReaderAPI.ClouInterface.IAsynchronousMessage contextForm)
            : this()
        {
            this.ConnID = readerID;
            this.contextForm = contextForm;
        }

        private void SettingRFID_RF_Load(object sender, EventArgs e)
        {
            this.Width = 500;
            this.Height = 300;
            InitDIC_RF();
            Init();
        }
        // 查询
        private void Init() 
        {
            // 查询当前工作频段
            if (!String.IsNullOrEmpty(ConnID))
            {
                string rt = ClouReaderAPI.CLReader.RFID_OPTION.GetRederRF(ConnID);
                Int32 index = -1;
                if (Int32.TryParse(rt, out index))
                {
                    this.cmb_RF.SelectedIndex = Int32.Parse(rt);
                }
            }
            // 查询跳频
            String rtStr = ClouReaderAPI.CLReader.RFID_OPTION.GetReaderWorkFrequency(ConnID);
            String[] varStr = rtStr.Split('|');
            if (varStr.Length > 0)
            {
                try
                {
                    cmb_RFType.SelectedIndex = Byte.Parse(varStr[0]);
                    List_NowPoint.Clear();
                    foreach (String item in varStr[1].Split(','))
                    {
                        Int32 ii = -1;
                        if (Int32.TryParse(item, out ii))
                        {
                            List_NowPoint.Add(new PointItem(ii,DIC_RF[cmb_RF.SelectedIndex][ii]));
                        }
                    }
                }
                catch { }
            }
            else
            {
                ShowMessage(rtStr);
            }
            ReviewNowPoint();
        }
        // 改变频段
        private void cmb_RF_SelectedIndexChanged(object sender, EventArgs e)
        {
            try 
            {
                lb_AllPoint.Items.Clear();
                for (int i = 0; i < DIC_RF[cmb_RF.SelectedIndex].Count; i++)
                {
                    lb_AllPoint.Items.Add(new PointItem(i, DIC_RF[cmb_RF.SelectedIndex][i]));
                }
            }
            catch { }
        }
        // 刷新当前选择的频点
        private void ReviewNowPoint() 
        {
            tb_PointList.Text = "";
            String pointString = "";
            foreach (PointItem item in List_NowPoint)
            {
                pointString += item + ",";
            }
            pointString = pointString.TrimEnd(',');
            tb_PointList.Text = pointString;
        }
        // 添加频点
        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (lb_AllPoint.SelectedItems.Count > 0) 
            {
                foreach (PointItem item in lb_AllPoint.SelectedItems)
                {
                    if (!List_NowPoint.Contains(item)) 
                    {
                        List_NowPoint.Add(item);
                    }
                }
            }
            ReviewNowPoint();
        }
        // 添加所有频点
        private void btn_AddAll_Click(object sender, EventArgs e)
        {
            List_NowPoint.Clear();
            for (int i = 0; i < DIC_RF[cmb_RF.SelectedIndex].Count; i++)
            {
                List_NowPoint.Add(new PointItem(i, DIC_RF[cmb_RF.SelectedIndex][i]));
            }
            ReviewNowPoint();
        }
        // 删除所有频点
        private void btn_Clear_Click(object sender, EventArgs e)
        {
            List_NowPoint.Clear();
            ReviewNowPoint();
        }
        // 配置
        private void btn_0010_05_Set_Click(object sender, EventArgs e)
        {
            // String rt1 = ""; 
            String rt2 = "";
            //if (!String.IsNullOrEmpty(ConnID))
            //{
            //    string param = cmb_RF.SelectedIndex.ToString();
            //    rt1 = ClouReaderAPI.CLReader.rfidOption.SetReaderRF(ConnID, param);
            //}

            String sendParam = "";
            if (cmb_RFType.SelectedIndex == 1)
            {
                sendParam += cmb_RFType.SelectedIndex;
            }
            else
            {
                sendParam += cmb_RFType.SelectedIndex + "|" + GetAllPoint();
            }
            rt2 = ClouReaderAPI.CLReader.RFID_OPTION.SetReaderWorkFrequency(ConnID, sendParam);
            if (rt2.StartsWith("0"))
            {
                ShowMessage("Success!");
                Init();
            }
            else 
            {
                ShowMessage("Failure!");
            }
        }
        // 获得当前配置的频点
        private String GetAllPoint() 
        {
            String rt = "";
            foreach (PointItem item in List_NowPoint)
            {
                rt += item.PointIndex + ",";
            }
            rt = rt.TrimEnd(',');
            return rt;
        }
        // 设置频段
        private void btn_SetRF_Click(object sender, EventArgs e)
        {
            String rt1 = "";
            string param = cmb_RF.SelectedIndex.ToString();
            rt1 = ClouReaderAPI.CLReader.RFID_OPTION.SetReaderRF(ConnID, param);
            Init();
            ShowMessage(rt1);
        }
        #region 通用辅助方法

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

    // 频点对象
    public class PointItem 
    {
        private Int32 pointIndex = 0;

        public Int32 PointIndex
        {
            get { return pointIndex; }
            set { pointIndex = value; }
        }
        private String pointText = "";

        public String PointText
        {
            get { return pointText; }
            set { pointText = value; }
        }
        public PointItem() { }
        public PointItem(Int32 pointIndex, String pointText) 
        {
            this.pointIndex = pointIndex;
            this.pointText = pointText;
        }
        public override string ToString()
        {
            return pointText;
        }
    }
}
