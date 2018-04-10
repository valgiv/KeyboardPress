using KeyboardPress_Analyzer.Helper;
using KeyboardPress_Analyzer.Objects;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Data;
using KeyboardPress_Analyzer;

namespace KeyboardPress
{
    public partial class UcTabScreenMouse : UcBase, IDisposable
    {
        private UcScreen uc = null;

        private DataTable dt = null;
        private DateTime dtLoadDate = DateTime.Now;

        public UcTabScreenMouse()
        {
            InitializeComponent();
        }

        protected override void UcBaceLoad()
        {
            base.UcBaceLoad();

            LoadComboBoxValues();
        }

        public override void RefreshData(bool firstLoad = false)
        {
            try
            {
                if (firstLoad)
                {
                    if (uc == null)
                        uc = new UcScreen();
                    uc.Dock = DockStyle.Fill;
                    this.panelScreen.Controls.Add(uc);

                    uc.MouseEvents = GetDataByFilter(firstLoad);// MF.Kpt.MouseEvents;
                    uc.TryRedraw();
                }
                else
                {
                    uc.MouseEvents = GetDataByFilter(firstLoad);// MF.Kpt.MouseEvents;
                    uc.TryRedraw();
                }
            }
            catch(Exception ex)
            {
                LogHelper.ShowErrorMsgWithLog("Klaida atveriant pelės paspaudimų langą", ex);
            }
        }
        
        private List<ObjEvent_mouse> GetDataByFilter(bool FirstLoad)
        {
            List<ObjEvent_mouse> result = new List<ObjEvent_mouse>();

            #region db
            if (FirstLoad || dtLoadDate < DateTime.Now.AddMinutes(-10))
            {
                string sql = $@"
SELECT record_id, CAST(event_type_id AS SMALLINT) as event_type_id, CAST(event_data_type_id AS SMALLINT) as event_data_type_id, win_id, [time], x, y, user_record_id, CAST(mouse_key_id AS SMALLINT) as mouse_key_id
FROM KP_EVENT_MOUSE
WHERE user_record_id = {DBHelper.UserId}";

                dt = DBHelper.GetDataTableDb(sql);
                dtLoadDate = DateTime.Now;

                var a = dt.Columns["mouse_key_id"].DataType;
            }

            List<ObjEvent_mouse> dbMouseEvents = new List<ObjEvent_mouse>();
            dt.AsEnumerable().ToList().ForEach(x =>
            {
                var win = DatabaseControl.GetWindowsByIds(x.Field<int>("win_id"));

                dbMouseEvents.Add(new ObjEvent_mouse()
                {
                    ActiveWindowName = win != null && win.Length > 0 ? win[0].Item2 : Helper.unknownWindowName,
                    EventTime = x.Field<DateTime>("time"),
                    EventObjDataType = (EventDataType)x.Field<Int16>("event_data_type_id"),
                    EventObjType = (EventType)x.Field<Int16>("event_type_id"),
                    SavedInDB = true,
                    X = x.Field<Int16>("x"),
                    Y = x.Field<Int16>("y"),
                    MouseKey = (MouseKeys)x.Field<Int16>("mouse_key_id")
                });
            });

            if (cbProgram.SelectedValue.ToString() != base.cbProgramAllValuesName)
                dbMouseEvents = dbMouseEvents.Where(x => x.ActiveWindowName == cbProgram.SelectedValue.ToString()).ToList();
            if (dtpFrom.Checked)
                dbMouseEvents = dbMouseEvents.Where(x => x.EventTime >= dtpFrom.Value).ToList();
            if (dtpTo.Checked)
                dbMouseEvents = dbMouseEvents.Where(x => x.EventTime <= dtpTo.Value).ToList();

            #endregion

            #region local memory

            var data = MF.Kpt.MouseEvents.Where(x => x.SavedInDB == false);

            if (cbProgram.SelectedValue.ToString() != base.cbProgramAllValuesName)
                data = data.Where(x => x.ActiveWindowName == cbProgram.SelectedValue.ToString());
            if (dtpFrom.Checked)
                data = data.Where(x => x.EventTime >= dtpFrom.Value);
            if (dtpTo.Checked)
                data = data.Where(x => x.EventTime <= dtpTo.Value);

            result.AddRange(data.ToArray());
            #endregion

            result.AddRange(dbMouseEvents.ToArray());

            return result;
        }

    }
}
