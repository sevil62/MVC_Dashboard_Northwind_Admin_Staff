using MVC_Dashboard_Northwind.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Dashboard_Northwind.Areas.Admin.CustomFilter
{
    public class AuthAdminFilter : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            User user = filterContext.HttpContext.Session["admin"] as User;
            if (user.FirstName != "Sevil")
            {
                filterContext.Result = new RedirectResult("~/Employee/index");
            }
        }
    }
}