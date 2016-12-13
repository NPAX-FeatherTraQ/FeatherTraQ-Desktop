using ClouReaderDemo.MyFormTemplet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ClouReaderDemo.MySingleForm.SettingForm
{
    public partial class SettingGPI_ReadParam : BaseOption
    {
        String rtParam = "";
        SettingGPI singleMainForm = null;

        public SettingGPI_ReadParam()
        {
            InitializeComponent();
        }

        public SettingGPI_ReadParam(SettingGPI smf, Int32 commandIndex)
            : this()
        {
            this.singleMainForm = smf;
            this.cmb_CommandList.SelectedIndex = commandIndex;
        }

        private void ReadTag_Param_Load(object sender, EventArgs e)
        {
            this.Width = 700;
            this.Height = 500;
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            #region 获取参数            
            foreach (var item in tp_6C.Controls)
            {
                CheckBox cb = item as CheckBox;
                if (cb != null) 
                {
                    if (cb.Checked) 
                    {
                        try
                        {
                            if (cb.Name.EndsWith("1"))              //  匹配参数
                            {
                                rtParam += "1,";
                                String param1 = ClouReaderAPI.MyHelper.MyString.ByteToString((Byte)cb_01_00.SelectedIndex);
                                param1 += GetHexStringByUInt16(UInt16.Parse(tb_01_01.Text.Trim()));
                                param1 += ClouReaderAPI.MyHelper.MyString.ByteToString((Byte)(tb_01_02.Text.Length * 4));
                                param1 += tb_01_02.Text.Trim();
                                rtParam += param1 + "&";
                            }
                            else if (cb.Name.EndsWith("2"))         // TID参数
                            {
                                rtParam += "2,";
                                rtParam += ClouReaderAPI.MyHelper.MyString.ByteToString((Byte)cb_02_00.SelectedIndex);
                                rtParam += GetHexStringByByte(Byte.Parse(tb_02_01.Text.Trim()));
                                rtParam += "&";
                            }
                            else if (cb.Name.EndsWith("3"))         // 用户区参数
                            {
                                rtParam += "3,";
                                rtParam += GetHexStringByUInt16(UInt16.Parse(tb_03_00.Text.Trim()));
                                rtParam += GetHexStringByByte(Byte.Parse(tb_03_01.Text.Trim()));
                                rtParam += "&";
                            }
                            else if (cb.Name.EndsWith("4"))         // 保留区参数
                            {
                                rtParam += "4,";
                                rtParam += GetHexStringByUInt16(UInt16.Parse(tb_04_00.Text.Trim()));
                                rtParam += GetHexStringByByte(Byte.Parse(tb_04_01.Text.Trim()));
                                rtParam += "&";
                            }
                        }
                        catch { }
                    }
                }
            }
            #endregion

            rtParam = rtParam.TrimEnd('&');

            if (singleMainForm != null) 
            {
                singleMainForm.readVarParam_6B = "";
                singleMainForm.readVarParam_6C = rtParam;
            }
            this.DialogResult = DialogResult.OK;
            Save();
        }

        private void btn_Save_6B_Click(object sender, EventArgs e)
        {
            rtParam += cb_0010_40_00.SelectedIndex + "|";
            if (!String.IsNullOrEmpty(tb_0010_40_02.Text))
            {
                rtParam += "1," + tb_0010_40_01.Text + tb_0010_40_02.Text + "&";
            }
            if (!String.IsNullOrEmpty(tb_0010_40_03.Text)) 
            {
                rtParam += "2," + tb_0010_40_03.Text;
            }
            rtParam = rtParam.TrimEnd('&');
            if (singleMainForm != null)
            {
                singleMainForm.readVarParam_6C = "";
                singleMainForm.readVarParam_6B = rtParam;
            }
            this.DialogResult = DialogResult.OK;
            Save();
        }

        private byte[] GetReverseU16(ushort data)
        {
            byte[] rt = new byte[2];
            rt = BitConverter.GetBytes(data);
            Array.Reverse(rt);
            return rt;
        }

        private void Save() 
        {
            if (cmb_CommandList.SelectedIndex >= 0)
            {
                SaveConfig(cmb_CommandList.SelectedIndex);
                ShowMessage("Save Success！");
            }
            else
            {
                ShowMessage("Please select a command list！");
            }
        }

        private void SaveConfig(Int32 commandIndex) 
        {
            try
            {
                Helper.MyXmlHelper.UpdateInnerText(XMLFIENAME, "Root/" + this.Name + "_" + commandIndex, tc_Main.Name, tc_Main.SelectedIndex.ToString());
                foreach (var item in tp_6C.Controls)
                {
                    if (item is QQTextBoxEx)
                    {
                        QQTextBoxEx tb = (QQTextBoxEx)item;
                        Helper.MyXmlHelper.UpdateInnerText(XMLFIENAME, "Root/" + this.Name + "_" + commandIndex, tb.Name, tb.Text.Trim());
                    }
                    else if (item is ComboBox)
                    {
                        ComboBox cb = (ComboBox)item;
                        Helper.MyXmlHelper.UpdateInnerText(XMLFIENAME, "Root/" + this.Name + "_" + commandIndex, cb.Name, cb.SelectedIndex.ToString());
                    }
                    else if(item is CheckBox) 
                    {
                        CheckBox cb = (CheckBox)item;
                        Helper.MyXmlHelper.UpdateInnerText(XMLFIENAME, "Root/" + this.Name + "_" + commandIndex, cb.Name, cb.Checked.ToString());
                    }
                }
                foreach (var item in tp_6B.Controls)
                {
                    if (item is QQTextBoxEx)
                    {
                        QQTextBoxEx tb = (QQTextBoxEx)item;
                        Helper.MyXmlHelper.UpdateInnerText(XMLFIENAME, "Root/" + this.Name + "_" + commandIndex, tb.Name, tb.Text.Trim());
                    }
                    else if (item is ComboBox)
                    {
                        ComboBox cb = (ComboBox)item;
                        Helper.MyXmlHelper.UpdateInnerText(XMLFIENAME, "Root/" + this.Name + "_" + commandIndex, cb.Name, cb.SelectedIndex.ToString());
                    }
                    else if (item is CheckBox)
                    {
                        CheckBox cb = (CheckBox)item;
                        Helper.MyXmlHelper.UpdateInnerText(XMLFIENAME, "Root/" + this.Name + "_" + commandIndex, cb.Name, cb.Checked.ToString());
                    }
                }
            }
            catch(Exception ex) { System.Diagnostics.Debug.WriteLine(ex.Message); }
        }

        private void ReadConfig(Int32 commandIndex) 
        {
            try
            {
                tc_Main.SelectedIndex = Int32.Parse(Helper.MyXmlHelper.ReadInnerText(XMLFIENAME, "Root/" + this.Name + "_" + commandIndex, tc_Main.Name));
                foreach (var item in tp_6C.Controls)
                {
                    if (item is QQTextBoxEx)
                    {
                        QQTextBoxEx tb = (QQTextBoxEx)item;
                        tb.Text = "";
                        tb.Text = Helper.MyXmlHelper.ReadInnerText(XMLFIENAME, "Root/" + this.Name + "_" + commandIndex, tb.Name);
                    }
                    else if (item is ComboBox)
                    {
                        ComboBox cb = (ComboBox)item;
                        cb.SelectedIndex = -1;
                        string value = Helper.MyXmlHelper.ReadInnerText(XMLFIENAME, "Root/" + this.Name + "_" + commandIndex, cb.Name);
                        cb.SelectedIndex = Int32.Parse(value);
                    }
                    else if (item is CheckBox)
                    {
                        CheckBox cb = (CheckBox)item;
                        cb.Checked = false;
                        string value = Helper.MyXmlHelper.ReadInnerText(XMLFIENAME, "Root/" + this.Name + "_" + commandIndex, cb.Name);
                        cb.Checked = Boolean.Parse(value);
                    }
                }
                foreach (var item in tp_6B.Controls)
                {
                    if (item is QQTextBoxEx)
                    {
                        QQTextBoxEx tb = (QQTextBoxEx)item;
                        tb.Text = "";
                        tb.Text = Helper.MyXmlHelper.ReadInnerText(XMLFIENAME, "Root/" + this.Name + "_" + commandIndex, tb.Name);
                    }
                    else if (item is ComboBox)
                    {
                        ComboBox cb = (ComboBox)item;
                        cb.SelectedIndex = -1;
                        string value = Helper.MyXmlHelper.ReadInnerText(XMLFIENAME, "Root/" + this.Name + "_" + commandIndex, cb.Name);
                        cb.SelectedIndex = Int32.Parse(value);
                    }
                    else if (item is CheckBox)
                    {
                        CheckBox cb = (CheckBox)item;
                        cb.Checked = false;
                        string value = Helper.MyXmlHelper.ReadInnerText(XMLFIENAME, "Root/" + this.Name + "_" + commandIndex, cb.Name);
                        cb.Checked = Boolean.Parse(value);
                    }
                }
            }
            catch (Exception ex) { System.Diagnostics.Debug.WriteLine(ex.Message); }
        }

        private void cmb_CommandList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReadConfig(cmb_CommandList.SelectedIndex);
        }

    }
}
