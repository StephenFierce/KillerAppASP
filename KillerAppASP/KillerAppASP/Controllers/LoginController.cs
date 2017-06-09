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
        public ActionResult Login(string email, string password)
        {
            _login = new LoginRepository(connector);
            try
            {
                User user = _login.Login(email, password);
                Session["LoggedIn"] = user;
            }
            catch (LoginException)
            {
                ViewBag.ExceptionMessage = "No user was found with the given e-mail and password.";

                return View("Login");
            }
            ViewBag.Message = "You've succesfully logged in! Welcome!";
            return View("Welcome");
        }
    }
}