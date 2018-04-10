namespace KeyboardPress
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.setingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripItem_start = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripItem_stop = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripItem_debug = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripItem_cleanDebugWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.administrationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.offerWordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.apieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informacijaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.karščioŽemėlapisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadDataDbToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveDataDbToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteDataDbToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteDataLocalMemoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel_info = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_totalWorkTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.panelDebug = new System.Windows.Forms.Panel();
            this.richTB_debug = new System.Windows.Forms.RichTextBox();
            this.panelMain = new System.Windows.Forms.Panel();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageMainInfo = new System.Windows.Forms.TabPage();
            this.tbAvgPressH = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.tbAvgPressMin = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.tbAvgPressReleaseH = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.tbAvgPressReleaseMin = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.tbAvgWrdH = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.tbAvgWrdMin = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.tbAvgMousePressH = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.tbAvgMousePressMin = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.tbTotalWorkTime = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbMouseKeyboardRatio = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tbKeyPress = new System.Windows.Forms.TextBox();
            this.tbMousePress = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbMouseWheelDown = new System.Windows.Forms.TextBox();
            this.tbMouseWheelUp = new System.Windows.Forms.TextBox();
            this.tbRestTime = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbWorkTime = new System.Windows.Forms.TextBox();
            this.tbMouseWheelRatio = new System.Windows.Forms.TextBox();
            this.tbRightMousePress = new System.Windows.Forms.TextBox();
            this.tbLeftMousePress = new System.Windows.Forms.TextBox();
            this.tbKeyPressRelease = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTotalWords = new System.Windows.Forms.Label();
            this.lblLastWordWithMistake = new System.Windows.Forms.Label();
            this.tbTotalWords = new System.Windows.Forms.TextBox();
            this.lblLastWord = new System.Windows.Forms.Label();
            this.tbLastWord = new System.Windows.Forms.TextBox();
            this.tbTotalWordsWithMistakes = new System.Windows.Forms.TextBox();
            this.tabPageMouse = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabKeyboardHeatMap = new System.Windows.Forms.TabPage();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.timer_workTime = new System.Windows.Forms.Timer(this.components);
            this.timer_uiUpdateTrigger = new System.Windows.Forms.Timer(this.components);
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.panelDebug.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.tabControlMain.SuspendLayout();
            this.tabPageMainInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setingsToolStripMenuItem,
            this.administrationToolStripMenuItem,
            this.apieToolStripMenuItem,
            this.karščioŽemėlapisToolStripMenuItem,
            this.dBToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1116, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip";
            // 
            // setingsToolStripMenuItem
            // 
            this.setingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripItem_start,
            this.toolStripItem_stop,
            this.toolStripSeparator1,
            this.toolStripItem_debug,
            this.toolStripItem_cleanDebugWindow});
            this.setingsToolStripMenuItem.Name = "setingsToolStripMenuItem";
            this.setingsToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.setingsToolStripMenuItem.Text = "Nustatymai";
            // 
            // toolStripItem_start
            // 
            this.toolStripItem_start.CheckOnClick = true;
            this.toolStripItem_start.Name = "toolStripItem_start";
            this.toolStripItem_start.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F5)));
            this.toolStripItem_start.Size = new System.Drawing.Size(224, 22);
            this.toolStripItem_start.Text = "Pradėti";
            this.toolStripItem_start.Click += new System.EventHandler(this.toolStripItem_start_Click);
            // 
            // toolStripItem_stop
            // 
            this.toolStripItem_stop.CheckOnClick = true;
            this.toolStripItem_stop.Name = "toolStripItem_stop";
            this.toolStripItem_stop.Size = new System.Drawing.Size(224, 22);
            this.toolStripItem_stop.Text = "Sustabdyti";
            this.toolStripItem_stop.Click += new System.EventHandler(this.toolStripItem_stop_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(221, 6);
            // 
            // toolStripItem_debug
            // 
            this.toolStripItem_debug.CheckOnClick = true;
            this.toolStripItem_debug.Name = "toolStripItem_debug";
            this.toolStripItem_debug.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F10)));
            this.toolStripItem_debug.Size = new System.Drawing.Size(224, 22);
            this.toolStripItem_debug.Text = "Debug";
            this.toolStripItem_debug.Click += new System.EventHandler(this.toolStripItem_debug_Click);
            // 
            // toolStripItem_cleanDebugWindow
            // 
            this.toolStripItem_cleanDebugWindow.Name = "toolStripItem_cleanDebugWindow";
            this.toolStripItem_cleanDebugWindow.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F11)));
            this.toolStripItem_cleanDebugWindow.Size = new System.Drawing.Size(224, 22);
            this.toolStripItem_cleanDebugWindow.Text = "Valyti debug langą";
            this.toolStripItem_cleanDebugWindow.Click += new System.EventHandler(this.toolStripItem_cleanDebugWindow_Click);
            // 
            // administrationToolStripMenuItem
            // 
            this.administrationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.offerWordToolStripMenuItem});
            this.administrationToolStripMenuItem.Name = "administrationToolStripMenuItem";
            this.administrationToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.administrationToolStripMenuItem.Text = "Valdymas";
            // 
            // offerWordToolStripMenuItem
            // 
            this.offerWordToolStripMenuItem.Name = "offerWordToolStripMenuItem";
            this.offerWordToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.offerWordToolStripMenuItem.Text = "Reikšmių keitimas";
            this.offerWordToolStripMenuItem.Click += new System.EventHandler(this.offerWordToolStripMenuItem_Click);
            // 
            // apieToolStripMenuItem
            // 
            this.apieToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.informacijaToolStripMenuItem});
            this.apieToolStripMenuItem.Name = "apieToolStripMenuItem";
            this.apieToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.apieToolStripMenuItem.Text = "Apie";
            // 
            // informacijaToolStripMenuItem
            // 
            this.informacijaToolStripMenuItem.Name = "informacijaToolStripMenuItem";
            this.informacijaToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.informacijaToolStripMenuItem.Text = "Informacija";
            // 
            // karščioŽemėlapisToolStripMenuItem
            // 
            this.karščioŽemėlapisToolStripMenuItem.Name = "karščioŽemėlapisToolStripMenuItem";
            this.karščioŽemėlapisToolStripMenuItem.Size = new System.Drawing.Size(122, 20);
            this.karščioŽemėlapisToolStripMenuItem.Text = "\"Karščio\" žemėlapis";
            this.karščioŽemėlapisToolStripMenuItem.Click += new System.EventHandler(this.karščioŽemėlapisToolStripMenuItem_Click);
            // 
            // dBToolStripMenuItem
            // 
            this.dBToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadDataDbToolStripMenuItem,
            this.saveDataDbToolStripMenuItem,
            this.deleteDataDbToolStripMenuItem,
            this.deleteDataLocalMemoryToolStripMenuItem});
            this.dBToolStripMenuItem.Name = "dBToolStripMenuItem";
            this.dBToolStripMenuItem.Size = new System.Drawing.Size(34, 20);
            this.dBToolStripMenuItem.Text = "DB";
            // 
            // loadDataDbToolStripMenuItem
            // 
            this.loadDataDbToolStripMenuItem.Name = "loadDataDbToolStripMenuItem";
            this.loadDataDbToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.loadDataDbToolStripMenuItem.Text = "Užkrauti";
            this.loadDataDbToolStripMenuItem.Click += new System.EventHandler(this.loadDataDbToolStripMenuItem_Click);
            // 
            // saveDataDbToolStripMenuItem
            // 
            this.saveDataDbToolStripMenuItem.Name = "saveDataDbToolStripMenuItem";
            this.saveDataDbToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.saveDataDbToolStripMenuItem.Text = "Išsaugoti";
            this.saveDataDbToolStripMenuItem.Click += new System.EventHandler(this.saveDataDbToolStripMenuItem_Click);
            // 
            // deleteDataDbToolStripMenuItem
            // 
            this.deleteDataDbToolStripMenuItem.Name = "deleteDataDbToolStripMenuItem";
            this.deleteDataDbToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.deleteDataDbToolStripMenuItem.Text = "Pašalinti";
            this.deleteDataDbToolStripMenuItem.Click += new System.EventHandler(this.deleteDataDbToolStripMenuItem_Click);
            // 
            // deleteDataLocalMemoryToolStripMenuItem
            // 
            this.deleteDataLocalMemoryToolStripMenuItem.Name = "deleteDataLocalMemoryToolStripMenuItem";
            this.deleteDataLocalMemoryToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.deleteDataLocalMemoryToolStripMenuItem.Text = "Pašalinti iš atminties";
            this.deleteDataLocalMemoryToolStripMenuItem.Click += new System.EventHandler(this.deleteDataLocalMemoryToolStripMenuItem_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipText = "test";
            this.notifyIcon.BalloonTipTitle = "test";
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.BalloonTipClicked += new System.EventHandler(this.notifyIcon_BalloonTipClicked);
            this.notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseClick);
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // statusStrip
            // 
            this.statusStrip.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel_info,
            this.toolStripStatusLabel_totalWorkTime});
            this.statusStrip.Location = new System.Drawing.Point(0, 420);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1116, 22);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip";
            // 
            // toolStripStatusLabel_info
            // 
            this.toolStripStatusLabel_info.Name = "toolStripStatusLabel_info";
            this.toolStripStatusLabel_info.Size = new System.Drawing.Size(31, 17);
            this.toolStripStatusLabel_info.Text = "Info:";
            // 
            // toolStripStatusLabel_totalWorkTime
            // 
            this.toolStripStatusLabel_totalWorkTime.Name = "toolStripStatusLabel_totalWorkTime";
            this.toolStripStatusLabel_totalWorkTime.Size = new System.Drawing.Size(1070, 17);
            this.toolStripStatusLabel_totalWorkTime.Spring = true;
            this.toolStripStatusLabel_totalWorkTime.Text = "--";
            this.toolStripStatusLabel_totalWorkTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panelDebug
            // 
            this.panelDebug.Controls.Add(this.richTB_debug);
            this.panelDebug.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelDebug.Location = new System.Drawing.Point(782, 24);
            this.panelDebug.Name = "panelDebug";
            this.panelDebug.Size = new System.Drawing.Size(334, 396);
            this.panelDebug.TabIndex = 2;
            // 
            // richTB_debug
            // 
            this.richTB_debug.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.richTB_debug.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTB_debug.ForeColor = System.Drawing.Color.LimeGreen;
            this.richTB_debug.Location = new System.Drawing.Point(0, 0);
            this.richTB_debug.Name = "richTB_debug";
            this.richTB_debug.ReadOnly = true;
            this.richTB_debug.Size = new System.Drawing.Size(334, 396);
            this.richTB_debug.TabIndex = 0;
            this.richTB_debug.Text = "";
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panelMain.Controls.Add(this.tabControlMain);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 24);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(782, 396);
            this.panelMain.TabIndex = 3;
            // 
            // tabControlMain
            // 
            this.tabControlMain.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControlMain.Controls.Add(this.tabPageMainInfo);
            this.tabControlMain.Controls.Add(this.tabPageMouse);
            this.tabControlMain.Controls.Add(this.tabPage3);
            this.tabControlMain.Controls.Add(this.tabPage4);
            this.tabControlMain.Controls.Add(this.tabKeyboardHeatMap);
            this.tabControlMain.Controls.Add(this.tabPage6);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControlMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControlMain.ItemSize = new System.Drawing.Size(30, 120);
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Multiline = true;
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(782, 396);
            this.tabControlMain.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControlMain.TabIndex = 10;
            this.tabControlMain.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControlMain_DrawItem);
            this.tabControlMain.SelectedIndexChanged += new System.EventHandler(this.tabControlMain_SelectedIndexChanged);
            // 
            // tabPageMainInfo
            // 
            this.tabPageMainInfo.Controls.Add(this.tbAvgPressH);
            this.tabPageMainInfo.Controls.Add(this.label19);
            this.tabPageMainInfo.Controls.Add(this.tbAvgPressMin);
            this.tabPageMainInfo.Controls.Add(this.label20);
            this.tabPageMainInfo.Controls.Add(this.tbAvgPressReleaseH);
            this.tabPageMainInfo.Controls.Add(this.label18);
            this.tabPageMainInfo.Controls.Add(this.tbAvgPressReleaseMin);
            this.tabPageMainInfo.Controls.Add(this.label17);
            this.tabPageMainInfo.Controls.Add(this.tbAvgWrdH);
            this.tabPageMainInfo.Controls.Add(this.label16);
            this.tabPageMainInfo.Controls.Add(this.tbAvgWrdMin);
            this.tabPageMainInfo.Controls.Add(this.label15);
            this.tabPageMainInfo.Controls.Add(this.tbAvgMousePressH);
            this.tabPageMainInfo.Controls.Add(this.label14);
            this.tabPageMainInfo.Controls.Add(this.tbAvgMousePressMin);
            this.tabPageMainInfo.Controls.Add(this.label13);
            this.tabPageMainInfo.Controls.Add(this.label12);
            this.tabPageMainInfo.Controls.Add(this.tbTotalWorkTime);
            this.tabPageMainInfo.Controls.Add(this.label1);
            this.tabPageMainInfo.Controls.Add(this.tbMouseKeyboardRatio);
            this.tabPageMainInfo.Controls.Add(this.label11);
            this.tabPageMainInfo.Controls.Add(this.tbKeyPress);
            this.tabPageMainInfo.Controls.Add(this.tbMousePress);
            this.tabPageMainInfo.Controls.Add(this.label10);
            this.tabPageMainInfo.Controls.Add(this.label9);
            this.tabPageMainInfo.Controls.Add(this.label8);
            this.tabPageMainInfo.Controls.Add(this.tbMouseWheelDown);
            this.tabPageMainInfo.Controls.Add(this.tbMouseWheelUp);
            this.tabPageMainInfo.Controls.Add(this.tbRestTime);
            this.tabPageMainInfo.Controls.Add(this.label7);
            this.tabPageMainInfo.Controls.Add(this.label6);
            this.tabPageMainInfo.Controls.Add(this.label5);
            this.tabPageMainInfo.Controls.Add(this.label4);
            this.tabPageMainInfo.Controls.Add(this.tbWorkTime);
            this.tabPageMainInfo.Controls.Add(this.tbMouseWheelRatio);
            this.tabPageMainInfo.Controls.Add(this.tbRightMousePress);
            this.tabPageMainInfo.Controls.Add(this.tbLeftMousePress);
            this.tabPageMainInfo.Controls.Add(this.tbKeyPressRelease);
            this.tabPageMainInfo.Controls.Add(this.label3);
            this.tabPageMainInfo.Controls.Add(this.label2);
            this.tabPageMainInfo.Controls.Add(this.lblTotalWords);
            this.tabPageMainInfo.Controls.Add(this.lblLastWordWithMistake);
            this.tabPageMainInfo.Controls.Add(this.tbTotalWords);
            this.tabPageMainInfo.Controls.Add(this.lblLastWord);
            this.tabPageMainInfo.Controls.Add(this.tbLastWord);
            this.tabPageMainInfo.Controls.Add(this.tbTotalWordsWithMistakes);
            this.tabPageMainInfo.Location = new System.Drawing.Point(124, 4);
            this.tabPageMainInfo.Name = "tabPageMainInfo";
            this.tabPageMainInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMainInfo.Size = new System.Drawing.Size(654, 388);
            this.tabPageMainInfo.TabIndex = 0;
            this.tabPageMainInfo.Text = "Informacija";
            this.tabPageMainInfo.UseVisualStyleBackColor = true;
            // 
            // tbAvgPressH
            // 
            this.tbAvgPressH.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.tbAvgPressH.Location = new System.Drawing.Point(533, 307);
            this.tbAvgPressH.Name = "tbAvgPressH";
            this.tbAvgPressH.ReadOnly = true;
            this.tbAvgPressH.Size = new System.Drawing.Size(115, 20);
            this.tbAvgPressH.TabIndex = 51;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(375, 310);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(104, 13);
            this.label19.TabIndex = 50;
            this.label19.Text = "Vid. klav. nusp per h";
            // 
            // tbAvgPressMin
            // 
            this.tbAvgPressMin.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.tbAvgPressMin.Location = new System.Drawing.Point(533, 282);
            this.tbAvgPressMin.Name = "tbAvgPressMin";
            this.tbAvgPressMin.ReadOnly = true;
            this.tbAvgPressMin.Size = new System.Drawing.Size(115, 20);
            this.tbAvgPressMin.TabIndex = 49;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(375, 285);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(114, 13);
            this.label20.TabIndex = 48;
            this.label20.Text = "Vid. klav. nusp per min";
            // 
            // tbAvgPressReleaseH
            // 
            this.tbAvgPressReleaseH.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.tbAvgPressReleaseH.Location = new System.Drawing.Point(533, 259);
            this.tbAvgPressReleaseH.Name = "tbAvgPressReleaseH";
            this.tbAvgPressReleaseH.ReadOnly = true;
            this.tbAvgPressReleaseH.Size = new System.Drawing.Size(115, 20);
            this.tbAvgPressReleaseH.TabIndex = 47;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(380, 262);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(148, 13);
            this.label18.TabIndex = 46;
            this.label18.Text = "Vid. klavišų paspaudimų per h";
            // 
            // tbAvgPressReleaseMin
            // 
            this.tbAvgPressReleaseMin.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.tbAvgPressReleaseMin.Location = new System.Drawing.Point(533, 233);
            this.tbAvgPressReleaseMin.Name = "tbAvgPressReleaseMin";
            this.tbAvgPressReleaseMin.ReadOnly = true;
            this.tbAvgPressReleaseMin.Size = new System.Drawing.Size(115, 20);
            this.tbAvgPressReleaseMin.TabIndex = 45;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(375, 236);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(161, 13);
            this.label17.TabIndex = 44;
            this.label17.Text = "Vid. klavišų paspaudimų per min.";
            // 
            // tbAvgWrdH
            // 
            this.tbAvgWrdH.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.tbAvgWrdH.Location = new System.Drawing.Point(533, 207);
            this.tbAvgWrdH.Name = "tbAvgWrdH";
            this.tbAvgWrdH.ReadOnly = true;
            this.tbAvgWrdH.Size = new System.Drawing.Size(115, 20);
            this.tbAvgWrdH.TabIndex = 43;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(375, 210);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(96, 13);
            this.label16.TabIndex = 42;
            this.label16.Text = "Vid. užfiks. ž. per h";
            // 
            // tbAvgWrdMin
            // 
            this.tbAvgWrdMin.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.tbAvgWrdMin.Location = new System.Drawing.Point(533, 181);
            this.tbAvgWrdMin.Name = "tbAvgWrdMin";
            this.tbAvgWrdMin.ReadOnly = true;
            this.tbAvgWrdMin.Size = new System.Drawing.Size(115, 20);
            this.tbAvgWrdMin.TabIndex = 41;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(375, 184);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(109, 13);
            this.label15.TabIndex = 40;
            this.label15.Text = "Vid. užfiks. ž. per min.";
            // 
            // tbAvgMousePressH
            // 
            this.tbAvgMousePressH.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.tbAvgMousePressH.Location = new System.Drawing.Point(533, 155);
            this.tbAvgMousePressH.Name = "tbAvgMousePressH";
            this.tbAvgMousePressH.ReadOnly = true;
            this.tbAvgMousePressH.Size = new System.Drawing.Size(115, 20);
            this.tbAvgMousePressH.TabIndex = 39;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(375, 158);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(140, 13);
            this.label14.TabIndex = 38;
            this.label14.Text = "Vid. pelės paspaudimų per h";
            // 
            // tbAvgMousePressMin
            // 
            this.tbAvgMousePressMin.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.tbAvgMousePressMin.Location = new System.Drawing.Point(533, 130);
            this.tbAvgMousePressMin.Name = "tbAvgMousePressMin";
            this.tbAvgMousePressMin.ReadOnly = true;
            this.tbAvgMousePressMin.Size = new System.Drawing.Size(115, 20);
            this.tbAvgMousePressMin.TabIndex = 37;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(375, 133);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(153, 13);
            this.label13.TabIndex = 36;
            this.label13.Text = "Vid. pelės paspaudimų per min.";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(107, 366);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(101, 13);
            this.label12.TabIndex = 35;
            this.label12.Text = "Visas veikimo laikas";
            // 
            // tbTotalWorkTime
            // 
            this.tbTotalWorkTime.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.tbTotalWorkTime.Location = new System.Drawing.Point(214, 363);
            this.tbTotalWorkTime.Name = "tbTotalWorkTime";
            this.tbTotalWorkTime.ReadOnly = true;
            this.tbTotalWorkTime.Size = new System.Drawing.Size(155, 20);
            this.tbTotalWorkTime.TabIndex = 34;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 340);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 13);
            this.label1.TabIndex = 33;
            this.label1.Text = "Pelės/klaviatūros naudojimo santykis";
            // 
            // tbMouseKeyboardRatio
            // 
            this.tbMouseKeyboardRatio.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.tbMouseKeyboardRatio.Location = new System.Drawing.Point(214, 337);
            this.tbMouseKeyboardRatio.Name = "tbMouseKeyboardRatio";
            this.tbMouseKeyboardRatio.ReadOnly = true;
            this.tbMouseKeyboardRatio.Size = new System.Drawing.Size(155, 20);
            this.tbMouseKeyboardRatio.TabIndex = 32;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(107, 107);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(101, 13);
            this.label11.TabIndex = 31;
            this.label11.Text = "Klavišų nuspaudimų";
            // 
            // tbKeyPress
            // 
            this.tbKeyPress.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.tbKeyPress.Location = new System.Drawing.Point(214, 104);
            this.tbKeyPress.Name = "tbKeyPress";
            this.tbKeyPress.ReadOnly = true;
            this.tbKeyPress.Size = new System.Drawing.Size(155, 20);
            this.tbKeyPress.TabIndex = 30;
            this.tbKeyPress.TextChanged += new System.EventHandler(this.tbMouseKeyboardRatioChange);
            // 
            // tbMousePress
            // 
            this.tbMousePress.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.tbMousePress.Location = new System.Drawing.Point(214, 130);
            this.tbMousePress.Name = "tbMousePress";
            this.tbMousePress.ReadOnly = true;
            this.tbMousePress.Size = new System.Drawing.Size(155, 20);
            this.tbMousePress.TabIndex = 29;
            this.tbMousePress.TextChanged += new System.EventHandler(this.tbMouseKeyboardRatioChange);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(93, 133);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(115, 13);
            this.label10.TabIndex = 28;
            this.label10.Text = "Viso palės nuspaudimų";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(104, 236);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(104, 13);
            this.label9.TabIndex = 27;
            this.label9.Text = "Pelės ratukas žemyn";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(93, 210);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(111, 13);
            this.label8.TabIndex = 26;
            this.label8.Text = "Pelės ratukas aukštyn";
            // 
            // tbMouseWheelDown
            // 
            this.tbMouseWheelDown.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.tbMouseWheelDown.Location = new System.Drawing.Point(214, 233);
            this.tbMouseWheelDown.Name = "tbMouseWheelDown";
            this.tbMouseWheelDown.ReadOnly = true;
            this.tbMouseWheelDown.Size = new System.Drawing.Size(155, 20);
            this.tbMouseWheelDown.TabIndex = 25;
            this.tbMouseWheelDown.TextChanged += new System.EventHandler(this.tbMouseWheel_TextChanged);
            // 
            // tbMouseWheelUp
            // 
            this.tbMouseWheelUp.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.tbMouseWheelUp.Location = new System.Drawing.Point(214, 207);
            this.tbMouseWheelUp.Name = "tbMouseWheelUp";
            this.tbMouseWheelUp.ReadOnly = true;
            this.tbMouseWheelUp.Size = new System.Drawing.Size(155, 20);
            this.tbMouseWheelUp.TabIndex = 24;
            this.tbMouseWheelUp.TextChanged += new System.EventHandler(this.tbMouseWheel_TextChanged);
            // 
            // tbRestTime
            // 
            this.tbRestTime.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.tbRestTime.Location = new System.Drawing.Point(214, 311);
            this.tbRestTime.Name = "tbRestTime";
            this.tbRestTime.ReadOnly = true;
            this.tbRestTime.Size = new System.Drawing.Size(155, 20);
            this.tbRestTime.TabIndex = 23;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(120, 314);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "Pertraukos laikas";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(142, 288);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Darbo laikas";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(66, 184);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(142, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "D. pelės klavišų paspaudimų";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(73, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "K. pelės klvišo paspaudimų";
            // 
            // tbWorkTime
            // 
            this.tbWorkTime.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.tbWorkTime.Location = new System.Drawing.Point(214, 285);
            this.tbWorkTime.Name = "tbWorkTime";
            this.tbWorkTime.ReadOnly = true;
            this.tbWorkTime.Size = new System.Drawing.Size(155, 20);
            this.tbWorkTime.TabIndex = 18;
            // 
            // tbMouseWheelRatio
            // 
            this.tbMouseWheelRatio.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.tbMouseWheelRatio.Location = new System.Drawing.Point(214, 259);
            this.tbMouseWheelRatio.Name = "tbMouseWheelRatio";
            this.tbMouseWheelRatio.ReadOnly = true;
            this.tbMouseWheelRatio.Size = new System.Drawing.Size(155, 20);
            this.tbMouseWheelRatio.TabIndex = 17;
            // 
            // tbRightMousePress
            // 
            this.tbRightMousePress.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.tbRightMousePress.Location = new System.Drawing.Point(214, 181);
            this.tbRightMousePress.Name = "tbRightMousePress";
            this.tbRightMousePress.ReadOnly = true;
            this.tbRightMousePress.Size = new System.Drawing.Size(155, 20);
            this.tbRightMousePress.TabIndex = 16;
            // 
            // tbLeftMousePress
            // 
            this.tbLeftMousePress.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.tbLeftMousePress.Location = new System.Drawing.Point(214, 155);
            this.tbLeftMousePress.Name = "tbLeftMousePress";
            this.tbLeftMousePress.ReadOnly = true;
            this.tbLeftMousePress.Size = new System.Drawing.Size(155, 20);
            this.tbLeftMousePress.TabIndex = 15;
            // 
            // tbKeyPressRelease
            // 
            this.tbKeyPressRelease.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.tbKeyPressRelease.Location = new System.Drawing.Point(214, 78);
            this.tbKeyPressRelease.Name = "tbKeyPressRelease";
            this.tbKeyPressRelease.ReadOnly = true;
            this.tbKeyPressRelease.Size = new System.Drawing.Size(155, 20);
            this.tbKeyPressRelease.TabIndex = 13;
            this.tbKeyPressRelease.TextChanged += new System.EventHandler(this.tbMouseKeyboardRatioChange);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 262);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Pelės ratuko naudojimo santykis";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(107, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Klavišų paspaudimų";
            // 
            // lblTotalWords
            // 
            this.lblTotalWords.AutoSize = true;
            this.lblTotalWords.Location = new System.Drawing.Point(145, 3);
            this.lblTotalWords.Name = "lblTotalWords";
            this.lblTotalWords.Size = new System.Drawing.Size(63, 13);
            this.lblTotalWords.TabIndex = 7;
            this.lblTotalWords.Text = "Viso žodžių:";
            // 
            // lblLastWordWithMistake
            // 
            this.lblLastWordWithMistake.AutoSize = true;
            this.lblLastWordWithMistake.Location = new System.Drawing.Point(2, 55);
            this.lblLastWordWithMistake.Name = "lblLastWordWithMistake";
            this.lblLastWordWithMistake.Size = new System.Drawing.Size(206, 13);
            this.lblLastWordWithMistake.TabIndex = 9;
            this.lblLastWordWithMistake.Text = "Viso žodžių, kuriuos rašant taisytos klaidos";
            // 
            // tbTotalWords
            // 
            this.tbTotalWords.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.tbTotalWords.Location = new System.Drawing.Point(214, 0);
            this.tbTotalWords.Name = "tbTotalWords";
            this.tbTotalWords.ReadOnly = true;
            this.tbTotalWords.Size = new System.Drawing.Size(155, 20);
            this.tbTotalWords.TabIndex = 2;
            // 
            // lblLastWord
            // 
            this.lblLastWord.AutoSize = true;
            this.lblLastWord.Location = new System.Drawing.Point(70, 29);
            this.lblLastWord.Name = "lblLastWord";
            this.lblLastWord.Size = new System.Drawing.Size(138, 13);
            this.lblLastWord.TabIndex = 8;
            this.lblLastWord.Text = "Paskutinis užfiksuotas žodis";
            // 
            // tbLastWord
            // 
            this.tbLastWord.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.tbLastWord.Location = new System.Drawing.Point(214, 26);
            this.tbLastWord.Name = "tbLastWord";
            this.tbLastWord.ReadOnly = true;
            this.tbLastWord.Size = new System.Drawing.Size(155, 20);
            this.tbLastWord.TabIndex = 3;
            // 
            // tbTotalWordsWithMistakes
            // 
            this.tbTotalWordsWithMistakes.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.tbTotalWordsWithMistakes.Location = new System.Drawing.Point(214, 52);
            this.tbTotalWordsWithMistakes.Name = "tbTotalWordsWithMistakes";
            this.tbTotalWordsWithMistakes.ReadOnly = true;
            this.tbTotalWordsWithMistakes.Size = new System.Drawing.Size(155, 20);
            this.tbTotalWordsWithMistakes.TabIndex = 4;
            // 
            // tabPageMouse
            // 
            this.tabPageMouse.Location = new System.Drawing.Point(124, 4);
            this.tabPageMouse.Name = "tabPageMouse";
            this.tabPageMouse.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMouse.Size = new System.Drawing.Size(654, 388);
            this.tabPageMouse.TabIndex = 1;
            this.tabPageMouse.Text = "Pelė";
            this.tabPageMouse.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(124, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(654, 388);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Klaviatūra";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(124, 4);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(654, 388);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Klaidos";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabKeyboardHeatMap
            // 
            this.tabKeyboardHeatMap.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabKeyboardHeatMap.Location = new System.Drawing.Point(124, 4);
            this.tabKeyboardHeatMap.Name = "tabKeyboardHeatMap";
            this.tabKeyboardHeatMap.Padding = new System.Windows.Forms.Padding(3);
            this.tabKeyboardHeatMap.Size = new System.Drawing.Size(654, 388);
            this.tabKeyboardHeatMap.TabIndex = 4;
            this.tabKeyboardHeatMap.Text = "Klaviatūros karštis";
            this.tabKeyboardHeatMap.UseVisualStyleBackColor = true;
            // 
            // tabPage6
            // 
            this.tabPage6.Location = new System.Drawing.Point(124, 4);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(654, 388);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "tabPage6";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // timer_workTime
            // 
            this.timer_workTime.Interval = 1000;
            this.timer_workTime.Tick += new System.EventHandler(this.timer_workTime_Tick);
            // 
            // timer_uiUpdateTrigger
            // 
            this.timer_uiUpdateTrigger.Enabled = true;
            this.timer_uiUpdateTrigger.Interval = 3000;
            this.timer_uiUpdateTrigger.Tick += new System.EventHandler(this.timer_uiUpdateTrigger_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1116, 442);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelDebug);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.panelDebug.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            this.tabControlMain.ResumeLayout(false);
            this.tabPageMainInfo.ResumeLayout(false);
            this.tabPageMainInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem setingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripItem_debug;
        private System.Windows.Forms.ToolStripMenuItem toolStripItem_start;
        private System.Windows.Forms.ToolStripMenuItem toolStripItem_stop;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.Panel panelDebug;
        private System.Windows.Forms.RichTextBox richTB_debug;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.ToolStripMenuItem toolStripItem_cleanDebugWindow;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_info;
        private System.Windows.Forms.ToolStripMenuItem administrationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem apieToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem informacijaToolStripMenuItem;
        private System.Windows.Forms.Timer timer_workTime;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_totalWorkTime;
        private System.Windows.Forms.TextBox tbTotalWords;
        private System.Windows.Forms.Label lblLastWord;
        private System.Windows.Forms.Label lblTotalWords;
        private System.Windows.Forms.TextBox tbTotalWordsWithMistakes;
        private System.Windows.Forms.TextBox tbLastWord;
        private System.Windows.Forms.Label lblLastWordWithMistake;
        private System.Windows.Forms.ToolStripMenuItem karščioŽemėlapisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem offerWordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadDataDbToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveDataDbToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteDataDbToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteDataLocalMemoryToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageMainInfo;
        private System.Windows.Forms.TabPage tabPageMouse;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabKeyboardHeatMap;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbLeftMousePress;
        private System.Windows.Forms.TextBox tbKeyPressRelease;
        private System.Windows.Forms.TextBox tbRestTime;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbWorkTime;
        private System.Windows.Forms.TextBox tbMouseWheelRatio;
        private System.Windows.Forms.TextBox tbRightMousePress;
        private System.Windows.Forms.TextBox tbMouseWheelDown;
        private System.Windows.Forms.TextBox tbMouseWheelUp;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbMousePress;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbKeyPress;
        private System.Windows.Forms.Timer timer_uiUpdateTrigger;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbMouseKeyboardRatio;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbTotalWorkTime;
        private System.Windows.Forms.TextBox tbAvgMousePressMin;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tbAvgMousePressH;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tbAvgPressReleaseMin;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox tbAvgWrdH;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox tbAvgWrdMin;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox tbAvgPressReleaseH;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox tbAvgPressH;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox tbAvgPressMin;
        private System.Windows.Forms.Label label20;
    }
}

