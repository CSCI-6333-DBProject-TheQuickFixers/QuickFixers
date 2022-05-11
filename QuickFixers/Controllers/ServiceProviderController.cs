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

        public ActionResult CreateSPWorkSchedule()
        {
            var modeltest = new CreateSPWSModel();

            return View(modeltest);

        }

        [HttpPost]
        public ActionResult CreateWSAction(FormCollection collection)
        {

            String ResultStatus = Data.DataBase.DatabaseInserts.CreateNewWorkSchedule((int)Session["ServiceProviderID"], collection[1], collection[2], collection[3], collection[4]);


            if (ResultStatus == "Success")
            {
                return RedirectToAction("WorkSchedule", "ServiceProvider");
            }
            else
            {           
                return RedirectToAction("ErrorPage", "ServiceProvider");
            }


            
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult DeleteSPWorkSchedule(int id)
        {

            String ResultStatus = Data.DataBase.DatabaseInserts.DeleteWorkSchedule(id);


            if (ResultStatus == "Success")
            {
                return RedirectToAction("WorkSchedule", "ServiceProvider");
            }
            else
            {
                return RedirectToAction("ErrorPage", "ServiceProvider");
            }

        }



        public ActionResult CreateSPServiceOffered()
        {
            var modeltest = new CreateSPSOModel();

            return View(modeltest);

        }

        [HttpPost]
        public ActionResult CreateSOAction(FormCollection collection)
        {

            String ResultStatus = Data.DataBase.DatabaseInserts.CreateNewServiceOffered((int)Session["ServiceProviderID"], Int32.Parse(collection[1]), Decimal.Parse(collection[2]));


            if (ResultStatus == "Success")
            {
                return RedirectToAction("ServicesOffered", "ServiceProvider");
            }
            else
            {
                return RedirectToAction("ErrorPage", "ServiceProvider");
            }



        }



        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult DeleteSPServiceOffered(int id)
        {

            String ResultStatus = Data.DataBase.DatabaseInserts.DeleteServiceOffered(id);


            if (ResultStatus == "Success")
            {
                return RedirectToAction("ServicesOffered", "ServiceProvider");
            }
            else
            {
                return RedirectToAction("ErrorPage", "ServiceProvider");
            }

        }

        public ActionResult ErrorPage()
        {
            ViewBag.Message = "Error Encountered...";
            return View();
        }
    }
}