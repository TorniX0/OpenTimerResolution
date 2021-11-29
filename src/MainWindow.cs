using Microsoft.Win32;
using Microsoft.Win32.TaskScheduler;
using System.Reflection;
using System.Runtime.InteropServices;

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

        #pragma warning disable CS8602 // Dereference of a possibly null reference.

        private readonly static bool emptyBuildVersion = Assembly.GetEntryAssembly().GetName().Version.Build == -1;
        private readonly string ProgramVersion = emptyBuildVersion ? Assembly.GetEntryAssembly().GetName().Version.Build.ToString() : "1.0.2.1";

        #pragma warning restore CS8602 // Dereference of a possibly null reference.

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




        public MainWindow()
        {
            if (System.Diagnostics.Process.GetProcessesByName(System.Diagnostics.Process.GetCurrentProcess().ProcessName).Length > 1)
            {
                MessageBox.Show("OpenTimerResolution is already running. Only one instance of this application is allowed.", "OpenTimerResolution");
                this.Close();
                return;
            }

            InitializeComponent();

            try
            {
                string[] args = Environment.GetCommandLineArgs();
                for (int i = 1; i < args.Length; i++)
                {
                    string arg = args[i];

                    switch (arg)
                    {
                        case "-minimized":
                            {
                                this.WindowState = FormWindowState.Minimized;
                            
                                this.Hide();

                                timerResolutionBox.Text = "0.50";

                                var result = NtSetTimerResolution((int)(float.Parse(timerResolutionBox.Text) * 10000f), true, out NtCurrentResolution);

                                if (result != NtStatus.Success)
                                    MessageBox.Show($"Error code: {result}", "OpenTimerResolution", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                timerResolutionBox.ReadOnly = true;
                                timerResolutionBox.Enabled = false;
                                startButton.Enabled = false;
                                stopButton.Enabled = true;
                                break;
                            }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Wrong arguments, or something went wrong.");
            }

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
                warningLabel.Visible = (double.Parse(timerResolutionBox.Text) > 15.6250d) ? true : false;
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
        }


        private void startButton_Click(object sender, EventArgs e)
        {
            var result = NtSetTimerResolution((int)(float.Parse(timerResolutionBox.Text) * 10000f), true, out NtCurrentResolution);

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
            var result = NtSetTimerResolution((int)(float.Parse(timerResolutionBox.Text) * 10000f), false, out NtCurrentResolution);
                
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
            NtQueryTimerResolution(out NtMinimumResolution, out NtMaximumResolution, out NtActualResolution);

            // Values are represented in milliseconds.
            currentResolutionLabel.Text = $"Current Resolution: {NtActualResolution * 0.0001:N4}ms";
            minimumResolutionLabel.Text = $"Minimum Resolution: {NtMinimumResolution * 0.0001:N4}ms";
            maximumResolutionLabel.Text = $"Maximum Resolution: {NtMaximumResolution * 0.0001:N4}ms";
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
    }
}
