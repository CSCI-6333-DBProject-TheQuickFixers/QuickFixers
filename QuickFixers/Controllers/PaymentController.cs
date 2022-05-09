using QuickFixers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
                Data.Models.Payment newPayment = new Data.Models.Payment();
                newPayment.ExpirationMonthPayment = paymentViewModelPost.ExpirationMonth;
                newPayment.ExpirationYearPayment = paymentViewModelPost.ExpirationYear;
                newPayment.CardNumber = paymentViewModelPost.CardNumber;
                newPayment.AmountDue = paymentViewModelPost.AmountDue;
                newPayment.PaymentAmount = paymentViewModelPost.AmountDue;

                Boolean isValidPayment = Data.Models.Payment.MakePayment(newPayment);

                if (isValidPayment)
                {
                return RedirectToAction("Index", "Test");
                }
                else
                {
                    return View("Error");
                }
            }
            else
            {
                return View("Error");
            }
        }

    }
}