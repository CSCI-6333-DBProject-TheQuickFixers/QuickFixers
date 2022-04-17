using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuickFixers.Data;
//QuickFixers.Data is where we'd make database calls, seperate from the Web part of the project. 
//This would hold object classes that have db data we can reference in the View/Controller.
using QuickFixers.Data.Models; 
using QuickFixers.Models;
using QuickFixers.Data.DataBase;
using System.Data;

namespace QuickFixers.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            if ((Session.Keys.Count > 0) && (!string.IsNullOrEmpty(Session["sessionGUID"].ToString())))
            {
                return RedirectToAction("MainPage","Home");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Index(HomeViewModel homeViewModelPost)
        {
            if (ModelState.IsValid)
            {
                User loggedUser = new User();
                loggedUser.Email = homeViewModelPost.Email;
                loggedUser.UserPassword = homeViewModelPost.UserPassword;
                DataTable selectedUser = DatabaseSelections.SelectUser(loggedUser);

                if ((selectedUser != null) &  (selectedUser.Rows.Count > 0))
                {
                    Session.Add("userid", selectedUser.Rows[0]["UserID"]);
                    Session.Add("userTypeID", selectedUser.Rows[0]["UserTypeID"]);
                    Session.Add("sessionGUID", Guid.NewGuid());
                    return RedirectToAction("Index","Home");
                }
                else
                {
                    ModelState.AddModelError("Login Unsuccessful", "Incorrect Login");
                    return View();
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        
       [HttpGet]        
       public ActionResult MainPage()
        {
            return View();
        }


        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}