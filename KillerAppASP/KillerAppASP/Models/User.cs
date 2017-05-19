using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KillerAppASP.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public DateTime DateofBirth { get; set; }
        public bool Partner { get; set; }
        public string DisplayName { get; set; }
        public string Bio { get; set; }
        public string OfflineBanner { get; set; }
        public string ForbiddenWords { get; set; }


    }
}