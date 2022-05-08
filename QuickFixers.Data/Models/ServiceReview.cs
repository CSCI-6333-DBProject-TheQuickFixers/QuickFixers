using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickFixers.Data.Models
{
    public class ServiceReview
    {
        public int ServiceProviderID { get; set; }
        public int PaymentID { get; set; }
        public int ServiceTypeID { get; set; }
        public string BriefReview { get; set; }
        public int Rating { get; set; }
    }
}
