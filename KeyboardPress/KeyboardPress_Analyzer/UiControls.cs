using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeyboardPress_Analyzer
{
    /// <summary>
    /// Class for UI data update
    /// </summary>
    public class UiControls
    {
        private List<ObjUiControl> uiControls = null;
        private object locker = new object();

        public UiControls()
        {
            if(uiControls == null)
                uiControls = new List<ObjUiControl>();
        }

        //public void Add(ObjUiControl obj)
        //{
        //    bool throwEx = false;
        //    lock (locker)
        //    {
        //        if (uiControls.FirstOrDefault(x => x.Obj == obj.Obj) == null)
        //        {
        //            uiControls.Add(obj);
        //        }
        //        else
        //        {
        //            throwEx = true;
        //        }
        //    }
        //    if(throwEx)
        //        throw new ArgumentException("Duplicated object", nameof(obj.Obj));
        //}

        public void Add(object obj, EnumUiControlTag tag)
        {
            bool throwEx = false;
            lock (locker)
            {
                if (uiControls.FirstOrDefault(x => x.Obj == obj) == null)
                    uiControls.Add(new ObjUiControl()
                    {
                        Obj = obj,
                        Tag = tag
                    });
                else
                    throwEx = true;
            }

            if(throwEx)
                throw new ArgumentException("Duplicated object", nameof(obj));
        }

        public void SetText(string text, EnumUiControlTag uiControlTag)
        {
            string result = "OK";
            lock (locker)
            {
                var c = uiControls.FirstOrDefault(x => x.Tag == uiControlTag);
                if (c == null)
                    result = new ArgumentNullException(uiControlTag.ToString()).ToString();

                if(result == "OK")
                {
                    if (c.Obj is Label)
                    {
                        if (((Label)c.Obj).InvokeRequired)
                            ((Label)c.Obj).BeginInvoke(new MethodInvoker(delegate { ((Label)c.Obj).Text = text; }));
                        else
                            ((Label)c.Obj).Text = text;
                    }
                    else if(c.Obj is TextBox)
                    {
                        if (((TextBox)c.Obj).InvokeRequired)
                            ((TextBox)c.Obj).BeginInvoke(new MethodInvoker(delegate { ((TextBox)c.Obj).Text = text; }));
                        else
                            ((TextBox)c.Obj).Text = text;
                    }
                    else
                    {
                        result = new NotSupportedException().ToString();
                    }
                }
            }

            if (result != "OK")
                throw new Exception(result);
        }
    }

    public class ObjUiControl
    {
        public object Obj { get; set; }
        public EnumUiControlTag Tag { get; set; }
    }

    public enum EnumUiControlTag
    {
        TotalKeyPress,
        TotalMousePress,
        TotalWords,
        TotalMouseWheelUp,
        TotalMouseWheelDown,
        LastWord,
        TotalWordsMistakes,
        AvrgPressPerMin,
        AvrgPressPerHour,
        AvrgMousePressPerMin,
        AvrgMousePressPerHour,
        AvrgWordsPerMin,
        AvrgWordsPerHour,

    }
}
