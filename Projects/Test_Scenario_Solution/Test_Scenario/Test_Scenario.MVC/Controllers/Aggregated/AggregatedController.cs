using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using Test_Scenario.Core.Data;
using Test_Scenario.MVC.ViewModels;
using Test_Scenario.Services.Function;

namespace Test_Scenario.MVC.Controllers
{
    public class AggregatedController : Controller
    {
        #region Fields

        private IAggregateFunctionService<Aggregated> _aggregateFunctionService;

        #endregion

        #region Constructors

        public AggregatedController(IAggregateFunctionService<Aggregated> aggregateFunctionService)
        {
            _aggregateFunctionService = aggregateFunctionService;
        }

        #endregion

        #region Action
        public ActionResult Index()
        {
            AggregatedViewModel model = null;
            string condition = CreateConditionFilter();
            var result = _aggregateFunctionService.GetAggregate(condition);
            foreach (var item in result.ReturnValue)
            {
                model = new AggregatedViewModel
                {
                    CurrentInterestRate = item.CurrentInterestRate,
                    DTI = item.DTI,
                    IndexedDTI = item.IndexedDTI,
                    IndexedLTFV = item.IndexedLTFV,
                    IndexedLTI = item.IndexedLTI,
                    IndexedTotalIncome = item.IndexedTotalIncome,
                    LTI = item.LTI,
                    OriginalForeclosureValue = item.OriginalForeclosureValue,
                    OriginalLTFV = item.OriginalLTFV,
                    OriginalLTV = item.OriginalLTV,
                    OriginalPrincipalBalance = item.OriginalPrincipalBalance,
                    TotalIncome = item.TotalIncome,
                    Search = GetRequestSearchFormData(),
                };
            }
            LoadMetaData();
            
            return View(model);
        }

        public ActionResult Export()
        {
            AggregatedViewModel model = null;
            string condition = CreateConditionFilter();
            var result = _aggregateFunctionService.GetAggregate(condition);
            foreach (var item in result.ReturnValue)
            {
                model = new AggregatedViewModel
                {
                    CurrentInterestRate = item.CurrentInterestRate,
                    DTI = item.DTI,
                    IndexedDTI = item.IndexedDTI,
                    IndexedLTFV = item.IndexedLTFV,
                    IndexedLTI = item.IndexedLTI,
                    IndexedTotalIncome = item.IndexedTotalIncome,
                    LTI = item.LTI,
                    OriginalForeclosureValue = item.OriginalForeclosureValue,
                    OriginalLTFV = item.OriginalLTFV,
                    OriginalLTV = item.OriginalLTV,
                    OriginalPrincipalBalance = item.OriginalPrincipalBalance,
                    TotalIncome = item.TotalIncome,
                    Search = GetRequestSearchFormData(),
                };
            }

            LoadMetaData();
            return new Rotativa.ViewAsPdf(model)
            {
                PageOrientation = Rotativa.Options.Orientation.Landscape,
                PageSize = Rotativa.Options.Size.A4
            };

    }
        #endregion

        #region Methods

        public void LoadMetaData()
        {
            ViewBag.ReportDateOperator = GetOperator(Request.QueryString["OperatorReportDate"]);
            ViewBag.LoanOriginationDateOperator = GetOperator(Request.QueryString["OperatorLoanOriginationDate"]);
            ViewBag.LTIOperator = GetOperator(Request.QueryString["LTIOperator"]);
            ViewBag.BorrowerBirthDateOperator = GetOperator(Request.QueryString["OperatorBorrowerBirthDate"]);
            ViewBag.EmploymentStatusOperator = GetOperator(Request.QueryString["OperatorEmploymentStatus"]);
            ViewBag.IndexedDTIOperator = GetOperator(Request.QueryString["IndexedDTIOperator"]);
            ViewBag.OriginalLTVOperator = GetOperator(Request.QueryString["OriginalLTVOperator"]);
            ViewBag.IndexedLTFVOperator = GetOperator(Request.QueryString["IndexedLTFVOperator"]);
        }

        public virtual List<SelectListItem> GetOperator(string selected)
        {
            var and = false;
            var or = false;
            if (selected == "AND")
                and = true;
            else if (selected == "OR")
                or = true;
           return new List<SelectListItem>{
                new SelectListItem{ Value="AND",Text="AND",Selected = and},
                new SelectListItem{ Value="OR",Text="OR",Selected = or}
            };
        }
        public SearchViewModel GetRequestSearchFormData()
        {
            var searchmodel = new SearchViewModel
            {
                ReportDate =  String.IsNullOrEmpty(Request.QueryString["ReportDate"]) ? null : (DateTime?)Convert.ToDateTime(Request.QueryString["ReportDate"]).Date,
                LoanOriginationDate = String.IsNullOrEmpty(Request.QueryString["LoanOriginationDate"]) ? null : (DateTime?)Convert.ToDateTime(Request.QueryString["LoanOriginationDate"]).Date,
                LTI = String.IsNullOrEmpty(Request.QueryString["LTI"]) ? null : Request.QueryString["LTI"],
                BorrowerBirthDate = String.IsNullOrEmpty(Request.QueryString["BorrowerBirthDate"]) ? null : (DateTime?)Convert.ToDateTime(Request.QueryString["BorrowerBirthDate"]).Date,
                EmploymentStatus = String.IsNullOrEmpty(Request.QueryString["EmploymentStatus"]) ? null : Request.QueryString["EmploymentStatus"],
                IndexedDTI = String.IsNullOrEmpty(Request.QueryString["IndexedDTI"]) ? null : Request.QueryString["IndexedDTI"],
                OriginalLTV = String.IsNullOrEmpty(Request.QueryString["OriginalLTV"]) ? null : Request.QueryString["OriginalLTV"],
                IndexedLTFV = String.IsNullOrEmpty(Request.QueryString["IndexedLTFV"]) ? null : Request.QueryString["IndexedLTFV"],
            };
            return searchmodel;
        }
        public string CreateConditionFilter()
        {
            string filter = "";
            var search = GetRequestSearchFormData();
            if (search != null)
            {
                if (!String.IsNullOrEmpty(search.ReportDate.ToString()))
                    filter += search.ReportDate +""+ search.ReportDateOperator + " " ;
                if (!String.IsNullOrEmpty(search.LoanOriginationDate.ToString()))
                    filter += "M.LoanOriginationDate=" + "" + search.LoanOriginationDate + "" + search.LoanOriginationDateOperator + " ";
                if (!String.IsNullOrEmpty(search.LTI))
                    filter += "I.LTI=" + "" + search.LTI + "" + search.LTIOperator + " ";
                if (!String.IsNullOrEmpty(search.BorrowerBirthDate.ToString()))
                    filter += "I.BorrowerBirthDate=" + "" + search.BorrowerBirthDate + "" + search.BorrowerBirthDateOperator + " ";
                if (!String.IsNullOrEmpty(search.EmploymentStatus))
                    filter += "I.EmploymentStatus=" + "" + search.EmploymentStatus + "" + search.EmploymentStatusOperator + " ";
                if (!String.IsNullOrEmpty(search.IndexedDTI))
                    filter += "I.IndexedDTI=" + "" + search.IndexedDTI + "" + search.IndexedDTIOperator + " ";
                if (!String.IsNullOrEmpty(search.OriginalLTV))
                    filter += "V.OriginalLTV=" + "" + search.OriginalLTV + "";
            }
            if (string.IsNullOrEmpty(filter))
                return null;
            return filter;
        }
        #endregion
    }
}