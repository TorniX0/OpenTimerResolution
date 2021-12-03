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
            this.creatorLabel.Location = new System.Drawing.Point(245, 0);
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
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(327, 330);
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
    }
}
