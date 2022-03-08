using System.Configuration;
using System.Diagnostics;
using System.Globalization;

namespace OpenTimerResolution
{
    internal static class Program
    {
        internal static bool startMinimized = Environment.GetCommandLineArgs().Contains("-minimized");
        internal static bool silentInstall = Environment.GetCommandLineArgs().Contains("-silentInstall");

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>


        [STAThread]
        static void Main()
        {
            CultureInfo ci = new("en-US");
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;

            if (Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName).Length > 1)
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

            MainWindow mainWind = new();

            Application.Run(mainWind);
        }
    }
}
