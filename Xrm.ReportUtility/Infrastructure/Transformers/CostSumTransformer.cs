using System.Linq;
using Xrm.ReportUtility.Infrastructure.Transformers.Abstract;
using Xrm.ReportUtility.Interfaces;
using Xrm.ReportUtility.Models;

namespace Xrm.ReportUtility.Infrastructure.Transformers
{
    public class CostSumTransformer : DataTransformerBase
    {
        public CostSumTransformer(IDataTransformer dataTransformer) : base(dataTransformer) { }

        public override Report TransformData(DataRow[] data)
        {
            var report = DataTransformer.TransformData(data);

            report.FinalRows.Add(new ReportRow
            {
                Name = "Суммарная стоимость",
                Value = data.Sum(i => i.Cost * i.Count)
            });

            return report;
        }
    }
}
