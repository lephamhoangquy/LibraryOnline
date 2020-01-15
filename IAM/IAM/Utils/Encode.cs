using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace IAM.Utils
{
    public class Encode
    {
        public static string encode(string src)
        {
            var myBytes = Encoding.ASCII.GetBytes(src);
            var sha = new SHA256Managed();
            var hash = sha.ComputeHash(myBytes);
            string result = "";
            foreach (byte b in hash)
            {
                result += b.ToString("x2");
            }
            return result;
        }
    }
}
