using System.IO;
using System;
using FileWatcherApp.FileLoader;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace FileWatcherApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DirectoryMonitor _monitor;
        private PluginSystem _pluginSystem;
        public MainWindow()
        {
            InitializeComponent();

            _pluginSystem = new PluginSystem(); //fayl yukleyicileri qeydiyyatdan kecirin
            _pluginSystem.RegisterLoader(".xml", new XMLFileLoader());
            _pluginSystem.RegisterLoader(".csv", new CSVFileLoader());
            _pluginSystem.RegisterLoader(".txt", new TXTFileLoader());

            _monitor = new DirectoryMonitor(@"C:\monitor", 5000);
            StartMonitoring();
        }
        private async void StartMonitoring()
        {
            await _monitor.StartMonitoringAsync(OnFileFound);
        }
        private void OnFileFound(string filePath)
        {
            Task.Run(() =>
            {
                string extension = System.IO.Path.GetExtension(filePath).ToLower();
                var loader = _pluginSystem.GetLoader(extension);
                if (loader != null)
                {
                    var data = loader.Load(filePath);

                    Application.Current.Dispatcher.Invoke(() =>
                    {

                        FileListBox.Items.Add($"{filePath}:{data}");
                    });
                }
            });
        }

    }
    
}