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

namespace KeyboardPress
{
    public partial class UcTabMistakes : UcBase
    {
        public UcTabMistakes()
        {
            InitializeComponent();
        }

        protected override void RefreshData(bool firstLoad = false)
        {
            try
            {
                var data = MF.Kpt.MistakesChar.Where(x => x.EventTime >= dtpFrom.Value && x.EventTime <= dtpTo.Value);

                var dataForLast24H = MF.Kpt.MistakesChar.Where(x => x.EventTime >= DateTime.Now.AddDays(-1));

                if (cbMainFilter.SelectedValue.ToString() != base.cbProgramAllValuesName)
                {
                    data = data.Where(x => x.ActiveWindowName == cbMainFilter.SelectedValue.ToString());
                    dataForLast24H = dataForLast24H.Where(x => x.ActiveWindowName == cbMainFilter.SelectedValue.ToString());
                }

                var DataTableResult = new DataTable();
                DataTableResult.Columns.Add(new DataColumn("before_delete", typeof(string)));
                DataTableResult.Columns.Add(new DataColumn("deleted_char", typeof(string)));
                DataTableResult.Columns.Add(new DataColumn("new_char", typeof(string)));
                DataTableResult.Columns.Add(new DataColumn("count", typeof(int)));
                DataTableResult.Columns.Add(new DataColumn("count_in_last_2h", typeof(int)));
                DataTableResult.Columns.Add(new DataColumn("count_in_last_4h", typeof(int)));
                DataTableResult.Columns.Add(new DataColumn("count_in_last_8h", typeof(int)));
                DataTableResult.Columns.Add(new DataColumn("count_in_last_16h", typeof(int)));
                DataTableResult.Columns.Add(new DataColumn("count_in_last_24h", typeof(int)));

                foreach (var obj in data.ToArray())
                {
                    DataRow dr = DataTableResult.AsEnumerable().FirstOrDefault(x =>
                        ((x.Field<string>("before_delete") != null ? x.Field<string>("before_delete") : null) == (obj.BeforeRemovedChar == null ? null : obj.BeforeRemovedChar.ToString()))
                        && (x.Field<string>("deleted_char") == obj.RemovedChar.ToString())
                        && ((x.Field<string>("new_char") != null ? x.Field<string>("new_char") : null) == (obj.BeforeRemovedChar == null ? null : obj.BeforeRemovedChar.ToString())));
                    
                    if(dr == null)
                    {
                        dr = DataTableResult.NewRow();
                        dr["before_delete"] = obj.BeforeRemovedChar == null ? null : obj.BeforeRemovedChar.ToString();
                        dr["deleted_char"] = obj.RemovedChar.ToString();
                        dr["new_char"] = obj.ChangedChar == null ? null : obj.ChangedChar.ToString();
                        dr["count"] = 1;
                        dr["count_in_last_2h"] = dataForLast24H.Count(x=>x.EventTime >= DateTime.Now.AddHours(-2));
                        dr["count_in_last_4h"] = dataForLast24H.Count(x => x.EventTime >= DateTime.Now.AddHours(-4));
                        dr["count_in_last_8h"] = dataForLast24H.Count(x => x.EventTime >= DateTime.Now.AddHours(-8));
                        dr["count_in_last_16h"] = dataForLast24H.Count(x => x.EventTime >= DateTime.Now.AddHours(-16));
                        dr["count_in_last_24h"] = dataForLast24H.Count(x => x.EventTime >= DateTime.Now.AddHours(-24));

                        DataTableResult.Rows.Add(dr);
                    }
                    else
                    {
                        dr["count"] = (int)dr["count"] + 1;
                    }
                }

                dataGridView.DataSource = DataTableResult; //to do: sukurti datagrid'ą
            }
            catch(Exception ex)
            {
                LogHelper.ShowErrorMsgWithLog("Klaida apdorojant klaidų duomenis", ex);
            }
        }

    }
}
