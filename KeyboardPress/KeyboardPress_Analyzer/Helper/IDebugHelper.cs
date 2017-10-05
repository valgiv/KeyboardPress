using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyboardPress_Analyzer.Helper
{
    public interface IDebugHelper
    {
        bool DebugMode { get; }

        void AddInfoMsg(string msg);
        void AddInfoMsg(DateTime dateTime, string msg);
        void AddErrorMsg(string msg);
        void AddErrorMsg(DateTime dateTime, string msg);
    }
}
