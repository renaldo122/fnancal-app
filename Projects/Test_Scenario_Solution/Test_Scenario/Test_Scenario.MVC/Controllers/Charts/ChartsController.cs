using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test_Scenario.Core.Data;
using Test_Scenario.MVC.HtmlHelpers;
using Test_Scenario.MVC.ViewModels;
using Test_Scenario.Services.Charts;

namespace Test_Scenario.MVC.Controllers
{
    public class ChartsController : Controller
    {
        #region Fields
        private IChartsService<ChartsTable> _chartsService;
        #endregion

        #region Constructors
        public ChartsController(IChartsService<ChartsTable> chartsService)
        {
            _chartsService = chartsService;
        }
        #endregion

        #region Action
        public ActionResult Index()
        {
            ChartsViewModel model = new ChartsViewModel
            {
                ChartFirst = new List<ChartsFirstViewModel>(),
                ChartSecond = new List<ChartsFirstViewModel>(),
            };
            var resultChartFirst = _chartsService.GetChartsOriginalPropertyValue(null);
            var resultChartSecond = _chartsService.GetChartsIndexedLTFV(null);
            foreach (var item in resultChartFirst.ReturnValue)
            {
                var itemcharts = new ChartsFirstViewModel
                {
                    TotalCurrentAmount = item.TotalCurrentAmount,
                    Year=item.Year,
                    IndexedDTI=item.IndexedDTI,
                    IndexedLTI=item.IndexedLTI,
                    DelinquencyStatus=item.DelinquencyStatus,
                    OriginalFixedRateTerm=item.OriginalFixedRateTerm
                };
                model.ChartFirst.Add(itemcharts);
            }
            foreach (var item in resultChartSecond.ReturnValue)
            {
                var itemcharts = new ChartsFirstViewModel
                {
                    IndexedLTFV = item.IndexedLTFV,
                    Year = item.Year,
                    IndexedDTI = item.IndexedDTI,
                    IndexedLTI = item.IndexedLTI,
                    DelinquencyStatus = item.DelinquencyStatus,
                    OriginalFixedRateTerm = item.OriginalFixedRateTerm
                };
                model.ChartSecond.Add(itemcharts);
            }
            return View(model);
        }
        #endregion
    }
}