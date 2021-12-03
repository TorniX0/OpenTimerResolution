namespace OpenTimerResolution
{
    internal static class Program
    {
        internal static readonly bool startMinimized = Environment.GetCommandLineArgs().Any(t => t.Equals("-minimized"));
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (System.Diagnostics.Process.GetProcessesByName(System.Diagnostics.Process.GetCurrentProcess().ProcessName).Length > 1)
            {
                MessageBox.Show("OpenTimerResolution is already running. Only one instance of this application is allowed.", "OpenTimerResolution");
                Application.Exit();
                return;
            }

            ApplicationConfiguration.Initialize();
            MainWindow mainWind = new MainWindow();

            if (startMinimized) {

                try
                {
                    mainWind.WindowState = FormWindowState.Minimized;
                    mainWind.ShowInTaskbar = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }

            Application.Run(mainWind);
        }
    }
}
