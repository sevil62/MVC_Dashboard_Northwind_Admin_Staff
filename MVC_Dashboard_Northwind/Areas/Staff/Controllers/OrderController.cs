
using MVC_Dashboard_Northwind.Areas.Admin.CustomFilter;
using MVC_Dashboard_Northwind.Areas.Staff.CustomFilter;
using MVC_Dashboard_Northwind.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Dashboard_Northwind.Areas.Staff.Controllers
{
    [AuthStaffFilter]
   
    public class OrderController : Controller
    {
        // GET: Staff/Order
        NorthwindEntities db = new NorthwindEntities();

        public ActionResult Index()
        {
            var orders = db.Orders.ToList();
            ViewBag.Orders = orders;
            return View();
        }
        public ActionResult AddOrder()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddOrder(Order order)
        {
            db.Orders.Add(order);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UpdateOrder(int id)
        {
            Order order = db.Orders.Find(id);
            return View(order);
        }
        [HttpPost]
        public ActionResult UpdateOrder(Order order)
        {
            Order tobeUpdated = db.Orders.Find(order.OrderID);
            db.Entry(tobeUpdated).CurrentValues.SetValues(order);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var order = db.Orders.Find(id);
            db.Orders.Remove(order);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}