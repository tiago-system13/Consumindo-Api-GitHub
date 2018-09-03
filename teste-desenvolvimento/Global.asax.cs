using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using teste_desenvolvimento.App_Start;

namespace teste_desenvolvimento
{
    public class MvcApplication : System.Web.HttpApplication
    {      
            protected void Application_Start()
            {
                AutofacConfig.Register();
                AreaRegistration.RegisterAllAreas();
                BundlesConfig.Register(BundleTable.Bundles);
                RouteConfig.RegisterRoutes(RouteTable.Routes);                
            }
        }    
}

