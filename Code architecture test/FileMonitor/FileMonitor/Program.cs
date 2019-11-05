using System;
using System.IO;
using FileMonitor.Infrasctructure.Handlers;
using FileMonitor.Infrasctructure.Monitors;
using FileMonitor.Infrasctructure.Operations.Css;
using FileMonitor.Infrasctructure.Operations.Html;
using FileMonitor.Infrasctructure.Operations.Others;

namespace FileMonitor
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = AppDomain.CurrentDomain.BaseDirectory;
            var fileWatcher = new FileWatcher(Path.Combine(path, "AppFiles"));

            var commonHandler = new OtherFilesHandler(fileWatcher);
            var cssHandler = new CssFileHandler(fileWatcher);
            var htmlHandler = new HtmlFileHandler(fileWatcher);
            
            var htmlDivCounterObserver = new HtmlFileMonitor(new HtmlDivCounter("div count"));
            var htmlParagraphCounterObserver = new HtmlFileMonitor(new HtmlParagraphCounter("paragraph count"));
            htmlDivCounterObserver.Subscribe(htmlHandler);
            htmlParagraphCounterObserver.Subscribe(htmlHandler);

            var cssBracketsBalancerObserver = new CssFileMonitor(new CssBracketsBalanceChecker("check css brackets is balanced"));
            cssBracketsBalancerObserver.Subscribe(cssHandler);

            var txtFilesObserver = new OtherFilesMonitor(new PunctuationCounter("Count of punctuation symbols"));
            txtFilesObserver.Subscribe(commonHandler);

            Console.WriteLine("Press 'q' to quit.");
            while (Console.Read() != 'q') ;
        }
    }
}
