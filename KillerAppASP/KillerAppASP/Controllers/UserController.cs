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
        private UserRepo _userRepo;
        
        private IDatabaseConnector connector;
        // GET: User
        public ActionResult Index()
        {
            RefreshUsers();
            ViewBag.Message = "HEUJJJ";
            return View(_userRepo.Users);
        }

        public ActionResult Edit()
        {
            return View();
        }

        public ActionResult ShowUserDetails(int ID)
        {
            RefreshUsers();
            ViewBag.ViewUserDetails =  _userRepo.GetItem(ID);
            return View("Index");
        }

        public string Welcome()
        {
            return "Bla bla bla";
        }

        public void RefreshUsers()
        {
            _userRepo = new UserRepo(connector);
            List<User> users = new List<User>();
            _userRepo.Refresh();
            ViewBag.Users = _userRepo.Users;
        }
    }
}