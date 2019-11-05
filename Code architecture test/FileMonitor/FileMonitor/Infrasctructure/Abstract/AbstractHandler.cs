using FileMonitor.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileMonitor.Infrasctructure.Abstract
{
    /// <summary>
    /// Abstract files handler
    /// </summary>
    public abstract class AbstractHandler : IObservable<Document>
    {
        private List<IObserver<Document>> _observers;
        private List<Document> _documents;
        private readonly FileWatcher _fileWatcher;

        public AbstractHandler(FileWatcher fileWatcher)
        {
            _observers = new List<IObserver<Document>>();
            _documents = new List<Document>();

            _fileWatcher = fileWatcher;
        }

        /// <summary>
        /// File created event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void OnCreated(object sender, EventArgs e)
        {
            var args = e as FileSystemEventArgs;
            var extension = Path.GetExtension(args.FullPath);
            var document = new Document(args.Name, extension, args.FullPath);

            BeginOperation(document, _observers);
        }

        private void BeginOperation(Document document, List<IObserver<Document>> observers)
        {
            _documents.Add(document);

            foreach (var item in observers)
            {
                item.OnNext(document);
            }
        }

        /// <summary>
        /// Subscrive observer to the event
        /// </summary>
        /// <param name="observer"></param>
        /// <returns></returns>
        public IDisposable Subscribe(IObserver<Document> observer)
        {
            if (!_observers.Contains(observer))
            {
                _observers.Add(observer);

                foreach (var item in _documents)
                {
                    observer.OnNext(item);
                }
            }

            return new Unsubscriber<Document>(_observers, observer);
        }
    }
}
