using QuickFixers.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickFixers.Data.Services
{
    public class InMemoryScheduledServiceData : IServices
    {
        List<ScheduledService> scheduledServices;

        public InMemoryScheduledServiceData()
        {
            scheduledServices = new List<ScheduledService>()
            {
                new ScheduledService { clientID=1, scheduledServiceID=1, serviceAddress="Test AVe.", serviceDate= DateTime.Now, serviceProviderID=1, servicesOfferedID=1 },
                new ScheduledService { clientID=1, scheduledServiceID=3, serviceAddress="East Coast AVe.", serviceDate= DateTime.Now.AddDays(-1), serviceProviderID=1, servicesOfferedID=1 },
                new ScheduledService { clientID=1, scheduledServiceID=4, serviceAddress="Test AVe. 2", serviceDate= DateTime.Now.AddDays(1), serviceProviderID=1, servicesOfferedID=1 },
                new ScheduledService { clientID=1, scheduledServiceID=2, serviceAddress="Test AVe.", serviceDate= DateTime.Now.AddDays(4), serviceProviderID=1, servicesOfferedID=1 },

            };
        }
        public ScheduledService Get(int id)
        {
            return scheduledServices.FirstOrDefault(s => s.scheduledServiceID == id);
        }

        public IEnumerable<ScheduledService> GetAll()
        {
            return scheduledServices.OrderBy(s => s.scheduledServiceID);
        }

        public IEnumerable<ScheduledService> GetAllPast()
        {
            return scheduledServices.Where(s => s.serviceDate < DateTime.Now);
        }

        public IEnumerable<ScheduledService> GetAllFuture()
        {
            return scheduledServices.Where(s => s.serviceDate > DateTime.Now);
        }
    }
}
