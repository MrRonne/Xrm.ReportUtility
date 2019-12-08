using Xrm.ReportUtility.Models;

namespace Xrm.ReportUtility.Interfaces
{
    public interface IDataReader
    {
        DataRow[] GetData(string fileName);
    }
}