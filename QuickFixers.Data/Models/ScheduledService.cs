using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickFixers.Data.Models
{
    public class ScheduledService
    {
        public int scheduledServiceID { get; set; }
        public int serviceProviderID { get; set; }
        public int clientID { get; set; }
        public int servicesOfferedID { get; set; }
        public DateTime serviceDate { get; set; }
        public string serviceAddress { get; set; }
    }
}
