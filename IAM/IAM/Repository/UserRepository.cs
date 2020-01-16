using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using IAM.Utils;
using System.Data;
using IAM.Model;
namespace IAM.Repository
{
    public class UserRepository
    {
        public static async Task<ResponseBody> GetUserInfo(string email, string passWord)
        {
            SqlConnection con = DataProvider.GetConnection();
            SqlCommand cmd = new SqlCommand("sp_Login",con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Email", SqlDbType.VarChar, 100).Value = email;
            cmd.Parameters.Add("@Password", SqlDbType.VarChar,-1).Value = passWord;
            try
            {
                SqlDataReader reader = await cmd.ExecuteReaderAsync();
                UserModel result = null;
                while (await reader.ReadAsync())
                {
                    result = new UserModel();
                    result.Email = reader["Email"].ToString();
                    result.PassWord = reader["UserPassword"].ToString();
                    result.FullName = reader["FullName"].ToString();
                    result.PhoneNumber = reader["Phone"].ToString();
                    break;
                }
                DataProvider.CloseConnection(con);
                if (result != null)
                {
                    ResponseBody response = new ResponseBodyWithData(Utils.StatusManager.Instance.OK, result, "Get user info successfully");
                    return response;
                }
                else
                {
                    ResponseBody response = new ResponseBody(Utils.StatusManager.Instance.NotFound, "Not found any user matched");
                    return response;
                }
            } catch (Exception e)
            {
                DataProvider.CloseConnection(con);
                ResponseBody response = new ResponseBody(Utils.StatusManager.Instance.InternalServerError, e.Message);
                return response;
            }
        }
    }
}
