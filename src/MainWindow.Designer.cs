namespace OpenTimerResolution
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.startButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.currentResolutionLabel = new System.Windows.Forms.Label();
            this.minimumResolutionLabel = new System.Windows.Forms.Label();
            this.maximumResolutionLabel = new System.Windows.Forms.Label();
            this.textChanger = new System.Windows.Forms.Timer(this.components);
            this.wantedResolutionLabel = new System.Windows.Forms.Label();
            this.timerResolutionBox = new System.Windows.Forms.TextBox();
            this.warningLabel = new System.Windows.Forms.Label();
            this.intervalComboBox = new System.Windows.Forms.ComboBox();
            this.textIntervalLabel = new System.Windows.Forms.Label();
            this.minimizeIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.minimizeIconContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.creatorLabel = new System.Windows.Forms.Label();
            this.installScheduleButton = new System.Windows.Forms.Button();
            this.logButton = new System.Windows.Forms.Button();
            this.timerLogger = new System.Windows.Forms.Timer(this.components);
            this.darkModeBox = new System.Windows.Forms.CheckBox();
            this.purgeCacheButton = new System.Windows.Forms.Button();
            this.freeMemoryText = new System.Windows.Forms.Label();
            this.cacheSizeText = new System.Windows.Forms.Label();
            this.totalSystemMemoryText = new System.Windows.Forms.Label();
            this.automaticCacheCleanBox = new System.Windows.Forms.CheckBox();
            this.totalTimesCleanText = new System.Windows.Forms.Label();
            this.automaticMemoryPurger = new System.Windows.Forms.Timer(this.components);
            this.updateConfigButton = new System.Windows.Forms.Button();
            this.minimizeIconContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startButton.Location = new System.Drawing.Point(62, 159);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Enabled = false;
            this.stopButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.stopButton.Location = new System.Drawing.Point(178, 159);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(75, 23);
            this.stopButton.TabIndex = 1;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = false;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // currentResolutionLabel
            // 
            this.currentResolutionLabel.AutoSize = true;
            this.currentResolutionLabel.BackColor = System.Drawing.Color.Transparent;
            this.currentResolutionLabel.Location = new System.Drawing.Point(62, 9);
            this.currentResolutionLabel.Name = "currentResolutionLabel";
            this.currentResolutionLabel.Size = new System.Drawing.Size(109, 15);
            this.currentResolutionLabel.TabIndex = 2;
            this.currentResolutionLabel.Text = "Current Resolution:";
            // 
            // minimumResolutionLabel
            // 
            this.minimumResolutionLabel.AutoSize = true;
            this.minimumResolutionLabel.BackColor = System.Drawing.Color.Transparent;
            this.minimumResolutionLabel.Location = new System.Drawing.Point(62, 37);
            this.minimumResolutionLabel.Name = "minimumResolutionLabel";
            this.minimumResolutionLabel.Size = new System.Drawing.Size(122, 15);
            this.minimumResolutionLabel.TabIndex = 3;
            this.minimumResolutionLabel.Text = "Minimum Resolution:";
            // 
            // maximumResolutionLabel
            // 
            this.maximumResolutionLabel.AutoSize = true;
            this.maximumResolutionLabel.BackColor = System.Drawing.Color.Transparent;
            this.maximumResolutionLabel.Location = new System.Drawing.Point(62, 66);
            this.maximumResolutionLabel.Name = "maximumResolutionLabel";
            this.maximumResolutionLabel.Size = new System.Drawing.Size(124, 15);
            this.maximumResolutionLabel.TabIndex = 4;
            this.maximumResolutionLabel.Text = "Maximum Resolution:";
            // 
            // textChanger
            // 
            this.textChanger.Enabled = true;
            this.textChanger.Interval = 1000;
            this.textChanger.Tick += new System.EventHandler(this.textChanger_Tick);
            // 
            // wantedResolutionLabel
            // 
            this.wantedResolutionLabel.AutoSize = true;
            this.wantedResolutionLabel.BackColor = System.Drawing.Color.Transparent;
            this.wantedResolutionLabel.Location = new System.Drawing.Point(68, 95);
            this.wantedResolutionLabel.Name = "wantedResolutionLabel";
            this.wantedResolutionLabel.Size = new System.Drawing.Size(110, 15);
            this.wantedResolutionLabel.TabIndex = 5;
            this.wantedResolutionLabel.Text = "Wanted Resolution:";
            // 
            // timerResolutionBox
            // 
            this.timerResolutionBox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.timerResolutionBox.Location = new System.Drawing.Point(185, 92);
            this.timerResolutionBox.MaxLength = 7;
            this.timerResolutionBox.Name = "timerResolutionBox";
            this.timerResolutionBox.ShortcutsEnabled = false;
            this.timerResolutionBox.Size = new System.Drawing.Size(60, 23);
            this.timerResolutionBox.TabIndex = 6;
            this.timerResolutionBox.TextChanged += new System.EventHandler(this.timerResolutionBox_TextChanged);
            this.timerResolutionBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.timerResolutionBox_KeyPress);
            // 
            // warningLabel
            // 
            this.warningLabel.AutoSize = true;
            this.warningLabel.BackColor = System.Drawing.Color.Transparent;
            this.warningLabel.ForeColor = System.Drawing.Color.Red;
            this.warningLabel.Location = new System.Drawing.Point(23, 124);
            this.warningLabel.Name = "warningLabel";
            this.warningLabel.Size = new System.Drawing.Size(289, 30);
            this.warningLabel.TabIndex = 7;
            this.warningLabel.Text = "WARNING! YOU SHOULDN\'T USE THIS VALUE!\r\nUSE 0.50 IF YOU DON\'T KNOW WHAT YOU\'RE DO" +
    "ING!";
            this.warningLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.warningLabel.Visible = false;
            // 
            // intervalComboBox
            // 
            this.intervalComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.intervalComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.intervalComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.intervalComboBox.FormattingEnabled = true;
            this.intervalComboBox.Items.AddRange(new object[] {
            "1000ms",
            "500ms",
            "125ms",
            "50ms"});
            this.intervalComboBox.Location = new System.Drawing.Point(164, 202);
            this.intervalComboBox.Name = "intervalComboBox";
            this.intervalComboBox.Size = new System.Drawing.Size(121, 23);
            this.intervalComboBox.TabIndex = 8;
            this.intervalComboBox.SelectedIndexChanged += new System.EventHandler(this.intervalComboBox_SelectedIndexChanged);
            // 
            // textIntervalLabel
            // 
            this.textIntervalLabel.AutoSize = true;
            this.textIntervalLabel.Location = new System.Drawing.Point(41, 205);
            this.textIntervalLabel.Name = "textIntervalLabel";
            this.textIntervalLabel.Size = new System.Drawing.Size(114, 15);
            this.textIntervalLabel.TabIndex = 9;
            this.textIntervalLabel.Text = "Text Update Interval:";
            // 
            // minimizeIcon
            // 
            this.minimizeIcon.ContextMenuStrip = this.minimizeIconContextMenu;
            this.minimizeIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("minimizeIcon.Icon")));
            this.minimizeIcon.Text = "OpenTimerResolution";
            this.minimizeIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.minimizeIcon_MouseClick);
            // 
            // minimizeIconContextMenu
            // 
            this.minimizeIconContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quitToolStripMenuItem});
            this.minimizeIconContextMenu.Name = "minimizeIconContextMenu";
            this.minimizeIconContextMenu.Size = new System.Drawing.Size(98, 26);
            this.minimizeIconContextMenu.Text = "OpenTimerResolution";
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(97, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitStripMenu_Click);
            // 
            // creatorLabel
            // 
            this.creatorLabel.AutoSize = true;
            this.creatorLabel.BackColor = System.Drawing.Color.Transparent;
            this.creatorLabel.ForeColor = System.Drawing.Color.Gray;
            this.creatorLabel.Location = new System.Drawing.Point(701, 1);
            this.creatorLabel.Name = "creatorLabel";
            this.creatorLabel.Size = new System.Drawing.Size(81, 15);
            this.creatorLabel.TabIndex = 10;
            this.creatorLabel.Text = "TorniX © 2021";
            // 
            // installScheduleButton
            // 
            this.installScheduleButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.installScheduleButton.Location = new System.Drawing.Point(23, 240);
            this.installScheduleButton.Name = "installScheduleButton";
            this.installScheduleButton.Size = new System.Drawing.Size(289, 23);
            this.installScheduleButton.TabIndex = 11;
            this.installScheduleButton.Text = "Install start-up schedule";
            this.installScheduleButton.UseVisualStyleBackColor = true;
            this.installScheduleButton.Click += new System.EventHandler(this.installScheduleButton_Click);
            // 
            // logButton
            // 
            this.logButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logButton.Location = new System.Drawing.Point(23, 269);
            this.logButton.Name = "logButton";
            this.logButton.Size = new System.Drawing.Size(289, 26);
            this.logButton.TabIndex = 12;
            this.logButton.Text = "Start logging actual resolution";
            this.logButton.UseVisualStyleBackColor = false;
            this.logButton.Click += new System.EventHandler(this.logButton_Click);
            // 
            // timerLogger
            // 
            this.timerLogger.Interval = 300;
            this.timerLogger.Tick += new System.EventHandler(this.timerLogger_Tick);
            // 
            // darkModeBox
            // 
            this.darkModeBox.AutoSize = true;
            this.darkModeBox.Location = new System.Drawing.Point(23, 301);
            this.darkModeBox.Name = "darkModeBox";
            this.darkModeBox.Size = new System.Drawing.Size(84, 19);
            this.darkModeBox.TabIndex = 13;
            this.darkModeBox.Text = "Dark Mode";
            this.darkModeBox.UseVisualStyleBackColor = true;
            this.darkModeBox.CheckedChanged += new System.EventHandler(this.darkModeBox_CheckedChanged);
            // 
            // purgeCacheButton
            // 
            this.purgeCacheButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.purgeCacheButton.Location = new System.Drawing.Point(479, 170);
            this.purgeCacheButton.Name = "purgeCacheButton";
            this.purgeCacheButton.Size = new System.Drawing.Size(170, 23);
            this.purgeCacheButton.TabIndex = 14;
            this.purgeCacheButton.Text = "Purge memory cache";
            this.purgeCacheButton.UseVisualStyleBackColor = true;
            this.purgeCacheButton.Click += new System.EventHandler(this.purgeCacheButton_Click);
            // 
            // freeMemoryText
            // 
            this.freeMemoryText.AutoSize = true;
            this.freeMemoryText.BackColor = System.Drawing.Color.Transparent;
            this.freeMemoryText.Location = new System.Drawing.Point(393, 107);
            this.freeMemoryText.Name = "freeMemoryText";
            this.freeMemoryText.Size = new System.Drawing.Size(80, 15);
            this.freeMemoryText.TabIndex = 17;
            this.freeMemoryText.Text = "Free memory:";
            // 
            // cacheSizeText
            // 
            this.cacheSizeText.AutoSize = true;
            this.cacheSizeText.BackColor = System.Drawing.Color.Transparent;
            this.cacheSizeText.Location = new System.Drawing.Point(393, 78);
            this.cacheSizeText.Name = "cacheSizeText";
            this.cacheSizeText.Size = new System.Drawing.Size(65, 15);
            this.cacheSizeText.TabIndex = 16;
            this.cacheSizeText.Text = "Cache size:";
            // 
            // totalSystemMemoryText
            // 
            this.totalSystemMemoryText.AutoSize = true;
            this.totalSystemMemoryText.BackColor = System.Drawing.Color.Transparent;
            this.totalSystemMemoryText.Location = new System.Drawing.Point(393, 50);
            this.totalSystemMemoryText.Name = "totalSystemMemoryText";
            this.totalSystemMemoryText.Size = new System.Drawing.Size(123, 15);
            this.totalSystemMemoryText.TabIndex = 15;
            this.totalSystemMemoryText.Text = "Total system memory:";
            // 
            // automaticCacheCleanBox
            // 
            this.automaticCacheCleanBox.AutoSize = true;
            this.automaticCacheCleanBox.Location = new System.Drawing.Point(522, 199);
            this.automaticCacheCleanBox.Name = "automaticCacheCleanBox";
            this.automaticCacheCleanBox.Size = new System.Drawing.Size(82, 19);
            this.automaticCacheCleanBox.TabIndex = 18;
            this.automaticCacheCleanBox.Text = "Automatic";
            this.automaticCacheCleanBox.UseVisualStyleBackColor = true;
            this.automaticCacheCleanBox.CheckedChanged += new System.EventHandler(this.automaticCacheCleanBox_CheckedChanged);
            // 
            // totalTimesCleanText
            // 
            this.totalTimesCleanText.AutoSize = true;
            this.totalTimesCleanText.BackColor = System.Drawing.Color.Transparent;
            this.totalTimesCleanText.Location = new System.Drawing.Point(393, 133);
            this.totalTimesCleanText.Name = "totalTimesCleanText";
            this.totalTimesCleanText.Size = new System.Drawing.Size(111, 15);
            this.totalTimesCleanText.TabIndex = 19;
            this.totalTimesCleanText.Text = "Total times cleaned:";
            // 
            // automaticMemoryPurger
            // 
            this.automaticMemoryPurger.Interval = 1000;
            this.automaticMemoryPurger.Tick += new System.EventHandler(this.automaticMemoryPurger_Tick);
            // 
            // updateConfigButton
            // 
            this.updateConfigButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.updateConfigButton.Location = new System.Drawing.Point(674, 297);
            this.updateConfigButton.Name = "updateConfigButton";
            this.updateConfigButton.Size = new System.Drawing.Size(105, 29);
            this.updateConfigButton.TabIndex = 20;
            this.updateConfigButton.Text = "Update config";
            this.updateConfigButton.UseVisualStyleBackColor = true;
            this.updateConfigButton.Click += new System.EventHandler(this.updateConfigButton_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(783, 330);
            this.Controls.Add(this.updateConfigButton);
            this.Controls.Add(this.totalTimesCleanText);
            this.Controls.Add(this.automaticCacheCleanBox);
            this.Controls.Add(this.freeMemoryText);
            this.Controls.Add(this.cacheSizeText);
            this.Controls.Add(this.totalSystemMemoryText);
            this.Controls.Add(this.purgeCacheButton);
            this.Controls.Add(this.darkModeBox);
            this.Controls.Add(this.logButton);
            this.Controls.Add(this.installScheduleButton);
            this.Controls.Add(this.creatorLabel);
            this.Controls.Add(this.textIntervalLabel);
            this.Controls.Add(this.intervalComboBox);
            this.Controls.Add(this.warningLabel);
            this.Controls.Add(this.timerResolutionBox);
            this.Controls.Add(this.wantedResolutionLabel);
            this.Controls.Add(this.maximumResolutionLabel);
            this.Controls.Add(this.minimumResolutionLabel);
            this.Controls.Add(this.currentResolutionLabel);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.startButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.Text = "OpenTimerResolution";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.Resize += new System.EventHandler(this.MainWindow_Resize);
            this.minimizeIconContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button startButton;
        private Button stopButton;
        private Label currentResolutionLabel;
        private Label minimumResolutionLabel;
        private Label maximumResolutionLabel;
        private System.Windows.Forms.Timer textChanger;
        private Label wantedResolutionLabel;
        private TextBox timerResolutionBox;
        private Label warningLabel;
        private ComboBox intervalComboBox;
        private Label textIntervalLabel;
        private NotifyIcon minimizeIcon;
        private ContextMenuStrip minimizeIconContextMenu;
        private ToolStripMenuItem quitToolStripMenuItem;
        private Label creatorLabel;
        private Button installScheduleButton;
        private Button logButton;
        private System.Windows.Forms.Timer timerLogger;
        private CheckBox darkModeBox;
        private Button purgeCacheButton;
        private Label freeMemoryText;
        private Label cacheSizeText;
        private Label totalSystemMemoryText;
        private CheckBox automaticCacheCleanBox;
        private Label totalTimesCleanText;
        private System.Windows.Forms.Timer automaticMemoryPurger;
        private Button updateConfigButton;
    }
}
