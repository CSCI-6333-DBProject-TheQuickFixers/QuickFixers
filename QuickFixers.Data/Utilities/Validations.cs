using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickFixers.Data.Utilities
{
    public static class Validations
    {
        
       public static string ToSqlSafe(string sqlField)
        {
            return sqlField.Replace("'", "''");
        }
    }
}
