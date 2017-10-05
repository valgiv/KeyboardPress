using Gma.System.MouseKeyHook;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyboardPress_Analyzer
{
    public interface IKeyboardPressAdapter
    {
        /// <summary>
        /// Catches keyboard presses events and saves data about it
        /// </summary>
        void StartHookWork();

        /// <summary>
        /// Stops catching keyboard presses
        /// </summary>
        void StopHookWork();

        /// <summary>
        /// Cleans saved data
        /// </summary>
        void CleanData();

    }
}
