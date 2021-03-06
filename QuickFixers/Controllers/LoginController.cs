using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
 //QuickFixers.Data is where we'd make database calls, seperate from the Web part of the project. 
//This would hold object classes that have db data we can reference in the View/Controller.
using QuickFixers.Data.Models;
using QuickFixers.Models;
using QuickFixers.Data.DataBase;
using System.Data;
using QuickFixers.Data.Utilities;

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
                Dictionary<string,string> spParameters = new Dictionary<string, string>();

                // Add parameter names and values to dictionary
                spParameters.Add("@Email", homeViewModelPost.Email);
                spParameters.Add("@UserPassword", homeViewModelPost.UserPassword.ToEncryptedString());

                DataTable selectedUser = DatabaseSelections.Select("quickFixers.selectUser", spParameters);

                if ((selectedUser != null) & (selectedUser.Rows.Count > 0))
                {
                    CreateSession(selectedUser);
                    //Successful Login Redirect to ServiceProviderHome
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
                IUser newUser;
                if (newLoginViewModel.UserTypeID == 1)
                {
                    newUser = new Client();
                }
                else
                {
                    newUser = new ServiceProvider();
                }

                #region Populate object to pass in DB call
                newUser.UserTypeID = newLoginViewModel.UserTypeID;
                newUser.Email = newLoginViewModel.Email;
                newUser.UserPassword = newLoginViewModel.UserPassword.ToEncryptedString();
                newUser.Name = newLoginViewModel.Name;
                newUser.PhoneNumber = newLoginViewModel.PhoneNumber;
                newUser.ZipCode = newLoginViewModel.ZipCode;
                newUser.Address = newLoginViewModel.Address;
                newUser.PreferredDistance = newLoginViewModel.PreferredDistance;
                #endregion

                Tuple<Int32, Int32, String> newUserResults = DatabaseInserts.CreateUserClient(newUser);           
                if (newUserResults.Item1 == 1)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View("Error");
                }
            }
            else
            {
                return View("Error");
            }
        }

        protected Boolean CreateSession(DataTable selectedUser) 
        {
            if ((selectedUser != null) & (selectedUser.Rows.Count > 0))
            {
                Session.Add("userid", selectedUser.Rows[0]["UserID"]);
                Session.Add("userTypeID", selectedUser.Rows[0]["UserTypeID"]);
                Session.Add("sessionGUID", Guid.NewGuid());
                Session.Add("address", selectedUser.Rows[0]["Address"]);

                if (Convert.ToInt16(Session["userTypeID"])  == 1)
                {
                    Session.Add("clientID", selectedUser.Rows[0]["ClientID"]);
                }
                else{
                    Session.Add("serviceProviderID", selectedUser.Rows[0]["ServiceProviderID"]);
                }

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