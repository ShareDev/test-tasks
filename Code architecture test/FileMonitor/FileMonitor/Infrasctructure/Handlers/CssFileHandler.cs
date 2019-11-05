using FileMonitor.Domain;
using FileMonitor.Infrasctructure.Abstract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileMonitor.Infrasctructure.Handlers
{
    /// <summary>
    /// Handler for CSS files
    /// </summary>
    public class CssFileHandler : AbstractHandler
    {
        private FileWatcher _fileWatcher;

        public CssFileHandler(FileWatcher fileWatcher) : base(fileWatcher)
        {
            _fileWatcher = fileWatcher;
            _fileWatcher.CssFileCreated += OnCreated;
        }
    }
}
