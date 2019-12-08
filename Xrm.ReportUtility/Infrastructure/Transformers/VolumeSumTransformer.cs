using System.Linq;
using Xrm.ReportUtility.Infrastructure.Transformers.Abstract;
using Xrm.ReportUtility.Interfaces;
using Xrm.ReportUtility.Models;

namespace Xrm.ReportUtility.Infrastructure.Transformers
{
    public class VolumeSumTransformer : DataTransformerBase
    {
        public VolumeSumTransformer(IDataTransformer dataTransformer) : base(dataTransformer) { }

        public override Report TransformData(DataRow[] data)
        {
            var report = DataTransformer.TransformData(data);

            report.FinalRows.Add(new ReportRow
            {
                Name = "Суммарный объём",
                Value = data.Sum(i => i.Volume * i.Count)
            });

            return report;
        }
    }
}
