using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuickFixers.Controllers
{
    public class ServiceProviderController : Controller
    {
        // GET: SP
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult WorkSchedule()
        {
            ViewBag.Message = "Shows current schedule and a link to edit";

            return View();
        }

        public ActionResult Invoices()
        {
            ViewBag.Message = "Shows invoices";

            return View();
        }

        public ActionResult ServicesOffered()
        {
            ViewBag.Message = "Shows current service offered and price, provides option to edit the service and price";

            return View();
        }

        public ActionResult ScheduledServices()
        {
            ViewBag.Message = "Shows current scheduled services ";

            return View();
        }

        public ActionResult PastServices()
        {
            ViewBag.Message = "Shows past services and clickable action to view an associated survey with each service";

            return View();
        }

        public ActionResult LogOut()
        {
            ViewBag.Message = "Logs out user and redirects to the QuickFix main page";

            return View();
        }
    }
}