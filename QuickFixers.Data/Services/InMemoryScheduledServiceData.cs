using QuickFixers.Data.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace QuickFixers.Data.Services
{
    public class InMemoryScheduledServiceData : IServices
    {
        List<ScheduledService> scheduledServices;

        public InMemoryScheduledServiceData()
        {
            int testVal = (int)HttpContext.Current.Session["userid"];

            Dictionary<string, string> storedProcedureParameters = new Dictionary<string, string>();
            storedProcedureParameters.Add("@UserID", testVal.ToString());

            DataTable testTable = DataBase.DatabaseSelections.Select("quickFixers.selectServicesByUserID", storedProcedureParameters);
            scheduledServices = DataBase.DatabaseSelections.ConvertToList<ScheduledService>(testTable);        }
        public ScheduledService Get(int id)
        {
            return scheduledServices.FirstOrDefault(s => s.ScheduledServiceID == id);
        }

        public IEnumerable<ScheduledService> GetAll()
        {
            return scheduledServices.OrderBy(s => s.ScheduledServiceID);
        }

        public IEnumerable<ScheduledService> GetAllPast()
        {
            return scheduledServices.Where(s => s.ServiceDate < DateTime.Now);
        }

        public IEnumerable<ScheduledService> GetAllFuture()
        {
            return scheduledServices.Where(s => s.ServiceDate > DateTime.Now);
        }
    }
}
