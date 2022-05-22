using MVC_Dashboard_Northwind.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Dashboard_Northwind.Areas.Staff.CustomFilter
{
    public class AuthStaffFilter : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            User user = filterContext.HttpContext.Session["staff"] as User;
            if (user.FirstName != "Tuba")
            {
                filterContext.Result = new RedirectResult("~/Order/index");
            }
        }
    }
}