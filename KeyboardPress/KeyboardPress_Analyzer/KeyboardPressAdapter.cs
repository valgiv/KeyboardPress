using Gma.System.MouseKeyHook;
using KeyboardPress_Analyzer.Helper;
using KeyboardPress_Analyzer.Objects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;


namespace KeyboardPress_Analyzer
{
    public class KeyboardPressAdapter : IKeyboardPressAdapter, IDatabase
    {
        /// <summary>
        /// Pelės mygtukų paspaudimai /sukuriau vieta db saugojimui KP_EVENT_MOUSE
        /// </summary>
        private List<ObjEvent_mouse> mouseEvents;

        /// <summary>
        /// visi klaviatūros mygtukų paspaudimai
        /// KP_EVENT_KEY_ALL
        /// </summary>
        private List<ObjEvent_key> keysEvents;

        /// <summary>
        /// klaviatūros mygtukų paspaudimų junginiai (gauti REZULTATAI) darantis įtaką rašomam tekstui
        /// KP_EVENT_KEY_ALL
        /// </summary>
        private List<ObjEvent_key> keysCharsEvents;

        /// <summary>
        /// Paspaudimų dažnumui skaičiuoti
        /// KP_KEY_PRESS_COUNT
        /// </summary>
        private List<ObjKeyPressCount> keyPressCountObjList;
        
        private IKeyboardMouseEvents m_GlobalHook;
        private Stopwatch stopWach;

        #region constructors
        public KeyboardPressAdapter()
        {
            keysEvents = new List<ObjEvent_key>();
            keysCharsEvents = new List<ObjEvent_key>();
            mouseEvents = new List<ObjEvent_mouse>();
            keyPressCountObjList = new List<ObjKeyPressCount>();

            stopWach = new Stopwatch();
        }
        #endregion constructors

        #region auto-properties (get-set)
        /// <summary>
        /// visi klaviatūros mygtukų paspaudimai
        /// </summary>
        public List<ObjEvent_key> KeysEvents
        {
            get
            {
                if (keysEvents == null)
                    keysEvents = new List<ObjEvent_key>();
                return keysEvents;
            }

            set
            {
                keysEvents = value;
            }
        }

        /// <summary>
        /// klaviatūros mygtukų paspaudimų junginiai (gauti REZULTATAI) darantis įtaką rašomam tekstui
        /// </summary>
        public List<ObjEvent_key> KeysCharsEvents
        {
            get
            {
                if (keysCharsEvents == null)
                    keysCharsEvents = new List<ObjEvent_key>();
                return keysCharsEvents;
            }

            set
            {
                keysCharsEvents = value;
            }
        }

        /// <summary>
        /// Pelės mygtukų paspaudimai
        /// </summary>
        public List<ObjEvent_mouse> MouseEvents
        {
            get
            {
                if (mouseEvents == null)
                    mouseEvents = new List<ObjEvent_mouse>();
                return mouseEvents;
            }

            set
            {
                mouseEvents = value;
            }
        }
        
        public Stopwatch StopWach
        {
            get { return stopWach; }
        }

        public List<ObjKeyPressCount> KeyPressCountObjList
        {
            get
            {
                return keyPressCountObjList;
            }
            set
            {
                keyPressCountObjList = value;
            }
        }

        #endregion auto-properties(get-set)

        #region IKeyboardPressTracking

        public virtual void CleanData()
        {
            if (keysEvents != null)
                keysEvents.Clear();

            if (keysCharsEvents != null)
                keysCharsEvents.Clear();

            if (mouseEvents != null)
                mouseEvents.Clear();
        }

        public virtual void StopHookWork()
        {
            if (m_GlobalHook == null)
                return;

            m_GlobalHook.KeyDown -= GlobalHookKeyDown;
            m_GlobalHook.KeyUp -= GlobalHookKeyUp;
            m_GlobalHook.KeyPress -= GlobalHookKeyPress;

            m_GlobalHook.MouseDown -= GlobalHookMouseDown;
            m_GlobalHook.MouseWheel -= GlobalHook_MouseWheel;

            m_GlobalHook.Dispose();

            stopWach.Stop();
        }

        public virtual void StartHookWork()
        {
            if (m_GlobalHook == null)
                m_GlobalHook = Hook.GlobalEvents();

            m_GlobalHook.KeyDown += GlobalHookKeyDown;
            m_GlobalHook.KeyPress += GlobalHookKeyPress;
            m_GlobalHook.KeyUp += GlobalHookKeyUp;

            m_GlobalHook.MouseDown += GlobalHookMouseDown;
            m_GlobalHook.MouseWheel += GlobalHook_MouseWheel;

            stopWach.Start();
        }

        #endregion IKeyboardPressTracking

        #region GlobalHook_Mouse

        protected virtual void GlobalHook_MouseWheel(object sender, MouseEventArgs e)
        {

        }

        protected virtual void GlobalHookMouseDown(object sender, MouseEventArgs e)
        {

        }

        #endregion GlobalHook_Mouse

        /// <summary>
        /// simbolių gavimui
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void GlobalHookKeyPress(object sender, KeyPressEventArgs e)
        {
            var newRec = new ObjEvent_key()
            {
                ActiveWindowName = Helper.Helper.GetActiveWindowTitle_v2(),
                EventObjType = EventType.KeyPress,
                KeyValue = (int)e.KeyChar,
                Key = e.KeyChar.ToString(),
                EventObjDataType = EventDataType.SymbolAsciiCode
            };

            Add_ObjEvent_key(newRec);


            DebugHelper.AddInfoMsg(newRec.EventTime, $"{newRec.Key.ToString()} {newRec.KeyValue.ToString()} [{newRec.ActiveWindowName}]");
        }
        
        protected void Add_ObjEvent_key(ObjEvent_key newRec)
        {
            try
            {
                keysCharsEvents.Add(newRec);
            }
            catch (OutOfMemoryException oomEx)
            {
                LogHelper.LogErrorMsg(oomEx);
                LogHelper.LogInfoMsg($"BANDOMA PAŠALINTI DALĮ ELEMENTŲ IŠ {nameof(keysCharsEvents)}");
                DebugHelper.AddInfoMsg($"BANDOMA PAŠALINTI DALĮ ELEMENTŲ IŠ {nameof(keysCharsEvents)}");
                var deletedItems = new List<ObjEvent_key>();
                Helper.Helper.DeleteFromBegin(ref keysCharsEvents, 100, ref deletedItems);
                keysCharsEvents.Add(newRec);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected virtual void GlobalHookKeyUp(object sender, KeyEventArgs e)
        {
            var rec = keyPressCountObjList.FirstOrDefault(x => x.AsciiKeyCode == e.KeyValue);
            if (rec != null)
            {
                rec.PressReleaseCount++;
            }
            else
            {
                var newRec = new ObjKeyPressCount(e.KeyValue);
                newRec.PressReleaseCount++;
                keyPressCountObjList.Add(newRec);
            }
        }

        protected virtual void GlobalHookKeyDown(object sender, KeyEventArgs e)
        {
            var newRec = new ObjEvent_key()
            {
                Key = e.KeyData.ToString(),
                EventObjType = EventType.KeyDown,
                ActiveWindowName = Helper.Helper.GetActiveWindowTitle_v2(),
                KeyValue = e.KeyValue,
                EventObjDataType = EventDataType.KeyboardButtonCode
            };
            try
            {
                keysEvents.Add(newRec);
            }
            catch (OutOfMemoryException oomEx)
            {
                LogHelper.LogErrorMsg(oomEx);
                LogHelper.LogInfoMsg($"BANDOMA PAŠALINTI DALĮ ELEMENTŲ IŠ {nameof(keysEvents)}");
                DebugHelper.AddInfoMsg($"BANDOMA PAŠALINTI DALĮ ELEMENTŲ IŠ {nameof(keysEvents)}");
                var deletedItems = new List<ObjEvent_key>();
                Helper.Helper.DeleteFromBegin(ref keysEvents, 100, ref deletedItems);
                keysEvents.Add(newRec);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
            var rec = keyPressCountObjList.FirstOrDefault(x => x.AsciiKeyCode == e.KeyValue);
            if (rec != null)
                rec.PressHoldCount++;
            else
                keyPressCountObjList.Add(new ObjKeyPressCount(e.KeyValue));

            DebugHelper.AddInfoMsg(newRec.EventTime, $"{newRec.Key.ToString()} {newRec.KeyValue.ToString()} [{newRec.ActiveWindowName}]");
        }

        public void Db_SaveChanges()
        {
            try
            {
                #region KP_EVENT_MOUSE
                if (mouseEvents.Count(x=>x.SavedInDB == false) > 0)
                {
                    string sql_KP_EVENT_MOUSE = "INSERT INTO KP_EVENT_MOUSE (event_type_id, event_data_type_id, win_id, time, x, y, user_record_id) VALUES";
                    mouseEvents.Where(x => x.SavedInDB == false).ToList().ForEach(x =>
                    {
                        sql_KP_EVENT_MOUSE += $@"
({(int)x.EventObjType}, {(int)x.EventObjDataType}, null, '{x.EventTime}', {(x.X != null ? x.X.ToString() : "null")}, {(x.Y != null ? x.Y.ToString() : "null")}, {DBHelper.UserId}),";
                    }); //to do: win_id
                    sql_KP_EVENT_MOUSE = sql_KP_EVENT_MOUSE.Remove(sql_KP_EVENT_MOUSE.Length - 1, 1);
                    var result_KP_EVENT_MOUSE = DBHelper.ExecSqlDb(sql_KP_EVENT_MOUSE, true);
                    if (result_KP_EVENT_MOUSE != "OK")
                        throw new Exception($"Failled {nameof(KeyboardPressAdapter)}.{nameof(Db_SaveChanges)} {result_KP_EVENT_MOUSE} (sql: {sql_KP_EVENT_MOUSE})");

                    mouseEvents.Where(x => x.SavedInDB == false).ToList().ForEach(x => x.SavedInDB = true);
                }
                #endregion KP_EVENT_MOUSE

                #region KP_EVENT_KEY_ALL
                if (keysEvents.Count(x => x.SavedInDB == false) > 0)
                {
                    string sql_KP_EVENT_KEY_ALL = "INSERT INTO KP_EVENT_KEY_ALL (event_type_id, event_data_type_id, win_id, time, key, key_value, shift_press, ctrl_press, user_record_id) VALUES";
                    keysEvents.Where(x => x.SavedInDB == false).ToList().ForEach(x =>
                    {
                        sql_KP_EVENT_KEY_ALL += $@"
({(int)x.EventObjType}, {(int)x.EventObjDataType}, null, '{x.EventTime}', '{x.Key}', {x.KeyValue}, {(x.ShiftKeyPressed != null ? ((bool)x.ShiftKeyPressed ? "1" : "0") : "null")}, {(x.CtrlKeyPressed != null ? ((bool)x.CtrlKeyPressed ? "1" : "0") : "null")}, {DBHelper.UserId}),";//to do: win_id
                    });
                    sql_KP_EVENT_KEY_ALL = sql_KP_EVENT_KEY_ALL.Remove(sql_KP_EVENT_KEY_ALL.Length - 1, 1);
                    var result_KP_EVENT_KEY_ALL = DBHelper.ExecSqlDb(sql_KP_EVENT_KEY_ALL, true);
                    if(result_KP_EVENT_KEY_ALL != "OK")
                        throw new Exception($"Failled {nameof(KeyboardPressAdapter)}.{nameof(Db_SaveChanges)} {result_KP_EVENT_KEY_ALL} (sql: {sql_KP_EVENT_KEY_ALL})");

                    keysEvents.Where(x => x.SavedInDB == false).ToList().ForEach(x => x.SavedInDB = true);
                }
                #endregion KP_EVENT_KEY_ALL

                #region KP_EVENT_KEY_CHAR
                if (keysCharsEvents.Count(x => x.SavedInDB == false) > 0)
                {
                    string sql_KP_EVENT_KEY_CHAR = "INSERT INTO KP_EVENT_KEY_CHAR (event_type_id, event_data_type_id, win_id, time, key, key_value, shift_press, ctrl_press, user_record_id) VALUES";
                    keysCharsEvents.Where(x => x.SavedInDB == false).ToList().ForEach(x =>
                    {
                        sql_KP_EVENT_KEY_CHAR += $@"
({(int)x.EventObjType}, {(int)x.EventObjDataType}, null, '{x.EventTime}', '{x.Key}', {x.KeyValue}, {(x.ShiftKeyPressed != null ? ((bool)x.ShiftKeyPressed ? "1" : "0") : "null")}, {(x.CtrlKeyPressed != null ? ((bool)x.CtrlKeyPressed ? "1" : "0") : "null")}, {DBHelper.UserId}),";//to do: win_id
                    });
                    sql_KP_EVENT_KEY_CHAR = sql_KP_EVENT_KEY_CHAR.Remove(sql_KP_EVENT_KEY_CHAR.Length - 1, 1);
                    var result_KP_EVENT_KEY_CHAR = DBHelper.ExecSqlDb(sql_KP_EVENT_KEY_CHAR, true);
                    if (result_KP_EVENT_KEY_CHAR != "OK")
                        throw new Exception($"Failled {nameof(KeyboardPressAdapter)}.{nameof(Db_SaveChanges)} {result_KP_EVENT_KEY_CHAR} (sql: {sql_KP_EVENT_KEY_CHAR})");

                    keysCharsEvents.Where(x => x.SavedInDB == false).ToList().ForEach(x => x.SavedInDB = true);
                }
                #endregion KP_EVENT_KEY_CHAR

                #region keyPressCountObjList - KP_KEYPRESS_COUNT

                string sql = "";
                keyPressCountObjList.ForEach(x =>
                {
                    sql += $@"
UPDATE KP_KEY_PRESS_COUNT
    SET press_hold_count = {x.PressHoldCount}, press_release_count = {x.PressReleaseCount}
WHERE ascii_code = {x.AsciiKeyCode} AND user_record_id = {DBHelper.UserId}
IF @@ROWCOUNT = 0
    INSERT INTO KP_KEY_PRESS_COUNT (ascii_code, press_hold_count, press_release_count, user_record_id)
        VALUES ({x.AsciiKeyCode}, {x.PressHoldCount}, {x.PressReleaseCount}, {DBHelper.UserId})";
                });
                var result = DBHelper.ExecSqlDb(sql, true);
                if (result != "OK")
                    throw new Exception($"Failled {nameof(KeyboardPressAdapter)}.{nameof(Db_SaveChanges)} {result} (sql: {sql})");
                
                #endregion keyPressCountObjList - KP_KEYPRESS_COUNT
            }
            catch (Exception ex)
            {
                LogHelper.LogErrorMsg(ex);
                throw;
            }
        }

        public void Db_LoadData()
        {
            try
            {
                mouseEvents = new List<ObjEvent_mouse>();
                keysEvents = new List<ObjEvent_key>();
                keysCharsEvents = new List<ObjEvent_key>();
                keyPressCountObjList = new List<ObjKeyPressCount>();

                string sql = $@"
SELECT record_id, event_type_id, event_data_type_id, win_id, time, key, key_value, shift_press, ctrl_press, user_record_id FROM KP_EVENT_KEY_ALL WHERE user_record_id = {DBHelper.UserId}
SELECT record_id, event_type_id, event_data_type_id, win_id, time, key, key_value, shift_press, ctrl_press, user_record_id FROM KP_EVENT_KEY_CHAR WHERE user_record_id = {DBHelper.UserId}
SELECT record_id, event_type_id, event_data_type_id, win_id, time, x, y, user_record_id FROM KP_EVENT_MOUSE WHERE user_record_id = {DBHelper.UserId}
SELECT record_id, ascii_code, press_hold_count, press_release_count, user_record_id FROM KP_KEYPRESS_COUNT WHERE user_record_id = {DBHelper.UserId}";

                var ds = DBHelper.GetDataSetDb(sql);

                if (ds == null || ds.Tables.Count != 4)
                    throw new Exception($"Failled {nameof(KeyboardPressAdapter)}.{nameof(Db_LoadData)} data load (sql: {sql})");

                if(ds.Tables[0].Rows.Count > 0)
                {
                    //KP_EVENT_KEY_ALL
                    //keysEvents
                    ds.Tables[0].AsEnumerable().ToList().ForEach(x =>
                    {
                        keysEvents.Add(new ObjEvent_key()
                        {
                            ActiveWindowName = "", //to do
                            CtrlKeyPressed = x.Field<bool?>("ctrl_press").HasValue ? x.Field<bool?>("ctrl_press").Value : (bool?)null,
                            ShiftKeyPressed = x.Field<bool?>("shift_press").HasValue ? x.Field<bool?>("shift_press").Value : (bool?)null,
                            EventTime = x.Field<DateTime>("time"),
                            SavedInDB = true,
                            EventObjDataType = (EventDataType)x.Field<int>("event_data_type_id"),
                            EventObjType = (EventType)x.Field<int>("event_type_id"),
                            Key = x.Field<string>("key"),
                            KeyValue = x.Field<int>("key_value")
                        });
                    });
                }

                if (ds.Tables[1].Rows.Count > 0)
                {
                    //KP_EVENT_KEY_CHAR
                    //keysCharsEvents
                    ds.Tables[1].AsEnumerable().ToList().ForEach(x =>
                    {
                        keysCharsEvents.Add(new ObjEvent_key()
                        {
                            ActiveWindowName = "", //to do
                            CtrlKeyPressed = x.Field<bool?>("ctrl_press").HasValue ? x.Field<bool?>("ctrl_press").Value : (bool?)null,
                            ShiftKeyPressed = x.Field<bool?>("shift_press").HasValue ? x.Field<bool?>("shift_press").Value : (bool?)null,
                            EventTime = x.Field<DateTime>("time"),
                            SavedInDB = true,
                            EventObjDataType = (EventDataType)x.Field<int>("event_data_type_id"),
                            EventObjType = (EventType)x.Field<int>("event_type_id"),
                            Key = x.Field<string>("key"),
                            KeyValue = x.Field<int>("key_value")
                        });
                    });
                }

                if (ds.Tables[2].Rows.Count > 0)
                {
                    //KP_EVENT_MOUSE
                    ds.Tables[2].AsEnumerable().ToList().ForEach(x =>
                    {
                        mouseEvents.Add(new ObjEvent_mouse()
                        {
                            ActiveWindowName = "",//to do
                            EventTime = x.Field<DateTime>("time"),
                            EventObjDataType = (EventDataType)x.Field<int>("event_data_type_id"),
                            EventObjType = (EventType)x.Field<int>("event_type_id"),
                            SavedInDB = true,
                            X = x.Field<int>("x"),
                            Y = x.Field<int>("y")
                        });
                    });
                }

                if (ds.Tables[3].Rows.Count > 0)
                {
                    //KP_KEYPRESS_COUNT
                    ds.Tables[3].AsEnumerable().ToList().ForEach(x =>
                    {
                        keyPressCountObjList.Add(new ObjKeyPressCount()
                        {
                            AsciiKeyCode = x.Field<int>("ascii_code"),
                            PressHoldCount = x.Field<uint>("press_hold_count"),
                            PressReleaseCount = x.Field<uint>("press_release_count")
                        });
                    });
                }
            }
            catch(Exception ex)
            {
                LogHelper.LogErrorMsg(ex);
                throw;
            }
        }

        public void Db_DeleteDataFromDatabase()
        {
            try
            {
                string sql = $@"
DELETE FROM KP_EVENT_KEY_ALL WHERE user_record_id = {DBHelper.UserId}
DELETE FROM KP_EVENT_KEY_CHAR WHERE user_record_id = {DBHelper.UserId}
DELETE FROM KP_EVENT_MOUSE WHERE user_record_id = {DBHelper.UserId}
DELETE FROM KP_KEYPRESS_COUNT WHERE user_record_id = {DBHelper.UserId}";

                var result = DBHelper.ExecSqlDb(sql, true);
                if (result != "OK")
                    throw new Exception($"Failled {nameof(KeyboardPressAdapter)}.{nameof(Db_DeleteDataFromDatabase)} {result} (sql: {sql})");
            }
            catch (Exception ex)
            {
                LogHelper.LogErrorMsg(ex);
                throw;
            }
        }

        public void Db_DeleteDataFromLocalMemory()
        {
            try
            {
                mouseEvents = new List<ObjEvent_mouse>();
                keysEvents = new List<ObjEvent_key>();
                keysCharsEvents = new List<ObjEvent_key>();
                keyPressCountObjList = new List<ObjKeyPressCount>();
            }
            catch (Exception ex)
            {
                LogHelper.LogErrorMsg(ex);
                throw;
            }
        }

    }
}
