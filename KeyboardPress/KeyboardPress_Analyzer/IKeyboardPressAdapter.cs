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

        /*/// <summary>
        /// Mouse press events
        /// </summary>
        List<EventObj_mouse> MouseEvents
        {
            get; set;
        }

        /// <summary>
        /// All keyboard press events
        /// </summary>
        List<EventObj_key> KeysEvents
        {
            get; set;
        }

        /// <summary>
        /// Keyboard press results
        /// </summary>
        List<EventObj_key> KeysCharsEvents
        {
            get; set;
        }

        List<KeyPressCountObj> KeyPressCountObjList
        {
            get; set;
        }*/


    }
}
