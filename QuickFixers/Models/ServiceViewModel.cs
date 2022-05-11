using QuickFixers.Data.Models;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace QuickFixers.Models
{
    public class ServiceViewModel
    {
        [IntegerValidator(MinValue = 1, MaxValue = 10)]
        public int ServiceTypeID { get; set; }

        /// <summary>
        /// This populates are user types to a drop down. 
        /// </summary>
        public List<ServiceType> ServiceTypesSelect
        {
            get
            {
                return ServiceType.GetServiceTypes();
            }
        }

        public int ZipCode { get; set; }
        public int PreferredDistance { get; set; }
        public string ServiceProviderName { get; set; }
        public DateTime SearchDate { get; set; } = DateTime.Now;
        public DayOfWeek DayOfTheWeek { get; set; }

    }
}