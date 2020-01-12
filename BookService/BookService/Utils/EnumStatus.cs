using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookService.Utils
{
    public static class EnumStatus
    {
        public const string OK = "OK";
        public const string InternalServerError = "Internal Server Error";
        public const string NotFound = "Not Found";
        public const string BadRequest = "400 Bad Request";
        public const string Unauthorized = "401 Unauthorized";
        public const string Forbidden = "403 Forbidden";
       

        public static int GetStatusCode(string status)
        {
            switch (status)
            {
                case OK:
                    return 200;
                case InternalServerError:
                    return 500;
                case NotFound:
                    return 404;
                case BadRequest:
                    return 400;
                case Unauthorized:
                    return 401;
                case Forbidden:
                    return 403;
                default:
                    return 500;
            }
        }
    }
}
