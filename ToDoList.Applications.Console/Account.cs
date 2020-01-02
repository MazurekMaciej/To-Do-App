using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Lib.Business.Managers;
using ToDoList.Lib.Common;
using ToDoList.Lib.Common.DomainModel;
using Unity;

namespace ToDoList.Applications.ApplicationConsole
{
    public class Account
    {
        ISecurityManager _securityManager;
        IAccountManager _accountManager;

        public Account(ISecurityManager securityManager, IAccountManager accountManager)
        {
            _securityManager = securityManager ?? throw new ArgumentNullException(nameof(securityManager));
            _accountManager = accountManager ?? throw new ArgumentNullException(nameof(accountManager));
        }

        public void Register()
        {
            Console.WriteLine("Write username:");
            string username = Console.ReadLine();
            Console.WriteLine("Write your password: ");
            string password = Console.ReadLine();
            User user = new User { Username = username, Password = password };

            try
            {
                _accountManager.Register(user);
                Console.WriteLine("You registered successfully");
                Console.WriteLine("Now you can log in");
                LogIn();
            }
            catch
            {
                Console.WriteLine("You did not reigstered");
                System.Threading.Thread.Sleep(1000);
                Console.Clear();
                Program.Start();
            }
            System.Threading.Thread.Sleep(1000);
            Console.Clear();
           // Program.Start();
            MenuOption.MainMenu();
        }


        public void LogIn()
        {
            Console.WriteLine("Write your username: ");
            string username = Console.ReadLine();
            Console.WriteLine("Write your password: ");
            string password = Console.ReadLine();
            try
            {
                _securityManager.Login(username, password);
                Console.WriteLine("You logged in successfully");
                Console.WriteLine("Displaying main menu......");
            }
            catch
            {
                Console.WriteLine("Wrong credentials");
                System.Threading.Thread.Sleep(1000);
                Console.Clear();
                Program.Start();
            }
            System.Threading.Thread.Sleep(1000);
            Console.Clear();
            MenuOption.MainMenu();
        }

        public void LogOut()
        {
            Console.WriteLine("Good bye");
            _securityManager.Logout(_securityManager.GetLoggedUser());
            Environment.Exit(0);
        }

    }
}
