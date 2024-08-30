using FileWatcherApp.FileInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileWatcherApp
{
    public class PluginSystem
    {
        private Dictionary<string, IFileLoader> _loaders = new Dictionary<string, IFileLoader>();

        public void RegisterLoader(string fileExtension, IFileLoader loader) 
        {
            _loaders[fileExtension] = loader;
        }
        public IFileLoader GetLoader(string fileExtension)
        {
            return _loaders.ContainsKey(fileExtension) ? _loaders[fileExtension] : null;
        }
    }
}
