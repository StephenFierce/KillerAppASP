using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KillerAppASP.Models
{
    public class Panel
    {
        public int ID { get; set; }
        public int ChannelID { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }

    }
}