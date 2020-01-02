using log4net;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Lib.Common;
using ToDoList.Lib.Common.DomainModel;

namespace ToDoList.Lib.Business.Managers
{
    public class SessionManager : ISessionManager
    {
        ISessionContextManager _sessionContextManager;
        ILog _logManager;

        private static ConcurrentDictionary<string, object> _session = new ConcurrentDictionary<string, object>();
        public SessionManager(ILog logManager, ISessionContextManager sessionContextManager)
        {
            _logManager = logManager ?? throw new ArgumentNullException(nameof(logManager));
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
                _session[key] = user;
        }

        public void RemoveSession(string key)
        {
            if (String.IsNullOrEmpty(key))
                throw new ArgumentNullException(nameof(key));
            else
            {
                _session[key] = null;
                _sessionContextManager.RemoveSessionToken();
            }
        }

        public object GetCurrentSession(string key)
        {
            if (String.IsNullOrEmpty(key))
                throw new ArgumentNullException(nameof(key));
            else
            {
                return _session[key];
            }
        }

        public object GetSession()
        {
            return _session;
        }

    }
}
