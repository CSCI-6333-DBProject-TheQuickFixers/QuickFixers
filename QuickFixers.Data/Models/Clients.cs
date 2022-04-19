using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickFixers.Data.Models
{
   public class Clients: User, IUser
    {
        public int ClientID { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public int ZipCode { get; set; }
        public decimal PreferredDistance { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int ServiceProviderID { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
