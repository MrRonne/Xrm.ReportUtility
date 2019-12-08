using System.IO;
using System.Linq;
using CsvHelper;
using Xrm.ReportUtility.Infrastructure.Readers.Abstract;
using Xrm.ReportUtility.Models;

namespace Xrm.ReportUtility.Infrastructure.Readers
{
    public class CsvDataReader : DataReaderBase
    {
        protected override DataRow[] ParseData(string text)
        {
            using (TextReader textReader = new StringReader(text))
            {
                var csvReader = new CsvReader(textReader);

                csvReader.Configuration.Delimiter = ";";
                csvReader.Configuration.RegisterClassMap<RowDataMapper>();

                return csvReader.GetRecords<DataRow>().ToArray();
            }
        }
    }
}