namespace Test_Scenario.Core.Data
{
    public class Aggregated
    {
        public float OriginalPrincipalBalance { get; set; }
        public float DTI { get; set; }
        public float LTI { get; set; }
        public float TotalIncome { get; set; }
        public float IndexedDTI { get; set; }
        public float IndexedLTI { get; set; }
        public float IndexedTotalIncome { get; set; }
        public float CurrentInterestRate { get; set; }
        public float OriginalLTV { get; set; }
        public float OriginalLTFV { get; set; }
        public float OriginalForeclosureValue { get; set; }
        public float IndexedLTFV { get; set; }
    }
}
