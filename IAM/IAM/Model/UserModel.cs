using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IAM.Model
{
    public class UserModel
    {
        private string email;
        private string passWord;
        private string fullName;
        private string phoneNumber;
        private string token;

        public string Email { get => email; set => email = value; }
        public string PassWord { get => passWord; set => passWord = value; }
        public string FullName { get => fullName; set => fullName = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string Token { get => token; set => token = value; }

        public UserModel()
        {
            email = passWord = fullName = phoneNumber = token = "";
        }

    }
}
