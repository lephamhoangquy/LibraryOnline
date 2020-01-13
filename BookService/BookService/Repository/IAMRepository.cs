using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BookService.Utils;
using BookService.ClientConfig;
using Microsoft.Extensions.Primitives;
using System.Net;
using Newtonsoft.Json;
using BookService.Model;
namespace BookService.Repository
{
    public class IAMRepository
    {
        public async static Task<ResponseBody> GetActionSource(StringValues values)
        {
            ResponseBody response;
            string token = values.FirstOrDefault();
            if (token == null || token == "")
            {
                response = new ResponseBody(EnumStatus.Unauthorized, EnumStatus.Unauthorized);
                return response;
            }

            var client = new HttpClient();
            client.BaseAddress = new Uri(IAMClientConfig.BaseUrl);
            string url = "/iam/authentication?token=" + token;

            HttpResponseMessage iamResp = await client.GetAsync(url);
            if (iamResp.StatusCode != HttpStatusCode.OK)
            {
                response = new ResponseBody(EnumStatus.Forbidden, EnumStatus.Forbidden);
                return response;
            }
            try
            {
                string content = await iamResp.Content.ReadAsStringAsync();
                ResponseBodyWithData contentObject = JsonConvert.DeserializeObject<ResponseBodyWithData>(content);
                UserModelIAM user = JsonConvert.DeserializeObject<UserModelIAM>(contentObject.data.ToString());
                response = new ResponseBodyWithData(EnumStatus.OK, user, "Lấy thông tin user thành công");
                return response;
            }
            catch (Exception e)
            {
                response = new ResponseBody(EnumStatus.InternalServerError, e.Message);
                return response;
            }
        }
    }
}
