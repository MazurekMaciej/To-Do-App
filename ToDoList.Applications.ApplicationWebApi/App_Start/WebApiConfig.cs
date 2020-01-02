using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Unity;
using Unity.WebApi;
using System.Web.Http.Cors;
using System.Web.Http.Filters;

namespace ToDoList.Applications.ApplicationWebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            config.SuppressHostPrincipal(); //disable host-level authentication inside web api pipeline
            //config.Filters.Add(new AuthenticationFilter("Bearer"));

            config.MapHttpAttributeRoutes();

            var cors = new EnableCorsAttribute("http://localhost:51004", "*", "*");
            config.EnableCors(cors);
            // Web API routes

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
