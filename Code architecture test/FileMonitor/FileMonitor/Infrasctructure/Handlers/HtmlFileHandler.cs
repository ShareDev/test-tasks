using FileMonitor.Domain;
using FileMonitor.Infrasctructure.Abstract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileMonitor.Infrasctructure.Handlers
{
    /// <summary>
    /// Handler for html files
    /// </summary>
    public class HtmlFileHandler : AbstractHandler
    {
        private FileWatcher _fileWatcher;

        public HtmlFileHandler(FileWatcher fileWatcher) : base(fileWatcher)
        {
            _fileWatcher = fileWatcher;
            _fileWatcher.HtmlFileCreated += OnCreated;
        }
    }
}
