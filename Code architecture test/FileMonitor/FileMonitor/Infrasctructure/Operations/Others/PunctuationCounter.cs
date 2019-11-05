using System;
using System.IO;
using System.Linq;
using FileMonitor.Domain;
using FileMonitor.Infrasctructure.Abstract;

namespace FileMonitor.Infrasctructure.Operations.Others
{
    /// <summary>
    /// Punctuation symbols counter
    /// </summary>
    public class PunctuationCounter : IOperation
    {
        public string OperationName { get; set; }

        public PunctuationCounter(string operationName)
        {
            if (string.IsNullOrEmpty(operationName))
            {
                throw new ArgumentNullException("The observer must be assigned a name.");
            }

            OperationName = operationName;
        }

        public void Run(Document document, out object result)
        {
            result = document.Text.Count(char.IsPunctuation);
        }
    }
}
