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
        private static DataConvert Converter = new BookDataConvertStrategy();
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
                    BookModel book = (BookModel)Converter.ConvertDataReaderToModel(reader);
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
                    result = (BookModel)Converter.ConvertDataReaderToModel(reader);
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
                SqlDataReader reader = await cmd.ExecuteReaderAsync();
                List<BookModel> result = new List<BookModel>();
                while (await reader.ReadAsync())
                {
                    BookModel book = (BookModel)Converter.ConvertDataReaderToModel(reader);
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

        public static async Task<ResponseBody> DeleteBookById(int BookId)
        {
            SqlConnection con = DataProvider.GetConnection();
            SqlCommand cmd = new SqlCommand("sp_DeleteBookById", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@BookID", SqlDbType.Int).Value = BookId;
            ResponseBody response;
            try
            {
                await cmd.ExecuteNonQueryAsync();
                DataProvider.CloseConnection(con);
                response = new ResponseBody(EnumStatus.OK, "Delete book successfully");
                return response;
            }
            catch (Exception e)
            {
                DataProvider.CloseConnection(con);
                response = new ResponseBody(EnumStatus.InternalServerError, e.Message);
                return response;
            }

        }

        public static async Task<ResponseBody> UpdateBook(BookModel book)
        {
            SqlConnection con = DataProvider.GetConnection();
            SqlCommand cmd = new SqlCommand("sp_UpdateBook", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@BookID", SqlDbType.Int).Value = book.BookID;
            cmd.Parameters.Add("@Price", SqlDbType.Float).Value = book.Price;
            cmd.Parameters.Add("@Author", SqlDbType.NVarChar).Value = book.Author;
            cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = book.Title;
            cmd.Parameters.Add("@Qty", SqlDbType.Int).Value = book.Qty;
            cmd.Parameters.Add("@AboutBook", SqlDbType.NVarChar).Value = book.AboutBook;
            cmd.Parameters.Add("@Base64String", SqlDbType.VarChar).Value = book.Picture;

            ResponseBody response;
            try
            {
                await cmd.ExecuteNonQueryAsync();
                DataProvider.CloseConnection(con);
                response = new ResponseBody(EnumStatus.OK, "Update book successfully");
                return response;
            }
            catch (Exception e)
            {
                DataProvider.CloseConnection(con);
                response = new ResponseBody(EnumStatus.InternalServerError, e.Message);
                return response;
            }
        }

        public static async Task<ResponseBody> InsertBook(BookModel book)
        {
            SqlConnection con = DataProvider.GetConnection();
            SqlCommand cmd = new SqlCommand("sp_InsertBook", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@Price", SqlDbType.Float).Value = book.Price;
            cmd.Parameters.Add("@Author", SqlDbType.NVarChar).Value = book.Author;
            cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = book.Title;
            cmd.Parameters.Add("@Qty", SqlDbType.Int).Value = book.Qty;
            cmd.Parameters.Add("@AboutBook", SqlDbType.NVarChar).Value = book.AboutBook;
            cmd.Parameters.Add("@Base64String", SqlDbType.VarChar).Value = book.Picture;

            ResponseBody response;
            try
            {
                await cmd.ExecuteNonQueryAsync();
                DataProvider.CloseConnection(con);
                response = new ResponseBody(EnumStatus.OK, "Insert book successfully");
                return response;
            }
            catch (Exception e)
            {
                DataProvider.CloseConnection(con);
                response = new ResponseBody(EnumStatus.InternalServerError, e.Message);
                return response;
            }
        }

    }
}
