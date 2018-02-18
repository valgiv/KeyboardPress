using KeyboardPress_Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeyboardPress_Extensions.InfoForm
{
    public partial class InfoFormDialog : Form
    {
        private bool opacityUp = true;
        private int showTimeMiliseconds = 0;
        private Action action = null;

        //to do: padaryti naudojima kur reikia
        public InfoFormDialog(string Message, string Title, int ShowTimeMiliseconds, Image Image, Action ClickAct)
        {
            InitializeComponent();

            this.Opacity = 0;
            showTimeMiliseconds = ShowTimeMiliseconds;
            pictureBox.Image = Image;
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            lblFormTitle.Text = Title;
            action = ClickAct;
            lblText.Text = Message;

            ChangeFormSize();
        }

        protected override bool ShowWithoutActivation
        {
            get { return true; }
        }

        private void ChangeFormSize()
        {
            try
            {
                Size sz = TextRenderer.MeasureText(lblText.Text, lblText.Font, lblText.Size, TextFormatFlags.WordBreak);
                //MessageBox.Show(sz.Width.ToString() + " - " + sz.Height.ToString()); //to do: jei sitas, tai klaida
                if (sz.Width >= lblText.Width)
                    this.Width = sz.Width + pictureBox.Width + 40;
                if (sz.Height >= lblText.Height)
                    this.Height = sz.Height + 40;
            }
            catch(Exception ex)
            {
                //to do: nustatyti kažkokį dydį klaidos atveju
            }
        }

        public string FormTitle
        {
            get { return lblFormTitle.Text; }
            set { lblFormTitle.Text = value; }
        }

        public void SetFormPosition(Point point)
        {
            this.Location = point;
        }

        private void InfoForm_Load(object sender, EventArgs e)
        {
            
        }
        
        #region Form closing

        private void btnCloseFrom_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        #endregion Form closing

        private void timerOpacity_Tick(object sender, EventArgs e)
        {
            if (opacityUp)
            {
                if(this.Opacity < 0.9)
                {
                    this.Opacity = this.Opacity + 0.05;
                }
                else
                {
                    opacityUp = false;
                }
            }
            else if (showTimeMiliseconds > 0)
            {
                showTimeMiliseconds = showTimeMiliseconds - timerOpacity.Interval;
            }
            else
            {
                if (this.Opacity > 0)
                    this.Opacity = this.Opacity - 0.05;
                else
                    this.Close();
            }
        }

        private const int WS_EX_TOPMOST = 0x00000008;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams createParams = base.CreateParams;
                createParams.ExStyle |= WS_EX_TOPMOST;
                return createParams;
            }
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            action?.Invoke();
        }

        private void lblText_Click(object sender, EventArgs e)
        {
            action?.Invoke();
        }

        private void panelCenter_Click(object sender, EventArgs e)
        {
            action?.Invoke();
        }
    }

    public class InfoForm
    {
        public static void Show(string Message, string Title, int ShowTimeMiliseconds, Enum_InfoFormImage Image, Action ClickAct)
        {
            try
            {
                Image img = null;
                switch (Image)
                {
                    case Enum_InfoFormImage.HeadConfig:
                        img = global::KeyboardPress_Extensions.Properties.Resources.head_config;
                        break;
                    case Enum_InfoFormImage.BulbBlack:
                        img = global::KeyboardPress_Extensions.Properties.Resources.bulb_black;
                        break;
                    case Enum_InfoFormImage.BulbQ:
                        img = global::KeyboardPress_Extensions.Properties.Resources.bulb_quastion;
                        break;
                    case Enum_InfoFormImage.HeadMind:
                        img = global::KeyboardPress_Extensions.Properties.Resources.head_mind;
                        break;
                    case Enum_InfoFormImage.Precent:
                        img = global::KeyboardPress_Extensions.Properties.Resources.precent;
                        break;
                    default:
                        throw new Exception("Nanumatytas paveikslėlis");
                }

                var form = new InfoFormDialog(Message, Title, ShowTimeMiliseconds, img, ClickAct);
                form.SetFormPosition(CalculateFormLocation(form));
                //FormWithoutActivation.ShowInactiveTopmost(form);
                form.Show();
                System.Windows.Threading.Dispatcher.Run();
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public enum Enum_InfoFormImage
        {
            HeadConfig = 1,
            HeadMind,
            Precent,
            BulbBlack,
            BulbQ
        }

        public static Point CalculateFormLocation(Form form)
        {
            try
            {
                var taskbars = InfoFormManagement.FindDockedTaskBars();
                if (taskbars == null)
                    throw new Exception("Failed docked taskbars search");

                if (taskbars.Count() == 0) // turbūt auto-hide rėžimas
                    return new Point(0, 0);

                int pading = 5;

                if (taskbars[0].X == 0 && taskbars[0].Y == 0 && taskbars[0].Width < 300)
                {
                    // kairėje -> kaire apacioje
                    return new Point(taskbars[0].Width + pading, taskbars[0].Height - form.Height - pading);
                }
                else if (taskbars[0].X != 0 && taskbars[0].Y == 0)
                {
                    //desineje -> desine apacioje
                    return new Point(taskbars[0].X - form.Width - pading, taskbars[0].Height - form.Height - pading);
                }
                else if(taskbars[0].X == 0 && taskbars[0].Y < 200)
                {
                    //virsuje -> virsuje desineje
                    return new Point(taskbars[0].Width - form.Width - pading, taskbars[0].Height + pading);
                }
                else
                {
                    //apacioje
                    return new Point(taskbars[0].Width - form.Width - pading, taskbars[0].Y - form.Height - pading);
                }
            }
            catch(Exception ex)
            {
                return new Point(200, 0);
            }
        }

    }
    
}
