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
        private const int lastRecordsToCheck = 25;

        private ulong totalKeyPress;
        private ulong totalMousePress;
        private ulong totalWords;
        private ulong totalMouseWheelUp;
        private ulong totalMouseWheelDown;

        private KeyValuePair<string, string>[] offerWordTemplate_pairs;
        private RestReminder restReminder;

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
                return totalWords;
            }

            set
            {
                totalWords = value;
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

        private NotifyIcon notifyIcon;

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

        public KeyboardPressTracking(NotifyIcon NotifyIcon) : base()
        {
            totalKeyPress = 0;
            totalMousePress = 0;
            totalWords = 0;
            totalMouseWheelUp = 0;
            totalMouseWheelDown = 0;

            notifyIcon = NotifyIcon;
            
            offerWordTemplate_pairs = new KeyValuePair<string, string>[]
            {
                new KeyValuePair<string, string>("aa", "labaaaasRytas"),
                new KeyValuePair<string, string>("abrikosas", "ananasas"),
                new KeyValuePair<string, string>("greta", "pyyypsikė")
            };
        }

        protected override void GlobalHookKeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                base.GlobalHookKeyUp(sender, e);

                if (totalKeyPress < ulongMax)
                    totalKeyPress++;
                else if (DebugLog)
                    IDebugLogHelper.AddErrorMsg("Pasiektas maksimalus sumuojamas klavišų paspaudimų kiekis");

                WorkInProgress();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, $"Error on {nameof(GlobalHookKeyUp)}");
            }
        }

        /// <summary>
        /// Apsoliučia visi mygtukų paspaudimai (nuspaudimai)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void GlobalHookKeyDown(object sender, KeyEventArgs e)
        {
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
                base.GlobalHookKeyPress(sender, e);

                ObjEvent_key lastRec;
                ObjEvent_key[] lastNRecInSameWin;
                lock (KeysCharsEvents)
                {
                    lastRec = KeysCharsEvents.LastOrDefault();
                    lastNRecInSameWin = Helper.Helper.TakeLast(KeysCharsEvents.Where(x => x.activeWindowName == lastRec.activeWindowName), lastRecordsToCheck).ToArray();
                }

                // Atskiroje gijoje sumuoja žodžius
                var t_totalWordsCount = new Task(() => { totalWordsCount(lastRec, lastNRecInSameWin); });
                t_totalWordsCount.Start();

                // Atskiroje gijoje žodžių keitimas
                Thread t = new Thread(() =>
                {
                    offerWordTemplate(lastNRecInSameWin);
                });
                t.SetApartmentState(ApartmentState.STA);
                t.Start();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, $"Error on {nameof(GlobalHookKeyPress)}");
            }
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
            }
            catch(Exception ex)
            {
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

        /// <summary>
        /// Counting total words - always works in other thread/task (count word when word end's)
        /// </summary>
        /// <param name="lastRecord"></param>
        /// <param name="NLastKeyPressInSameWindow"></param>
        private void totalWordsCount(ObjEvent_key lastRecord, ObjEvent_key[] NLastKeyPressInSameWindow)
        {
            try
            {
                int[] strArr = new int[] { 9, 13, 32, 46, 44,63, 33, 58, 59, 91, 93, 123, 125, 34, 61, 60, 62, 47, 42, 45, 43, 95, 64 }; // tab enter space . , ? ! : ; [ ] { } = < / " * + @ // to do: papildyti: ... ir kt.simboliais pamastyti apie smailus
                if (strArr.Contains(lastRecord.keyValue))
                {
                    var lst_NLastKeyPressInSameWindow = NLastKeyPressInSameWindow.Reverse().ToList();
                    lst_NLastKeyPressInSameWindow.RemoveAt(0);
                    if(lst_NLastKeyPressInSameWindow.Count() > 0)
                    {
                        var before = totalWords;

                        string wrd = "";
                        int skip = 0;
                        foreach (var item in lst_NLastKeyPressInSameWindow)
                        {
                            if (!strArr.Contains(item.keyValue))
                            {
                                if ((int)((char)item.key) == 8)
                                {
                                    skip++;
                                }
                                else
                                {
                                    if (skip == 0)
                                        wrd += item.key.ToString();
                                    else
                                        skip--;
                                }
                            }
                            else
                            {
                                break;
                            }
                        }

                        //kad nefiksuotų smailo kaip žodžio
                        char[] smilesChars = new char[] { ';', ':', '-' };
                        if (wrd.Length == 2 && smilesChars.Contains(wrd[0]))
                            return;

                        var tmp = wrd.ToCharArray();
                        Array.Reverse(tmp);
                        wrd = new string(tmp);

                        foreach(var c in tmp)
                        {
                            int ch = (int)c;
                            if ((ch > 64 && ch < 91) || (ch > 96 && ch < 123) || Helper.Helper.ltLettersArray.Contains(ch))
                            {
                                totalWords++;
                                break;
                            }
                        }
                        
                        if (before != totalWords)
                        {
                            if (DebugLog)
                                IDebugLogHelper.AddInfoMsg($"Iš viso žodžių: {totalWords.ToString()} paskutinis: {wrd}");
                            
                            System.Diagnostics.Debug.WriteLine("total words: " + totalWords.ToString() + " last word: " + wrd);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, $"Error on {nameof(totalWordsCount)}");
                Console.WriteLine(ex.Message);
            }
        }

        private void offerWordTemplate(ObjEvent_key[] NLastKeyPressInSameWindow)
        {
            try
            {
                if (offerWordTemplate_pairs != null && offerWordTemplate_pairs.Count() > 0)
                {
                    int maxLettersToCheck = 10;
                    int symbolToConfimOffer = 9;//// tab '\t'
                    bool confirm = NLastKeyPressInSameWindow[NLastKeyPressInSameWindow.Length - 1].keyValue == symbolToConfimOffer;

                    string lastSymbols = "";
                    foreach (var s in NLastKeyPressInSameWindow)
                    {
                        lastSymbols += s.key.ToString();
                    }
                    if (confirm)
                    {
                        lastSymbols = lastSymbols.Remove(lastSymbols.Length - 1, 1);
                    }
                    System.Diagnostics.Debug.WriteLine("offetWordTemplate: " + lastSymbols);
                    for (int i = 1; i < maxLettersToCheck && i < lastSymbols.Length; i++)
                    {
                        string strLet = lastSymbols.Remove(0, lastSymbols.Length - 1 - i);
                        var pair = offerWordTemplate_pairs.FirstOrDefault(x => x.Key.ToLower() == strLet.ToLower());
                        if (!String.IsNullOrEmpty(pair.Key) && !String.IsNullOrEmpty(pair.Value))
                        {
                            if (!confirm)
                            {
                                notifyIcon.ShowBalloonTip(1000, "", $"Siūlomas tekstas: {pair.Value}", ToolTipIcon.Info); // to do: reikia pamastyti kaip uzdaryti siulymus
                                System.Diagnostics.Debug.WriteLine("offetWordTemplate atitikmuo: " + pair.Value);
                                return;
                            }
                            else
                            {
                                System.Windows.Forms.Application.DoEvents();
                                KeyboardControlAdapter.pressAndReleaseButton(VirtualKeysEnum.VK_BACK);
                                for (int z = 0; z < ((KeyValuePair<string, string>)pair).Key.Length; z++)
                                {
                                    KeyboardControlAdapter.pressAndReleaseButton(VirtualKeysEnum.VK_BACK);
                                }
                                KeyboardControlAdapter.pasteText(((KeyValuePair<string, string>)pair).Value, true);
                                
                                return;
                            }
                        }
                        else
                        {
                            notifyIcon.Visible = true;
                        }
                    }
                }
                return;
            }
            catch (Exception ex)
            {

                return;
            }
        }

        //del sito reikia daugiau pamastyti i kuria struktura ziureti
        //public string[] mostMistakesAfterLetters(int lettersBefore)
        //{
        //    try
        //    {
        //        EventObj_key[] tempData;
        //        lock (KeysCharsEvents)
        //        {
        //            tempData = new EventObj_key[KeysCharsEvents.Count - 1];
        //            KeysCharsEvents.CopyTo(tempData);
        //        }

        //        List<string> result = new List<string>();
        //        foreach(var item in tempData)
        //        {
        //            //if(item.)
        //        }
        //        return result.ToArray();
        //    }
        //    catch(Exception ex)
        //    {
        //        MessageBox.Show($"Klaida ieškant po kokių simbolių junginių dažniausiai daromos klaidos\n{ex.Message}");
        //        Helper.LogHelper.LogErrorMsg(ex.Message);
        //        return null;
        //    }
        //}

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
            if (totalWords == 0 || StopWach.ElapsedMilliseconds == 0)
                return 0;

            return totalWords / TimeSpan.FromMilliseconds(StopWach.ElapsedMilliseconds).TotalMinutes;
        }

        public double countAvrgWordsPerHour()
        {
            if (totalWords == 0 || StopWach.ElapsedMilliseconds == 0)
                return 0;

            return TimeSpan.FromMilliseconds(StopWach.ElapsedMilliseconds).TotalHours;
        }

        #endregion count avrg

    }
}
