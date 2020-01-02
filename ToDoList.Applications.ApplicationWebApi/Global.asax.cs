﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ToDoList.Applications.ApplicationWebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
           // AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
           // FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
           // BundleConfig.RegisterBundles(BundleTable.Bundles);
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings
                              .ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            GlobalConfiguration.Configuration.Formatters
               .Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);

         //   UnityConfig.RegisterComponents(); //unity + app_start.unityconfig
           // log4net.Config.XmlConfigurator.Configure();

        }
    }
}
