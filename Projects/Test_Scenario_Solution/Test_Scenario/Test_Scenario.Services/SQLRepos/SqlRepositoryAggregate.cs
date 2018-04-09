using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Test_Scenario.Core.Data;
using Test_Scenario.Services.Repositories;

namespace Test_Scenario.Services.SQLRepos
{
    public class SqlRepositoryAggregate : RepositoryAggregate<Aggregated>
    {
        private string _conn;

        public SqlRepositoryAggregate(string conStr)
        {
            _conn = conStr;
        }
        public override List<Aggregated> GetAll(string condition)
        {
            var aggregated = new List<Aggregated>();
            try
            {
                using (SqlConnection conn = new SqlConnection(_conn))
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand("sp_weightedaverageavlues", conn))
                    {
                        command.Parameters.Add(new SqlParameter("@FilterCondition", condition));
                        command.CommandType = CommandType.StoredProcedure;
                        using (IDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var item = new Aggregated
                                {
                                    OriginalPrincipalBalance = float.Parse(reader["OriginalPrincipalBalance"].ToString()),
                                    DTI = float.Parse(reader["DTI"].ToString()),
                                    LTI = float.Parse(reader["LTI"].ToString()),
                                    TotalIncome = float.Parse(reader["TotalIncome"].ToString()),
                                    IndexedDTI = float.Parse(reader["IndexedDTI"].ToString()),
                                    IndexedLTI = float.Parse(reader["IndexedLTI"].ToString()),
                                    IndexedTotalIncome = float.Parse(reader["IndexedTotalIncome"].ToString()),
                                    CurrentInterestRate = float.Parse(reader["CurrentInterestRate"].ToString()),
                                    OriginalLTV = float.Parse(reader["OriginalLTV"].ToString()),
                                    OriginalLTFV = float.Parse(reader["OriginalLTFV"].ToString()),
                                    OriginalForeclosureValue = float.Parse(reader["OriginalForeclosureValue"].ToString()),
                                    IndexedLTFV = float.Parse(reader["IndexedLTFV"].ToString()),
                                };
                                aggregated.Add(item);
                            }
                        }
                    }
                }
                return aggregated;
            }
            catch (SqlException ec)
            {
                return null;
            }
        }

        public override Aggregated GetById(object id) => throw new NotImplementedException();
    }
}
