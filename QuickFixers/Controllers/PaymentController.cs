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
        public ActionResult Index(Payment creatingPayment)
        {
            PaymentViewModel paymentViewModelGet = new PaymentViewModel();

            paymentViewModelGet.AmountDue = creatingPayment.AmountDue;
            paymentViewModelGet.ServiceDate = DateTime.Now;
            paymentViewModelGet.ServiceAddress = Session["address"].ToString();
            paymentViewModelGet.ClientID = (int)Session["clientID"];
            paymentViewModelGet.ServiceOfferredID = creatingPayment.ServicesOfferedID;
            paymentViewModelGet.ServiceProviderID = creatingPayment.ServiceProviderID;

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
                newPayment.ServiceProviderID = paymentViewModelPost.ServiceProviderID;
                newPayment.ClientID = (int)Session["clientID"];
                newPayment.ServicesOfferedID = paymentViewModelPost.ServiceOfferredID;
                newPayment.ServiceAddress = paymentViewModelPost.ServiceAddress;
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