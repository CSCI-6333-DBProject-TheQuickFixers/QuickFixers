﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickFixers.Data.Models
{
    public class ScheduledService
    {
        public int ScheduledServiceID { get; set; }
        public int ServiceProviderID { get; set; }
        public string ServiceProviderName { get; set; }
        public int ClientID { get; set; }
        public string ClientName { get; set; }
        public int ServicesOfferedID { get; set; }
        public string ServiceTypeName { get; set; }
        public DateTime ServiceDate { get; set; }
        public string ServiceAddress { get; set; }
        public double ServiceFee { get; set; }
    }
}
