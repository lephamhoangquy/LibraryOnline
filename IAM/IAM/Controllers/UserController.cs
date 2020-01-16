using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IAM.Utils;
using IAM.Model;
using IAM.Repository;
namespace IAM.Controllers
{
    [Route("iam/authentication")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // POST: iam/authentication
        [HttpPost]
        public async Task<IActionResult> Authenticate(LoginReq req)
        {
            ResponseBody response;
            if (req.email == null)
            {
                response = new ResponseBody(StatusManager.Instance.BadRequest, "Email is empty");
                return StatusCode(StatusCodes.Status400BadRequest, response);
            }
            if (req.passWord == null)
            {
                response = new ResponseBody(StatusManager.Instance.BadRequest, "Password is empty");
                return StatusCode(StatusCodes.Status400BadRequest, response);
            }

            req.passWord = Encode.encode(req.passWord);

            response = await UserRepository.GetUserInfo(req.email, req.passWord);
            if (response.status != StatusManager.Instance.OK)
            {
                return StatusCode(StatusManager.Instance.GetStatusCode(response.status), response);
            }

            try
            {
                ResponseBodyWithData finalResp = (ResponseBodyWithData)response;
                UserModel user = (UserModel)finalResp.data;
                user.Token = TokenManager.GenerateToken(user.Email + "/" + user.PassWord);
                finalResp.data = user;
                return StatusCode(StatusCodes.Status200OK, finalResp);
            }
            catch (Exception e)
            {
                response = new ResponseBody(StatusManager.Instance.InternalServerError, e.Message);
                return StatusCode(500, response);
            }

        }


        // GET: iam/authentication
        [HttpGet]
        public async Task<IActionResult> Validation(string token)
        {
            ResponseBody response;
            string info = TokenManager.ValidateToken(token);
            if (info == null)
            {
                response = new ResponseBody(StatusManager.Instance.Forbidden, StatusManager.Instance.Forbidden);
                return StatusCode(StatusCodes.Status403Forbidden, response);
            }
            LoginReq userInfo = LoginReq.GetEmailAndPasswordFromInfoString(info);
            if (userInfo == null)
            {
                response = new ResponseBody(StatusManager.Instance.Forbidden, StatusManager.Instance.Forbidden);
                return StatusCode(StatusCodes.Status403Forbidden, response);
            }

            if (userInfo.email == "" || userInfo.passWord == "")
            {
                response = new ResponseBody(StatusManager.Instance.Forbidden, StatusManager.Instance.Forbidden);
                return StatusCode(StatusCodes.Status403Forbidden, response);
            }

          //  userInfo.passWord = Encode.encode(userInfo.passWord);

            response = await UserRepository.GetUserInfo(userInfo.email, userInfo.passWord);
            if (response.status != StatusManager.Instance.OK)
            {
                response = new ResponseBody(StatusManager.Instance.Forbidden, StatusManager.Instance.Forbidden);
                return StatusCode(StatusCodes.Status403Forbidden, response);
            }

            return StatusCode(StatusCodes.Status200OK, response);
        }


    }
}
