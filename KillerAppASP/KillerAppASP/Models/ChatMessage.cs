using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KillerAppASP.Models
{
    public class ChatMessage
    {
        public int ChannelID { get; set; }
        public string Message { get; set; }
        public DateTime TimeStamp { get; set; }
        public int SentByUserID { get; set; }
    }
}