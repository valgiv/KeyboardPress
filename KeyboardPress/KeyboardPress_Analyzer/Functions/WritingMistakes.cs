using KeyboardPress_Analyzer.Helper;
using KeyboardPress_Analyzer.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyboardPress_Analyzer.Functions
{
    public class WritingMistakes
    {
        private object locker = new object();
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

                obj.EventTime = DateTime.Now;

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

        

    }

    
}
