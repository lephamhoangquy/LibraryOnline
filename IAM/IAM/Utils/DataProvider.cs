using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace IAM.Utils
{
    public class DataProvider
    {
        public static SqlConnection GetConnection()
        {
            string connectionString = @"Data Source=GHN-TECH-LP0126;Initial Catalog=IAMService;Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            return con;
        }
        public static void CloseConnection(SqlConnection con)
        {
            con.Close();
        }
    }
}
