using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KillerAppASP.Models
{
    public class Channel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Banner { get; set; }
        public string ProfilePicture { get; set; }
        public int Views { get; set; }

    }
}