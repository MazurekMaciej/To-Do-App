using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using ToDoList.Lib.Common;

namespace ToDoList.Applications.ApplicationWebApi.Authorize
{
    public class CustomAutorization : AuthorizeAttribute
    {

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            try
            {
                var sessionContextManager = (ISessionContextManager)GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(ISessionContextManager));
                var securityManager = (ISecurityManager)GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(ISecurityManager));

                if (!actionContext.Request.Headers.Contains("Authorization"))
                    actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);

                //if (actionContext.Request.Headers.Authorization != null &&
                //    !String.IsNullOrEmpty(actionContext.Request.Headers.Authorization.Parameter))
                //{
                string token = actionContext.Request.Headers.Authorization.Parameter;

                sessionContextManager.SetSessionToken(token);

                if (securityManager.GetLoggedUser() != null)
                    return;
                // }
            }
            catch (Exception)
            {
                actionContext.Response = new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.Unauthorized,
                    Content = new StringContent("You are unauthorized to access this resource")
                };

            }
        }
    }
}