using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using QuickFixers.Data.Models;

namespace QuickFixers.Data.DataBase
{
    /// <summary>
    /// Database calls that setup select type of SQL calls. 
    /// Most are returned in a DataTable object.
    /// </summary>
    public static class DatabaseSelections
    {
        public static DataTable GetResultsNoParameters(string storedProcedure)
        {
            DataTable dataBaseResults = new DataTable();
            try
            {
                MySqlConnectionStringBuilder connectionStringBuilder = new MySqlConnectionStringBuilder();
                connectionStringBuilder = DatabaseExtensions.ToConnectionStringBuilder(connectionStringBuilder);
                using (var connectionDB = new MySqlConnection(connectionStringBuilder.ToString()))
                {
                    using (var sqlQuery = new MySqlCommand(storedProcedure, connectionDB))
                    {
                        sqlQuery.CommandType = CommandType.StoredProcedure;
                        MySqlDataAdapter da = new MySqlDataAdapter();
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

        public static DataTable Select(String storedProcedure, Dictionary<string,string> parameters)
        {
            DataTable returnResults = new DataTable();
            try
            {
                MySqlConnectionStringBuilder connectionStringBuilder = new MySqlConnectionStringBuilder();
                connectionStringBuilder = DatabaseExtensions.ToConnectionStringBuilder(connectionStringBuilder);

                using (var connectionDB = new MySqlConnection(connectionStringBuilder.ToString()))
                {
                    using (var sqlQuery = new MySqlCommand(storedProcedure, connectionDB))
                    {
                        sqlQuery.CommandType = CommandType.StoredProcedure;

                        foreach (var item in parameters)
                        {
                            sqlQuery.Parameters.AddWithValue(item.Key, item.Value);
                        }

                        MySqlDataAdapter da = new MySqlDataAdapter();
                        da.SelectCommand = sqlQuery;
                        da.Fill(returnResults);
                    }
                }
            }
            catch (Exception ex)
            {
                returnResults = new DataTable();
                Console.WriteLine(ex.ToString());
            }
            return returnResults;
        }

        public static DataTable SelectUser(User loggingUser)
        {
            DataTable returnResults = new DataTable();
            try
            {
                MySqlConnectionStringBuilder connectionStringBuilder = new MySqlConnectionStringBuilder();
                connectionStringBuilder = DatabaseExtensions.ToConnectionStringBuilder(connectionStringBuilder);

                using (var connectionDB = new MySqlConnection(connectionStringBuilder.ToString()))
                {
                    using (var sqlQuery = new MySqlCommand("quickFixers.selectUser", connectionDB))
                    {
                        sqlQuery.CommandType = CommandType.StoredProcedure;
                        sqlQuery.Parameters.AddWithValue($"@Email", loggingUser.Email);
                        sqlQuery.Parameters.AddWithValue($"@UserPassword", loggingUser.UserPassword);

                        MySqlDataAdapter da = new MySqlDataAdapter();
                        da.SelectCommand = sqlQuery;
                        da.Fill(returnResults);
                    }
                }
            }
            catch (Exception ex)
            {
                returnResults = new DataTable();
                Console.WriteLine(ex.ToString());
            }
            return returnResults;
        }

        public static List<T> ConvertToList<T>(DataTable dt)
        {
            var columnNames = dt.Columns.Cast<DataColumn>()
                    .Select(c => c.ColumnName)
                    .ToList();
            var properties = typeof(T).GetProperties();
            return dt.AsEnumerable().Select(row =>
            {
                var objT = Activator.CreateInstance<T>();
                foreach (var pro in properties)
                {
                    if (columnNames.Contains(pro.Name))
                    {
                        PropertyInfo pI = objT.GetType().GetProperty(pro.Name);
                        pro.SetValue(objT, row[pro.Name] == DBNull.Value ? null : Convert.ChangeType(row[pro.Name], pI.PropertyType));
                    }
                }
                return objT;
            }).ToList();
        }

        //Used to retrieve Service Provider info and save to Session for later use
        public static DataTable SelectSP(int sessionUserID)
        {
            DataTable returnResults = new DataTable();
            try
            {
                MySqlConnectionStringBuilder connectionStringBuilder = new MySqlConnectionStringBuilder();
                connectionStringBuilder = DatabaseExtensions.ToConnectionStringBuilder(connectionStringBuilder);

                using (var connectionDB = new MySqlConnection(connectionStringBuilder.ToString()))
                {
                    using (var sqlQuery = new MySqlCommand("quickFixers.SelSPUser", connectionDB))
                    {
                        sqlQuery.CommandType = CommandType.StoredProcedure;
                        sqlQuery.Parameters.AddWithValue($"@UserID", sessionUserID);

                        MySqlDataAdapter da = new MySqlDataAdapter();
                        da.SelectCommand = sqlQuery;
                        da.Fill(returnResults);
                    }
                }
            }
            catch (Exception ex)
            {
                returnResults = new DataTable();
                Console.WriteLine(ex.ToString());
            }
            return returnResults;
        }


        //Used to retrieve Service Provider Work Schedule Data Table for Specified Service Provider
        public static DataTable SelectSPWorkSchedule(int SPUserID)
        {
            DataTable returnResults = new DataTable();
            try
            {
                MySqlConnectionStringBuilder connectionStringBuilder = new MySqlConnectionStringBuilder();
                connectionStringBuilder = DatabaseExtensions.ToConnectionStringBuilder(connectionStringBuilder);

                using (var connectionDB = new MySqlConnection(connectionStringBuilder.ToString()))
                {
                    using (var sqlQuery = new MySqlCommand("quickFixers.SelSPWorkSchedule", connectionDB))
                    {
                        sqlQuery.CommandType = CommandType.StoredProcedure;
                        sqlQuery.Parameters.AddWithValue($"@SPUserID", SPUserID);

                        MySqlDataAdapter da = new MySqlDataAdapter();
                        da.SelectCommand = sqlQuery;
                        da.Fill(returnResults);
                    }
                }
            }
            catch (Exception ex)
            {
                returnResults = new DataTable();
                Console.WriteLine(ex.ToString());
            }
            return returnResults;
        }

        //Used to retrieve Service Provider Work Schedule Data Table for Specified Service Provider
        public static DataTable SelectSPServiceOffered(int SPUserID)
        {
            DataTable returnResults = new DataTable();
            try
            {
                MySqlConnectionStringBuilder connectionStringBuilder = new MySqlConnectionStringBuilder();
                connectionStringBuilder = DatabaseExtensions.ToConnectionStringBuilder(connectionStringBuilder);

                using (var connectionDB = new MySqlConnection(connectionStringBuilder.ToString()))
                {
                    using (var sqlQuery = new MySqlCommand("quickFixers.SelSPServicesOffered", connectionDB))
                    {
                        sqlQuery.CommandType = CommandType.StoredProcedure;
                        sqlQuery.Parameters.AddWithValue($"@SPUserID", SPUserID);

                        MySqlDataAdapter da = new MySqlDataAdapter();
                        da.SelectCommand = sqlQuery;
                        da.Fill(returnResults);
                    }
                }
            }
            catch (Exception ex)
            {
                returnResults = new DataTable();
                Console.WriteLine(ex.ToString());
            }
            return returnResults;
        }

        //Used to retrieve Service Provider Invoices Data Table for Specified Service Provider
        public static DataTable SelectSPInvoices(int SPUserID)
        {
            DataTable returnResults = new DataTable();
            try
            {
                MySqlConnectionStringBuilder connectionStringBuilder = new MySqlConnectionStringBuilder();
                connectionStringBuilder = DatabaseExtensions.ToConnectionStringBuilder(connectionStringBuilder);

                using (var connectionDB = new MySqlConnection(connectionStringBuilder.ToString()))
                {
                    using (var sqlQuery = new MySqlCommand("quickFixers.SelSPInvoices", connectionDB))
                    {
                        sqlQuery.CommandType = CommandType.StoredProcedure;
                        sqlQuery.Parameters.AddWithValue($"@SPUserID", SPUserID);

                        MySqlDataAdapter da = new MySqlDataAdapter();
                        da.SelectCommand = sqlQuery;
                        da.Fill(returnResults);
                    }
                }
            }
            catch (Exception ex)
            {
                returnResults = new DataTable();
                Console.WriteLine(ex.ToString());
            }
            return returnResults;
        }

        public static DataTable SelectSPScheduledServices(int SPUserID)
        {
            DataTable returnResults = new DataTable();
            try
            {
                MySqlConnectionStringBuilder connectionStringBuilder = new MySqlConnectionStringBuilder();
                connectionStringBuilder = DatabaseExtensions.ToConnectionStringBuilder(connectionStringBuilder);

                using (var connectionDB = new MySqlConnection(connectionStringBuilder.ToString()))
                {
                    using (var sqlQuery = new MySqlCommand("quickFixers.SelSPScheduledServices", connectionDB))
                    {
                        sqlQuery.CommandType = CommandType.StoredProcedure;
                        sqlQuery.Parameters.AddWithValue($"@SPUserID", SPUserID);

                        MySqlDataAdapter da = new MySqlDataAdapter();
                        da.SelectCommand = sqlQuery;
                        da.Fill(returnResults);
                    }
                }
            }
            catch (Exception ex)
            {
                returnResults = new DataTable();
                Console.WriteLine(ex.ToString());
            }
            return returnResults;
        }

        public static DataTable SelectSPPastServices(int SPUserID)
        {
            DataTable returnResults = new DataTable();
            try
            {
                MySqlConnectionStringBuilder connectionStringBuilder = new MySqlConnectionStringBuilder();
                connectionStringBuilder = DatabaseExtensions.ToConnectionStringBuilder(connectionStringBuilder);

                using (var connectionDB = new MySqlConnection(connectionStringBuilder.ToString()))
                {
                    using (var sqlQuery = new MySqlCommand("quickFixers.SelSPPastServices", connectionDB))
                    {
                        sqlQuery.CommandType = CommandType.StoredProcedure;
                        sqlQuery.Parameters.AddWithValue($"@SPUserID", SPUserID);     

                        MySqlDataAdapter da = new MySqlDataAdapter();
                        da.SelectCommand = sqlQuery;
                        da.Fill(returnResults);
                    }
                }
            }
            catch (Exception ex)
            {
                returnResults = new DataTable();
                Console.WriteLine(ex.ToString());
            }
            return returnResults;
        }
    }
}
