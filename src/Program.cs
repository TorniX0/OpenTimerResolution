using System.Configuration;

namespace OpenTimerResolution
{
    internal static class Program
    {
        internal static bool startMinimized = Environment.GetCommandLineArgs().Any(t => t.Equals("-minimized"));
        internal static bool silentInstall = Environment.GetCommandLineArgs().Any(t => t.Equals("-silentInstall"));

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

            if (silentInstall)
                startMinimized = true;

            if (!File.Exists(ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None).FilePath))
                File.WriteAllText(ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None).FilePath, resources.defaultConfig);


            ApplicationConfiguration.Initialize();

            MainWindow mainWind = new MainWindow();

            Application.Run(mainWind);
        }
    }
}
