using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace QuickFixers.Data.DataBase
{
    public static class DatabaseExtensions
    {
        public static readonly string DataBase = "quickFixers";
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
