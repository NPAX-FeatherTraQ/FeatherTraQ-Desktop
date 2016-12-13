using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ClouReaderDemo.MySingleForm.TestForm.Dialog
{
    public partial class SendCommand : BaseDialog
    {
        private SingleMainForm contextForm;
        public SendCommand()
        {
            InitializeComponent();
        }

        public SendCommand(SingleMainForm contextForm):this()
        {
            this.contextForm = contextForm;
            this.Width = 500;
            this.Height = 250;
        }

        private void btn_SendCommand_Click(object sender, EventArgs e)
        {
            Int32 iMax = 1;
            try
            {
                iMax = Int32.Parse(tb_TotalCount.Text.Trim());
            }
            catch { }
            for (int i = 0; i < iMax; i++)
            {
                ClouReaderAPI.CLReader.SendCustomCommand(contextForm.ConnID, tb_Command.Text.Trim());
            }
        }
    }
}
