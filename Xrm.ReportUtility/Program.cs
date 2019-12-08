using System;
using Xrm.ReportUtility.Infrastructure.Builders;

namespace Xrm.ReportUtility
{
    public static class Program
    {
        // "Files/table.txt" -data -weightSum -costSum -withIndex -withoutWeight -withTotalVolume
        public static void Main(string[] args)
        {
            var report = new ConfigBuilder(args).ParseConfig().ReadData().CreateReport();
            Console.WriteLine(report);
            Console.WriteLine("Press enter...");
            Console.ReadLine();
        }
    }
}