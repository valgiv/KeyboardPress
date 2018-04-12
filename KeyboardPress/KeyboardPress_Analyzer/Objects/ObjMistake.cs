

namespace KeyboardPress_Analyzer.Objects
{
    //public class ObjMistake : ObjDate
    //{
    //    public string Word { get; set; }   
    //}

    public class ObjMistakeChar : ObjDateWinAndDb
    {
        public char? BeforeRemovedChar { get; set; }

        public char RemovedChar { get; set; }

        public char? ChangedChar { get; set; }
    }

    //public class ObjMistakeString : ObjMistake
    //{
    //    public ObjMistakeString()
    //    {
    //        ModifiedCharacters = new List<Tuple<string, string>>();
    //    }

    //    public List<Tuple<string, string>> ModifiedCharacters { get; set; }
        
    //}

}
