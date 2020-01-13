using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookService.Model
{
    public class UserModel
    {
        private string email;
        private int permission;

        public string Email { get => email; set => email = value; }
        public int Permission { get => permission; set => permission = value; }
    }
}
