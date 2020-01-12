using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookService.Utils
{
    public class ResponseBodyWithData:ResponseBody
    {
        public object data;
        public ResponseBodyWithData(string status, object data, string message):base(status,message)
        {
            this.data = data;
        }

      
    }
}
