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
            this.tabPage1 = new System.Windows.Forms.TabPage();
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
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabKeyboardHeatMap = new System.Windows.Forms.TabPage();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.timer_workTime = new System.Windows.Forms.Timer(this.components);
            this.tbKeyPress = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.panelDebug.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.tabControlMain.SuspendLayout();
            this.tabPage1.SuspendLayout();
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
            this.menuStrip.Size = new System.Drawing.Size(1084, 24);
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
            this.statusStrip.Size = new System.Drawing.Size(1084, 22);
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
            this.toolStripStatusLabel_totalWorkTime.Size = new System.Drawing.Size(1038, 17);
            this.toolStripStatusLabel_totalWorkTime.Spring = true;
            this.toolStripStatusLabel_totalWorkTime.Text = "--";
            this.toolStripStatusLabel_totalWorkTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panelDebug
            // 
            this.panelDebug.Controls.Add(this.richTB_debug);
            this.panelDebug.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelDebug.Location = new System.Drawing.Point(750, 24);
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
            this.panelMain.Size = new System.Drawing.Size(750, 396);
            this.panelMain.TabIndex = 3;
            // 
            // tabControlMain
            // 
            this.tabControlMain.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControlMain.Controls.Add(this.tabPage1);
            this.tabControlMain.Controls.Add(this.tabPage2);
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
            this.tabControlMain.Size = new System.Drawing.Size(750, 396);
            this.tabControlMain.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControlMain.TabIndex = 10;
            this.tabControlMain.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControlMain_DrawItem);
            this.tabControlMain.SelectedIndexChanged += new System.EventHandler(this.tabControlMain_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.tbKeyPress);
            this.tabPage1.Controls.Add(this.tbMousePress);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.tbMouseWheelDown);
            this.tabPage1.Controls.Add(this.tbMouseWheelUp);
            this.tabPage1.Controls.Add(this.tbRestTime);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.tbWorkTime);
            this.tabPage1.Controls.Add(this.tbMouseWheelRatio);
            this.tabPage1.Controls.Add(this.tbRightMousePress);
            this.tabPage1.Controls.Add(this.tbLeftMousePress);
            this.tabPage1.Controls.Add(this.tbKeyPressRelease);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.lblTotalWords);
            this.tabPage1.Controls.Add(this.lblLastWordWithMistake);
            this.tabPage1.Controls.Add(this.tbTotalWords);
            this.tabPage1.Controls.Add(this.lblLastWord);
            this.tabPage1.Controls.Add(this.tbLastWord);
            this.tabPage1.Controls.Add(this.tbTotalWordsWithMistakes);
            this.tabPage1.Location = new System.Drawing.Point(124, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(622, 388);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Informacija";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tbMousePress
            // 
            this.tbMousePress.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.tbMousePress.Location = new System.Drawing.Point(225, 157);
            this.tbMousePress.Name = "tbMousePress";
            this.tbMousePress.ReadOnly = true;
            this.tbMousePress.Size = new System.Drawing.Size(155, 20);
            this.tbMousePress.TabIndex = 29;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(104, 160);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(115, 13);
            this.label10.TabIndex = 28;
            this.label10.Text = "Viso palės nuspaudimų";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(115, 263);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(104, 13);
            this.label9.TabIndex = 27;
            this.label9.Text = "Pelės ratukas žemyn";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(104, 237);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(111, 13);
            this.label8.TabIndex = 26;
            this.label8.Text = "Pelės ratukas aukštyn";
            // 
            // tbMouseWheelDown
            // 
            this.tbMouseWheelDown.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.tbMouseWheelDown.Location = new System.Drawing.Point(225, 260);
            this.tbMouseWheelDown.Name = "tbMouseWheelDown";
            this.tbMouseWheelDown.ReadOnly = true;
            this.tbMouseWheelDown.Size = new System.Drawing.Size(155, 20);
            this.tbMouseWheelDown.TabIndex = 25;
            // 
            // tbMouseWheelUp
            // 
            this.tbMouseWheelUp.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.tbMouseWheelUp.Location = new System.Drawing.Point(225, 234);
            this.tbMouseWheelUp.Name = "tbMouseWheelUp";
            this.tbMouseWheelUp.ReadOnly = true;
            this.tbMouseWheelUp.Size = new System.Drawing.Size(155, 20);
            this.tbMouseWheelUp.TabIndex = 24;
            // 
            // tbRestTime
            // 
            this.tbRestTime.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.tbRestTime.Location = new System.Drawing.Point(225, 338);
            this.tbRestTime.Name = "tbRestTime";
            this.tbRestTime.ReadOnly = true;
            this.tbRestTime.Size = new System.Drawing.Size(155, 20);
            this.tbRestTime.TabIndex = 23;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(131, 341);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "Pertraukos laikas";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(153, 315);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Darbo laikas";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(77, 211);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(142, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "D. pelės klavišų paspaudimų";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(84, 185);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "K. pelės klvišo paspaudimų";
            // 
            // tbWorkTime
            // 
            this.tbWorkTime.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.tbWorkTime.Location = new System.Drawing.Point(225, 312);
            this.tbWorkTime.Name = "tbWorkTime";
            this.tbWorkTime.ReadOnly = true;
            this.tbWorkTime.Size = new System.Drawing.Size(155, 20);
            this.tbWorkTime.TabIndex = 18;
            // 
            // tbMouseWheelRatio
            // 
            this.tbMouseWheelRatio.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.tbMouseWheelRatio.Location = new System.Drawing.Point(225, 286);
            this.tbMouseWheelRatio.Name = "tbMouseWheelRatio";
            this.tbMouseWheelRatio.ReadOnly = true;
            this.tbMouseWheelRatio.Size = new System.Drawing.Size(155, 20);
            this.tbMouseWheelRatio.TabIndex = 17;
            // 
            // tbRightMousePress
            // 
            this.tbRightMousePress.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.tbRightMousePress.Location = new System.Drawing.Point(225, 208);
            this.tbRightMousePress.Name = "tbRightMousePress";
            this.tbRightMousePress.ReadOnly = true;
            this.tbRightMousePress.Size = new System.Drawing.Size(155, 20);
            this.tbRightMousePress.TabIndex = 16;
            // 
            // tbLeftMousePress
            // 
            this.tbLeftMousePress.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.tbLeftMousePress.Location = new System.Drawing.Point(225, 182);
            this.tbLeftMousePress.Name = "tbLeftMousePress";
            this.tbLeftMousePress.ReadOnly = true;
            this.tbLeftMousePress.Size = new System.Drawing.Size(155, 20);
            this.tbLeftMousePress.TabIndex = 15;
            // 
            // tbKeyPressRelease
            // 
            this.tbKeyPressRelease.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.tbKeyPressRelease.Location = new System.Drawing.Point(225, 105);
            this.tbKeyPressRelease.Name = "tbKeyPressRelease";
            this.tbKeyPressRelease.ReadOnly = true;
            this.tbKeyPressRelease.Size = new System.Drawing.Size(155, 20);
            this.tbKeyPressRelease.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(61, 289);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Pelės ratuko naudojimo santykis";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(118, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Klavišų paspaudimų";
            // 
            // lblTotalWords
            // 
            this.lblTotalWords.AutoSize = true;
            this.lblTotalWords.Location = new System.Drawing.Point(156, 30);
            this.lblTotalWords.Name = "lblTotalWords";
            this.lblTotalWords.Size = new System.Drawing.Size(63, 13);
            this.lblTotalWords.TabIndex = 7;
            this.lblTotalWords.Text = "Viso žodžių:";
            // 
            // lblLastWordWithMistake
            // 
            this.lblLastWordWithMistake.AutoSize = true;
            this.lblLastWordWithMistake.Location = new System.Drawing.Point(13, 82);
            this.lblLastWordWithMistake.Name = "lblLastWordWithMistake";
            this.lblLastWordWithMistake.Size = new System.Drawing.Size(206, 13);
            this.lblLastWordWithMistake.TabIndex = 9;
            this.lblLastWordWithMistake.Text = "Viso žodžių, kuriuos rašant taisytos klaidos";
            // 
            // tbTotalWords
            // 
            this.tbTotalWords.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.tbTotalWords.Location = new System.Drawing.Point(225, 27);
            this.tbTotalWords.Name = "tbTotalWords";
            this.tbTotalWords.ReadOnly = true;
            this.tbTotalWords.Size = new System.Drawing.Size(155, 20);
            this.tbTotalWords.TabIndex = 2;
            // 
            // lblLastWord
            // 
            this.lblLastWord.AutoSize = true;
            this.lblLastWord.Location = new System.Drawing.Point(81, 56);
            this.lblLastWord.Name = "lblLastWord";
            this.lblLastWord.Size = new System.Drawing.Size(138, 13);
            this.lblLastWord.TabIndex = 8;
            this.lblLastWord.Text = "Paskutinis užfiksuotas žodis";
            // 
            // tbLastWord
            // 
            this.tbLastWord.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.tbLastWord.Location = new System.Drawing.Point(225, 53);
            this.tbLastWord.Name = "tbLastWord";
            this.tbLastWord.ReadOnly = true;
            this.tbLastWord.Size = new System.Drawing.Size(155, 20);
            this.tbLastWord.TabIndex = 3;
            // 
            // tbTotalWordsWithMistakes
            // 
            this.tbTotalWordsWithMistakes.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.tbTotalWordsWithMistakes.Location = new System.Drawing.Point(225, 79);
            this.tbTotalWordsWithMistakes.Name = "tbTotalWordsWithMistakes";
            this.tbTotalWordsWithMistakes.ReadOnly = true;
            this.tbTotalWordsWithMistakes.Size = new System.Drawing.Size(155, 20);
            this.tbTotalWordsWithMistakes.TabIndex = 4;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(124, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(622, 388);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Pelė";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(124, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(622, 388);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Klaviatūra";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(124, 4);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(622, 388);
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
            this.tabKeyboardHeatMap.Size = new System.Drawing.Size(622, 388);
            this.tabKeyboardHeatMap.TabIndex = 4;
            this.tabKeyboardHeatMap.Text = "Klaviatūros karštis";
            this.tabKeyboardHeatMap.UseVisualStyleBackColor = true;
            // 
            // tabPage6
            // 
            this.tabPage6.Location = new System.Drawing.Point(124, 4);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(622, 388);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "tabPage6";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // timer_workTime
            // 
            this.timer_workTime.Interval = 1000;
            this.timer_workTime.Tick += new System.EventHandler(this.timer_workTime_Tick);
            // 
            // tbKeyPress
            // 
            this.tbKeyPress.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.tbKeyPress.Location = new System.Drawing.Point(225, 131);
            this.tbKeyPress.Name = "tbKeyPress";
            this.tbKeyPress.ReadOnly = true;
            this.tbKeyPress.Size = new System.Drawing.Size(155, 20);
            this.tbKeyPress.TabIndex = 30;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(118, 134);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(101, 13);
            this.label11.TabIndex = 31;
            this.label11.Text = "Klavišų nuspaudimų";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 442);
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
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
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
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
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
    }
}

