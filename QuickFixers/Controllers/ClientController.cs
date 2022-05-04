using QuickFixers.Data.Services;
using System;
using System.Collections.Generic;
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
            return View();
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

    }
}