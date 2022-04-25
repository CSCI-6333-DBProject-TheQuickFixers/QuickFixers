using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickFixers.Data.Models
{
    public class UserType
    {
        public int UserTypeID { get; set; }
        public string Description { get; set; }

        /// <summary>
        /// Calls db for list of user types and their ID values.
        /// </summary>
        /// <returns></returns>
        public static List<UserType> GetUserTypeIDs()
        {
            List<UserType> userTypes = new List<UserType>();
            try
            {
                DataTable databaseResults = DataBase.DatabaseSelections.GetResultsNoParameters("quickFixers.selectUserTypes");
                if(databaseResults != null)
                {
                    foreach(DataRow userTypeRow in databaseResults.Rows)
                    {
                        UserType userType = new UserType();
                        userType.UserTypeID = (int)userTypeRow["UserTypeID"];
                        userType.Description = userTypeRow["UserTypeDescription"].ToString();
                        userTypes.Add(userType);
                    }
                    return userTypes;
                }
                return userTypes;
            }
            catch
            {                
                return userTypes;
            }
        }
    }
}
