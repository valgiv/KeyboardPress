namespace KeyboardPress
{
    partial class UcTabMistakes
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
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.col_deleted_char = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_before_deleted = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.con_new_char = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_count_in_last2h = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_count_in_last_4h = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_count_in_last_8h = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_count_in_last_16h = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_count_in_last_24_h = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelTop.SuspendLayout();
            this.panelCenter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRefreshSeconds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpFrom
            // 
            this.dtpFrom.Value = new System.DateTime(2018, 4, 12, 0, 0, 0, 0);
            // 
            // dtpTo
            // 
            this.dtpTo.Value = new System.DateTime(2018, 4, 12, 23, 59, 59, 0);
            // 
            // panelTop
            // 
            this.panelTop.Size = new System.Drawing.Size(475, 30);
            // 
            // panelCenter
            // 
            this.panelCenter.Controls.Add(this.dataGridView);
            this.panelCenter.Size = new System.Drawing.Size(475, 255);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_deleted_char,
            this.col_before_deleted,
            this.con_new_char,
            this.col_count,
            this.col_count_in_last2h,
            this.col_count_in_last_4h,
            this.col_count_in_last_8h,
            this.col_count_in_last_16h,
            this.col_count_in_last_24_h});
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(0, 0);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.Size = new System.Drawing.Size(475, 255);
            this.dataGridView.TabIndex = 0;
            // 
            // col_deleted_char
            // 
            this.col_deleted_char.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_deleted_char.DataPropertyName = "deleted_char";
            this.col_deleted_char.HeaderText = "Pašalintas simbolis";
            this.col_deleted_char.Name = "col_deleted_char";
            this.col_deleted_char.ReadOnly = true;
            // 
            // col_before_deleted
            // 
            this.col_before_deleted.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_before_deleted.DataPropertyName = "before_delete";
            this.col_before_deleted.HeaderText = "Simbolis prieš pašalintąjį";
            this.col_before_deleted.Name = "col_before_deleted";
            this.col_before_deleted.ReadOnly = true;
            // 
            // con_new_char
            // 
            this.con_new_char.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.con_new_char.DataPropertyName = "new_char";
            this.con_new_char.HeaderText = "Simbolis į kurį pakeista";
            this.con_new_char.Name = "con_new_char";
            this.con_new_char.ReadOnly = true;
            // 
            // col_count
            // 
            this.col_count.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_count.DataPropertyName = "count";
            this.col_count.HeaderText = "Viso pasikartojimų";
            this.col_count.Name = "col_count";
            this.col_count.ReadOnly = true;
            // 
            // col_count_in_last2h
            // 
            this.col_count_in_last2h.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_count_in_last2h.DataPropertyName = "count_in_last_2h";
            this.col_count_in_last2h.HeaderText = "Pasikartojimų per paskutines 2 valandas";
            this.col_count_in_last2h.Name = "col_count_in_last2h";
            this.col_count_in_last2h.ReadOnly = true;
            // 
            // col_count_in_last_4h
            // 
            this.col_count_in_last_4h.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_count_in_last_4h.DataPropertyName = "count_in_last_4h";
            this.col_count_in_last_4h.HeaderText = "Pasikartojimų per paskutines 4 valandas";
            this.col_count_in_last_4h.Name = "col_count_in_last_4h";
            this.col_count_in_last_4h.ReadOnly = true;
            // 
            // col_count_in_last_8h
            // 
            this.col_count_in_last_8h.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_count_in_last_8h.DataPropertyName = "count_in_last_8h";
            this.col_count_in_last_8h.HeaderText = "Pasikartojimų per paskutines 8 valandas";
            this.col_count_in_last_8h.Name = "col_count_in_last_8h";
            this.col_count_in_last_8h.ReadOnly = true;
            // 
            // col_count_in_last_16h
            // 
            this.col_count_in_last_16h.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_count_in_last_16h.DataPropertyName = "count_in_last_16h";
            this.col_count_in_last_16h.HeaderText = "Pasikartojimų per paskutines 16 valanų";
            this.col_count_in_last_16h.Name = "col_count_in_last_16h";
            this.col_count_in_last_16h.ReadOnly = true;
            // 
            // col_count_in_last_24_h
            // 
            this.col_count_in_last_24_h.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_count_in_last_24_h.DataPropertyName = "count_in_last_24h";
            this.col_count_in_last_24_h.HeaderText = "Pasikartojimų per paskutines 24 valanas";
            this.col_count_in_last_24_h.Name = "col_count_in_last_24_h";
            this.col_count_in_last_24_h.ReadOnly = true;
            // 
            // UcTabMistakes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "UcTabMistakes";
            this.Size = new System.Drawing.Size(475, 285);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelCenter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRefreshSeconds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_deleted_char;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_before_deleted;
        private System.Windows.Forms.DataGridViewTextBoxColumn con_new_char;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_count;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_count_in_last2h;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_count_in_last_4h;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_count_in_last_8h;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_count_in_last_16h;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_count_in_last_24_h;
    }
}
