using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BookService.Utils
{
    public class DataProvider
    {
        public static SqlConnection GetConnection()
        {
            string connectionString = @"Data Source=GHN-TECH-LP0126;Initial Catalog=BookService;Integrated Security=True";
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
