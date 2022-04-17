using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickFixers.Data.Models;
using MySql.Data.MySqlClient;
namespace QuickFixers.Data.DataBase
{
    /// <summary>
    /// Database class that holds sql calls that inserts. 
    /// Stored procedures/sql statements that need parameters are set up differently in mysql objects.
    /// </summary>
    public static class DatabaseInserts  
    {
        /// <summary>
        /// Sets up insertUser stored proc parameters to add a new Client.
        /// Some fields are not shared with Clients and Service Providers but MySql paramters are not optional.
        /// insertUser combines adding a Client or SP. InsertClient and InsertServiceProviders are call within insertUser.
        /// Returns out parameter for success flag and new created UserID.
        /// </summary>
        /// <param name="newUser"></param>
        /// <param name="preferredDistance"></param>
        /// <returns></returns>
        public static Tuple<Boolean, int, String> CreateUserClient(Clients newUser)
        {
            Tuple<Boolean, int, String> returnResults = new Tuple<Boolean, int, String>(false, -1,String.Empty);
            try
            {
                MySqlConnectionStringBuilder connectionStringBuilder = new MySql.Data.MySqlClient.MySqlConnectionStringBuilder();
                connectionStringBuilder = DatabaseExtensions.ToConnectionStringBuilder(connectionStringBuilder);

                using (var connectionDB = new MySqlConnection(connectionStringBuilder.ToString()))
                {
                    using (var sqlQuery = new MySqlCommand("quickFixers.insertUser", connectionDB))
                    {
                        sqlQuery.CommandType = CommandType.StoredProcedure;
                        sqlQuery.Parameters.AddWithValue($"@UserType", newUser.UserTypeID);
                        sqlQuery.Parameters.AddWithValue($"@Email", newUser.Email);
                        sqlQuery.Parameters.AddWithValue($"@Pass", newUser.UserPassword);
                        sqlQuery.Parameters.AddWithValue($"@PhoneNumber", newUser.PhoneNumber);
                        sqlQuery.Parameters.AddWithValue($"@Address", newUser.Address);
                        sqlQuery.Parameters.AddWithValue($"@ZipCode", newUser.ZipCode);
                        sqlQuery.Parameters.AddWithValue($"@PreferredDistance", 0);

                        sqlQuery.Parameters.Add(new MySqlParameter("NewUserID", MySql.Data.MySqlClient.MySqlDbType.Int16));
                        sqlQuery.Parameters.Add(new MySqlParameter("Success", MySql.Data.MySqlClient.MySqlDbType.Int16));

                        sqlQuery.Parameters["NewUserID"].Direction = ParameterDirection.Output;
                        sqlQuery.Parameters["Success"].Direction = ParameterDirection.Output;

                        MySqlDataAdapter da = new MySql.Data.MySqlClient.MySqlDataAdapter();
                        sqlQuery.ExecuteNonQuery();
                        returnResults = new Tuple<bool, int, string>((Boolean)sqlQuery.Parameters["@Success"].Value, (int)sqlQuery.Parameters["@NewUserID"].Value, string.Empty);
                    }
                }

            }
            catch (Exception ex)
            {
                returnResults = new Tuple<Boolean, int, string>(false, -1, ex.ToString());
                Console.WriteLine(ex.ToString()); 
            }
            return returnResults;
        }
    }
}
