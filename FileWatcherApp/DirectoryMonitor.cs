using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileWatcherApp
{
    public class DirectoryMonitor
    {
        private string _directoryPath;
        private int _pollingInterval;

        public DirectoryMonitor(string directoryPath, int pollingInterval)
        {
            _directoryPath = directoryPath;
            _pollingInterval = pollingInterval;
        }
        public async Task StartMonitoringAsync(Action<string> onFileFound) 
        {
            while (true)
            {
                var files = Directory.GetFiles(_directoryPath);
                foreach (var file in files)
                {
                    onFileFound(file);

                }
                await Task.Delay(_pollingInterval);
            }
        }
    }
}
