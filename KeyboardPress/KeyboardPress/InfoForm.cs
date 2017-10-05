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
    public partial class InfoForm : Form
    {
        private string[] Phrases;
        private List<Label> LabelsLst;
        private const int itemHeight = 15;
        private const float defaultFontSize = 8.25F;

        private int selectedIndex = -1;

        public InfoForm(string[] phrases)
        {
            InitializeComponent();
            this.TopMost = true;

            Phrases = phrases;
        }

        protected override bool ShowWithoutActivation
        {
            get { return true; }
        }

        public int SelectedIndex { get { return selectedIndex; } }

        public void CloseForm()
        {
            this.Close();
        }

        private void InfoForm_Load(object sender, EventArgs e)
        {
            if (Phrases == null || Phrases.Count() < 0)
                CloseForm();

            LabelsLst = new List<Label>();
            int maxWith = 0;

            foreach (string str in Phrases)
            {
                var label = new Label()
                {
                    Text = $": {str}",
                    AutoSize = true,
                    Name = $"label_{LabelsLst.Count()}",
                    TabIndex = LabelsLst.Count(),
                    Location = new System.Drawing.Point(1, 1 + (itemHeight * LabelsLst.Count()))
                };
                label.MouseClick += Label_MouseClick;

                changeFont(label, true);

                this.Controls.Add(label);
                LabelsLst.Add(label);

                if (maxWith < label.Size.Width)
                    maxWith = label.Size.Width;
            }

            for(int i = 1; i < LabelsLst.Count(); i++)
            {
                changeFont(LabelsLst[i], false);
            }
            selectedIndex = 0;

            this.Width = maxWith + 2;
            this.Height = 2 + (itemHeight * LabelsLst.Count());
        }

        private void changeFont(Label label, bool bold)
        {
            if(bold)
                label.Font = new System.Drawing.Font("Microsoft Sans Serif", defaultFontSize, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            else
                label.Font = new System.Drawing.Font("Microsoft Sans Serif", defaultFontSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
        }

        public void selectNext()
        {
            if(selectedIndex + 1 != LabelsLst.Count())
            {
                changeFont(LabelsLst[selectedIndex], false);
                changeFont(LabelsLst[selectedIndex + 1], true);
                selectedIndex++;
            }
            else
            {
                changeFont(LabelsLst[selectedIndex], false);
                changeFont(LabelsLst[0], true);
                selectedIndex = 0;
            }
        }

        public string getSelectedValue()
        {
            return LabelsLst[selectedIndex].Text;
        }

        private void Label_MouseClick(object sender, MouseEventArgs e)
        {
            InfoForm_MouseClick(sender, e);
        }

        private void InfoForm_MouseHover(object sender, EventArgs e)
        {
            //CloseForm();
        }
        
        private void InfoForm_MouseClick(object sender, MouseEventArgs e)
        {
            //CloseForm();
            selectNext();
        }
    }
}
