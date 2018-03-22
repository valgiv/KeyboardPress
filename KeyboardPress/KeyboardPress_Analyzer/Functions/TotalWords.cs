using KeyboardPress_Analyzer.Helper;
using KeyboardPress_Analyzer.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeyboardPress_Analyzer.Functions
{
    public class TotalWords : WritingMistakes
    {
        //private ulong totalWords_v1;
        //private ulong wordsWithMistakes_v1;
        //private List<string> tmpWrdsList_v1 = new List<string>();

        private ulong totalWords_v2;
        private ulong wordsWithMistakes_v2;
        private List<string> tmpWrdsList_v2 = new List<string>();

        public TotalWords()
        {
            //totalWords_v1 = 0;
            //wordsWithMistakes_v1 = 0;
            totalWords_v2 = 0;
            wordsWithMistakes_v2 = 0;
        }
        
        //public ulong TotalWordsCount_v1
        //{
        //    get { return totalWords_v1; }
        //}

        public ulong TotalWordsCount_v2
        {
            get { return totalWords_v2; }
        }

        public ulong WordsWithMistakes_v2
        {
            get { return wordsWithMistakes_v2; }
        }

        /*
        /// <summary>
        /// Counting total words - always works in other thread/task (counts word when word end's)
        /// </summary>
        /// <param name="lastRecord"></param>
        /// <param name="NLastKeyPressInSameWindow"></param>
        public void totalWordsCount(ObjEvent_key lastRecord, ObjEvent_key[] NLastKeyPressInSameWindow)
        {
            try
            {
                if (Constants.WordEndSymbolArr.Contains(lastRecord?.KeyValue ?? 0))
                {
                    var lst_NLastKeyPressInSameWindow = NLastKeyPressInSameWindow.Reverse().ToList();
                    lst_NLastKeyPressInSameWindow.RemoveAt(0);
                    if (lst_NLastKeyPressInSameWindow.Count() > 0)
                    {
                        var before = totalWords_v1;

                        string wrd = "";
                        int skip = 0;
                        bool wasSkip = false;

                        int insertLetterPosition = 0;
                        //int arrowUp = 0;
                        //int arrowDown = 0;


                        foreach (var item in lst_NLastKeyPressInSameWindow)
                        {
                            if (!Constants.WordEndSymbolArr.Contains(item?.KeyValue ?? 0))
                            {
                                if (item.Key.Length == 1 && (int)((char)item.Key[0]) == 8)
                                {
                                    skip++;
                                }
                                else if (item.Key.Length == 1)
                                {
                                    if (skip == 0)
                                    {
                                        wrd = wrd.Insert(insertLetterPosition, item.Key.ToString());
                                        insertLetterPosition++;
                                    }
                                    else
                                    {
                                        skip--;
                                        wasSkip = true;
                                    }
                                }
                                else
                                {
                                    if (item.Key == "Down")
                                    {
                                        return;
                                    }
                                    else if (item.Key == "Up")
                                    {
                                        return;
                                    }
                                    else if(item.Key == "Left")
                                    {

                                    }
                                    else if(item.Key == "Right")
                                    {

                                    }
                                    else if(item.Key == "End")
                                    {

                                    }
                                    else if(item.Key == "Home")
                                    {
                                        return;
                                    }
                                }
                            }
                            else
                            {
                                break;
                            }
                        }

                        #region kad nefiksuotų smailo kaip žodžio
                        char[] smilesChars = new char[] { ';', ':', '-' };
                        if (wrd.Length == 2 && smilesChars.Contains(wrd[0]))
                            return;
                        #endregion

                        var tmp = wrd.ToCharArray();
                        Array.Reverse(tmp);
                        wrd = new string(tmp);

                        foreach (var c in tmp)
                        {
                            int ch = (int)c;
                            if ((ch > 64 && ch < 91) || (ch > 96 && ch < 123) || Helper.Helper.ltLettersArray.Contains(ch))
                            {
                                totalWords_v1++;
                                if (wasSkip)
                                {
                                    wordsWithMistakes_v1++;

                                    //AddMistake(wrd, );
                                }
                                Helper.Helper.UiControls.SetText(totalWords_v1.ToString(), EnumUiControlTag.TotalWords);
                                Helper.Helper.UiControls.SetText(wrd, EnumUiControlTag.LastWord);
                                Helper.Helper.UiControls.SetText(wordsWithMistakes_v1.ToString(), EnumUiControlTag.LastWordMistake);
                                tmpWrdsList_v1.Add(wrd);
                                break;
                            }
                        }
                        
                        if (before != totalWords_v1)
                        {
                            DebugHelper.AddInfoMsg($"Iš viso žodžių: {totalWords_v1.ToString()} paskutinis: {wrd}");

                            System.Diagnostics.Debug.WriteLine("total words: " + totalWords_v1.ToString() + " last word: " + wrd);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, $"Error on {nameof(totalWordsCount)}");
                Console.WriteLine(ex.Message);
            }
        }
        */

        /// <summary>
        /// V2 Counting total words - always works in other thread/task (counts word when word end's)
        /// </summary>
        /// <param name="NLastKeyPressInSameWindow">nuo paskutinio tame lange arba nuo paskutinio KeyboardButtonsToSkipWordsCount</param>
        public void totalWordsCount_v2(ObjEvent_key[] NLastKeyPressInSameWindow)
        {
            // to do: fiksuoti klaidas
            try
            {
                bool mistake = false;
                if (NLastKeyPressInSameWindow == null || NLastKeyPressInSameWindow.Count() == 0 || NLastKeyPressInSameWindow.Where(x=>x.EventObjDataType != EventDataType.MouseClick).Count() <= 1)
                    return;
                if (!Constants.WordEndSymbolArr.Contains(NLastKeyPressInSameWindow.LastOrDefault()?.KeyValue ?? 0))
                    return;
                if (NLastKeyPressInSameWindow.LastOrDefault().EventObjDataType != EventDataType.SymbolAsciiCode)
                    return;

                string newWord = "";
                if (true)
                {
                    string json = Newtonsoft.Json.JsonConvert.SerializeObject(NLastKeyPressInSameWindow);
                }
                int cursorPos = 0;
                int? cursorSelectBeginPos = null;
                int eventK_index = 0;
                foreach (ObjEvent_key eventK in NLastKeyPressInSameWindow)
                {
                    if (eventK == NLastKeyPressInSameWindow.Last()) // paskutinio netraukti (bet jei yra pazymetas tesktas, reikia apdoroti)
                    {
                        if (cursorSelectBeginPos != null && cursorSelectBeginPos != cursorPos)
                        {
                            newWord = newWord.Remove((int)cursorSelectBeginPos > cursorPos ? cursorPos : (int)cursorSelectBeginPos, Math.Abs((int)cursorSelectBeginPos - cursorPos));
                            mistake = true;
                        }
                        break;
                    }

                    if(eventK.EventObjDataType == EventDataType.MouseClick)
                    {
                        if (newWord.Length > 0)
                            return;
                    }

                    if (eventK.EventObjDataType == EventDataType.SymbolAsciiCode)
                    {
                        #region iterpiamas/pašalinamas simbolis
                        if (cursorSelectBeginPos == null || cursorSelectBeginPos == cursorPos)
                        {
                            #region nera selectinto teksto
                            if (eventK.KeyValue == 8)
                            {
                                // backspace:
                                if (cursorPos == 0)
                                {
                                    //return;
                                    cursorPos = 0;
                                }
                                else
                                {
                                    newWord = newWord.Remove(cursorPos - 1, 1); //cursorPos-1 arba apkeisti vietom su cursorPos--
                                    cursorPos--;
                                    mistake = false;
                                }
                            }
                            else
                            {
                                newWord = newWord.Insert(cursorPos, eventK.Key);
                                cursorPos++;
                            }
                            #endregion nera selectinto teksto
                        }
                        else
                        {
                            #region yra selectintas tekstas
                            if (eventK.KeyValue == 8)
                            {
                                // backspace:
                                newWord = newWord.Remove((int)cursorSelectBeginPos > cursorPos ? cursorPos : (int)cursorSelectBeginPos, Math.Abs((int)cursorSelectBeginPos - cursorPos));
                                cursorPos = (int)cursorSelectBeginPos > cursorPos ? cursorPos : (int)cursorSelectBeginPos;
                                cursorSelectBeginPos = null;
                                mistake = true;
                            }
                            else
                            {
                                newWord = newWord.Remove((int)cursorSelectBeginPos > cursorPos ? cursorPos : (int)cursorSelectBeginPos, Math.Abs((int)cursorSelectBeginPos - cursorPos));
                                cursorPos = (int)cursorSelectBeginPos > cursorPos ? cursorPos : (int)cursorSelectBeginPos;
                                cursorSelectBeginPos = null;

                                newWord = newWord.Insert(cursorPos, eventK.Key);
                                cursorPos++;
                            }
                            #endregion yra selectintas tekstas
                        }
                        cursorSelectBeginPos = null;
                        #endregion iterpiamas/pašalinamas simbolis
                    }
                    else if (eventK.EventObjDataType == EventDataType.KeyboardButtonCode)
                    {
                        #region keičiama kursoriaus pozicija + delete btn:
                        if (cursorSelectBeginPos == null || cursorSelectBeginPos == cursorPos)
                        {
                            #region nera selectinto teksto
                            if(eventK.KeyValue == 46)
                            {
                                //delete btn
                                if (cursorPos + 1 <= newWord.Length)
                                {
                                    newWord = newWord.Remove(cursorPos, 1);
                                    mistake = true;
                                }
                            }
                            else
                            {
                                if (!calculateCursorPos(newWord, ref cursorPos, ref cursorSelectBeginPos, eventK, eventK_index, NLastKeyPressInSameWindow))
                                {
                                    Console.WriteLine("TotalWordsCount v2 exited with false");
                                    return;
                                }
                            }
                            #endregion nera selectinto teksto
                        }
                        else
                        {
                            #region yra selectinamas tekstas
                            if (eventK.KeyValue == 46)
                            {
                                //delete btn
                                int from = cursorPos < (int)cursorSelectBeginPos ? cursorPos : (int)cursorSelectBeginPos;
                                int countLenght = Math.Abs((int)cursorSelectBeginPos - cursorPos);
                                newWord = newWord.Remove(from, countLenght);
                                cursorSelectBeginPos = null;
                                cursorPos = from;
                                mistake = true;
                            }
                            else
                            {
                                if (!calculateCursorPos(newWord, ref cursorPos, ref cursorSelectBeginPos, eventK, eventK_index, NLastKeyPressInSameWindow))
                                {
                                    Console.WriteLine("TotalWordsCount v2 exited with false");
                                    return;
                                }
                            }
                            #endregion yra selectinamas tekstas
                        }
                        #endregion keičiama kursoriaus pozicija + delete btn:
                    }
                    eventK_index++;
                }
                if(!String.IsNullOrEmpty(newWord) && newWord.Length > 0 && Regex.Matches(newWord, @"[a-zA-Z]").Count > 0)
                {
                    totalWords_v2++;
                    tmpWrdsList_v2.Add(newWord);
                    if (mistake)
                        wordsWithMistakes_v2++;

                    Helper.Helper.UiControls.SetText(totalWords_v2.ToString(), EnumUiControlTag.TotalWords);
                    Helper.Helper.UiControls.SetText(newWord, EnumUiControlTag.LastWord);
                    Helper.Helper.UiControls.SetText(wordsWithMistakes_v2.ToString(), EnumUiControlTag.TotalWordsMistakes);

                    Console.WriteLine($"TotalWordsCount v2: '{newWord}'");
                }
                else
                {
                    Console.WriteLine($"TotalWordsCount v2: neatitinka žodžio savokos '{newWord}'");

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, $"Error on {nameof(totalWordsCount_v2)}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(ex.Message);
                LogHelper.LogErrorMsg(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="word"></param>
        /// <param name="cursorPos"></param>
        /// <param name="cursorSelectBeginPos"></param>
        /// <param name="eventK"></param>
        /// <param name="eventKIndex">kad būtų galima atskirti būsimus veikmus</param>
        /// <param name="nLastKeyPressInSameWindow">kad būtų galima atskirti būsimus veikmus (kolkas nenaudojama)</param>
        private bool calculateCursorPos(string word,
            ref int cursorPos,
            ref int? cursorSelectBeginPos,
            ObjEvent_key eventK,
            int eventKIndex,
            ObjEvent_key[] nLastKeyPressInSameWindow)
        {
            if (eventK.EventObjDataType != EventDataType.KeyboardButtonCode)
                throw new ArgumentException("wrong EventObjDataType", nameof(eventK.EventObjDataType));

            if(eventK.KeyValue == 37) //left
            {
                #region left
                if (cursorPos == 0)
                    return false;
                if ((eventK.ShiftKeyPressed != null && eventK.ShiftKeyPressed == true) && (eventK.CtrlKeyPressed != null && eventK.CtrlKeyPressed == true))
                {
                    //ctrl+shift
                    if (cursorSelectBeginPos != null && cursorSelectBeginPos != cursorPos)
                    {
                        cursorPos = 0;
                    }
                    else
                    {
                        cursorSelectBeginPos = cursorPos;
                        cursorPos = 0;
                    }
                }
                else if ((eventK.ShiftKeyPressed != null && eventK.ShiftKeyPressed == true) && (eventK.CtrlKeyPressed == null || eventK.CtrlKeyPressed == false))
                {
                    //shift
                    if (cursorSelectBeginPos != null && cursorSelectBeginPos != cursorPos)
                    {
                        cursorPos--;
                        if (cursorPos == cursorSelectBeginPos)
                            cursorSelectBeginPos = null;
                    }
                    else
                    {
                        cursorSelectBeginPos = cursorPos;
                        cursorPos--;
                    }
                }
                else if((eventK.ShiftKeyPressed == null || eventK.ShiftKeyPressed == false) && (eventK.CtrlKeyPressed != null && eventK.CtrlKeyPressed == true))
                {
                    //ctrl
                    cursorSelectBeginPos = null;
                    cursorPos = 0;
                }
                else
                {
                    if(cursorSelectBeginPos != null && cursorSelectBeginPos != cursorPos)
                    {
                        cursorPos--;
                    }
                    else
                    {
                        cursorPos--;
                    }
                    cursorSelectBeginPos = null;
                }
                #endregion
            }
            else if(eventK.KeyValue == 39)//right
            {
                #region right
                if (cursorPos == word.Length)
                    return false;

                if ((eventK?.ShiftKeyPressed ?? false == true) && (eventK?.CtrlKeyPressed ?? false == true))
                {
                    //ctrl+shift
                    if (cursorSelectBeginPos != null && cursorSelectBeginPos != cursorPos)
                    {
                        cursorPos = word.Length;
                    }
                    else
                    {
                        cursorSelectBeginPos = cursorPos;
                        cursorPos = word.Length;
                    }
                }
                else if ((eventK?.ShiftKeyPressed ?? false == true) && (eventK?.CtrlKeyPressed ?? false == false))
                {
                    //shift
                    if (cursorSelectBeginPos != null && cursorSelectBeginPos != cursorPos)
                    {
                        cursorPos++;
                        if (cursorPos == cursorSelectBeginPos)
                            cursorSelectBeginPos = null;
                    }
                    else
                    {
                        cursorSelectBeginPos = cursorPos;
                        cursorPos++;
                    }
                }
                else if ((eventK?.ShiftKeyPressed ?? false == false) && (eventK?.CtrlKeyPressed ?? false == true))
                {
                    //ctrl
                    cursorSelectBeginPos = null;
                    cursorPos = word.Length;
                }
                else
                {
                    if (cursorSelectBeginPos != null && cursorSelectBeginPos != cursorPos)
                    {
                        cursorPos++;
                    }
                    else
                    {
                        cursorPos++;
                    }
                    cursorSelectBeginPos = null;
                }
                #endregion
            }
            else
            {
                return false;
            }

            return true;
        }


    }
}
