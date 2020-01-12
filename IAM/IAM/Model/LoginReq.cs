using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IAM.Model
{
    public class LoginReq
    {
        public string email;
        public string passWord;
        public LoginReq()
        {
            email = passWord = "";
        }
        public static LoginReq GetEmailAndPasswordFromInfoString(string info)
        {
            try
            {
                string[] results = info.Split("/");
                LoginReq loginReq = new LoginReq();
                loginReq.email = results[0];
                loginReq.passWord = results[1];
                return loginReq;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
