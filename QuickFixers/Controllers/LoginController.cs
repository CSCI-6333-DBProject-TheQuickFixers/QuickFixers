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
        /// If true then redirect and set session values for that user to be save and used across the site.
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

                if (CreateSession(selectedUser))
                { 
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
            ViewBag.Message = string.Empty;
            return View(new LoginViewModel());
        }

        [HttpPost]
        public ActionResult Register(LoginViewModel newLoginViewModel)
        {
            if (ModelState.IsValid)
            {
                IUser newUser = newLoginViewModel.UserTypeID == 1 ? new Clients() : null; //replace null with service provider
                
                #region Populate object to pass in DB call
                newUser.UserTypeID = newLoginViewModel.UserTypeID;
                newUser.Email = newLoginViewModel.Email;
                newUser.UserPassword = newLoginViewModel.UserPassword;
                newUser.Name = newLoginViewModel.Name;
                newUser.PhoneNumber = newLoginViewModel.PhoneNumber;
                newUser.ZipCode = newLoginViewModel.ZipCode;
                newUser.Address = newLoginViewModel.Address;
                #endregion

                Tuple<Int32, Int32, String> newUserResults = DatabaseInserts.CreateUserClient(newUser);
                if (newUserResults.Item1 == 1)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Message("Failed to create user, please try again");
                    return RedirectToAction("Register", "Login");
                }
            }
            else
            {
                return RedirectToAction("Register","Login");
            }
        }

        protected Boolean CreateSession(DataTable selectedUser) 
        {
            if ((selectedUser != null) & (selectedUser.Rows.Count > 0))
            {
                Session.Add("userid", selectedUser.Rows[0]["UserID"]);
                Session.Add("userTypeID", selectedUser.Rows[0]["UserTypeID"]);
                Session.Add("sessionGUID", Guid.NewGuid());
                return true;
            }
            else
            {
                return false;
            }
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }

}