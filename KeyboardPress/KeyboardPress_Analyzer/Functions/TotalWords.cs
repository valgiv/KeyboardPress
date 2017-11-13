using KeyboardPress_Analyzer.Helper;
using KeyboardPress_Analyzer.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeyboardPress_Analyzer.Functions
{
    public class TotalWords : WritingMistakes
    {
        private ulong totalWords_v1;
        private ulong wordsWithMistakes_v1;

        private List<string> tmpWrdsList_v1 = new List<string>();

        public TotalWords()
        {
            totalWords_v1 = 0;
            wordsWithMistakes_v1 = 0;
        }
        
        public ulong TotalWordsCount_v1
        {
            get { return totalWords_v1; }
        }

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
                                    // to do: reikia ka=kaip apmastyti vaiksiojima su rodyklemis ir t.t.
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="NLastKeyPressInSameWindow">nuo paskutinio tame lange arba nuo paskutinio KeyboardButtonsToSkipWordsCount</param>
        public void totalWordsCount_v2(ObjEvent_key[] NLastKeyPressInSameWindow)
        {
            try
            {
                if (NLastKeyPressInSameWindow == null || NLastKeyPressInSameWindow.Count() == 0)
                    return;
                if (!Constants.WordEndSymbolArr.Contains(NLastKeyPressInSameWindow.LastOrDefault()?.KeyValue ?? 0))
                    return;
                if (NLastKeyPressInSameWindow.LastOrDefault().EventObjDataType != EventDataType.SymbolAsciiCode)
                    return;

                string newWord = "";
                int cursorPos = 0;
                bool containsLetters = false;
                int? cursorBeginPos = null;
                foreach(ObjEvent_key eventK in NLastKeyPressInSameWindow)
                {
                    // to do: cia daryti
                    if(eventK.EventObjDataType == EventDataType.SymbolAsciiCode)
                    {

                    }
                    else if(eventK.EventObjDataType == EventDataType.KeyboardButtonCode)
                    {

                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, $"Error on {nameof(totalWordsCount_v2)}");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
