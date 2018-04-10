namespace KeyboardPress
{
    partial class UcTabScreenMouse
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
            this.panelScreen = new System.Windows.Forms.Panel();
            this.panelTop.SuspendLayout();
            this.panelCenter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRefreshSeconds)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpFrom
            // 
            this.dtpFrom.Value = new System.DateTime(2018, 4, 10, 0, 0, 0, 0);
            this.dtpFrom.ValueChanged += new System.EventHandler(this.dtp_ValueChanged);
            this.dtpFrom.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dtp_MouseDown);
            // 
            // dtpTo
            // 
            this.dtpTo.Value = new System.DateTime(2018, 4, 10, 23, 59, 59, 0);
            this.dtpTo.ValueChanged += new System.EventHandler(this.dtp_ValueChanged);
            this.dtpTo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dtp_MouseDown);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(392, 4);
            // 
            // cbProgram
            // 
            this.cbProgram.Size = new System.Drawing.Size(167, 21);
            this.cbProgram.SelectedIndexChanged += new System.EventHandler(this.cbProgram_SelectedIndexChanged);
            // 
            // panelTop
            // 
            this.panelTop.Size = new System.Drawing.Size(544, 44);
            // 
            // panelCenter
            // 
            this.panelCenter.Controls.Add(this.panelScreen);
            this.panelCenter.Location = new System.Drawing.Point(0, 44);
            this.panelCenter.Size = new System.Drawing.Size(544, 280);
            // 
            // panelScreen
            // 
            this.panelScreen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelScreen.Location = new System.Drawing.Point(26, 28);
            this.panelScreen.Name = "panelScreen";
            this.panelScreen.Size = new System.Drawing.Size(489, 226);
            this.panelScreen.TabIndex = 0;
            // 
            // UcTabScreenMouse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "UcTabScreenMouse";
            this.Size = new System.Drawing.Size(544, 324);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelCenter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRefreshSeconds)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelScreen;
    }
}
