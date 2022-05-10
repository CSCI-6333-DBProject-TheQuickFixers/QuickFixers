using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickFixers.Data.Models
{
    public class Service
    {
        public int ServiceTypeID { get; set; }
        public string ServiceTypeName { get; set; }
        public int ZipCode { get; set; }
        public int PreferredDistance { get; set; }
        public int ServiceProviderID { get; set; }
        public string ServiceProviderName { get; set; }
        public DateTime ServiceDate { get; set; }
        [DataType(DataType.Currency)]
        public decimal ServiceFee { get; set; }

    }
}
