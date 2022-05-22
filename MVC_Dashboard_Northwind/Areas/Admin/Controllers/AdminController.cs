using MVC_Dashboard_Northwind.Models;
using MVC_Dashboard_Northwind.VMClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Dashboard_Northwind.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        NorthwindEntities db = new NorthwindEntities();

        // GET: Admin/Admin
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(AppUserVM appUserVM)
        {
            if (ModelState.IsValid)
            {
                bool result = db.Users.Any(x => x.FirstName == appUserVM.UserName && x.Password == appUserVM.Password);
                if (result)
                {
                    User user = db.Users.Where(x => x.FirstName == appUserVM.UserName && x.Password == appUserVM.Password).FirstOrDefault();
                    Session["admin"] = user;
                    return RedirectToAction("index", "Employee");

                }

                else
                {
                    TempData["error"] = "Kullanıcı bilgileri hatalıdır";
                    return View(appUserVM);
                }

            }
            else
            {
                return View(appUserVM);
            }
        }

    }
}