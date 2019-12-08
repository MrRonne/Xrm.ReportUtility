using Xrm.ReportUtility.Infrastructure.Transformers.Abstract;
using Xrm.ReportUtility.Interfaces;
using Xrm.ReportUtility.Models;
using Xrm.ReportUtility.Services;

namespace Xrm.ReportUtility.Infrastructure.Transformers
{
    public class WithTotalWeightTransformer : DataTransformerBase
    {
        public WithTotalWeightTransformer(IDataTransformer dataTransformer) : base(dataTransformer) { }

        public override Report TransformData(DataRow[] data)
        {
            var report = DataTransformer.TransformData(data);

            report.Table.Attributes.AddLast(TranslationService.TotalWeight);

            for (int i = 0; i < report.Table.Rows.Count; i++)
            {
                var dataRow = data[i];
                var tableRow = report.Table.Rows[i];
                tableRow.Add(TranslationService.TotalWeight, dataRow.Weight * dataRow.Count);
            }

            return report;
        }
    }
}