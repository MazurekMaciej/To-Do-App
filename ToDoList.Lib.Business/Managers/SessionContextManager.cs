using ToDoList.Lib.Common;

namespace ToDoList.Lib.Business.Managers
{
    public class SessionContextManager : ISessionContextManager
    {
        private string _sessionToken;
        public string GetSessionToken()
        {
            return _sessionToken;
        }

        public void SetSessionToken(string token)
        {
            _sessionToken = token;
        }

        public void RemoveSessionToken()
        {
            _sessionToken = null;
        }

    }
}
