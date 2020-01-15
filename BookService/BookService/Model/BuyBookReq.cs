using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookService.Model
{
    public class BuyBookReq
    {
        private string email;
        private string address;
        private BookModel[] books;
        

        public string Email { get => email; set => email = value; }
        public BookModel[] Books { get => books; set => books = value; }
        public string Address { get => address; set => address = value; }

        public BuyBookReq()
        {

        }
    }
}
