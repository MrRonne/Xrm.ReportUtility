using Xrm.ReportUtility.Infrastructure.Transformers.Abstract;
using Xrm.ReportUtility.Interfaces;
using Xrm.ReportUtility.Models;
using Xrm.ReportUtility.Services;

namespace Xrm.ReportUtility.Infrastructure.Transformers
{
    public class DataTransformer : DataTransformerBase
    {
        public DataTransformer(IDataTransformer dataTransformer) : base(dataTransformer) { }

        public override Report TransformData(DataRow[] data)
        {
            var report = DataTransformer.TransformData(data);

            report.Table.Attributes.AddLast(TranslationService.Name);
            report.Table.Attributes.AddLast(TranslationService.Volume);
            report.Table.Attributes.AddLast(TranslationService.Weight);
            report.Table.Attributes.AddLast(TranslationService.Cost);
            report.Table.Attributes.AddLast(TranslationService.Count);
            /*
            while (report.Table.Rows.Count < data.Length)
                report.Table.AddRow();
                */
            for (int i = 0; i < data.Length; i++)
            {
                var dataRow = data[i];
                report.Table.AddRow();
                var tableRow = report.Table.Rows[i];
                tableRow.Add(TranslationService.Name, dataRow.Name);
                tableRow.Add(TranslationService.Volume, dataRow.Volume);
                tableRow.Add(TranslationService.Weight, dataRow.Weight);
                tableRow.Add(TranslationService.Cost, dataRow.Cost);
                tableRow.Add(TranslationService.Count, dataRow.Count);
            }

            return report;
        }
    }
}
