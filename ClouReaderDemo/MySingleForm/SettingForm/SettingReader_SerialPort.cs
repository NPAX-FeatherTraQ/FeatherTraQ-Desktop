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
    /// 串口设置
    /// </summary>
    public partial class SettingReader_SerialPort : BaseOption
    {
        ClouReaderAPI.ClouInterface.IAsynchronousMessage contextForm =null;
        public SettingReader_SerialPort()
        {
            InitializeComponent();
        }

        public SettingReader_SerialPort(string readerID, ClouReaderAPI.ClouInterface.IAsynchronousMessage contextForm)
            : this()
        {
            this.ConnID = readerID;
            this.contextForm = contextForm;
        }

        private void SettingReader_SerialPort_Load(object sender, EventArgs e)
        {
            this.Width = 500;
            this.Height = 300;
            Init();
        }

        private void Init() 
        {
            Int32 rt = -1;
            String rtStr = ClouReaderAPI.CLReader.PARAM_SET.GetReaderSerialPortParam(ConnID);
            if (Int32.TryParse(rtStr, out rt))
            {
                cb_0001_02_00.SelectedIndex = rt;
            }
            else
            {
                ShowMessage(rtStr);
            }
        }

        private void btn_0001_02_Set_Click(object sender, EventArgs e)
        {
            ShowMessage(ClouReaderAPI.CLReader.PARAM_SET.SetReaderSerialPortParam(ConnID, cb_0001_02_00.SelectedIndex.ToString()));
        }

        private void btn_Init_Click(object sender, EventArgs e)
        {
            Init();
        }
    }
}
