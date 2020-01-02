using Unity;
using Microsoft.Practices.Unity.Configuration;
using System.Web.Http;
using Unity.log4net;

namespace ToDoList.Applications.ApplicationWebApi
{
    public static class UnityConfig
    {
       //  public static IUnityContainer container => new UnityContainer();

        public static void RegisterComponents()
        {
            var container = new UnityContainer();
            log4net.Config.XmlConfigurator.Configure();
        
            container.AddNewExtension<Log4NetExtension>();
            container.LoadConfiguration();

          //  HttpConfiguration httpConfiguration = new HttpConfiguration();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
           // httpConfiguration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}