using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookService.Utils.ResponseStatusHelper
{
    public class Status200:ResponseStatus
    {
        public override string GetStatusName()
        {
            return "OK";
        }
        public override int GetStatusCode()
        {
            return 200;
        }
    }
}
