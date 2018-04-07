using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KeyboardPress_Analyzer.Objects;
using KeyboardPress_Analyzer.Helper;
using System.Windows.Media;

namespace KeyboardPress
{
    public partial class KeyboardUc : UserControl
    {
        private List<ObjKeyPressCount> Data;
        private Color[] heatMapColors;

        public KeyboardUc(List<ObjKeyPressCount> data)
        {
            InitializeComponent();

            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Font = new System.Drawing.Font("Tahoma", 9.25F);

            Data = data;
        }

        private void KeyboardUc_Load(object sender, EventArgs e)
        {
            try
            {
                ReloadData(Data);

                this.SizeChanged += new System.EventHandler(this.KeyboardUc_SizeChanged);
            }
            catch (Exception ex)
            {
                LogHelper.LogErrorMsg(ex);
            }
        }

        public void ReloadData(List<ObjKeyPressCount> data)
        {
            Data = data;

            uint maxCount = 0;
            Data.ForEach(x =>
            {
                if (maxCount < x.PressHoldCount)
                    maxCount = x.PressHoldCount;
            });

            foreach (var control in this.panel.Controls)
            {
                if (control is Button)
                {
                    if (((Button)control).Tag.ToString() != "")
                    {
                        var iLine = Data.FirstOrDefault(x => x.AsciiKeyCode == System.Convert.ToInt32(((Button)control).Tag.ToString()));
                        if (iLine != null)
                        {
                            // v1:
                            //int value = getColor(System.Convert.ToInt32(iLine.PressHoldCount.ToString()), maxCount);
                            //((Button)control).BackColor = Color.FromArgb(255, value, value);

                            // v2:
                            var cnt = getColor_v2(System.Convert.ToInt32(iLine.PressHoldCount.ToString()), maxCount);
                            if (cnt != null)
                                ((Button)control).BackColor = (Color)cnt;
                        }
                    }
                }
            }
        }

        private int getColor(int count, uint maxCount)
        {
            //int minValue = 50;
            //int maxValue = 210;
            //int diffColors = 10;
            int minValue = 30;
            int maxValue = 240;
            int diffColors = 20;

            int diffValue = (maxValue - minValue) / diffColors;

            var res = ((double)count / (double)maxCount) * 10 * diffValue;

            return maxValue - System.Convert.ToInt32(res);
        }
        
        private Color? getColor_v2(int count, uint maxCount)
        {
            try
            {
                if (count == 0)
                    return null;

                if (heatMapColors == null || heatMapColors.Count() < 1)
                {
                    heatMapColors = new Color[]
                    {
                    System.Drawing.ColorTranslator.FromHtml("#8d8dfc"),
                    System.Drawing.ColorTranslator.FromHtml("#8dbbfc"),
                    System.Drawing.ColorTranslator.FromHtml("#8de7fc"),
                    System.Drawing.ColorTranslator.FromHtml("#8dfce5"),
                    System.Drawing.ColorTranslator.FromHtml("#8dfcb9"),
                    System.Drawing.ColorTranslator.FromHtml("#8dfc8d"),
                    System.Drawing.ColorTranslator.FromHtml("#bbfc8d"),
                    System.Drawing.ColorTranslator.FromHtml("#e9fc8d"),
                    System.Drawing.ColorTranslator.FromHtml("#fce28d"),
                    System.Drawing.ColorTranslator.FromHtml("#ffc7a5"),
                    System.Drawing.ColorTranslator.FromHtml("#fc8d8d")
                    };
                }

                long j = maxCount / (heatMapColors.Length - 1);
                if (j == 0)
                    return heatMapColors[0];

                long i = count / j;
                if (i < 0)
                    i = 0;
                else if (i > heatMapColors.Length - 1)
                    i = heatMapColors.Length - 1;
                
                return heatMapColors[i];
            }
            catch(Exception ex)
            {
                LogHelper.LogErrorMsg(ex);
                return null;
            }
        }

        private void resize()
        {
            try
            {
                //Console.WriteLine($"{panel.Width} {panel.Height}");

                if (panel.Width == 0 || panel.Height == 0)
                {
                    Console.WriteLine("panel 0");
                    return;
                }

                decimal w = (decimal)this.Size.Width / (decimal)panel.Width;
                decimal h = (decimal)this.Size.Height / (decimal)panel.Height;

                decimal ratio = 0;
                bool useW = false;
                bool useH = false;
                
                if (System.Convert.ToInt32(Math.Floor(w * panel.Width)) <= this.Size.Width 
                    && System.Convert.ToInt32(Math.Floor(w * panel.Height)) <= this.Size.Height)
                    useW = true;

                if (System.Convert.ToInt32(Math.Floor(h * panel.Width)) <= this.Size.Width
                    && System.Convert.ToInt32(Math.Floor(h * panel.Height)) <= this.Size.Height)
                    useH = true;

                if (useH && useW)
                    ratio = h > w ? h : w;
                else if (useH)
                    ratio = h;
                else if (useW)
                    ratio = w;
                else
                    throw new Exception("Resize operation failed");

                Console.WriteLine($"ratio: {ratio}");

                if (ratio <= 0)
                    return;

                this.Scale(new SizeF()
                {
                    Height = (float)ratio,
                    Width = (float)ratio
                });

                foreach (var obj in panel.Controls)
                {
                    if (obj is Button)
                    {
                        ((Button)obj).Font = new Font(button1.Font.FontFamily.Name, button1.Font.Size * (float)ratio);
                    }
                }
            }
            catch(Exception ex)
            {
                LogHelper.LogErrorMsg(ex);
            }
        }
        
        private void KeyboardUc_SizeChanged(object sender, EventArgs e)
        {
            if (!timerResize.Enabled)
                timerResize.Enabled = true;
        }
        
        private void timerResize_Tick(object sender, EventArgs e)
        {
            resize();
            timerResize.Enabled = false;
        }
    }
    
}
