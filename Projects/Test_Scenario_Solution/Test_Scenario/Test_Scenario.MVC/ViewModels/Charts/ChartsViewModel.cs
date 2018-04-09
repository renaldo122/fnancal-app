using Chart.Mvc.ComplexChart;
using System.Collections.Generic;

namespace Test_Scenario.MVC.ViewModels
{
    public class ChartsViewModel
    {
        public List<ChartsFirstViewModel> ChartFirst { get; set; }
        public List<ChartsFirstViewModel> ChartSecond { get; set; }
    }

    public class ChartsFirstViewModel
    {
        public float TotalCurrentAmount { get; set; }
        public string Year { get; set; }
        public float IndexedDTI { get; set; }
        public float IndexedLTI { get; set; }
        public float DelinquencyStatus { get; set; }
        public float OriginalFixedRateTerm { get; set; }
        public float IndexedLTFV { get; set; }
        
    }
  
}