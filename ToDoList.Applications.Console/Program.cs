using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Lib.Common.DomainModel;
using ToDoList.Lib.Business.Managers;
using ToDoList.Lib.Common;
using Unity;
using Microsoft.Practices.Unity.Configuration;
using System.Configuration;
using Unity.log4net;

namespace ToDoList.Applications.ApplicationConsole
{
    class Program
    {   
        private static bool _startup = true;
        public static void Start()
        {
            System.Threading.Thread.Sleep(1000);
            Account account = DependencyResolver.Container.Resolve<Account>();
            string choice;
            
            while (_startup == true)
            {
                Console.WriteLine("Login (If you don't have an account type Register)");
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "register":
                        account.Register();
                        _startup = false;
                        break;
                    case "login":
                        account.LogIn();
                        _startup = false;
                        break;
                    default:
                        Console.WriteLine("Error, please repeat.");
                        Console.WriteLine();
                        break;
                }

            }
        }
         static void Main(string[] args)
        {
            using (UnityContainer container = new UnityContainer())
            {
                container.LoadConfiguration();
                log4net.Config.XmlConfigurator.Configure();
                container.AddNewExtension<Log4NetExtension>();
                DependencyResolver.Container = container;               

                Start();
                Console.ReadKey();
            }
        }

    }
}
