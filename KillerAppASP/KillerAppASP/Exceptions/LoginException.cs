using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KillerAppASP.Exceptions
{
    public class LoginException : Exception
    {
        public LoginException(string message) : base(message) { }
    }
}