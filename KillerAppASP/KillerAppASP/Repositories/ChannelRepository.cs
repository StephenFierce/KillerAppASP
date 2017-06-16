using KillerAppASP.Contexts;
using KillerAppASP.Interfaces;
using KillerAppASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KillerAppASP.Repositories
{
    public class ChannelRepository : IRepository<Channel>
    {
        public List<Channel> Channels { get { return Items; } private set { Items = value; } }
        public List<Channel> Items { get; private set; }
        public Channel channel = new Channel();
        private readonly ChannelContext _context;

        public ChannelRepository(IDatabaseConnector connector)
        {
            _context = new ChannelContext(connector);
            Channels = new List<Channel>();
        }
        public void Add(Channel item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Channel item)
        {
            throw new NotImplementedException();
        }

        public Channel GetItem(int ID)
        {
            channel = _context.GetItem(ID);
            return channel;
        }

        public List<Channel> Read()
        {
           return _context.Read();
        }

        public void Update(Channel item)
        {
            _context.Update(item);
        }

        public void GoLive(int id)
        {
            _context.GoLive(id);
        }

        public List<Suggestion> GetSuggestions(int id)
        {
            return _context.GetSuggestions(id);
        }

        public void Refresh()
        {
            throw new NotImplementedException();
        }
    }
}