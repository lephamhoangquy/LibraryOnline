using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using BookService.Utils;
using BookService.Model;
using Microsoft.Extensions.Primitives;

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
                response = new ResponseBodyWithData(StatusManager.Instance.OK, user, "Get user role successfully");
                DataProvider.CloseConnection(con);
                return response;
            }
            catch (Exception e)
            {
                DataProvider.CloseConnection(con);
                response = new ResponseBody(StatusManager.Instance.InternalServerError, e.Message);
                return response;
            }
        }
        public static async Task<ResponseBody> CheckUserRole(StringValues values)
        {
            ResponseBody IAMResponse = await IAMRepository.GetActionSource(values);
            if (IAMResponse.status != StatusManager.Instance.OK)
            {
                return IAMResponse;
            }

            ResponseBodyWithData resp = (ResponseBodyWithData)IAMResponse;
            UserModelIAM user = (UserModelIAM)resp.data;

            ResponseBody GetRoleResponse = GetUserRole(user.Email);
            if (GetRoleResponse.status != StatusManager.Instance.OK)
            {
                return GetRoleResponse;
            }

            ResponseBodyWithData respRoleWithData = (ResponseBodyWithData)GetRoleResponse;
            UserModel userInBookService = (UserModel)respRoleWithData.data;
            if (userInBookService.Permission != 2)
            {
                ResponseBody response  = new ResponseBody(StatusManager.Instance.Forbidden, "Not permission");
                return response;
            }
            return respRoleWithData;
        }
    }
}
