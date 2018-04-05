using KeyboardPress_Analyzer.Helper;
using KeyboardPress_Analyzer.Objects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeyboardPress_Analyzer.Functions
{
    public class TotalWords : WritingMistakes, IDatabase
    {
        //private ulong totalWords_v1;
        //private ulong wordsWithMistakes_v1;
        //private List<string> tmpWrdsList_v1 = new List<string>();

        //to do: ar netrūksta lock'ų?
        
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
            try
            {
                bool mistake = false;
                if (NLastKeyPressInSameWindow == null || NLastKeyPressInSameWindow.Count() == 0 || NLastKeyPressInSameWindow.Where(x=>x.EventObjDataType != EventDataType.MouseClick).Count() <= 1)
                    return;
                if (!Constants.WordEndSymbolArr.Contains(NLastKeyPressInSameWindow.LastOrDefault()?.KeyValue ?? 0))
                    return;
                if (NLastKeyPressInSameWindow.LastOrDefault().EventObjDataType != EventDataType.SymbolAsciiCode)
                    return;

                #region Char mistakes
                Func<string, int, char?> Func_beforeMistakeChar = (word, indexBefChar) =>
                {
                    if(indexBefChar < 0)
                        return null;

                    return word[indexBefChar];
                };

                Func<string, int, char?> Func_afterMistakeChar = (word, indexNextObj) =>
                {
                    if(NLastKeyPressInSameWindow.Length - 1 >= indexNextObj
                    && NLastKeyPressInSameWindow.Last() != NLastKeyPressInSameWindow[indexNextObj])
                    {
                        if (NLastKeyPressInSameWindow[indexNextObj].EventObjDataType == EventDataType.KeyboardButtonCode
                            && word.Length - 1 >= indexNextObj)
                            return word[indexNextObj];
                        else if (NLastKeyPressInSameWindow[indexNextObj].EventObjDataType == EventDataType.SymbolAsciiCode)
                            return NLastKeyPressInSameWindow[indexNextObj].Key[0];
                            
                            
                    }

                    return null;
                };
                #endregion

                string newWord = "";
                //if (true)
                //{
                //    string json = Newtonsoft.Json.JsonConvert.SerializeObject(NLastKeyPressInSameWindow);
                //}
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
                                     AddCharMistake(
                                        Func_beforeMistakeChar(newWord, cursorPos - 2),
                                        newWord[cursorPos - 1],
                                        Func_afterMistakeChar(newWord, cursorPos + 1)); // +1

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
                                //if(cursorPos - cursorSelectBeginPos == 1 || cursorPos - cursorSelectBeginPos == 1)
                                if (Math.Abs(cursorPos - (int)cursorSelectBeginPos) == 1)
                                    AddCharMistake(
                                        Func_beforeMistakeChar(newWord, ((int)cursorSelectBeginPos > cursorPos ? cursorPos : (int)cursorSelectBeginPos) - 1),
                                        newWord[(int)cursorSelectBeginPos > cursorPos ? cursorPos : (int)cursorSelectBeginPos],
                                        //Func_afterMistakeChar(newWord, ((int)cursorSelectBeginPos > cursorPos ? cursorPos : (int)cursorSelectBeginPos) + 1)
                                        Func_afterMistakeChar(newWord, eventK_index + 1)
                                        );
                                //else
                                //    AddCharMistake(); // gal nereikia?

                                // backspace:
                                newWord = newWord.Remove((int)cursorSelectBeginPos > cursorPos ? cursorPos : (int)cursorSelectBeginPos, Math.Abs((int)cursorSelectBeginPos - cursorPos));
                                cursorPos = (int)cursorSelectBeginPos > cursorPos ? cursorPos : (int)cursorSelectBeginPos;
                                cursorSelectBeginPos = null;
                                mistake = true;
                            }
                            else
                            {
                                bool saveMistake = false;
                                char? befC = null;
                                char? c = null;
                                if (Math.Abs(cursorPos - (int)cursorSelectBeginPos) == 1)
                                {
                                    saveMistake = true;
                                    befC = Func_beforeMistakeChar(newWord, ((int)cursorSelectBeginPos > cursorPos ? cursorPos : (int)cursorSelectBeginPos) - 1);
                                    c = newWord[(int)cursorSelectBeginPos > cursorPos ? cursorPos : (int)cursorSelectBeginPos];
                                }

                                newWord = newWord.Remove((int)cursorSelectBeginPos > cursorPos ? cursorPos : (int)cursorSelectBeginPos, Math.Abs((int)cursorSelectBeginPos - cursorPos));
                                cursorPos = (int)cursorSelectBeginPos > cursorPos ? cursorPos : (int)cursorSelectBeginPos;
                                cursorSelectBeginPos = null;

                                newWord = newWord.Insert(cursorPos, eventK.Key);
                                cursorPos++;

                                if (saveMistake && c != null)
                                     AddCharMistake(befC,
                                         (char)c,
                                         newWord.Length - 1 >= cursorPos - 1 ? (char?)newWord[cursorPos-1] : null);
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
                                      AddCharMistake(
                                        Func_beforeMistakeChar(newWord, cursorPos -1),
                                        newWord[cursorPos],
                                        Func_afterMistakeChar(newWord, cursorPos + 1));

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
                                bool saveMistake = false;
                                char? befC = null;
                                char? c = null;
                                if (Math.Abs(cursorPos - (int)cursorSelectBeginPos) == 1)
                                { 
                                    saveMistake = true;
                                    befC = Func_beforeMistakeChar(newWord, ((int)cursorSelectBeginPos > cursorPos ? cursorPos : (int)cursorSelectBeginPos) - 1);
                                    c = newWord[(int)cursorSelectBeginPos > cursorPos ? cursorPos : (int)cursorSelectBeginPos];
                                }
                                //else
                                //    AddCharMistake(); // gal nereikia ?

                                //delete btn
                                int from = cursorPos < (int)cursorSelectBeginPos ? cursorPos : (int)cursorSelectBeginPos;
                                int countLenght = Math.Abs((int)cursorSelectBeginPos - cursorPos);
                                newWord = newWord.Remove(from, countLenght);
                                cursorSelectBeginPos = null;
                                cursorPos = from;
                                mistake = true;

                                if (saveMistake && c != null)
                                     AddCharMistake(befC,
                                         (char)c,
                                         newWord.Length - 1 >= cursorPos ? (char?)newWord[cursorPos] : null);
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

        public void Db_SaveChanges()
        {
            try
            {
                string sql = $@"
IF EXISTS (SELECT record_id FROM KP_SYSTEM_PARAMETERS WHERE user_record_id = {DBHelper.UserId} AND name = '{nameof(totalWords_v2)}')
BEGIN
    UPDATE KP_SYSTEM_PARAMETERS
        SET decimal_value = {totalWords_v2}, modified_date = '{DateTime.Now}'
    WHERE user_record_id = {DBHelper.UserId} AND name = '{nameof(totalWords_v2)}'
END
ELSE BEGIN
    INSERT INTO KP_SYSTEM_PARAMETERS (user_record_id, name, decimal_value, modified_date)
        VALUES ({DBHelper.UserId}, '{nameof(totalWords_v2)}', {totalWords_v2}, '{DateTime.Now}')
END

IF EXISTS (SELECT record_id FROM KP_SYSTEM_PARAMETERS WHERE user_record_id = {DBHelper.UserId} AND name = '{nameof(wordsWithMistakes_v2)}')
BEGIN
    UPDATE KP_SYSTEM_PARAMETERS
        SET decimal_value = {wordsWithMistakes_v2}, modified_date = '{DateTime.Now}'
    WHERE user_record_id = {DBHelper.UserId} AND name = '{nameof(wordsWithMistakes_v2)}'
END
ELSE BEGIN
    INSERT INTO KP_SYSTEM_PARAMETERS (user_record_id, name, decimal_value, modified_date)
        VALUES ({DBHelper.UserId}, '{nameof(wordsWithMistakes_v2)}', {wordsWithMistakes_v2}, '{DateTime.Now}')
END
";

                var result = DBHelper.ExecSqlDb(sql, true);
                if (result != "OK")
                    throw new Exception($"Failed {nameof(TotalWords)} {nameof(Db_SaveChanges)}: {result} (sql: {sql})");
            }
            catch(Exception ex)
            {
                LogHelper.LogErrorMsg(ex);
                throw;
            }

            base.Db_SaveChanges();
        }

        public void Db_LoadData()
        {
            try
            {
                var dt = DBHelper.GetDataTableDb($@"
SELECT
    SP.name, SP.decimal_value
FROM KP_SYSTEM_PARAMETERS SP
WHERE SP.user_record_id = {DBHelper.UserId}
    AND SP.name IN ('{nameof(totalWords_v2)}', '{nameof(wordsWithMistakes_v2)}')");

                if (dt == null)
                    throw new Exception($"Failed {nameof(TotalWords)}.{nameof(Db_LoadData)} dataload");

                var tw = dt.AsEnumerable().FirstOrDefault(x => x.Field<string>("name") == nameof(totalWords_v2));
                if (tw != null)
                    totalWords_v2 = System.Convert.ToUInt64(tw["decimal_value"]);
                else
                    totalWords_v2 = 0;

                var twm = dt.AsEnumerable().FirstOrDefault(x => x.Field<string>("name") == nameof(wordsWithMistakes_v2));
                if (twm != null)
                    wordsWithMistakes_v2 = System.Convert.ToUInt64(twm["decimal_value"]);
                else
                    wordsWithMistakes_v2 = 0;
            }
            catch(Exception ex)
            {
                LogHelper.LogErrorMsg(ex);
                throw;
            }

            base.Db_LoadData();
        }

        public void Db_DeleteDataFromDatabase()
        {
            try
            {
                string sql = $"DELETE FROM KP_SYSTEM_PARAMETERS WHERE user_record_id = {DBHelper.UserId} AND name IN ('{nameof(totalWords_v2)}', '{nameof(wordsWithMistakes_v2)}')";
                var result = DBHelper.ExecSqlDb(sql, true);
                if (result != "OK")
                    throw new Exception($"Failed {nameof(TotalWords)} {nameof(Db_DeleteDataFromDatabase)}: {result} (sql: {sql})");
            }
            catch(Exception ex)
            {
                LogHelper.LogErrorMsg(ex);
                throw;
            }

            base.Db_DeleteDataFromDatabase();

            Db_DeleteDataFromLocalMemory();
        }

        public void Db_DeleteDataFromLocalMemory()
        {
            try
            {
                totalWords_v2 = 0;
                wordsWithMistakes_v2 = 0;
            }
            catch(Exception ex)
            {
                LogHelper.LogErrorMsg(ex);
                throw;
            }

            base.Db_DeleteDataFromLocalMemory();
        }
    }
}
