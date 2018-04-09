using System.Collections.Generic;

namespace Test_Scenario.Services.Repositories
{
    public abstract class RepositoryCharts<T> : RepositoryBase<T>
    {
        public abstract List<T> GetChartsIndexedLTFV(string condition);
    }
}
