using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace QuickFixers.Data.DataBase
{
    /// <summary>
    /// This class holds the basic connection and formatting with the database.
    /// Also contains formatters if a stored proc or SQL string needs any validation.
    /// </summary>
    public static class DatabaseExtensions
    {
        public static readonly string DataBase = "quickFixers";
        /// <summary>
        /// Set the connection's url, port and creditials to connect to the database.
        /// </summary>
        /// <param name="connectionStringBuilderToSet"></param>
        /// <returns></returns>
        public static MySqlConnectionStringBuilder ToConnectionStringBuilder( MySqlConnectionStringBuilder connectionStringBuilderToSet)
        {
            string ServerEndPoint = "db-quickfixers.cffhy94odwbg.us-east-1.rds.amazonaws.com";
            uint Port = 3306;
            string UserID = "quickFixersAdmin";
            string Password = "7BAvFULs7Gzb1IGqte24";

            MySqlConnectionStringBuilder connectionStringBuilder = new MySqlConnectionStringBuilder
            {
                Server = ServerEndPoint,
                Port = Port,
                UserID = UserID,
                Password = Password,
                Database = DatabaseExtensions.DataBase
            };
            return connectionStringBuilder;
        }

        public static string FormatToDataBase(this string sqlString)
        {
            return !sqlString.Contains(DatabaseExtensions.DataBase) ? $"{DatabaseExtensions.DataBase}.{sqlString}" : sqlString;
        }       
    }
}
