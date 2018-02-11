﻿using KeyboardPress_Extensions;
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

namespace KeyboardPress
{
    public partial class InfoFormDialog : Form
    {
        private bool opacityUp = true;
        private int showTimeMiliseconds = 0;
        private Action action = null;

        public InfoFormDialog(string Message, string Title, int ShowTimeMiliseconds, Image Image, Action ClickAct)
        {
            InitializeComponent();

            this.Opacity = 0;
            showTimeMiliseconds = ShowTimeMiliseconds;
            pictureBox.Image = Image;
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            lblFormTitle.Text = Title;
            action = ClickAct;
            //to do: padaryti action ant paspaudimo,
            //to do: atidaryti tam tikroje ekrano vietoje
        }

        public string FormTitle
        {
            get { return lblFormTitle.Text; }
            set { lblFormTitle.Text = value; }
        }

        private void InfoForm_Load(object sender, EventArgs e)
        {
            //timerOpacity.Start();

            //pictureBox.Image = KeyboardPress_Extensions.Properties.Resources.bulb_black;
            //pictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
        }

        #region overrides

        protected override bool ShowWithoutActivation
        {
            get { return true; }
        }
        

        #endregion override

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
    }

    public class InfoForm
    {
        public static void Show(string Message, string Title, int ShowTimeMiliseconds, Enum_InfoFormImage Image, Action ClickAct)
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

            FormWithoutActivation.ShowInactiveTopmost(new InfoFormDialog(Message, Title, ShowTimeMiliseconds, img, ClickAct));
        }

        public enum Enum_InfoFormImage
        {
            HeadConfig = 1,
            HeadMind,
            Precent,
            BulbBlack,
            BulbQ
        }

    }
    
}
