using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using BookService.Utils;
using BookService.Model;
namespace BookService.Repository
{
    public class UserRepository
    {
        public static ResponseBody GetUserRole(string email)
        {
            SqlConnection con = DataProvider.GetConnection();
            SqlCommand cmd = new SqlCommand("sp_GetUserRole", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = email;
            cmd.Parameters.AddWithValue("@Role", 0);
            cmd.Parameters["@Role"].Direction = ParameterDirection.Output;
            ResponseBody response;
            try
            {
                cmd.ExecuteNonQuery();
                int role = int.Parse(cmd.Parameters["@Role"].Value.ToString());
                UserModel user = new UserModel();
                user.Email = email;
                user.Permission = role;
                response = new ResponseBodyWithData(EnumStatus.OK, user, "Get user role successfully");
                DataProvider.CloseConnection(con);
                return response;
            }
            catch (Exception e)
            {
                DataProvider.CloseConnection(con);
                response = new ResponseBody(EnumStatus.InternalServerError, e.Message);
                return response;
            }
        }
    }
}
