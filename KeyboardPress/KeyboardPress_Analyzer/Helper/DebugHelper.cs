using System;
using System.Globalization;
using System.Windows.Forms;

namespace KeyboardPress_Analyzer.Helper
{
    public class DebugHelper : IDebugHelper
    {
        private RichTextBox debugRichTextBox;

        static readonly object locker = new object();

        public DebugHelper(RichTextBox richTextBox)
        {
            debugRichTextBox = richTextBox;
        }

        public bool DebugMode
        {
            get
            {
                if (debugRichTextBox != null)
                    return true;
                return false;
            }
        }

        public RichTextBox DebugModeControl
        {
            get
            {
                return debugRichTextBox;
            }
            set
            {
                debugRichTextBox = value;
            }
        }
        
        public void AddErrorMsg(string msg)
        {
            string errMsg = $"ERR-{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture)}: {msg}\n";
            if (debugRichTextBox != null)
            {
                lock (locker)
                {
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
            LogHelper.LogErrorMsg(errMsg);
        }

        public void AddErrorMsg(DateTime dateTime, string msg)
        {
            string errMsg = $"ERR-{dateTime.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture)}: {msg}\n";
            if (debugRichTextBox != null)
            {
                lock (locker)
                {
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
            LogHelper.LogErrorMsg(errMsg);
        }

        public void AddInfoMsg(string msg)
        {
            if (debugRichTextBox != null)
            {
                lock (locker)
                {
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

        public void AddInfoMsg(DateTime dateTime, string msg)
        {
            if (debugRichTextBox != null)
            {
                lock (locker)
                {
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
