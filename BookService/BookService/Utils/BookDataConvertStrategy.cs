using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using BookService.Model;
namespace BookService.Utils
{
    public class BookDataConvertStrategy:DataConvert
    {
        public override object ConvertDataReaderToModel(SqlDataReader reader)
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
                    book.Picture = Convert.ToBase64String(img, 0, img.Length);
                }
            }
            book.AboutBook = reader["AboutBook"].ToString();
            book.CategoryID = int.Parse(reader["CategoryID"].ToString());
            book.Qty = int.Parse(reader["Qty"].ToString());
            book.CreatedAt = reader["CreatedAt"].ToString();
            book.CategoryName = reader["CategoryName"].ToString();
            book.Price = double.Parse(reader["Price"].ToString());
            book.IsDeleted = bool.Parse(reader["IsDelete"].ToString());
            return book;
        }
    }
}
