using System;
using System.Collections.Generic;
using System.Text;

namespace FileMonitor.Infrasctructure.Abstract
{
    /// <summary>
    /// Save file Interface
    /// </summary>
    public interface IFileSaver
    {
        /// <summary>
        /// Save text to file
        /// </summary>
        /// <param name="resultText"></param>
        void SaveResultToFile(string resultText);
    }
}
