using FileMonitor.Domain;
using FileMonitor.Infrasctructure.Abstract;
using FileMonitor.Infrasctructure.Handlers;
using System;
using System.Collections.Generic;

namespace FileMonitor.Infrasctructure.Monitors
{
    /// <summary>
    /// Monitor for html files
    /// </summary>
    public class HtmlFileMonitor : AbstractMonitor
    {
        private IOperation _operation;

        public HtmlFileMonitor(IOperation operation) : base(operation)
        {
            _operation = operation;
        }
    }
}
