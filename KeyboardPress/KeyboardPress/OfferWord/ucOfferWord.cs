using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KeyboardPress_Analyzer.Helper;

namespace KeyboardPress.OfferWord
{
    public partial class ucOfferWord : UserControl
    {
        private DataTable dt;
        public ucOfferWord()
        {
            InitializeComponent();
        }
        
        private void ucOfferWord_Load(object sender, EventArgs e)
        {
            try
            {
                loadData();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void loadData()
        {
            dt = DBHelper.GetDataTableDb($"SELECT record_id, value1, value2 FROM KP_OFFER_WORD WHERE user_record_id = '{DBHelper.UserId}'");
            dt.AcceptChanges();
            dataGridView.DataSource = dt;

            dataGridView.Columns["record_id"].Visible = false;
            dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView.Columns["value2"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView.Columns["value1"].HeaderText = "Reikšmė iš";
            dataGridView.Columns["value2"].HeaderText = "Reikšmė į";
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var changes = dt.GetChanges();
                if (changes == null)
                {
                    MessageBox.Show("Nėra pakeistų duomenų");
                    return;
                }

                var oneWordValidation = changes.AsEnumerable()
                    .FirstOrDefault(x => !String.IsNullOrWhiteSpace(x.Field<string>("value1"))
                        && (x.Field<string>("value1").Contains(' ') || x.Field<string>("value1").Contains('\t')));
                if(oneWordValidation != null)
                {
                    MessageBox.Show("'Reikšmė iš' gali būti sudaryta tik iš vieno žodžio", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }


                string sql = "";
                foreach (DataRow change in changes.Rows)
                {
                    if (change.RowState == DataRowState.Modified)
                    {
                        if(String.IsNullOrEmpty(change["value1"].ToString()) || String.IsNullOrEmpty(change["value2"].ToString()))
                        {
                            MessageBox.Show("Turi būti nurodytos laukų 'Reikšmė iš' ir 'Reikšmė į' reikšmės");
                            return;
                        }
                        sql += $"UPDATE KP_OFFER_WORD SET value1 = '{change["value1"].ToString().Replace("'", "''")}', value2='{change["value2"].ToString().Replace("'", "''")}' WHERE record_id = {change["record_id"].ToString()}";
                    }
                    else if (change.RowState == DataRowState.Added)
                    {
                        if (String.IsNullOrEmpty(change["value1"].ToString()) || String.IsNullOrEmpty(change["value2"].ToString()))
                        {
                            MessageBox.Show("Turi būti nurodytos laukų 'Reikšmė iš' ir 'Reikšmė į' reikšmės");
                            return;
                        }
                        sql += $"INSERT INTO KP_OFFER_WORD (value1, value2, user_record_id) VALUES ('{change["value1"].ToString().Replace("'", "''")}', '{change["value2"].ToString().Replace("'", "''")}', {DBHelper.UserId})";
                    }
                    else if (change.RowState == DataRowState.Deleted)
                    {
                        if (change["record_id", DataRowVersion.Original] == null
                        || change["record_id", DataRowVersion.Original] == DBNull.Value
                        || change["record_id", DataRowVersion.Original].ToString() == ""
                        || (int)change["record_id", DataRowVersion.Original] < 1)
                            change.AcceptChanges();
                        else
                            sql += $"DELETE FROM KP_OFFER_WORD WHERE record_id = {change["record_id", DataRowVersion.Original].ToString()}";
                    }

                    sql += "\n";
                }

                if (!String.IsNullOrEmpty(sql))
                {
                    DBHelper.ExecSqlDb(sql, true);
                    dt.AcceptChanges();
                }

                MessageBox.Show("Duomenys sėkmingai išsaugoti");
            }
            catch (Exception ex)
            {
                LogHelper.ShowErrorMsgWithLog("Klaida bandant išsaugoti pakeitimus", ex);
            }
        }

        private void btn_addLine_Click(object sender, EventArgs e)
        {
            dt.Rows.Add();

        }

        private void btn_remove_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView.SelectedRows.Count < 1)
                    throw new Exception("Nepasirinkta nei viena eilutė");
                
                dataGridView.Rows.Remove(dataGridView.SelectedRows[0]);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Klaida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        
    }
}
