using KillerAppASP.Exceptions;
using KillerAppASP.Interfaces;
using KillerAppASP.Models;
using KillerAppASP.Repositories;
using KillerAppASP.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KillerAppASP.Controllers
{
    public class LoginController : Controller
    {
        private LoginRepository _login;
        private IDatabaseConnector connector;
        public ActionResult Login()
        {
            _login = new LoginRepository(connector);
            return View("Login");
        }

        [HttpPost]
        public ActionResult Login(Login user)
        {
            try
            {
                User u = new User();
                u = _login.Login(user.Email, user.Password);
                Session["LoggedInUser"] = u;
            }
            catch (LoginException)
            {
                ViewBag.ExceptionMessage = "No user was found with the given e-mail and password.";

                return View();
            }

            return View("Index");
        }
    }
}