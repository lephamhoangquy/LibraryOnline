using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IAM.Utils.ResponseStatusHelper
{
    public class Status500 : ResponseStatus
    {
        public override string GetStatusName()
        {
            return "Internal Server Error";
        }
        public override int GetStatusCode()
        {
            return 500;
        }

    }
}
