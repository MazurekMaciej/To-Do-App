using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using Microsoft.Practices.Unity.Configuration;
using System.Configuration;
using Unity.log4net;

namespace ToDoList.Applications.ApplicationWinForms
{
    static class Program
    {
        private static UnityContainer _container;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (_container = new UnityContainer())
            {
                _container.LoadConfiguration();
                log4net.Config.XmlConfigurator.Configure();
                _container.AddNewExtension<Log4NetExtension>();
                DependencyResolver.Container = _container;
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(DependencyResolver.Container.Resolve<Form1>());
            }
        }
    }
}
