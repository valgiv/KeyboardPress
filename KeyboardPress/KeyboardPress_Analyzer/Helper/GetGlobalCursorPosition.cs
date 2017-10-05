using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace KeyboardPress_Analyzer.Helper
{
    public class GetGlobalCursorPosition
    {
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetCursorPos(out POINT lpPoint);

        //[DllImport("user32.dll")]
        //static extern bool GetCaretPos(out Point lpPoint);

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

        public static POINT? GetCursorPositionCoordinates()
        {
            POINT p;
            if (GetCursorPos(out p))
                return p;
            else
                return null;
        }

        //public static Point GetCaretPositionCoordinates()
        //{
        //    System.Windows.Forms.Application.DoEvents();
        //    Point p = Point.Empty;
        //    if (GetCaretPos(out p))
        //        return p;
        //    else
        //        return Point.Empty;
        //}
    }
}
