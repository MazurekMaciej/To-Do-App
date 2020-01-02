using System;
using ToDoList.Lib.Common;
using ToDoList.Lib.Common.DomainModel;
using ToDoList.Lib.Data;
using ToDoList.Lib.Common.Exceptions;
using log4net;

namespace ToDoList.Lib.Business.Managers
{
    public class AccountManager : IAccountManager
    {
        ILog _logManager;
        public AccountManager(ILog logManager)
        {
            _logManager = logManager ?? throw new ArgumentNullException(nameof(logManager));
        }

        public void Register(User user)
        {
            ToDoContext dbContext = new ToDoContext();
            _logManager.Debug("Register start");
            if (user.Username == "" || user.Password == "")
            {
                _logManager.Error("Registration error. Not created. Username/passoword not provided");
                throw new RegistrationException("Registration error. Username/passoword not provided");
            }
            else
            {
                try
                {
                    _logManager.Debug("Starting to create a new user");
                    dbContext.Users.Add(user);
                    dbContext.SaveChanges();
                    _logManager.Info("User created successfully");
                    _logManager.Debug("Register ended succesfully");
                }
                catch (Exception)
                {
                    _logManager.Error("Registration failed");
                    _logManager.Debug("Data which've been used to perform registration that failed: " + "Username: " + user.Username + " Password: " + user.Password);
                    throw new RegistrationException("Registration failed. User already exists");
                }
            }
        }
    }
}
