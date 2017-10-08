using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Extensions
{
    public static class NotifyIconExtensions
    {
        public static void HideBalloonTip(this NotifyIcon notifyIcon)
        {
            if (notifyIcon.Visible)
            {
                notifyIcon.Visible = false;
                notifyIcon.Visible = true;
            }
        }
    }
}
