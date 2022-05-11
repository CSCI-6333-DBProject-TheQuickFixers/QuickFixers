using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuickFixers.Models
{
    public class PaymentViewModel
    {          
        public Boolean IsValidPayment { get; set; }
        
        public string CardNumber { get; set; }

        public string BankAccount { get; set; }

        public string RoutingNumber { get; set; }

        public int ExpirationMonth { get; set; }

        public int ExpirationYear { get; set; }

        public decimal AmountDue { get; set;  }

        [Required]     
        public decimal PaymentAmount { get; set; }

        public List<int> ExpirationMonthList
        {
            get
            {
                return Data.Models.Payment.ExpirationMonth;
            }
        }
        
        public List<int> ExpirationYearList
        {
            get
            {
                return Data.Models.Payment.ExpirationYear;
            }
        }

    }
}