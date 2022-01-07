using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace WebProj
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            
            List<string> messages = new List<string>();
            Application["Users"] = 0;
            HttpContext.Current.Cache["Messages"] = messages;
            Application["Url"] = "";
            
        }

        protected void Session_Start()
        {

            Application["Users"] = (int)Application["Users"] + 1;
        }

        
    }
}
