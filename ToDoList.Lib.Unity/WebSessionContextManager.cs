using System;
using System.Web;

namespace ToDoList.Lib.Common.IoC.Unity
{
    public class WebSessionContextManager : ISessionManager
    {
        ISessionContextManager _sessionContextManager;
        public WebSessionContextManager(ISessionContextManager sessionContextManager)
        {
            _sessionContextManager = sessionContextManager ?? throw new ArgumentNullException(nameof(sessionContextManager));
        }
        public string SessionToken { get => _sessionContextManager.GetSessionToken(); set => _sessionContextManager.SetSessionToken(value); }

        public object GetCurrentSession(string key)
        {
            if (String.IsNullOrEmpty(key))
                throw new ArgumentNullException(nameof(key));

            CheckContext();
            return (object)HttpContext.Current.Session[key];
        }

        public void RemoveSession(string key)
        {
            if (String.IsNullOrEmpty(key))
                throw new ArgumentNullException(nameof(key));
            CheckContext();
            HttpContext.Current.Session[key] = null;
        }

        public void CreateSession(string key, object data)
        {
            if (String.IsNullOrEmpty(key))
                throw new ArgumentNullException(nameof(key));
            CheckContext();
            HttpContext.Current.Session[key] = data;
        }

        private void CheckContext()
        {
            if (HttpContext.Current == null)
                throw new ApplicationException("HttpContext.Current is null");

            if (HttpContext.Current.Session == null)
                throw new ApplicationException("HttpContext.Current.Session is null");
        }

        public object GetSession()
        {
            throw new NotImplementedException();
        }
    }
}