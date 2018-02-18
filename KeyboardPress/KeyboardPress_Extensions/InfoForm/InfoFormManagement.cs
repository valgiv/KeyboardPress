using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeyboardPress_Extensions.InfoForm
{
    public class InfoFormManagement
    {
        /// <summary>
        /// Grąžina visus taskbarus
        /// </summary>
        /// <returns></returns>
        public static List<Rectangle> FindDockedTaskBars()
        {
            try
            {
                List<Rectangle> dockedRects = new List<Rectangle>();
                foreach (var tmpScrn in Screen.AllScreens)
                {
                    if (!tmpScrn.Bounds.Equals(tmpScrn.WorkingArea))
                    {
                        Rectangle rect = new Rectangle();

                        var leftDockedWidth = Math.Abs((Math.Abs(tmpScrn.Bounds.Left) - Math.Abs(tmpScrn.WorkingArea.Left)));
                        var topDockedHeight = Math.Abs((Math.Abs(tmpScrn.Bounds.Top) - Math.Abs(tmpScrn.WorkingArea.Top)));
                        var rightDockedWidth = ((tmpScrn.Bounds.Width - leftDockedWidth) - tmpScrn.WorkingArea.Width);
                        var bottomDockedHeight = ((tmpScrn.Bounds.Height - topDockedHeight) - tmpScrn.WorkingArea.Height);
                        if ((leftDockedWidth > 0))
                        {
                            rect.X = tmpScrn.Bounds.Left;
                            rect.Y = tmpScrn.Bounds.Top;
                            rect.Width = leftDockedWidth;
                            rect.Height = tmpScrn.Bounds.Height;
                        }
                        else if ((rightDockedWidth > 0))
                        {
                            rect.X = tmpScrn.WorkingArea.Right;
                            rect.Y = tmpScrn.Bounds.Top;
                            rect.Width = rightDockedWidth;
                            rect.Height = tmpScrn.Bounds.Height;
                        }
                        else if ((topDockedHeight > 0))
                        {
                            rect.X = tmpScrn.WorkingArea.Left;
                            rect.Y = tmpScrn.Bounds.Top;
                            rect.Width = tmpScrn.WorkingArea.Width;
                            rect.Height = topDockedHeight;
                        }
                        else if ((bottomDockedHeight > 0))
                        {
                            rect.X = tmpScrn.WorkingArea.Left;
                            rect.Y = tmpScrn.WorkingArea.Bottom;
                            rect.Width = tmpScrn.WorkingArea.Width;
                            rect.Height = bottomDockedHeight;
                        }
                        else
                        {
                            // Nothing found!
                        }

                        dockedRects.Add(rect);
                    }
                }

                if (dockedRects.Count == 0)
                {
                    // Taskbar is set to "Auto-Hide".
                }

                return dockedRects;
            }
            catch (Exception ex)
            {

                return null;
            }
        }
    }
}
