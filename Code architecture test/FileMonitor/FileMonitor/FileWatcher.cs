using System;
using System.IO;

namespace FileMonitor
{
    /// <summary>
    /// Folder monitor 
    /// </summary>
    public class FileWatcher
    {
        private string _path;

        /// <summary>
        /// Eventhandler when other file created
        /// </summary>
        public EventHandler OtherFileCreated { get; internal set; }

        /// <summary>
        /// Eventhandler when html file created
        /// </summary>
        public EventHandler HtmlFileCreated { get; internal set; }

        /// <summary>
        /// Eventhandler when css file created
        /// </summary>
        public EventHandler CssFileCreated { get; internal set; }

        public FileWatcher(string path)
        {
            _path = path;

            FileSystemWatcher watcher = new FileSystemWatcher(_path)
            {
                NotifyFilter = NotifyFilters.LastAccess
                                             | NotifyFilters.LastWrite
                                             | NotifyFilters.FileName
                                             | NotifyFilters.DirectoryName,
                Filter = "*.*",
                EnableRaisingEvents = true
            };

            watcher.Created += (sender, e) => {
                switch (Path.GetExtension(e.FullPath))
                {
                    case ".html":
                        HtmlFileCreated(sender, e);
                        break;
                    case ".css":
                        CssFileCreated(sender, e);
                        break;
                    default:
                        OtherFileCreated(sender, e);
                        break;
                }
            };
        }
    }
}
