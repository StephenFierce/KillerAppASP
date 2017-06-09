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
        public ActionResult Edit(int ID)
        {
            ViewBag.CurrentUser = _userRepo.GetItem(ID);
            return View();
        }

        [HttpPost]
        public ActionResult Edit(int id, string username, string password, string dateofbirth, string email, string displayname, string bio, string offlinebanner, string forbiddenwords)
        {
            _userRepo = new UserRepo(connector);
            User u = new User()
            {
                ID = id,
                Username = username,
                Password = password,
                DateofBirth = Convert.ToDateTime(dateofbirth),
                Email = email,
                DisplayName = displayname,
                Bio = bio,
                OfflineBanner = offlinebanner,
                ForbiddenWords = forbiddenwords
            };
            _userRepo.Update(u);
            Session["LoggedIn"] = u;
            return View("Index");
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