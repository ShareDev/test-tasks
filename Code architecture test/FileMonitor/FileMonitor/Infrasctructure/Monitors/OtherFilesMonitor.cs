using FileMonitor.Domain;
using FileMonitor.Infrasctructure.Abstract;
using FileMonitor.Infrasctructure.Handlers;
using System;
using System.Collections.Generic;

namespace FileMonitor.Infrasctructure.Monitors
{
    /// <summary>
    /// Monitor for others files
    /// </summary>
    public class OtherFilesMonitor : AbstractMonitor
    {
        private IOperation _operation;

        public OtherFilesMonitor(IOperation operation) : base(operation)
        {
            _operation = operation;
        }
    }
}
