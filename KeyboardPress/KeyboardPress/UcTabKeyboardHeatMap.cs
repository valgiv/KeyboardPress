using KeyboardPress_Analyzer.Helper;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace KeyboardPress
{
    public class UcTabKeyboardHeatMap : UcBase
    {
        private System.Windows.Forms.Panel panelColorMap;
        private UcKeyboard uc = null;

        public UcTabKeyboardHeatMap()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.panelColorMap = new System.Windows.Forms.Panel();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRefreshSeconds)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpFrom
            // 
            this.dtpFrom.Value = new System.DateTime(2018, 4, 7, 0, 0, 0, 0);
            this.dtpFrom.Visible = false;
            // 
            // dtpTo
            // 
            this.dtpTo.Value = new System.DateTime(2018, 4, 7, 23, 59, 59, 0);
            this.dtpTo.Visible = false;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(3, 31);
            // 
            // cbMainFilter
            // 
            this.cbMainFilter.Visible = false;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.panelColorMap);
            this.panelTop.Size = new System.Drawing.Size(582, 90);
            this.panelTop.Controls.SetChildIndex(this.btnRefresh, 0);
            this.panelTop.Controls.SetChildIndex(this.dtpTo, 0);
            this.panelTop.Controls.SetChildIndex(this.cbMainFilter, 0);
            this.panelTop.Controls.SetChildIndex(this.dtpFrom, 0);
            this.panelTop.Controls.SetChildIndex(this.numericUpDownRefreshSeconds, 0);
            this.panelTop.Controls.SetChildIndex(this.checkBoxAutoRefresh, 0);
            this.panelTop.Controls.SetChildIndex(this.panelColorMap, 0);
            // 
            // panelCenter
            // 
            this.panelCenter.Location = new System.Drawing.Point(0, 90);
            this.panelCenter.Size = new System.Drawing.Size(582, 188);
            // 
            // numericUpDownRefreshSeconds
            // 
            this.numericUpDownRefreshSeconds.Location = new System.Drawing.Point(147, 34);
            // 
            // checkBoxAutoRefresh
            // 
            this.checkBoxAutoRefresh.Location = new System.Drawing.Point(188, 36);
            // 
            // panelColorMap
            // 
            this.panelColorMap.Location = new System.Drawing.Point(3, 60);
            this.panelColorMap.Name = "panelColorMap";
            this.panelColorMap.Size = new System.Drawing.Size(337, 24);
            this.panelColorMap.TabIndex = 6;
            // 
            // UcTabKeyboardHeatMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Name = "UcTabKeyboardHeatMap";
            this.Size = new System.Drawing.Size(582, 278);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRefreshSeconds)).EndInit();
            this.ResumeLayout(false);

        }

        protected override void RefreshData(bool firstLoad = false)
        {
            try
            {
                if (firstLoad)
                {
                    loadColorMap();

                    panelCenter.Controls.Clear();
                    if (uc != null)
                        uc.Dispose();
                    uc = null;

                    uc = new UcKeyboard(MF.Kpt.KeyPressCountObjList);
                    uc.Dock = System.Windows.Forms.DockStyle.Fill;

                    panelCenter.Controls.Add(uc);
                }
                else
                {
                    uc.ReloadData(MF.Kpt.KeyPressCountObjList);
                }
            }
            catch(Exception ex)
            {

            }
        }

        private void loadColorMap()
        {
            try
            {
                var col = (new UcKeyboard(null)).HeatMapColors;

                var wdth = panelColorMap.Width / col.Length;
                
                int j = 0;
                for(int i = col.Length - 1; i>=0; i--)
                {
                    var panel = new Panel();
                    panel.Name = $"panel_{j}";
                    panel.BackColor = col[i];
                    panel.Dock = DockStyle.Left;
                    panel.Width = 30;
                    panel.Height = panelColorMap.Height;
                    panelColorMap.Controls.Add(panel);
                    
                    j++;
                }
            }
            catch(Exception ex)
            {
                LogHelper.ShowErrorMsgWithLog("Klaida užkraunant spalvų hierarchiją", ex);
            }
        }

    }
}
