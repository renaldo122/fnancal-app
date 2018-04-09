using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Scenario.Data
{
    public class IDbContext
    {
        public void CreateConection(string _conn)
        {
            using (SqlConnection conn = new SqlConnection(_conn))
            {
                conn.Open();
            }
        }
    }

}
