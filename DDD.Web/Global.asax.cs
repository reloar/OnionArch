using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;
using DDD.Infrastructure;
using DDD.Web.App_Start;

namespace DDD.Web
{
    public class Global : HttpApplication
    {
       protected void Application_Start()
        {
            // Code that runs on application startup

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //FilterConfig.Configure(GlobalFilters.Filters);
        }
    }
}