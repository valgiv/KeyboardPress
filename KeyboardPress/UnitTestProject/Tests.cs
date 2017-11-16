using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KeyboardPress_Analyzer.Functions;

namespace UnitTestProject
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void Test_TotalWords_v2()
        {
            var totalWrds = new TotalWords();
            totalWrds.totalWordsCount_v2(new KeyboardPress_Analyzer.Objects.ObjEvent_key[]
            {

            });
        }
    }
}
