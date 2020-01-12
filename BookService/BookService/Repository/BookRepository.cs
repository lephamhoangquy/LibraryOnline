using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using BookService.Model;
using BookService.Utils;
namespace BookService.Repository
{
    public class BookRepository
    {
        public static async Task<ResponseBody> GetBooks(int offset, int limit)
        {
            SqlConnection con = DataProvider.GetConnection();
            SqlCommand cmd = new SqlCommand("sp_GetBooks", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@offset", SqlDbType.Int).Value = offset;
            cmd.Parameters.Add("@limit", SqlDbType.Int).Value = limit;
            cmd.Parameters.AddWithValue("@total", 0);
            cmd.Parameters["@total"].Direction = ParameterDirection.Output;

            try
            {
                cmd.ExecuteNonQuery();
                int total = int.Parse(cmd.Parameters["@total"].Value.ToString());
                SqlDataReader reader = await cmd.ExecuteReaderAsync();
                List<BookModel> result = new List<BookModel>();
                while (await reader.ReadAsync())
                {
                    BookModel book = new BookModel();
                    book.BookID = int.Parse(reader["BookID"].ToString());
                    book.Title = reader["Title"].ToString();
                    book.Author = reader["Author"].ToString();
                    if (reader["Picture"] != System.DBNull.Value)
                    {
                        byte[] img = (byte[])(reader["Picture"]);
                        if (img != null)
                        {
                            book.Picture = img;
                        }
                    }
                    book.AboutBook = reader["AboutBook"].ToString();
                    book.CategoryID = int.Parse(reader["CategoryID"].ToString());
                    book.Qty = int.Parse(reader["Qty"].ToString());
                    book.CreatedAt = reader["CreatedAt"].ToString();
                    book.CategoryName = reader["CategoryName"].ToString();
                    book.Price = double.Parse(reader["Price"].ToString());
                    result.Add(book);
                }
              
                DataProvider.CloseConnection(con);
                ResponseBody response = new ResponseBodyWithDataAndTotal(EnumStatus.OK, result.ToArray(), "Get books successfully", total);
                return response;
            }
            catch (Exception e)
            {
                DataProvider.CloseConnection(con);
                ResponseBody response = new ResponseBody(EnumStatus.InternalServerError, e.Message);
                return response;
            }
        }    

        public static async Task<ResponseBody> GetBookDetail(int BookId)
        {
            SqlConnection con = DataProvider.GetConnection();
            SqlCommand cmd = new SqlCommand("sp_GetBookDetail", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@BookID", SqlDbType.Int).Value = BookId;
            try
            { 
                SqlDataReader reader = await cmd.ExecuteReaderAsync();
                BookModel result = null;
                while (await reader.ReadAsync())
                {
                    result = new BookModel();
                    result.BookID = int.Parse(reader["BookID"].ToString());
                    result.Title = reader["Title"].ToString();
                    result.Author = reader["Author"].ToString();
                    if (reader["Picture"] != System.DBNull.Value)
                    {
                        byte[] img = (byte[])(reader["Picture"]);
                        if (img != null)
                        {
                            result.Picture = img;
                        }
                    }
                    result.AboutBook = reader["AboutBook"].ToString();
                    result.CategoryID = int.Parse(reader["CategoryID"].ToString());
                    result.Qty = int.Parse(reader["Qty"].ToString());
                    result.CreatedAt = reader["CreatedAt"].ToString();
                    result.CategoryName = reader["CategoryName"].ToString();
                    result.Price = double.Parse(reader["Price"].ToString());
                    break;
                }

                DataProvider.CloseConnection(con);
                if (result != null)
                {
                    ResponseBody response = new ResponseBodyWithData(EnumStatus.OK, result, "Get book detail successfully");
                    return response;
                } else
                {
                    ResponseBody response = new ResponseBody(EnumStatus.NotFound,"Not found any book match with BookID");
                    return response;
                }
            }
            catch (Exception e)
            {
                DataProvider.CloseConnection(con);
                ResponseBody response = new ResponseBody(Utils.EnumStatus.InternalServerError, e.Message);
                return response;
            }
        }

        public static async Task<ResponseBody> SearchBookByTitle(string title, int offset, int limit)
        {
            SqlConnection con = DataProvider.GetConnection();
            SqlCommand cmd = new SqlCommand("sp_SearchBookByTitle", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@TextToSearch", SqlDbType.NVarChar).Value = title;
            cmd.Parameters.Add("@offset", SqlDbType.Int).Value = offset;
            cmd.Parameters.Add("@limit", SqlDbType.Int).Value = limit;
            cmd.Parameters.AddWithValue("@total", 0);
            cmd.Parameters["@total"].Direction = ParameterDirection.Output;
            cmd.CommandTimeout = 0;
            try
            {
                cmd.ExecuteNonQuery();
                int total = int.Parse(cmd.Parameters["@total"].Value.ToString());
                //int total = 0;
                SqlDataReader reader = await cmd.ExecuteReaderAsync();
                List<BookModel> result = new List<BookModel>();
                while (await reader.ReadAsync())
                {
                    BookModel book = new BookModel();
                    book.BookID = int.Parse(reader["BookID"].ToString());
                    book.Title = reader["Title"].ToString();
                    book.Author = reader["Author"].ToString();
                    if (reader["Picture"] != System.DBNull.Value)
                    {
                        byte[] img = (byte[])(reader["Picture"]);
                        if (img != null)
                        {
                            book.Picture = img;
                        }
                    }
                    book.AboutBook = reader["AboutBook"].ToString();
                    book.CategoryID = int.Parse(reader["CategoryID"].ToString());
                    book.Qty = int.Parse(reader["Qty"].ToString());
                    book.CreatedAt = reader["CreatedAt"].ToString();
                    book.CategoryName = reader["CategoryName"].ToString();
                    book.Price = double.Parse(reader["Price"].ToString());
                    result.Add(book);
                }

                DataProvider.CloseConnection(con);
                ResponseBody response = new ResponseBodyWithDataAndTotal(EnumStatus.OK, result.ToArray(), "Get books successfully", total);
                return response;
            }
            catch (Exception e)
            {
                DataProvider.CloseConnection(con);
                ResponseBody response = new ResponseBody(EnumStatus.InternalServerError, e.Message);
                return response;
            }

        }
    }
}
