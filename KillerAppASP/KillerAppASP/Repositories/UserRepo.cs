using KillerAppASP.Contexts;
using KillerAppASP.Interfaces;
using KillerAppASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KillerAppASP.Repositories
{
    public class UserRepo : IRepository<User>
    {
        public List<User> Users { get { return Items; } private set { Items = value; } }
        public List<User> Items { get; private set; }
        public User user = new User();
        private readonly UserContext _context;

        public UserRepo(IDatabaseConnector connector)
        {
            _context = new UserContext(connector);
            Users = new List<User>();
        }
        public void Add(User item)
        {
            throw new NotImplementedException();
        }

        public void Delete(User item)
        {
            throw new NotImplementedException();
        }

        public User GetItem(int ID)
        {
            user = _context.GetItem(ID);
            return user;
        }

        public List<User> RefreshUsers()
        {
            Users = _context.Read();
            return Users;
        }

        public void Refresh()
        {

        }

        public void Update(User item)
        {
            _context.Update(item);
        }
    }
}