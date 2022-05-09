using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickFixers.Data.Models
{
    public class Payment
    {
        #region Properties
        protected static readonly List<int> _expirationMonth = new List<int> {1,2,3,4,5,6,7,8,9,10,11,12};
        public static List<int> ExpirationMonth
        {
            get
            {
                return _expirationMonth;
            }
        
        }

       public static List<int> ExpirationYear
        {
            get
            {
                List<int> result = new List<int>();
                for(int i = DateTime.Now.Year; i <= DateTime.Now.Year + 10; i++)
                {
                    result.Add(i);
                }
                return result; 
            }
        }
        public decimal PaymentAmount { get; set; }
        public decimal AmountDue { get; set; }
        public string CardNumber { get; set; }  
        public int ExpirationMonthPayment { get; set;}
        public int ExpirationYearPayment { get; set; }
        public DateTime ExpirationDate
        {
            get
            {
                DateTime expirationDate = DateTime.MinValue;             
                DateTime.TryParse($"{ExpirationMonthPayment.ToString()}/1/{ExpirationYearPayment.ToString()}", out expirationDate);
                return expirationDate;                
            }
        }
        #endregion

        public static Boolean MakePayment(Payment newPayment)
        {
            return (newPayment.CardNumber.Equals("4111111111111111")) && (newPayment.ExpirationDate.Subtract(DateTime.Now).TotalDays >= 0) && (newPayment.PaymentAmount >= newPayment.AmountDue) ? true : false;
        }

    }
}
