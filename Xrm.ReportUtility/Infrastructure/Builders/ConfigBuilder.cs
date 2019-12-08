using System;
using System.Linq;
using Xrm.ReportUtility.Models;

namespace Xrm.ReportUtility.Infrastructure.Builders
{
    public class ConfigBuilder
    {
        public readonly string[] Args;

        public ConfigBuilder(string[] args)
        {
            Args = args;
        }

        public ReadBuilder ParseConfig()
        {
            var config = new ReportConfig
            {
                Data = Args.Contains("-data"),

                WithIndex = Args.Contains("-withIndex"),
                WithTotalVolume = Args.Contains("-withTotalVolume"),
                WithTotalWeight = Args.Contains("-withTotalWeight"),

                WithoutVolume = Args.Contains("-withoutVolume"),
                WithoutWeight = Args.Contains("-withoutWeight"),
                WithoutCost = Args.Contains("-withoutCost"),
                WithoutCount = Args.Contains("-withoutCount"),

                VolumeSum = Args.Contains("-volumeSum"),
                WeightSum = Args.Contains("-weightSum"),
                CostSum = Args.Contains("-costSum"),
                CountSum = Args.Contains("-countSum")
            }; 
            if (config.VolumeSum || config.WeightSum || config.CostSum || config.CountSum) 
                return new ReadBuilder(Args[0], config);
            throw new ArgumentException("Не указан ни один из обязательных флагов");
        }
    }
}