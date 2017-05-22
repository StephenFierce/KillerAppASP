﻿using KillerAppASP.Contexts;
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
        public List<User> Items { get; private set; }
        private readonly UserContext _context;

        public UserRepo(IDatabaseConnector connector)
        {
            _context = new UserContext(connector);
            Items = new List<User>();
        }
        public void Add(User item)
        {
            throw new NotImplementedException();
        }

        public void Delete(User item)
        {
            throw new NotImplementedException();
        }

        public void GetItem(int ID)
        {
            throw new NotImplementedException();
        }

        public void Refresh()
        {
            Items = _context.Read();
        }

        public void Update(User item)
        {
            throw new NotImplementedException();
        }
    }
}