using Gma.System.MouseKeyHook;
using KeyboardPress_Analyzer.Helper;
using KeyboardPress_Analyzer.Objects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;


namespace KeyboardPress_Analyzer
{
    // nice to have: ar klaseje netruksta lock'o?

    public class KeyboardPressAdapter : IKeyboardPressAdapter, IDatabase
    {
        /// <summary>
        /// Pelės mygtukų paspaudimai /sukuriau vieta db saugojimui KP_EVENT_MOUSE
        /// </summary>
        protected List<ObjEvent_mouse> mouseEvents;

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

        private bool working = false;

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

        public bool Working
        {
            get
            {
                return working;
            }
        }

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
        
        public virtual void StopHookWork()
        {
            if (m_GlobalHook == null)
                return;

            m_GlobalHook.KeyDown -= GlobalHookKeyDown;
            m_GlobalHook.KeyPress -= GlobalHookKeyPress;
            m_GlobalHook.KeyUp -= GlobalHookKeyUp;


            m_GlobalHook.MouseDown -= GlobalHookMouseDown;
            m_GlobalHook.MouseWheel -= GlobalHook_MouseWheel;

            m_GlobalHook.Dispose();
            m_GlobalHook = null;

            stopWach.Stop();

            working = false;
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

            working = true;
        }
        
        #endregion IKeyboardPressTracking

        #region GlobalHook_Mouse
        
        protected virtual void GlobalHook_MouseWheel(object sender, MouseEventArgs e)
        {
        }

        protected virtual void GlobalHookMouseDown(object sender, MouseEventArgs e)
        {
            // done: iškelta į perrašančią klasę, taip optimizuojant
            //var obj = new ObjEvent_mouse()
            //{
            //    ActiveWindowName = Helper.Helper.GetActiveWindowTitle_v3(),
            //    EventObjDataType = EventDataType.MouseClick,
            //    SavedInDB = false,
            //    EventObjType = EventType.MouseDown,
            //    EventTime = DateTime.Now,
            //    X = e.X,
            //    Y = e.Y
            //};

            //switch (e.Button)
            //{
            //    case MouseButtons.Left:
            //        obj.MouseKey = MouseKeys.Left;
            //        break;
            //    case MouseButtons.Right:
            //        obj.MouseKey = MouseKeys.Right;
            //        break;
            //    case MouseButtons.Middle:
            //        obj.MouseKey = MouseKeys.Middle;
            //        break;
            //    case MouseButtons.XButton1:
            //        obj.MouseKey = MouseKeys.XButton1;
            //        break;
            //    case MouseButtons.XButton2:
            //        obj.MouseKey = MouseKeys.XButton2;
            //        break;
            //    case MouseButtons.None:
            //    default:
            //        obj.MouseKey = MouseKeys.Unknown;
            //        break;
            //} 

            //Add_Obj<ObjEvent_mouse>(ref mouseEvents, obj);
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
                ActiveWindowName = Helper.Helper.GetActiveWindowTitle_v3(),
                EventObjType = EventType.KeyPress,
                KeyValue = (int)e.KeyChar,
                Key = e.KeyChar.ToString(),
                EventObjDataType = EventDataType.SymbolAsciiCode,
                SavedInDB = false,
                EventTime = DateTime.Now
            };

            Add_ObjEvent_key(newRec);
            
            //DebugHelper.AddInfoMsg(newRec.EventTime, $"{newRec.Key.ToString()} {newRec.KeyValue.ToString()} [{newRec.ActiveWindowName}]");
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
                Helper.Helper.DeleteFromBegin(ref keysCharsEvents, 5000);
                keysCharsEvents.Add(newRec);
            }
            catch
            {
                throw;
            }
        }

        protected void Add_Obj<T>(ref List<T> lst, T obj)
        {
            try
            {
                lst.Add(obj);
            }
            catch (OutOfMemoryException oomEx)
            {
                LogHelper.LogErrorMsg(oomEx);
                LogHelper.LogInfoMsg($"BANDOMA PAŠALINTI DALĮ ELEMENTŲ IŠ {nameof(T)}");
                DebugHelper.AddInfoMsg($"BANDOMA PAŠALINTI DALĮ ELEMENTŲ IŠ {nameof(T)}");
                Helper.Helper.DeleteFromBegin(ref lst, 5000);
                lst.Add(obj);
            }
            catch
            {
                throw;
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
                ActiveWindowName = Helper.Helper.GetActiveWindowTitle_v3(),
                KeyValue = e.KeyValue,
                EventObjDataType = EventDataType.KeyboardButtonCode,
                SavedInDB = false,
                EventTime = DateTime.Now
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
                Helper.Helper.DeleteFromBegin(ref keysEvents, 5000);
                keysEvents.Add(newRec);
            }
            catch
            {
                throw;
            }
            
            var rec = keyPressCountObjList.FirstOrDefault(x => x.AsciiKeyCode == e.KeyValue);
            if (rec != null)
                rec.PressHoldCount++;
            else
                keyPressCountObjList.Add(new ObjKeyPressCount(e.KeyValue));

            DebugHelper.AddInfoMsg(newRec.EventTime, $"{newRec.Key.ToString()} {newRec.KeyValue.ToString()} [{newRec.ActiveWindowName}]");
        }

        #region IDatabase

        public void Db_SaveChanges()
        {
            try
            {
                #region KP_EVENT_MOUSE
                if (mouseEvents.Count(x=>x.SavedInDB == false) > 0)
                {
                    DatabaseControl.SaveWindows(mouseEvents.Where(x => x.SavedInDB == false).Select(x => x.ActiveWindowName).Distinct().ToArray());

                    string sql_KP_EVENT_MOUSE = "INSERT INTO KP_EVENT_MOUSE (event_type_id, event_data_type_id, win_id, [time], x, y, user_record_id, mouse_key_id) VALUES";
                    List<string> sql_values_KP_EVENT_MOUSE = new List<string>();
                    mouseEvents.Where(x => x.SavedInDB == false).ToList().ForEach(x =>
                    {
                        var win = DatabaseControl.GetWindowsIdsByProcName(x.ActiveWindowName);

                        sql_values_KP_EVENT_MOUSE.Add($"({(int)x.EventObjType}, {(int)x.EventObjDataType}, {win[0].Item1}, '{x.EventTime.ToString("yyyy-MM-dd HH:mm:ss.fff")}', {(x.X != null ? x.X.ToString() : "null")}, {(x.Y != null ? x.Y.ToString() : "null")}, {DBHelper.UserId}, {(int)x.MouseKey}),");
                    });
                    sql_KP_EVENT_MOUSE = DatabaseControl.CreateInsertSqlClause(sql_KP_EVENT_MOUSE, sql_values_KP_EVENT_MOUSE.ToArray());
                    if (!String.IsNullOrEmpty(sql_KP_EVENT_MOUSE))
                    {
                        var result_KP_EVENT_MOUSE = DBHelper.ExecSqlDb(sql_KP_EVENT_MOUSE, true);
                        if (result_KP_EVENT_MOUSE != "OK")
                            throw new Exception($"Failled {nameof(KeyboardPressAdapter)}.{nameof(Db_SaveChanges)}.[KP_EVENT_MOUSE] {result_KP_EVENT_MOUSE} (sql: {sql_KP_EVENT_MOUSE})");

                        mouseEvents.Where(x => x.SavedInDB == false).ToList().ForEach(x => x.SavedInDB = true);
                    }
                }
                #endregion KP_EVENT_MOUSE

                #region KP_EVENT_KEY_ALL
                if (keysEvents.Count(x => x.SavedInDB == false) > 0)
                {
                    DatabaseControl.SaveWindows(keysEvents.Where(x => x.SavedInDB == false).Select(y=>y.ActiveWindowName).Distinct().ToArray());

                    string sql_KP_EVENT_KEY_ALL = "INSERT INTO KP_EVENT_KEY_ALL (event_type_id, event_data_type_id, win_id, [time], [key], key_value, shift_press, ctrl_press, user_record_id) VALUES";
                    List<string> sql_values_KP_EVENT_KEY_ALL = new List<string>();
                    keysEvents.Where(x => x.SavedInDB == false).ToList().ForEach(x =>
                    {
                        var win = DatabaseControl.GetWindowsIdsByProcName(x.ActiveWindowName);

                        sql_values_KP_EVENT_KEY_ALL.Add($"({(int)x.EventObjType}, {(int)x.EventObjDataType}, {win[0].Item1}, '{x.EventTime.ToString("yyyy-MM-dd HH:mm:ss.fff")}', '{x.Key}', {x.KeyValue}, {(x.ShiftKeyPressed != null ? ((bool)x.ShiftKeyPressed ? "1" : "0") : "null")}, {(x.CtrlKeyPressed != null ? ((bool)x.CtrlKeyPressed ? "1" : "0") : "null")}, {DBHelper.UserId}),");
                    });
                    sql_KP_EVENT_KEY_ALL = DatabaseControl.CreateInsertSqlClause(sql_KP_EVENT_KEY_ALL, sql_values_KP_EVENT_KEY_ALL.ToArray());
                    if (!String.IsNullOrEmpty(sql_KP_EVENT_KEY_ALL))
                    {
                        var result_KP_EVENT_KEY_ALL = DBHelper.ExecSqlDb(sql_KP_EVENT_KEY_ALL, true);
                        if (result_KP_EVENT_KEY_ALL != "OK")
                            throw new Exception($"Failled {nameof(KeyboardPressAdapter)}.{nameof(Db_SaveChanges)}.[KP_EVENT_KEY_ALL] {result_KP_EVENT_KEY_ALL} (sql: {sql_KP_EVENT_KEY_ALL})");

                        keysEvents.Where(x => x.SavedInDB == false).ToList().ForEach(x => x.SavedInDB = true);
                    }
                }
                #endregion KP_EVENT_KEY_ALL

                #region KP_EVENT_KEY_CHAR
                if (keysCharsEvents.Count(x => x.SavedInDB == false) > 0)
                {
                    DatabaseControl.SaveWindows(keysCharsEvents.Where(y => y.SavedInDB == false).Select(y=>y.ActiveWindowName).Distinct().ToArray());

                    string sql_KP_EVENT_KEY_CHAR = "INSERT INTO KP_EVENT_KEY_CHAR (event_type_id, event_data_type_id, win_id, [time], [key], key_value, shift_press, ctrl_press, user_record_id) VALUES";
                    var sql_values_KP_EVENT_KEY_CHAR = new List<string>();
                    keysCharsEvents.Where(x => x.SavedInDB == false && x.Key.ToString() != "MouseClick").ToList().ForEach(x =>
                    {
                        var win = DatabaseControl.GetWindowsIdsByProcName(x.ActiveWindowName);

                        sql_values_KP_EVENT_KEY_CHAR.Add($"({(int)x.EventObjType}, {(int)x.EventObjDataType}, {win[0].Item1}, '{x.EventTime.ToString("yyyy-MM-dd HH:mm:ss.fff")}', '{x.Key}', {x.KeyValue}, {(x.ShiftKeyPressed != null ? ((bool)x.ShiftKeyPressed ? "1" : "0") : "null")}, {(x.CtrlKeyPressed != null ? ((bool)x.CtrlKeyPressed ? "1" : "0") : "null")}, {DBHelper.UserId}),");
                    });
                    sql_KP_EVENT_KEY_CHAR = DatabaseControl.CreateInsertSqlClause(sql_KP_EVENT_KEY_CHAR, sql_values_KP_EVENT_KEY_CHAR.ToArray());
                    if (!String.IsNullOrEmpty(sql_KP_EVENT_KEY_CHAR))
                    {
                        var result_KP_EVENT_KEY_CHAR = DBHelper.ExecSqlDb(sql_KP_EVENT_KEY_CHAR, true);
                        if (result_KP_EVENT_KEY_CHAR != "OK")
                            throw new Exception($"Failled {nameof(KeyboardPressAdapter)}.{nameof(Db_SaveChanges)}.[KP_EVENT_KEY_CHAR] {result_KP_EVENT_KEY_CHAR} (sql: {sql_KP_EVENT_KEY_CHAR})");

                        keysCharsEvents.Where(x => x.SavedInDB == false).ToList().ForEach(x => x.SavedInDB = true);
                    }
                }
                #endregion KP_EVENT_KEY_CHAR

                #region keyPressCountObjList - KP_KEY_PRESS_COUNT

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

                if (!String.IsNullOrWhiteSpace(sql))
                {
                    var result = DBHelper.ExecSqlDb(sql, true);
                    if (result != "OK")
                        throw new Exception($"Failled {nameof(KeyboardPressAdapter)}.{nameof(Db_SaveChanges)}.[KP_KEY_PRESS_COUNT] {result} (sql: {sql})");
                }

                #endregion keyPressCountObjList - KP_KEY_PRESS_COUNT
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
SELECT TOP 0 record_id, CAST(event_type_id AS SMALLINT) as event_type_id, CAST(event_data_type_id AS SMALLINT) as event_data_type_id, win_id, [time], [key], key_value, shift_press, ctrl_press, user_record_id
FROM KP_EVENT_KEY_ALL
WHERE user_record_id = {DBHelper.UserId}

SELECT TOP 0 record_id, CAST(event_type_id AS SMALLINT) as event_type_id, CAST(event_data_type_id AS SMALLINT) as event_data_type_id, win_id, [time], [key], key_value, shift_press, ctrl_press, user_record_id
FROM KP_EVENT_KEY_CHAR
WHERE user_record_id = {DBHelper.UserId}

SELECT TOP 0 record_id, CAST(event_type_id AS SMALLINT) as event_type_id, CAST(event_data_type_id AS SMALLINT) as event_data_type_id, win_id, [time], x, y, user_record_id, mouse_key_id
FROM KP_EVENT_MOUSE
WHERE user_record_id = {DBHelper.UserId}

SELECT record_id, ascii_code, press_hold_count, press_release_count, user_record_id
FROM KP_KEY_PRESS_COUNT
WHERE user_record_id = {DBHelper.UserId}";

                var ds = DBHelper.GetDataSetDb(sql);

                if (ds == null || ds.Tables.Count != 4)
                    throw new Exception($"Failled {nameof(KeyboardPressAdapter)}.{nameof(Db_LoadData)} data load (sql: {sql})");

                if(ds.Tables[0].Rows.Count > 0)
                {
                    //KP_EVENT_KEY_ALL
                    //keysEvents
                    ds.Tables[0].AsEnumerable().ToList().ForEach(x =>
                    {
                        var win = DatabaseControl.GetWindowsByIds(x.Field<int>("win_id"));
                        
                        keysEvents.Add(new ObjEvent_key()
                        {
                            ActiveWindowName = win != null && win.Length > 0 ? win[0].Item2 : Helper.Helper.unknownWindowName,
                            CtrlKeyPressed = x.Field<bool?>("ctrl_press").HasValue ? x.Field<bool?>("ctrl_press").Value : (bool?)null,
                            ShiftKeyPressed = x.Field<bool?>("shift_press").HasValue ? x.Field<bool?>("shift_press").Value : (bool?)null,
                            EventTime = x.Field<DateTime>("time"),
                            SavedInDB = true,
                            EventObjDataType = (EventDataType)x.Field<Int16>("event_data_type_id"),
                            EventObjType = (EventType)x.Field<Int16>("event_type_id"),
                            Key = x.Field<string>("key"),
                            KeyValue = x.Field<Int16>("key_value")
                        });
                    });
                }

                if (ds.Tables[1].Rows.Count > 0)
                {
                    //KP_EVENT_KEY_CHAR
                    //keysCharsEvents
                    ds.Tables[1].AsEnumerable().ToList().ForEach(x =>
                    {
                        var win = DatabaseControl.GetWindowsByIds(x.Field<int>("record_id"));
                        keysCharsEvents.Add(new ObjEvent_key()
                        {
                            ActiveWindowName = win != null && win.Length > 0 ? win[0].Item2 : Helper.Helper.unknownWindowName,
                            CtrlKeyPressed = x.Field<bool?>("ctrl_press").HasValue ? x.Field<bool?>("ctrl_press").Value : (bool?)null,
                            ShiftKeyPressed = x.Field<bool?>("shift_press").HasValue ? x.Field<bool?>("shift_press").Value : (bool?)null,
                            EventTime = x.Field<DateTime>("time"),
                            SavedInDB = true,
                            EventObjDataType = (EventDataType)x.Field<Int16>("event_data_type_id"),
                            EventObjType = (EventType)x.Field<Int16>("event_type_id"),
                            Key = x.Field<string>("key"),
                            KeyValue = x.Field<Int16>("key_value")
                        });
                    });
                }

                if (ds.Tables[2].Rows.Count > 0)
                {
                    //KP_EVENT_MOUSE
                    ds.Tables[2].AsEnumerable().ToList().ForEach(x =>
                    {
                        var win = DatabaseControl.GetWindowsByIds(x.Field<int>("win_id"));
                        
                        mouseEvents.Add(new ObjEvent_mouse()
                        {
                            ActiveWindowName = win != null && win.Length > 0 ? win[0].Item2 : Helper.Helper.unknownWindowName,
                            EventTime = x.Field<DateTime>("time"),
                            EventObjDataType = (EventDataType)x.Field<Int16>("event_data_type_id"),
                            EventObjType = (EventType)x.Field<Int16>("event_type_id"),
                            SavedInDB = true,
                            X = x.Field<Int16>("x"),
                            Y = x.Field<Int16>("y"),
                            MouseKey = (MouseKeys)x.Field<Int16>("mouse_key_id")
                        });
                    });
                }

                if (ds.Tables[3].Rows.Count > 0)
                {
                    //KP_KEY_PRESS_COUNT
                    ds.Tables[3].AsEnumerable().ToList().ForEach(x =>
                    {
                        keyPressCountObjList.Add(new ObjKeyPressCount()
                        {
                            AsciiKeyCode = x.Field<Int16>("ascii_code"),
                            PressHoldCount = (uint)x.Field<Int64>("press_hold_count"),
                            PressReleaseCount = (uint)x.Field<Int64>("press_release_count")
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
DELETE FROM KP_KEY_PRESS_COUNT WHERE user_record_id = {DBHelper.UserId}";

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

        #endregion IDatabase
    }
}
