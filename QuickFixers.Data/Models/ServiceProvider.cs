using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickFixers.Data.Models
{
    public class ServiceProvider: User, IUser
    {
        public int ServiceProviderID { get; set; }
        //Set Default ClientID for IUser
        private int defaultClientID = -1;
        public int ClientID { get => defaultClientID; set => defaultClientID = -1; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public int ZipCode { get; set; }
        public decimal PreferredDistance { get; set; }
        public string Name { get; set; }

    }
}
