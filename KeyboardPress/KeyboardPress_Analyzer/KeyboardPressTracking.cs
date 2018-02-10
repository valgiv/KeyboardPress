using KeyboardPress_Analyzer.Functions;
using KeyboardPress_Analyzer.Helper;
using KeyboardPress_Analyzer.Objects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeyboardPress_Analyzer
{
    public class KeyboardPressTracking : KeyboardPressAdapter
    {
        private const ulong ulongMax = ulong.MaxValue;
        private const int lastRecordsToCheck = 30;
        private const int maxLastRecordToCheckForWord = 40;

        private ulong totalKeyPress;
        private ulong totalMousePress;
        
        private ulong totalMouseWheelUp;
        private ulong totalMouseWheelDown;
        
        private RestReminder restReminder;

        private NotifyIcon notifyIcon;

        private TotalWords TotalWordsClass;
        private OfferWord OfferWordClass;

        public List<object> UiControls;

        #region get set
        public ulong TotalKeyPress
        {
            get
            {
                return totalKeyPress;
            }
            set
            {
                totalKeyPress = value;
            }
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

        public void Reload_OfferWordClass_Data()
        {
            if (OfferWordClass != null)
                OfferWordClass.reloadOfferWord();
        }
        #endregion

        #region interface overrides
        public override void CleanData()
        {
            base.CleanData();
        }

        public override void StopHookWork()
        {
            base.StopHookWork();

            if (restReminder != null)
                restReminder.Stop();
        }

        public override void StartHookWork()
        {
            base.StartHookWork();

            if (restReminder == null)
                restReminder = new RestReminder();
            restReminder.TimeToRest += RestReminder_TimeToRest;
            restReminder.Start();
        }
        #endregion

        #region Rest reminder
        private void RestReminder_TimeToRest(object sender, EventArgs e)
        {
            notifyIcon.ShowBalloonTip(1000, "restTime", "restTime", ToolTipIcon.Warning);
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
            totalKeyPress = 0;
            totalMousePress = 0;
            totalMouseWheelUp = 0;
            totalMouseWheelDown = 0;
            
            notifyIcon = NotifyIcon;

            TotalWordsClass = new TotalWords();
            OfferWordClass = new OfferWord(NotifyIcon);
        }
        #endregion

        #region overrides
        protected override void GlobalHookKeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                base.GlobalHookKeyUp(sender, e);

                if (totalKeyPress < ulongMax)
                    totalKeyPress++;
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
                    ActiveWindowName = Helper.Helper.GetActiveWindowTitle_v2(),
                    ShiftKeyPressed = e.Shift,
                    CtrlKeyPressed = e.Control,
                    EventObjType = EventType.KeyPress,
                    KeyValue = e.KeyValue,
                    EventObjDataType = EventDataType.KeyboardButtonCode,
                    Key = e.KeyCode.ToString()
                };
                Add_ObjEvent_key(a);
            }
            
            try
            {
                base.GlobalHookKeyDown(sender, e);
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, $"Error on {nameof(GlobalHookKeyDown)}");
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
                // nice to have: ar bazineje klaseje netruksta lock'o?
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
                }
                WorkInProgress();

                //pelės paspaudimas gali keisti kursoriaus poziciją
                var a = new ObjEvent_key()
                {
                    ActiveWindowName = Helper.Helper.GetActiveWindowTitle_v2(),
                    ShiftKeyPressed = null,
                    CtrlKeyPressed = null,
                    EventObjType = EventType.KeyPress, //nes naudojamas bus ten kur generuojamos zodis
                    KeyValue = -1,
                    EventObjDataType = EventDataType.MouseClick,
                    Key = "MouseClick"
                };
                Add_ObjEvent_key(a);
            }
            catch(Exception ex)
            {
                LogHelper.LogErrorMsg(ex);
                MessageBox.Show(ex.Message, $"Error on {nameof(GlobalHookMouseDown)}");
            }
        }

        protected override void GlobalHook_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
                totalMouseWheelUp++;
            else
                totalMouseWheelDown++;

            WorkInProgress();
        }
        #endregion

        

        #region count avrg

        public double countAvrgPressPerMin()
        {
            if (KeysEvents.LongCount() == 0 || StopWach.ElapsedMilliseconds == 0)
                return 0;
            
            return KeysEvents.LongCount() / TimeSpan.FromMilliseconds(StopWach.ElapsedMilliseconds).TotalMinutes;
        }

        public double countAvrgPressPerHour()
        {
            if (KeysEvents.LongCount() == 0 || StopWach.ElapsedMilliseconds == 0)
                return 0;

            return KeysEvents.LongCount() / TimeSpan.FromMilliseconds(StopWach.ElapsedMilliseconds).TotalHours;
        }

        public double countAvrgMousePressPerMin()
        {
            if (totalMousePress == 0 || StopWach.ElapsedMilliseconds == 0)
                return 0;

            return totalMousePress / TimeSpan.FromMilliseconds(StopWach.ElapsedMilliseconds).TotalMinutes;
        }

        public double countAvrgMousePressPerHour()
        {
            if (totalMousePress == 0 || StopWach.ElapsedMilliseconds == 0)
                return 0;

            return totalMousePress / TimeSpan.FromMilliseconds(StopWach.ElapsedMilliseconds).TotalHours;
        }

        public double countAvrgWordsPerMin()
        {
            if (TotalWordsClass.TotalWordsCount_v2 == 0 || StopWach.ElapsedMilliseconds == 0)
                return 0;

            return TotalWordsClass.TotalWordsCount_v2 / TimeSpan.FromMilliseconds(StopWach.ElapsedMilliseconds).TotalMinutes;
        }

        public double countAvrgWordsPerHour()
        {
            if (TotalWordsClass.TotalWordsCount_v2 == 0 || StopWach.ElapsedMilliseconds == 0)
                return 0;

            return TimeSpan.FromMilliseconds(StopWach.ElapsedMilliseconds).TotalHours;
        }

        #endregion count avrg

    }
}
