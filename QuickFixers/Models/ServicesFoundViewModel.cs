using System;

namespace QuickFixers.Models
{
    public class ServicesFoundViewModel
    {
        public int ServiceTypeID { get; set; }
        public string ServiceTypeName { get; set; }
        public int ZipCode { get; set; }
        public int PreferredDistance { get; set; }
        public int ServiceProviderID { get; set; }
        public string ServiceProviderName { get; set; }
        public DateTime ServiceDate { get; set; }
    }
}