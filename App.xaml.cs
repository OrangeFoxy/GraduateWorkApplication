using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace GraduateWorkApplication
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        private static System.Threading.Mutex instanceMutex;
        private void OnStartup(object sender, StartupEventArgs e)
        {
            bool createdNew;
            string mutName = "MainWindow111";
            instanceMutex = new System.Threading.Mutex(true, mutName, out createdNew);
            if (!createdNew)
            {
                MessageBox.Show("Приложение уже запущено");
                this.Shutdown();
            }
        }
        private void OnExit(object sender, ExitEventArgs e)
        {
            if (instanceMutex != null)
                instanceMutex.ReleaseMutex();
        }
    }
}