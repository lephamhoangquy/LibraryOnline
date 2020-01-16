using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IAM.Utils.ResponseStatusHelper
{
    public class Status403 : ResponseStatus
    {
        public override string GetStatusName()
        {
            return "403 Fobbidden";
        }
        public override int GetStatusCode()
        {
            return 403;
        }
    }
}
