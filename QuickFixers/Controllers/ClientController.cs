using QuickFixers.Data.DataBase;
using QuickFixers.Data.Models;
using QuickFixers.Data.Services;
using QuickFixers.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuickFixers.Controllers
{
    public class ClientController : Controller
    {
        private readonly IServices db;

        public ClientController(IServices db)
        {
            this.db = db;
        }

        // GET: Client
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Services()
        {

            return View(new ServiceViewModel());
        }

        public ActionResult ScheduledServices()
        {
            var model = db.GetAllFuture();

            return View(model);
        }

        public ActionResult PastServices()
        {
            var model = db.GetAllPast();
            return View(model);
        }

        public ActionResult SelectService(List<Service> selectedServices)
        {
            var model = selectedServices;
            return View(model);
        }

        [HttpPost]
        public ActionResult Services(ServiceViewModel serviceViewModelPost)
        {
            if (ModelState.IsValid)
            {
                Service searchService = new Service
                {
                    ServiceTypeID = serviceViewModelPost.ServiceTypeID,
                    ServiceProviderName = serviceViewModelPost.ServiceProviderName,
                    ZipCode = serviceViewModelPost.ZipCode,
                    PreferredDistance = serviceViewModelPost.PreferredDistance
                };

                // searchService      
                DayOfWeek daytest = serviceViewModelPost.StartDate.DayOfWeek;
                String serviceTime = serviceViewModelPost.StartDate.ToString("HH:mm:ss");
                Dictionary<string, string> spParameters = new Dictionary<string, string>();

                // Add parameter names and values to dictionary
                spParameters.Add("@ServiceTypeID", serviceViewModelPost.ServiceTypeID.ToString());
                spParameters.Add("@ServiceProviderName", serviceViewModelPost.ServiceProviderName);
                spParameters.Add("@ZipCode", serviceViewModelPost.ZipCode.ToString());
                spParameters.Add("@PreferredDistance", serviceViewModelPost.PreferredDistance.ToString());
                spParameters.Add("@DayOfTheWeek", daytest.ToString());
                spParameters.Add("@ServiceTime", serviceTime);


                DataTable selectedServices = DatabaseSelections.Select("quickFixers.selectServices", spParameters);

                if ((selectedServices != null) & (selectedServices.Rows.Count > 0))
                {
                    List<Service> servicesFound = DatabaseSelections.ConvertToList<Service>(selectedServices);

                    return View(servicesFound);
                }
                else
                {
                    ModelState.AddModelError("No Services that meet that criteria.", "Try other data.");
                    return View();
                }
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

    }
}