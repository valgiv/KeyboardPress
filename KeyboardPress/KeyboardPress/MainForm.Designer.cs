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
            this.dBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadDataDbToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveDataDbToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteDataDbToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteDataLocalMemoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.apieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informacijaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel_info = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_totalWorkTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.panelDebug = new System.Windows.Forms.Panel();
            this.richTB_debug = new System.Windows.Forms.RichTextBox();
            this.panelMain = new System.Windows.Forms.Panel();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageMainInfo = new System.Windows.Forms.TabPage();
            this.lblMouseKeyboardRatio = new System.Windows.Forms.Label();
            this.lblCurrentRestTime = new System.Windows.Forms.Label();
            this.lblCurrentWorkTime = new System.Windows.Forms.Label();
            this.lblWorkTime = new System.Windows.Forms.Label();
            this.lblTotalWorkTime = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tabPageMouseInfo = new System.Windows.Forms.TabPage();
            this.lblMouseKeyboardRatioMouse = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.lblMouseWheelRatio = new System.Windows.Forms.Label();
            this.lblMouseWheelDown = new System.Windows.Forms.Label();
            this.lblMouseWheelUp = new System.Windows.Forms.Label();
            this.lblAvgMousePressH = new System.Windows.Forms.Label();
            this.lblAvgMousePressMin = new System.Windows.Forms.Label();
            this.lblRightMousePress = new System.Windows.Forms.Label();
            this.lblLeftMousePress = new System.Windows.Forms.Label();
            this.lblMousePress = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.tabPageMouse = new System.Windows.Forms.TabPage();
            this.tabPageMouseUsagePerHour = new System.Windows.Forms.TabPage();
            this.tabPageKeyboardInfo = new System.Windows.Forms.TabPage();
            this.lblMouseKeyboardRatioKeyboard = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.lblTotalWordsWithMistakes = new System.Windows.Forms.Label();
            this.lblLastWord = new System.Windows.Forms.Label();
            this.lblAvgWrdH = new System.Windows.Forms.Label();
            this.lblAvgWrdMin = new System.Windows.Forms.Label();
            this.lblTotalWords = new System.Windows.Forms.Label();
            this.lblAvgPressH = new System.Windows.Forms.Label();
            this.lblAvgPressMin = new System.Windows.Forms.Label();
            this.lblKeyPress = new System.Windows.Forms.Label();
            this.lblAvgPressReleaseH = new System.Windows.Forms.Label();
            this.lblAvgPressReleaseMin = new System.Windows.Forms.Label();
            this.lblKeyPressRelease = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label100 = new System.Windows.Forms.Label();
            this.label102 = new System.Windows.Forms.Label();
            this.label101 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.tabPageKeyboardUsagePerHour = new System.Windows.Forms.TabPage();
            this.tabPageKeyboardHeatMap = new System.Windows.Forms.TabPage();
            this.tabPageSymbols = new System.Windows.Forms.TabPage();
            this.tabPageMistakes = new System.Windows.Forms.TabPage();
            this.timer_workTime = new System.Windows.Forms.Timer(this.components);
            this.timer_uiUpdateTrigger = new System.Windows.Forms.Timer(this.components);
            this.timerDatabaseUpdate = new System.Windows.Forms.Timer(this.components);
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.panelDebug.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.tabControlMain.SuspendLayout();
            this.tabPageMainInfo.SuspendLayout();
            this.tabPageMouseInfo.SuspendLayout();
            this.tabPageKeyboardInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setingsToolStripMenuItem,
            this.administrationToolStripMenuItem,
            this.dBToolStripMenuItem,
            this.apieToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1000, 24);
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
            this.toolStripItem_start.Size = new System.Drawing.Size(213, 22);
            this.toolStripItem_start.Text = "Pradėti";
            this.toolStripItem_start.Click += new System.EventHandler(this.toolStripItem_start_Click);
            // 
            // toolStripItem_stop
            // 
            this.toolStripItem_stop.CheckOnClick = true;
            this.toolStripItem_stop.Name = "toolStripItem_stop";
            this.toolStripItem_stop.Size = new System.Drawing.Size(213, 22);
            this.toolStripItem_stop.Text = "Sustabdyti";
            this.toolStripItem_stop.Click += new System.EventHandler(this.toolStripItem_stop_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(210, 6);
            // 
            // toolStripItem_debug
            // 
            this.toolStripItem_debug.CheckOnClick = true;
            this.toolStripItem_debug.Name = "toolStripItem_debug";
            this.toolStripItem_debug.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F10)));
            this.toolStripItem_debug.Size = new System.Drawing.Size(213, 22);
            this.toolStripItem_debug.Text = "Debug sritis";
            this.toolStripItem_debug.Click += new System.EventHandler(this.toolStripItem_debug_Click);
            // 
            // toolStripItem_cleanDebugWindow
            // 
            this.toolStripItem_cleanDebugWindow.Name = "toolStripItem_cleanDebugWindow";
            this.toolStripItem_cleanDebugWindow.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F11)));
            this.toolStripItem_cleanDebugWindow.Size = new System.Drawing.Size(213, 22);
            this.toolStripItem_cleanDebugWindow.Text = "Valyti debug sritį";
            this.toolStripItem_cleanDebugWindow.Click += new System.EventHandler(this.toolStripItem_cleanDebugWindow_Click);
            // 
            // administrationToolStripMenuItem
            // 
            this.administrationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.offerWordToolStripMenuItem});
            this.administrationToolStripMenuItem.Name = "administrationToolStripMenuItem";
            this.administrationToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.administrationToolStripMenuItem.Text = "Valdymas";
            // 
            // offerWordToolStripMenuItem
            // 
            this.offerWordToolStripMenuItem.Name = "offerWordToolStripMenuItem";
            this.offerWordToolStripMenuItem.Size = new System.Drawing.Size(281, 22);
            this.offerWordToolStripMenuItem.Text = "Žodžių \"konvertavimo\" konfigūravimas";
            this.offerWordToolStripMenuItem.Click += new System.EventHandler(this.offerWordToolStripMenuItem_Click);
            // 
            // dBToolStripMenuItem
            // 
            this.dBToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadDataDbToolStripMenuItem,
            this.saveDataDbToolStripMenuItem,
            this.deleteDataDbToolStripMenuItem,
            this.deleteDataLocalMemoryToolStripMenuItem});
            this.dBToolStripMenuItem.Name = "dBToolStripMenuItem";
            this.dBToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.dBToolStripMenuItem.Text = "DB valdymas";
            // 
            // loadDataDbToolStripMenuItem
            // 
            this.loadDataDbToolStripMenuItem.Name = "loadDataDbToolStripMenuItem";
            this.loadDataDbToolStripMenuItem.Size = new System.Drawing.Size(272, 22);
            this.loadDataDbToolStripMenuItem.Text = "Užkrauti duomenis iš duomenų bazės";
            this.loadDataDbToolStripMenuItem.Click += new System.EventHandler(this.loadDataDbToolStripMenuItem_Click);
            // 
            // saveDataDbToolStripMenuItem
            // 
            this.saveDataDbToolStripMenuItem.Name = "saveDataDbToolStripMenuItem";
            this.saveDataDbToolStripMenuItem.Size = new System.Drawing.Size(272, 22);
            this.saveDataDbToolStripMenuItem.Text = "Išsaugoti duomenis į duomenų bazę";
            this.saveDataDbToolStripMenuItem.Click += new System.EventHandler(this.saveDataDbToolStripMenuItem_Click);
            // 
            // deleteDataDbToolStripMenuItem
            // 
            this.deleteDataDbToolStripMenuItem.Name = "deleteDataDbToolStripMenuItem";
            this.deleteDataDbToolStripMenuItem.Size = new System.Drawing.Size(272, 22);
            this.deleteDataDbToolStripMenuItem.Text = "Pašalinti duomenis iš duomenų bazės";
            this.deleteDataDbToolStripMenuItem.Click += new System.EventHandler(this.deleteDataDbToolStripMenuItem_Click);
            // 
            // deleteDataLocalMemoryToolStripMenuItem
            // 
            this.deleteDataLocalMemoryToolStripMenuItem.Name = "deleteDataLocalMemoryToolStripMenuItem";
            this.deleteDataLocalMemoryToolStripMenuItem.Size = new System.Drawing.Size(272, 22);
            this.deleteDataLocalMemoryToolStripMenuItem.Text = "Pašalinti duomenis iš atminties";
            this.deleteDataLocalMemoryToolStripMenuItem.Click += new System.EventHandler(this.deleteDataLocalMemoryToolStripMenuItem_Click);
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
            this.informacijaToolStripMenuItem.Click += new System.EventHandler(this.informacijaToolStripMenuItem_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipText = "test";
            this.notifyIcon.BalloonTipTitle = "test";
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
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
            this.statusStrip.Size = new System.Drawing.Size(1000, 22);
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
            this.toolStripStatusLabel_totalWorkTime.Size = new System.Drawing.Size(954, 17);
            this.toolStripStatusLabel_totalWorkTime.Spring = true;
            this.toolStripStatusLabel_totalWorkTime.Text = "--";
            this.toolStripStatusLabel_totalWorkTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panelDebug
            // 
            this.panelDebug.Controls.Add(this.richTB_debug);
            this.panelDebug.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelDebug.Location = new System.Drawing.Point(666, 24);
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
            this.panelMain.Size = new System.Drawing.Size(666, 396);
            this.panelMain.TabIndex = 3;
            // 
            // tabControlMain
            // 
            this.tabControlMain.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControlMain.Controls.Add(this.tabPageMainInfo);
            this.tabControlMain.Controls.Add(this.tabPageMouseInfo);
            this.tabControlMain.Controls.Add(this.tabPageMouse);
            this.tabControlMain.Controls.Add(this.tabPageMouseUsagePerHour);
            this.tabControlMain.Controls.Add(this.tabPageKeyboardInfo);
            this.tabControlMain.Controls.Add(this.tabPageKeyboardUsagePerHour);
            this.tabControlMain.Controls.Add(this.tabPageKeyboardHeatMap);
            this.tabControlMain.Controls.Add(this.tabPageSymbols);
            this.tabControlMain.Controls.Add(this.tabPageMistakes);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControlMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControlMain.ItemSize = new System.Drawing.Size(30, 120);
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Multiline = true;
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(666, 396);
            this.tabControlMain.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControlMain.TabIndex = 10;
            this.tabControlMain.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControlMain_DrawItem);
            this.tabControlMain.SelectedIndexChanged += new System.EventHandler(this.tabControlMain_SelectedIndexChanged);
            // 
            // tabPageMainInfo
            // 
            this.tabPageMainInfo.Controls.Add(this.lblMouseKeyboardRatio);
            this.tabPageMainInfo.Controls.Add(this.lblCurrentRestTime);
            this.tabPageMainInfo.Controls.Add(this.lblCurrentWorkTime);
            this.tabPageMainInfo.Controls.Add(this.lblWorkTime);
            this.tabPageMainInfo.Controls.Add(this.lblTotalWorkTime);
            this.tabPageMainInfo.Controls.Add(this.label21);
            this.tabPageMainInfo.Controls.Add(this.label12);
            this.tabPageMainInfo.Controls.Add(this.label1);
            this.tabPageMainInfo.Controls.Add(this.label7);
            this.tabPageMainInfo.Controls.Add(this.label6);
            this.tabPageMainInfo.Location = new System.Drawing.Point(124, 4);
            this.tabPageMainInfo.Name = "tabPageMainInfo";
            this.tabPageMainInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMainInfo.Size = new System.Drawing.Size(538, 388);
            this.tabPageMainInfo.TabIndex = 0;
            this.tabPageMainInfo.Text = "Bendra informacija";
            this.tabPageMainInfo.UseVisualStyleBackColor = true;
            // 
            // lblMouseKeyboardRatio
            // 
            this.lblMouseKeyboardRatio.AutoSize = true;
            this.lblMouseKeyboardRatio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMouseKeyboardRatio.Location = new System.Drawing.Point(177, 116);
            this.lblMouseKeyboardRatio.Name = "lblMouseKeyboardRatio";
            this.lblMouseKeyboardRatio.Size = new System.Drawing.Size(15, 15);
            this.lblMouseKeyboardRatio.TabIndex = 42;
            this.lblMouseKeyboardRatio.Text = "--";
            // 
            // lblCurrentRestTime
            // 
            this.lblCurrentRestTime.AutoSize = true;
            this.lblCurrentRestTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentRestTime.Location = new System.Drawing.Point(177, 90);
            this.lblCurrentRestTime.Name = "lblCurrentRestTime";
            this.lblCurrentRestTime.Size = new System.Drawing.Size(15, 15);
            this.lblCurrentRestTime.TabIndex = 41;
            this.lblCurrentRestTime.Text = "--";
            // 
            // lblCurrentWorkTime
            // 
            this.lblCurrentWorkTime.AutoSize = true;
            this.lblCurrentWorkTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentWorkTime.Location = new System.Drawing.Point(177, 64);
            this.lblCurrentWorkTime.Name = "lblCurrentWorkTime";
            this.lblCurrentWorkTime.Size = new System.Drawing.Size(15, 15);
            this.lblCurrentWorkTime.TabIndex = 40;
            this.lblCurrentWorkTime.Text = "--";
            // 
            // lblWorkTime
            // 
            this.lblWorkTime.AutoSize = true;
            this.lblWorkTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWorkTime.Location = new System.Drawing.Point(177, 38);
            this.lblWorkTime.Name = "lblWorkTime";
            this.lblWorkTime.Size = new System.Drawing.Size(15, 15);
            this.lblWorkTime.TabIndex = 39;
            this.lblWorkTime.Text = "--";
            // 
            // lblTotalWorkTime
            // 
            this.lblTotalWorkTime.AutoSize = true;
            this.lblTotalWorkTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalWorkTime.Location = new System.Drawing.Point(177, 12);
            this.lblTotalWorkTime.Name = "lblTotalWorkTime";
            this.lblTotalWorkTime.Size = new System.Drawing.Size(15, 15);
            this.lblTotalWorkTime.TabIndex = 38;
            this.lblTotalWorkTime.Text = "--";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(6, 38);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(161, 15);
            this.label21.TabIndex = 36;
            this.label21.Text = "Veikimo laikas nuo įjungimo";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(6, 12);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(116, 15);
            this.label12.TabIndex = 35;
            this.label12.Text = "Visas veikimo laikas";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 35);
            this.label1.TabIndex = 33;
            this.label1.Text = "Pelės/klaviatūros naudojimo santykis";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 90);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 15);
            this.label7.TabIndex = 22;
            this.label7.Text = "Pertraukos laikas";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 15);
            this.label6.TabIndex = 21;
            this.label6.Text = "Darbo laikas";
            // 
            // tabPageMouseInfo
            // 
            this.tabPageMouseInfo.Controls.Add(this.lblMouseKeyboardRatioMouse);
            this.tabPageMouseInfo.Controls.Add(this.label23);
            this.tabPageMouseInfo.Controls.Add(this.lblMouseWheelRatio);
            this.tabPageMouseInfo.Controls.Add(this.lblMouseWheelDown);
            this.tabPageMouseInfo.Controls.Add(this.lblMouseWheelUp);
            this.tabPageMouseInfo.Controls.Add(this.lblAvgMousePressH);
            this.tabPageMouseInfo.Controls.Add(this.lblAvgMousePressMin);
            this.tabPageMouseInfo.Controls.Add(this.lblRightMousePress);
            this.tabPageMouseInfo.Controls.Add(this.lblLeftMousePress);
            this.tabPageMouseInfo.Controls.Add(this.lblMousePress);
            this.tabPageMouseInfo.Controls.Add(this.label10);
            this.tabPageMouseInfo.Controls.Add(this.label9);
            this.tabPageMouseInfo.Controls.Add(this.label8);
            this.tabPageMouseInfo.Controls.Add(this.label5);
            this.tabPageMouseInfo.Controls.Add(this.label4);
            this.tabPageMouseInfo.Controls.Add(this.label3);
            this.tabPageMouseInfo.Controls.Add(this.label14);
            this.tabPageMouseInfo.Controls.Add(this.label13);
            this.tabPageMouseInfo.Location = new System.Drawing.Point(124, 4);
            this.tabPageMouseInfo.Name = "tabPageMouseInfo";
            this.tabPageMouseInfo.Size = new System.Drawing.Size(538, 388);
            this.tabPageMouseInfo.TabIndex = 6;
            this.tabPageMouseInfo.Text = "Pelės informacija";
            this.tabPageMouseInfo.UseVisualStyleBackColor = true;
            // 
            // lblMouseKeyboardRatioMouse
            // 
            this.lblMouseKeyboardRatioMouse.AutoSize = true;
            this.lblMouseKeyboardRatioMouse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMouseKeyboardRatioMouse.Location = new System.Drawing.Point(193, 218);
            this.lblMouseKeyboardRatioMouse.Name = "lblMouseKeyboardRatioMouse";
            this.lblMouseKeyboardRatioMouse.Size = new System.Drawing.Size(15, 15);
            this.lblMouseKeyboardRatioMouse.TabIndex = 168;
            this.lblMouseKeyboardRatioMouse.Text = "--";
            // 
            // label23
            // 
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(14, 218);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(141, 35);
            this.label23.TabIndex = 167;
            this.label23.Text = "Pelės/klaviatūros naudojimo santykis";
            // 
            // lblMouseWheelRatio
            // 
            this.lblMouseWheelRatio.AutoSize = true;
            this.lblMouseWheelRatio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMouseWheelRatio.Location = new System.Drawing.Point(193, 195);
            this.lblMouseWheelRatio.Name = "lblMouseWheelRatio";
            this.lblMouseWheelRatio.Size = new System.Drawing.Size(15, 15);
            this.lblMouseWheelRatio.TabIndex = 166;
            this.lblMouseWheelRatio.Text = "--";
            // 
            // lblMouseWheelDown
            // 
            this.lblMouseWheelDown.AutoSize = true;
            this.lblMouseWheelDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMouseWheelDown.Location = new System.Drawing.Point(193, 169);
            this.lblMouseWheelDown.Name = "lblMouseWheelDown";
            this.lblMouseWheelDown.Size = new System.Drawing.Size(15, 15);
            this.lblMouseWheelDown.TabIndex = 165;
            this.lblMouseWheelDown.Text = "--";
            this.lblMouseWheelDown.TextChanged += new System.EventHandler(this.lblMouseWheel_TextChanged);
            // 
            // lblMouseWheelUp
            // 
            this.lblMouseWheelUp.AutoSize = true;
            this.lblMouseWheelUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMouseWheelUp.Location = new System.Drawing.Point(193, 144);
            this.lblMouseWheelUp.Name = "lblMouseWheelUp";
            this.lblMouseWheelUp.Size = new System.Drawing.Size(15, 15);
            this.lblMouseWheelUp.TabIndex = 164;
            this.lblMouseWheelUp.Text = "--";
            this.lblMouseWheelUp.TextChanged += new System.EventHandler(this.lblMouseWheel_TextChanged);
            // 
            // lblAvgMousePressH
            // 
            this.lblAvgMousePressH.AutoSize = true;
            this.lblAvgMousePressH.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvgMousePressH.Location = new System.Drawing.Point(193, 117);
            this.lblAvgMousePressH.Name = "lblAvgMousePressH";
            this.lblAvgMousePressH.Size = new System.Drawing.Size(15, 15);
            this.lblAvgMousePressH.TabIndex = 163;
            this.lblAvgMousePressH.Text = "--";
            // 
            // lblAvgMousePressMin
            // 
            this.lblAvgMousePressMin.AutoSize = true;
            this.lblAvgMousePressMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvgMousePressMin.Location = new System.Drawing.Point(193, 91);
            this.lblAvgMousePressMin.Name = "lblAvgMousePressMin";
            this.lblAvgMousePressMin.Size = new System.Drawing.Size(15, 15);
            this.lblAvgMousePressMin.TabIndex = 162;
            this.lblAvgMousePressMin.Text = "--";
            // 
            // lblRightMousePress
            // 
            this.lblRightMousePress.AutoSize = true;
            this.lblRightMousePress.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRightMousePress.Location = new System.Drawing.Point(193, 66);
            this.lblRightMousePress.Name = "lblRightMousePress";
            this.lblRightMousePress.Size = new System.Drawing.Size(15, 15);
            this.lblRightMousePress.TabIndex = 161;
            this.lblRightMousePress.Text = "--";
            // 
            // lblLeftMousePress
            // 
            this.lblLeftMousePress.AutoSize = true;
            this.lblLeftMousePress.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLeftMousePress.Location = new System.Drawing.Point(193, 39);
            this.lblLeftMousePress.Name = "lblLeftMousePress";
            this.lblLeftMousePress.Size = new System.Drawing.Size(15, 15);
            this.lblLeftMousePress.TabIndex = 160;
            this.lblLeftMousePress.Text = "--";
            // 
            // lblMousePress
            // 
            this.lblMousePress.AutoSize = true;
            this.lblMousePress.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMousePress.Location = new System.Drawing.Point(193, 13);
            this.lblMousePress.Name = "lblMousePress";
            this.lblMousePress.Size = new System.Drawing.Size(15, 15);
            this.lblMousePress.TabIndex = 159;
            this.lblMousePress.Text = "--";
            this.lblMousePress.TextChanged += new System.EventHandler(this.lblMouseKeyboardRatioChange_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(14, 13);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(110, 15);
            this.label10.TabIndex = 118;
            this.label10.Text = "Pelės paspaudimų";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(14, 169);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(120, 15);
            this.label9.TabIndex = 117;
            this.label9.Text = "Pelės ratukas žemyn";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(14, 143);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(125, 15);
            this.label8.TabIndex = 116;
            this.label8.Text = "Pelės ratukas aukštyn";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(14, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 15);
            this.label5.TabIndex = 113;
            this.label5.Text = "D. pelės klavišas";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(14, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 15);
            this.label4.TabIndex = 112;
            this.label4.Text = "K. pelės klavišas";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 195);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(154, 15);
            this.label3.TabIndex = 108;
            this.label3.Text = "Ratuko naudojimo santykis";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(14, 117);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(156, 15);
            this.label14.TabIndex = 106;
            this.label14.Text = "Vid. pelės paspaudimai/val.";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(14, 91);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(162, 15);
            this.label13.TabIndex = 104;
            this.label13.Text = "Vid. pelės paspaudimai/min.";
            // 
            // tabPageMouse
            // 
            this.tabPageMouse.Location = new System.Drawing.Point(124, 4);
            this.tabPageMouse.Name = "tabPageMouse";
            this.tabPageMouse.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMouse.Size = new System.Drawing.Size(538, 388);
            this.tabPageMouse.TabIndex = 1;
            this.tabPageMouse.Text = "Pelės paspaudimai";
            this.tabPageMouse.UseVisualStyleBackColor = true;
            // 
            // tabPageMouseUsagePerHour
            // 
            this.tabPageMouseUsagePerHour.Location = new System.Drawing.Point(124, 4);
            this.tabPageMouseUsagePerHour.Name = "tabPageMouseUsagePerHour";
            this.tabPageMouseUsagePerHour.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMouseUsagePerHour.Size = new System.Drawing.Size(538, 388);
            this.tabPageMouseUsagePerHour.TabIndex = 5;
            this.tabPageMouseUsagePerHour.Text = "Pelės naudojimas";
            this.tabPageMouseUsagePerHour.UseVisualStyleBackColor = true;
            // 
            // tabPageKeyboardInfo
            // 
            this.tabPageKeyboardInfo.Controls.Add(this.lblMouseKeyboardRatioKeyboard);
            this.tabPageKeyboardInfo.Controls.Add(this.label24);
            this.tabPageKeyboardInfo.Controls.Add(this.lblTotalWordsWithMistakes);
            this.tabPageKeyboardInfo.Controls.Add(this.lblLastWord);
            this.tabPageKeyboardInfo.Controls.Add(this.lblAvgWrdH);
            this.tabPageKeyboardInfo.Controls.Add(this.lblAvgWrdMin);
            this.tabPageKeyboardInfo.Controls.Add(this.lblTotalWords);
            this.tabPageKeyboardInfo.Controls.Add(this.lblAvgPressH);
            this.tabPageKeyboardInfo.Controls.Add(this.lblAvgPressMin);
            this.tabPageKeyboardInfo.Controls.Add(this.lblKeyPress);
            this.tabPageKeyboardInfo.Controls.Add(this.lblAvgPressReleaseH);
            this.tabPageKeyboardInfo.Controls.Add(this.lblAvgPressReleaseMin);
            this.tabPageKeyboardInfo.Controls.Add(this.lblKeyPressRelease);
            this.tabPageKeyboardInfo.Controls.Add(this.label11);
            this.tabPageKeyboardInfo.Controls.Add(this.label2);
            this.tabPageKeyboardInfo.Controls.Add(this.label100);
            this.tabPageKeyboardInfo.Controls.Add(this.label102);
            this.tabPageKeyboardInfo.Controls.Add(this.label101);
            this.tabPageKeyboardInfo.Controls.Add(this.label19);
            this.tabPageKeyboardInfo.Controls.Add(this.label20);
            this.tabPageKeyboardInfo.Controls.Add(this.label18);
            this.tabPageKeyboardInfo.Controls.Add(this.label17);
            this.tabPageKeyboardInfo.Controls.Add(this.label16);
            this.tabPageKeyboardInfo.Controls.Add(this.label15);
            this.tabPageKeyboardInfo.Location = new System.Drawing.Point(124, 4);
            this.tabPageKeyboardInfo.Name = "tabPageKeyboardInfo";
            this.tabPageKeyboardInfo.Size = new System.Drawing.Size(538, 388);
            this.tabPageKeyboardInfo.TabIndex = 7;
            this.tabPageKeyboardInfo.Text = "Klaviatūros informacija";
            this.tabPageKeyboardInfo.UseVisualStyleBackColor = true;
            // 
            // lblMouseKeyboardRatioKeyboard
            // 
            this.lblMouseKeyboardRatioKeyboard.AutoSize = true;
            this.lblMouseKeyboardRatioKeyboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMouseKeyboardRatioKeyboard.Location = new System.Drawing.Point(198, 298);
            this.lblMouseKeyboardRatioKeyboard.Name = "lblMouseKeyboardRatioKeyboard";
            this.lblMouseKeyboardRatioKeyboard.Size = new System.Drawing.Size(15, 15);
            this.lblMouseKeyboardRatioKeyboard.TabIndex = 170;
            this.lblMouseKeyboardRatioKeyboard.Text = "--";
            // 
            // label24
            // 
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(15, 298);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(141, 28);
            this.label24.TabIndex = 169;
            this.label24.Text = "Pelės/klaviatūros naudojimo santykis";
            // 
            // lblTotalWordsWithMistakes
            // 
            this.lblTotalWordsWithMistakes.AutoSize = true;
            this.lblTotalWordsWithMistakes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalWordsWithMistakes.Location = new System.Drawing.Point(198, 272);
            this.lblTotalWordsWithMistakes.Name = "lblTotalWordsWithMistakes";
            this.lblTotalWordsWithMistakes.Size = new System.Drawing.Size(15, 15);
            this.lblTotalWordsWithMistakes.TabIndex = 158;
            this.lblTotalWordsWithMistakes.Text = "--";
            // 
            // lblLastWord
            // 
            this.lblLastWord.AutoSize = true;
            this.lblLastWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastWord.Location = new System.Drawing.Point(198, 246);
            this.lblLastWord.Name = "lblLastWord";
            this.lblLastWord.Size = new System.Drawing.Size(15, 15);
            this.lblLastWord.TabIndex = 157;
            this.lblLastWord.Text = "--";
            // 
            // lblAvgWrdH
            // 
            this.lblAvgWrdH.AutoSize = true;
            this.lblAvgWrdH.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvgWrdH.Location = new System.Drawing.Point(198, 220);
            this.lblAvgWrdH.Name = "lblAvgWrdH";
            this.lblAvgWrdH.Size = new System.Drawing.Size(15, 15);
            this.lblAvgWrdH.TabIndex = 156;
            this.lblAvgWrdH.Text = "--";
            // 
            // lblAvgWrdMin
            // 
            this.lblAvgWrdMin.AutoSize = true;
            this.lblAvgWrdMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvgWrdMin.Location = new System.Drawing.Point(198, 194);
            this.lblAvgWrdMin.Name = "lblAvgWrdMin";
            this.lblAvgWrdMin.Size = new System.Drawing.Size(15, 15);
            this.lblAvgWrdMin.TabIndex = 155;
            this.lblAvgWrdMin.Text = "--";
            // 
            // lblTotalWords
            // 
            this.lblTotalWords.AutoSize = true;
            this.lblTotalWords.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalWords.Location = new System.Drawing.Point(198, 168);
            this.lblTotalWords.Name = "lblTotalWords";
            this.lblTotalWords.Size = new System.Drawing.Size(15, 15);
            this.lblTotalWords.TabIndex = 154;
            this.lblTotalWords.Text = "--";
            // 
            // lblAvgPressH
            // 
            this.lblAvgPressH.AutoSize = true;
            this.lblAvgPressH.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvgPressH.Location = new System.Drawing.Point(198, 142);
            this.lblAvgPressH.Name = "lblAvgPressH";
            this.lblAvgPressH.Size = new System.Drawing.Size(15, 15);
            this.lblAvgPressH.TabIndex = 153;
            this.lblAvgPressH.Text = "--";
            // 
            // lblAvgPressMin
            // 
            this.lblAvgPressMin.AutoSize = true;
            this.lblAvgPressMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvgPressMin.Location = new System.Drawing.Point(198, 116);
            this.lblAvgPressMin.Name = "lblAvgPressMin";
            this.lblAvgPressMin.Size = new System.Drawing.Size(15, 15);
            this.lblAvgPressMin.TabIndex = 152;
            this.lblAvgPressMin.Text = "--";
            // 
            // lblKeyPress
            // 
            this.lblKeyPress.AutoSize = true;
            this.lblKeyPress.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKeyPress.Location = new System.Drawing.Point(198, 90);
            this.lblKeyPress.Name = "lblKeyPress";
            this.lblKeyPress.Size = new System.Drawing.Size(15, 15);
            this.lblKeyPress.TabIndex = 151;
            this.lblKeyPress.Text = "--";
            this.lblKeyPress.TextChanged += new System.EventHandler(this.lblMouseKeyboardRatioChange_TextChanged);
            // 
            // lblAvgPressReleaseH
            // 
            this.lblAvgPressReleaseH.AutoSize = true;
            this.lblAvgPressReleaseH.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvgPressReleaseH.Location = new System.Drawing.Point(198, 64);
            this.lblAvgPressReleaseH.Name = "lblAvgPressReleaseH";
            this.lblAvgPressReleaseH.Size = new System.Drawing.Size(15, 15);
            this.lblAvgPressReleaseH.TabIndex = 150;
            this.lblAvgPressReleaseH.Text = "--";
            // 
            // lblAvgPressReleaseMin
            // 
            this.lblAvgPressReleaseMin.AutoSize = true;
            this.lblAvgPressReleaseMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvgPressReleaseMin.Location = new System.Drawing.Point(198, 38);
            this.lblAvgPressReleaseMin.Name = "lblAvgPressReleaseMin";
            this.lblAvgPressReleaseMin.Size = new System.Drawing.Size(15, 15);
            this.lblAvgPressReleaseMin.TabIndex = 149;
            this.lblAvgPressReleaseMin.Text = "--";
            // 
            // lblKeyPressRelease
            // 
            this.lblKeyPressRelease.AutoSize = true;
            this.lblKeyPressRelease.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKeyPressRelease.Location = new System.Drawing.Point(198, 12);
            this.lblKeyPressRelease.Name = "lblKeyPressRelease";
            this.lblKeyPressRelease.Size = new System.Drawing.Size(15, 15);
            this.lblKeyPressRelease.TabIndex = 148;
            this.lblKeyPressRelease.Text = "--";
            this.lblKeyPressRelease.TextChanged += new System.EventHandler(this.lblMouseKeyboardRatioChange_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(15, 90);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(121, 15);
            this.label11.TabIndex = 147;
            this.label11.Text = "Klavišų nuspaudimai";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 15);
            this.label2.TabIndex = 144;
            this.label2.Text = "Klavišų paspaudimai";
            // 
            // label100
            // 
            this.label100.AutoSize = true;
            this.label100.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label100.Location = new System.Drawing.Point(15, 168);
            this.label100.Name = "label100";
            this.label100.Size = new System.Drawing.Size(144, 15);
            this.label100.TabIndex = 141;
            this.label100.Text = "Sistama užfiksavo žodžių";
            // 
            // label102
            // 
            this.label102.AutoSize = true;
            this.label102.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label102.Location = new System.Drawing.Point(15, 272);
            this.label102.Name = "label102";
            this.label102.Size = new System.Drawing.Size(83, 15);
            this.label102.TabIndex = 143;
            this.label102.Text = "Taisyti žodžiai";
            // 
            // label101
            // 
            this.label101.AutoSize = true;
            this.label101.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label101.Location = new System.Drawing.Point(15, 246);
            this.label101.Name = "label101";
            this.label101.Size = new System.Drawing.Size(159, 15);
            this.label101.TabIndex = 142;
            this.label101.Text = "Paskutinis užfiksuotas žodis";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(15, 142);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(163, 15);
            this.label19.TabIndex = 136;
            this.label19.Text = "Vid. klavišų nuspaudimai/val.";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(15, 116);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(169, 15);
            this.label20.TabIndex = 134;
            this.label20.Text = "Vid. klavišų nuspaudimai/min.";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(13, 64);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(163, 15);
            this.label18.TabIndex = 132;
            this.label18.Text = "Vid. klavišų paspaudimai/val.";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(13, 38);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(169, 15);
            this.label17.TabIndex = 130;
            this.label17.Text = "Vid. klavišų paspaudimai/min.";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(15, 220);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(90, 15);
            this.label16.TabIndex = 128;
            this.label16.Text = "Vid. žodžiai/val.";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(15, 194);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(96, 15);
            this.label15.TabIndex = 126;
            this.label15.Text = "Vid. žodžiai/min.";
            // 
            // tabPageKeyboardUsagePerHour
            // 
            this.tabPageKeyboardUsagePerHour.Location = new System.Drawing.Point(124, 4);
            this.tabPageKeyboardUsagePerHour.Name = "tabPageKeyboardUsagePerHour";
            this.tabPageKeyboardUsagePerHour.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageKeyboardUsagePerHour.Size = new System.Drawing.Size(538, 388);
            this.tabPageKeyboardUsagePerHour.TabIndex = 2;
            this.tabPageKeyboardUsagePerHour.Text = "Klaviatūros naudojimas";
            this.tabPageKeyboardUsagePerHour.UseVisualStyleBackColor = true;
            // 
            // tabPageKeyboardHeatMap
            // 
            this.tabPageKeyboardHeatMap.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPageKeyboardHeatMap.Location = new System.Drawing.Point(124, 4);
            this.tabPageKeyboardHeatMap.Name = "tabPageKeyboardHeatMap";
            this.tabPageKeyboardHeatMap.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageKeyboardHeatMap.Size = new System.Drawing.Size(538, 388);
            this.tabPageKeyboardHeatMap.TabIndex = 4;
            this.tabPageKeyboardHeatMap.Text = "Klaviatūros \"karštis\"";
            this.tabPageKeyboardHeatMap.UseVisualStyleBackColor = true;
            // 
            // tabPageSymbols
            // 
            this.tabPageSymbols.Location = new System.Drawing.Point(124, 4);
            this.tabPageSymbols.Name = "tabPageSymbols";
            this.tabPageSymbols.Size = new System.Drawing.Size(538, 388);
            this.tabPageSymbols.TabIndex = 8;
            this.tabPageSymbols.Text = "Simboliai";
            this.tabPageSymbols.UseVisualStyleBackColor = true;
            // 
            // tabPageMistakes
            // 
            this.tabPageMistakes.Location = new System.Drawing.Point(124, 4);
            this.tabPageMistakes.Name = "tabPageMistakes";
            this.tabPageMistakes.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMistakes.Size = new System.Drawing.Size(538, 388);
            this.tabPageMistakes.TabIndex = 3;
            this.tabPageMistakes.Text = "Klaidos";
            this.tabPageMistakes.UseVisualStyleBackColor = true;
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
            // timerDatabaseUpdate
            // 
            this.timerDatabaseUpdate.Interval = 900000;
            this.timerDatabaseUpdate.Tick += new System.EventHandler(this.timerDatabaseUpdate_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 442);
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
            this.tabPageMouseInfo.ResumeLayout(false);
            this.tabPageMouseInfo.PerformLayout();
            this.tabPageKeyboardInfo.ResumeLayout(false);
            this.tabPageKeyboardInfo.PerformLayout();
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
        private System.Windows.Forms.ToolStripMenuItem offerWordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadDataDbToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveDataDbToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteDataDbToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteDataLocalMemoryToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageMainInfo;
        private System.Windows.Forms.TabPage tabPageMouse;
        private System.Windows.Forms.TabPage tabPageKeyboardUsagePerHour;
        private System.Windows.Forms.TabPage tabPageMistakes;
        private System.Windows.Forms.TabPage tabPageKeyboardHeatMap;
        private System.Windows.Forms.TabPage tabPageMouseUsagePerHour;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Timer timer_uiUpdateTrigger;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TabPage tabPageMouseInfo;
        private System.Windows.Forms.TabPage tabPageKeyboardInfo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label100;
        private System.Windows.Forms.Label label102;
        private System.Windows.Forms.Label label101;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblTotalWorkTime;
        private System.Windows.Forms.Label lblMouseKeyboardRatio;
        private System.Windows.Forms.Label lblCurrentRestTime;
        private System.Windows.Forms.Label lblCurrentWorkTime;
        private System.Windows.Forms.Label lblWorkTime;
        private System.Windows.Forms.Label lblTotalWordsWithMistakes;
        private System.Windows.Forms.Label lblLastWord;
        private System.Windows.Forms.Label lblAvgWrdH;
        private System.Windows.Forms.Label lblAvgWrdMin;
        private System.Windows.Forms.Label lblTotalWords;
        private System.Windows.Forms.Label lblAvgPressH;
        private System.Windows.Forms.Label lblAvgPressMin;
        private System.Windows.Forms.Label lblKeyPress;
        private System.Windows.Forms.Label lblAvgPressReleaseH;
        private System.Windows.Forms.Label lblAvgPressReleaseMin;
        private System.Windows.Forms.Label lblKeyPressRelease;
        private System.Windows.Forms.Label lblMouseWheelRatio;
        private System.Windows.Forms.Label lblMouseWheelDown;
        private System.Windows.Forms.Label lblMouseWheelUp;
        private System.Windows.Forms.Label lblAvgMousePressH;
        private System.Windows.Forms.Label lblAvgMousePressMin;
        private System.Windows.Forms.Label lblRightMousePress;
        private System.Windows.Forms.Label lblLeftMousePress;
        private System.Windows.Forms.Label lblMousePress;
        private System.Windows.Forms.Label lblMouseKeyboardRatioMouse;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label lblMouseKeyboardRatioKeyboard;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Timer timerDatabaseUpdate;
        private System.Windows.Forms.TabPage tabPageSymbols;
    }
}

