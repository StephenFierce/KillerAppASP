using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KillerAppASP.Models
{
    public class Search
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }

        public Search(string type, string name, string info)
        {
            Type = type;
            Name = name;
            Info = info;
        }
    }
}