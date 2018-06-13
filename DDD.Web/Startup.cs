using Microsoft.Owin.Security.Cookies;
using Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DDD.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType="ApplicationCookie",
                LoginPath=new PathString("/auth/Login")
            });

        }
    }
}