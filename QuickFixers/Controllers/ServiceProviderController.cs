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

            ViewBag.Message = "Shows current schedule and a link to edit";

            return View(wsresults);

        }

        public ActionResult Invoices()
        {

            ServiceProviderViewModel invoiceresults = new ServiceProviderViewModel();
            invoiceresults.DbResults = Data.DataBase.DatabaseSelections.SelectSPInvoices((int)Session["ServiceProviderID"]);
            invoiceresults.IsDBConnected = invoiceresults.DbResults != null && invoiceresults.DbResults.Rows.Count > 0 ? true : false;

            ViewBag.Message = "Shows current schedule and a link to edit";

            return View(invoiceresults);

        }

        public ActionResult ServicesOffered()
        {

            ServiceProviderViewModel serviceofferedresults = new ServiceProviderViewModel();
            serviceofferedresults.DbResults = Data.DataBase.DatabaseSelections.SelectSPServiceOffered((int)Session["ServiceProviderID"]);
            serviceofferedresults.IsDBConnected = serviceofferedresults.DbResults != null && serviceofferedresults.DbResults.Rows.Count > 0 ? true : false;

            ViewBag.Message = "Shows current schedule and a link to edit";

            return View(serviceofferedresults);
            
        }

        public ActionResult ScheduledServices()
        {

            ServiceProviderViewModel scheduledresults = new ServiceProviderViewModel();
            scheduledresults.DbResults = Data.DataBase.DatabaseSelections.SelectSPScheduledServices((int)Session["ServiceProviderID"]);
            scheduledresults.IsDBConnected = scheduledresults.DbResults != null && scheduledresults.DbResults.Rows.Count > 0 ? true : false;

            ViewBag.Message = "Shows current scheduled services ";

            return View(scheduledresults);
           


        }

        public ActionResult PastServices()
        {

            ServiceProviderViewModel pastresults = new ServiceProviderViewModel();
            pastresults.DbResults = Data.DataBase.DatabaseSelections.SelectSPPastServices((int)Session["ServiceProviderID"]);
            pastresults.IsDBConnected = pastresults.DbResults != null && pastresults.DbResults.Rows.Count > 0 ? true : false;

            ViewBag.Message = "Shows past services and clickable action to view an associated survey with each service";

            return View(pastresults);


        }

    }
}