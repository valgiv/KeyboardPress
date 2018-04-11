namespace KeyboardPress
{
    partial class UcTabMouseUsage
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
            this.cbMouseType = new System.Windows.Forms.ComboBox();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRefreshSeconds)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpFrom
            // 
            this.dtpFrom.Size = new System.Drawing.Size(121, 20);
            this.dtpFrom.Value = new System.DateTime(2018, 4, 11, 0, 0, 0, 0);
            // 
            // dtpTo
            // 
            this.dtpTo.Location = new System.Drawing.Point(410, 33);
            this.dtpTo.Value = new System.DateTime(2018, 4, 11, 23, 59, 59, 0);
            this.dtpTo.Visible = false;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(129, 3);
            // 
            // cbMainFilter
            // 
            this.cbMainFilter.Location = new System.Drawing.Point(3, 27);
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.cbMouseType);
            this.panelTop.Size = new System.Drawing.Size(689, 59);
            this.panelTop.Controls.SetChildIndex(this.btnRefresh, 0);
            this.panelTop.Controls.SetChildIndex(this.dtpTo, 0);
            this.panelTop.Controls.SetChildIndex(this.cbMainFilter, 0);
            this.panelTop.Controls.SetChildIndex(this.dtpFrom, 0);
            this.panelTop.Controls.SetChildIndex(this.numericUpDownRefreshSeconds, 0);
            this.panelTop.Controls.SetChildIndex(this.checkBoxAutoRefresh, 0);
            this.panelTop.Controls.SetChildIndex(this.cbMouseType, 0);
            // 
            // panelCenter
            // 
            this.panelCenter.Location = new System.Drawing.Point(0, 59);
            this.panelCenter.Size = new System.Drawing.Size(689, 293);
            // 
            // numericUpDownRefreshSeconds
            // 
            this.numericUpDownRefreshSeconds.Location = new System.Drawing.Point(264, 5);
            // 
            // checkBoxAutoRefresh
            // 
            this.checkBoxAutoRefresh.Location = new System.Drawing.Point(305, 7);
            // 
            // cbMouseType
            // 
            this.cbMouseType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMouseType.FormattingEnabled = true;
            this.cbMouseType.Location = new System.Drawing.Point(130, 27);
            this.cbMouseType.Name = "cbMouseType";
            this.cbMouseType.Size = new System.Drawing.Size(128, 21);
            this.cbMouseType.TabIndex = 6;
            // 
            // UcTabMouseUsage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "UcTabMouseUsage";
            this.Size = new System.Drawing.Size(689, 352);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRefreshSeconds)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbMouseType;
    }
}
