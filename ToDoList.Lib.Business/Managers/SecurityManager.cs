using System;
using System.Linq;
using ToDoList.Lib.Common;
using ToDoList.Lib.Common.DomainModel;
using ToDoList.Lib.Data;
using ToDoList.Lib.Common.Exceptions;
using log4net;

namespace ToDoList.Lib.Business.Managers
{
    public class SecurityManager : ISecurityManager
    {
        ILog _logManager;
        ISessionManager _sessionManager;
        public SecurityManager(ILog logManager, ISessionManager sessionManager)
        {
            _logManager = logManager ?? throw new ArgumentNullException(nameof(logManager));
            _sessionManager = sessionManager ?? throw new ArgumentNullException(nameof(sessionManager));
        }
        public string Login(string userName, string password)
        {
            ToDoContext dbContext = new ToDoContext();
            _logManager.Debug("Login process started");
            var user = dbContext.Users.Where(u => u.Username == userName).SingleOrDefault();
            _logManager.Debug("User with provided username found");
            if (user != null)
            {
                if (password == user.Password)
                {
                    _logManager.Info("Provided credentials are valid ");
                    string token = Guid.NewGuid().ToString();
                    _sessionManager.SessionToken = token;
                    _sessionManager.CreateSession("User", user);

                    dbContext.Entry<User>(user).State = System.Data.Entity.EntityState.Detached;

                    _logManager.Info("User sucsesfully logged in: " + user.Id +" "+user.Username + " " + user.Password);
                    _logManager.Debug("Login process ended successfully");
                    return _sessionManager.SessionToken;              
                }
                else
                {
                    _logManager.Error("Invalid password");
                    throw new PasswordInvalidException("Invalid password");                   
                }
            }
            else
            {
                _logManager.Error("User cannot be found");
                throw new UserNameNotFoundException("User cannot be found");
            }
        }

        public void Logout(User user)
        {
            _logManager.Debug("Logout process started");
            if(!IsLoggedIn())
            {
                _logManager.Error("No user currently logged in");
                throw new UserNotFoundException("User is not logged in");
            }
            _sessionManager.RemoveSession("User");
            _logManager.Info("User logged out");
            _logManager.Debug("Logout process ended successfully");
        }

        
        public int? GetLoggedUserId()
        {
            _logManager.Debug("Returning logged user id");
            User user = GetLoggedUser();
            return user.Id;
        }

        public bool IsLoggedIn()
        {
            _logManager.Debug("Checking if user is logged in");
            return (User)_sessionManager.GetCurrentSession("User") != null;
        }

        public User GetLoggedUser()
        {
            if((User)_sessionManager.GetCurrentSession("User") == null)
                throw new UserNotFoundException("No logged user found");
            else
            return (User)_sessionManager.GetCurrentSession("User");
            
        }

    }
}
