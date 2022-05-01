using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuickFixers.Data;
using QuickFixers.Models;
using QuickFixers.Data.DataBase;
using System.Data;
using QuickFixers.Data.Models;


namespace QuickFixers.Controllers
{
    public class ServiceProviderController : Controller
    {
        // GET: SP
        public ActionResult Index()
        {
            //Manually Set SeviceProvider Info to allow for building of pages
            //QuickFixers.Data.Models.ServiceProvider SPuser = new QuickFixers.Data.Models.ServiceProvider();
            //SPuser.ServiceProviderId = 12;
            //SPuser.UserId = 49;
            //SPuser.PhoneNumber = "9561234444";
            // SPuser.Address = "63 Coveway St";
            //SPuser.ZipCode = 78521;
            //SPuser.PreferredDistance = 20;
            //SPuser.UName = "Mathew Sosa";

            //Session.Add("spID", SPuser.ServiceProviderId);
            //Session.Add("phnum", SPuser.PhoneNumber);
            // Session.Add("address", SPuser.Address);
            //Session.Add("zipcode", SPuser.ZipCode);
            //Session.Add("prefdist", SPuser.PreferredDistance);
            // Session.Add("uname", SPuser.UName);


            //ViewBag.Message = "Hello " + SPuser.UName + "!";

            DataTable selectedSP = DatabaseSelections.SelectSP((int)Session["userid"]);

            if ((selectedSP != null) & (selectedSP.Rows.Count > 0))
            {
                Session.Add("ServiceProviderID", selectedSP.Rows[0]["ServiceProviderID"]);
                Session.Add("PhoneNumber", selectedSP.Rows[0]["PhoneNumber"]);
                Session.Add("Address", selectedSP.Rows[0]["Address"]);
                Session.Add("PreferredDistance", selectedSP.Rows[0]["PreferredDistance"]);
                Session.Add("ZipCode", selectedSP.Rows[0]["ZipCode"]);
                Session.Add("ServiceProviderName", selectedSP.Rows[0]["ServiceProviderName"]);

                ViewBag.Message = "Hello " + (string)Session["ServiceProviderName"] + "!";
            }
            else
            {
                ViewBag.Message = "Hello " + "(Error: Could Not Retrieve Name)! " + Session["userid"];
                return View();
            }

            return View();
        }

        public ActionResult WorkSchedule()
        {
            ServiceProviderViewModel wsresults = new ServiceProviderViewModel();
            wsresults.DbResults = Data.DataBase.DatabaseSelections.SelectSPWorkSchedule((int)Session["ServiceProviderID"]);
            wsresults.IsDBConnected = wsresults.DbResults != null && wsresults.DbResults.Rows.Count > 0 ? true : false;
            //return View(wsresults);

            ViewBag.Message = "Shows current schedule and a link to edit";

            return View(wsresults);

            //return View();
        }

        public ActionResult Invoices()
        {

            ServiceProviderViewModel invoiceresults = new ServiceProviderViewModel();
            invoiceresults.DbResults = Data.DataBase.DatabaseSelections.SelectSPInvoices((int)Session["ServiceProviderID"]);
            invoiceresults.IsDBConnected = invoiceresults.DbResults != null && invoiceresults.DbResults.Rows.Count > 0 ? true : false;
            //return View(wsresults);

            ViewBag.Message = "Shows current schedule and a link to edit";

            return View(invoiceresults);

            //ViewBag.Message = "Shows invoices";

            //return View();
        }

        public ActionResult ServicesOffered()
        {

            ServiceProviderViewModel serviceofferedresults = new ServiceProviderViewModel();
            serviceofferedresults.DbResults = Data.DataBase.DatabaseSelections.SelectSPServiceOffered((int)Session["ServiceProviderID"]);
            serviceofferedresults.IsDBConnected = serviceofferedresults.DbResults != null && serviceofferedresults.DbResults.Rows.Count > 0 ? true : false;
            //return View(wsresults);

            ViewBag.Message = "Shows current schedule and a link to edit";

            return View(serviceofferedresults);
            
            //ViewBag.Message = "Shows current service offered and price, provides option to edit the service and price";

            //return View();
        }

        public ActionResult ScheduledServices()
        {

            ServiceProviderViewModel scheduledresults = new ServiceProviderViewModel();
            scheduledresults.DbResults = Data.DataBase.DatabaseSelections.SelectSPScheduledServices((int)Session["ServiceProviderID"]);
            scheduledresults.IsDBConnected = scheduledresults.DbResults != null && scheduledresults.DbResults.Rows.Count > 0 ? true : false;
            //return View(wsresults);

            //ViewBag.Message = "Shows current schedule and a link to edit";
            ViewBag.Message = "Shows current scheduled services ";

            return View(scheduledresults);
           

            //return View();
        }

        public ActionResult PastServices()
        {

            ServiceProviderViewModel pastresults = new ServiceProviderViewModel();
            pastresults.DbResults = Data.DataBase.DatabaseSelections.SelectSPPastServices((int)Session["ServiceProviderID"]);
            pastresults.IsDBConnected = pastresults.DbResults != null && pastresults.DbResults.Rows.Count > 0 ? true : false;
            //return View(wsresults);

            //ViewBag.Message = "Shows current schedule and a link to edit";
            //ViewBag.Message = "Shows current scheduled services ";
            ViewBag.Message = "Shows past services and clickable action to view an associated survey with each service";

            return View(pastresults);

            

            //return View();
        }

       // public ActionResult LogOut()
        //{
         //   ViewBag.Message = "Logs out user and redirects to the QuickFix main page";
         //
         //   return View();
        //}
    }
}