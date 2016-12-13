using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ClouReaderDemo.MySingleForm.TestForm.Dialog
{
    public partial class AddBlack_WriteList : BaseDialog
    {
        BlacklistBeep beepForm = null;
        public AddBlack_WriteList()
        {
            InitializeComponent();
        }

        public AddBlack_WriteList(Int32 addType, BlacklistBeep beepForm)
            : this()
        {
            if (addType == 0) 
            {
                this.Text = "添加黑名单";
            }
            else if(addType == 1)
            {
                this.Text = "添加白名单";
            }
            this.beepForm = beepForm;
            this.beepForm.TempAddListValue = "";
        }

        private void btn_AddList_Click(object sender, EventArgs e)
        {
            beepForm.TempAddListValue = tb_Value.Text;
            this.DialogResult = DialogResult.OK;
        }
    }
}
