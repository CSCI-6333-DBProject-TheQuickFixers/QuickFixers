using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickFixers.Data.Models;

namespace QuickFixers.Data.Services
{
    public class InMemoryPaymentData
    {
        List<Payment> listOfPayments = new List<Payment>();

        public InMemoryPaymentData()
        {
            listOfPayments = new List<Payment>()
            {
                new Payment { PaymentAmount = 100.50M, InvoiceID = 1, IsApproved = true, PaymentDate = DateTime.Now}
            };
        }

         public Payment GetPaymentByID(int paymentID)
        {
            return listOfPayments.Find(x => x.PaymentID == paymentID);
        }

        public List<Payment> GetPayments()
        {
            return listOfPayments;
        }

        public void Add(Payment payment)
        {
            listOfPayments.Add(payment);
        }
         
    }
}
