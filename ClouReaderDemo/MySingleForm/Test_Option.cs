using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ClouReaderAPI.ClouInterface;

namespace ClouReaderDemo.MySingleForm
{
    public partial class Test_Option : BaseOption
    {
        IAsynchronousMessage contextForm = null;
        public Int32 rfIndex = 0;               // 当前查询到的读的器的频率范围
        Dictionary<Int32, List<String>> DIC_RF = new Dictionary<int, List<String>>(){};

        public Test_Option()
        {
            InitializeComponent();
        }

        public Test_Option(string readerID, IAsynchronousMessage contextForm)
            : this()
        {
            this.ConnID = readerID;
            this.contextForm = contextForm;
            this.Text = readerID.Trim() + " --较准";
        }

        private void Test_Option_Load(object sender, EventArgs e)
        {
            InitDIC_RF();
            tc_Main.SelectedIndex = -1;
            tc_Main.SelectedIndex = 0;
        }
        // 选项卡切换时，初始化查询所的数据
        private void tc_Main_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (tc_Main.SelectedIndex == 0)
            {
                InitReaderProerty();
                InitTestControl();
            }
            else if (tc_Main.SelectedIndex == 1)
            {
                InitReaderProerty();
                InitTestControl_1();
            }
            else
            {

            }
        }

        #region 通用辅助方法

        private void InitDIC_RF()
        {
            DIC_RFAddItem(0, 920.625f, 924.375f, 0.25f);
            DIC_RFAddItem(1, 840.625f, 844.375f, 0.25f);
            DIC_RFAddItem(2, 840.625f, 844.375f, 0.25f);
            DIC_RFAddItem(2, 920.625f, 924.375f, 0.25f);
            DIC_RFAddItem(3, 902.75f, 927.25f, 0.5f);
            DIC_RFAddItem(4, 865.7f, 868.1f, 0.6f);
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

        #region 测试命令

        private void btn_0010_04_Get_t_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(ConnID))
            {
                string rt = ClouReaderAPI.CLReader.RFID_OPTION.GetRederRF(ConnID);
                Int32 index = -1;
                if (Int32.TryParse(rt, out index))
                {
                    try
                    {
                        this.cb_0010_03_t.SelectedIndex = Int32.Parse(rt);
                        rfIndex = index;
                        cb_0101_00_1.Items.Clear();
                        cb_0101_00_1.Items.AddRange(DIC_RF[rfIndex].ToArray());
                    }
                    catch { }
                }
            }

        }

        private void btn_0010_03_Set_t_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(ConnID))
            {
                string param = cb_0010_03_t.SelectedIndex.ToString();
                ShowMessage(ClouReaderAPI.CLReader.RFID_OPTION.SetReaderRF(ConnID, param));
                btn_0010_04_Get_t_Click(null, null);
            }
        }

        private void btn_0101_00_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(ConnID))
            {
                string param = btn_0101_00.Tag.ToString() + "|" + cb_0101_00_1.SelectedIndex.ToString();

                ShowMessage(ClouReaderAPI.CLReader.RFID_OPTION.SendCarrier(ConnID, param));
            }
        }

        private void dud_0101_01_SelectedItemChanged(object sender, EventArgs e)
        {
            try
            {
                tBar_0101_01.Value = Int32.Parse(dud_0101_01.Text.Trim());
            }
            catch { }
        }

        private void dud_0101_01_Click(object sender, EventArgs e)
        {
            string param = dud_0101_01.Text.ToString() + "|0";
            string rt = ClouReaderAPI.CLReader.RFID_OPTION.Set_0101_01(ConnID, param);
        }

        private void dud_0101_01_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                dud_0101_01_Click(null, null);
            }
        }

        private void tBar_0101_01_Scroll(object sender, EventArgs e)
        {
            dud_0101_01.Text = tBar_0101_01.Value.ToString();
        }

        private void tBar_0101_01_MouseUp(object sender, MouseEventArgs e)
        {
            dud_0101_01_Click(null, null);
        }

        private void dud_0101_03_02_MouseUp(object sender, MouseEventArgs e)
        {
            string param = tb_0101_03_00.Text.ToString() + "|" + tb_0101_03_01.Text.ToString() + "|" + dud_0101_03_02.Text.ToString() + "|0";
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
                string param = tb_0101_03_00.Text.ToString() + "|" + tb_0101_03_01.Text.ToString() + "|" + dud_0101_03_02.Text.ToString() + "|0";
                string rt = ClouReaderAPI.CLReader.RFID_OPTION.Set_0101_03(ConnID, param);
            }
        }

        private void btn_0101_01_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(ConnID))
            {
                string param = dud_0101_01.Text.ToString() + "|1";
                string rt = ClouReaderAPI.CLReader.RFID_OPTION.Set_0101_01(ConnID, param);
                ShowMessage(rt);
            }
        }

        private void tBar_0101_03_03_Scroll(object sender, EventArgs e)
        {
            dud_0101_03_02.Text = tBar_0101_03_03.Value.ToString();
        }

        private void tBar_0101_03_03_MouseUp(object sender, MouseEventArgs e)
        {
            string param = tb_0101_03_00.Text.ToString() + "|" + tb_0101_03_01.Text.ToString() + "|" + dud_0101_03_02.Text.ToString() + "|0";
            string rt = ClouReaderAPI.CLReader.RFID_OPTION.Set_0101_03(ConnID, param);
        }

        private void tb_0101_03_01_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (cb_0101_00_1.Items.Count > 0)
                {
                    Int32 selectIndex = cb_0101_00_1.Items.Count / 2;
                    cb_0101_00_1.SelectedIndex = selectIndex;
                }
                btn_0101_00_Click(null, null);
            }
        }

        private void btn_0101_03_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(ConnID))
            {
                string param = tb_0101_03_00.Text.ToString() + "|" + tb_0101_03_01.Text.ToString() + "|" + dud_0101_03_02.Text.ToString() + "|1";

                string rt = ClouReaderAPI.CLReader.RFID_OPTION.Set_0101_03(ConnID, param);
                ShowMessage(rt);

            }
        }

        private void btn_0101_04_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(ConnID))
            {
                string param = tb_0101_03_00.Text.ToString() + "|" + tb_0101_03_01.Text.ToString();
                string rt = ClouReaderAPI.CLReader.RFID_OPTION.Get_0101_04(ConnID, param);
                string[] array_rt = rt.Split('|');
                if (array_rt.Length >= 3)
                {
                    this.tb_0101_03_00.Text = array_rt[0];
                    this.tb_0101_03_01.Text = array_rt[1];
                    int objIndex = dud_0101_03_02.Items.IndexOf(array_rt[2]);
                    if (objIndex >= 0)
                    {
                        dud_0101_03_02.SelectedIndex = objIndex;
                    }
                    // this.dud_0101_03_02.Text = array_rt[2];
                }
            }
        }

        private void btn_0101_04_NextPower_Click(object sender, EventArgs e)
        {
            try
            {
                Int32 nowDB = Int32.Parse(tb_0101_03_01.Text.Trim());
                if (nowDB + 1 <= maxDB)
                {
                    tb_0101_03_01.Text = (nowDB + 1).ToString();
                    tb_0101_03_01_KeyDown(null, null);
                }
            }
            catch { }
        }

        private void btn_0101_05_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(ConnID))
            {
                string rt = ClouReaderAPI.CLReader.RFID_OPTION.Get_0101_05(ConnID);
                ShowMessage(rt);
                string[] array_rt = rt.Split('|');
                if (array_rt.Length >= 2)
                {
                    this.tb_0101_05_00.Text = array_rt[0];
                    this.tb_0101_05_01.Text = array_rt[1];
                }
            }
        }

        private void rb_0101_00_00_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb != null)
            {
                btn_0101_00.Tag = rb.Tag;
            }
        }

        private void btn_StopReader_Click(object sender, EventArgs e)
        {
            ShowMessage(ClouReaderAPI.CLReader.RFID_OPTION.StopReader(ConnID));
        }


        #region pr9200外部PA反馈参数


        private void dud_RES_1_SelectedItemChanged(object sender, EventArgs e)
        {
            try
            {
                tBar_RES_1.Value = Int32.Parse(dud_RES_1.Text.Trim());
            }
            catch { }
        }

        private void dud_RES_2_SelectedItemChanged(object sender, EventArgs e)
        {
            try
            {
                tBar_RES_2.Value = Int32.Parse(dud_RES_2.Text.Trim());
            }
            catch { }
        }

        private void tBar_RES_1_Scroll(object sender, EventArgs e)
        {
            dud_RES_1.Text = tBar_RES_1.Value.ToString();
        }

        private void tBar_RES_2_Scroll(object sender, EventArgs e)
        {
            dud_RES_2.Text = tBar_RES_2.Value.ToString();
        }

        private void tBar_RES_1_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                Int32 i_RES1 = Int32.Parse(dud_RES_1.Text.ToString());
                Int32 i_RES2 = Int32.Parse(dud_RES_2.Text.ToString());
                Byte RES1_RES2 = (Byte)((i_RES1 << 4) + i_RES2);

                string param = RES1_RES2 + "|0";
                string rt = ClouReaderAPI.CLReader.RFID_OPTION.Set_0101_06(ConnID, param);
            }
            catch { }
        }

        private void tBar_RES_2_MouseUp(object sender, MouseEventArgs e)
        {
            tBar_RES_1_MouseUp(null, null);
        }


        private void btn_0101_06_Click(object sender, EventArgs e)
        {
            try
            {
                Int32 i_RES1 = Int32.Parse(dud_RES_1.Text.ToString());
                Int32 i_RES2 = Int32.Parse(dud_RES_2.Text.ToString());
                Byte RES1_RES2 = (Byte)((i_RES1 << 4) + i_RES2);

                string param = RES1_RES2 + "|1";
                string rt = ClouReaderAPI.CLReader.RFID_OPTION.Set_0101_06(ConnID, param);
            }
            catch { }
        }

        private void btn_0101_07_Click(object sender, EventArgs e)
        {
            try
            {
                String RES1_RES2 = ClouReaderAPI.CLReader.RFID_OPTION.Get_0101_07(ConnID);
                String[] arrRES = RES1_RES2.Split('|');
                dud_RES_1.Text = arrRES[0];
                dud_RES_2.Text = arrRES[1];
            }
            catch (Exception ex) { }
        }


        private void dud_RES_1_Click(object sender, EventArgs e)
        {
            try
            {
                Int32 i_RES1 = Int32.Parse(dud_RES_1.Text.ToString());
                Int32 i_RES2 = Int32.Parse(dud_RES_2.Text.ToString());
                Byte RES1_RES2 = (Byte)((i_RES1 << 4) + i_RES2);

                string param = RES1_RES2 + "|0";
                string rt = ClouReaderAPI.CLReader.RFID_OPTION.Set_0101_06(ConnID, param);
            }
            catch { }
        }

        private void dud_RES_2_Click(object sender, EventArgs e)
        {
            dud_RES_1_Click(null, null);
        }



        #endregion

        #endregion

        #region 参数初始化

        private void InitTestControl()
        {
            foreach (var item in gb_SendCarrier.Controls)
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
            for (int i = 127; i >= -127; i--)
            {
                dud_0101_01.Items.Add(i.ToString());
            }
            for (int i = 255; i >= 0; i--)
            {
                dud_0101_03_02.Items.Add(i.ToString());
            }
            String rtStr = ClouReaderAPI.CLReader.RFID_OPTION.Get_0101_02(ConnID);
            int objIndex = dud_0101_01.Items.IndexOf(rtStr);
            if (objIndex >= 0)
            {
                dud_0101_01.SelectedIndex = objIndex;
            }

            // dud_0101_01.Text = ClouReaderAPI.CLReader.RFID_OPTION.Get_0101_02(ConnID);

            btn_0010_04_Get_t_Click(null, null);
            btn_0101_04_Click(null, null);

        }

        private void InitTestControl_1()
        {
            for (int i = 7; i >= 0; i--)
            {
                dud_RES_1.Items.Add(i.ToString());
            }

            for (int i = 15; i >= 0; i--)
            {
                dud_RES_2.Items.Add(i.ToString());
            }
            try
            {
                String RES1_RES2 = ClouReaderAPI.CLReader.RFID_OPTION.Get_0101_07(ConnID);
                String[] arrRES = RES1_RES2.Split('|');
                int objIndex_1 = dud_RES_1.Items.IndexOf(arrRES[0]);
                if (objIndex_1 >= 0)
                {
                    dud_RES_1.SelectedIndex = objIndex_1;
                }
                int objIndex_2 = dud_RES_2.Items.IndexOf(arrRES[1]);
                if (objIndex_2 >= 0)
                {
                    dud_RES_2.SelectedIndex = objIndex_2;
                }
                // dud_RES_1.Text = arrRES[0];
                // dud_RES_2.Text = arrRES[1];
            }
            catch { }
        }

        #endregion

    }
}
