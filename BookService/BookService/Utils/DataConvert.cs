using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BookService.Utils
{
    public abstract class DataConvert
    {
        public abstract object ConvertDataReaderToModel(SqlDataReader reader);
    }
}
