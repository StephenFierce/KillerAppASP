using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KillerAppASP.Models
{
    public class Video
    {
        public int ID { get; set; }
        public int GameID { get; set; }
        public int ChannelID { get; set; }
        public string Description { get; set; }
        public string Tags { get; set; }
        public string Thumbnail { get; set; }
        public string Language { get; set; }


    }
}