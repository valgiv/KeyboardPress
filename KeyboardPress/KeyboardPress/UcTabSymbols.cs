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
using KeyboardPress_Analyzer;
using KeyboardPress_Analyzer.Objects;

namespace KeyboardPress
{
    public partial class UcTabSymbols : UcBase
    {
        public UcTabSymbols()
        {
            InitializeComponent();
        }

        protected override void LoadComboBoxValues()
        {
            dtpFrom.ShowCheckBox = false;
            dtpTo.ShowCheckBox = false;

            base.LoadComboBoxValues();
        }

        protected override void RefreshData(bool firstLoad = false)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                int maxKeyPressDiffMiliseconds = 2000;

                var dbKeyCharEvents = new List<ObjEvent_key>();
                #region db memory
                string sql = $@"
SELECT record_id, CAST(event_type_id AS SMALLINT) as event_type_id, CAST(event_data_type_id AS SMALLINT) as event_data_type_id, win_id, [time], [key], key_value, shift_press, ctrl_press, user_record_id
FROM KP_EVENT_KEY_CHAR
WHERE user_record_id = {DBHelper.UserId}
    AND ([time] >= '{dtpFrom.Value.Date.ToString("yyyy-MM-dd")}' AND [time] <= '{dtpTo.Value.Date.AddDays(1).ToString("yyyy-MM-dd")}')
";
                var db_dt = DBHelper.GetDataTableDb(sql);

                if(db_dt != null && db_dt.Rows.Count > 0)
                {
                    
                    db_dt.AsEnumerable().ToList().ForEach(x =>
                    {
                        var win = DatabaseControl.GetWindowsByIds((int)x.Field<Int64>("record_id"));
                        dbKeyCharEvents.Add(new ObjEvent_key()
                        {
                            ActiveWindowName = win != null && win.Length > 0 ? win[0].Item2 : Helper.unknownWindowName,
                            CtrlKeyPressed = x.Field<bool?>("ctrl_press").HasValue ? x.Field<bool?>("ctrl_press").Value : (bool?)null,
                            ShiftKeyPressed = x.Field<bool?>("shift_press").HasValue ? x.Field<bool?>("shift_press").Value : (bool?)null,
                            EventTime = x.Field<DateTime>("time"),
                            SavedInDB = true,
                            EventObjDataType = (EventDataType)x.Field<Int64>("event_data_type_id"),
                            EventObjType = (EventType)x.Field<Int64>("event_type_id"),
                            Key = x.Field<string>("key"),
                            KeyValue = x.Field<Int16>("key_value")
                        });
                    });

                    if (cbMainFilter.SelectedValue.ToString() != base.cbProgramAllValuesName)
                        dbKeyCharEvents = dbKeyCharEvents.Where(x => x.ActiveWindowName == cbMainFilter.SelectedValue.ToString()).ToList();
                }
                #endregion

                #region local memory
                var data = MF.Kpt.KeysCharsEvents.Where(x => x.SavedInDB == false && x.EventTime.Date >= dtpFrom.Value.Date && x.EventTime <= dtpTo.Value.Date.AddDays(1) && x.EventObjDataType == EventDataType.SymbolAsciiCode);

                if (cbMainFilter.SelectedValue.ToString() != base.cbProgramAllValuesName)
                    data = data.Where(x => x.ActiveWindowName == cbMainFilter.SelectedValue.ToString());
                #endregion

                dbKeyCharEvents.AddRange(data.ToArray());
                dbKeyCharEvents = dbKeyCharEvents.OrderBy(x => x.EventTime).ToList(); // gal ir nereikia? (ir taip turbūt pagal datą yra)
                
                var DataTableResult = new DataTable();
                DataTableResult.Columns.Add(new DataColumn("symbol", typeof(char)));
                DataTableResult.Columns.Add(new DataColumn("symbol_show", typeof(string)));
                DataTableResult.Columns.Add(new DataColumn("symbol_count", typeof(int)));
                DataTableResult.Columns.Add(new DataColumn("time_before_sum", typeof(TimeSpan)));
                DataTableResult.Columns.Add(new DataColumn("time_before_count", typeof(int)));
                DataTableResult.Columns.Add(new DataColumn("time_before_avg", typeof(double)));
                DataTableResult.Columns.Add(new DataColumn("time_after_sum", typeof(TimeSpan)));
                DataTableResult.Columns.Add(new DataColumn("time_after_count", typeof(int)));
                DataTableResult.Columns.Add(new DataColumn("time_after_avg", typeof(double)));
                DataTableResult.Columns.Add(new DataColumn("mistakes_count", typeof(int)));

                int totalRec = dbKeyCharEvents.Count - 1;
                for (int i = 0; i <= totalRec; i++)
                {
                    try
                    {
                        var obj = dbKeyCharEvents[i];
                        DataRow dr = null;
                        dr = DataTableResult.AsEnumerable().FirstOrDefault(x => x.Field<char>("symbol") == obj.Key[0]);
                        if (dr == null)
                        {
                            dr = DataTableResult.NewRow();
                            dr["symbol"] = obj.Key[0];
                            dr["symbol_show"] = $"'{obj.Key[0]}'";
                            dr["symbol_count"] = 0;
                            dr["time_before_sum"] = new TimeSpan(0, 0, 0, 0, 0);
                            dr["time_before_count"] = 0;
                            dr["time_after_sum"] = new TimeSpan(0, 0, 0, 0, 0);
                            dr["time_after_count"] = 0;
                            var mistakesCounting = MF.Kpt.MistakesChar.Where(x => x.EventTime.Date >= dtpFrom.Value.Date
                                && x.EventTime.Date <= dtpTo.Value.Date.AddDays(1)
                                && x.RemovedChar == obj.Key[0]);
                            if (cbMainFilter.SelectedValue.ToString() != base.cbProgramAllValuesName)
                                mistakesCounting = mistakesCounting.Where(x => x.ActiveWindowName == cbMainFilter.SelectedValue.ToString());
                            dr["mistakes_count"] = mistakesCounting.Count();
                            DataTableResult.Rows.Add(dr);
                        }
                        dr["symbol_count"] = (int)dr["symbol_count"] + 1;

                        #region prev symbol
                        ObjEvent_key prev = null;
                        if (i != 0)
                            prev = dbKeyCharEvents[i - 1];
                        if (prev != null)
                        {
                            if (prev.ActiveWindowName == obj.ActiveWindowName)
                            {
                                TimeSpan dif = obj.EventTime - prev.EventTime;
                                if (dif.TotalMilliseconds <= maxKeyPressDiffMiliseconds)
                                {
                                    dr["time_before_count"] = (int)dr["time_before_count"] + 1;
                                    dr["time_before_sum"] = (TimeSpan)dr["time_before_sum"] + dif;
                                }
                            }
                        }
                        #endregion
                        #region next symbol
                        ObjEvent_key next = null;
                        if (i != totalRec)
                            next = dbKeyCharEvents[i + 1];
                        if (next != null)
                        {
                            if (next.ActiveWindowName == obj.ActiveWindowName)
                            {
                                TimeSpan dif = next.EventTime - obj.EventTime;
                                if (dif.TotalMilliseconds <= maxKeyPressDiffMiliseconds)
                                {
                                    dr["time_after_count"] = (int)dr["time_after_count"] + 1;
                                    dr["time_after_sum"] = (TimeSpan)dr["time_after_sum"] + dif;
                                }
                            }
                        }
                        #endregion
                    }
                    catch (Exception ex)
                    {

                    }
                }

                foreach(DataRow row in DataTableResult.Rows)
                {
                    row["time_after_avg"] = (((TimeSpan)row["time_after_sum"]).TotalSeconds / ((int)row["time_after_count"] > 0 ? (int)row["time_after_count"] : 1));
                    row["time_before_avg"] = (((TimeSpan)row["time_before_sum"]).TotalSeconds / ((int)row["time_before_count"] > 0 ? (int)row["time_before_count"] : 1));
                }

                var dw = DataTableResult.DefaultView;
                dw.Sort = "symbol_count desc, symbol asc";
                DataTableResult = dw.ToTable();

                this.dataGridView.DataSource = DataTableResult;

            }
            catch (Exception ex)
            {
                LogHelper.ShowErrorMsgWithLog("Klaida apdorojant simbolių duomenis", ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
    }
}
