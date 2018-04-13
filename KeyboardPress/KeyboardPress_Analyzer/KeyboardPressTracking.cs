using KeyboardPress_Analyzer.Functions;
using KeyboardPress_Analyzer.Helper;
using KeyboardPress_Analyzer.Objects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using KeyboardPress_Extensions.InfoForm;
using System.Data;

namespace KeyboardPress_Analyzer
{
    public class KeyboardPressTracking : KeyboardPressAdapter, IDatabase
    {
        private const ulong ulongMax = ulong.MaxValue;
        private const int lastRecordsToCheck = 30;
        private const int maxLastRecordToCheckForWord = 40;

        private ulong totalKeyPressRelease;
        private ulong totalKeyPress;
        private ulong totalMousePress;
        private ulong totalMouseLeftPress;
        private ulong totalMouseRightPress;
        private ulong totalMouseWheelUp;
        private ulong totalMouseWheelDown;
        
        private RestReminder restReminder;

        private NotifyIcon notifyIcon;

        private TotalWords TotalWordsClass;
        private OfferWord OfferWordClass;

        //public List<object> UiControls;

        public List<ObjMistakeChar> MistakesChar
        {
            get
            {
                if(TotalWordsClass != null)
                    return TotalWordsClass.MistakesChar;
                return null;
            }
        }

        public CustomStopWatch TotalWorkStopWatch = null;
        
        #region get set
        
        public Stopwatch RestReminderWorkTime
        {
            get
            {
                if(restReminder != null)
                    return restReminder.WorkStopwatch;
                return null;
            }
        }

        public Stopwatch RestReminderRestTime
        {
            get
            {
                if (restReminder != null)
                    return restReminder.RestStopWatch;
                return null;
            }
        }
        
        public ulong TotalKeyPressRelease
        {
            get
            {
                return totalKeyPressRelease;
            }
            set
            {
                totalKeyPressRelease = value;
            }
        }

        public ulong TotalKeyPres
        {
            get { return totalKeyPress; }
        }

        public ulong TotalMousePress
        {
            get
            {
                return totalMousePress;
            }

            set
            {
                totalMousePress = value;
            }
        }

        public ulong TotalWords
        {
            get
            {
                return TotalWordsClass.TotalWordsCount_v2;
            }
        }

        public ulong TotalMouseWheelUp
        {
            get
            {
                return totalMouseWheelUp;
            }

            set
            {
                totalMouseWheelUp = value;
            }
        }

        public ulong TotalMouseWheelDown
        {
            get
            {
                return totalMouseWheelDown;
            }

            set
            {
                totalMouseWheelDown = value;
            }
        }
        
        #endregion

        public void Reload_OfferWordClass_Data()
        {
            if (OfferWordClass != null)
                OfferWordClass.reloadOfferWord();
        }

        #region interface overrides
        //public override void CleanData()
        //{
        //    base.CleanData();
        //}

        public override void StopHookWork()
        {
            base.StopHookWork();

            if (restReminder != null)
            {
                restReminder.Stop();
                restReminder = null;
            }

            if (TotalWorkStopWatch.IsRunning)
                TotalWorkStopWatch.Stop();
        }

        public override void StartHookWork()
        {
            base.StartHookWork();

            if (restReminder == null)
                restReminder = new RestReminder();
            restReminder.TimeToRest += RestReminder_TimeToRest;
            restReminder.Start();

            if (!TotalWorkStopWatch.IsRunning)
                TotalWorkStopWatch.Start();
        }
        #endregion

        #region Rest reminder
        private void RestReminder_TimeToRest(object sender, EventArgs e)
        {
            Task t = new Task(() =>
            {
                InfoForm.Show($@"Pernelyk ilgas darbas kenkia Jūsų sveikatai.
Prie kompiutero jau dirbate daugiau nei {restReminder.WorkStopwatch.Elapsed.TotalMinutes.ToString("#.##")} minutes(-čių).
Siūloma pailsėti bent {(((double)(restReminder.RestTimeSeconds)) / 60d).ToString("#.##")} minutes(-čių).",
                "Laikas poilsiui", 10000,
                InfoForm.Enum_InfoFormImage.HeadMind,
                null);

                //                Thread th = new Thread(() =>
                //                {
                //                    InfoForm.Show($@"Pernelyk ilgas darbas kenkia Jūsų sveikatai.
                //Prie kompiutero jau dirbate daugiau nei {restReminder.WorkStopwatch.Elapsed.TotalMinutes.ToString("#.##")} minučių.
                //Siūloma pailsėti bent {(((double)(restReminder.RestTimeSeconds)) / 60d).ToString("#.##")} minutes.",
                //                "Laikas poilsiui", 10000,
                //                InfoForm.Enum_InfoFormImage.HeadMind,
                //                null);
                //                });
                //                th.Start();
                //                Thread.Sleep(15000);
                //                th.Abort();
            });
            t.Start();
            //notifyIcon.ShowBalloonTip(1000, "restTime", "restTime", ToolTipIcon.Warning);
            
        }

        private void WorkInProgress()
        {
            if (restReminder != null)
                restReminder.Action();
        }
        #endregion Rest reminder

        #region construkctor
        public KeyboardPressTracking(NotifyIcon NotifyIcon) : base()
        {
            totalKeyPressRelease = 0;
            totalMousePress = 0;
            totalMouseWheelUp = 0;
            totalMouseWheelDown = 0;
            totalMouseLeftPress = 0;
            totalMouseRightPress = 0;
            totalKeyPress = 0;

            notifyIcon = NotifyIcon;

            TotalWordsClass = new TotalWords();
            OfferWordClass = new OfferWord(NotifyIcon);

            TotalWorkStopWatch = new CustomStopWatch(null);
        }
        #endregion

        #region overrides
        protected override void GlobalHookKeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                base.GlobalHookKeyUp(sender, e);

                if (totalKeyPressRelease < ulongMax)
                {
                    totalKeyPressRelease++;
                    Helper.Helper.UiControls.SetText(totalKeyPressRelease.ToString(), EnumUiControlTag.TotalKeyPressRelease);
                }
                else
                    DebugHelper.AddErrorMsg("Pasiektas maksimalus sumuojamas klavišų paspaudimų kiekis");

                WorkInProgress();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, $"Error on {nameof(GlobalHookKeyUp)}");
            }
        }

        /// <summary>
        /// Apsoliučiai visi mygtukų paspaudimai (nuspaudimai) + kursoriaus pozicijos keitimas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void GlobalHookKeyDown(object sender, KeyEventArgs e)
        {
            if (Constants.CursorPositionChangeKeyboardKeyCodesArr.Contains(e.KeyValue) || e.KeyValue == 46) // home, end, arrows, pgup, pgdn || delete
            {
                //nes keičia kursoriaus poziciją
                var a = new ObjEvent_key()
                {
                    ActiveWindowName = Helper.Helper.GetActiveWindowTitle_v3(),
                    ShiftKeyPressed = e.Shift,
                    CtrlKeyPressed = e.Control,
                    EventObjType = EventType.KeyPress,
                    KeyValue = e.KeyValue,
                    EventObjDataType = EventDataType.KeyboardButtonCode,
                    Key = e.KeyCode.ToString(),
                    SavedInDB = false,
                    EventTime = DateTime.Now
                };
                Add_ObjEvent_key(a);
            }

            base.GlobalHookKeyDown(sender, e);

            if(totalKeyPress < ulongMax)
            {
                totalKeyPress++;
                Helper.Helper.UiControls.SetText(totalKeyPress.ToString(), EnumUiControlTag.TotalKeyPress);
            }
        }

        /// <summary>
        /// Mygtukų nuspaudimai generuojantys/keičiantys tekstą
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void GlobalHookKeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                base.GlobalHookKeyPress(sender, e);

                ObjEvent_key lastRec = null;
                ObjEvent_key[] lastNRecInSameWin = null;
                ObjEvent_key[] lastNRecInSameWin_v2 = null;
                lock (KeysCharsEvents)
                {
                    lastRec = KeysCharsEvents.LastOrDefault();
                    // v.1.1:
                    lastNRecInSameWin = Helper.Helper.TakeLast(KeysCharsEvents.Where(x => x.ActiveWindowName == lastRec.ActiveWindowName), lastRecordsToCheck).ToArray();
                    // v.2.0:
                    lastNRecInSameWin_v2 = getLastSymbolsForWordCountV2(lastRec);
                }

                // Atskiroje gijoje sumuoja žodžius
                // v.1.1:
                //var t_totalWordsCount = new Task(() => { TotalWordsClass.totalWordsCount(lastRec, lastNRecInSameWin); });
                //t_totalWordsCount.Start();
                // v.2.0:
                var t_totalWordsCount_v2 = new Task(() => { TotalWordsClass.totalWordsCount_v2(lastNRecInSameWin_v2); });
                t_totalWordsCount_v2.Start();


                // Atskiroje gijoje žodžių keitimas
                // nice to have: pajungti ant t_totalWordsCount_v2
                Thread t = new Thread(() =>
                {
                    OfferWordClass.offerWordTemplate(lastNRecInSameWin);
                });
                t.SetApartmentState(ApartmentState.STA);
                t.Start();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, $"Error on {nameof(GlobalHookKeyPress)}");
            }
        }

        private ObjEvent_key[] getLastSymbolsForWordCountV2(ObjEvent_key lastRec)
        {
            if (lastRec == null)
                return null;

            var result = new List<ObjEvent_key>();

            var data = KeysCharsEvents.Where(x => (x.EventObjType == EventType.KeyPress && x.ActiveWindowName == lastRec.ActiveWindowName) || (x.EventObjType == EventType.KeyPress && x.EventObjDataType == EventDataType.MouseClick))
                .TakeLast(maxLastRecordToCheckForWord).Reverse();
            foreach (var rec in data)
            {
                if (!(rec.EventObjDataType == EventDataType.KeyboardButtonCode && Constants.KeyboardButtonsToSkipWordsCount.Contains(rec.KeyValue))
                    &&
                    !(rec.EventObjDataType == EventDataType.SymbolAsciiCode && Constants.WordEndSymbolArr.Contains(rec.KeyValue)))
                    result.Add(rec);
                else if(rec == data.FirstOrDefault())
                    result.Add(rec);
                else if(rec.EventObjDataType == EventDataType.MouseClick)
                    result.Add(rec);
                else
                    break;
            }

            return result.ToArray().Reverse().ToArray();
        }

        protected override void GlobalHookMouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (totalMousePress < ulongMax)
                {
                    totalMousePress++;
                    Helper.Helper.UiControls.SetText(totalMousePress.ToString(), EnumUiControlTag.TotalMousePress);
                }
                WorkInProgress();

                string winTitle = Helper.Helper.GetActiveWindowTitle_v3();

                #region atkelta iš base klasės
                var obj = new ObjEvent_mouse()
                {
                    ActiveWindowName = winTitle,
                    EventObjDataType = EventDataType.MouseClick,
                    SavedInDB = false,
                    EventObjType = EventType.MouseDown,
                    EventTime = DateTime.Now,
                    X = e.X,
                    Y = e.Y
                };

                switch (e.Button)
                {
                    case MouseButtons.Left:
                        obj.MouseKey = MouseKeys.Left;
                        if (totalMouseLeftPress < ulongMax)
                        {
                            totalMouseLeftPress++;
                            Helper.Helper.UiControls.SetText(totalMouseLeftPress.ToString(), EnumUiControlTag.TotalMouseLeftPress);
                        }
                        break;
                    case MouseButtons.Right:
                        obj.MouseKey = MouseKeys.Right;
                        if (totalMouseRightPress < ulongMax)
                        {
                            totalMouseRightPress++;
                            Helper.Helper.UiControls.SetText(totalMouseRightPress.ToString(), EnumUiControlTag.TotalMouseRightPress);
                        }
                        break;
                    case MouseButtons.Middle:
                        obj.MouseKey = MouseKeys.Middle;
                        break;
                    case MouseButtons.XButton1:
                        obj.MouseKey = MouseKeys.XButton1;
                        break;
                    case MouseButtons.XButton2:
                        obj.MouseKey = MouseKeys.XButton2;
                        break;
                    case MouseButtons.None:
                    default:
                        obj.MouseKey = MouseKeys.Unknown;
                        break;
                }

                Add_Obj<ObjEvent_mouse>(ref mouseEvents, obj);
                #endregion

                //pelės paspaudimas gali keisti kursoriaus poziciją
                var a = new ObjEvent_key()
                {
                    ActiveWindowName = winTitle,
                    ShiftKeyPressed = null,
                    CtrlKeyPressed = null,
                    EventObjType = EventType.KeyPress, //nes naudojamas bus ten kur generuojamos zodis
                    KeyValue = -1,
                    EventObjDataType = EventDataType.MouseClick,
                    Key = "MouseClick", //įrašas neina į db pagal šį pavadinimą
                    EventTime = DateTime.Now,
                    SavedInDB = false
                };
                Add_ObjEvent_key(a);
            }
            catch(Exception ex)
            {
                LogHelper.LogErrorMsg(ex);
                MessageBox.Show(ex.Message, $"Error on {nameof(GlobalHookMouseDown)}");
            }
            
            //base.GlobalHookMouseDown(sender, e); //viskas iškelta čianais
        }

        protected override void GlobalHook_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                totalMouseWheelUp++;
                Helper.Helper.UiControls.SetText(totalMouseWheelUp.ToString(), EnumUiControlTag.TotalMouseWheelUp);
            }
            else
            {
                totalMouseWheelDown++;
                Helper.Helper.UiControls.SetText(totalMouseWheelDown.ToString(), EnumUiControlTag.TotalMouseWheelDown);
            }

            WorkInProgress();
        }
        #endregion
        
        #region count avrg

        //public double countAvrgPressPerMin()
        //{
        //    if (KeysEvents.LongCount() == 0 || StopWach.ElapsedMilliseconds == 0)
        //        return 0;
            
        //    return KeysEvents.LongCount() / TimeSpan.FromMilliseconds(StopWach.ElapsedMilliseconds).TotalMinutes;
        //}

        //public double countAvrgPressPerHour()
        //{
        //    if (KeysEvents.LongCount() == 0 || StopWach.ElapsedMilliseconds == 0)
        //        return 0;

        //    return KeysEvents.LongCount() / TimeSpan.FromMilliseconds(StopWach.ElapsedMilliseconds).TotalHours;
        //}

        //public double countAvrgMousePressPerMin()
        //{
        //    if (totalMousePress == 0 || StopWach.ElapsedMilliseconds == 0)
        //        return 0;

        //    return totalMousePress / TimeSpan.FromMilliseconds(StopWach.ElapsedMilliseconds).TotalMinutes;
        //}

        //public double countAvrgMousePressPerHour()
        //{
        //    if (totalMousePress == 0 || StopWach.ElapsedMilliseconds == 0)
        //        return 0;

        //    return totalMousePress / TimeSpan.FromMilliseconds(StopWach.ElapsedMilliseconds).TotalHours;
        //}

        //public double countAvrgWordsPerMin()
        //{
        //    if (TotalWordsClass.TotalWordsCount_v2 == 0 || StopWach.ElapsedMilliseconds == 0)
        //        return 0;

        //    return TotalWordsClass.TotalWordsCount_v2 / TimeSpan.FromMilliseconds(StopWach.ElapsedMilliseconds).TotalMinutes;
        //}

        //public double countAvrgWordsPerHour()
        //{
        //    if (TotalWordsClass.TotalWordsCount_v2 == 0 || StopWach.ElapsedMilliseconds == 0)
        //        return 0;

        //    return TimeSpan.FromMilliseconds(StopWach.ElapsedMilliseconds).TotalHours;
        //}

        #endregion count avrg

        #region IDatabase
        public void Db_SaveChanges()
        {
            try
            {
                bool needToStop = base.Working;
                if (needToStop)
                    base.StopHookWork();
                
                #region KP_SYSTEM_PARAMETERS
                Func<string, string, string> FuncFormat_KP_SYSTEM_PARAMETERS_sql = (value, name) =>
                {
                    //                    string sql_result = $@"
                    //IF EXISTS (SELECT record_id FROM KP_SYSTEM_PARAMETERS WHERE user_record_id = {DBHelper.UserId} AND name = '{name}')
                    //BEGIN
                    //UPDATE KP_SYSTEM_PARAMETERS
                    //    SET decimal_value = {value}, modified_date = '{DateTime.Now}'
                    //WHERE user_record_id = {DBHelper.UserId} AND name = '{name}'
                    //END
                    //ELSE BEGIN
                    //INSERT INTO KP_SYSTEM_PARAMETERS (user_record_id, name, decimal_value, modified_date)
                    //    VALUES ({DBHelper.UserId}, '{name}', {value}, '{DateTime.Now}')
                    //END";
                    string sql_result = $@"
UPDATE KP_SYSTEM_PARAMETERS
    SET decimal_value = {value}, modified_date = '{DateTime.Now}'
WHERE user_record_id = {DBHelper.UserId} AND name = '{name}';

INSERT INTO KP_SYSTEM_PARAMETERS (user_record_id, name, decimal_value, modified_date)
    SELECT {DBHelper.UserId}, '{name}', {value}, '{DateTime.Now}'
    WHERE (Select Changes() = 0);";
                    return sql_result;
                };

                try
                {
                    string sql_KP_SYSTEM_PARAMETERS = "";
                    sql_KP_SYSTEM_PARAMETERS += FuncFormat_KP_SYSTEM_PARAMETERS_sql(totalKeyPressRelease.ToString(), nameof(totalKeyPressRelease));
                    sql_KP_SYSTEM_PARAMETERS += FuncFormat_KP_SYSTEM_PARAMETERS_sql(totalMousePress.ToString(), nameof(totalMousePress));
                    sql_KP_SYSTEM_PARAMETERS += FuncFormat_KP_SYSTEM_PARAMETERS_sql(totalMouseLeftPress.ToString(), nameof(totalMouseLeftPress));
                    sql_KP_SYSTEM_PARAMETERS += FuncFormat_KP_SYSTEM_PARAMETERS_sql(totalMouseRightPress.ToString(), nameof(totalMouseRightPress));
                    sql_KP_SYSTEM_PARAMETERS += FuncFormat_KP_SYSTEM_PARAMETERS_sql(totalMouseWheelUp.ToString(), nameof(totalMouseWheelUp));
                    sql_KP_SYSTEM_PARAMETERS += FuncFormat_KP_SYSTEM_PARAMETERS_sql(totalMouseWheelDown.ToString(), nameof(totalMouseWheelDown));
                    sql_KP_SYSTEM_PARAMETERS += FuncFormat_KP_SYSTEM_PARAMETERS_sql(totalKeyPress.ToString(), nameof(totalKeyPress));
                        
                    string string_value = $"{TotalWorkStopWatch.Elapsed.Days};{TotalWorkStopWatch.Elapsed.Hours};{TotalWorkStopWatch.Elapsed.Minutes};{TotalWorkStopWatch.Elapsed.Seconds}";
                    //                    sql_KP_SYSTEM_PARAMETERS += $@"
                    //IF EXISTS (SELECT record_id FROM KP_SYSTEM_PARAMETERS WHERE user_record_id = {DBHelper.UserId} AND name = '{nameof(TotalWorkStopWatch)}')
                    //BEGIN
                    //UPDATE KP_SYSTEM_PARAMETERS
                    //    SET string_value = '{string_value}', modified_date = '{DateTime.Now}'
                    //WHERE user_record_id = {DBHelper.UserId} AND name = '{nameof(TotalWorkStopWatch)}'
                    //END
                    //ELSE BEGIN
                    //INSERT INTO KP_SYSTEM_PARAMETERS (user_record_id, name, string_value, modified_date)
                    //    VALUES ({DBHelper.UserId}, '{nameof(TotalWorkStopWatch)}', '{string_value}', '{DateTime.Now}')
                    //END";
                    sql_KP_SYSTEM_PARAMETERS += $@"
UPDATE KP_SYSTEM_PARAMETERS
    SET string_value = '{string_value}', modified_date = '{DateTime.Now}'
WHERE user_record_id = {DBHelper.UserId} AND name = '{nameof(TotalWorkStopWatch)}';

INSERT INTO KP_SYSTEM_PARAMETERS (user_record_id, name, string_value, modified_date)
    SELECT {DBHelper.UserId}, '{nameof(TotalWorkStopWatch)}', '{string_value}', '{DateTime.Now}'
    WHERE (Select Changes() = 0);";

                    var result = DBHelper.ExecSqlDb(sql_KP_SYSTEM_PARAMETERS, true);
                    if (result != "OK")
                        throw new Exception($"Failed {nameof(KeyboardPressTracking)} {nameof(Db_SaveChanges)}[KP_SYSTEM_PARAMETERS]: {result} (sql: {sql_KP_SYSTEM_PARAMETERS})");
                }
                catch(Exception ex)
                {
                    LogHelper.LogErrorMsg(ex);
                    throw;
                }
                #endregion KP_SYSTEM_PARAMETERS

                if (TotalWordsClass != null)
                    TotalWordsClass.Db_SaveChanges(); //kartu ir Writing mistakes

                base.Db_SaveChanges();
                
                if(needToStop)
                    base.StartHookWork();
            }
            catch
            {
                throw;
            }
        }

        public void Db_LoadData()
        {
            try
            {
                bool needToStop = base.Working;
                if (needToStop)
                    base.StopHookWork();
                
                #region KP_SYSTEM_PARAMETERS
                try
                {
                    var dt = DBHelper.GetDataTableDb($@"
SELECT
SP.name, SP.decimal_value, SP.string_value
FROM KP_SYSTEM_PARAMETERS SP
WHERE SP.user_record_id = {DBHelper.UserId}
AND SP.name IN ('{nameof(totalKeyPressRelease)}', '{nameof(totalMousePress)}', '{nameof(totalMouseLeftPress)}', '{nameof(totalMouseRightPress)}', '{nameof(totalMouseWheelUp)}', '{nameof(totalMouseWheelDown)}', '{nameof(totalKeyPress)}', '{nameof(TotalWorkStopWatch)}')");

                    if (dt == null)
                        throw new Exception($"{nameof(KeyboardPressTracking)}.{nameof(Db_LoadData)} [KP_SYSTEM_PARAMETERS] dataload");

                    Func<DataTable, string, ulong> FuncFillValueFromDt = (dataTable, parameterName) =>
                    {
                        var va = dataTable.AsEnumerable().FirstOrDefault(x => x.Field<string>("name") == parameterName);
                        if (va == null)
                            return 0;
                        else
                            return System.Convert.ToUInt64(va["decimal_value"]);
                    };

                    totalKeyPressRelease = FuncFillValueFromDt(dt, nameof(totalKeyPressRelease));
                    totalMousePress = FuncFillValueFromDt(dt, nameof(totalMousePress));
                    totalMouseLeftPress = FuncFillValueFromDt(dt, nameof(totalMouseLeftPress));
                    totalMouseRightPress = FuncFillValueFromDt(dt, nameof(totalMouseRightPress));
                    totalMouseWheelUp = FuncFillValueFromDt(dt, nameof(totalMouseWheelUp));
                    totalMouseWheelDown = FuncFillValueFromDt(dt, nameof(totalMouseWheelDown));
                    totalKeyPress = FuncFillValueFromDt(dt, nameof(totalKeyPress));

                    var totalWT = dt.AsEnumerable().FirstOrDefault(x => x.Field<string>("name") == (nameof(TotalWorkStopWatch)));
                    if (totalWT == null)
                    {
                        TotalWorkStopWatch.StartOffset = null;
                    }
                    else
                    {
                        var data = totalWT["string_value"].ToString().Split(';');
                        if (data.Length != 4)
                            throw new Exception($"Duomenų bazėje netinkamai suformuota {nameof(TotalWorkStopWatch)} pradinė reikšmė");
                        TotalWorkStopWatch.StartOffset = new TimeSpan(System.Convert.ToInt32(data[0]), //days
                            System.Convert.ToInt32(data[1]), //h
                            System.Convert.ToInt32(data[2]), //m
                            System.Convert.ToInt32(data[3])); //s
                    }
                }
                catch(Exception ex)
                {
                    LogHelper.LogErrorMsg(ex);
                    throw;
                }
                #endregion LP_SYSTEM_PARAMETERS

                if (TotalWordsClass != null)
                    TotalWordsClass.Db_LoadData(); //kartu ir Writing mistakes

                base.Db_LoadData();


                if (needToStop)
                    base.StartHookWork();

                Helper.Helper.UiControls.SetText(totalKeyPressRelease.ToString(), EnumUiControlTag.TotalKeyPressRelease);
                Helper.Helper.UiControls.SetText(totalMousePress.ToString(), EnumUiControlTag.TotalMousePress);
                Helper.Helper.UiControls.SetText(totalMouseLeftPress.ToString(), EnumUiControlTag.TotalMouseLeftPress);
                Helper.Helper.UiControls.SetText(totalMouseRightPress.ToString(), EnumUiControlTag.TotalMouseRightPress);
                Helper.Helper.UiControls.SetText(totalMouseWheelUp.ToString(), EnumUiControlTag.TotalMouseWheelUp);
                Helper.Helper.UiControls.SetText(totalMouseWheelDown.ToString(), EnumUiControlTag.TotalMouseWheelDown);
                Helper.Helper.UiControls.SetText(totalKeyPress.ToString(), EnumUiControlTag.TotalKeyPress);
            }
            catch
            {
                throw;
            }
        }

        public void Db_DeleteDataFromDatabase()
        {
            try
            {
                bool needToStop = base.Working;
                if (needToStop)
                    base.StopHookWork();
                
                #region KP_SYSTEM_PARAMETERS
                try
                {
                    string sql_del_KP_SYSTEM_PARAMETERS = $@"DELETE FROM KP_SYSTEM_PARAMETERS WHERE user_record_id = {DBHelper.UserId} AND name IN ('{nameof(totalKeyPressRelease)}', '{nameof(totalMousePress)}', '{nameof(totalMouseLeftPress)}', '{nameof(totalMouseRightPress)}', '{nameof(totalMouseWheelUp)}', '{nameof(totalMouseWheelDown)}', '{nameof(totalKeyPress)}', '{nameof(TotalWorkStopWatch)}');";
                    var result = DBHelper.ExecSqlDb(sql_del_KP_SYSTEM_PARAMETERS, true);
                    if (result != "OK")
                        throw new Exception($"Failed {nameof(KeyboardPressTracking)} {nameof(Db_DeleteDataFromDatabase)} [KP_SYSTEM_PARAMETERS]: {result} (sql: {sql_del_KP_SYSTEM_PARAMETERS})");
                }
                catch(Exception ex)
                {
                    LogHelper.LogErrorMsg(ex);
                    throw;
                }
                    
                #endregion LP_SYSTEM_PARAMETERS

                if (TotalWordsClass != null)
                    TotalWordsClass.Db_DeleteDataFromDatabase(); //kartu ir Writing mistakes

                base.Db_DeleteDataFromDatabase();

                Db_DeleteDataFromLocalMemory();

                if(needToStop)
                    base.StartHookWork();
            }
            catch
            {
                throw;
            }
        }

        public void Db_DeleteDataFromLocalMemory()
        {
            try
            {
                bool needToStop = base.Working;
                if(needToStop)
                    base.StopHookWork();

                #region KP_SYSTEM_PARAMETERS
                totalKeyPressRelease = 0;
                totalMousePress = 0;
                totalMouseLeftPress = 0;
                totalMouseRightPress = 0;
                totalMouseWheelUp = 0;
                totalMouseWheelDown = 0;
                totalKeyPress = 0;
                TotalWorkStopWatch.StartOffset = null;
                TotalWorkStopWatch.Restart();
                #endregion

                if (TotalWordsClass != null)
                    TotalWordsClass.Db_DeleteDataFromLocalMemory(); //kartu ir Writing mistakes

                base.Db_DeleteDataFromLocalMemory();

                if(needToStop)
                    base.StartHookWork();

                Helper.Helper.UiControls.SetText(totalKeyPressRelease.ToString(), EnumUiControlTag.TotalKeyPressRelease);
                Helper.Helper.UiControls.SetText(totalMousePress.ToString(), EnumUiControlTag.TotalMousePress);
                Helper.Helper.UiControls.SetText(totalMouseLeftPress.ToString(), EnumUiControlTag.TotalMouseLeftPress);
                Helper.Helper.UiControls.SetText(totalMouseRightPress.ToString(), EnumUiControlTag.TotalMouseRightPress);
                Helper.Helper.UiControls.SetText(totalMouseWheelUp.ToString(), EnumUiControlTag.TotalMouseWheelUp);
                Helper.Helper.UiControls.SetText(totalMouseWheelDown.ToString(), EnumUiControlTag.TotalMouseWheelDown);
                Helper.Helper.UiControls.SetText(totalKeyPress.ToString(), EnumUiControlTag.TotalKeyPress);
            }
            catch
            {
                throw;
            }
        }

        #endregion

    }
}
