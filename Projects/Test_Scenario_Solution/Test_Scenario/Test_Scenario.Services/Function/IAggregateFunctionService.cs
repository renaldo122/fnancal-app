using Test_Scenario.Core.Helpers;

namespace Test_Scenario.Services.Function
{
    public interface IAggregateFunctionService<T>
    {
        MultiResult<T> GetAggregate(string condition);
    }
}
