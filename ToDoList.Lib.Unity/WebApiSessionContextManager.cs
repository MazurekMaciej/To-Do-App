using System;
using System.Collections.Concurrent;
using ToDoList.Lib.Common.DomainModel;

namespace ToDoList.Lib.Common.IoC.Unity
{
    public class WebApiSessionContextManager : ISessionManager
    {
        ISessionContextManager _sessionContextManager;

        //[ThreadStatic]
        private static ConcurrentDictionary<string, object> _session = new ConcurrentDictionary<string, object>();
        public WebApiSessionContextManager(ISessionContextManager sessionContextManager)
        {
            _sessionContextManager = sessionContextManager ?? throw new ArgumentNullException(nameof(sessionContextManager));
        }

        public string SessionToken
        {
            get
            {
                return _sessionContextManager.GetSessionToken();
            }
            set
            {
                _sessionContextManager.SetSessionToken(value);
            }
        }

        public void CreateSession(string key, object user)
        {
            if (String.IsNullOrEmpty(key))
                throw new ArgumentNullException(nameof(key));
            else
                _session[String.Format("{0}___{1}", (SessionToken ?? ""), key)] = user;
        }

        public void RemoveSession(string key)
        {
            if (String.IsNullOrEmpty(key))
                throw new ArgumentNullException(nameof(key));
            else
            {
                var tokenkey = String.Format("{0}___{1}", (SessionToken ?? ""), key);
                _session[tokenkey] = null;
                _sessionContextManager.RemoveSessionToken();
            }
        }
        public object GetCurrentSession(string key)
        {
            if (String.IsNullOrEmpty(key))
                throw new ArgumentNullException(nameof(key));
            else
            {
                var tokenkey = String.Format("{0}___{1}", (SessionToken ?? ""), key);
                try
                {
                    return _session[tokenkey];
                }
                catch
                {
                    User user = null;
                    return user;
                }
            }
        }

        public object GetSession()
        {
            return _session;
        }
    }
}
