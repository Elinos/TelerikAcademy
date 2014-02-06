using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using AvalonDock;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using System.ComponentModel;
using System.Windows.Threading;
using System.Threading;

namespace FilesShelf.App
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Application.Current.DispatcherUnhandledException += new
            DispatcherUnhandledExceptionEventHandler(
            AppDispatcherUnhandledException);
            base.OnStartup(e);
        }
        void AppDispatcherUnhandledException(object sender,
        DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.Message, "An error occured", MessageBoxButton.OK, MessageBoxImage.Error);
            e.Handled = true;
        }
    }
}
