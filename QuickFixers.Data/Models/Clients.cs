using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickFixers.Data.Models
{
   public class Clients: User, IUser
    {

        private int defaultClientID = -1;
        public int ClientID { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public int ZipCode { get; set; }
        private decimal defaultPreferredDistance = 0;
        public decimal PreferredDistance { get => defaultPreferredDistance; set => defaultPreferredDistance = 0; }
        private int defaultServiceProviderID = -1;
        public int ServiceProviderID { get => defaultServiceProviderID; set => defaultServiceProviderID = -1; }
    }
}
