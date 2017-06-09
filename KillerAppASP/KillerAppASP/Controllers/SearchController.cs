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
            _searchRepo = new SearchRepo(connector);
            List<Search> users = new List<Search>();
            ViewBag.SearchResults = _searchRepo.Search(SearchQuery);
            
            return View("Index");
        }
    }
}