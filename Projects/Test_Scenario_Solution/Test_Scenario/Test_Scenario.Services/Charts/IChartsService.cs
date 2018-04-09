using Test_Scenario.Core.Helpers;

namespace Test_Scenario.Services.Charts
{
    public interface IChartsService<T>
    {
        MultiResult<T> GetChartsOriginalPropertyValue(string condition);
        MultiResult<T> GetChartsIndexedLTFV(string condition);
    }
}
