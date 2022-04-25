using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuickFixers.Data;
using QuickFixers.Models;


namespace QuickFixers.Controllers
{
    public class ServiceProviderController : Controller
    {
        // GET: SP
        public ActionResult Index()
        {
            //Manually Set SeviceProvider Info to allow for building of pages
            QuickFixers.Data.Models.ServiceProvider SPuser = new QuickFixers.Data.Models.ServiceProvider();
            SPuser.ServiceProviderId = 12;
            SPuser.UserId = 49;
            SPuser.PhoneNumber = "9561234444";
            SPuser.Address = "63 Coveway St";
            SPuser.ZipCode = 78521;
            SPuser.PreferredDistance = 20;
            SPuser.UName = "Mathew Sosa";

            Session.Add("spID", SPuser.ServiceProviderId);
            Session.Add("phnum", SPuser.PhoneNumber);
            Session.Add("address", SPuser.Address);
            Session.Add("zipcode", SPuser.ZipCode);
            Session.Add("prefdist", SPuser.PreferredDistance);
            Session.Add("uname", SPuser.UName);


            ViewBag.Message = "Hello " + SPuser.UName + "!";

            return View();
        }

        public ActionResult WorkSchedule()
        {
            ServiceProvider wsresults = new ServiceProvider();
            wsresults.DbResults = Data.DataBase.DBConnector.GetResultsByStoredProcedure("quickFixers.dummyWorkSchedule");
            wsresults.IsDBConnected = wsresults.DbResults != null && wsresults.DbResults.Rows.Count > 0 ? true : false;
            //return View(wsresults);

            ViewBag.Message = "Shows current schedule and a link to edit " + Session["userid"];

            return View(wsresults);
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

       // public ActionResult LogOut()
        //{
         //   ViewBag.Message = "Logs out user and redirects to the QuickFix main page";
         //
         //   return View();
        //}
    }
}