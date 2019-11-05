using FileMonitor.Domain;
using FileMonitor.Infrasctructure.Savers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileMonitor.Infrasctructure.Abstract
{
    /// <summary>
    /// Abstract files monitor
    /// </summary>
    public abstract class AbstractMonitor : IObserver<Document>
    {
        private IDisposable cancellation;
        private List<Document> docInfos;

        private IOperation _operation;
        private Document _document;
        private object _result;

        public AbstractMonitor(IOperation operation)
        {
            docInfos = new List<Document>();
            _operation = operation;
        }

        public virtual void Subscribe(AbstractHandler provider)
        {
            cancellation = provider.Subscribe(this);
        }

        public virtual void Unsubscribe()
        {
            cancellation.Dispose();
            docInfos.Clear();
        }

        public virtual void OnCompleted()
        {
            var fileSaver = new TxtFileSaver(
                                Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                                "AppFiles/Result"),
                                "result");

            fileSaver.SaveResultToFile($"{_document.Name} - {_operation.OperationName} - {_result}");
        }

        public virtual void OnError(Exception error)
        {
            Console.WriteLine($"======={_operation.OperationName} error!!!!=======");
            Console.WriteLine($"{error.Message}");
        }

        public virtual void OnNext(Document value)
        {
            _operation.Run(value, out object result);
            
            _result = result;
            _document = value;

            this.OnCompleted();
        }
    }
}
