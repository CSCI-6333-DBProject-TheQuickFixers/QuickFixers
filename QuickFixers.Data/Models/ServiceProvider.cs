using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickFixers.Data.Models
{
    public class ServiceProvider
    {
        public int ServiceProviderId { get; set; }
        public int UserId { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public int ZipCode { get; set; }
        public float PreferredDistance { get; set; }
        public string UName { get; set; }

    }
}
