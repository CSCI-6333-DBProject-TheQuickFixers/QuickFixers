﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuickFixers.Data;
//QuickFixers.Data is where we'd make database calls, seperate from the Web part of the project. 
//This would hold object classes that have db data we can reference in the View/Controller.
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
                QuickFixers.Data.Models.User loggedUser = new QuickFixers.Data.Models.User();
                //loggedUser.Email = "test@mail.com";
                //loggedUser.UserPassword = "123";
                //loggedUser.UserTypeID = 1;

                //Test Service Provider Will Delete After Testing
                loggedUser.Email = "sptestmatt@email.com";
                loggedUser.UserPassword = "123";
                loggedUser.UserTypeID = 2;

                if ((loggedUser != null))
                {
                    Session.Add("userid", loggedUser.UserID);
                    Session.Add("email", loggedUser.Email);
                    Session.Add("sessionGUID", Guid.NewGuid());
                    Session.Add("pass", loggedUser.UserPassword);
                    Session.Add("usertypeid", loggedUser.UserTypeID);
                    //return RedirectToAction("Index","Home");
                    //Redirect to Service Provider Index Will Delete After Testing
                    return RedirectToAction("Index", "ServiceProvider");
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