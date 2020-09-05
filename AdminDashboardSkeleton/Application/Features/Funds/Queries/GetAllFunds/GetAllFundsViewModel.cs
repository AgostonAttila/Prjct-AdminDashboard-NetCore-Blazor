using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Funds.Queries.GetAllFunds
{
    public class GetAllFundsViewModel
    {
        public string ISINNumber { get; set; } = "";
        public string Currency { get; set; } = "";
        public string Name { get; set; } = "";
        public string Management { get; set; } = "";
        public string Focus { get; set; } = "";
        public string Type { get; set; } = "";
        public string PerformanceYTD { get; set; } = "";
        public string Performance1Year { get; set; } = "";
        public string Performance3Year { get; set; } = "";
        public string Performance5Year { get; set; } = "";
        public string PerformanceFromBeggining { get; set; } = "";
        public string PerformanceActualMinus9 { get; set; } = "";
        public string PerformanceActualMinus8 { get; set; } = "";
        public string PerformanceActualMinus7 { get; set; } = "";
        public string PerformanceActualMinus6 { get; set; } = "";
        public string PerformanceActualMinus5 { get; set; } = "";
        public string PerformanceActualMinus4 { get; set; } = "";
        public string PerformanceActualMinus3 { get; set; } = "";
        public string PerformanceActualMinus2 { get; set; } = "";
        public string PerformanceActualMinus1 { get; set; } = "";
        public string PerformanceAverage { get; set; } = "";

        public string VolatilityArrayAsString { get; set; }
        public string SharpRateArrayAsString { get; set; }
        public string BestMonthArrayAsString { get; set; }
        public string WorstMonthArrayAsString { get; set; }
        public string MaxLossArrayAsString { get; set; }
        public string OverFulFilmentArrayAsString { get; set; }

        public string Url { get; set; }

        public string MonthlyPerformanceAsString { get; set; }
    }
}
