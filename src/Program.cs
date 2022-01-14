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

            if (!File.Exists(@".\OTR_CONFIG.xml"))
                File.WriteAllText(@".\OTR_CONFIG.xml", resources.defaultConfig);

            AppDomain.CurrentDomain.SetData("APP_CONFIG_FILE", @".\OTR_CONFIG.xml");

            ApplicationConfiguration.Initialize();

            MainWindow mainWind = new MainWindow();

            Application.Run(mainWind);
        }
    }
}
