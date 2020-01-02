using System.Web;
using Unity.Lifetime;

namespace ToDoList.Lib.Common.IoC.Unity
{
    public class SessionLifetimeManager : LifetimeManager
    {
        private string _key;

        public override object GetValue(ILifetimeContainer container = null)
        {
            return HttpContext.Current.Session[_key];
        }

        public override void RemoveValue(ILifetimeContainer container = null)
        {
            HttpContext.Current.Session.Remove(_key);
        }

        public override void SetValue(object newValue, ILifetimeContainer container = null)
        {
            HttpContext.Current.Session[_key] = newValue;
        }

        protected override LifetimeManager OnCreateLifetimeManager()
        {
            return new SessionLifetimeManager();
        }
    }
}
