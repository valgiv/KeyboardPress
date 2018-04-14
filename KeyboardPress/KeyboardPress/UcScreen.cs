using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using KeyboardPress_Analyzer.Objects;
using KeyboardPress_Analyzer.Helper;

namespace KeyboardPress
{
    public partial class UcScreen : UserControl, IDisposable
    {
        public List<ObjEvent_mouse> MouseEvents { get; set; }

        public UcScreen()
        {
            InitializeComponent();
        }

        private void ucScreen_Paint(object sender, PaintEventArgs e)
        {
            int minPix = 5;
            int drawScreenW, drawScreenH;

            #region screenLines
            var panelW = this.Size.Width - 2 * minPix;
            var panelH = this.Size.Height - 2 * minPix;
            
            var screenH = panelW * (9d / 16d);
            if(screenH < panelH)
            {
                drawScreenW = panelW;
                drawScreenH = (int)screenH;
            }
            else
            {
                drawScreenW = (int)(panelH * (16d / 9d));
                drawScreenH = panelH;
            }

            Pen blackpen = new Pen(Color.Black, 3);
            
            Graphics g = e.Graphics;
            g.DrawLine(blackpen, 0 + minPix, 0 + minPix, drawScreenW + minPix, 0 + minPix); //virsutine briauna
            g.DrawLine(blackpen, 0 + minPix, drawScreenH + minPix, drawScreenW + minPix, drawScreenH + minPix); //apatinė briauna
            g.DrawLine(blackpen, 0 + minPix, 0 + minPix, 0 + minPix, drawScreenH + minPix); //kaire
            g.DrawLine(blackpen, drawScreenW + minPix, 0 + minPix, drawScreenW + minPix, drawScreenH + minPix); //desine

            g.FillRectangle(Brushes.LightBlue, 0 + minPix, 0 + minPix, drawScreenW + 1, drawScreenH + 1);
            #endregion

            SolidBrush semiTransBrush = new SolidBrush(Color.FromArgb(25, 0, 0, 255)); //pirmas skaicius ryskumas, kiti spalvos
            var semiTransPen = new Pen(semiTransBrush, 6);

            float hRatio = ((float)drawScreenH / (float)(Helper.ScreenHeight));
            float wRatio = ((float)drawScreenW / (float)(Helper.ScreenWidth)); ;
            
            if (MouseEvents != null && MouseEvents.Count() > 0)
            {
                MouseEvents.ForEach(x =>
                {
                    if (x.X != null && x.Y != null)
                    {
                        //g.DrawEllipse(semiTransPen,
                        //    (float)(Math.Floor((decimal)(x.X * wRatio)) + minPix),
                        //    (float)(Math.Floor((decimal)(x.Y * hRatio)) + minPix),
                        //    10,
                        //    10);

                        g.FillEllipse(semiTransBrush,
                            (float)(Math.Floor((decimal)(x.X * wRatio)) + minPix - 6),
                            (float)(Math.Floor((decimal)(x.Y * hRatio)) + minPix - 6),
                            12,
                            12);
                    }
                });
            }

            //g.DrawEllipse(semiTransPen, 10, 10, 5, 5);
            //g.DrawEllipse(semiTransPen, 12, 12, 5, 5);

            g.Dispose();
        }

        public void TryRedraw()
        {
            this.Refresh();
        }
    }
}
