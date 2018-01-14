using KeyboardPress_Analyzer.Helper;
using KeyboardPress_Analyzer.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeyboardPress
{
    public partial class Keyboard : Form
    {
        private List<ObjKeyPressCount> Data;

        public Keyboard(List<ObjKeyPressCount> data)
        {
            InitializeComponent();

            Data = data;
        }

        private void Keyboard_Load(object sender, EventArgs e)
        {
            try
            {
                uint maxCount = 0;
                Data.ForEach(x =>
                {
                    if (maxCount < x.PressHoldCount)
                        maxCount = x.PressHoldCount;
                });

                foreach (var control in this.Controls)
                {
                    if (control is Button)
                    {
                        if (((Button)control).Tag.ToString() != "")
                        {
                            var iLine = Data.FirstOrDefault(x => x.AsciiKeyCode == System.Convert.ToInt32(((Button)control).Tag.ToString()));
                            if (iLine != null)
                            {
                                int value = getColor(System.Convert.ToInt32(iLine.PressHoldCount.ToString()), maxCount);
                                ((Button)control).BackColor = Color.FromArgb(255, value, value);
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                LogHelper.LogErrorMsg(ex);
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

    }
}
