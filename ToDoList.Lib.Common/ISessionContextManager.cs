namespace ToDoList.Lib.Common
{
    public interface ISessionContextManager
    {
        string GetSessionToken();
        void SetSessionToken(string token);
        void RemoveSessionToken();
    }
}
