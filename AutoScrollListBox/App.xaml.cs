using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Windows;

namespace Innario
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        private void Application_Startup(object sender, StartupEventArgs e)
        {

            Process proc = Process.GetCurrentProcess();
            int count = Process.GetProcesses().Where(p =>
                             p.ProcessName == proc.ProcessName).Count();
            if (count > 1)
            {
                MessageBox.Show("Already an instance is running...");
                App.Current.Shutdown();
            }
            else
            {
                // Create the startup window
                MainWindow wnd = new MainWindow();
                // Show the window
                wnd.Show();
            }
        }
    }
}
