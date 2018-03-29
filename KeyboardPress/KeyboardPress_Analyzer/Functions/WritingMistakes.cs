using KeyboardPress_Analyzer.Helper;
using KeyboardPress_Analyzer.Objects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyboardPress_Analyzer.Functions
{
    public class WritingMistakes : IDatabase
    {
        private object locker = new object();

        /// <summary>
        /// KP_MISTAKE_CHAR
        /// </summary>
        public List<ObjMistakeChar> MistakesChar { get; set; }
        //public List<ObjMistakeString> MistakesString { get; set; }

        public WritingMistakes()
        {
            MistakesChar = new List<ObjMistakeChar>();
            //MistakesString = new List<ObjMistakeString>();
        }

        //protected void AddMistake(string correctWord, Tuple<string, string>[] strings)
        //{
        //    lock (locker)
        //    {
        //        var m = Mistakes.FirstOrDefault(x => x.Word == correctWord.ToLower());

        //        foreach (var pair in strings)
        //        {
        //            if (pair.Item1.ToLower() != pair.Item2.ToLower() && pair.Item2 != "")
        //            {
        //                if (m != null)
        //                    m.ModifiedCharacters.Add(new Tuple<string, string>(pair.Item1, pair.Item2));
        //                else
        //                {
        //                    m = new ObjMistake()
        //                    {
        //                        Word = correctWord.ToLower()
        //                    };
        //                    m.ModifiedCharacters.Add(new Tuple<string, string>(pair.Item1, pair.Item2));
        //                    Mistakes.Add(m);
        //                }
        //            }
        //        }
        //    }
        //}

        protected void AddCharMistake(ObjMistakeChar obj)
        {
            try
            {
                if (obj == null)
                    return;
                
                lock (locker)
                {
                    MistakesChar.Add(obj);
                }
            }
            catch(Exception ex)
            {
                LogHelper.LogErrorMsg(ex);
            }
        }

        protected void AddCharMistake(char? beforeRemovedChar,
            char removedChar,
            char? changedChar)
            {

            Console.WriteLine($"AddCharMistake: {(beforeRemovedChar == null ? "null" : beforeRemovedChar.ToString())}, {removedChar.ToString()}, {(changedChar == null ? "null" : changedChar.ToString())}");
            AddCharMistake(new ObjMistakeChar()
            {
                BeforeRemovedChar = beforeRemovedChar,
                ChangedChar = changedChar,
                RemovedChar = removedChar,
                EventTime = DateTime.Now
            });
        }

        public void Db_SaveChanges()
        {
            try
            {
                var toSave = MistakesChar.Count(x=>x.SavedInDB == false);
                if (MistakesChar.Count(x => x.SavedInDB == false) == 0)
                    return;

                
                string sql = "INSERT INTO KP_MISTAKE_CHAR (before_removed_char, removed_char, changed_char, win_id, time, user_record_id) VALUES";
                var mis = MistakesChar.Where(x => x.SavedInDB == false).ToList();
                mis.ForEach(x =>
                {
                    sql += $@"
    ('{x.BeforeRemovedChar}', '{x.RemovedChar}', '{x.ChangedChar}', null, '{x.EventTime}', {DBHelper.UserId}),";
                });
                sql = sql.Remove(sql.Length - 1, 1);
                
                var result = DBHelper.ExecSqlDb(sql, true);
                if (result != "OK")
                    throw new Exception($"Failled {nameof(WritingMistakes)}.{nameof(Db_SaveChanges)} {result} (sql: {sql})");

                mis.ForEach(x => x.SavedInDB = true);
            }
            catch(Exception ex)
            {
                LogHelper.LogErrorMsg(ex);
                throw;
            }
        }

        public void Db_LoadData()
        {
            try
            {
                MistakesChar = new List<ObjMistakeChar>();

                var dt = DBHelper.GetDataTableDb($@"
SELECT record_id, before_removed_char, removed_char, changed_char, win_id, time, user_record_id
FROM KP_MISTAKE_CHAR
WHERE user_record_id = {DBHelper.UserId}
ORDER BY record_id ASC");

                if (dt == null || dt.Rows.Count == 0)
                    return;

                dt.AsEnumerable().ToList().ForEach(x =>
                {
                    MistakesChar.Add(new ObjMistakeChar()
                    {
                        ActiveWindowName = "", //to do
                        SavedInDB = true,
                        EventTime = x.Field<DateTime>("time"),
                        RemovedChar = x.Field<string>("removed_char")[0],
                        BeforeRemovedChar = String.IsNullOrEmpty(x.Field<string>("before_removed_char")) ? (char?)null : (char?)x.Field<string>("before_removed_char")[0],
                        ChangedChar = String.IsNullOrEmpty(x.Field<string>("changed_char")) ? (char?)null : (char?)x.Field<string>("changed_char")[0]
                    });
                });
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
                string sql = $"DELETE FROM KP_MISTAKE_CHAR WHERE user_record_id = {DBHelper.UserId}";
                var result = DBHelper.ExecSqlDb(sql, true);

                if (result != "OK")
                    throw new Exception($"Failled {nameof(WritingMistakes)}.{nameof(Db_DeleteDataFromDatabase)} {result} (sql: {sql})");
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
                MistakesChar = new List<ObjMistakeChar>();
            }
            catch (Exception ex)
            {
                LogHelper.LogErrorMsg(ex);
                throw;
            }
        }
        

    }

    
}
