using FileWatcherApp.FileInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace FileWatcherApp.FileLoader
{
    public class XMLFileLoader : IFileLoader
    {
        public object Load(string filePath)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);
            return doc.InnerXml; //XML Faylinin mezmunun qaytarir
        }
    }
}
