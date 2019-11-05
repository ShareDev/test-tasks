using System;
using System.IO;
using System.Linq;
using FileMonitor.Domain;
using FileMonitor.Infrasctructure.Abstract;
using HtmlAgilityPack;

namespace FileMonitor.Infrasctructure.Operations.Html
{
    /// <summary>
    /// HTML div counter
    /// </summary>
    public class HtmlDivCounter : IOperation
    {
        public string OperationName { get; set; }

        public HtmlDivCounter(string operationName)
        {
            if (string.IsNullOrEmpty(operationName))
            {
                throw new ArgumentNullException("The observer must be assigned a name.");
            }

            OperationName = operationName;
        }

        public void Run(Document document, out object result)
        {
            HtmlDocument html = new HtmlDocument();
            html.LoadHtml(File.ReadAllText(document.FullPath));
            var tags = html.DocumentNode.Descendants("div");
            result = tags.Count();
        }
    }
}