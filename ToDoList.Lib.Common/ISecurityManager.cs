using ToDoList.Lib.Common.DomainModel;

namespace ToDoList.Lib.Common
{
    public interface ISecurityManager
    {
        string Login(string userName, string password);
        void Logout(User user);
        int? GetLoggedUserId();
        bool IsLoggedIn();
        User GetLoggedUser();
        
    }
}
