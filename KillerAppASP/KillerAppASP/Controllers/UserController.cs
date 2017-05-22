using KillerAppASP.Interfaces;
using KillerAppASP.Models;
using KillerAppASP.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KillerAppASP.Controllers
{
    
    public class UserController : Controller
    {
        private IRepository<User> _userRepo;
        private IDatabaseConnector connector;
        // GET: User
        public ActionResult Index()
        {
            _userRepo = new UserRepo(connector);
            List<User> users = new List<User>();
            _userRepo.Refresh();
            users = _userRepo.Items;
            ViewBag.Users = users;
            ViewBag.Message = "HEUJJJ";
            return View();
        }

        public ActionResult ViewUserDetails()
        {

            return View();
        }

        public string Welcome()
        {
            return "Bla bla bla";
        }
    }
}