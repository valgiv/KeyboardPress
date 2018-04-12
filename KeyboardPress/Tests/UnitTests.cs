using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void DataBaseTest()
        {
            try
            {
                //    var a = KeyboardPress_Analyzer.Helper.Helper.GetDataSetDb("SELECT * FROM KP_USER");

                //    var b = KeyboardPress_Analyzer.Helper.Helper.GetDataSetDb($"INSERT INTO KP_USER (guid_id, name) VALUES ('{Guid.NewGuid()}', 'test2')");

                var a = System.Reflection.Assembly.GetExecutingAssembly().Location;
                var b = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
                var c = AppDomain.CurrentDomain.BaseDirectory;
                var d = System.Reflection.Assembly.GetExecutingAssembly().Location;

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
