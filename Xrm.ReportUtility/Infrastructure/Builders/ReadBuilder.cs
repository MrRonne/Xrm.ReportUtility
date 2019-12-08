using System;
using Xrm.ReportUtility.Infrastructure.Readers;
using Xrm.ReportUtility.Interfaces;
using Xrm.ReportUtility.Models;

namespace Xrm.ReportUtility.Infrastructure.Builders
{
    public class ReadBuilder
    {
        private readonly IDataReader _dataReader;
        
        public readonly string FileName;
        public readonly ReportConfig Config;

        public ReadBuilder(string fileName, ReportConfig config)
        {
            FileName = fileName;
            Config = config;

            if (FileName.EndsWith(".txt"))
                _dataReader = new TxtDataReader();
            else if (FileName.EndsWith(".csv"))
                _dataReader = new CsvDataReader();
            else if (FileName.EndsWith(".xlsx"))
                _dataReader = new XlsxDataReader();
            else
                throw new NotSupportedException("this extension not supported");
        }

        public ReportBuilder ReadData()
        {
            var data = _dataReader.GetData(FileName);
            return new ReportBuilder(data, Config);
        }
    }
}