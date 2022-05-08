using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

        public static string ToEncriptedString(this string passwordText)
        {
            string hashPassword = string.Empty;
            SHA1CryptoServiceProvider cyptoProvider = new SHA1CryptoServiceProvider();

            Byte[] passwordBytes = Encoding.ASCII.GetBytes(passwordText);
            Byte[] sha1Data = cyptoProvider.ComputeHash(passwordBytes);

            StringBuilder hashString = new StringBuilder();
            hashPassword = Convert.ToBase64String(sha1Data);
            return hashPassword;
        }

    }
}
