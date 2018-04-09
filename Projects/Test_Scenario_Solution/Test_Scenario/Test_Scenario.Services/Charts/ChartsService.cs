using Test_Scenario.Core.Data;
using Test_Scenario.Core.Helpers;
using Test_Scenario.Services.Charts;
using Test_Scenario.Services.Repositories;

namespace Test_Scenario.Services.Function
{
    public class ChartsService : IChartsService<ChartsTable>
    {
        private readonly RepositoryCharts<ChartsTable> _repository;

        public ChartsService(RepositoryCharts<ChartsTable> repository)
        {
            _repository = repository;
        }

        public MultiResult<ChartsTable> GetChartsOriginalPropertyValue(string condition)
        {
            return new MultiResult<ChartsTable>(_repository.GetAll(condition), false, "");
        }
        public MultiResult<ChartsTable> GetChartsIndexedLTFV(string condition)
        {
            return new MultiResult<ChartsTable>(_repository.GetChartsIndexedLTFV(condition), false, "");
        }

    }
}
