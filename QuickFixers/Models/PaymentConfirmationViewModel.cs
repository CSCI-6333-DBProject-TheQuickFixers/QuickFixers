using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuickFixers.Models
{
    public class PaymentConfirmationViewModel
    {
        [Required]
        public Boolean IsValidPayment { get; set; }

        public Guid PaymentGuid
        {
            get
            {
                return Guid.NewGuid();
            }
        }

        public DateTime PaymentDate
        {
            get
            {
                return DateTime.Now;
            }
        }
    }
}