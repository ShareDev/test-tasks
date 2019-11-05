using FileMonitor.Domain;
using FileMonitor.Infrasctructure.Abstract;
using HtmlAgilityPack;
using System;
using System.IO;
using System.Linq;

namespace FileMonitor.Infrasctructure.Operations.Html
{
    /// <summary>
    /// HTML paragraph counter
    /// </summary>
    public class HtmlParagraphCounter : IOperation
    {
        public string OperationName { get; set; }

        public HtmlParagraphCounter(string operationName)
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
            var tags = html.DocumentNode.Descendants("p");
            result = tags.Count();
        }
    }
}
