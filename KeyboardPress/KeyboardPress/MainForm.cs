using KeyboardPress_Analyzer;
using KeyboardPress_Analyzer.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using KeyboardPress_Extensions;

namespace KeyboardPress
{
    public partial class MainForm : Form, IKeyboardPressAdapter
    {
        private KeyboardPressTracking kpt;
        private Task logInfoTask;

        public MainForm()
        {
            InitializeComponent();
            this.Text = "Keyboard Press Analyzer";
        }
        
        private void StartUp()
        {
            toolStripItem_debug.Checked = true;
            toolStripItem_debug_Click(null, null);

            bool startOnStartUp = true;
            toolStripItem_start.Checked = startOnStartUp;
            toolStripItem_start_Click(null, null);

            LogHelper.LogInfoMsg("Programa pradeda darbą");

            logInfoTask = new Task(() => { LogInfo(); });
            logInfoTask.Start();

            this.notifyIcon.Visible = true;
        }
        
        #region UI Events

        #region ToolStrip meniu items

        private void toolStripItem_debug_Click(object sender, EventArgs e)
        {
            panelDebug.Visible = toolStripItem_debug.Checked;
            if (panelDebug.Visible)
                kpt.IDebugLogHelper = new DebugHelper(richTB_debug);
            else
                kpt.IDebugLogHelper = null;
        }

        private void toolStripItem_start_Click(object sender, EventArgs e)
        {
            if (toolStripItem_start.Checked)
            {
                StartHookWork();
                toolStripItem_stop.Checked = false;
            }
            else
            {
                StopHookWork();
                toolStripItem_stop.Checked = true;
            }
        }

        private void toolStripItem_stop_Click(object sender, EventArgs e)
        {
            if (toolStripItem_stop.Checked)
            {
                StopHookWork();
                toolStripItem_start.Checked = false;
            }
            else
            {
                StartHookWork();
                toolStripItem_start.Checked = true;
            }
        }

        private void toolStripItem_clean_Click(object sender, EventArgs e)
        {
            CleanData();
        }

        private void toolStripItem_cleanDebugWindow_Click(object sender, EventArgs e)
        {
            richTB_debug.Text = "";
        }

        #endregion ToolStrip meniu items

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                if (kpt == null)
                    kpt = new KeyboardPressTracking(this.notifyIcon);

                StartUp();
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Klaida paleidžiant programą:\n{ex.Message}");
                LogHelper.LogErrorMsg(ex.Message);
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if (kpt != null)
                    kpt.StopHookWork();
            }
            catch (Exception ex)
            {
                LogHelper.LogErrorMsg(ex.Message);
                Console.WriteLine("NENUMATYTA KLAIDA: " + ex.Message);
            }
        }

        #endregion UI Events

        public void StartHookWork()
        {
            try
            {
                kpt.StartHookWork();
                toolStripStatusLabel_info.Text = $"{DateTime.Now.ToString()}: Pradėti fiksuoti duomenys";
                timer_workTime.Start();
            }
            catch(Exception ex)
            {
                LogHelper.LogErrorMsg(ex.Message);
                MessageBox.Show("Klaida inicijuojant klavišų paspaudimų fiksavimo pradžią");
            }
        }

        public void StopHookWork()
        {
            try
            {
                kpt.StopHookWork();
                toolStripStatusLabel_info.Text = $"{DateTime.Now.ToString()}: Sustabdyti fiksuoti duomenys";
                timer_workTime.Stop();
            }
            catch(Exception ex)
            {
                LogHelper.LogErrorMsg(ex.Message);
                MessageBox.Show("Klaida sustabdant klavišų paspaudimų fiksavimą");
            }
        }

        public void CleanData()
        {
            try
            {
                kpt.CleanData();
            }
            catch(Exception ex)
            {
                LogHelper.LogErrorMsg(ex.Message);
                MessageBox.Show("Klaida inicijuojant surinktų duomenų šalinimą");
            }
        }

        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            string info = baloonInfoString();
            notifyIcon.ShowBalloonTip(500, "", info, ToolTipIcon.None);
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
            //this.notifyIcon.Visible = false;
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if(this.WindowState == FormWindowState.Minimized)
            {
                this.ShowInTaskbar = false;
                //this.notifyIcon.Visible = true;
            }
        }

        private void notifyIcon_BalloonTipClicked(object sender, EventArgs e)
        {
            notifyIcon_MouseDoubleClick(null, null);
        }

        private string baloonInfoString()
        {
            if (kpt == null) return "";

            return $@"Pelės paspaudimų: {kpt.TotalMousePress.ToString()}
{Environment.NewLine}Klavišų paspaudimų: {kpt.TotalKeyPress.ToString()}
{Environment.NewLine}Žodžių: {kpt.TotalWords.ToString()}
{Environment.NewLine}Pelės ratuko naudojimo santykis: {kpt.TotalMouseWheelUp}/{kpt.TotalMouseWheelDown}
{Environment.NewLine}Per: {kpt.StopWach.Elapsed.ToString(@"dd\.hh\:mm\:ss")}";
        }

        /// <summary>
        /// Method is called only from other thread/task
        /// </summary>
        private void LogInfo()
        {
            while (true)
            {
                try
                {
                    LogHelper.LogInfoMsg(Environment.NewLine + baloonInfoString());

                    Thread.Sleep(1800000); //1 800 000 milliseconds = 30 minutes
                }
                catch{}
            }
        }
        

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Thread.Sleep(5000);
            //KeyboardControlAdapter.pressAndReleaseButton(VirtualKeysEnum.VK_BACK);
            //KeyboardControlAdapter.pressAndReleaseButton(VirtualKeysEnum.VK_BACK);
            //KeyboardControlAdapter.pressAndReleaseButton(VirtualKeysEnum.VK_BACK);
            //KeyboardControlAdapter.pressAndReleaseButton(VirtualKeysEnum.VK_BACK);

            notifyIcon.ShowBalloonTip(5000, "title", "text", ToolTipIcon.Info);

        }

        private void timer_workTime_Tick(object sender, EventArgs e)
        {
            if (kpt == null || kpt.StopWach == null)
                return;

            toolStripStatusLabel_totalWorkTime.Text = kpt.StopWach.Elapsed.ToString(@"dd\.hh\:mm\:ss");
        }

        private void test2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notifyIcon.SetIcon(NotifyIconExtensions.NotifyIconType.red);
            //notifyIcon.Icon = new Icon(@"C:\Users\Val\GitHub\Repos\kp\KeyboardPress\Graphicloads-Seo-Services-Tags.ico");
        }
    }
}
