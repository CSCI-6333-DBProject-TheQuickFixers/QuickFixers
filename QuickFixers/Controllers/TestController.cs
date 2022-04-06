using QuickFixers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuickFixers.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            TestViewModel testViewModel = new TestViewModel();
            testViewModel.DbResults = Data.DataBase.DBConnector.GetResultsByStoredProcedure("quickFixers.selData");
            testViewModel.IsDBConnected = testViewModel.DbResults != null && testViewModel.DbResults.Rows.Count > 0 ? true : false;
            return View(testViewModel);
        }
    }
}