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
    public class SearchController : Controller
    {
        private SearchRepo _searchRepo;

        private IDatabaseConnector connector;
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Search(string SearchQuery)
        {
            try { 
            _searchRepo = new SearchRepo(connector);
            List<Search> users = new List<Search>();
            ViewBag.SearchResults = _searchRepo.Search(SearchQuery);
                this.FlashSuccess("Het zoeken is gelukt!");
            }
            catch (Exception)
            {
                this.FlashDanger("Het zoeken is mislukt, probeer het opnieuw.");
            }
            return View("Index");
        }
    }
}