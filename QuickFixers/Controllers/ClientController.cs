using QuickFixers.Data.DataBase;
using QuickFixers.Data.Models;
using QuickFixers.Data.Services;
using QuickFixers.Models;
using System;
using System.Collections.Generic;
using System.Data;
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


        [HttpGet]
        public ActionResult SelectService(ServiceViewModel serviceViewModelPost)
        {
                
                // Populate values      
                DayOfWeek daytest = serviceViewModelPost.SearchDate.DayOfWeek;
                String serviceTime = serviceViewModelPost.SearchDate.ToString("HH:mm:ss");
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
                    List<Service> servicesFound = new List<Service>();

                    servicesFound = DatabaseSelections.ConvertToList<Service>(selectedServices);
                   

                    foreach (Service servTest in servicesFound)
                    {
                        servTest.ServiceDate = serviceViewModelPost.SearchDate;
                    }

                    return View(servicesFound);
                }
                else { 
                
                    return View("Error");
                }

        }

        [HttpPost]
        public ActionResult Services(ServiceViewModel serviceViewModelPost)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("SelectService", "Client", serviceViewModelPost);
            }
            else
            {
                return View("Error");
            }      
        }

    }
}