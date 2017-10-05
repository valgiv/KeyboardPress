using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyboardPress_Analyzer
{
    public class ObjEvent_mouse : ObjEvent_base
    {
        public int? x { get; set; }
        public int? y { get; set; }
    }

    public class ObjEvent_key : ObjEvent_base
    {
        public ObjEvent_key()
        {
            processed = false;
        }

        public object key { get; set; } // to do: pakeisti į reikiamą tipą
        /// <summary>
        /// ascii int value
        /// </summary>
        public int keyValue { get; set; } // desimtainis kodas is ascii
        
        /// <summary>
        /// 
        /// </summary>
        public bool processed { get; set; }
    }

    public class ObjEvent_base
    {
        public DateTime dateTime { get; set; }
        public EventType eventObjType { get; set; }
        public string activeWindowName { get; set; }
    }

    public enum EventType
    {
        KeyDown,
        KeyPress,
        MouseClick,
        MouseDoubleClick,
        MouseDown,
        MouseDownExt,
        MouseDragFinished,
        MouseDragFinishedExt,
        MouseDragStarted,
        MouseDragStartedExt,
        MouseMove,
        MouseMoveExt,
        MouseUp,
        MouseUpExt,
        MouseWheel,
        MouseWheelExt
    }
}
