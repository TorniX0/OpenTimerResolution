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
            this.minimizeIconContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // startButton
            // 
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
            this.stopButton.Location = new System.Drawing.Point(178, 159);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(75, 23);
            this.stopButton.TabIndex = 1;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
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
            this.timerResolutionBox.Location = new System.Drawing.Point(185, 92);
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
            this.warningLabel.Size = new System.Drawing.Size(286, 30);
            this.warningLabel.TabIndex = 7;
            this.warningLabel.Text = "WARNING! YOU SHOULDN\'T USE THIS VALUE!\r\nUSE 0.50 IF YOU DON\'T KNOW WHAT YOU\'RE DOIN" +
    "G!";
            this.warningLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.warningLabel.Visible = false;
            // 
            // intervalComboBox
            // 
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
            this.textIntervalLabel.BackColor = System.Drawing.Color.Transparent;
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
            this.minimizeIcon.Visible = true;
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
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(327, 237);
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
    }
}
