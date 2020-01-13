using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookService.Utils;
using BookService.Model;
using BookService.Repository;
using Microsoft.Extensions.Primitives;

namespace BookService.Controllers
{
    [Route("bms/books")]
    [ApiController]
    public class BookController : ControllerBase
    {
        // GET: bms/books
        [HttpGet]
        public async Task<IActionResult> GetAllBooks(int offset, int limit)
        {
            ResponseBody response;
            response = await BookRepository.GetBooks(offset, limit);
            if (response.status != EnumStatus.OK)
            {
                return StatusCode(EnumStatus.GetStatusCode(response.status), response);
            }
            return StatusCode(200, response);
        }

        // GET: bms/books/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> GetBookDetail(int id)
        {
            ResponseBody response;
            response = await BookRepository.GetBookDetail(id);
            if (response.status != EnumStatus.OK)
            {
                return StatusCode(EnumStatus.GetStatusCode(response.status), response);
            }
            return StatusCode(200, response);
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetBookByTitle(string title, int offset, int limit)
        {
            ResponseBody response;
            response = await BookRepository.SearchBookByTitle(title, offset, limit);
            if (response.status != EnumStatus.OK)
            {
                return StatusCode(EnumStatus.GetStatusCode(response.status), response);
            }
            return StatusCode(200, response);
        }

        // DELETE: bms/books/5
        [HttpDelete("{id}", Name="Delete")]
        public async Task<IActionResult> DeleteBookById(int id)
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
            UserModelIAM user = (UserModelIAM)resp.data;

            ResponseBody GetRoleResponse = UserRepository.GetUserRole(user.Email);
            if (GetRoleResponse.status != Utils.EnumStatus.OK)
            {
                return StatusCode(EnumStatus.GetStatusCode(GetRoleResponse.status), GetRoleResponse);
            }

            ResponseBodyWithData respRoleWithData = (ResponseBodyWithData)GetRoleResponse;
            UserModel userInBookService = (UserModel)respRoleWithData.data;
            if (userInBookService.Permission != 2)
            {
                response = new ResponseBody(EnumStatus.Forbidden, "Not permission to delete book");
                return StatusCode(403, response);
            }

            response = await BookRepository.DeleteBookById(id);
            if (response.status != EnumStatus.OK)
            {
                return StatusCode(EnumStatus.GetStatusCode(response.status), response);
            }
            return StatusCode(200, response);
        }

    }
}
