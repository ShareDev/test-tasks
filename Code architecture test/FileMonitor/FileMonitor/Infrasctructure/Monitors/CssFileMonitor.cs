using FileMonitor.Domain;
using FileMonitor.Infrasctructure.Abstract;
using FileMonitor.Infrasctructure.Handlers;
using System;
using System.Collections.Generic;

namespace FileMonitor.Infrasctructure.Monitors
{
    /// <summary>
    /// Monitors the css files
    /// </summary>
    public class CssFileMonitor : AbstractMonitor
    {
        private IOperation _operation;

        public CssFileMonitor(IOperation operation) : base(operation)
        {
            _operation = operation;
        }
    }
}
