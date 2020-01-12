using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookService.Utils
{
    public class ResponseBodyWithDataAndTotal:ResponseBodyWithData
    {
        public int total;
        public ResponseBodyWithDataAndTotal(string status, object data, string message, int total):base(status,data,message)
        {
            this.total = total;
        }

    
    }
}
