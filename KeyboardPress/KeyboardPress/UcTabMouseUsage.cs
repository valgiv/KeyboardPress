using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using KeyboardPress_Analyzer.Helper;
using KeyboardPress_Analyzer.Objects;
using KeyboardPress_Analyzer;

namespace KeyboardPress
{
    public partial class UcTabMouseUsage : UcBase, IDisposable
    {
        private UcSimpleChart uc = null;

        public UcTabMouseUsage()
        {
            InitializeComponent();
        }

        protected override void LoadComboBoxValues()
        {
            base.LoadComboBoxValues();

            dtpFrom.ShowCheckBox = false;

            cbMouseType.Items.AddRange(new string[] { "Visi klavišai", "Kairysis klavišas", "Dešinysis klavišas" });
            cbMouseType.SelectedIndex = 0;
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
            catch(Exception ex)
            {
                LogHelper.ShowErrorMsgWithLog("Klaida atveriant pelės paspaudimų per valandą langą", ex);
            }
        }

        private Tuple<string, int>[] GetDataByFilter()
        {
            
            #region db
            
            string sql = $@"
SELECT record_id, CAST(event_type_id AS SMALLINT) as event_type_id, CAST(event_data_type_id AS SMALLINT) as event_data_type_id, win_id, [time], x, y, user_record_id, CAST(mouse_key_id AS SMALLINT) as mouse_key_id
FROM KP_EVENT_MOUSE
WHERE user_record_id = {DBHelper.UserId};";

            DataTable dt = DBHelper.GetDataTableDb(sql);
            
            List<ObjEvent_mouse> dbMouseEvents = new List<ObjEvent_mouse>();
            dt.AsEnumerable().ToList().ForEach(x =>
            {
                Tuple<int, string>[] win = DatabaseControl.GetWindowsByIds(x.Field<int>("win_id"));

                dbMouseEvents.Add(new ObjEvent_mouse()
                {
                    ActiveWindowName = win != null && win.Length > 0 ? win[0].Item2 : Helper.unknownWindowName,
                    EventTime = x.Field<DateTime>("time"),
                    EventObjDataType = (EventDataType)x.Field<Int64>("event_data_type_id"),
                    EventObjType = (EventType)x.Field<Int64>("event_type_id"),
                    SavedInDB = true,
                    X = x.Field<Int16>("x"),
                    Y = x.Field<Int16>("y"),
                    MouseKey = (MouseKeys)x.Field<Int64>("mouse_key_id")
                });
            });

            if (cbMainFilter.SelectedValue.ToString() != base.cbProgramAllValuesName)
                dbMouseEvents = dbMouseEvents.Where(x => x.ActiveWindowName == cbMainFilter.SelectedValue.ToString()).ToList();
            dbMouseEvents = dbMouseEvents.Where(x => x.EventTime.Date == dtpFrom.Value.Date).ToList();
            if (cbMouseType.SelectedIndex == 1) //kairysis
                dbMouseEvents = dbMouseEvents.Where(x => x.MouseKey == MouseKeys.Left).ToList();
            else if (cbMouseType.SelectedIndex == 2) //dešinysis
                dbMouseEvents = dbMouseEvents.Where(x => x.MouseKey == MouseKeys.Right).ToList();

            #endregion

            #region local memory

            var data = MF.Kpt.MouseEvents.Where(x => x.SavedInDB == false);

            if (cbMainFilter.SelectedValue.ToString() != base.cbProgramAllValuesName)
                data = data.Where(x => x.ActiveWindowName == cbMainFilter.SelectedValue.ToString());
            if (dtpFrom.Checked)
                data = data.Where(x => x.EventTime.Date == dtpFrom.Value.Date);
            if (cbMouseType.SelectedIndex == 1) //kairysis
                data = data.Where(x => x.MouseKey == MouseKeys.Left);
            else if (cbMouseType.SelectedIndex == 2) //dešinysis
                data = data.Where(x => x.MouseKey == MouseKeys.Right);

            #endregion

            List<ObjEvent_mouse> all = new List<ObjEvent_mouse>();
            all.AddRange(dbMouseEvents);
            all.AddRange(data);

            var hours = all.Select(x => x.EventTime.Hour).ToArray();
            List<Tuple<string, int>> result = new List<Tuple<string, int>>();
            for(int i = 0; i<=23; i++)
            {
                result.Add(new Tuple<string, int>(i.ToString(), hours.Count(x => x == i)));
            }


            return result.ToArray();
        }

    }
}
