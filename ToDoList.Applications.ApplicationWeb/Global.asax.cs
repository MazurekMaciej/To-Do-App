using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using ToDoList.Applications.ApplicationWeb.Controllers;

namespace ToDoList.Applications.ApplicationWeb
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Session_End()
        {
           // dispose the session scope of SessionLifeTimeManager
        }

        //protected void Application_Error()
        //{
        //    if (Context.Response.StatusCode == 404 || Context.Response.StatusCode == 403 || Context.Response.StatusCode == 500)
        //    {
        //        Response.Clear();

        //        var rd = new RouteData();
        //        //rd.DataTokens["area"] = "AreaName"; // In case controller is in another area
        //        rd.Values["controller"] = "Errors";
        //        rd.Values["action"] = "NotFound";

        //        IController c = new ErrorsController();
        //        c.Execute(new RequestContext(new HttpContextWrapper(Context), rd));
        //    }
        //}
    }
}
