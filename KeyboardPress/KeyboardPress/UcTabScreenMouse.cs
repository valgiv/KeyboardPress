using System;
using System.Windows.Forms;

namespace KeyboardPress
{
    public partial class UcTabScreenMouse : UcBase
    {
        private UcScreen uc = null;

        public UcTabScreenMouse()
        {
            InitializeComponent();
        }

        private void UcTabScreenMouse_Load(object sender, EventArgs e)
        {
            try
            {
                if (uc == null)
                    uc = new UcScreen();
                uc.Dock = DockStyle.Fill;
                this.panelScreen.Controls.Add(uc);
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            uc.MouseEvents = MF.Kpt.MouseEvents;
            uc.TryRedraw();
        }
    }
}
