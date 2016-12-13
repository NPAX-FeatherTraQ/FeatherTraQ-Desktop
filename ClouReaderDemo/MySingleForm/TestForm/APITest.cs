using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ClouReaderDemo.MySingleForm.TestForm
{
    public partial class APITest : BaseOption
    {
        /// <summary>
        /// 上下文窗体
        /// </summary>
        ClouReaderAPI.ClouInterface.IAsynchronousMessage contextForm = null;

        public APITest()
        {
            InitializeComponent();
        }

        public APITest(string readerID, ClouReaderAPI.ClouInterface.IAsynchronousMessage contextForm)
            : this()
        {
            this.ConnID = readerID;
            this.contextForm = contextForm;
        }
    }
}
