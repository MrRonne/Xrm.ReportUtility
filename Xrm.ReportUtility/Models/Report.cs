using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xrm.ReportUtility.Models
{
    public class Report
    {
        public ReportTable Table;
        public List<ReportRow> FinalRows;

        public Report()
        {
            Table = new ReportTable();
            FinalRows = new List<ReportRow>();
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            if (Table.Attributes.Any())
                result.Append(Table);

            if (FinalRows.Any())
            {
                result.AppendLine("Итого:");
                foreach (var reportRow in FinalRows)
                {
                    result.AppendFormat("  {0,-20}\t{1}", reportRow.Name, reportRow.Value);
                    result.AppendLine();
                }
            }

            return result.ToString();
        }
    }
}
