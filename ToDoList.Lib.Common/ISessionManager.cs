namespace ToDoList.Lib.Common
{
    public interface ISessionManager
    {
        string SessionToken
        {
            get;
            set;
        }
        void CreateSession(string key, object user);
        object GetSession();
        object GetCurrentSession(string key);
       // void SetSession(string key, User user);
        void RemoveSession(string token);

    }
}
