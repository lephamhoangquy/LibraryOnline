using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookService.Utils;
using BookService.Model;
using BookService.Repository;
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
    }
}
