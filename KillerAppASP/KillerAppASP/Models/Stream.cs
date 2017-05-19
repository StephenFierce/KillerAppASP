using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KillerAppASP.Models
{
    public class Stream
    {
        public int ID { get; set; }
        public int ChannelID { get; set; }
        public int GameID { get; set; }
        public string Title { get; set; }
        public bool Live { get; set; }

    }
}