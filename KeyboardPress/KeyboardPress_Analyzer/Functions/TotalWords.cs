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
        private ulong totalWords;
        private ulong wordsWithMistakes;

        private List<string> tmpWrdsList = new List<string>();

        public TotalWords()
        {
            totalWords = 0;
            wordsWithMistakes = 0;
        }
        
        public ulong TotalWordsCount
        {
            get { return totalWords; }
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
                int[] strArr = new int[] { 9, 13, 32, 46, 44, 63, 33, 58, 59, 91, 93, 123, 125, 34, 61, 60, 62, 47, 42, 45, 43, 95, 64 }; // tab enter space . , ? ! : ; [ ] { } = < / " * + @ // to do: papildyti: ... ir kt.simboliais pamastyti apie smailus
                if (strArr.Contains(lastRecord?.KeyValue ?? 0))
                {
                    var lst_NLastKeyPressInSameWindow = NLastKeyPressInSameWindow.Reverse().ToList();
                    lst_NLastKeyPressInSameWindow.RemoveAt(0);
                    if (lst_NLastKeyPressInSameWindow.Count() > 0)
                    {
                        var before = totalWords;

                        string wrd = "";
                        int skip = 0;
                        bool wasSkip = false;

                        int insertLetterPosition = 0;
                        //int arrowUp = 0;
                        //int arrowDown = 0;


                        foreach (var item in lst_NLastKeyPressInSameWindow)
                        {
                            if (!strArr.Contains(item?.KeyValue ?? 0))
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
                                totalWords++;
                                if (wasSkip)
                                {
                                    wordsWithMistakes++;

                                    //AddMistake(wrd, );
                                }
                                Helper.Helper.UiControls.SetText(totalWords.ToString(), EnumUiControlTag.TotalWords);
                                Helper.Helper.UiControls.SetText(wrd, EnumUiControlTag.LastWord);
                                Helper.Helper.UiControls.SetText(wordsWithMistakes.ToString(), EnumUiControlTag.LastWordMistake);
                                tmpWrdsList.Add(wrd);
                                break;
                            }
                        }
                        
                        if (before != totalWords)
                        {
                            DebugHelper.AddInfoMsg($"Iš viso žodžių: {totalWords.ToString()} paskutinis: {wrd}");

                            System.Diagnostics.Debug.WriteLine("total words: " + totalWords.ToString() + " last word: " + wrd);
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
        /// rašymo tikslumas
        /// </summary>
        private void CountAccuracy()
        {
            try
            {

            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
        }

    }
}
