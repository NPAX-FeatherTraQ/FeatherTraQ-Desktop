using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ClouReaderAPI;
using ClouReaderAPI.ClouInterface;

namespace ClouReaderDemo.MyForm.Dialog
{
    public partial class AddSerial : BaseDialog
    {
        IAsynchronousMessage contextForm = null;
        public AddSerial()
        {
            InitializeComponent();
        }
        public AddSerial(IAsynchronousMessage contextForm)
            : this()
        {
            this.contextForm = contextForm;
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            string param = this.tb_SerialParam.Text.Trim();
            if (CLReader.CreateSerialConn(param, contextForm))
            {
                this.DialogResult = DialogResult.OK;
            }
            else 
            {
                this.DialogResult = DialogResult.No;
            }
        }
    }
}
