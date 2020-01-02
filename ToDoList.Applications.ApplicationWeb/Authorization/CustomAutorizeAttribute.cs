using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace ToDoList.Applications.ApplicationWeb.Authorization
{
    public class CustomAutorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (string.IsNullOrEmpty(Convert.ToString(filterContext.HttpContext.Session["User"])))
            {
                HandleUnauthorizedRequest(filterContext);
            }
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(
                      new RouteValueDictionary{{ "controller", "Errors" },
                                     { "action", "NotFound" },
                                     {"returnUrl", filterContext.HttpContext.Request.RawUrl }
                        });
        }
    }
}