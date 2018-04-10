namespace KeyboardPress
{
    partial class UcBase
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
            this.components = new System.ComponentModel.Container();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.cbProgram = new System.Windows.Forms.ComboBox();
            this.panelTop = new System.Windows.Forms.Panel();
            this.checkBoxAutoRefresh = new System.Windows.Forms.CheckBox();
            this.numericUpDownRefreshSeconds = new System.Windows.Forms.NumericUpDown();
            this.panelCenter = new System.Windows.Forms.Panel();
            this.timerRefresh = new System.Windows.Forms.Timer(this.components);
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRefreshSeconds)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpFrom
            // 
            this.dtpFrom.CustomFormat = "yyyy-MM-dd";
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.Location = new System.Drawing.Point(3, 5);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.ShowCheckBox = true;
            this.dtpFrom.Size = new System.Drawing.Size(102, 20);
            this.dtpFrom.TabIndex = 0;
            // 
            // dtpTo
            // 
            this.dtpTo.CustomFormat = "yyyy-MM-dd";
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTo.Location = new System.Drawing.Point(111, 5);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.ShowCheckBox = true;
            this.dtpTo.Size = new System.Drawing.Size(102, 20);
            this.dtpTo.TabIndex = 1;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(346, 3);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(129, 23);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Atnaujinti duomenis";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // cbProgram
            // 
            this.cbProgram.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProgram.FormattingEnabled = true;
            this.cbProgram.Location = new System.Drawing.Point(219, 5);
            this.cbProgram.Name = "cbProgram";
            this.cbProgram.Size = new System.Drawing.Size(121, 21);
            this.cbProgram.TabIndex = 3;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.checkBoxAutoRefresh);
            this.panelTop.Controls.Add(this.numericUpDownRefreshSeconds);
            this.panelTop.Controls.Add(this.dtpFrom);
            this.panelTop.Controls.Add(this.cbProgram);
            this.panelTop.Controls.Add(this.dtpTo);
            this.panelTop.Controls.Add(this.btnRefresh);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(637, 30);
            this.panelTop.TabIndex = 4;
            // 
            // checkBoxAutoRefresh
            // 
            this.checkBoxAutoRefresh.AutoSize = true;
            this.checkBoxAutoRefresh.Location = new System.Drawing.Point(587, 7);
            this.checkBoxAutoRefresh.Name = "checkBoxAutoRefresh";
            this.checkBoxAutoRefresh.Size = new System.Drawing.Size(47, 17);
            this.checkBoxAutoRefresh.TabIndex = 5;
            this.checkBoxAutoRefresh.Text = "auto";
            this.checkBoxAutoRefresh.UseVisualStyleBackColor = true;
            this.checkBoxAutoRefresh.Click += new System.EventHandler(this.checkBoxAutoRefresh_Click);
            // 
            // numericUpDownRefreshSeconds
            // 
            this.numericUpDownRefreshSeconds.Location = new System.Drawing.Point(546, 5);
            this.numericUpDownRefreshSeconds.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numericUpDownRefreshSeconds.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownRefreshSeconds.Name = "numericUpDownRefreshSeconds";
            this.numericUpDownRefreshSeconds.Size = new System.Drawing.Size(35, 20);
            this.numericUpDownRefreshSeconds.TabIndex = 4;
            this.numericUpDownRefreshSeconds.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // panelCenter
            // 
            this.panelCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCenter.Location = new System.Drawing.Point(0, 30);
            this.panelCenter.Name = "panelCenter";
            this.panelCenter.Size = new System.Drawing.Size(637, 256);
            this.panelCenter.TabIndex = 5;
            // 
            // timerRefresh
            // 
            this.timerRefresh.Tick += new System.EventHandler(this.timerRefresh_Tick);
            // 
            // UcBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelCenter);
            this.Controls.Add(this.panelTop);
            this.Name = "UcBase";
            this.Size = new System.Drawing.Size(637, 286);
            this.Load += new System.EventHandler(this.UcBase_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRefreshSeconds)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.DateTimePicker dtpFrom;
        protected System.Windows.Forms.DateTimePicker dtpTo;
        protected System.Windows.Forms.Button btnRefresh;
        protected System.Windows.Forms.ComboBox cbProgram;
        protected System.Windows.Forms.Panel panelTop;
        protected System.Windows.Forms.Panel panelCenter;
        protected System.Windows.Forms.NumericUpDown numericUpDownRefreshSeconds;
        protected System.Windows.Forms.CheckBox checkBoxAutoRefresh;
        private System.Windows.Forms.Timer timerRefresh;
    }
}
