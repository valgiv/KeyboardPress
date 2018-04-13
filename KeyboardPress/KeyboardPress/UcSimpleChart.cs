using System;
using System.Windows.Forms;

namespace KeyboardPress
{
    public partial class UcSimpleChart : UserControl
    {
        public UcSimpleChart()
        {
            InitializeComponent();
        }

        private void ucMouseUsageByHours_Load(object sender, EventArgs e)
        {

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
