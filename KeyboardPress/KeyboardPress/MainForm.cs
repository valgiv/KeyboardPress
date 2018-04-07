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
using KeyboardPress_Analyzer.Objects;
using KeyboardPress.OfferWord;
using KeyboardPress_Extensions.InfoForm;
using System.Configuration;

namespace KeyboardPress
{
    // v.1.0.0.0
    public partial class MainForm : Form, IKeyboardPressAdapter
    {
        private KeyboardPressTracking kpt;
        private Task logInfoTask;

        bool periodicalDbSaveChanges = false;

        public MainForm()
        {
            InitializeComponent();
            this.Text = "Keyboard Press Analyzer";

        }
        
        private void StartUp()
        {
            LoadConfiguration();

            TestDBConnectionOnLoad();

            SetControls();
            
            toolStripItem_debug.Checked = true;
            toolStripItem_debug_Click(null, null);

            bool startOnStartUp = true;
            toolStripItem_start.Checked = startOnStartUp;
            toolStripItem_start_Click(null, null);

            LogHelper.LogInfoMsg("Programa pradeda darbą");

            logInfoTask = new Task(() => { LogInfo(); });
            logInfoTask.Start();

            this.notifyIcon.Visible = true;
            
            Db_LoadData();
        }

        private void LoadConfiguration()
        {
            try
            {
                if (ConfigurationManager.AppSettings["PeriodicalDbSaveChanges"].ToString() == "1" || ConfigurationManager.AppSettings["PeriodicalDbSaveChanges"].ToString().ToLower() == "true")
                    periodicalDbSaveChanges = true;
            }
            catch(Exception ex)
            {
                LogHelper.ShowErrorMsgWithLog("Klaida skaitant konfigūracijos failą", ex);
            }
        }

        #region ToolStrip meniu items

        private void toolStripItem_debug_Click(object sender, EventArgs e)
        {
            bool visibleChanged = panelDebug.Visible == toolStripItem_debug.Checked ? false : true;
            panelDebug.Visible = toolStripItem_debug.Checked;

            int maxWidth = 0;
            foreach(var screen in Screen.AllScreens)
            {
                if (screen.WorkingArea.Width > maxWidth)
                    maxWidth = screen.WorkingArea.Width;
            }

            if (panelDebug.Visible)
            {
                DebugHelper.Start(richTB_debug);
                if (visibleChanged)
                {
                    if (this.Width + panelDebug.Width < maxWidth)
                        this.Width = this.Width + panelDebug.Width;
                    else
                        this.Width = maxWidth;
                }
            }
            else
            {
                DebugHelper.Stop();
                if (visibleChanged)
                {
                    this.Width = this.Width - richTB_debug.Width;
                }
            }
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

        //private void toolStripItem_clean_Click(object sender, EventArgs e)
        //{
        //    CleanData();
        //}

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
                LogHelper.LogErrorMsg(ex);
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if (kpt != null)
                    kpt.StopHookWork();

                Db_SaveChanges();
            }
            catch (Exception ex)
            {
                LogHelper.LogErrorMsg(ex);
                Console.WriteLine("NENUMATYTA KLAIDA: " + ex.Message);
            }
        }

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
                LogHelper.LogErrorMsg(ex);
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
                LogHelper.LogErrorMsg(ex);
                MessageBox.Show("Klaida sustabdant klavišų paspaudimų fiksavimą");
            }
        }

        //public void CleanData()
        //{
        //    try
        //    {
        //        kpt.CleanData();
        //    }
        //    catch(Exception ex)
        //    {
        //        LogHelper.LogErrorMsg(ex);
        //        MessageBox.Show("Klaida inicijuojant surinktų duomenų šalinimą");
        //    }
        //}

        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            string info = baloonInfoString();
            InfoForm.Show($"{info}",
                "Informacija", 5000,
                InfoForm.Enum_InfoFormImage.HeadMind,
                null);
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

        private void SetControls()
        {
            Helper.UiControls.Add(tbTotalWords, EnumUiControlTag.TotalWords);
            Helper.UiControls.Add(tbLastWord, EnumUiControlTag.LastWord);
            Helper.UiControls.Add(tbTotalWordsWithMistakes, EnumUiControlTag.TotalWordsMistakes);
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
                    Console.WriteLine("started LogInfo() method...");
                    LogHelper.LogInfoMsg(Environment.NewLine + baloonInfoString());

                    
                    //Thread.Sleep(1800000); //1 800 000 milliseconds = 30 minutes
                    Thread.Sleep(300000); //5min

                    if (periodicalDbSaveChanges)
                    {
                        LogHelper.LogInfoMsg(Environment.NewLine + "Periodinis duomenų saugojimas į db - pradedamas");
                        Db_SaveChanges();
                        LogHelper.LogInfoMsg(Environment.NewLine + "Periodinis duomenų saugojimas į db - įvykdytas");
                    }
                }
                catch{}
            }
        }
        
        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void timer_workTime_Tick(object sender, EventArgs e)
        {
            if (kpt == null || kpt.StopWach == null)
                return;

            toolStripStatusLabel_totalWorkTime.Text = kpt.StopWach.Elapsed.ToString(@"dd\.hh\:mm\:ss");
        }

        private void test2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //InfoForm.Show(2000, InfoForm.Enum_InfoFormImage.BulbBlack);
            
            //InfoForm.Show(2000, InfoForm.Enum_InfoFormImage.BulbQ);

            //InfoForm.Show(2000, InfoForm.Enum_InfoFormImage.HeadConfig);

            //InfoForm.Show(2000, InfoForm.Enum_InfoFormImage.HeadMind);

            string text = @"Labas
1
2
-33333333333333333333333333333333333333333333333-
4
5
6
7
8
testas";

            //InfoForm.Show(text,
            //    "Pavadinimas", 2000,
            //    InfoForm.Enum_InfoFormImage.Precent,
            //    null);

            Task t = new Task(() =>
            {
                InfoForm.Show(text,
                "Pavadinimas", 2000,
                InfoForm.Enum_InfoFormImage.Precent,
                null);
            });
            t.Start();

            //Thread t = new Thread(delegate ()
            //{
            //    var form = new InfoFormDialog("tst", "ewgvszdfv", 3000, null, null);
            //    //form.SetFormPosition(CalculateFormLocation(form));
            //    //FormWithoutActivation.ShowInactiveTopmost(form);
            //    form.Show();
            //    System.Windows.Threading.Dispatcher.Run();
            //});
            ////t.SetApartmentState(ApartmentState.STA);
            //t.Start();



            //Task t = new Task(() =>
            //{
            //    var form = new InfoFormDialog("tst", "ewgvszdfv", 3000, null, new Action(()=>
            //    {
            //        testAction();
            //    }));
            //    //form.SetFormPosition(CalculateFormLocation(form));
            //    //FormWithoutActivation.ShowInactiveTopmost(form);
            //    form.Show();
            //    System.Windows.Threading.Dispatcher.Run();
            //});
            //t.Start();

        }

        public void testAction()
        {

        }

        private void TestDBConnectionOnLoad()
        {
            if(!DBHelper.TestConnection())
            {
                MessageBox.Show("Nepavyksta prisijunti prie duomenų bazės");
                return;
            }
            var user = DBHelper.UserId;
        }

        private void karščioŽemėlapisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                List<ObjKeyPressCount> a = kpt.KeyPressCountObjList;

                //Keyboard k = new Keyboard(a);
                //k.ShowDialog();

                new EmptyForm(new KeyboardUc(a), "Karščio žemėlapis", true).ShowDialog();
            }
            catch (Exception ex)
            {
                LogHelper.LogErrorMsg(ex);
                MessageBox.Show($"Klaida atveriant langą\n{ex.Message}", "Klaida", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void offerWordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ucOfferWord uc = new ucOfferWord();
                EmptyForm form = new EmptyForm(uc, "Žodžių keitimas", true);
                form.ShowDialog();
                kpt.Reload_OfferWordClass_Data();
            }
            catch(Exception ex)
            {
                LogHelper.LogErrorMsg(ex);
            }
        }

        #region Data Database

        private void loadDataDbToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Db_LoadData();
            LogHelper.ShowInfoMsgWithLog("Duomenys sėkmingai užkrauti");
        }

        private void saveDataDbToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Db_SaveChanges();
            LogHelper.ShowInfoMsgWithLog("Duomenys sėkmingai išsaugoti");
        }

        private void deleteDataDbToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(Db_DeleteDataFromDatabase())
            LogHelper.ShowInfoMsgWithLog("Duomenys sėkmingai pašalinti");
        }

        private void deleteDataLocalMemoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(Db_DeleteDataFromLocalMemory())
                LogHelper.ShowInfoMsgWithLog("Duomenys iš lokalios atminties sėkmingai pašalinti");
        }

        private bool Db_SaveChanges(bool silentMode = false)
        {
            try
            {
                if (kpt != null)
                    kpt.Db_SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                if (!silentMode)
                    LogHelper.ShowErrorMsgWithLog($"Klaida išsaugant duomenis į duomenų bazę: {ex.Message}", ex);
                else
                    LogHelper.LogInfoMsg($"Klaida išsaugant duomenis į duomenų bazę: {ex.Message}");
                return false;
            }
        }

        private bool Db_LoadData()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (kpt != null)
                    kpt.Db_LoadData();
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.ShowErrorMsgWithLog($"Klaida užkraunant duomenis iš duomenų bazės: {ex.Message}", ex);
                return false;
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private bool Db_DeleteDataFromDatabase()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (kpt != null)
                    kpt.Db_DeleteDataFromDatabase();
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.ShowErrorMsgWithLog($"Klaida šalinant duomenis iš duomenų bazės: {ex.Message}", ex);
                return false;
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private bool Db_DeleteDataFromLocalMemory()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (kpt != null)
                    kpt.Db_DeleteDataFromLocalMemory();
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.ShowErrorMsgWithLog($"Klaida šalinant duomenis į lokalios atminties: {ex.Message}", ex);
                return false;
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        #endregion Data Database

        private void tabControlMain_DrawItem(object sender, DrawItemEventArgs e)
        {
            var g = e.Graphics;
            var text = this.tabControlMain.TabPages[e.Index].Text;
            var sizeText = g.MeasureString(text, this.tabControlMain.Font);

            var x = e.Bounds.Left + 3;
            var y = e.Bounds.Top + (e.Bounds.Height - sizeText.Height) / 2;

            //
            SolidBrush _TextBrush = null;
            Font _Font = null;
            if (e.State == DrawItemState.Selected)
            {
                _TextBrush = new SolidBrush(Color.Black);
                //g.FillRectangle(Brushes.Gray, e.Bounds);
                _Font = new Font(this.tabControlMain.Font, FontStyle.Bold);
            }
            else
            {
                _TextBrush = new SolidBrush(Color.Black);
                _Font = this.tabControlMain.Font;
            }
            //

            //g.DrawString(text, this.tabControlMain.Font, Brushes.Black, x, y);
            g.DrawString(text, _Font, _TextBrush, x, y);
        }
        
        private void tabControlMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            //tabControlMain.TabPages[2].Text = "tst";
        }
    }
}
