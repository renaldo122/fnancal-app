using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Test_Scenario.MVC.ViewModels
{
    public class AggregatedViewModel
    {
        [Display(Name = "Original Principal Balance")]
        public float OriginalPrincipalBalance { get; set; }

        [Display(Name = "DTI")]
        public float DTI { get; set; }

        [Display(Name = "LTI")]
        public float LTI { get; set; }

        [Display(Name = "Indexed DTI")]
        public float TotalIncome { get; set; }

        [Display(Name = "Indexed DTI")]
        public float IndexedDTI { get; set; }

        [Display(Name = "Indexed LTI")]
        public float IndexedLTI { get; set; }

        [Display(Name = "Indexed Total Income")]
        public float IndexedTotalIncome { get; set; }

        [Display(Name = "Current Interest Rate")]
        public float CurrentInterestRate { get; set; }

        [Display(Name = "Original LTV")]
        public float OriginalLTV { get; set; }

        [Display(Name = "Original LTFV")]
        public float OriginalLTFV { get; set; }

        [Display(Name = "Original Foreclosure Value")]
        public float OriginalForeclosureValue { get; set; }

        [Display(Name = "Indexed LTFV")]
        public float IndexedLTFV { get; set; }

        public SearchViewModel  Search { get; set; }
    }

    public class SearchViewModel
    {

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Report Date")]
        public DateTime? ReportDate { get; set; }
        public List<string> ReportDateOperator { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Loan Origination Date")]
        public DateTime? LoanOriginationDate { get; set; }
        public List<string> LoanOriginationDateOperator { get; set; }


        [Display(Name = "LTI")]
        public string LTI { get; set; }
        public List<string> LTIOperator { get; set; }

        

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Borrower BirthDate")]
        public DateTime? BorrowerBirthDate { get; set; }
        public List<string> BorrowerBirthDateOperator { get; set; }


        [Display(Name = "Employment Status")]
        public string EmploymentStatus { get; set; }
        public List<string> EmploymentStatusOperator { get; set; }


        [Display(Name = "Indexed DTI")]
        public string IndexedDTI { get; set; }
        public List<string> IndexedDTIOperator { get; set; }



        [Display(Name = "Original LTV")]
        public string OriginalLTV { get; set; }
        public List<string> OriginalLTVOperator { get; set; }


        [Display(Name = "Indexed LTFV")]
        public string IndexedLTFV { get; set; }
        public List<string> IndexedLTFVOperator { get; set; }

    }

}