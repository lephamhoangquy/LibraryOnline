using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookService.Utils.ResponseStatusHelper
{
    public class Status401 : ResponseStatus
    {
        public override string GetStatusName()
        {
            return "401 Unauthorized";
        }
        public override int GetStatusCode()
        {
            return 401;
        }

    }
}
