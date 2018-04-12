using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeyboardPress
{
    public partial class ucMouseUsageByHours : UserControl
    {
        public ucMouseUsageByHours()
        {
            InitializeComponent();
        }

        private void ucMouseUsageByHours_Load(object sender, EventArgs e)
        {
            //chart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            //chart.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
            //chart.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            //chart.ChartAreas[0].AxisY.MinorGrid.Enabled = false;
        }

        public void SetData(Tuple<string, int>[] data)
        {
            chart.Series[0].Points.Clear();

            foreach(var d in data)
            {
                chart.Series[0].Points.AddXY(d.Item1, d.Item2);
            }
        }
    }
}
