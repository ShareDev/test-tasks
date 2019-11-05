using FileMonitor.Domain;
using FileMonitor.Infrasctructure.Abstract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileMonitor.Infrasctructure.Handlers
{
    /// <summary>
    /// Handlers for others files
    /// </summary>
    public class OtherFilesHandler : AbstractHandler
    {
        private FileWatcher _fileWatcher;

        public OtherFilesHandler(FileWatcher fileWatcher) : base(fileWatcher)
        {
            _fileWatcher = fileWatcher;
            _fileWatcher.OtherFileCreated += OnCreated;
        }
    }
}
