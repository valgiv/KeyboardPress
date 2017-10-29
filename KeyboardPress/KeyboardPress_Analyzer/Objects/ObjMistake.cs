using System;
using System.Collections.Generic;

namespace KeyboardPress_Analyzer.Objects
{
    public class ObjMistake : ObjDate
    {
        public ObjMistake()
        {
            ModifiedCharacters = new List<Tuple<string, string>>();
        }

        public string CorrectWord { get; set; }

        public List<Tuple<string, string>> ModifiedCharacters {get;set;}

        public int MistakesCount
        {
            get
            {
                return ModifiedCharacters.Count;
            }
        }
    }
}
