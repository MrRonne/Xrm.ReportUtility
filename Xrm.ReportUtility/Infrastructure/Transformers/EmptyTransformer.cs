using Xrm.ReportUtility.Interfaces;
using Xrm.ReportUtility.Models;

namespace Xrm.ReportUtility.Infrastructure.Transformers
{
    class EmptyTransformer : IDataTransformer
    {
        public Report TransformData(DataRow[] data)
        {
            return new Report();
        }
    }
}