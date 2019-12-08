using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xrm.ReportUtility.Models
{
    public class ReportTable
    {
        public LinkedList<string> Attributes;
        public List<Dictionary<string, object>> Rows;

        public ReportTable()
        {
            Attributes = new LinkedList<string>();
            Rows = new List<Dictionary<string, object>>();
        }

        public void AddRow()
        {
            Rows.Add(new Dictionary<string, object>());
        }

        public override string ToString()
        {
            var attributesArray = Attributes.ToArray();
            var result = new StringBuilder();
            var rowTemplate = "";

            for (int i = 0; i < attributesArray.Length; i++)
            {
                var attribute = attributesArray[i];
                result.Append(attribute);
                result.Append('\t');
                rowTemplate += $"{{{i},{attribute.Length}}}\t";
            }
            result.AppendLine();

            foreach (var tableRow in Rows)
            {
                var args = new object[attributesArray.Length];
                for (int i = 0; i < attributesArray.Length; i++)
                {
                    var attribute = attributesArray[i];
                    args[i] = tableRow[attribute];
                }
                result.AppendFormat(rowTemplate, args);
                result.AppendLine();
            }

            return result.ToString();
        }
    }
}