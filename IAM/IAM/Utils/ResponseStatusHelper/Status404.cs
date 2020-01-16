using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IAM.Utils.ResponseStatusHelper
{
    public class Status404:ResponseStatus
    {
        public override string GetStatusName()
        {
            return "404 Not Found";
        }
        public override int GetStatusCode()
        {
            return 404;
        }
    }
}
