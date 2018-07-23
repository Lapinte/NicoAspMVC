using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Mvc;

namespace Roomax.Filters
{
    public class AuthenticationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session["USER_BO"] == null)
            {
                filterContext.Result = new RedirectResult("\\BackOffice\\Authentication\\Login");
                //filterContext.Result = new RedirectToRouteResult(new { controller = "Authentication", action = "Login", area = "BackOffice" });
            }
        }
    }
}