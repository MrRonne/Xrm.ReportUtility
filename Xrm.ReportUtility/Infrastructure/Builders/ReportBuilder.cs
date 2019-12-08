using System;
using Xrm.ReportUtility.Infrastructure.Transformers;
using Xrm.ReportUtility.Interfaces;
using Xrm.ReportUtility.Models;

namespace Xrm.ReportUtility.Infrastructure.Builders
{
    public class ReportBuilder : IReportService
    {
        private IDataTransformer _dataTransformer;

        public readonly DataRow[] Data;

        public ReportBuilder(DataRow[] data, ReportConfig config)
        {
            Data = data;
            _dataTransformer = new EmptyTransformer();

            if (config.Data)
            {
                _dataTransformer = new DataTransformer(_dataTransformer);
                if (config.WithIndex)
                    _dataTransformer = new WithIndexTransformer(_dataTransformer);
                if (config.WithTotalVolume)
                    _dataTransformer = new WithTotalVolumeTransformer(_dataTransformer);
                if (config.WithTotalWeight)
                    _dataTransformer = new WithTotalWeightTransformer(_dataTransformer);
                if (config.WithoutVolume)
                    _dataTransformer = new WithoutVolumeTransformer(_dataTransformer);
                if (config.WithoutWeight)
                    _dataTransformer = new WithoutWeightTransformer(_dataTransformer);
                if (config.WithoutCost)
                    _dataTransformer = new WithoutCostTransformer(_dataTransformer);
                if (config.WithoutCount)
                    _dataTransformer = new WithoutCountTransformer(_dataTransformer);
            }
            else if (config.WithIndex || config.WithTotalVolume || config.WithTotalWeight ||
                     config.WithoutVolume || config.WithoutWeight || config.WithoutCost || config.WithoutCount)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("warning");
                Console.ResetColor();
            }

            if (config.VolumeSum)
                _dataTransformer = new VolumeSumTransformer(_dataTransformer);
            if (config.WeightSum)
                _dataTransformer = new WeightSumTransformer(_dataTransformer);
            if (config.CostSum)
                _dataTransformer = new CostSumTransformer(_dataTransformer);
            if (config.CountSum)
                _dataTransformer = new CountSumTransformer(_dataTransformer);
        }

        public Report CreateReport() => _dataTransformer.TransformData(Data);
    }
}