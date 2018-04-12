using System;
using System.Configuration;
using System.IO;
using System.Windows.Forms;

namespace KeyboardPress_Analyzer.Helper
{
    public class LogHelper
    {
        private static string logDir = "";

        private static string LogDir
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
                string errMsg = $"============================================{Environment.NewLine}{DateTime.Now} ERROR: {msg}";

                WriteToFile(errMsg);
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR !!! !!! !!!");
                Console.WriteLine($"err on {nameof(LogErrorMsg)}()");
                Console.WriteLine(ex.Message);
            }
        }

        public static void ShowErrorMsgWithLog(string ErrorMSg, Exception ex)
        {
            MessageBox.Show(ErrorMSg, "Klaida", MessageBoxButtons.OK, MessageBoxIcon.Error);
            LogErrorMsg(ex);
        }

        public static void ShowErrorMsgWithLog(Exception ex)
        {
            ShowErrorMsgWithLog(ex.Message, ex);
        }

        public static void LogErrorMsg(Exception ex)
        {
            try
            {
                string errMsg = $"============================================{Environment.NewLine}{DateTime.Now} ERROR: [{ex.Source}] {ex.Message} [{ex.StackTrace}]";

                WriteToFile(errMsg);
            }
            catch(Exception e)
            {
                Console.WriteLine("ERROR !!! !!! !!!");
                Console.WriteLine($"err on {nameof(LogErrorMsg)}()");
                Console.WriteLine(e.Message);
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

        public static void ShowInfoMsgWithLog(string infoMsg)
        {
            ShowInfoMsgWithLog(infoMsg, infoMsg);
        }

        public static void ShowInfoMsgWithLog(string infoMsg, string infoMsgLog)
        {
            MessageBox.Show(infoMsg, "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            LogInfoMsg(infoMsgLog);
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
