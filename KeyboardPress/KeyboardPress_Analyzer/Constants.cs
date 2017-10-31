using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyboardPress_Analyzer
{
    public static class Constants
    {
        /// <summary>
        /// (ascii symbol codes) Symbols to fixate word end
        /// </summary>
        public static readonly int[] WordEndSymbolArr = new int[] { 9, 13, 32, 46, 44, 63, 33, 58, 59, 91, 93, 123, 125, 34, 61, 60, 62, 47, 42, 45, 43, 95, 64 }; // tab enter space . , ? ! : ; [ ] { } = < / " * + @ 

        public static readonly int[] CursorPositionChangeKeyboardKeyCodesArr = new int[] { 35, 36, 37, 38, 39, 40 };
    }
}
