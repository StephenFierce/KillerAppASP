using KillerAppASP.Exceptions;
using KillerAppASP.Interfaces;
using KillerAppASP.Models;
using KillerAppASP.Repositories;
using KillerAppASP.ViewModels;
using Santhos.Web.Mvc.BootstrapFlashMessages;
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
            ViewBag.Count = 1;
            return View("Login");
        }

        [HttpPost]
        public ActionResult Login(int count, string email, string password)
        {
            _login = new LoginRepository(connector);
            int counter = count;
            try
            {
                User user = _login.Login(email, password);
                Session["LoggedIn"] = user;
            }
            catch (Exception)
            {
                
                this.FlashDanger("Er is geen gebruiker gevonden met de ingevulde gegevens, probeer het opnieuw.");
                if (counter < 4)
                { 
                switch (counter)
                {
                    case 1:
                        ViewBag.Gif = "https://media3.giphy.com/media/njYrp176NQsHS/giphy.gif";
                        break;
                    case 2:
                        ViewBag.Gif = "https://media2.giphy.com/media/G7KNnJfmBo2AM/giphy.gif";
                        break;
                    case 3:
                        ViewBag.Gif = "https://media0.giphy.com/media/46itMIe0bkQeY/giphy.gif";
                        break;
                }
                } else if (counter < 11)
                {
                    ViewBag.Gif = "https://media0.giphy.com/media/FEikw3bXVHdMk/giphy.gif";
                } else
                {
                    ViewBag.Gif = "https://www.youtube.com/watch?v=Gc2u6AFImn8";
                }
                
                counter++;
                ViewBag.Count = counter;
                return View("Login");
                
            }
            ViewBag.Message = "Welkom ";
            return View("Welcome");
        }

        public ActionResult Logout()
        {
            _login = new LoginRepository(connector);
            Session["LoggedIn"] = null;
            return View("Login");
        }
    }
}