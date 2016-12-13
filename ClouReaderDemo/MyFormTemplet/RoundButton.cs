using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace ClouReaderDemo.MyFormTemplet
{
    public class RoundButton : Button
    {
        #region 变量

        private Int32 _Radius = 15;

        #endregion

        #region 属性
        [Description("圆形半径"), Category("行为")]
        public Int32 Radius
        {
            get { return _Radius; }
            set { _Radius = value; }
        }
        
        #endregion
        public RoundButton() 
        {
            GraphicsPath myPath = new GraphicsPath();
            myPath.AddEllipse(5, 5, _Radius, _Radius);
            this.Region = new Region(myPath);
        }
    }
}
