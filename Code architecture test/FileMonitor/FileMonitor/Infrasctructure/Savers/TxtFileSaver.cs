using FileMonitor.Infrasctructure.Abstract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileMonitor.Infrasctructure.Savers
{
    /// <summary>
    /// Save file as TXT
    /// </summary>
    public class TxtFileSaver : IFileSaver
    {
        public string FullPath => $"{_path}/{_fileName}";

        private readonly string _path;
        private readonly string _fileName;

        public TxtFileSaver(string path, string fileName)
        {
            _path = path;
            _fileName = fileName;
        }

        public void SaveResultToFile(string resultText)
        {
            File.AppendAllText(@$"{FullPath}.txt", resultText + Environment.NewLine);
        }
    }
}
