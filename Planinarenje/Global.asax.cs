using Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Planinarenje
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private ILog _log;
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            UnityConfig.RegisterComponents();
        }
        protected void Application_Error()
        {
            var ex = Server.GetLastError();
            //log the error!
            _log = LogToFile.GetInstance;
            _log.Log(ex);
        }
    }
}
