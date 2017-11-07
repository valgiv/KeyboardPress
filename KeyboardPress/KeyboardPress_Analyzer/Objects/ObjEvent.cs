using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyboardPress_Analyzer.Objects
{
    public class ObjEvent_mouse : ObjEvent_base
    {
        public int? X { get; set; }
        public int? Y { get; set; }
    }

    public class ObjEvent_key : ObjEvent_base
    {
        //public object Key { get; set; } // to do: pakeisti į reikiamą tipą
        public string Key { get; set; } //dažnu atveju char
        /// <summary>
        /// ascii int value
        /// </summary>
        public int KeyValue { get; set; } // desimtainis simbolio arba mygtuko kodas (priklausomai nuo eventType)
        
        public bool? ShiftKeyPressed { get; set; }
        public bool? CtrlKeyPressed { get; set; }
    }

    public class ObjEvent_base : ObjDate
    {
        public EventType EventObjType { get; set; }
        public string ActiveWindowName { get; set; }
        public EventDataType EventObjDataType { get; set; }
    }

    public class ObjDate
    {
        public ObjDate()
        {
            EventTime = DateTime.Now;
        }

        public DateTime EventTime { get; set; }
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

    public enum EventDataType
    {
        KeyboardButtonCode = 1,
        SymbolAsciiCode = 2
    }
}
