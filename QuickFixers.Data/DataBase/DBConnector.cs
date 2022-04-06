using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickFixers.Data.DataBase
{
    public class DBConnector
    {
        protected static readonly string ServerEndPoint = "db-quickfixers.cffhy94odwbg.us-east-1.rds.amazonaws.com";
        protected static readonly uint Port = 3306;
        protected static readonly string UserID = "quickFixersAdmin";
        protected static readonly string Password = "7BAvFULs7Gzb1IGqte24";
        protected static readonly string DataBase = "quickFixers";

        public static DataTable GetResultsByStoredProcedure(string storedProcedure)
        {
            DataTable dataBaseResults = new DataTable();
            try
            {
                MySql.Data.MySqlClient.MySqlConnectionStringBuilder connectionStringBuilder = new MySql.Data.MySqlClient.MySqlConnectionStringBuilder
                {
                    Server = DBConnector.ServerEndPoint,
                    Port = DBConnector.Port,
                    UserID = DBConnector.UserID,
                    Password = DBConnector.Password,
                    Database = DBConnector.DataBase
                };
                using (var connectionDB = new MySql.Data.MySqlClient.MySqlConnection(connectionStringBuilder.ToString()))
                {
                    using (var sqlQuery = new MySql.Data.MySqlClient.MySqlCommand(storedProcedure, connectionDB))
                    {
                        sqlQuery.CommandType = System.Data.CommandType.StoredProcedure;
                        MySql.Data.MySqlClient.MySqlDataAdapter da = new MySql.Data.MySqlClient.MySqlDataAdapter();
                        da.SelectCommand = sqlQuery;
                        da.Fill(dataBaseResults);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                dataBaseResults = new DataTable();
            }
            return dataBaseResults;
        }
    }
}
