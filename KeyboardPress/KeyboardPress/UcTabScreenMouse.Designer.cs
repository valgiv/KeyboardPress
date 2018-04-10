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
            this.SuspendLayout();
            // 
            // dtpFrom
            // 
            this.dtpFrom.Value = new System.DateTime(2018, 4, 10, 0, 0, 0, 0);
            // 
            // dtpTo
            // 
            this.dtpTo.Value = new System.DateTime(2018, 4, 10, 23, 59, 59, 0);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
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
            this.Load += new System.EventHandler(this.UcTabScreenMouse_Load);
            this.panelTop.ResumeLayout(false);
            this.panelCenter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelScreen;
    }
}
