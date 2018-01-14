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
        DataTable dt;
        public ucOfferWord()
        {
            InitializeComponent();
        }

        private void ucOfferWord_Load(object sender, EventArgs e)
        {
            try
            {
                loadData();
                loadStructure();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void loadStructure()
        {
            dataGridView.DataSource = dt;
            colValue1.DataPropertyName = "value1";
            colValue2.DataPropertyName = "value2";
            colId.DataPropertyName = "record_id";
        }

        private void loadData()
        {
            dt = DBHelper.GetDataTableDb($"SELECT record_id, value1, value2 FROM KP_OFFER_WORD WHERE user_guid_id = '{DBHelper.UserId}'");
        }

        private void saveChanges()
        {
            try
            {
                var changes = dt.GetChanges();
                if (changes == null)
                {
                    MessageBox.Show("Nėra pakeistų duomenų");
                }

                string sql = "";
                foreach(var change in changes.Rows)
                {

                }

                if (!String.IsNullOrEmpty(sql))
                {
                    DBHelper.ExecSqlDb(sql, true);
                    dt.AcceptChanges();
                }
                
                MessageBox.Show("Duomenys sėkmingai išsaugoti");
            }
            catch(Exception ex)
            {
                LogHelper.ShowErrorMsgWithLog("Klaida bandant išsaugoti pakeitimus", ex);
            }
        }
    }
}
