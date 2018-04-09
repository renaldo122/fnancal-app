using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Test_Scenario.Core.Data;
using Test_Scenario.Services.Repositories;

namespace Test_Scenario.Services.SQLRepos
{
    public class SqlRepositoryCharts : RepositoryCharts<ChartsTable>
    {
        private string _conn;
        public SqlRepositoryCharts(string conStr)
        {
            _conn = conStr;
        }
        public override List<ChartsTable> GetAll(string condition)
        {
            var chart = new List<ChartsTable>();
            try
            {
                using (SqlConnection conn = new SqlConnection(_conn))
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand("sp_originalpropertyvalue", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        using (IDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var item = new ChartsTable
                                {
                                    Year = reader["Year"].ToString(),
                                    TotalCurrentAmount = float.Parse(reader["TotalCurrentAmount"].ToString()),
                                    IndexedDTI = float.Parse(reader["IndexedDTI"].ToString()),
                                    IndexedLTI = float.Parse(reader["IndexedLTI"].ToString()),
                                    //DelinquencyStatus = float.Parse(reader["DelinquencyStatus"].ToString()),
                                    OriginalFixedRateTerm = float.Parse(reader["OriginalFixedRateTerm"].ToString()),
                                };
                                chart.Add(item);
                            }
                        }
                    }
                }
                return chart;
            }
            catch (SqlException ec)
            {
                // Logger.Error(ec);
                return null;
            }
        }

        public override List<ChartsTable> GetChartsIndexedLTFV(string condition)
        {
            var chart = new List<ChartsTable>();
            try
            {
                using (SqlConnection conn = new SqlConnection(_conn))
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand("sp_indexedltfv", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        using (IDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var item = new ChartsTable
                                {
                                    Year = reader["Year"].ToString(),
                                    IndexedLTFV = float.Parse(reader["IndexedLTFV"].ToString()),
                                    IndexedDTI = float.Parse(reader["IndexedDTI"].ToString()),
                                    IndexedLTI = float.Parse(reader["IndexedLTI"].ToString()),
                                    //DelinquencyStatus = float.Parse(reader["DelinquencyStatus"].ToString()),
                                    OriginalFixedRateTerm = float.Parse(reader["OriginalFixedRateTerm"].ToString()),
                                };
                                chart.Add(item);
                            }
                        }
                    }
                }


                return chart;
            }
            catch (SqlException ec)
            {
                // Logger.Error(ec);
                return null;
            }
        }

        public override ChartsTable GetById(object id) => throw new NotImplementedException();
    }
}
