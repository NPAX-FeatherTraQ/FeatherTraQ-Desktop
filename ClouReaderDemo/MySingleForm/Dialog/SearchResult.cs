using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ClouReaderDemo.MySingleForm.TestForm.Dialog
{
    public partial class SearchResult : BaseDialog
    {
        public SearchResult()
        {
            InitializeComponent();
        }

        public SearchResult(String msg)
            : this()
        {
            this.label1.Text = msg;
            this.Width = 400;
            this.Height = 190;
        }
    }
}
