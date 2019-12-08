using Xrm.ReportUtility.Interfaces;
using Xrm.ReportUtility.Models;

namespace Xrm.ReportUtility.Infrastructure.Transformers.Abstract
{
    public abstract class DataTransformerBase : IDataTransformer
    {
        protected readonly IDataTransformer DataTransformer;

        protected DataTransformerBase(IDataTransformer dataTransformer)
        {
            DataTransformer = dataTransformer;
        }

        public abstract Report TransformData(DataRow[] data);
    }
}
