using Microsoft.Win32.TaskScheduler;
using Newtonsoft.Json.Linq;
using System.Configuration;
using System.Diagnostics;
using System.Globalization;
using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;

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

        private readonly static Version assemblyVersion = Assembly.GetEntryAssembly().GetName().Version;
        private readonly string programVersion = string.Join('.', assemblyVersion.Major, assemblyVersion.Minor, assemblyVersion.Build, assemblyVersion.Revision);

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

        /// <summary>
        /// Receives a string and translates it to the index for the Text Update Interval Combo Box (in this case used for the config).
        /// </summary>
        /// <param name="text">The string needed to be translated.</param>
        /// <returns>The index value for the Text Update Interval Combo Box.</returns>
        private static int GetIndexFromString(string text)
        {

            return text switch
            {
                "1000ms" => 0,
                "500ms" => 1,
                "125ms" => 2,
                "50ms" => 3,
                _ => 0,
            };
        }

        #endregion


        #region Methods

        public MainWindow()
        {
            InitializeComponent();

            using (TaskService ts = new())
            {
                installScheduleButton.Text = ts.RootFolder.AllTasks.Any(t => t.Name == "OpenTimerRes") ? "Remove start-up schedule" : "Install start-up schedule";
            }

            this.Text = string.Concat("OpenTimerResolution | ", programVersion);

            bool darkMode = false;
            bool purgeAutomatically = false;
            float desiredResolution = 0f;
            string textUpdateInterval = string.Empty;

            try
            {
                if (bool.TryParse(ConfigurationManager.AppSettings["DarkMode"], out darkMode))
                    darkModeBox.Checked = darkMode;

                if (bool.TryParse(ConfigurationManager.AppSettings["StartPurgingAutomatically"], out purgeAutomatically))
                    automaticCacheCleanBox.Checked = purgeAutomatically;

                float.TryParse(ConfigurationManager.AppSettings["DesiredResolution"], out desiredResolution);

                if (desiredResolution == 0f)
                    desiredResolution = 0.50f;

                timerResolutionBox.Text = desiredResolution.ToString();

                textUpdateInterval = ConfigurationManager.AppSettings["TextUpdateInterval"];

                intervalComboBox.SelectedIndex = GetIndexFromString(textUpdateInterval);
            }
            catch
            {
                MessageBox.Show("Config is invalid, or something else went wrong!", "OpenTimerResolution", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            CheckForUpdates();
        }

        private static string GetRequest(string uri, bool jsonaccept)
        {
            HttpClient client = new();
            client.BaseAddress = new(uri);
            client.Timeout = new(0, 0, 4);

            if (jsonaccept)
                client.DefaultRequestHeaders
                      .Accept
                      .Add(new MediaTypeWithQualityHeaderValue("application/json"));

            string res = string.Empty;

            try
            {
                res = client.GetStringAsync(uri).Result;
            }
            catch (AggregateException ex)
            {
                ex.Handle(x =>
                {
                    if (x is HttpRequestException || x is SocketException || x is TaskCanceledException)
                    {
                        return true;
                    }

                    return false;
                });
            }

            return res;
        }

        private void CheckForUpdates()
        {
            string json = GetRequest("https://github.com/TorniX0/OpenTimerResolution/releases/latest", true);

            if (json == string.Empty)
                return;

            var obj = JObject.Parse(json);
            string ver = obj["tag_name"].ToString();
            ver = ver.Substring(8, ver.Length - 8);

            if (ver != programVersion)
            {
                DialogResult res = MessageBox.Show("Found a new update! Would you like to be redirected to the GitHub page?", "OpenTimerResolution", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                switch (res)
                {
                    case DialogResult.Yes:
                        Process.Start(new ProcessStartInfo("cmd", "/c start https://github.com/TorniX0/OpenTimerResolution/releases/latest") { CreateNoWindow = true });
                        break;
                    case DialogResult.No:
                        break;
                }
            }
        }

        private void timerResolutionBox_TextChanged(object sender, EventArgs e)
        {
            if (timerResolutionBox.Text != string.Empty && timerResolutionBox.Text.Last() != '.')
            {
                warningLabel.Visible = float.Parse(timerResolutionBox.Text) > 15.6250f;
            }
        }


        private void timerResolutionBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                return;
            }

            if ((e.KeyChar == '.') && (timerResolutionBox.Text.IndexOf('.') > -1))
            {
                e.Handled = true;
                return;
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

            var result = NtSetTimerResolution((int)(float.Parse(timerResolutionBox.Text) * 10000f), true, out NtCurrentResolution);

            if (result != NtStatus.SUCCESS)
            {
                MessageBox.Show(string.Concat("Error code: ", result.ToString()), "OpenTimerResolution", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            var result = NtSetTimerResolution((int)(float.Parse(timerResolutionBox.Text) * 10000f), false, out NtCurrentResolution);

            if (result != NtStatus.SUCCESS)
            {
                MessageBox.Show(string.Concat("Error code: ", result.ToString()), "OpenTimerResolution", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            currentResolutionLabel.Text = string.Concat("Current Resolution: ", (NtActualResolution * 0.0001f).ToString("N4"), "ms");
            minimumResolutionLabel.Text = string.Concat("Minimum Resolution: ", (NtMinimumResolution * 0.0001f).ToString("N4"), "ms");
            maximumResolutionLabel.Text = string.Concat("Maximum Resolution: ", (NtMaximumResolution * 0.0001f).ToString("N4") ,"ms");

            // Memory Cleaner labels
            totalSystemMemoryText.Text = string.Concat("Total system memory: ", MemoryCleaner.GetTotalMemory().ToString(), " MB");
            freeMemoryText.Text = string.Concat("Free memory: ", MemoryCleaner.GetFreeMemory().ToString(), " MB");
            cacheSizeText.Text = string.Concat("Cache size: ", MemoryCleaner.GetStandbyCache().ToString(), " MB");
            totalTimesCleanText.Text = string.Concat("Total times cleaned: ", MemoryCleaner.cleanCounter.ToString(), " time(s)");
        }

        private void MainWindow_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                minimizeIcon.Visible = true;
                this.ShowInTaskbar = false;
                this.Hide();
                this.SendToBack();
            }
        }

        private void minimizeIcon_MouseClick(object sender, MouseEventArgs e)
        {
            minimizeIcon.Visible = false;
            this.ShowInTaskbar = true;
            this.Show();
            this.BringToFront();
            this.WindowState = FormWindowState.Normal;
        }

        private void quitStripMenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void installScheduleButton_Click(object sender, EventArgs e)
        {
            using TaskService ts = new();

            if (ts.RootFolder.AllTasks.Any(t => t.Name == "OpenTimerRes")) ts.RootFolder.DeleteTask("OpenTimerRes");
            else
            {
                TaskDefinition td = ts.NewTask();

                td.RegistrationInfo.Description = "Opens OpenTimerResolution at startup.";

                td.Principal.RunLevel = TaskRunLevel.Highest;

                td.Triggers.Add(new LogonTrigger());

                td.Actions.Add(new ExecAction(string.Concat("\"", Application.ExecutablePath, "\""), "-minimized"));

                td.Settings.StopIfGoingOnBatteries = false;
                td.Settings.DisallowStartIfOnBatteries = false;
                td.Settings.RunOnlyIfNetworkAvailable = false;
                td.Settings.RunOnlyIfIdle = false;
                td.Settings.Enabled = true;

                ts.RootFolder.RegisterTaskDefinition("OpenTimerRes", td);
            }

            installScheduleButton.Text = ts.RootFolder.AllTasks.Any(t => t.Name == "OpenTimerRes") ? "Remove start-up schedule" : "Install start-up schedule";
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            if (Program.startMinimized)
            {
                var result = NtSetTimerResolution((int)(float.Parse(timerResolutionBox.Text) * 10000f), true, out NtCurrentResolution);

                if (result != NtStatus.SUCCESS)
                    MessageBox.Show(string.Concat("Error code: ", result.ToString()), "OpenTimerResolution", MessageBoxButtons.OK, MessageBoxIcon.Error);

                timerResolutionBox.ReadOnly = true;
                timerResolutionBox.Enabled = false;
                startButton.Enabled = false;
                stopButton.Enabled = true;

                this.ShowInTaskbar = false;
                minimizeIcon.Visible = true;
                this.Hide();
                this.SendToBack();
            }

            using (TaskService ts = new())
            {
                if (Program.silentInstall && !ts.RootFolder.AllTasks.Any(t => t.Name == "OpenTimerRes"))
                    installScheduleButton_Click(installScheduleButton, EventArgs.Empty);
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

                StringBuilder final = new();

                final.AppendLine(string.Concat("- Note: updated once every ", timerLogger.Interval.ToString(), "ms.", Environment.NewLine));

                foreach (var pair in Logger)
                {
                    final.AppendLine(string.Concat(pair.Key, "ms - ", pair.Value.ToString(), " time(s)"));
                }

                SaveFileDialog saveFileDiag = new();
                saveFileDiag.InitialDirectory = Application.ExecutablePath;
                saveFileDiag.FileName = Regex.Replace($"OTR-{DateTime.Now}.log", "[\\/:*?\"<>|]", "-").Replace(" ", "_");
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
                    MessageBox.Show("Cancelled log saving.", "OpenTimerResolution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                File.WriteAllText(saveFileDiag.FileName, final.ToString());

                MessageBox.Show(string.Concat("Saved log file in ", saveFileDiag.FileName, "!"), "OpenTimerResolution", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void timerLogger_Tick(object sender, EventArgs e)
        {
            NtQueryTimerResolution(out NtMinimumResolution, out NtMaximumResolution, out NtActualResolution);

            Logger.TryGetValue((NtActualResolution * 0.0001f).ToString("N4"), out var count);
            Logger[(NtActualResolution * 0.0001f).ToString("N4")] = count + 1;
        }

        private void darkModeBox_CheckedChanged(object sender, EventArgs e)
        {
            if (darkModeBox.Checked)
            {
                this.BackColor = Color.FromArgb(255, 15, 15, 15);
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
            for (int i = 0; i < this.Controls.Count; i++)
            {
                if (this.Controls[i] == creatorLabel || this.Controls[i] == warningLabel) continue;

                this.Controls[i].ForeColor = this.ForeColor;
                this.Controls[i].BackColor = this.BackColor;
            }
        }

        private void automaticCacheCleanBox_CheckedChanged(object sender, EventArgs e)
        {
            if (automaticCacheCleanBox.Checked)
                automaticMemoryPurger.Start();
            else
                automaticMemoryPurger.Stop();
        }

        private void purgeCacheButton_Click(object sender, EventArgs e)
        {
            MemoryCleaner.ClearStandbyCache();
        }

        private void automaticMemoryPurger_Tick(object sender, EventArgs e)
        {
            if (MemoryCleaner.GetStandbyCache() >= 2048 && MemoryCleaner.GetFreeMemory() < (MemoryCleaner.GetTotalMemory() / 2))
                MemoryCleaner.ClearStandbyCache();
            else
                return;
        }

        private void updateConfigButton_Click(object sender, EventArgs e)
        {
            Configuration customConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            AppSettingsSection appSettings = customConfig.GetSection("appSettings") as AppSettingsSection;

            appSettings.Settings["DarkMode"].Value = darkModeBox.Checked.ToString();
            appSettings.Settings["StartPurgingAutomatically"].Value = automaticCacheCleanBox.Checked.ToString();
            appSettings.Settings["DesiredResolution"].Value = timerResolutionBox.Text;
            appSettings.Settings["TextUpdateInterval"].Value = intervalComboBox.Text;

            customConfig.Save();


            MessageBox.Show("Config was updated successfully!", "OpenTimerResolution", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion
    }
}
