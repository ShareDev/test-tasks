using FileMonitor.Domain;

namespace FileMonitor.Infrasctructure.Abstract
{
    public interface IOperation
    {
        /// <summary>
        /// Operation name
        /// </summary>
        public string OperationName { get; set; }

        /// <summary>
        /// Starts operation
        /// </summary>
        /// <param name="document"></param>
        /// <param name="result"></param>
        void Run(Document document, out object result);
    }
}