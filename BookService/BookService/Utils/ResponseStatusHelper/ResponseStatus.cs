using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookService.Utils.ResponseStatusHelper
{
    public abstract class ResponseStatus
    {
        public abstract string GetStatusName();
        public abstract int GetStatusCode();
    }
}
