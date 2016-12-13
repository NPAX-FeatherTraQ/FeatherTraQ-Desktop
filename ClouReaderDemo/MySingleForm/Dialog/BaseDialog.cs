using ClouReaderDemo.Forms;
using ClouReaderDemo.MyFormTemplet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ClouReaderDemo.MySingleForm.TestForm.Dialog
{
    public partial class BaseDialog : _360Form
    {
        public BaseDialog()
        {
            InitializeComponent();
        }

        private void BaseDialog_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ShowIcon = false;
            base.IsResize = false;
            this.SysButton = ESysButton.Normal;
        }
    }
}
