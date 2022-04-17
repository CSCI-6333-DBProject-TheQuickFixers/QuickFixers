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
    public class LoginController : Controller
    {

        [HttpGet]
        public ActionResult Index()
        {
            if ((Session.Keys.Count > 0) && (!string.IsNullOrEmpty(Session["sessionGUID"].ToString())))
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }


        /// <summary>
        /// This is the login information that is posted to this function.
        /// We do a select user call from the Data project to return a matching user/password.
        /// If true than redirect and set session values for that user to be save and used across the site.
        /// If false then print an invalid login message and not redirect.
        /// </summary>
        /// <param name="homeViewModelPost"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Index(HomeViewModel homeViewModelPost)
        {
            if (ModelState.IsValid)
            {
                User loggedUser = new User();
                loggedUser.Email = homeViewModelPost.Email;
                loggedUser.UserPassword = homeViewModelPost.UserPassword;
                DataTable selectedUser = DatabaseSelections.SelectUser(loggedUser);

                if ((selectedUser != null) & (selectedUser.Rows.Count > 0))
                {
                    Session.Add("userid", selectedUser.Rows[0]["UserID"]);
                    Session.Add("userTypeID", selectedUser.Rows[0]["UserTypeID"]);
                    Session.Add("sessionGUID", Guid.NewGuid());
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("Login Unsuccessful", "Incorrect Login");
                    return View();
                }
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        [HttpGet]        
        public ActionResult Register()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public ActionResult Register(LoginViewModel newLoginViewModel)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Register","Login");
            }
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }

}