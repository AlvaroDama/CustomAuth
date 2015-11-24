using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using CustomAuth.Security;

namespace CustomAuth
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_PostAuthenticateRequest(object sender, EventArgs e)
        {
            if (Request.IsAuthenticated)
            {
                var identity = new CustomIdentity(HttpContext.Current.User.Identity);
                var principal = new CustomPrincipal(identity);
                HttpContext.Current.User = principal;
            }
        }
    }
}
