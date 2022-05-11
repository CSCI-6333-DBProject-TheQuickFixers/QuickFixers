using QuickFixers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuickFixers.Data.Models;
using System.Data;

namespace QuickFixers.Controllers
{
    public class PaymentController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            PaymentViewModel paymentViewModelGet = new PaymentViewModel();
            paymentViewModelGet.AmountDue = 100.50M;
            return View(paymentViewModelGet);
        }


        [HttpPost]
         public ActionResult Index(PaymentViewModel paymentViewModelPost)
        {
            if (ModelState.IsValid)
            {
                Payment newPayment = new Data.Models.Payment();
                #region Reflection to DB model

       
                newPayment.ExpirationMonthPayment = paymentViewModelPost.ExpirationMonth;
                newPayment.ExpirationYearPayment = paymentViewModelPost.ExpirationYear;
                newPayment.CardNumber = paymentViewModelPost.CardNumber;
                newPayment.AmountDue = paymentViewModelPost.AmountDue;
                newPayment.PaymentAmount = paymentViewModelPost.AmountDue;
                newPayment.scheduledServiceID = 12;
                newPayment.serviceProviderID = 12;
                newPayment.clientID = 12;
                newPayment.servicesOfferedID = 2;
                newPayment.serviceAddress = "123 st";
                newPayment.ServiceFee = 4.40M;
                newPayment.PaymentDate = DateTime.Now;
                 #endregion
                PaymentConfirmationViewModel paymentConfirmationViewModel = new PaymentConfirmationViewModel();

                paymentConfirmationViewModel.IsValidPayment = Payment.MakePayment(newPayment);

                newPayment.IsApproved = paymentConfirmationViewModel.IsValidPayment;

                Data.DataBase.DatabaseInserts.CreatePayment(newPayment);

                return RedirectToAction("PaymentConfirmation", "Payment", paymentConfirmationViewModel);                
            }
            else
            {
                return View("Error");
            }
        }

        [HttpGet]
        public ActionResult PaymentConfirmation(PaymentConfirmationViewModel paymentViewModelGet)
        {
            if (ModelState.IsValid)
            {
                 return View(paymentViewModelGet);
            }
            else
            {
                 return View("Error");
            }
        }

    }
}