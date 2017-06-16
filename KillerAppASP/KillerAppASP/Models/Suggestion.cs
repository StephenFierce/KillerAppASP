using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KillerAppASP.Models
{
    public class Suggestion
    {
        public string Title { get; set; }
        public string GameName { get; set; }
        public string GenreName { get; set; }
        public int Views { get; set; }
        public string ChannelName { get; set; }
        public string Username { get; set; }
    }
}