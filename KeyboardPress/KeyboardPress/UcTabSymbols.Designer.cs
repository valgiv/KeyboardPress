namespace KeyboardPress
{
    partial class UcTabSymbols
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.col_symbol_char = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_symbol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_symbol_count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_time_before_sum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_time_before_count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_time_before_avg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_time_after_sum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_time_after_count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_time_after_avg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_mistakes_count = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.panelTop.Size = new System.Drawing.Size(680, 30);
            // 
            // panelCenter
            // 
            this.panelCenter.Controls.Add(this.dataGridView);
            this.panelCenter.Size = new System.Drawing.Size(680, 274);
            // 
            // numericUpDownRefreshSeconds
            // 
            this.numericUpDownRefreshSeconds.Visible = false;
            // 
            // checkBoxAutoRefresh
            // 
            this.checkBoxAutoRefresh.Visible = false;
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_symbol_char,
            this.col_symbol,
            this.col_symbol_count,
            this.col_time_before_sum,
            this.col_time_before_count,
            this.col_time_before_avg,
            this.col_time_after_sum,
            this.col_time_after_count,
            this.col_time_after_avg,
            this.col_mistakes_count});
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(0, 0);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.Size = new System.Drawing.Size(680, 274);
            this.dataGridView.TabIndex = 0;
            // 
            // col_symbol_char
            // 
            this.col_symbol_char.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_symbol_char.DataPropertyName = "symbol";
            this.col_symbol_char.HeaderText = "col_symbol_char";
            this.col_symbol_char.Name = "col_symbol_char";
            this.col_symbol_char.ReadOnly = true;
            this.col_symbol_char.Visible = false;
            // 
            // col_symbol
            // 
            this.col_symbol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_symbol.DataPropertyName = "symbol_show";
            this.col_symbol.HeaderText = "Simbolis";
            this.col_symbol.Name = "col_symbol";
            this.col_symbol.ReadOnly = true;
            // 
            // col_symbol_count
            // 
            this.col_symbol_count.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_symbol_count.DataPropertyName = "symbol_count";
            this.col_symbol_count.HeaderText = "Simbolis panaudotas";
            this.col_symbol_count.Name = "col_symbol_count";
            this.col_symbol_count.ReadOnly = true;
            // 
            // col_time_before_sum
            // 
            this.col_time_before_sum.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_time_before_sum.DataPropertyName = "time_before_sum";
            this.col_time_before_sum.HeaderText = "col_time_before_sum";
            this.col_time_before_sum.Name = "col_time_before_sum";
            this.col_time_before_sum.ReadOnly = true;
            this.col_time_before_sum.Visible = false;
            // 
            // col_time_before_count
            // 
            this.col_time_before_count.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_time_before_count.DataPropertyName = "time_before_count";
            this.col_time_before_count.HeaderText = "col_time_before_count";
            this.col_time_before_count.Name = "col_time_before_count";
            this.col_time_before_count.ReadOnly = true;
            this.col_time_before_count.Visible = false;
            // 
            // col_time_before_avg
            // 
            this.col_time_before_avg.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_time_before_avg.DataPropertyName = "time_before_avg";
            dataGridViewCellStyle1.Format = "N4";
            dataGridViewCellStyle1.NullValue = null;
            this.col_time_before_avg.DefaultCellStyle = dataGridViewCellStyle1;
            this.col_time_before_avg.HeaderText = "Vid. laikas (s) prieš simolio paspaudimą (po paspaudimo)";
            this.col_time_before_avg.Name = "col_time_before_avg";
            this.col_time_before_avg.ReadOnly = true;
            // 
            // col_time_after_sum
            // 
            this.col_time_after_sum.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_time_after_sum.DataPropertyName = "time_after_sum";
            this.col_time_after_sum.HeaderText = "col_time_after_sum";
            this.col_time_after_sum.Name = "col_time_after_sum";
            this.col_time_after_sum.ReadOnly = true;
            this.col_time_after_sum.Visible = false;
            // 
            // col_time_after_count
            // 
            this.col_time_after_count.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_time_after_count.DataPropertyName = "time_after_count";
            this.col_time_after_count.HeaderText = "col_time_after_count";
            this.col_time_after_count.Name = "col_time_after_count";
            this.col_time_after_count.ReadOnly = true;
            this.col_time_after_count.Visible = false;
            // 
            // col_time_after_avg
            // 
            this.col_time_after_avg.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_time_after_avg.DataPropertyName = "time_after_avg";
            dataGridViewCellStyle2.Format = "N4";
            dataGridViewCellStyle2.NullValue = null;
            this.col_time_after_avg.DefaultCellStyle = dataGridViewCellStyle2;
            this.col_time_after_avg.HeaderText = "Vid. laikas (s) po simbolio paspaudimo (prieš paspaudžiant kitą simbolį)";
            this.col_time_after_avg.Name = "col_time_after_avg";
            this.col_time_after_avg.ReadOnly = true;
            // 
            // col_mistakes_count
            // 
            this.col_mistakes_count.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_mistakes_count.DataPropertyName = "mistakes_count";
            this.col_mistakes_count.HeaderText = "Klaidingai panaudotas";
            this.col_mistakes_count.Name = "col_mistakes_count";
            this.col_mistakes_count.ReadOnly = true;
            // 
            // UcTabSymbols
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "UcTabSymbols";
            this.Size = new System.Drawing.Size(680, 304);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelCenter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRefreshSeconds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_symbol_char;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_symbol;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_symbol_count;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_time_before_sum;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_time_before_count;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_time_before_avg;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_time_after_sum;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_time_after_count;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_time_after_avg;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_mistakes_count;
    }
}
