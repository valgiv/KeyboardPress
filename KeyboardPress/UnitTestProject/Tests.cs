using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KeyboardPress_Analyzer.Functions;
using KeyboardPress_Analyzer.Objects;
using System.Collections.Generic;
using KeyboardPress_Analyzer.Helper;

using System.Diagnostics;

namespace UnitTestProject
{
    [TestClass]
    public class Tests
    {
        /// <summary>
        /// vedami simboliai: [backspace] l a a <-- b --> s
        /// </summary>
        [TestMethod]
        public void Test_TotalWords_v2_1()
        {
            var totalWrds = new TotalWords();
            totalWrds.totalWordsCount_v2(new KeyboardPress_Analyzer.Objects.ObjEvent_key[]
            {
                new KeyboardPress_Analyzer.Objects.ObjEvent_key()
                {
                    CtrlKeyPressed = null,
                    EventObjDataType = KeyboardPress_Analyzer.Objects.EventDataType.SymbolAsciiCode,
                    EventObjType = KeyboardPress_Analyzer.Objects.EventType.KeyPress,
                    EventTime = DateTime.Now,
                    Key = "\b",
                    KeyValue = 8,
                    ShiftKeyPressed = null
                },
                new KeyboardPress_Analyzer.Objects.ObjEvent_key()
                {
                    CtrlKeyPressed = null,
                    EventObjDataType = KeyboardPress_Analyzer.Objects.EventDataType.SymbolAsciiCode,
                    EventObjType = KeyboardPress_Analyzer.Objects.EventType.KeyPress,
                    EventTime = DateTime.Now,
                    Key = "l",
                    KeyValue = 108,
                    ShiftKeyPressed = null
                },
                new KeyboardPress_Analyzer.Objects.ObjEvent_key()
                {
                    CtrlKeyPressed = null,
                    EventObjDataType = KeyboardPress_Analyzer.Objects.EventDataType.SymbolAsciiCode,
                    EventObjType = KeyboardPress_Analyzer.Objects.EventType.KeyPress,
                    EventTime = DateTime.Now,
                    Key = "a",
                    KeyValue = 97,
                    ShiftKeyPressed = null
                },
                new KeyboardPress_Analyzer.Objects.ObjEvent_key()
                {
                    CtrlKeyPressed = null,
                    EventObjDataType = KeyboardPress_Analyzer.Objects.EventDataType.SymbolAsciiCode,
                    EventObjType = KeyboardPress_Analyzer.Objects.EventType.KeyPress,
                    EventTime = DateTime.Now,
                    Key = "a",
                    KeyValue = 97,
                    ShiftKeyPressed = null
                },
                new KeyboardPress_Analyzer.Objects.ObjEvent_key()
                {
                    CtrlKeyPressed = null,
                    EventObjDataType = KeyboardPress_Analyzer.Objects.EventDataType.KeyboardButtonCode,
                    EventObjType = KeyboardPress_Analyzer.Objects.EventType.KeyPress,
                    EventTime = DateTime.Now,
                    Key = "Left",
                    KeyValue = 37,
                    ShiftKeyPressed = false
                },
                new KeyboardPress_Analyzer.Objects.ObjEvent_key()
                {
                    CtrlKeyPressed = null,
                    EventObjDataType = KeyboardPress_Analyzer.Objects.EventDataType.SymbolAsciiCode,
                    EventObjType = KeyboardPress_Analyzer.Objects.EventType.KeyPress,
                    EventTime = DateTime.Now,
                    Key = "b",
                    KeyValue = 98,
                    ShiftKeyPressed = null
                },
                new KeyboardPress_Analyzer.Objects.ObjEvent_key()
                {
                    CtrlKeyPressed = null,
                    EventObjDataType = KeyboardPress_Analyzer.Objects.EventDataType.KeyboardButtonCode,
                    EventObjType = KeyboardPress_Analyzer.Objects.EventType.KeyPress,
                    EventTime = DateTime.Now,
                    Key = "Right",
                    KeyValue = 39,
                    ShiftKeyPressed = false
                },
                new KeyboardPress_Analyzer.Objects.ObjEvent_key()
                {
                    CtrlKeyPressed = null,
                    EventObjDataType = KeyboardPress_Analyzer.Objects.EventDataType.SymbolAsciiCode,
                    EventObjType = KeyboardPress_Analyzer.Objects.EventType.KeyPress,
                    EventTime = DateTime.Now,
                    Key = "s",
                    KeyValue = 115,
                    ShiftKeyPressed = null
                },
                new KeyboardPress_Analyzer.Objects.ObjEvent_key()
                {
                    CtrlKeyPressed = null,
                    EventObjDataType = KeyboardPress_Analyzer.Objects.EventDataType.SymbolAsciiCode,
                    EventObjType = KeyboardPress_Analyzer.Objects.EventType.KeyPress,
                    EventTime = DateTime.Now,
                    Key = " ",
                    KeyValue = 32,
                    ShiftKeyPressed = null
                }
            });
        }

        /// <summary>
        /// l a [shift+kaire] b
        /// </summary>
        [TestMethod]
        public void Test_TotalWords_v2_2()
        {
            var totalWrds = new TotalWords();
            totalWrds.totalWordsCount_v2(new KeyboardPress_Analyzer.Objects.ObjEvent_key[]
            {
                
                new KeyboardPress_Analyzer.Objects.ObjEvent_key()
                {
                    CtrlKeyPressed = null,
                    EventObjDataType = KeyboardPress_Analyzer.Objects.EventDataType.SymbolAsciiCode,
                    EventObjType = KeyboardPress_Analyzer.Objects.EventType.KeyPress,
                    EventTime = DateTime.Now,
                    Key = "l",
                    KeyValue = 108,
                    ShiftKeyPressed = null
                },
                new KeyboardPress_Analyzer.Objects.ObjEvent_key()
                {
                    CtrlKeyPressed = null,
                    EventObjDataType = KeyboardPress_Analyzer.Objects.EventDataType.SymbolAsciiCode,
                    EventObjType = KeyboardPress_Analyzer.Objects.EventType.KeyPress,
                    EventTime = DateTime.Now,
                    Key = "a",
                    KeyValue = 97,
                    ShiftKeyPressed = null
                },
                new KeyboardPress_Analyzer.Objects.ObjEvent_key()
                {
                    CtrlKeyPressed = null,
                    EventObjDataType = KeyboardPress_Analyzer.Objects.EventDataType.KeyboardButtonCode,
                    EventObjType = KeyboardPress_Analyzer.Objects.EventType.KeyPress,
                    EventTime = DateTime.Now,
                    Key = "Left",
                    KeyValue = 37,
                    ShiftKeyPressed = true
                },
                new KeyboardPress_Analyzer.Objects.ObjEvent_key()
                {
                    CtrlKeyPressed = null,
                    EventObjDataType = KeyboardPress_Analyzer.Objects.EventDataType.SymbolAsciiCode,
                    EventObjType = KeyboardPress_Analyzer.Objects.EventType.KeyPress,
                    EventTime = DateTime.Now,
                    Key = "b",
                    KeyValue = 98,
                    ShiftKeyPressed = null
                },
                new KeyboardPress_Analyzer.Objects.ObjEvent_key()
                {
                    CtrlKeyPressed = null,
                    EventObjDataType = KeyboardPress_Analyzer.Objects.EventDataType.SymbolAsciiCode,
                    EventObjType = KeyboardPress_Analyzer.Objects.EventType.KeyPress,
                    EventTime = DateTime.Now,
                    Key = " ",
                    KeyValue = 32,
                    ShiftKeyPressed = null
                }
            });
        }

        /// <summary>
        /// a b c [left] [left + shift] [right] [space]
        /// </summary>
        [TestMethod]
        public void Test_TotalWords_v2_3()
        {
            var totalWrds = new TotalWords();
            string jsonstr = "[{\"Key\":\"a\",\"KeyValue\":97,\"ShiftKeyPressed\":null,\"CtrlKeyPressed\":null,\"EventObjType\":1,\"ActiveWindowName\":\"Untitled - Notepad\",\"EventObjDataType\":2,\"EventTime\":\"2018-01-13T18:03:14.4766168+02:00\"},{\"Key\":\"b\",\"KeyValue\":98,\"ShiftKeyPressed\":null,\"CtrlKeyPressed\":null,\"EventObjType\":1,\"ActiveWindowName\":\"Untitled - Notepad\",\"EventObjDataType\":2,\"EventTime\":\"2018-01-13T18:03:14.6956293+02:00\"},{\"Key\":\"c\",\"KeyValue\":99,\"ShiftKeyPressed\":null,\"CtrlKeyPressed\":null,\"EventObjType\":1,\"ActiveWindowName\":\"Untitled - Notepad\",\"EventObjDataType\":2,\"EventTime\":\"2018-01-13T18:03:15.0116474+02:00\"},{\"Key\":\"Left\",\"KeyValue\":37,\"ShiftKeyPressed\":false,\"CtrlKeyPressed\":false,\"EventObjType\":1,\"ActiveWindowName\":\"Untitled - Notepad\",\"EventObjDataType\":1,\"EventTime\":\"2018-01-13T18:03:15.4936749+02:00\"},{\"Key\":\"Left\",\"KeyValue\":37,\"ShiftKeyPressed\":true,\"CtrlKeyPressed\":false,\"EventObjType\":1,\"ActiveWindowName\":\"Untitled - Notepad\",\"EventObjDataType\":1,\"EventTime\":\"2018-01-13T18:03:15.826694+02:00\"},{\"Key\":\"Delete\",\"KeyValue\":46,\"ShiftKeyPressed\":false,\"CtrlKeyPressed\":false,\"EventObjType\":1,\"ActiveWindowName\":\"Untitled - Notepad\",\"EventObjDataType\":1,\"EventTime\":\"2018-01-13T18:03:16.6777427+02:00\"},{\"Key\":\"Right\",\"KeyValue\":39,\"ShiftKeyPressed\":false,\"CtrlKeyPressed\":false,\"EventObjType\":1,\"ActiveWindowName\":\"Untitled - Notepad\",\"EventObjDataType\":1,\"EventTime\":\"2018-01-13T18:03:17.2837773+02:00\"},{\"Key\":\" \",\"KeyValue\":32,\"ShiftKeyPressed\":null,\"CtrlKeyPressed\":null,\"EventObjType\":1,\"ActiveWindowName\":\"Untitled - Notepad\",\"EventObjDataType\":2,\"EventTime\":\"2018-01-13T18:03:17.7778056+02:00\"}]";
            totalWrds.totalWordsCount_v2(Newtonsoft.Json.JsonConvert.DeserializeObject<ObjEvent_key[]>(jsonstr));
        }

        [TestMethod]
        public void Test_outOfMemoryList()
        {
            try
            {
                var obj = new ObjEvent_key()
                {
                    EventObjDataType = EventDataType.KeyboardButtonCode,
                    SavedInDB = false,
                    ActiveWindowName = "asdasdasdasdasdasdasdasd",
                    CtrlKeyPressed = false,
                    EventObjType = EventType.KeyPress,
                    EventTime = new DateTime(2008, 1, 12),
                    Key = "a",
                    KeyValue = 65,
                    ShiftKeyPressed = false
                };

                List<ObjEvent_key> lst = new List<ObjEvent_key>();
                int i = 0;
                int i2 = 0;
                while (true)
                {
                    i++;
                    i2 = lst.Count;
                    Add_Obj<ObjEvent_key>(ref lst, obj);
                }
            }
            catch(Exception ex)
            {

            }
        }

        protected void Add_Obj<T>(ref List<T> lst, T obj)
        {
            try
            {
                lst.Add(obj);
            }
            catch (OutOfMemoryException oomEx)
            {
                LogHelper.LogErrorMsg(oomEx);
                LogHelper.LogInfoMsg($"BANDOMA PAŠALINTI DALĮ ELEMENTŲ IŠ {nameof(T)}");
                DebugHelper.AddInfoMsg($"BANDOMA PAŠALINTI DALĮ ELEMENTŲ IŠ {nameof(T)}");
                Stopwatch st = new Stopwatch();
                st.Start();
                Helper.DeleteFromBegin(ref lst, 10000000);
                st.Stop();
                var a = st.ElapsedMilliseconds;
                lst.Add(obj);
            }
            catch
            {
                throw;
            }
        }

    }
}
