using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using KeyboardPress_Analyzer.Helper;
using KeyboardPress_Analyzer;
using KeyboardPress_Analyzer.Objects;

namespace KeyboardPress
{
    public partial class UcTabKeyboardUsage : UcBase, IDisposable
    {
        private UcSimpleChart uc = null;

        public UcTabKeyboardUsage()
        {
            InitializeComponent();
        }

        protected override void LoadComboBoxValues()
        {
            base.LoadComboBoxValues();

            dtpFrom.ShowCheckBox = false;
        }

        protected override void RefreshData(bool firstLoad = false)
        {
            try
            {
                if (firstLoad)
                {
                    if (uc == null)
                        uc = new UcSimpleChart();
                    uc.Dock = DockStyle.Fill;
                    this.panelCenter.Controls.Add(uc);

                    uc.SetData(GetDataByFilter());
                }
                else
                {
                    uc.SetData(GetDataByFilter());
                }
            }
            catch (Exception ex)
            {
                LogHelper.ShowErrorMsgWithLog("Klaida atveriant pelės paspaudimų per valandą langą", ex);
            }
        }

        private Tuple<string, int>[] GetDataByFilter()
        {
            var dbKeysEvents = new List<ObjEvent_key>();
            #region db
            string sql = $@"
SELECT record_id, CAST(event_type_id AS SMALLINT) as event_type_id, CAST(event_data_type_id AS SMALLINT) as event_data_type_id, win_id, [time], [key], key_value, shift_press, ctrl_press, user_record_id
FROM KP_EVENT_KEY_ALL
WHERE user_record_id = {DBHelper.UserId}
    AND ([time] >= '{dtpFrom.Value.Date.ToString("yyyy-MM-dd")}' AND [time] <= '{dtpFrom.Value.Date.AddDays(1).ToString("yyyy-MM-dd")}')";

            DataTable dt = DBHelper.GetDataTableDb(sql);
            
            if(dt != null && dt.Rows.Count > 0)
            {
                dt.AsEnumerable().ToList().ForEach(x =>
                {
                    var win = DatabaseControl.GetWindowsByIds(x.Field<int>("win_id"));

                    dbKeysEvents.Add(new ObjEvent_key()
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
                    dbKeysEvents = dbKeysEvents.Where(x => x.ActiveWindowName == cbMainFilter.SelectedValue.ToString()).ToList();
            }
            #endregion

            #region local memory

            var data = MF.Kpt.KeysEvents.Where(x => x.SavedInDB == false);

            if (cbMainFilter.SelectedValue.ToString() != base.cbProgramAllValuesName)
                data = data.Where(x => x.ActiveWindowName == cbMainFilter.SelectedValue.ToString());
            if (dtpFrom.Checked)
                data = data.Where(x => x.EventTime.Date == dtpFrom.Value.Date);
            #endregion

            var all = new List<ObjEvent_key>();
            all.AddRange(dbKeysEvents);
            all.AddRange(data);

            var hours = all.Select(x => x.EventTime.Hour).ToArray();
            List<Tuple<string, int>> result = new List<Tuple<string, int>>();
            for (int i = 0; i <= 23; i++)
            {
                result.Add(new Tuple<string, int>(i.ToString(), hours.Count(x => x == i)));
            }
            
            return result.ToArray();
        }


    }
}
