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

            ResponseBody checkUserRoleResp = await UserRepository.CheckUserRole(values);
            if (checkUserRoleResp.status != EnumStatus.OK)
            {
                if (checkUserRoleResp.status != EnumStatus.Forbidden)
                {
                    return StatusCode(EnumStatus.GetStatusCode(checkUserRoleResp.status), checkUserRoleResp);
                }
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

        [HttpPut]
        public async Task<IActionResult> UpdateBook(BookModel book)
        {
            ResponseBody response;
            if (book.BookID == 0 || book.Title == null || book.Author == null || book.AboutBook == null)
            {
                response = new ResponseBody(EnumStatus.BadRequest, "Require bookID - title - author - aboutBook");
                return StatusCode(400, response);
            }
            if (book.Picture == null)
            {
                book.Picture = "";
            }

            StringValues values;
            Request.Headers.TryGetValue("Authorization", out values);

            ResponseBody checkUserRoleResp = await UserRepository.CheckUserRole(values);
            if (checkUserRoleResp.status != EnumStatus.OK)
            {
                if (checkUserRoleResp.status != EnumStatus.Forbidden)
                {
                    return StatusCode(EnumStatus.GetStatusCode(checkUserRoleResp.status),checkUserRoleResp);
                }
                response = new ResponseBody(EnumStatus.Forbidden, "Not permission to update book");
                return StatusCode(403, response);
            }
          
            response = await BookRepository.UpdateBook(book);
            if (response.status != EnumStatus.OK)
            {
                return StatusCode(EnumStatus.GetStatusCode(response.status), response);
            }
            return StatusCode(200, response);
        }

        [HttpPost]
        public async Task<IActionResult> InsertBook(BookModel book)
        {
            ResponseBody response;
            if (book.Title == null || book.Author == null || book.AboutBook == null)
            {
                response = new ResponseBody(EnumStatus.BadRequest, "title - author - aboutBook");
                return StatusCode(400, response);
            }
            if (book.Picture == null)
            {
                book.Picture = "";
            }

            StringValues values;
            Request.Headers.TryGetValue("Authorization", out values);

            ResponseBody checkUserRoleResp = await UserRepository.CheckUserRole(values);
            if (checkUserRoleResp.status != EnumStatus.OK)
            {
                if (checkUserRoleResp.status != EnumStatus.Forbidden)
                {
                    return StatusCode(EnumStatus.GetStatusCode(checkUserRoleResp.status), checkUserRoleResp);
                }
                response = new ResponseBody(EnumStatus.Forbidden, "Not permission to insert book");
                return StatusCode(403, response);
            }

            response = await BookRepository.InsertBook(book);
            if (response.status != EnumStatus.OK)
            {
                return StatusCode(EnumStatus.GetStatusCode(response.status), response);
            }
            return StatusCode(200, response);
        }

    }
}
