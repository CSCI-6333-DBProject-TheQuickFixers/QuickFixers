using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuickFixers.Data;
using QuickFixers.Data.Models;
using QuickFixers.Models;

namespace QuickFixers.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            if ((Session.Keys.Count > 0) && (!string.IsNullOrEmpty(Session["sessionGUID"].ToString())))
            {
                return RedirectToAction("Index","Test");
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
                QuickFixers.Data.Models.User loggedUser = new QuickFixers.Data.Models.User();
                loggedUser.Email = "test@mail.com";
                loggedUser.Password = "123";
                loggedUser.UserType = 1;

                if ((loggedUser != null))
                {
                    Session.Add("userid", loggedUser.UserID);
                    Session.Add("email", loggedUser.Email);
                    Session.Add("sessionGUID", Guid.NewGuid());
                    Session.Add("pass", loggedUser.Password);
                    Session.Add("usertypeid", loggedUser.UserType);
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