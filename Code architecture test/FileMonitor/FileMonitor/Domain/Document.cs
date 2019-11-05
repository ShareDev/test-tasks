using System;
using System.IO;

namespace FileMonitor.Domain
{
    public struct Document
    {
        /// <summary>
        /// Document name
        /// </summary>
        private string _name;

        /// <summary>
        /// Document extension
        /// </summary>
        private string _extension;

        /// <summary>
        /// Document full path
        /// </summary>
        private string _fullPath;

        public Document(string name, string extension, string fullPath)
        {
            _name = name;
            _extension = extension;
            _fullPath = fullPath;
        }

        public string Name => _name;
        public string Extension => _extension;
        public string FullPath => _fullPath;
        public string Text => File.ReadAllText(_fullPath);
    }
}
