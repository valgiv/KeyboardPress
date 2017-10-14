using System;
using System.Globalization;
using System.Windows.Forms;

namespace KeyboardPress_Analyzer.Helper
{
    public class DebugHelper
    {
        private static RichTextBox debugRichTextBox;

        static readonly object locker = new object();
        
        public static void Start(RichTextBox rtb)
        {
            debugRichTextBox = rtb;
        }

        public static void Stop()
        {
            debugRichTextBox = null;
        }

        public static void AddErrorMsg(string msg)
        {
            string errMsg = $"ERR-{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture)}: {msg}\n";
            if (debugRichTextBox != null)
            {
                lock (locker)
                {
                    //lastLock = DateTime.Now;
                    //lockObj = "AddErrorMsg" + " " + msg;

                    if (!debugRichTextBox.InvokeRequired)
                    {
                        debugRichTextBox.Text += errMsg;
                        debugRichTextBox.SelectionStart = debugRichTextBox.Text.Length;
                        debugRichTextBox.ScrollToCaret();
                    }
                    else
                    {
                        debugRichTextBox.Invoke(new MethodInvoker(delegate {
                            debugRichTextBox.Text += errMsg;
                            debugRichTextBox.SelectionStart = debugRichTextBox.Text.Length;
                            debugRichTextBox.ScrollToCaret();
                        }));
                    }
                }
            }
        }

        public static void AddErrorMsg(DateTime dateTime, string msg)
        {
            string errMsg = $"ERR-{dateTime.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture)}: {msg}\n";
            if (debugRichTextBox != null)
            {
                lock (locker)
                {
                    //lastLock = DateTime.Now;
                    //lockObj = "AddErrorMsg" + " " + dateTime.ToString() + " " + msg;

                    if (!debugRichTextBox.InvokeRequired)
                    {
                        debugRichTextBox.Text += errMsg;
                        debugRichTextBox.SelectionStart = debugRichTextBox.Text.Length;
                        debugRichTextBox.ScrollToCaret();
                    }
                    else
                    {
                        debugRichTextBox.Invoke(new MethodInvoker(delegate {
                            debugRichTextBox.Text += errMsg;
                            debugRichTextBox.SelectionStart = debugRichTextBox.Text.Length;
                            debugRichTextBox.ScrollToCaret();
                        }));
                    }
                }
            }
        }

        public static void AddInfoMsg(string msg)
        {
            if (debugRichTextBox != null)
            {
                lock (locker)
                {
                    //lastLock = DateTime.Now;
                    //lockObj = "AddInfoMsg" + " " + msg;

                    if (!debugRichTextBox.InvokeRequired)
                    {
                        debugRichTextBox.Text += $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture)}: {msg}\n";
                        debugRichTextBox.SelectionStart = debugRichTextBox.Text.Length;
                        debugRichTextBox.ScrollToCaret();
                    }
                    else
                    {
                        debugRichTextBox.Invoke(new MethodInvoker(delegate {
                            debugRichTextBox.Text += $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture)}: {msg}\n";
                            debugRichTextBox.SelectionStart = debugRichTextBox.Text.Length;
                            debugRichTextBox.ScrollToCaret();
                        }));
                    }
                }
            }
        }

        public static void AddInfoMsg(DateTime dateTime, string msg)
        {
            if (debugRichTextBox != null)
            {
                lock (locker)
                {
                    //lastLock = DateTime.Now;
                    //lockObj = "AddInfoMsg" + " " + dateTime.ToString() + " " + msg;

                    if (!debugRichTextBox.InvokeRequired)
                    {
                        debugRichTextBox.Text += $"{dateTime.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture)}: {msg}\n";
                        debugRichTextBox.SelectionStart = debugRichTextBox.Text.Length;
                        debugRichTextBox.ScrollToCaret();
                    }
                    else
                    {
                        debugRichTextBox.Invoke(new MethodInvoker(delegate
                        {
                            debugRichTextBox.Text += $"{dateTime.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture)}: {msg}\n";
                            debugRichTextBox.SelectionStart = debugRichTextBox.Text.Length;
                            debugRichTextBox.ScrollToCaret();
                        }));
                    }    
                }
            }
        }

        

    }
}
