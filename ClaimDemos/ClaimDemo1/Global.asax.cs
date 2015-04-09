using System;
using System.Collections.Generic;
using System.IdentityModel.Configuration;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ClaimDemo1
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_AuthenticateRequest()
        {

        }

        protected void Application_PostAuthenticateRequest()
        {
            var config = new IdentityConfiguration();
            var newPrincipal = config.ClaimsAuthenticationManager
                                                .Authenticate(null,ClaimsPrincipal.Current);
            Thread.CurrentPrincipal = newPrincipal;

            if (HttpContext.Current != null)
                HttpContext.Current.User = newPrincipal;
        }
    }
}
