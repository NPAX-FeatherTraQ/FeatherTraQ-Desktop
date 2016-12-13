using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace BW.BAR2EPC.SERVER.MAIN
{
    public class LxLedControl : Control, ISupportInitialize
    {
        private bool m_bGradientBackground = false;
        private bool m_bIsCacheBuild = false;
        private bool m_bIsInitializing = false;
        private bool m_bRoundRect = false;
        private bool m_bShowHighlight = false;
        private GraphicsPath[] m_CachedPaths = new GraphicsPath[8];
        private Color m_colBorderColor = Color.Gray;
        private Color m_colCustomBk1 = Color.Black;
        private Color m_colCustomBk2 = Color.DimGray;
        private Color m_colFadedColor = Color.DimGray;
        private Color m_colFocusedBorderColor = Color.Cyan;
        private Alignment m_enumAlign = Alignment.Left;
        private float m_fBevelRate = 0.25f;
        private float m_fWidthIntervalRatio = 0.05f;
        private float m_fWidthSegWidthRatio = 0.2f;
        private bool m_italicMode = false;
        private int m_nBorderWidth = 1;
        private int m_nCharacterNumber = 5;
        private int m_nCornerRadius = 5;
        private byte m_nHighlightOpaque = 50;
        private bool m_smoothingMode = false;
        private const float WIDTHHEIGHTRATIO = 0.5f;

        public LxLedControl()
        {
            base.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            base.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.ForeColor = Color.LightGreen;
            this.BackColor = Color.Transparent;
            base.Click += new EventHandler(this.EvClick);
            base.KeyDown += new KeyEventHandler(this.EvKeyDown);
            base.GotFocus += new EventHandler(this.EvFocus);
            base.LostFocus += new EventHandler(this.EvFocus);
        }

        private void CalculateDrawingParams(out float segmentWidth, out float segmentInterval)
        {
            float num = base.ClientRectangle.Height * 0.5f;
            segmentWidth = num * this.m_fWidthSegWidthRatio;
            segmentInterval = num * this.m_fWidthIntervalRatio;
        }

        private void CreateCache(Rectangle rectBound, float bevelRate, float segmentWidth, float segmentInterval)
        {
            Matrix matrix = new Matrix(1f, 0f, 0f, 1f, 0f, 0f);
            matrix.Shear(-0.1f, 0f);
            PointF[] points = new PointF[6];
            PointF[] tfArray2 = new PointF[4];
            for (int i = 0; i < 8; i++)
            {
                if (this.m_CachedPaths[i] == null)
                {
                    this.m_CachedPaths[i] = new GraphicsPath();
                }
            }
            points[0].X = (segmentWidth * bevelRate) + segmentInterval;
            points[0].Y = segmentWidth * bevelRate;
            points[1].X = segmentInterval + ((segmentWidth * bevelRate) * 2f);
            points[1].Y = 0f;
            points[2].X = (rectBound.Width - segmentInterval) - ((segmentWidth * bevelRate) * 2f);
            points[2].Y = 0f;
            points[3].X = (rectBound.Width - segmentInterval) - (segmentWidth * bevelRate);
            points[3].Y = segmentWidth * bevelRate;
            points[4].X = (rectBound.Width - segmentInterval) - segmentWidth;
            points[4].Y = segmentWidth;
            points[5].X = segmentWidth + segmentInterval;
            points[5].Y = segmentWidth;
            this.m_CachedPaths[0].AddPolygon(points);
            this.m_CachedPaths[0].CloseFigure();
            if (this.UseItalicStyle)
            {
                this.m_CachedPaths[0].Transform(matrix);
            }
            points[0].X = rectBound.Width - segmentWidth;
            points[0].Y = segmentWidth + segmentInterval;
            points[1].X = rectBound.Width - (segmentWidth * bevelRate);
            points[1].Y = (segmentWidth * bevelRate) + segmentInterval;
            points[2].X = rectBound.Width + 1;
            points[2].Y = (((segmentWidth * bevelRate) * 2f) + segmentInterval) + 1f;
            points[3].X = rectBound.Width + 1;
            points[3].Y = (((rectBound.Height >> 1) - (segmentWidth * 0.5f)) - segmentInterval) - 1f;
            points[4].X = rectBound.Width - (segmentWidth * 0.5f);
            points[4].Y = (rectBound.Height >> 1) - segmentInterval;
            points[5].X = rectBound.Width - segmentWidth;
            points[5].Y = ((rectBound.Height >> 1) - (segmentWidth * 0.5f)) - segmentInterval;
            this.m_CachedPaths[1].AddPolygon(points);
            this.m_CachedPaths[1].CloseFigure();
            if (this.UseItalicStyle)
            {
                this.m_CachedPaths[1].Transform(matrix);
            }
            points[0].X = rectBound.Width - segmentWidth;
            points[0].Y = ((rectBound.Height >> 1) + segmentInterval) + (segmentWidth * 0.5f);
            points[1].X = rectBound.Width - (segmentWidth * 0.5f);
            points[1].Y = (rectBound.Height >> 1) + segmentInterval;
            points[2].X = rectBound.Width + 1;
            points[2].Y = (((rectBound.Height >> 1) + segmentInterval) + (segmentWidth * 0.5f)) + 1f;
            points[3].X = rectBound.Width + 1;
            points[3].Y = ((rectBound.Height - segmentInterval) - ((segmentWidth * bevelRate) * 2f)) - 1f;
            points[4].X = rectBound.Width - (segmentWidth * bevelRate);
            points[4].Y = (rectBound.Height - (segmentWidth * bevelRate)) - segmentInterval;
            points[5].X = rectBound.Width - segmentWidth;
            points[5].Y = (rectBound.Height - segmentWidth) - segmentInterval;
            this.m_CachedPaths[2].AddPolygon(points);
            this.m_CachedPaths[2].CloseFigure();
            if (this.UseItalicStyle)
            {
                this.m_CachedPaths[2].Transform(matrix);
            }
            points[0].X = (segmentWidth * bevelRate) + segmentInterval;
            points[0].Y = rectBound.Height - (segmentWidth * bevelRate);
            points[1].X = segmentWidth + segmentInterval;
            points[1].Y = rectBound.Height - segmentWidth;
            points[2].X = (rectBound.Width - segmentInterval) - segmentWidth;
            points[2].Y = rectBound.Height - segmentWidth;
            points[3].X = (rectBound.Width - segmentInterval) - (segmentWidth * bevelRate);
            points[3].Y = rectBound.Height - (segmentWidth * bevelRate);
            points[4].X = (rectBound.Width - segmentInterval) - ((segmentWidth * bevelRate) * 2f);
            points[4].Y = rectBound.Height;
            points[5].X = ((segmentWidth * bevelRate) * 2f) + segmentInterval;
            points[5].Y = rectBound.Height;
            this.m_CachedPaths[3].AddPolygon(points);
            this.m_CachedPaths[3].CloseFigure();
            if (this.UseItalicStyle)
            {
                this.m_CachedPaths[3].Transform(matrix);
            }
            points[0].X = 0f;
            points[0].Y = ((rectBound.Height >> 1) + segmentInterval) + (segmentWidth * 0.5f);
            points[1].X = segmentWidth * 0.5f;
            points[1].Y = (rectBound.Height >> 1) + segmentInterval;
            points[2].X = segmentWidth;
            points[2].Y = ((rectBound.Height >> 1) + segmentInterval) + (segmentWidth * 0.5f);
            points[3].X = segmentWidth;
            points[3].Y = (rectBound.Height - segmentWidth) - segmentInterval;
            points[4].X = segmentWidth * bevelRate;
            points[4].Y = (rectBound.Height - (segmentWidth * bevelRate)) - segmentInterval;
            points[5].X = 0f;
            points[5].Y = (rectBound.Height - segmentInterval) - ((segmentWidth * bevelRate) * 2f);
            this.m_CachedPaths[4].AddPolygon(points);
            this.m_CachedPaths[4].CloseFigure();
            if (this.UseItalicStyle)
            {
                this.m_CachedPaths[4].Transform(matrix);
            }
            points[0].X = 0f;
            points[0].Y = ((segmentWidth * bevelRate) * 2f) + segmentInterval;
            points[1].X = segmentWidth * bevelRate;
            points[1].Y = (segmentWidth * bevelRate) + segmentInterval;
            points[2].X = segmentWidth;
            points[2].Y = segmentWidth + segmentInterval;
            points[3].X = segmentWidth;
            points[3].Y = ((rectBound.Height >> 1) - (segmentWidth * 0.5f)) - segmentInterval;
            points[4].X = segmentWidth * 0.5f;
            points[4].Y = (rectBound.Height >> 1) - segmentInterval;
            points[5].X = 0f;
            points[5].Y = ((rectBound.Height >> 1) - (segmentWidth * 0.5f)) - segmentInterval;
            this.m_CachedPaths[5].AddPolygon(points);
            this.m_CachedPaths[5].CloseFigure();
            if (this.UseItalicStyle)
            {
                this.m_CachedPaths[5].Transform(matrix);
            }
            points[0].X = (segmentWidth * 0.5f) + segmentInterval;
            points[0].Y = rectBound.Height >> 1;
            points[1].X = segmentWidth + segmentInterval;
            points[1].Y = (rectBound.Height >> 1) - (segmentWidth * 0.5f);
            points[2].X = (rectBound.Width - segmentInterval) - segmentWidth;
            points[2].Y = (rectBound.Height >> 1) - (segmentWidth * 0.5f);
            points[3].X = (rectBound.Width - segmentInterval) - (segmentWidth * 0.5f);
            points[3].Y = rectBound.Height >> 1;
            points[4].X = (rectBound.Width - segmentInterval) - segmentWidth;
            points[4].Y = (rectBound.Height >> 1) + (segmentWidth * 0.5f);
            points[5].X = segmentWidth + segmentInterval;
            points[5].Y = (rectBound.Height >> 1) + (segmentWidth * 0.5f);
            this.m_CachedPaths[6].AddPolygon(points);
            this.m_CachedPaths[6].CloseFigure();
            if (this.UseItalicStyle)
            {
                this.m_CachedPaths[6].Transform(matrix);
            }
            tfArray2[0].X = 0f;
            tfArray2[0].Y = rectBound.Height;
            tfArray2[1].X = segmentWidth;
            tfArray2[1].Y = rectBound.Height;
            tfArray2[2].X = segmentWidth;
            tfArray2[2].Y = rectBound.Height - segmentWidth;
            tfArray2[3].X = 0f;
            tfArray2[3].Y = rectBound.Height - segmentWidth;
            this.m_CachedPaths[7].AddPolygon(tfArray2);
            this.m_CachedPaths[7].CloseFigure();
            if (this.UseItalicStyle)
            {
                this.m_CachedPaths[7].Transform(matrix);
            }
            this.m_bIsCacheBuild = true;
        }

        private void DestoryCache()
        {
            for (int i = 0; i < 8; i++)
            {
                if (this.m_CachedPaths[i] != null)
                {
                    this.m_CachedPaths[i].Dispose();
                    this.m_CachedPaths[i] = null;
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            this.DestoryCache();
            base.Dispose(disposing);
        }

        private void DrawBackground(Graphics g)
        {
            Rectangle clientRectangle = base.ClientRectangle;
            Color colBorder = this.Focused ? this.m_colFocusedBorderColor : this.m_colBorderColor;
            if (this.m_bRoundRect)
            {
                this.DrawRoundRect(g, clientRectangle, (float)this.m_nCornerRadius, this.m_colCustomBk1, this.m_colCustomBk2, colBorder, this.m_nBorderWidth, this.m_bGradientBackground, this.m_nBorderWidth != 0);
            }
            else if (!(this.m_colCustomBk1 == Color.Transparent))
            {
                this.DrawNormalRect(g, clientRectangle, this.m_colCustomBk1, this.m_colCustomBk2, colBorder, this.m_nBorderWidth, this.m_bGradientBackground, this.m_nBorderWidth != 0);
            }
        }

        private void DrawChars(Graphics g, float segmentWidth, float segmentInterval)
        {
            Rectangle clientRectangle = base.ClientRectangle;
            Rectangle rectBound = new Rectangle();
            int num = (int)(clientRectangle.Height * 0.5f);
            int height = clientRectangle.Height;
            int nCharacterNumber = this.m_nCharacterNumber;
            int num4 = (segmentInterval > 0.5) ? ((int)(segmentInterval * 2f)) : 1;
            int num5 = 0;
            if (this.m_enumAlign == Alignment.Right)
            {
                if (this.Text.Length >= nCharacterNumber)
                {
                    num5 = 0;
                }
                else
                {
                    num5 = nCharacterNumber - this.Text.Length;
                }
            }
            for (int i = 0; i < nCharacterNumber; i++)
            {
                rectBound.Width = num;
                rectBound.Height = height;
                rectBound.X = (i * rectBound.Width) + 5;
                rectBound.Y = 0;
                rectBound.Inflate(-num4, -num4);
                if (this.m_enumAlign == Alignment.Left)
                {
                    if (i < this.Text.Length)
                    {
                        this.DrawSingleCharWithFadedBk(g, rectBound, this.ForeColor, this.m_colFadedColor, this.Text[i], this.m_fBevelRate, segmentWidth, segmentInterval);
                    }
                    else
                    {
                        this.DrawSingleChar(g, rectBound, this.m_colFadedColor, '8', this.m_fBevelRate, segmentWidth, segmentInterval);
                    }
                }
                else if (i >= num5)
                {
                    this.DrawSingleCharWithFadedBk(g, rectBound, this.ForeColor, this.m_colFadedColor, this.Text[i - num5], this.m_fBevelRate, segmentWidth, segmentInterval);
                }
                else
                {
                    this.DrawSingleChar(g, rectBound, this.m_colFadedColor, '8', this.m_fBevelRate, segmentWidth, segmentInterval);
                }
            }
        }

        private void DrawHighlight(Graphics g)
        {
            if (this.m_bShowHighlight)
            {
                Rectangle clientRectangle = base.ClientRectangle;
                clientRectangle.Height = clientRectangle.Height >> 1;
                clientRectangle.Inflate(-2, -2);
                Color color = Color.FromArgb(100, 0xff, 0xff, 0xff);
                Color color2 = Color.FromArgb(this.m_nHighlightOpaque, 0xff, 0xff, 0xff);
                this.DrawRoundRect(g, clientRectangle, ((this.m_nCornerRadius - 1) > 1) ? ((float)(this.m_nCornerRadius - 1)) : ((float)1), color, color2, Color.Empty, 0, true, false);
            }
        }

        private void DrawNormalRect(Graphics g, Rectangle rect, Color col1, Color col2, Color colBorder, int nBorderWidth, bool bGradient, bool bDrawBorder)
        {
            Brush brush = null;
            if (bGradient)
            {
                brush = new LinearGradientBrush(rect, col1, col2, 90f);
                g.FillRectangle(brush, rect);
            }
            else
            {
                brush = new SolidBrush(col1);
                g.FillRectangle(brush, rect);
            }
            if (bDrawBorder)
            {
                rect.Width--;
                rect.Height--;
                Pen pen = new Pen(colBorder);
                g.DrawRectangle(pen, rect);
                pen.Dispose();
            }
            brush.Dispose();
        }

        private void DrawRoundRect(Graphics g, Rectangle rect, float radius, Color col1, Color col2, Color colBorder, int nBorderWidth, bool bGradient, bool bDrawBorder)
        {
            GraphicsPath path = new GraphicsPath();
            float width = radius + radius;
            RectangleF ef = new RectangleF(0f, 0f, width, width);
            Brush brush = null;
            ef.X = rect.Left;
            ef.Y = rect.Top;
            path.AddArc(ef, 180f, 90f);
            ef.X = (rect.Right - 1) - width;
            path.AddArc(ef, 270f, 90f);
            ef.Y = (rect.Bottom - 1) - width;
            path.AddArc(ef, 0f, 90f);
            ef.X = rect.Left;
            path.AddArc(ef, 90f, 90f);
            path.CloseFigure();
            if (bGradient)
            {
                brush = new LinearGradientBrush(rect, col1, col2, 90f, false);
            }
            else
            {
                brush = new SolidBrush(col1);
            }
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.FillPath(brush, path);
            if (bDrawBorder)
            {
                Pen pen = new Pen(colBorder);
                pen.Width = nBorderWidth;
                g.DrawPath(pen, path);
                pen.Dispose();
            }
            g.SmoothingMode = this.UseSmoothingMode ? SmoothingMode.AntiAlias : SmoothingMode.None;
            brush.Dispose();
            path.Dispose();
        }

        private void DrawSegment(Graphics g, Rectangle rectBound, Color colSegment, int nIndex, float bevelRate, float segmentWidth, float segmentInterval)
        {
            GraphicsPath path = null;
            SolidBrush brush = null;
            Matrix matrix = null;
            if (!this.m_bIsCacheBuild)
            {
                Debug.WriteLine("Rebuilding cache...");
                this.DestoryCache();
                this.CreateCache(rectBound, bevelRate, segmentWidth, segmentInterval);
            }
            path = (GraphicsPath)this.m_CachedPaths[nIndex - 1].Clone();
            matrix = new Matrix();
            matrix.Translate((float)rectBound.X, (float)rectBound.Y);
            path.Transform(matrix);
            brush = new SolidBrush(colSegment);
            g.Clip = new Region(base.ClientRectangle);
            g.FillPath(brush, path);
            brush.Dispose();
            matrix.Dispose();
            path.Dispose();
        }

        private void DrawSingleChar(Graphics g, Rectangle rectBound, Color colCharacter, char character, float bevelRate, float segmentWidth, float segmentInterval)
        {
            switch (character)
            {
                case '(':
                    this.DrawSegment(g, rectBound, colCharacter, 1, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 6, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 5, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 4, bevelRate, segmentWidth, segmentInterval);
                    break;

                case ')':
                    this.DrawSegment(g, rectBound, colCharacter, 1, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 2, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 3, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 4, bevelRate, segmentWidth, segmentInterval);
                    break;

                case '-':
                    this.DrawSegment(g, rectBound, colCharacter, 7, bevelRate, segmentWidth, segmentInterval);
                    break;

                case '.':
                    this.DrawSegment(g, rectBound, colCharacter, 8, bevelRate, segmentWidth, segmentInterval);
                    break;

                case '0':
                    this.DrawSegment(g, rectBound, colCharacter, 1, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 2, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 3, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 4, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 5, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 6, bevelRate, segmentWidth, segmentInterval);
                    break;

                case '1':
                    this.DrawSegment(g, rectBound, colCharacter, 2, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 3, bevelRate, segmentWidth, segmentInterval);
                    break;

                case '2':
                    this.DrawSegment(g, rectBound, colCharacter, 1, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 2, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 7, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 5, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 4, bevelRate, segmentWidth, segmentInterval);
                    break;

                case '3':
                    this.DrawSegment(g, rectBound, colCharacter, 1, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 2, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 7, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 3, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 4, bevelRate, segmentWidth, segmentInterval);
                    break;

                case '4':
                    this.DrawSegment(g, rectBound, colCharacter, 6, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 2, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 7, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 3, bevelRate, segmentWidth, segmentInterval);
                    break;

                case '5':
                    this.DrawSegment(g, rectBound, colCharacter, 1, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 6, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 7, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 3, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 4, bevelRate, segmentWidth, segmentInterval);
                    break;

                case '6':
                    this.DrawSegment(g, rectBound, colCharacter, 1, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 6, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 7, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 3, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 4, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 5, bevelRate, segmentWidth, segmentInterval);
                    break;

                case '7':
                    this.DrawSegment(g, rectBound, colCharacter, 1, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 2, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 3, bevelRate, segmentWidth, segmentInterval);
                    break;

                case '8':
                    this.DrawSegment(g, rectBound, colCharacter, 1, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 2, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 3, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 4, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 5, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 6, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 7, bevelRate, segmentWidth, segmentInterval);
                    break;

                case '9':
                    this.DrawSegment(g, rectBound, colCharacter, 1, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 2, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 3, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 4, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 6, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 7, bevelRate, segmentWidth, segmentInterval);
                    break;

                case 'A':
                    this.DrawSegment(g, rectBound, colCharacter, 1, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 2, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 3, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 5, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 6, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 7, bevelRate, segmentWidth, segmentInterval);
                    break;

                case 'B':
                    this.DrawSegment(g, rectBound, colCharacter, 1, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 2, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 3, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 4, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 5, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 6, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 7, bevelRate, segmentWidth, segmentInterval);
                    break;

                case 'C':
                    this.DrawSegment(g, rectBound, colCharacter, 1, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 6, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 5, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 4, bevelRate, segmentWidth, segmentInterval);
                    break;

                case 'D':
                    this.DrawSegment(g, rectBound, colCharacter, 1, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 2, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 3, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 4, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 5, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 6, bevelRate, segmentWidth, segmentInterval);
                    break;

                case 'E':
                    this.DrawSegment(g, rectBound, colCharacter, 1, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 6, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 7, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 5, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 4, bevelRate, segmentWidth, segmentInterval);
                    break;

                case 'F':
                    this.DrawSegment(g, rectBound, colCharacter, 1, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 7, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 6, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 5, bevelRate, segmentWidth, segmentInterval);
                    break;

                case 'G':
                    this.DrawSegment(g, rectBound, colCharacter, 1, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 6, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 5, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 4, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 3, bevelRate, segmentWidth, segmentInterval);
                    break;

                case 'H':
                    this.DrawSegment(g, rectBound, colCharacter, 6, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 2, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 7, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 5, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 3, bevelRate, segmentWidth, segmentInterval);
                    break;

                case 'I':
                    this.DrawSegment(g, rectBound, colCharacter, 2, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 3, bevelRate, segmentWidth, segmentInterval);
                    break;

                case 'J':
                    this.DrawSegment(g, rectBound, colCharacter, 2, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 3, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 4, bevelRate, segmentWidth, segmentInterval);
                    break;

                case 'L':
                    this.DrawSegment(g, rectBound, colCharacter, 6, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 5, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 4, bevelRate, segmentWidth, segmentInterval);
                    break;

                case 'N':
                    this.DrawSegment(g, rectBound, colCharacter, 5, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 6, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 1, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 2, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 3, bevelRate, segmentWidth, segmentInterval);
                    break;

                case 'O':
                    this.DrawSegment(g, rectBound, colCharacter, 1, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 2, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 3, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 4, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 5, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 6, bevelRate, segmentWidth, segmentInterval);
                    break;

                case 'P':
                    this.DrawSegment(g, rectBound, colCharacter, 1, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 2, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 7, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 6, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 5, bevelRate, segmentWidth, segmentInterval);
                    break;

                case 'R':
                    this.DrawSegment(g, rectBound, colCharacter, 1, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 2, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 3, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 5, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 6, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 7, bevelRate, segmentWidth, segmentInterval);
                    break;

                case 'S':
                    this.DrawSegment(g, rectBound, colCharacter, 1, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 6, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 7, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 3, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 4, bevelRate, segmentWidth, segmentInterval);
                    break;

                case 'T':
                    this.DrawSegment(g, rectBound, colCharacter, 1, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 6, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 5, bevelRate, segmentWidth, segmentInterval);
                    break;

                case 'U':
                    this.DrawSegment(g, rectBound, colCharacter, 2, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 3, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 4, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 5, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 6, bevelRate, segmentWidth, segmentInterval);
                    break;

                case 'V':
                    this.DrawSegment(g, rectBound, colCharacter, 2, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 3, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 4, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 5, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 6, bevelRate, segmentWidth, segmentInterval);
                    break;

                case 'Y':
                    this.DrawSegment(g, rectBound, colCharacter, 6, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 2, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 7, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 3, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 4, bevelRate, segmentWidth, segmentInterval);
                    break;

                case 'Z':
                    this.DrawSegment(g, rectBound, colCharacter, 1, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 2, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 7, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 5, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 4, bevelRate, segmentWidth, segmentInterval);
                    break;

                case '_':
                    this.DrawSegment(g, rectBound, colCharacter, 4, bevelRate, segmentWidth, segmentInterval);
                    break;
            }
        }

        private void DrawSingleCharWithFadedBk(Graphics g, Rectangle rectBound, Color colCharacter, Color colFaded, char character, float bevelRate, float segmentWidth, float segmentInterval)
        {
            switch (character)
            {
                case '(':
                    this.DrawSegment(g, rectBound, colFaded, 2, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colFaded, 3, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colFaded, 7, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 1, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 6, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 5, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 4, bevelRate, segmentWidth, segmentInterval);
                    return;

                case ')':
                    this.DrawSegment(g, rectBound, colFaded, 5, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colFaded, 6, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colFaded, 7, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 1, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 2, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 3, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 4, bevelRate, segmentWidth, segmentInterval);
                    return;

                case '-':
                    this.DrawSegment(g, rectBound, colFaded, 1, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colFaded, 2, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colFaded, 3, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colFaded, 4, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colFaded, 5, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colFaded, 6, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 7, bevelRate, segmentWidth, segmentInterval);
                    return;

                case '.':
                    this.DrawSegment(g, rectBound, colFaded, 1, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colFaded, 2, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colFaded, 3, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colFaded, 4, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colFaded, 5, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colFaded, 6, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colFaded, 7, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 8, bevelRate, segmentWidth, segmentInterval);
                    return;

                case '0':
                    this.DrawSegment(g, rectBound, colFaded, 7, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 1, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 2, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 3, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 4, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 5, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 6, bevelRate, segmentWidth, segmentInterval);
                    return;

                case '1':
                    this.DrawSegment(g, rectBound, colFaded, 1, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colFaded, 4, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colFaded, 5, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colFaded, 6, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colFaded, 7, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 2, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 3, bevelRate, segmentWidth, segmentInterval);
                    return;

                case '2':
                    this.DrawSegment(g, rectBound, colFaded, 3, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colFaded, 6, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 1, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 2, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 7, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 5, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 4, bevelRate, segmentWidth, segmentInterval);
                    return;

                case '3':
                    this.DrawSegment(g, rectBound, colFaded, 5, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colFaded, 6, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 1, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 2, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 7, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 3, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 4, bevelRate, segmentWidth, segmentInterval);
                    return;

                case '4':
                    this.DrawSegment(g, rectBound, colFaded, 1, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colFaded, 4, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colFaded, 5, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 6, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 2, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 7, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 3, bevelRate, segmentWidth, segmentInterval);
                    return;

                case '5':
                    this.DrawSegment(g, rectBound, colFaded, 2, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colFaded, 5, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 1, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 6, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 7, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 3, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 4, bevelRate, segmentWidth, segmentInterval);
                    return;

                case '6':
                    this.DrawSegment(g, rectBound, colFaded, 2, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 1, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 6, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 7, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 3, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 4, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 5, bevelRate, segmentWidth, segmentInterval);
                    return;

                case '7':
                    this.DrawSegment(g, rectBound, colFaded, 4, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colFaded, 5, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colFaded, 6, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colFaded, 7, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 1, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 2, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 3, bevelRate, segmentWidth, segmentInterval);
                    return;

                case '8':
                    this.DrawSegment(g, rectBound, colCharacter, 1, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 2, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 3, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 4, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 5, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 6, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 7, bevelRate, segmentWidth, segmentInterval);
                    return;

                case '9':
                    this.DrawSegment(g, rectBound, colFaded, 5, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 1, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 2, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 3, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 4, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 6, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 7, bevelRate, segmentWidth, segmentInterval);
                    return;

                case 'A':
                    this.DrawSegment(g, rectBound, colFaded, 4, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 1, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 2, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 3, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 5, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 6, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 7, bevelRate, segmentWidth, segmentInterval);
                    return;

                case 'B':
                    this.DrawSegment(g, rectBound, colCharacter, 1, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 2, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 3, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 4, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 5, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 6, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 7, bevelRate, segmentWidth, segmentInterval);
                    return;

                case 'C':
                    this.DrawSegment(g, rectBound, colFaded, 2, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colFaded, 3, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colFaded, 7, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 1, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 6, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 5, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 4, bevelRate, segmentWidth, segmentInterval);
                    return;

                case 'D':
                    this.DrawSegment(g, rectBound, colFaded, 7, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 1, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 2, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 3, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 4, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 5, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 6, bevelRate, segmentWidth, segmentInterval);
                    return;

                case 'E':
                    this.DrawSegment(g, rectBound, colFaded, 2, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colFaded, 3, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 1, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 6, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 7, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 5, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 4, bevelRate, segmentWidth, segmentInterval);
                    return;

                case 'F':
                    this.DrawSegment(g, rectBound, colFaded, 2, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colFaded, 3, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colFaded, 4, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 1, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 7, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 6, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 5, bevelRate, segmentWidth, segmentInterval);
                    return;

                case 'G':
                    this.DrawSegment(g, rectBound, colFaded, 2, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colFaded, 7, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 1, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 6, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 5, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 4, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 3, bevelRate, segmentWidth, segmentInterval);
                    return;

                case 'H':
                    this.DrawSegment(g, rectBound, colFaded, 1, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colFaded, 4, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 6, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 2, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 7, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 5, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 3, bevelRate, segmentWidth, segmentInterval);
                    return;

                case 'I':
                    this.DrawSegment(g, rectBound, colFaded, 1, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colFaded, 4, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colFaded, 5, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colFaded, 6, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colFaded, 7, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 2, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 3, bevelRate, segmentWidth, segmentInterval);
                    return;

                case 'J':
                    this.DrawSegment(g, rectBound, colFaded, 1, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colFaded, 5, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colFaded, 6, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colFaded, 7, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 2, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 3, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 4, bevelRate, segmentWidth, segmentInterval);
                    return;

                case 'L':
                    this.DrawSegment(g, rectBound, colFaded, 1, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colFaded, 2, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colFaded, 3, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colFaded, 7, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 6, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 5, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 4, bevelRate, segmentWidth, segmentInterval);
                    return;

                case 'N':
                    this.DrawSegment(g, rectBound, colFaded, 4, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colFaded, 7, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 5, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 6, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 1, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 2, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 3, bevelRate, segmentWidth, segmentInterval);
                    return;

                case 'O':
                    this.DrawSegment(g, rectBound, colFaded, 7, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 1, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 2, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 3, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 4, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 5, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 6, bevelRate, segmentWidth, segmentInterval);
                    return;

                case 'P':
                    this.DrawSegment(g, rectBound, colFaded, 3, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colFaded, 4, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 1, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 2, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 7, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 6, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 5, bevelRate, segmentWidth, segmentInterval);
                    return;

                case 'R':
                    this.DrawSegment(g, rectBound, colFaded, 4, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 1, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 2, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 3, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 5, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 6, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 7, bevelRate, segmentWidth, segmentInterval);
                    return;

                case 'S':
                    this.DrawSegment(g, rectBound, colFaded, 2, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colFaded, 5, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 1, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 6, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 7, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 3, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 4, bevelRate, segmentWidth, segmentInterval);
                    return;

                case 'T':
                    this.DrawSegment(g, rectBound, colFaded, 2, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colFaded, 3, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colFaded, 4, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colFaded, 7, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 1, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 6, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 5, bevelRate, segmentWidth, segmentInterval);
                    return;

                case 'U':
                    this.DrawSegment(g, rectBound, colFaded, 1, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colFaded, 7, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 2, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 3, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 4, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 5, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 6, bevelRate, segmentWidth, segmentInterval);
                    return;

                case 'V':
                    this.DrawSegment(g, rectBound, colFaded, 1, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colFaded, 7, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 2, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 3, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 4, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 5, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 6, bevelRate, segmentWidth, segmentInterval);
                    return;

                case 'Y':
                    this.DrawSegment(g, rectBound, colFaded, 1, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colFaded, 5, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 6, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 2, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 7, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 3, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 4, bevelRate, segmentWidth, segmentInterval);
                    return;

                case 'Z':
                    this.DrawSegment(g, rectBound, colFaded, 3, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colFaded, 6, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 1, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 2, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 7, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 5, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 4, bevelRate, segmentWidth, segmentInterval);
                    return;

                case '_':
                    this.DrawSegment(g, rectBound, colFaded, 1, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colFaded, 2, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colFaded, 3, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colFaded, 5, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colFaded, 6, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colFaded, 7, bevelRate, segmentWidth, segmentInterval);
                    this.DrawSegment(g, rectBound, colCharacter, 4, bevelRate, segmentWidth, segmentInterval);
                    return;
            }
            this.DrawSegment(g, rectBound, colFaded, 1, bevelRate, segmentWidth, segmentInterval);
            this.DrawSegment(g, rectBound, colFaded, 2, bevelRate, segmentWidth, segmentInterval);
            this.DrawSegment(g, rectBound, colFaded, 3, bevelRate, segmentWidth, segmentInterval);
            this.DrawSegment(g, rectBound, colFaded, 4, bevelRate, segmentWidth, segmentInterval);
            this.DrawSegment(g, rectBound, colFaded, 5, bevelRate, segmentWidth, segmentInterval);
            this.DrawSegment(g, rectBound, colFaded, 6, bevelRate, segmentWidth, segmentInterval);
            this.DrawSegment(g, rectBound, colFaded, 7, bevelRate, segmentWidth, segmentInterval);
        }

        private void EvClick(object sender, EventArgs e)
        {
            base.Focus();
        }

        private void EvFocus(object sender, EventArgs e)
        {
            base.Invalidate();
        }

        private void EvKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && (e.KeyCode == Keys.C))
            {
                try
                {
                    Clipboard.SetText(this.Text);
                }
                catch
                {
                }
            }
        }

        private void InitializeComponent()
        {
            base.SuspendLayout();
            base.ResumeLayout(false);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = this.UseSmoothingMode ? SmoothingMode.AntiAlias : SmoothingMode.None;
            float segmentWidth = 0f;
            float segmentInterval = 0f;
            if ((base.ClientRectangle.Height >= 20) && (base.ClientRectangle.Width >= 20))
            {
                this.DrawBackground(g);
                this.CalculateDrawingParams(out segmentWidth, out segmentInterval);
                this.DrawChars(g, segmentWidth, segmentInterval);
                this.DrawHighlight(g);
            }
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            base.OnPaintBackground(pevent);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            this.m_bIsCacheBuild = false;
            base.OnSizeChanged(e);
        }

        void ISupportInitialize.BeginInit()
        {
            this.m_bIsInitializing = true;
        }

        void ISupportInitialize.EndInit()
        {
            this.m_bIsInitializing = false;
            base.Invalidate();
        }

        [Browsable(true), Description("Set thr first custom background color"), DefaultValue(typeof(Color), "System.Drawing.Color.Black"), Category("Appearance")]
        public Color BackColor_1
        {
            get
            {
                return this.m_colCustomBk1;
            }
            set
            {
                this.m_colCustomBk1 = value;
                if (!this.m_bIsInitializing)
                {
                    base.Invalidate();
                }
            }
        }

        [DefaultValue(typeof(Color), "System.Drawing.Color.DimGray"), Description("Set thr second custom background color"), Browsable(true), Category("Appearance")]
        public Color BackColor_2
        {
            get
            {
                return this.m_colCustomBk2;
            }
            set
            {
                this.m_colCustomBk2 = value;
                if (!this.m_bIsInitializing)
                {
                    base.Invalidate();
                }
            }
        }

        [Browsable(false)]
        public override Image BackgroundImage
        {
            get
            {
                return base.BackgroundImage;
            }
            set
            {
                base.BackgroundImage = null;
            }
        }

        [Browsable(false)]
        public override ImageLayout BackgroundImageLayout
        {
            get
            {
                return base.BackgroundImageLayout;
            }
            set
            {
            }
        }

        [Browsable(true), DefaultValue((double)0.25), Category("Behavior"), Description("Set the bevel rate of each segment")]
        public float BevelRate
        {
            get
            {
                return (this.m_fBevelRate * 2f);
            }
            set
            {
                if ((value < 0f) || (value > 1f))
                {
                    throw new ArgumentException("This value should be between 0.0 and 1");
                }
                this.m_fBevelRate = value / 2f;
                if (!this.m_bIsInitializing)
                {
                    this.m_bIsCacheBuild = false;
                    base.Invalidate();
                }
            }
        }

        [Description("Set the border color"), Browsable(true), DefaultValue(typeof(Color), "Gray"), Category("Appearance")]
        public Color BorderColor
        {
            get
            {
                return this.m_colBorderColor;
            }
            set
            {
                if (!(value == this.m_colBorderColor))
                {
                    this.m_colBorderColor = value;
                    if (!this.m_bIsInitializing)
                    {
                        base.Invalidate();
                    }
                }
            }
        }

        [Browsable(true), DefaultValue(1), Category("Appearance"), Description("Set the border style")]
        public int BorderWidth
        {
            get
            {
                return this.m_nBorderWidth;
            }
            set
            {
                if (this.m_nBorderWidth != value)
                {
                    if ((value < 0) || (value > 5))
                    {
                        throw new ArgumentException("This value should be between 0 and 5");
                    }
                    this.m_nBorderWidth = value;
                    if (!this.m_bIsInitializing)
                    {
                        base.Invalidate();
                    }
                }
            }
        }

        [Browsable(true), DefaultValue(5), Category("Appearance"), Description("Set the corner radius for the background rectangle.")]
        public int CornerRadius
        {
            get
            {
                return this.m_nCornerRadius;
            }
            set
            {
                if ((value < 1) || (value > 10))
                {
                    throw new ArgumentException("This value should be between 1 and 10");
                }
                if (this.m_nCornerRadius != value)
                {
                    this.m_nCornerRadius = value;
                    if (this.m_bIsInitializing)
                    {
                        base.Invalidate();
                    }
                }
            }
        }

        [DefaultValue(typeof(Color), "System.Color.DimGray"), Description("Set the color of background characters"), Browsable(true), Category("Appearance")]
        public Color FadedColor
        {
            get
            {
                return this.m_colFadedColor;
            }
            set
            {
                if (!(this.m_colFadedColor == value))
                {
                    this.m_colFadedColor = value;
                    if (!this.m_bIsInitializing)
                    {
                        base.Invalidate();
                    }
                }
            }
        }

        [Browsable(true), Description("Set the focused border color."), DefaultValue(typeof(Color), "Cyan"), Category("Appearance")]
        public Color FocusedBorderColor
        {
            get
            {
                return this.m_colFocusedBorderColor;
            }
            set
            {
                if (!(value == this.m_colFocusedBorderColor))
                {
                    this.m_colFocusedBorderColor = value;
                    if (!this.m_bIsInitializing)
                    {
                        base.Invalidate();
                    }
                }
            }
        }

        [Browsable(false)]
        public override System.Drawing.Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
            }
        }

        [Description("Set if the background was filled in gradient colors"), DefaultValue(false), Browsable(true), Category("Appearance")]
        public bool GradientBackground
        {
            get
            {
                return this.m_bGradientBackground;
            }
            set
            {
                if (this.m_bGradientBackground != value)
                {
                    this.m_bGradientBackground = value;
                    if (!this.m_bIsInitializing)
                    {
                        base.Invalidate();
                    }
                }
            }
        }

        [Browsable(true), DefaultValue(50), Category("Appearance"), Description("Set the opaque value of the highlight")]
        public byte HighlightOpaque
        {
            get
            {
                return this.m_nHighlightOpaque;
            }
            set
            {
                if (value > 100)
                {
                    throw new ArgumentException("This value should be between 0 and 50");
                }
                if (this.m_nHighlightOpaque != value)
                {
                    this.m_nHighlightOpaque = value;
                    if (!this.m_bIsInitializing)
                    {
                        base.Invalidate();
                    }
                }
            }
        }

        [Category("Appearance"), DefaultValue(false), Browsable(true), Description("Set the background bound style")]
        public bool RoundCorner
        {
            get
            {
                return this.m_bRoundRect;
            }
            set
            {
                if (this.m_bRoundRect != value)
                {
                    this.m_bRoundRect = value;
                    if (!this.m_bIsInitializing)
                    {
                        base.Invalidate();
                    }
                }
            }
        }

        [Category("Behavior"), Browsable(true), DefaultValue(40), Description("Set segment interval ratio")]
        public int SegmentIntervalRatio
        {
            get
            {
                return (int)((this.m_fWidthIntervalRatio - 0.01f) * 1000f);
            }
            set
            {
                if ((value < 0) || (value > 100))
                {
                    throw new ArgumentException("This value should be between 0 and 100");
                }
                this.m_fWidthIntervalRatio = 0.01f + (value * 0.001f);
                if (!this.m_bIsInitializing)
                {
                    this.m_bIsCacheBuild = false;
                    base.Invalidate();
                }
            }
        }

        [Browsable(true), Category("Behavior"), Description("Set the segment width ratio"), DefaultValue(50)]
        public int SegmentWidthRatio
        {
            get
            {
                return (int)((this.m_fWidthSegWidthRatio - 0.1f) * 500f);
            }
            set
            {
                if ((value < 0) || (value > 100))
                {
                    throw new ArgumentException("This value should be between 0 and 100");
                }
                this.m_fWidthSegWidthRatio = 0.1f + (value * 0.002f);
                if (!this.m_bIsInitializing)
                {
                    this.m_bIsCacheBuild = false;
                    base.Invalidate();
                }
            }
        }

        [DefaultValue(false), Browsable(true), Category("Appearance"), Description("Set whether to show highlight area on the control")]
        public bool ShowHighlight
        {
            get
            {
                return this.m_bShowHighlight;
            }
            set
            {
                if (this.m_bShowHighlight != value)
                {
                    this.m_bShowHighlight = value;
                    if (!this.m_bIsInitializing)
                    {
                        base.Invalidate();
                    }
                }
            }
        }

        [Description("Set text of the control"), Category("Appearance"), DefaultValue("HELLO"), Browsable(true)]
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value.ToUpper();
                if (!this.m_bIsInitializing)
                {
                    base.Invalidate();
                }
            }
        }

        [Browsable(true), DefaultValue(typeof(Alignment), "Left"), Category("Appearance"), Description("Set the alignment of the text")]
        public Alignment TextAlignment
        {
            get
            {
                return this.m_enumAlign;
            }
            set
            {
                this.m_enumAlign = value;
                if (!this.m_bIsInitializing)
                {
                    base.Invalidate();
                }
            }
        }

        [Description("Set the total number of characters to display"), DefaultValue(5), Category("Behavior"), Browsable(true)]
        public int TotalCharCount
        {
            get
            {
                return this.m_nCharacterNumber;
            }
            set
            {
                if (value < 2)
                {
                    throw new ArgumentException("This value should be greater than 2.");
                }
                this.m_nCharacterNumber = value;
                if (!this.m_bIsInitializing)
                {
                    base.Invalidate();
                }
            }
        }

        [DefaultValue(false), Category("Appearance"), Browsable(true), Description("Turn on/off the italic text style.")]
        public bool UseItalicStyle
        {
            get
            {
                return this.m_italicMode;
            }
            set
            {
                if (this.m_italicMode != value)
                {
                    this.m_italicMode = value;
                    this.m_bIsCacheBuild = false;
                    if (!this.m_bIsInitializing)
                    {
                        base.Invalidate();
                    }
                }
            }
        }

        [Description("Turn on/off the smoothing mode."), DefaultValue(false), Browsable(true), Category("Appearance")]
        public bool UseSmoothingMode
        {
            get
            {
                return this.m_smoothingMode;
            }
            set
            {
                if (this.m_smoothingMode != value)
                {
                    this.m_smoothingMode = value;
                    if (!this.m_bIsInitializing)
                    {
                        base.Invalidate();
                    }
                }
            }
        }

        public enum Alignment
        {
            Left,
            Right
        }
    }
}