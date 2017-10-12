using Gma.System.MouseKeyHook;
using KeyboardPress_Analyzer.Helper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;


namespace KeyboardPress_Analyzer
{
    public class KeyboardPressAdapter : IKeyboardPressAdapter
    {
        public Point lastPoint;

        /// <summary>
        /// Pelės mygtukų paspaudimai
        /// </summary>
        private List<ObjEvent_mouse> mouseEvents;

        /// <summary>
        /// visi klaviatūros mygtukų paspaudimai
        /// </summary>
        private List<ObjEvent_key> keysEvents;

        /// <summary>
        /// klaviatūros mygtukų paspaudimų junginiai (gauti REZULTATAI) darantis įtaką rašomam tekstui
        /// </summary>
        private List<ObjEvent_key> keysCharsEvents;
        
        /// <summary>
        /// Paspaudimų dažnumui skaičiuoti
        /// </summary>
        private List<ObjKeyPressCount> keyPressCountObjList;
        
        private IKeyboardMouseEvents m_GlobalHook;
        private IDebugHelper debugLogHelper;
        private Stopwatch stopWach;

        #region constructors
        public KeyboardPressAdapter()
        {
            keysEvents = new List<ObjEvent_key>();
            keysCharsEvents = new List<ObjEvent_key>();
            mouseEvents = new List<ObjEvent_mouse>();
            keyPressCountObjList = new List<ObjKeyPressCount>();

            stopWach = new Stopwatch();
        }
        #endregion constructors

        #region auto-properties (get-set)
        /// <summary>
        /// visi klaviatūros mygtukų paspaudimai
        /// </summary>
        public List<ObjEvent_key> KeysEvents
        {
            get
            {
                if (keysEvents == null)
                    keysEvents = new List<ObjEvent_key>();
                return keysEvents;
            }

            set
            {
                keysEvents = value;
            }
        }

        /// <summary>
        /// klaviatūros mygtukų paspaudimų junginiai (gauti REZULTATAI) darantis įtaką rašomam tekstui
        /// </summary>
        public List<ObjEvent_key> KeysCharsEvents
        {
            get
            {
                if (keysCharsEvents == null)
                    keysCharsEvents = new List<ObjEvent_key>();
                return keysCharsEvents;
            }

            set
            {
                keysCharsEvents = value;
            }
        }

        /// <summary>
        /// Pelės mygtukų paspaudimai
        /// </summary>
        public List<ObjEvent_mouse> MouseEvents
        {
            get
            {
                if (mouseEvents == null)
                    mouseEvents = new List<ObjEvent_mouse>();
                return mouseEvents;
            }

            set
            {
                mouseEvents = value;
            }
        }

        public IDebugHelper IDebugLogHelper
        {
            get
            {
                return debugLogHelper;
            }
            set
            {
                debugLogHelper = value;
            }
        }

        protected bool DebugLog
        {
            get
            {
                if (debugLogHelper != null)
                    return true;
                return false;
            }
        }

        public Stopwatch StopWach
        {
            get { return stopWach; }
        }

        public List<ObjKeyPressCount> KeyPressCountObjList
        {
            get
            {
                return keyPressCountObjList;
            }
            set
            {
                keyPressCountObjList = value;
            }
        }

        #endregion auto-properties(get-set)

        #region IKeyboardPressTracking

        public virtual void CleanData()
        {
            if (keysEvents != null)
                keysEvents.Clear();

            if (keysCharsEvents != null)
                keysCharsEvents.Clear();

            if (mouseEvents != null)
                mouseEvents.Clear();
        }

        public virtual void StopHookWork()
        {
            if (m_GlobalHook == null)
                return;

            m_GlobalHook.KeyDown -= GlobalHookKeyDown;
            m_GlobalHook.KeyUp -= GlobalHookKeyUp;
            m_GlobalHook.KeyPress -= GlobalHookKeyPress;

            m_GlobalHook.MouseDown -= GlobalHookMouseDown;
            m_GlobalHook.MouseWheel -= GlobalHook_MouseWheel;

            m_GlobalHook.Dispose();

            stopWach.Stop();
        }

        public virtual void StartHookWork()
        {
            if (m_GlobalHook == null)
                m_GlobalHook = Hook.GlobalEvents();

            m_GlobalHook.KeyDown += GlobalHookKeyDown;
            m_GlobalHook.KeyPress += GlobalHookKeyPress;
            m_GlobalHook.KeyUp += GlobalHookKeyUp;

            m_GlobalHook.MouseDown += GlobalHookMouseDown;
            m_GlobalHook.MouseWheel += GlobalHook_MouseWheel;

            stopWach.Start();
        }
        
        #endregion IKeyboardPressTracking

        protected virtual void GlobalHook_MouseWheel(object sender, MouseEventArgs e)
        {

        }

        /// <summary>
        /// simbolių gavimui
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void GlobalHookKeyPress(object sender, KeyPressEventArgs e)
        {
            var newRec = new ObjEvent_key()
            {
                dateTime = DateTime.Now,
                activeWindowName = Helper.Helper.GetActiveWindowTitle(),
                eventObjType = EventType.KeyPress,
                keyValue = (int)e.KeyChar,
                key = e.KeyChar
            };

            try
            {
                keysCharsEvents.Add(newRec);
            }
            catch(OutOfMemoryException oomEx)
            {
                LogHelper.LogInfoMsg($"BANDOMA PAŠALINTI DALĮ ELEMENTŲ IŠ {nameof(keysCharsEvents)}");
                if(DebugLog)
                    debugLogHelper.AddInfoMsg($"BANDOMA PAŠALINTI DALĮ ELEMENTŲ IŠ {nameof(keysCharsEvents)}");
                var deletedItems = new List<ObjEvent_key>();
                Helper.Helper.DeleteFromBegin(ref keysCharsEvents, 100, ref deletedItems);
                keysCharsEvents.Add(newRec);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
            if (DebugLog)
            {
                debugLogHelper.AddInfoMsg(newRec.dateTime, $"{newRec.key.ToString()} {newRec.keyValue.ToString()} [{newRec.activeWindowName}]");
            }
        }
        
        protected virtual void GlobalHookMouseDown(object sender, MouseEventArgs e)
        {
            
        }

        protected virtual void GlobalHookKeyUp(object sender, KeyEventArgs e)
        {
            var rec = keyPressCountObjList.FirstOrDefault(x => x.AsciiKeyCode == e.KeyValue);
            if (rec != null)
            {
                rec.PressReleaseCount++;
            }
            else
            {
                var newRec = new ObjKeyPressCount(e.KeyValue);
                newRec.PressReleaseCount++;
                keyPressCountObjList.Add(newRec);
            }
        }

        protected virtual void GlobalHookKeyDown(object sender, KeyEventArgs e)
        {
            var newRec = new ObjEvent_key()
            {
                dateTime = DateTime.Now,
                key = e.KeyData.ToString(),
                eventObjType = EventType.KeyDown,
                activeWindowName = Helper.Helper.GetActiveWindowTitle(),
                keyValue = e.KeyValue
            };
            try
            {
                keysEvents.Add(newRec);
            }
            catch (OutOfMemoryException oomEx)
            {
                LogHelper.LogInfoMsg($"BANDOMA PAŠALINTI DALĮ ELEMENTŲ IŠ {nameof(keysEvents)}");
                if (DebugLog)
                    debugLogHelper.AddInfoMsg($"BANDOMA PAŠALINTI DALĮ ELEMENTŲ IŠ {nameof(keysEvents)}");
                var deletedItems = new List<ObjEvent_key>();
                Helper.Helper.DeleteFromBegin(ref keysEvents, 100, ref deletedItems);
                keysEvents.Add(newRec);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
            var rec = keyPressCountObjList.FirstOrDefault(x => x.AsciiKeyCode == e.KeyValue);
            if (rec != null)
                rec.PressHoldCount++;
            else
                keyPressCountObjList.Add(new ObjKeyPressCount(e.KeyValue));

            if (DebugLog)
            {
                debugLogHelper.AddInfoMsg(newRec.dateTime, $"{newRec.key.ToString()} {newRec.keyValue.ToString()} [{newRec.activeWindowName}]");
            }
        }
        
        

    }
}
