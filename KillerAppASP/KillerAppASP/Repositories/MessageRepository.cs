using KillerAppASP.Contexts;
using KillerAppASP.Interfaces;
using KillerAppASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KillerAppASP.Repositories
{
    public class MessageRepository : IRepository<ChatMessage>
    {
        public List<ChatMessage> Messages { get { return Items; } private set { Items = value; } }
        public List<ChatMessage> Items { get; private set; }
        public Channel channel = new Channel();
        private readonly MessageContext _context;

        public MessageRepository(IDatabaseConnector connector)
        {
            _context = new MessageContext(connector);
            Messages = new List<ChatMessage>();
        }
        public void Add(ChatMessage item)
        {
            _context.Create(item);
        }

        public void Delete(ChatMessage item)
        {
            throw new NotImplementedException();
        }

        public ChatMessage GetItem(int ID)
        {
            throw new NotImplementedException();
        }
        public List<ChatMessage> GetItems(int channelID)
        {
            Items = _context.GetItems(channelID);
            return Items;
        }

        public void Refresh()
        {
            _context.Read();
        }

        public void Update(ChatMessage item)
        {
            throw new NotImplementedException();
        }
    }
}