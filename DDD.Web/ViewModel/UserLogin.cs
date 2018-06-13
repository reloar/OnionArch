using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DDD.Web.ViewModel
{
    public class UserLogin
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public string ReturnUrl { get; set; }
    }
}