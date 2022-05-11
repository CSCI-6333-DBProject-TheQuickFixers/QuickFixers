using System.Collections.Generic;
using System.Data;

namespace QuickFixers.Data.Models
{
    public class ServiceType
    {
        public int ServiceTypeID { get; set; }
        public string ServiceTypeName { get; set; }

        /// <summary>
        /// Calls db for list of service types and their ID values.
        /// </summary>
        /// <returns></returns>
        public static List<ServiceType> GetServiceTypes()
        {
            List<ServiceType> serviceTypes = new List<ServiceType>();
            try
            {
                DataTable databaseResults = DataBase.DatabaseSelections.GetResultsNoParameters("quickFixers.selectServiceTypes");
                if (databaseResults != null)
                {
                    foreach (DataRow serviceTypeRow in databaseResults.Rows)
                    {
                        ServiceType serviceType = new ServiceType();
                        serviceType.ServiceTypeID = (int)serviceTypeRow["ServiceTypeID"];
                        serviceType.ServiceTypeName = serviceTypeRow["ServiceTypeName"].ToString();
                        serviceTypes.Add(serviceType);
                    }
                    return serviceTypes;
                }
                return serviceTypes;
            }
            catch
            {
                return serviceTypes;
            }
        }

    }
}
