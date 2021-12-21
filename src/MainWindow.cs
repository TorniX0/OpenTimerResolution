using Microsoft.Win32;
using Microsoft.Win32.TaskScheduler;
using System.Configuration;
using System.Globalization;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenTimerResolution
{
    public partial class MainWindow : Form
    {
        #region Definitions

        /// <summary>
        /// NtQueryTimerResolution returns the resolution of the system Timer in the context of the calling process.
        /// </summary>
        /// <param name="MinimumResolution">Minimum resolution defined by the system Timer.</param>
        /// <param name="MaximumResolution">Maximum resolution defined by the system Timer.</param>
        /// <param name="ActualResolution">Actual current resolution set.</param>
        [DllImport("ntdll.dll", SetLastError = true)]
        private static extern NtStatus NtQueryTimerResolution(out uint MinimumResolution, out uint MaximumResolution, out uint ActualResolution);

        /// <summary>
        /// NtSetTimerResolution sets the resolution of the system Timer in the calling process context.
        /// </summary>
        /// <param name="DesiredResolution">The desired resolution for the system Timer.</param>
        /// <param name="SetResolution">Set to 'true' if setting a custom resolution, to 'false' if resetting to the default resolution.</param>
        /// <param name="CurrentResolution">Current resolution set.</param>
        [DllImport("ntdll.dll", SetLastError = true)]
        private static extern NtStatus NtSetTimerResolution(int DesiredResolution, bool SetResolution, out int CurrentResolution);

        private int NtCurrentResolution = 156250;
        private uint NtMinimumResolution = 0;
        private uint NtMaximumResolution = 0;
        private uint NtActualResolution = 0;

        private readonly static bool emptyBuildVersion = Assembly.GetEntryAssembly().GetName().Version.Build == -1;
        private readonly string ProgramVersion = emptyBuildVersion ? Assembly.GetEntryAssembly().GetName().Version.Build.ToString() : "1.0.3.1";

        private static Dictionary<string, int> Logger = new();

        /// <summary>
        /// Receives the index of the Text Update Interval Combo Box, and returns the represented value.
        /// </summary>
        /// <param name="original">The index of the Text Update Interval Combo Box.</param>
        /// <returns>Interval value for the timer.</returns>
        private static int GetIntervalFromIndex(int original)
        {

            return original switch
            {
                0 => 1000,
                1 => 500,
                2 => 125,
                3 => 50,
                _ => 1000,
            };
        }

        #endregion


        #region Methods

        public MainWindow()
        {
            InitializeComponent();

            using (TaskService ts = new TaskService())
            {
                installScheduleButton.Text = ts.RootFolder.AllTasks.Any(t => t.Name == "OpenTimerRes") ? "Remove start-up schedule" : "Install start-up schedule";
            }

            this.Text = $"OpenTimerResolution | {ProgramVersion}";

            intervalComboBox.SelectedIndex = 0; // Default is 1000ms.
        }

        private void timerResolutionBox_TextChanged(object sender, EventArgs e)
        {
            if (timerResolutionBox.Text != string.Empty && timerResolutionBox.Text.Last() != '.')
            {
                warningLabel.Visible = (double.Parse(timerResolutionBox.Text, CultureInfo.InvariantCulture) > 15.6250d) ? true : false;
            }
        }


        private void timerResolutionBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && (timerResolutionBox.Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }


        private void intervalComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            textChanger.Interval = GetIntervalFromIndex(intervalComboBox.SelectedIndex); // Changing the interval on index change.
            automaticMemoryPurger.Interval = GetIntervalFromIndex(intervalComboBox.SelectedIndex); // Also linked the automatic memory purger to it.
        }


        private void startButton_Click(object sender, EventArgs e)
        {
            if (timerResolutionBox.Text == string.Empty)
                return;

            var result = NtSetTimerResolution((int)(float.Parse(timerResolutionBox.Text, CultureInfo.InvariantCulture) * 10000f), true, out NtCurrentResolution);

            if (result != NtStatus.Success)
            {
                MessageBox.Show($"Error code: {result}", "OpenTimerResolution", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            timerResolutionBox.ReadOnly = true;
            timerResolutionBox.Enabled = false;
            startButton.Enabled = false;
            stopButton.Enabled = true;
        }


        private void stopButton_Click(object sender, EventArgs e)
        {
            if (timerResolutionBox.Text == string.Empty)
                return;

            var result = NtSetTimerResolution((int)(float.Parse(timerResolutionBox.Text, CultureInfo.InvariantCulture) * 10000f), false, out NtCurrentResolution);
                
            if (result != NtStatus.Success)
            {
                MessageBox.Show($"Error code: {result}", "OpenTimerResolution", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            timerResolutionBox.ReadOnly = false;
            timerResolutionBox.Enabled = true;
            startButton.Enabled = true;
            stopButton.Enabled = false;
        }

        private void textChanger_Tick(object sender, EventArgs e)
        {
            if (!timerLogger.Enabled)
                NtQueryTimerResolution(out NtMinimumResolution, out NtMaximumResolution, out NtActualResolution);

            // Timer Resolution labels
            currentResolutionLabel.Text = $"Current Resolution: {NtActualResolution * 0.0001:N4}ms";
            minimumResolutionLabel.Text = $"Minimum Resolution: {NtMinimumResolution * 0.0001:N4}ms";
            maximumResolutionLabel.Text = $"Maximum Resolution: {NtMaximumResolution * 0.0001:N4}ms";

            // Memory Cleaner labels
            totalSystemMemoryText.Text = $"Total system memory: {MemoryCleaner.GetTotalMemory()} MB";
            freeMemoryText.Text = $"Free memory: {MemoryCleaner.GetAvailableMemory()} MB";
            cacheSizeText.Text = $"Cache size: {MemoryCleaner.GetStandbyCache()} MB";
            totalTimesCleanText.Text = $"Total times cleaned: {MemoryCleaner.cleanCounter} time(s)";
        }

        private void MainWindow_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                minimizeIcon.Visible = true;
            }
        }

        private void minimizeIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (!this.ShowInTaskbar)
                this.ShowInTaskbar = true;

            this.Show();
            this.WindowState = FormWindowState.Normal;
            minimizeIcon.Visible = false;
        }

        private void quitStripMenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void installScheduleButton_Click(object sender, EventArgs e)
        {
            using (TaskService ts = new TaskService())
            {
                if (ts.RootFolder.AllTasks.Any(t => t.Name == "OpenTimerRes"))
                {
                    ts.RootFolder.DeleteTask("OpenTimerRes");
                }
                else
                {
                    TaskDefinition td = ts.NewTask();

                    td.RegistrationInfo.Description = "Opens OpenTimerResultion at startup.";

                    td.Principal.RunLevel = TaskRunLevel.Highest;

                    td.Triggers.Add(new LogonTrigger());

                    td.Actions.Add(new ExecAction(@$"""{Application.ExecutablePath}""", "-minimized"));

                    td.Settings.StopIfGoingOnBatteries = false;
                    td.Settings.DisallowStartIfOnBatteries = false;
                    td.Settings.RunOnlyIfNetworkAvailable = false;
                    td.Settings.Enabled = true;

                    ts.RootFolder.RegisterTaskDefinition("OpenTimerRes", td);
                }

                installScheduleButton.Text = ts.RootFolder.AllTasks.Any(t => t.Name == "OpenTimerRes") ? "Remove start-up schedule" : "Install start-up schedule";
            }
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            bool darkMode = false;
            bool purgeAutomatically = false;
            float desiredResolution = 0;

            try
            {
                if (bool.TryParse(System.Configuration.ConfigurationManager.AppSettings["DarkMode"], out darkMode))
                    darkModeBox.Checked = darkMode;

                if (bool.TryParse(System.Configuration.ConfigurationManager.AppSettings["StartPurgingAutomatically"], out purgeAutomatically))
                    automaticCacheCleanBox.Checked = purgeAutomatically;

                if (float.TryParse(System.Configuration.ConfigurationManager.AppSettings["DesiredResolution"], out desiredResolution)) { }

                timerResolutionBox.Text = $"{desiredResolution}";
            }
            catch
            {
                MessageBox.Show("Config is invalid, or something else went wrong!", "OpenTimerResolution", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Program.startMinimized)
            {
                var result = NtSetTimerResolution((int)(float.Parse(timerResolutionBox.Text, CultureInfo.InvariantCulture) * 10000f), true, out NtCurrentResolution);

                if (result != NtStatus.Success)
                    MessageBox.Show($"Error code: {result}", "OpenTimerResolution", MessageBoxButtons.OK, MessageBoxIcon.Error);

                timerResolutionBox.ReadOnly = true;
                timerResolutionBox.Enabled = false;
                startButton.Enabled = false;
                stopButton.Enabled = true;
            }
        }

        private void logButton_Click(object sender, EventArgs e)
        {
            if (!timerLogger.Enabled)
            {
                timerLogger.Start();
                logButton.Text = "Stop logging";
                logButton.ForeColor = Color.Red;
            }
            else
            {
                timerLogger.Stop();

                StringBuilder final = new StringBuilder();

                foreach (var pair in Logger)
                {
                    final.AppendLine($"{pair.Key}ms - {pair.Value}x");
                }

                SaveFileDialog saveFileDiag = new SaveFileDialog();
                saveFileDiag.InitialDirectory = Application.ExecutablePath;
                saveFileDiag.FileName = System.Text.RegularExpressions.Regex.Replace(@$"OTR-{DateTime.Now}.log", "[\\/:*?\"<>|]", "-").Replace(" ", "_");
                saveFileDiag.Title = "Choose where to save log file...";
                saveFileDiag.DefaultExt = "log";
                saveFileDiag.Filter = "log files (*.log)|*.log";
                saveFileDiag.CheckPathExists = true;
                saveFileDiag.CheckFileExists = false;

                var result = saveFileDiag.ShowDialog();

                logButton.Text = "Start logging actual resolution";
                logButton.ForeColor = this.ForeColor;

                if (result != DialogResult.OK)
                {

                    MessageBox.Show($"Cancelled log saving.", "OpenTimerResolution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                File.WriteAllText(saveFileDiag.FileName, final.ToString());

                MessageBox.Show($"Saved log file in {saveFileDiag.FileName}!", "OpenTimerResolution", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void timerLogger_Tick(object sender, EventArgs e)
        {
            NtQueryTimerResolution(out NtMinimumResolution, out NtMaximumResolution, out NtActualResolution);

            Logger.TryGetValue((NtActualResolution * 0.0001).ToString("N4"), out var count);
            Logger[(NtActualResolution * 0.0001).ToString("N4")] = count + 1;
        }

        private void darkModeBox_CheckedChanged(object sender, EventArgs e)
        {
            //maybe upgrade project to WPF?

            if (darkModeBox.Checked)
            {
                this.BackColor = Color.Black;
                this.ForeColor = Color.White;
                UpdateUI();
            }
            else
            {
                this.BackColor = Color.White;
                this.ForeColor = SystemColors.ControlText;
                UpdateUI();
            }
        }

        private void UpdateUI()
        {
            timerResolutionBox.BackColor = this.BackColor;
            timerResolutionBox.ForeColor = this.ForeColor;
            intervalComboBox.ForeColor = this.ForeColor;
            intervalComboBox.BackColor = this.BackColor;
            logButton.ForeColor = this.ForeColor;
            logButton.BackColor = this.BackColor;
            stopButton.ForeColor = this.ForeColor;
            stopButton.BackColor = this.BackColor;
            startButton.ForeColor = this.ForeColor;
            startButton.BackColor = this.BackColor;
            installScheduleButton.ForeColor = this.ForeColor;
            installScheduleButton.BackColor = this.BackColor;
            automaticCacheCleanBox.ForeColor = this.ForeColor;
            automaticCacheCleanBox.BackColor = this.BackColor;
            totalTimesCleanText.ForeColor = this.ForeColor;
            totalTimesCleanText.BackColor = this.BackColor;
            automaticCacheCleanBox.ForeColor = this.ForeColor;
            automaticCacheCleanBox.BackColor = this.BackColor;
            freeMemoryText.ForeColor = this.ForeColor;
            freeMemoryText.BackColor = this.BackColor;
            totalSystemMemoryText.ForeColor = this.ForeColor;
            totalSystemMemoryText.BackColor = this.BackColor;
            purgeCacheButton.ForeColor = this.ForeColor;
            purgeCacheButton.BackColor = this.BackColor;
            updateConfigButton.ForeColor = this.ForeColor;
            updateConfigButton.BackColor = this.BackColor;
        }

        private void automaticCacheCleanBox_CheckedChanged(object sender, EventArgs e)
        {
            if (automaticCacheCleanBox.Checked)
            {
                automaticMemoryPurger.Start();
            }
            else
            {
                automaticMemoryPurger.Stop();
            }
        }

        private void purgeCacheButton_Click(object sender, EventArgs e)
        {
            MemoryCleaner.ClearStandbyCache();
        }

        private void automaticMemoryPurger_Tick(object sender, EventArgs e)
        {
            if (MemoryCleaner.GetStandbyCache() >= 2048 && MemoryCleaner.GetAvailableMemory() <= (MemoryCleaner.GetTotalMemory() / 2))
                MemoryCleaner.ClearStandbyCache();
            else
                return;
        }

        private void updateConfigButton_Click(object sender, EventArgs e)
        {
            ExeConfigurationFileMap customConfigFileMap = new ExeConfigurationFileMap();
            customConfigFileMap.ExeConfigFilename = AppDomain.CurrentDomain.GetData("APP_CONFIG_FILE").ToString();
            Configuration customConfig = ConfigurationManager.OpenMappedExeConfiguration(customConfigFileMap, ConfigurationUserLevel.None);

            AppSettingsSection appSettings = customConfig.GetSection("appSettings") as AppSettingsSection;

            appSettings.Settings["DarkMode"].Value = darkModeBox.Checked.ToString();
            appSettings.Settings["StartPurgingAutomatically"].Value = automaticCacheCleanBox.Checked.ToString();
            appSettings.Settings["DesiredResolution"].Value = timerResolutionBox.Text;

            customConfig.Save();


            MessageBox.Show($"Config was updated successfully!", "OpenTimerResolution", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion
    }
}
