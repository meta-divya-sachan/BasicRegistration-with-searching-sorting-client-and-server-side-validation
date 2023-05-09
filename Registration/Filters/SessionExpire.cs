using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
//using TicketManagement.Helpers;

namespace Registration.Filters
{
    public class SessionExpire : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
           // if (HttpContext.Current.Session["_USERDATA"] == null || string.IsNullOrEmpty(HttpContext.Current.Session["_USERDATA"].ToString()))
           // { 

                filterContext.Result =
                new RedirectToRouteResult(new RouteValueDictionary
                {
                    {"action", "Login" },
                    {"controller", "Users" },
                });
            return;
       // }
        }
    }
}