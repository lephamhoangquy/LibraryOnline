using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace BookService.Model
{
    public class BookModel
    {
        private int bookID;
        private string title;
        private string author;
        private string picture;
        private string aboutBook;
        private int categoryID;
        private string categoryName;
        private int qty;
        private string createdAt;
        private double price;
      

        public int BookID { get => bookID; set => bookID = value; }
        public string Title { get => title; set => title = value; }
        public string Author { get => author; set => author = value; }
        public string Picture { get => picture; set => picture = value; }
        public string AboutBook { get => aboutBook; set => aboutBook = value; }
        public int CategoryID { get => categoryID; set => categoryID = value; }
        public string CategoryName { get => categoryName; set => categoryName = value; }
        public int Qty { get => qty; set => qty = value; }
        public string CreatedAt { get => createdAt; set => createdAt = value; }
        public double Price { get => price; set => price = value; }
       

        public BookModel()
        {
            BookID = CategoryID = Qty = 0;
            Title = Author = AboutBook = CategoryName = CreatedAt = "";
            Picture = null;
           
        }

    }
}
