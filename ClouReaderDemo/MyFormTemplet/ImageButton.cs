using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ClouReaderDemo.MyFormTemplet
{
    public partial class ImageButton : UserControl
    {
        public ImageButton()
        {
            this.InitializeComponent();
        }

        private void ImageButton_Load(object sender, EventArgs e)
        {
            this.pImage.Image = this.backgroundimage;

            this.lblTemp.Parent = this.pImage;
            this.lblTemp.Width = this.pImage.Width;
            this.lblTemp.Left = (int)Math.Round((double)((((double)this.pImage.Width) / 2.0) - (((double)this.lblTemp.Width) / 2.0)));
            this.lblTemp.Top = (int)Math.Round((double)((((double)this.pImage.Height) / 2.0) - (((double)this.lblTemp.Height) / 2.0)));
        }

        private void ImageButton_Resize(object sender, EventArgs e)
        {
            this.lblTemp.Left = (int)Math.Round((double)((((double)this.pImage.Width) / 2.0) - (((double)this.lblTemp.Width) / 2.0)));
            this.lblTemp.Top = (int)Math.Round((double)((((double)this.pImage.Height) / 2.0) - (((double)this.lblTemp.Height) / 2.0)));
        }

        #region 属性

        private Image backgroundimage;
        private Image mouseoverimage;
        private Image mouseclickimage;

        [Category("重要属性"), Description("按钮默认显示的背景图片")]
        public override Image BackgroundImage
        {
            get
            {
                return this.pImage.Image;
            }
            set
            {
                this.pImage.Image = value;
                this.backgroundimage = value;
            }
        }

        [Category("重要属性"), Description("按钮中要显示的文本")]
        public string ButtonText
        {
            get
            {
                return this.lblTemp.Text;
            }
            set
            {
                this.lblTemp.Text = value;
            }
        }

        [Category("重要属性"), Description("单击按钮时候显示的图片")]
        public Image MouseClickImage
        {
            get
            {
                return this.mouseclickimage;
            }
            set
            {
                this.mouseclickimage = value;
            }
        }

        [Category("重要属性"), Description("鼠标移动到按钮上时显示的图片")]
        public Image MouseOverImage
        {
            get
            {
                return this.mouseoverimage;
            }
            set
            {
                this.mouseoverimage = value;
            }
        }

        #endregion

        #region 事件

        public delegate void ClickEventHandler(object sender, EventArgs e);
        public event ClickEventHandler Click;

        private void OnClick(object sender, EventArgs e)
        {
            ClickEventHandler clickEvent = this.Click;
            if (clickEvent != null)
            {
                clickEvent(this, e);
            }
        }

        #region 鼠标事件

        private void Mouse_Enter(object sender, EventArgs e)
        {
            //this.Cursor = Cursors.Hand;
            this.pImage.Image = this.mouseoverimage;
        }

        private void Mouse_Leave(object sender, EventArgs e)
        {
            //this.Cursor = Cursors.Arrow;
            this.pImage.Image = this.backgroundimage;
        }

        private void Mouse_Down(object sender, MouseEventArgs e)
        {
            //this.Cursor = Cursors.Hand;
            this.pImage.Image = this.mouseclickimage;
        }

        private void Mouse_Hover(object sender, EventArgs e)
        {
            this.pImage.Image = this.mouseoverimage;
        }

        private void Mouse_Up(object sender, MouseEventArgs e)
        {
            this.pImage.Image = this.backgroundimage;
        }

        #endregion

        private void lblTemp_TextChanged(object sender, EventArgs e)
        {
            this.lblTemp.Parent = this.pImage;
            this.lblTemp.Width = this.pImage.Width;
            this.lblTemp.Left = (int)Math.Round((double)((((double)this.pImage.Width) / 2.0) - (((double)this.lblTemp.Width) / 2.0)));
            this.lblTemp.Top = (int)Math.Round((double)((((double)this.pImage.Height) / 2.0) - (((double)this.lblTemp.Height) / 2.0)));
        }

        private void pbImage_BackgroundImageChanged(object sender, EventArgs e)
        {
            this.pImage.Refresh();
        }

        #endregion
    }

    //ImageButton.Designer.cs  
    partial class ImageButton
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            this.pImage = new PictureBox();
            this.lblTemp = new Label();
            ((ISupportInitialize)this.pImage).BeginInit();
            base.SuspendLayout();
            this.pImage.Dock = DockStyle.Fill;
            this.pImage.Location = new Point(0, 0);
            this.pImage.Name = "pbImage";
            this.pImage.Size = new Size(0x80, 40);
            this.pImage.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pImage.TabIndex = 0;
            this.pImage.TabStop = false;
            this.pImage.MouseLeave += new EventHandler(this.Mouse_Leave);
            this.pImage.Click += new EventHandler(this.OnClick);
            this.pImage.MouseDown += new MouseEventHandler(this.Mouse_Down);
            this.pImage.BackgroundImageChanged += new EventHandler(this.pbImage_BackgroundImageChanged);
            this.pImage.MouseHover += new EventHandler(this.Mouse_Hover);
            this.pImage.MouseUp += new MouseEventHandler(this.Mouse_Up);
            this.pImage.MouseEnter += new EventHandler(this.Mouse_Enter);
            this.lblTemp.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            this.lblTemp.AutoSize = true;
            this.lblTemp.BackColor = Color.Transparent;
            this.lblTemp.Location = new Point(13, 15);
            this.lblTemp.Name = "lblTemp";
            this.lblTemp.Size = new Size(0x65, 12);
            this.lblTemp.TabIndex = 1;
            this.lblTemp.Text = "请输入显示的文本";
            this.lblTemp.TextAlign = ContentAlignment.MiddleCenter;
            this.lblTemp.MouseLeave += new EventHandler(this.Mouse_Leave);
            this.lblTemp.Click += new EventHandler(this.OnClick);
            this.lblTemp.MouseDown += new MouseEventHandler(this.Mouse_Down);
            this.lblTemp.MouseEnter += new EventHandler(this.Mouse_Enter);
            this.lblTemp.MouseHover += new EventHandler(this.Mouse_Hover);
            this.lblTemp.MouseUp += new MouseEventHandler(this.Mouse_Up);
            this.lblTemp.TextChanged += new EventHandler(this.lblTemp_TextChanged);
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.Controls.Add(this.lblTemp);
            base.Controls.Add(this.pImage);
            base.Name = "ImageButton";
            base.Size = new Size(0x80, 40);
            base.Load += new EventHandler(this.ImageButton_Load);
            base.Resize += new EventHandler(this.ImageButton_Resize);
            base.MouseEnter += new EventHandler(this.Mouse_Enter);
            base.MouseLeave += new EventHandler(this.Mouse_Leave);
            ((ISupportInitialize)this.pImage).EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private Label lblTemp;
        private PictureBox pImage;

        #endregion
    }
}
