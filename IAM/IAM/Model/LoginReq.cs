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
                //string[] results = info.Split("/");
                int index = info.IndexOf("/");
                string email = info.Substring(0, index);
                int n = info.Length;
                string passWord = info.Substring(index + 1, n - 1 - index);
                LoginReq loginReq = new LoginReq();
                loginReq.email = email;
                loginReq.passWord = passWord;
                return loginReq;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
