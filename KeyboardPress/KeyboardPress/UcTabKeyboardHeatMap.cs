using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyboardPress
{
    public class UcTabKeyboardHeatMap : UcBase
    {
        private KeyboardUc uc = null;

        public UcTabKeyboardHeatMap()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.panelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtpFrom
            // 
            this.dtpFrom.Value = new System.DateTime(2018, 4, 7, 0, 0, 0, 0);
            // 
            // dtpTo
            // 
            this.dtpTo.Value = new System.DateTime(2018, 4, 7, 23, 59, 59, 0);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // UcTabKeyboardHeatMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Name = "UcTabKeyboardHeatMap";
            this.Load += new System.EventHandler(this.UcTabKeyboardHeatMap_Load);
            this.panelTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void UcTabKeyboardHeatMap_Load(object sender, EventArgs e)
        {
            btnRefresh_Click(null, null);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if(sender == null && e == null)
            {
                panelCenter.Controls.Clear();
                if (uc != null)
                    uc.Dispose();
                uc = null;

                uc = new KeyboardUc(MF.Kpt.KeyPressCountObjList);
                uc.Dock = System.Windows.Forms.DockStyle.Fill;

                panelCenter.Controls.Add(uc);
            }
            else
            {
                uc.ReloadData(MF.Kpt.KeyPressCountObjList);
            }
        }


    }
}
