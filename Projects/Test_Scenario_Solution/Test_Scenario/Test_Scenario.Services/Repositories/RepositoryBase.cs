using System.Collections.Generic;

namespace Test_Scenario.Services.Repositories
{
    public abstract class RepositoryBase<T>
    {
        public abstract T GetById(object id);
        public abstract List<T> GetAll(string condition);
    }
}
