using System;
using System.Configuration;
using System.IO;

namespace KeyboardPress_Analyzer.Helper
{
    public class LogHelper
    {
        private static string logDir = "";

        public static string LogDir
        {
            get
            {
                if (string.IsNullOrEmpty(logDir))
                    logDir = ConfigurationManager.AppSettings["logDir"].ToString();
                return logDir;
            }
        }

        public static void LogErrorMsg(string msg)
        {
            try
            {
                string errMsg = $"{DateTime.Now} ERROR: {msg}";

                WriteToFile(errMsg);
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR !!! !!! !!!");
                Console.WriteLine($"err on {nameof(LogErrorMsg)}()");
                Console.WriteLine(ex.Message);
            }
        }

        public static void LogInfoMsg(string msg)
        {
            try
            {
                string errMsg = $"{DateTime.Now} INFO: {msg}";

                WriteToFile(errMsg);
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR !!! !!! !!!");
                Console.WriteLine($"err on {nameof(LogInfoMsg)}()");
                Console.WriteLine(ex.Message);
            }
        }

        private static void WriteToFile(string text)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(LogDir));

            using (var file = new StreamWriter(LogDir, true))
            {
                file.WriteLine(text);
            }
        }
    }
}
