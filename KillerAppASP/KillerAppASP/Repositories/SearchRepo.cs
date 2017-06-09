using KillerAppASP.Contexts;
using KillerAppASP.Interfaces;
using KillerAppASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KillerAppASP.Repositories
{
    public class SearchRepo : IRepository<Search>
    {
        public List<Search> Items { get; set; }
        private readonly SearchContext _context;
        private IDatabaseConnector connector;

        public SearchRepo(IDatabaseConnector connector)
        {
            this.connector = connector;
            Items = new List<Models.Search>();
            _context = new SearchContext();
        }

        public void Add(Search item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Search item)
        {
            throw new NotImplementedException();
        }

        public Search GetItem(int ID)
        {
            throw new NotImplementedException();
        }

        public void Refresh()
        {
            throw new NotImplementedException();
        }

        public List<Search> Search(string SearchQuery)
        {
            
            Items = _context.Search(SearchQuery);
            return Items;
        }

        public void Update(Search item)
        {
            throw new NotImplementedException();
        }
    }
}