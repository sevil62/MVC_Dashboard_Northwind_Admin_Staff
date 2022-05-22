using MVC_Dashboard_Northwind.Areas.Admin.CustomFilter;
using MVC_Dashboard_Northwind.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Dashboard_Northwind.Areas.Admin.Controllers
{
   
    [AuthAdminFilter]
    public class OrderDetailController : Controller
    {
        // GET: Admin/OrderDetail
        NorthwindEntities db = new NorthwindEntities();
     
        public ActionResult Index()
        {
            var orderDetail = db.Order_Details.ToList();
            ViewBag.OrderDetails = orderDetail;
            return View();
        }
        public ActionResult AddOrderDetail()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddOrderDetail(Order_Detail order_Detail)
        {
            db.Order_Details.Add(order_Detail);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UpdateOrderDetail(int id)
        {
            Order_Detail order_Detail = db.Order_Details.Find(id);
            return View(order_Detail);
        }
        [HttpPost]
        public ActionResult UpdateOrderDetail(Order_Detail order_Detail)
        {
            Order_Detail tobeUpdated = db.Order_Details.Find(order_Detail.OrderID);
            db.Entry(tobeUpdated).CurrentValues.SetValues(order_Detail);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var order_Detail = db.Order_Details.Find(id);
            db.Order_Details.Remove(order_Detail);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}