using KillerAppASP.Interfaces;
using KillerAppASP.Models;
using KillerAppASP.Repositories;
using Santhos.Web.Mvc.BootstrapFlashMessages;
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
        private MessageRepository _messageRepo;
        private IDatabaseConnector connector;

        public ActionResult Index(int id)
        {
            User u = new Models.User()
            {
                ID = id
            };
            InitializeRepos();
            ViewBag.AllUsers = _userRepo.RefreshUsers();
            ViewBag.AllChannels = _channelRepo.Read();
            ViewBag.ChatMessages = _messageRepo.GetItems(id);
            ViewBag.ChannelDetails = _channelRepo.GetItem(u.ID);
            ViewBag.Suggestions = _channelRepo.GetSuggestions(u.ID);
            return View();
        }
        public ActionResult EditChannel(int ID)
        {
            InitializeRepos();
            User u = _userRepo.GetItem(ID);
            ViewBag.ChannelDetails = _channelRepo.GetItem(u.ID);
            return View();
        }
        [HttpPost]
        public ActionResult EditChannel(int id, string name, string banner, string profilePicture)
        {
            try
            {
                InitializeRepos();
                Channel c = new Channel()
                {
                    ID = id,
                    Name = name,
                    Banner = banner,
                    ProfilePicture = profilePicture
                };
                _channelRepo.Update(c);
                ViewBag.ChannelDetails = c;
                this.FlashSuccess("Het bericht is verstuurd.");
                return View("EditChannel", c.ID);
            }
            catch (Exception)
            {
                this.FlashDanger("Het bericht is niet verstuurd, probeer het opnieuw.");
                return View("EditChannel", id);
            }
            
        }
        [HttpPost]
        public ActionResult SendMessage(int cid, int id, string message)
        {
            try
            {
                ChatMessage cm = new ChatMessage()
                {
                    SentByUserID = id,
                    Message = message,
                    TimeStamp = DateTime.Now,
                    ChannelID = cid
                };
                User u = new Models.User()
                {
                    ID = id
                };
                InitializeRepos();
                _messageRepo.Add(cm);
                ViewBag.AllUsers = _userRepo.RefreshUsers();
                ViewBag.AllChannels = _channelRepo.Read();
                ViewBag.ChatMessages = _messageRepo.GetItems(id);
                ViewBag.ChannelDetails = _channelRepo.GetItem(u.ID);
                ViewBag.Suggestions = _channelRepo.GetSuggestions(u.ID);
                this.FlashSuccess("Het bericht is verstuurd.");
            }
            catch (Exception)
            {
                this.FlashDanger("Het bericht is niet verstuurd, probeer het opnieuw.");
            }

            return View("Index");
        }

        public void InitializeRepos()
        {
            _messageRepo = new MessageRepository(connector);
            _userRepo = new UserRepo(connector);
            _channelRepo = new ChannelRepository(connector);
        }

        public ActionResult GoLive(int id)
        {
            try
            {
                User u = new Models.User()
                {
                    ID = id
                };
                InitializeRepos();
                ViewBag.AllUsers = _userRepo.RefreshUsers();
                ViewBag.AllChannels = _channelRepo.Read();
                ViewBag.ChatMessages = _messageRepo.GetItems(id);
                ViewBag.ChannelDetails = _channelRepo.GetItem(u.ID);
                ViewBag.Suggestions = _channelRepo.GetSuggestions(u.ID);
                _channelRepo.GoLive(id);
                this.FlashSuccess("Je bent nu live!");
            }
            catch (Exception)
            {
                this.FlashDanger("Het live gaan is niet gelukt!");
            }


            return View("Index");
        }
    }
}