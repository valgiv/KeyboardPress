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
            this.cbMouseKeyType = new System.Windows.Forms.ComboBox();
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
            this.dtpTo.Location = new System.Drawing.Point(3, 31);
            this.dtpTo.Value = new System.DateTime(2018, 4, 10, 23, 59, 59, 0);
            this.dtpTo.ValueChanged += new System.EventHandler(this.dtp_ValueChanged);
            this.dtpTo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dtp_MouseDown);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(284, 4);
            // 
            // cbProgram
            // 
            this.cbMainFilter.Location = new System.Drawing.Point(111, 5);
            this.cbMainFilter.Size = new System.Drawing.Size(167, 21);
            this.cbMainFilter.SelectedIndexChanged += new System.EventHandler(this.cbProgram_SelectedIndexChanged);
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.cbMouseKeyType);
            this.panelTop.Size = new System.Drawing.Size(665, 60);
            this.panelTop.Controls.SetChildIndex(this.btnRefresh, 0);
            this.panelTop.Controls.SetChildIndex(this.dtpTo, 0);
            this.panelTop.Controls.SetChildIndex(this.cbMainFilter, 0);
            this.panelTop.Controls.SetChildIndex(this.dtpFrom, 0);
            this.panelTop.Controls.SetChildIndex(this.numericUpDownRefreshSeconds, 0);
            this.panelTop.Controls.SetChildIndex(this.checkBoxAutoRefresh, 0);
            this.panelTop.Controls.SetChildIndex(this.cbMouseKeyType, 0);
            // 
            // panelCenter
            // 
            this.panelCenter.Controls.Add(this.panelScreen);
            this.panelCenter.Location = new System.Drawing.Point(0, 60);
            this.panelCenter.Size = new System.Drawing.Size(665, 264);
            // 
            // numericUpDownRefreshSeconds
            // 
            this.numericUpDownRefreshSeconds.Location = new System.Drawing.Point(419, 5);
            // 
            // checkBoxAutoRefresh
            // 
            this.checkBoxAutoRefresh.Location = new System.Drawing.Point(460, 7);
            // 
            // panelScreen
            // 
            this.panelScreen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelScreen.Location = new System.Drawing.Point(26, 28);
            this.panelScreen.Name = "panelScreen";
            this.panelScreen.Size = new System.Drawing.Size(610, 210);
            this.panelScreen.TabIndex = 0;
            // 
            // cbMouseKeyType
            // 
            this.cbMouseKeyType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMouseKeyType.FormattingEnabled = true;
            this.cbMouseKeyType.Location = new System.Drawing.Point(111, 32);
            this.cbMouseKeyType.Name = "cbMouseKeyType";
            this.cbMouseKeyType.Size = new System.Drawing.Size(167, 21);
            this.cbMouseKeyType.TabIndex = 6;
            this.cbMouseKeyType.SelectedIndexChanged += new System.EventHandler(this.cbProgram_SelectedIndexChanged);
            // 
            // UcTabScreenMouse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "UcTabScreenMouse";
            this.Size = new System.Drawing.Size(665, 324);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelCenter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRefreshSeconds)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelScreen;
        private System.Windows.Forms.ComboBox cbMouseKeyType;
    }
}
