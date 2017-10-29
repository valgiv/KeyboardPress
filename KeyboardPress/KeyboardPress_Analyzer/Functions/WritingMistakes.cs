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
        public List<ObjMistake> Mistakes { get; set; }

        public WritingMistakes()
        {
            Mistakes = new List<ObjMistake>();
        }

        protected void AddMistake(string correctWord, Tuple<string, string>[] strings)
        {
            lock (locker)
            {
                var m = Mistakes.FirstOrDefault(x => x.CorrectWord == correctWord.ToLower());
                
                foreach (var pair in strings)
                {
                    if (pair.Item1.ToLower() != pair.Item2.ToLower() && pair.Item2 != "")
                    {
                        if (m != null)
                            m.ModifiedCharacters.Add(new Tuple<string, string>(pair.Item1, pair.Item2));
                        else
                        {
                            m = new ObjMistake()
                            {
                                CorrectWord = correctWord.ToLower()
                            };
                            m.ModifiedCharacters.Add(new Tuple<string, string>(pair.Item1, pair.Item2));
                            Mistakes.Add(m);
                        }
                    }
                }
            }
        }
    }

    
}
