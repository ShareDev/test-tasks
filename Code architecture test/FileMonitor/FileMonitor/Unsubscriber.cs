using System;
using System.Collections.Generic;

namespace FileMonitor
{
    public class Unsubscriber<Document> : IDisposable
    {
        private List<IObserver<Document>> _observers;
        private IObserver<Document> _observer;

        internal Unsubscriber(List<IObserver<Document>> observers, IObserver<Document> observer)
        {
            _observers = observers;
            _observer = observer;
        }

        public void Dispose()
        {
            if (_observers.Contains(_observer))
                _observers.Remove(_observer);
        }
    }
}
