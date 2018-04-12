using System;
using System.Collections.Generic;
using System.Linq;
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
            string result = string.Empty;
            lock (locker)
            {
                //var c = uiControls.FirstOrDefault(x => x.Tag == uiControlTag);

                //if (c == null)
                //    result = new ArgumentNullException(uiControlTag.ToString()).ToString();

                var controls = uiControls.Where(x => x.Tag == uiControlTag);

                if(controls != null && controls.Count() > 0)
                {
                    foreach(var c in controls)
                    {
                        try
                        {
                            if (c.Obj is Label)
                            {
                                if (((Label)c.Obj).InvokeRequired)
                                    ((Label)c.Obj).BeginInvoke(new MethodInvoker(delegate { ((Label)c.Obj).Text = text; }));
                                else
                                    ((Label)c.Obj).Text = text;
                            }
                            else if (c.Obj is TextBox)
                            {

                                if (((TextBox)c.Obj).InvokeRequired)
                                    ((TextBox)c.Obj).BeginInvoke(new MethodInvoker(delegate
                                    {
                                        try
                                        {
                                            ((TextBox)c.Obj).Text = text;
                                        }
                                        catch (Exception ex)
                                        {
                                            result += $" {ex.Message}";
                                        }

                                    }));
                                else
                                    ((TextBox)c.Obj).Text = text;
                            }
                            else
                            {
                                result += new NotSupportedException().ToString();
                            }
                        }
                        catch(Exception ex)
                        {
                            result += $" {ex.Message}";
                        }
                    }
                }
            }

            if (!String.IsNullOrEmpty(result))
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
        TotalKeyPressRelease,//+
        TotalKeyPress,//+
        TotalMousePress,//+
        TotalWords, //+
        TotalMouseWheelUp,//+
        TotalMouseWheelDown,//+
        TotalMouseWhellRatio,//+
        LastWord, //+
        TotalWordsMistakes, //+

        AvrgPressPerMin,
        AvrgPressPerHour,
        AvrgPressReleasePerMin,
        AvrgPressReleasePerHour,
        AvrgMousePressPerMin,
        AvrgMousePressPerHour,
        AvrgWordsPerMin,
        AvrgWordsPerHour,

        TotalMouseLeftPress,//+
        TotalMouseRightPress,//+
        CurrentWorkTime,//+
        CurrentRestTime,//+
        MouseKeyboardRatio,

        WorkTime,

        TotalProgramWorkTime
    }
}
