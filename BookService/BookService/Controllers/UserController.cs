using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookService.Model;
using BookService.Utils;
using Microsoft.Extensions.Primitives;
using BookService.Repository;

namespace BookService.Controllers
{
    [Route("bms/role")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // GET: bms/role
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            StringValues values;
            ResponseBody response;
            Request.Headers.TryGetValue("Authorization", out values);

            ResponseBody IAMResponse = await IAMRepository.GetActionSource(values);
            if (IAMResponse.status != Utils.EnumStatus.OK)
            {
                return StatusCode(EnumStatus.GetStatusCode(IAMResponse.status), IAMResponse);
            }

            ResponseBodyWithData resp = (ResponseBodyWithData)IAMResponse;
            UserModelIAM userIAM = (UserModelIAM)resp.data;

            ResponseBody GetRoleResponse = UserRepository.GetUserRole(userIAM.Email);
            if (GetRoleResponse.status != Utils.EnumStatus.OK)
            {
                return StatusCode(EnumStatus.GetStatusCode(GetRoleResponse.status), GetRoleResponse);
            }

            ResponseBodyWithData respWithData = (ResponseBodyWithData)GetRoleResponse;
            UserModel user = (UserModel)respWithData.data;

            response = new ResponseBodyWithData(EnumStatus.OK, user, "Get role successfully");
            return StatusCode(200, response);
        }

       
    }
}
