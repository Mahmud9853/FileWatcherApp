﻿using FileWatcherApp.FileInterface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileWatcherApp.FileLoader
{
    public class TXTFileLoader : IFileLoader
    {
        public object Load(string filePath)
        {
            return File.ReadAllText(filePath);
        }
    }
}
