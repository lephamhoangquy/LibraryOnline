using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookService.Utils.ResponseStatusHelper
{
    public class Status400 : ResponseStatus
    {
        public override string GetStatusName()
        {
            return "400 Bad Request";
        }
        public override int GetStatusCode()
        {
            return 400;
        }

    }
}
