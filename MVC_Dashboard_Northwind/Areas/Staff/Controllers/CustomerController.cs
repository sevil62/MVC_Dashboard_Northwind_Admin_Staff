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
    
    public class CustomerController : Controller
    {
        // GET: Staff/Customer
        NorthwindEntities db = new NorthwindEntities();

        public ActionResult Index()
        {
            var customers = db.Customers.ToList();
            ViewBag.Customers = customers;
            return View();
        }
        public ActionResult AddCustomer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCustomer(Customer customer)
        {
            db.Customers.Add(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UpdateCustomer(int id)
        {
            Employee employee = db.Employees.Find(id);
            return View(employee);
        }
        [HttpPost]
        public ActionResult UpdateCustomer(Customer customer)
        {
            Customer tobeUpdated = db.Customers.Find(customer.CustomerID);
            db.Entry(tobeUpdated).CurrentValues.SetValues(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}