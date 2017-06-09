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
    public class ChannelController : Controller
    {
        // GET: Channel
        private ChannelRepository _channelRepo;
        private UserRepo _userRepo;
        private IDatabaseConnector connector;

        public ActionResult Index(int ID)
        {
            User u = new Models.User()
            {
                ID = ID
            };
            _channelRepo = new ChannelRepository(connector);
            ViewBag.ChannelDetails = _channelRepo.GetItem(u.ID);
            return View();
        }
        public ActionResult EditChannel(int ID)
        {
            _userRepo = new UserRepo(connector);
            _channelRepo = new ChannelRepository(connector);
            User u = _userRepo.GetItem(ID);
            ViewBag.ChannelDetails = _channelRepo.GetItem(u.ID);
            return View();
        }
        [HttpPost]
        public ActionResult EditChannel(int id, string name, string banner, string profilePicture)
        {
            _channelRepo = new ChannelRepository(connector);
            Channel c = new Channel()
            {
                ID = id,
                Name = name,
                Banner = banner,
                ProfilePicture = profilePicture
            };
            _channelRepo.Update(c);
            ViewBag.ChannelDetails = c;
            return View("EditChannel", c.ID);
        }
        // 
        // GET: /HelloWorld/Welcome/ 

        public string Welcome()
        {
            return "This is the Welcome action method...";
        }
    }
}