using Xrm.ReportUtility.Infrastructure.Transformers.Abstract;
using Xrm.ReportUtility.Interfaces;
using Xrm.ReportUtility.Models;
using Xrm.ReportUtility.Services;

namespace Xrm.ReportUtility.Infrastructure.Transformers
{
    public class WithIndexTransformer : DataTransformerBase
    {
        public WithIndexTransformer(IDataTransformer dataTransformer) : base(dataTransformer) { }

        public override Report TransformData(DataRow[] data)
        {
            var report = DataTransformer.TransformData(data);

            report.Table.Attributes.AddFirst(TranslationService.Index);

            for (int i = 0; i < report.Table.Rows.Count; i++)
            {
                var tableRow = report.Table.Rows[i];
                tableRow.Add(TranslationService.Index, i + 1);
            }

            return report;
        }
    }
}