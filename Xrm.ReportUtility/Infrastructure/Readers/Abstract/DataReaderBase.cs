using System.IO;
using Xrm.ReportUtility.Interfaces;
using Xrm.ReportUtility.Models;

namespace Xrm.ReportUtility.Infrastructure.Readers.Abstract
{
    public abstract class DataReaderBase : IDataReader
    {
        public DataRow[] GetData(string fileName)
        {
            var text = File.ReadAllText(fileName);
            return ParseData(text);
        }

        protected abstract DataRow[] ParseData(string text);
    }
}