using Xrm.ReportUtility.Infrastructure.Transformers.Abstract;
using Xrm.ReportUtility.Interfaces;
using Xrm.ReportUtility.Models;
using Xrm.ReportUtility.Services;

namespace Xrm.ReportUtility.Infrastructure.Transformers
{
    public class WithTotalVolumeTransformer : DataTransformerBase
    {
        public WithTotalVolumeTransformer(IDataTransformer dataTransformer) : base(dataTransformer) { }

        public override Report TransformData(DataRow[] data)
        {
            var report = DataTransformer.TransformData(data);

            report.Table.Attributes.AddLast(TranslationService.TotalVolume);

            for (int i = 0; i < report.Table.Rows.Count; i++)
            {
                var dataRow = data[i];
                var tableRow = report.Table.Rows[i];
                tableRow.Add(TranslationService.TotalVolume, dataRow.Volume * dataRow.Count);
            }

            return report;
        }
    }
}