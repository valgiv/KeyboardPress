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
            this.test2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.lblLastWordWithMistake = new System.Windows.Forms.Label();
            this.lblLastWord = new System.Windows.Forms.Label();
            this.lblTotalWords = new System.Windows.Forms.Label();
            this.tbTotalWordsWithMistakes = new System.Windows.Forms.TextBox();
            this.tbLastWord = new System.Windows.Forms.TextBox();
            this.tbTotalWords = new System.Windows.Forms.TextBox();
            this.timer_workTime = new System.Windows.Forms.Timer(this.components);
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
            this.test2ToolStripMenuItem,
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
            this.administrationToolStripMenuItem.Click += new System.EventHandler(this.testToolStripMenuItem_Click);
            // 
            // offerWordToolStripMenuItem
            // 
            this.offerWordToolStripMenuItem.Name = "offerWordToolStripMenuItem";
            this.offerWordToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.offerWordToolStripMenuItem.Text = "Reikšmių keitimas";
            this.offerWordToolStripMenuItem.Click += new System.EventHandler(this.offerWordToolStripMenuItem_Click);
            // 
            // test2ToolStripMenuItem
            // 
            this.test2ToolStripMenuItem.Name = "test2ToolStripMenuItem";
            this.test2ToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.test2ToolStripMenuItem.Text = "test2";
            this.test2ToolStripMenuItem.Click += new System.EventHandler(this.test2ToolStripMenuItem_Click);
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
            this.statusStrip.Location = new System.Drawing.Point(0, 385);
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
            this.panelDebug.Size = new System.Drawing.Size(334, 361);
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
            this.richTB_debug.Size = new System.Drawing.Size(334, 361);
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
            this.panelMain.Size = new System.Drawing.Size(750, 361);
            this.panelMain.TabIndex = 3;
            // 
            // tabControlMain
            // 
            this.tabControlMain.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControlMain.Controls.Add(this.tabPage1);
            this.tabControlMain.Controls.Add(this.tabPage2);
            this.tabControlMain.Controls.Add(this.tabPage3);
            this.tabControlMain.Controls.Add(this.tabPage4);
            this.tabControlMain.Controls.Add(this.tabPage5);
            this.tabControlMain.Controls.Add(this.tabPage6);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControlMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControlMain.ItemSize = new System.Drawing.Size(30, 120);
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Multiline = true;
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(750, 361);
            this.tabControlMain.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControlMain.TabIndex = 10;
            this.tabControlMain.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControlMain_DrawItem);
            this.tabControlMain.SelectedIndexChanged += new System.EventHandler(this.tabControlMain_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lblTotalWords);
            this.tabPage1.Controls.Add(this.lblLastWordWithMistake);
            this.tabPage1.Controls.Add(this.tbTotalWords);
            this.tabPage1.Controls.Add(this.lblLastWord);
            this.tabPage1.Controls.Add(this.tbLastWord);
            this.tabPage1.Controls.Add(this.tbTotalWordsWithMistakes);
            this.tabPage1.Location = new System.Drawing.Point(124, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(622, 353);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Informacija";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(124, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(296, 347);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Pelė";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(124, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(296, 347);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Klaviatūra";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(124, 4);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(296, 347);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Klaidos";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage5.Location = new System.Drawing.Point(124, 4);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(296, 347);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Klaviatūros karštis";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // tabPage6
            // 
            this.tabPage6.Location = new System.Drawing.Point(124, 4);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(296, 347);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "tabPage6";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // lblLastWordWithMistake
            // 
            this.lblLastWordWithMistake.Location = new System.Drawing.Point(6, 107);
            this.lblLastWordWithMistake.Name = "lblLastWordWithMistake";
            this.lblLastWordWithMistake.Size = new System.Drawing.Size(115, 29);
            this.lblLastWordWithMistake.TabIndex = 9;
            this.lblLastWordWithMistake.Text = "Viso žodžių, kuriuos rašant taisytos klaidos";
            // 
            // lblLastWord
            // 
            this.lblLastWord.Location = new System.Drawing.Point(6, 78);
            this.lblLastWord.Name = "lblLastWord";
            this.lblLastWord.Size = new System.Drawing.Size(115, 29);
            this.lblLastWord.TabIndex = 8;
            this.lblLastWord.Text = "Paskutinis užfiksuotas žodis";
            // 
            // lblTotalWords
            // 
            this.lblTotalWords.AutoSize = true;
            this.lblTotalWords.Location = new System.Drawing.Point(6, 55);
            this.lblTotalWords.Name = "lblTotalWords";
            this.lblTotalWords.Size = new System.Drawing.Size(63, 13);
            this.lblTotalWords.TabIndex = 7;
            this.lblTotalWords.Text = "Viso žodžių:";
            // 
            // tbTotalWordsWithMistakes
            // 
            this.tbTotalWordsWithMistakes.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.tbTotalWordsWithMistakes.Location = new System.Drawing.Point(150, 107);
            this.tbTotalWordsWithMistakes.Name = "tbTotalWordsWithMistakes";
            this.tbTotalWordsWithMistakes.ReadOnly = true;
            this.tbTotalWordsWithMistakes.Size = new System.Drawing.Size(155, 20);
            this.tbTotalWordsWithMistakes.TabIndex = 4;
            // 
            // tbLastWord
            // 
            this.tbLastWord.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.tbLastWord.Location = new System.Drawing.Point(150, 78);
            this.tbLastWord.Name = "tbLastWord";
            this.tbLastWord.ReadOnly = true;
            this.tbLastWord.Size = new System.Drawing.Size(155, 20);
            this.tbLastWord.TabIndex = 3;
            // 
            // tbTotalWords
            // 
            this.tbTotalWords.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.tbTotalWords.Location = new System.Drawing.Point(150, 52);
            this.tbTotalWords.Name = "tbTotalWords";
            this.tbTotalWords.ReadOnly = true;
            this.tbTotalWords.Size = new System.Drawing.Size(155, 20);
            this.tbTotalWords.TabIndex = 2;
            // 
            // timer_workTime
            // 
            this.timer_workTime.Interval = 1000;
            this.timer_workTime.Tick += new System.EventHandler(this.timer_workTime_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 407);
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
        private System.Windows.Forms.ToolStripMenuItem test2ToolStripMenuItem;
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
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage6;
    }
}

