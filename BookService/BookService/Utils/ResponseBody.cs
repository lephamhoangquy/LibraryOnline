using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookService.Utils
{
    public class ResponseBody
    {
        public string status;
        public string message;

        public ResponseBody(string status,string message)
        {
            this.status = status;
            this.message = message;
        }
    }
}
