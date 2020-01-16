﻿using System;
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
            if (response.status != StatusManager.Instance.OK)
            {
                return StatusCode(StatusManager.Instance.GetStatusCode(response.status), response);
            }
            return StatusCode(200, response);
        }

        // GET: bms/books/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> GetBookDetail(int id)
        {
            ResponseBody response;
            response = await BookRepository.GetBookDetail(id);
            if (response.status != StatusManager.Instance.OK)
            {
                return StatusCode(StatusManager.Instance.GetStatusCode(response.status), response);
            }
            return StatusCode(200, response);
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetBookByTitle(string title, int offset, int limit)
        {
            ResponseBody response;
            response = await BookRepository.SearchBookByTitle(title, offset, limit);
            if (response.status != StatusManager.Instance.OK)
            {
                return StatusCode(StatusManager.Instance.GetStatusCode(response.status), response);
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
            if (checkUserRoleResp.status != StatusManager.Instance.OK)
            {
                if (checkUserRoleResp.status != StatusManager.Instance.Forbidden)
                {
                    return StatusCode(StatusManager.Instance.GetStatusCode(checkUserRoleResp.status), checkUserRoleResp);
                }
                response = new ResponseBody(StatusManager.Instance.Forbidden, "Not permission to delete book");
                return StatusCode(403, response);
            }

            response = await BookRepository.DeleteBookById(id);
            if (response.status != StatusManager.Instance.OK)
            {
                return StatusCode(StatusManager.Instance.GetStatusCode(response.status), response);
            }
            return StatusCode(200, response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBook(BookModel book)
        {
            ResponseBody response;
            if (book.BookID == 0 || book.Title == null || book.Author == null || book.AboutBook == null)
            {
                response = new ResponseBody(StatusManager.Instance.BadRequest, "Require bookID - title - author - aboutBook");
                return StatusCode(400, response);
            }
            if (book.Picture == null)
            {
                book.Picture = "";
            }

            StringValues values;
            Request.Headers.TryGetValue("Authorization", out values);

            ResponseBody checkUserRoleResp = await UserRepository.CheckUserRole(values);
            if (checkUserRoleResp.status != StatusManager.Instance.OK)
            {
                if (checkUserRoleResp.status != StatusManager.Instance.Forbidden)
                {
                    return StatusCode(StatusManager.Instance.GetStatusCode(checkUserRoleResp.status),checkUserRoleResp);
                }
                response = new ResponseBody(StatusManager.Instance.Forbidden, "Not permission to update book");
                return StatusCode(403, response);
            }
          
            response = await BookRepository.UpdateBook(book);
            if (response.status != StatusManager.Instance.OK)
            {
                return StatusCode(StatusManager.Instance.GetStatusCode(response.status), response);
            }
            return StatusCode(200, response);
        }

        [HttpPost]
        public async Task<IActionResult> InsertBook(BookModel book)
        {
            ResponseBody response;
            if (book.Title == null || book.Author == null || book.AboutBook == null)
            {
                response = new ResponseBody(StatusManager.Instance.BadRequest, "title - author - aboutBook");
                return StatusCode(400, response);
            }
            if (book.Picture == null)
            {
                book.Picture = "";
            }

            StringValues values;
            Request.Headers.TryGetValue("Authorization", out values);

            ResponseBody checkUserRoleResp = await UserRepository.CheckUserRole(values);
            if (checkUserRoleResp.status != StatusManager.Instance.OK)
            {
                if (checkUserRoleResp.status != StatusManager.Instance.Forbidden)
                {
                    return StatusCode(StatusManager.Instance.GetStatusCode(checkUserRoleResp.status), checkUserRoleResp);
                }
                response = new ResponseBody(StatusManager.Instance.Forbidden, "Not permission to insert book");
                return StatusCode(403, response);
            }

            response = await BookRepository.InsertBook(book);
            if (response.status != StatusManager.Instance.OK)
            {
                return StatusCode(StatusManager.Instance.GetStatusCode(response.status), response);
            }
            return StatusCode(200, response);
        }

        [HttpPost("buy")]
        public async Task<IActionResult> BuyBook(BuyBookReq req)
        {
            ResponseBody response;
            StringValues values;
            Request.Headers.TryGetValue("Authorization", out values);

            ResponseBody getActionSourceResp = await IAMRepository.GetActionSource(values);
            if (getActionSourceResp.status != StatusManager.Instance.OK)
            {
                return StatusCode(StatusManager.Instance.GetStatusCode(getActionSourceResp.status), getActionSourceResp);
            }

            ResponseBodyWithData resp = (ResponseBodyWithData)getActionSourceResp;
            UserModelIAM user = (UserModelIAM)resp.data;

            ResponseBody GetRoleResponse = UserRepository.GetUserRole(user.Email);
            if (GetRoleResponse.status != StatusManager.Instance.OK)
            {
                return StatusCode(StatusManager.Instance.GetStatusCode(GetRoleResponse.status),GetRoleResponse);
            }

            ResponseBodyWithData respRoleWithData = (ResponseBodyWithData)GetRoleResponse;
            UserModel userInBookService = (UserModel)respRoleWithData.data;

            if (userInBookService.Permission == 1)
            {
                if (req.Email != null)
                {
                    if (userInBookService.Email != req.Email)
                    {
                        response = new ResponseBody(StatusManager.Instance.Forbidden, "User can not buy book for other user");
                        return StatusCode(403, response);
                    }
                }
            }

            if (req.Email == null)
            {
                return StatusCode(400, "Require Email");
            }

            if (req.Address == null)
            {
                return StatusCode(400, "Require Address");
            }

            int n = req.Books.Length;
            for (int i=0;i<n;i++)
            {
                if (req.Books[i].BookID == 0 || req.Books[i].Qty < 0)
                {
                    return StatusCode(400, "Require BookID - Qty");
                }
            }

            response = await BookRepository.BuyBooks(req);
            if (response.status != StatusManager.Instance.OK)
            {
                return StatusCode(StatusManager.Instance.GetStatusCode(response.status), response);
            }
            return StatusCode(200, response);
        }
    }
}
