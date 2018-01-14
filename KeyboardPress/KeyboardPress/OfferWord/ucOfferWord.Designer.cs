namespace KeyboardPress.OfferWord
{
    partial class ucOfferWord
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
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValue1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValue2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRemoveRex = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colValue1,
            this.colValue2,
            this.colRemoveRex});
            this.dataGridView.Location = new System.Drawing.Point(3, 39);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(448, 150);
            this.dataGridView.TabIndex = 0;
            // 
            // colId
            // 
            this.colId.HeaderText = "Id";
            this.colId.Name = "colId";
            this.colId.Visible = false;
            // 
            // colValue1
            // 
            this.colValue1.HeaderText = "Reikšmė iš";
            this.colValue1.Name = "colValue1";
            // 
            // colValue2
            // 
            this.colValue2.HeaderText = "Reikšmė į";
            this.colValue2.Name = "colValue2";
            // 
            // colRemoveRex
            // 
            this.colRemoveRex.HeaderText = "Šalinti";
            this.colRemoveRex.Name = "colRemoveRex";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(4, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Išsaugoti";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // ucOfferWord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dataGridView);
            this.Name = "ucOfferWord";
            this.Size = new System.Drawing.Size(454, 301);
            this.Load += new System.EventHandler(this.ucOfferWord_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValue1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValue2;
        private System.Windows.Forms.DataGridViewButtonColumn colRemoveRex;
        private System.Windows.Forms.Button btnSave;
    }
}
