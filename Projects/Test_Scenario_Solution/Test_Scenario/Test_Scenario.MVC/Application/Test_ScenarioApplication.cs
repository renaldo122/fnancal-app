using System;
using System.Configuration;
using Test_Scenario.Core.Data;
using Test_Scenario.Services.Charts;
using Test_Scenario.Services.Function;
using Test_Scenario.Services.Repositories;
using Test_Scenario.Services.SQLRepos;
using Unity;
using Unity.Injection;

namespace Test_Scenario.MVC
{
    class Test_ScenarioApplication
    {
        private static bool _isInit;
        public static void InitApplication(IUnityContainer container)
        {
            // Initialize Connection String
            var cstr = ConfigurationManager.ConnectionStrings["DbConnectionString"].ConnectionString;
            if (!_isInit)
            {
                if (container == null)
                {
                    throw new ApplicationException(
                        "Can not init application. Please provide a valid object container!!!");
                }

                container
                    .RegisterType<IChartsService<ChartsTable>, ChartsService>()
                    .RegisterType<RepositoryCharts<ChartsTable>, SqlRepositoryCharts>(new InjectionConstructor(cstr))
                    .RegisterType<IAggregateFunctionService<Aggregated>, AggregateFunctionService>()
                    .RegisterType<RepositoryAggregate<Aggregated>, SqlRepositoryAggregate>(
                        new InjectionConstructor(cstr))
                    ;
                _isInit = true;
            }
        }

    }
}
