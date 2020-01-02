using System.Web.Http;
using Unity;
using Unity.WebApi;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(ToDoList.Applications.ApplicationWebApi.UnityWebApiActivator), nameof(ToDoList.Applications.ApplicationWebApi.UnityWebApiActivator.Start))]
[assembly: WebActivatorEx.ApplicationShutdownMethod(typeof(ToDoList.Applications.ApplicationWebApi.UnityWebApiActivator), nameof(ToDoList.Applications.ApplicationWebApi.UnityWebApiActivator.Shutdown))]

namespace ToDoList.Applications.ApplicationWebApi
{
    /// <summary>
    /// Provides the bootstrapping for integrating Unity with WebApi when it is hosted in ASP.NET.
    /// </summary>
    public static class UnityWebApiActivator
    {
        /// <summary>
        /// Integrates Unity when the application starts.
        /// </summary>
        public static void Start()
        {
            UnityConfig.RegisterComponents();
            // GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver();
            // GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }

        /// <summary>
        /// Disposes the Unity container when the application is shut down.
        /// </summary>
        public static void Shutdown()
        {
            var container = new UnityContainer();
            container.Dispose();
        }
    }
}