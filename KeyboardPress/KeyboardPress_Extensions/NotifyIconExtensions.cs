using System.Windows.Forms;

namespace KeyboardPress_Extensions
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

        public static void SetIcon(this NotifyIcon notifyIcon, NotifyIconType notifyIconType)
        {
            if (notifyIconType == NotifyIconType.green)
                notifyIcon.Icon = KeyboardPress_Extensions.Properties.Resources.ico_green_Graphicloads_Seo_Services_Tags;
            else if (notifyIconType == NotifyIconType.blue)
                notifyIcon.Icon = KeyboardPress_Extensions.Properties.Resources.ico_blue_Graphicloads_Seo_Services_Creative;
            else if (notifyIconType == NotifyIconType.red)
                notifyIcon.Icon = KeyboardPress_Extensions.Properties.Resources.ico_red_Graphicloads_Seo_Services_Global;
            else if(notifyIconType == NotifyIconType.yellow)
                notifyIcon.Icon = KeyboardPress_Extensions.Properties.Resources.ico_yellow_Graphicloads_Seo_Services_Target;
        }

        public enum NotifyIconType
        {
            green, red, blue, yellow
        }
    }
}
