using Test_Scenario.Core.Data;
using Test_Scenario.Core.Helpers;
using Test_Scenario.Services.Repositories;

namespace Test_Scenario.Services.Function
{
    public class AggregateFunctionService : IAggregateFunctionService<Aggregated>
    {
        private readonly RepositoryAggregate<Aggregated> _repository;

        public AggregateFunctionService(RepositoryAggregate<Aggregated> repository)
        {
            _repository = repository;
        }

        public MultiResult<Aggregated> GetAggregate(string condition)
        {
            return new MultiResult<Aggregated>(_repository.GetAll(condition), false, "");
        }

    }
}
