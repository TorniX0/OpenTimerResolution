namespace OpenTimerResolution
{
    internal static class Program
    {
        private static string[] args = Environment.GetCommandLineArgs();
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            MainWindow mainWind = new MainWindow();

            try
            {
                for (int i = 1; i < args.Length; i++)
                {
                    string arg = args[i];

                    switch (arg)
                    {
                        case "-minimized":
                            mainWind.WindowState = FormWindowState.Minimized;
                            mainWind.ShowInTaskbar = false;
                            break;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Wrong arguments, or something went wrong.");
            }

            Application.Run(mainWind);
        }
    }
}
