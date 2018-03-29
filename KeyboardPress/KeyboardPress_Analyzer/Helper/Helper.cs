using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace KeyboardPress_Analyzer.Helper
{
    public static class Helper
    {
        public static readonly int[] ltLettersArray = new int[] { 260, 261, 269, 268, 281, 280, 279, 278, 303, 303, 353, 352, 371, 370, 363, 362, 382, 381 };

        private static UiControls uiControls;
        public static UiControls UiControls
        {
            get
            {
                if (uiControls == null)
                    uiControls = new UiControls();
                return uiControls;
            }
        }

        public static IEnumerable<T> TakeLast<T>(this IEnumerable<T> collection, int n)
        {
            if (collection == null)
                throw new ArgumentNullException(nameof(collection));
            if (n < 0)
                throw new ArgumentOutOfRangeException("n", "n must be 0 or greater");

            LinkedList<T> temp = new LinkedList<T>();

            foreach (var value in collection.Reverse())
            {
                temp.AddFirst(value);
                if (temp.Count == n)
                    break;
            }

            return temp;
        }

        public static void DeleteFromBegin<T>(ref List<T> list, int itemsToDelete, ref List<T> deletedItemslist)
        {
            if (list == null)
                throw new ArgumentNullException(nameof(list));

            if (itemsToDelete < 1)
                throw new ArgumentOutOfRangeException(nameof(itemsToDelete));
            
            for(int i = 0; i<itemsToDelete; i++)
            {
                if (list.LongCount() > 0)
                {
                    if (deletedItemslist != null)
                        deletedItemslist.Add(list[0]);
                    list.RemoveAt(0);
                }
                else
                {
                    break;
                }
            }
        }
        
        //--
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetCursorPos(out POINT lpPoint);

        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int X;
            public int Y;

            public POINT(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }
        }

        public static POINT? GetGlobalCursorPositionCoordinates()
        {
            POINT p;
            if (GetCursorPos(out p))
                return p;
            else
                return null;
        }
        //--
        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        [DllImport("user32.dll")]
        static extern IntPtr GetWindowThreadProcessId(IntPtr hWnd, out uint ProcessId);

        public static string GetActiveWindowTitle_v2()
        {
            try
            {
                IntPtr hwnd = GetForegroundWindow();
                uint pid;
                GetWindowThreadProcessId(hwnd, out pid);
                Process p = Process.GetProcessById((int)pid);
                string result = p.ProcessName;
                try
                {
                    string name = p.MainModule.FileVersionInfo.FileDescription;
                    if (!String.IsNullOrEmpty(name))
                        result = name;
                }
                catch { }
                
                return result;
            }
            catch { return "z_unknown"; }
            

            /// nice to have:
            /// mapas su procesu ir jo descriptionu
            /// arba (jei tuscia)
            /// var wmiQueryString = $"SELECT ProcessId, ExecutablePath, CommandLine FROM Win32_Process WHERE ProcessId = {pid}";
            /// using (var searcher = new ManagementObjectSearcher(wmiQueryString))
            /// using (var results = searcher.Get())
            /// {
            ///     var query = from p in Process.GetProcesses()
            ///                 join mo in results.Cast<ManagementObject>()
            ///                 on p.Id equals (int)(uint)mo["ProcessId"]
            ///                 select new
            ///                 {
            ///                     Process = p,
            ///                     Path = (string)mo["ExecutablePath"],
            ///                     CommandLine = (string)mo["CommandLine"],
            ///                 };
            ///     foreach (var item in query)
            ///     {
            ///         // pasiziureti failo description ir ideti i map'a
            ///     }

            }

        public static string GetActiveWindowTitle()
        {
            const int nChars = 256;
            StringBuilder Buff = new StringBuilder(nChars);
            IntPtr handle = GetForegroundWindow();

            if (GetWindowText(handle, Buff, nChars) > 0)
            {
                return Buff.ToString();
            }
            return null;
        }
        //--


    }
}
