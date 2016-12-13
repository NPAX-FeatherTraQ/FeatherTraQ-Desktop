using ClouReaderDemo.MyFormTemplet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ClouReaderDemo
{
    /// <summary>
    /// Author RFID_LX 2016.04.05
    /// 外接集线器
    /// </summary>
    public partial class HubMainForm : _360Form
    {
        private const Int32 GRID_ROWS = 4;              // 
        private const Int32 GRID_COLUMS = 2;            // 

        private const Int32 HUB_GRID_ROWS = 4;          //
        private const Int32 HUB_GRID_COLUMS = 4;        // 


        public HubMainForm()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
        }

        #region 窗体事件

        private void HubMainForm_Load(object sender, EventArgs e)
        {
            this.Height = 650;
            this.Width = 1024;
        }

        private void HubMainForm_Shown(object sender, EventArgs e)
        {
            InitView();                 // 初始化控件
        }

        #endregion

        #region 显示控制

        /// <summary>
        /// 初始化天线显示控件
        /// </summary>
        private void InitView() 
        {
            for (int iCol = 0; iCol < GRID_COLUMS; iCol++)
            {
                for (int iRow = 0; iRow < GRID_ROWS; iRow++)
                {
                    Panel add_Panel = new Panel();
                    Int32 antIndex = iCol * 4 + iRow;
                    add_Panel.Name = "pANT_" + antIndex;                 // 天线索引 从零开始
                    add_Panel.Tag = iCol * 4 + iRow;                     // 添加天线ID标识
                    add_Panel.Width = 210;
                    add_Panel.Height = 120;
                    add_Panel.Left = (30 + add_Panel.Width) * iRow + 45;
                    add_Panel.Top = (30 + 120) * iCol + 30;
                    add_Panel.Cursor = Cursors.Hand;
                    add_Panel.Paint += new PaintEventHandler(delegate(object sender, PaintEventArgs e) {
                        ControlPaint.DrawBorder(e.Graphics,
                                add_Panel.ClientRectangle,
                                Color.LightSeaGreen,                     // 7f9db9
                                2,
                                ButtonBorderStyle.Solid,
                                Color.LightSeaGreen,
                                2,
                                ButtonBorderStyle.Solid,
                                Color.LightSeaGreen,
                                2,
                                ButtonBorderStyle.Solid,
                                Color.LightSeaGreen,
                                2,
                                ButtonBorderStyle.Solid);
                    });

                    panel_Right.Controls.Add(add_Panel);               // 添加到容器

                    Label title_Label = new Label();
                    title_Label.Name = "titleLabel_" + antIndex;
                    title_Label.Text = "端口 " + (antIndex + 1);
                    title_Label.Width = 45;
                    title_Label.Left = add_Panel.Left + 60;
                    title_Label.Top = add_Panel.Top + add_Panel.Height + 5;
                    panel_Right.Controls.Add(title_Label);             // 添加端口名称

                    Label text_Label = new Label();
                    text_Label.Name = "textLabel_" + antIndex;
                    text_Label.TextAlign = ContentAlignment.MiddleCenter;
                    text_Label.Text = "0";
                    text_Label.Width = 45;
                    text_Label.Left = title_Label.Left + title_Label.Width + 5;
                    text_Label.Top = title_Label.Top - 6;
                    
                    panel_Right.Controls.Add(text_Label);              // 添加端口总读取次数

                    InitSingleGrid(add_Panel);                         // 初始化单个天线界面

                }
            }
        }

        /// <summary>
        /// 初始化单个天线端口
        /// </summary>
        /// <param name="contextPanel">天线端口Panel对象</param>
        private void InitSingleGrid(Panel contextPanel)
        {
            List<Color> listColor = new List<Color>() 
            {
                Color.Blue, Color.Yellow, Color.Green, Color.GreenYellow, Color.LightGoldenrodYellow,
                Color.Lime, Color.SeaShell, Color.YellowGreen, Color.PaleGreen, Color.MediumSlateBlue,
                Color.LightSkyBlue, Color.LightBlue, Color.Goldenrod, Color.ForestGreen, Color.LightBlue,
                Color.LightCoral, Color.LightSlateGray, Color.Linen, Color.MediumSlateBlue, Color.OldLace
            };

            for (int iCol = 0; iCol < HUB_GRID_COLUMS; iCol++)
            {
                for (int iRow = 0; iRow < HUB_GRID_COLUMS; iRow++)
                {
                    Label add_Label = new Label();
                    add_Label.Name = "lHub_" + contextPanel.Tag.ToString() + "_" + (iCol * 4 + iRow);
                    add_Label.Text = "0";
                    add_Label.Width = 43;
                    add_Label.Height = 18;
                    add_Label.Left = (add_Label.Width + 5) * iRow + 12;
                    add_Label.Top = (16 + 5) * iCol + 16;
                    add_Label.TextAlign = ContentAlignment.MiddleCenter;
                    add_Label.Cursor = Cursors.Hand;
                    add_Label.BackColor = listColor[iCol * 4 + iRow];

                    contextPanel.Controls.Add(add_Label);

                }
            }
        }

        #endregion

    }
}
