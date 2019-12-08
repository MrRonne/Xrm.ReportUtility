using Xrm.ReportUtility.Infrastructure.Transformers.Abstract;
using Xrm.ReportUtility.Interfaces;
using Xrm.ReportUtility.Models;
using Xrm.ReportUtility.Services;

namespace Xrm.ReportUtility.Infrastructure.Transformers
{
    public class WithoutCountTransformer : DataTransformerBase
    {
        public WithoutCountTransformer(IDataTransformer dataTransformer) : base(dataTransformer)
        {
        }

        public override Report TransformData(DataRow[] data)
        {
            var report = DataTransformer.TransformData(data);

            report.Table.Attributes.Remove(TranslationService.Count);

            return report;
        }
    }
}