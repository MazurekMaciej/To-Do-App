using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Unity.Lifetime;

namespace ToDoList.Lib.Common.IoC.Unity
{
    public class PerRequestLifetimeManager : LifetimeManager
    {
        private readonly object _key = new object();
        ISubscriptionToken _disposeToken;
        public override object GetValue(ILifetimeContainer container = null)
        {
            if (HttpContext.Current == null)
                throw new InvalidOperationException("HttpContext not available");

            return HttpContext.Current.Items[_key];
        }

        public override void SetValue(object newValue, ILifetimeContainer container = null)
        {
            if (HttpContext.Current == null)
                throw new InvalidOperationException("HttpContext not available");
            HttpContext.Current.Items[_key] = newValue;
            if (newValue as IDisposable != null)
                _disposeToken = HttpContext.Current.DisposeOnPipelineCompleted(newValue as IDisposable);
        }

        public override void RemoveValue(ILifetimeContainer container = null)
        {
            var disposable = GetValue() as IDisposable;

            disposable?.Dispose();

            HttpContext.Current.Items.Remove(_key);
        }

        protected override LifetimeManager OnCreateLifetimeManager()
        {
            return new PerRequestLifetimeManager();
        }
    }
}
