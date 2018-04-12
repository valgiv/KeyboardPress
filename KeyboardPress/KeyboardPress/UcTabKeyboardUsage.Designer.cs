namespace KeyboardPress
{
    partial class UcTabKeyboardUsage
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRefreshSeconds)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpFrom
            // 
            this.dtpFrom.Value = new System.DateTime(2018, 4, 12, 0, 0, 0, 0);
            // 
            // dtpTo
            // 
            this.dtpTo.Location = new System.Drawing.Point(466, 7);
            this.dtpTo.Value = new System.DateTime(2018, 4, 12, 23, 59, 59, 0);
            this.dtpTo.Visible = false;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(238, 4);
            // 
            // cbMainFilter
            // 
            this.cbMainFilter.Location = new System.Drawing.Point(111, 5);
            // 
            // panelTop
            // 
            this.panelTop.Size = new System.Drawing.Size(637, 32);
            // 
            // panelCenter
            // 
            this.panelCenter.Location = new System.Drawing.Point(0, 32);
            this.panelCenter.Size = new System.Drawing.Size(637, 254);
            // 
            // numericUpDownRefreshSeconds
            // 
            this.numericUpDownRefreshSeconds.Location = new System.Drawing.Point(372, 5);
            // 
            // checkBoxAutoRefresh
            // 
            this.checkBoxAutoRefresh.Location = new System.Drawing.Point(413, 7);
            // 
            // UcTabKeyboardUsage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "UcTabKeyboardUsage";
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRefreshSeconds)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
    }
}
