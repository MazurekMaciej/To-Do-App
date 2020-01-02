using System;
using System.Windows.Forms;
using ToDoList.Lib.Common;
using ToDoList.Lib.Common.DomainModel;
using ToDoList.Lib.Common.Exceptions;

namespace ToDoList.Applications.ApplicationWinForms
{
    class Account
    {
        ISecurityManager _securityManager;
        IAccountManager _accountManager;

        public Account(IAccountManager accountManager, ISecurityManager securityManager)
        {
            _accountManager = accountManager ?? throw new ArgumentNullException(nameof(accountManager));
            _securityManager = securityManager ?? throw new ArgumentNullException(nameof(securityManager));
        }

        public void LogIn(string name, string password)
        {
            try
            {
                _securityManager.Login(name, password);
                Form1.IsLoggedIn = true;
                MessageBox.Show("You successfully logged in");
            }
            catch(UserNameNotFoundException e)
            {
                MessageBox.Show(e.Message);
            }
            catch(PasswordInvalidException e)
            {
                MessageBox.Show(e.Message);
            }
            catch
            {
                MessageBox.Show("Something went wrong");
            }
        }

        public void Register(string username, string password)
        {
            User user = new User
            {
                Username = username,
                Password = password
            };
            try
            {
                _accountManager.Register(user);
                MessageBox.Show("You successfully registered. Now you can Log in");
            }
            catch (RegistrationException e)
            {
                MessageBox.Show(e.Message);
            }
            catch
            {
                MessageBox.Show("Try again with different credentials");
            }

        }
    }
}
