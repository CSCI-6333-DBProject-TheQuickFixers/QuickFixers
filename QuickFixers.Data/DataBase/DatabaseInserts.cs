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
        public static Tuple<Int32, Int32, String> CreateUserClient(IUser newUser)
        {
            Tuple<Int32, Int32, String> returnResults = new Tuple<Int32, Int32, String>(0, -1, String.Empty);
            try
            {
                MySqlConnectionStringBuilder connectionStringBuilder = new MySqlConnectionStringBuilder();
                connectionStringBuilder = DatabaseExtensions.ToConnectionStringBuilder(connectionStringBuilder);

                using (var connectionDB = new MySqlConnection(connectionStringBuilder.ToString()))
                {
                    using (var sqlQuery = new MySqlCommand("quickFixers.insertUser", connectionDB))
                    {
                        sqlQuery.CommandType = CommandType.StoredProcedure;
                        sqlQuery.Parameters.AddWithValue($"@UserTypeID", newUser.UserTypeID);
                        sqlQuery.Parameters.AddWithValue($"@Email", newUser.Email);
                        sqlQuery.Parameters.AddWithValue($"@Pass", newUser.UserPassword);
                        sqlQuery.Parameters.AddWithValue($"@PhoneNumber", newUser.PhoneNumber);
                        sqlQuery.Parameters.AddWithValue($"@Address", newUser.Address);
                        sqlQuery.Parameters.AddWithValue($"@ZipCode", newUser.ZipCode);
                        sqlQuery.Parameters.AddWithValue($"@PreferredDistance", newUser.PreferredDistance);
                        sqlQuery.Parameters.AddWithValue($"UName", newUser.Name);
                        sqlQuery.Parameters.Add(new MySqlParameter("NewUserID", MySqlDbType.Int32));
                        sqlQuery.Parameters.Add(new MySqlParameter("Success", MySqlDbType.Int32));

                        sqlQuery.Parameters["NewUserID"].Direction = ParameterDirection.Output;
                        sqlQuery.Parameters["Success"].Direction = ParameterDirection.Output;
                        MySqlDataAdapter da = new MySqlDataAdapter();
                        connectionDB.Open();
                        sqlQuery.ExecuteNonQuery();
                        connectionDB.Close();
                        returnResults = new Tuple<Int32, Int32, String>((Int32)sqlQuery.Parameters["@Success"].Value, (Int32)sqlQuery.Parameters["NewUserID"].Value, string.Empty);
                    }
                }

            }
            catch (Exception ex)
            {
                returnResults = new Tuple<Int32, Int32, String>(0, -1, ex.ToString());
                Console.WriteLine(ex.ToString());
            }
            return returnResults;
        }

        public static Tuple<Int32, String> CreatePayment(Payment newPayment)
        {
            Tuple<Int32, String> returnResults = new Tuple<Int32, String>(0, String.Empty);
            try
            {
                MySqlConnectionStringBuilder connectionStringBuilder = new MySqlConnectionStringBuilder();
                connectionStringBuilder = DatabaseExtensions.ToConnectionStringBuilder(connectionStringBuilder);

                using (var connectionDB = new MySqlConnection(connectionStringBuilder.ToString()))
                {
                    using (var sqlQuery = new MySqlCommand("quickFixers.InsertPayment", connectionDB))
                    {
                        sqlQuery.CommandType = CommandType.StoredProcedure;
                        sqlQuery.Parameters.AddWithValue($"@InputServiceProviderID", newPayment.serviceProviderID);
                        sqlQuery.Parameters.AddWithValue($"@InputClientID", newPayment.clientID);
                        sqlQuery.Parameters.AddWithValue($"@InputServiceOfferedID", newPayment.servicesOfferedID);
                        sqlQuery.Parameters.AddWithValue($"@InputServiceDate", newPayment.serviceDate);
                        sqlQuery.Parameters.AddWithValue($"@InputServiceAddress", newPayment.serviceAddress);
                        sqlQuery.Parameters.AddWithValue($"@InputPaymentAmount", newPayment.PaymentAmount);
                        sqlQuery.Parameters.AddWithValue($"@InputApproved", newPayment.IsApproved);
                        sqlQuery.Parameters.AddWithValue($"@InputPaymentDate", newPayment.PaymentDate);
 

                        sqlQuery.Parameters.Add(new MySqlParameter("Success", MySqlDbType.Int32));
                        sqlQuery.Parameters.Add(new MySqlParameter("FailedMessage", MySqlDbType.String));

                        sqlQuery.Parameters["Success"].Direction = ParameterDirection.Output;
                        sqlQuery.Parameters["FailedMessage"].Direction = ParameterDirection.Output;

                        MySqlDataAdapter da = new MySqlDataAdapter();
                        connectionDB.Open();
                        sqlQuery.ExecuteNonQuery();
                        connectionDB.Close();
                        returnResults = new Tuple<Int32, String>((Int32)sqlQuery.Parameters["@Success"].Value, sqlQuery.Parameters["FailedMessage"].Value.ToString());
                    }
                }

            }
            catch (Exception ex)
            {
                returnResults = new Tuple<Int32, String>(0, ex.ToString());
                Console.WriteLine(ex.ToString());
            }
            return returnResults;
        }


        public static Int16 Insert(string sqlString, Dictionary<string, string> parameters, Dictionary<string, DbType> outParameters)
        {
            Int16 sqlResults = 0;
            try
            {
                MySqlConnectionStringBuilder connectionStringBuilder = new MySqlConnectionStringBuilder();
                connectionStringBuilder = DatabaseExtensions.ToConnectionStringBuilder(connectionStringBuilder);

                using (var connectionDB = new MySqlConnection(connectionStringBuilder.ToString()))
                {
                    using (var sqlQuery = new MySqlCommand(sqlString, connectionDB))
                    {
                        sqlQuery.CommandType = CommandType.StoredProcedure;

                        foreach(KeyValuePair<string, string> parameter in parameters)
                        {
                            sqlQuery.Parameters.AddWithValue($"{parameter.Key}", parameter.Value);
                        }
              
                        foreach(KeyValuePair<string, DbType> parameter in outParameters)
                        {
                            sqlQuery.Parameters.Add(new MySqlParameter(parameter.Key, parameter.Value));
                            sqlQuery.Parameters[parameter.Key].Direction = ParameterDirection.Output;
                        }


                        MySqlDataAdapter da = new MySqlDataAdapter();
                        connectionDB.Open();
                        sqlQuery.ExecuteNonQuery();
                        connectionDB.Close();
                        return sqlResults = sqlQuery.Parameters.Contains("Success") ? (Int16)sqlQuery.Parameters["@Success"].Value : (Int16)1;
                    }
                }

            }
            catch (Exception ex)
            {
                sqlResults = 0;
                Console.WriteLine(ex.ToString());
            }
            return sqlResults;
        }

    }
}
