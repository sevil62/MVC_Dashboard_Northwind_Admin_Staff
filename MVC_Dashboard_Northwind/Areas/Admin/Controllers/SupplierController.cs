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
    public class SupplierController : Controller
    {
        // GET: Admin/Supplier
        NorthwindEntities db = new NorthwindEntities();

        public ActionResult Index()
        {
            var suppliers = db.Suppliers.ToList();
            ViewBag.Suppliers = suppliers;
            return View();
        }
        public ActionResult AddSupplier()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSupplier(Supplier supplier)
        {
            db.Suppliers.Add(supplier);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UpdateSupplier(int id)
        {
            Supplier supplier = db.Suppliers.Find(id);
            return View(supplier);
        }
        [HttpPost]
        public ActionResult UpdateSupplier(Supplier supplier)
        {
            Supplier tobeUpdated = db.Suppliers.Find(supplier.SupplierID);
            db.Entry(tobeUpdated).CurrentValues.SetValues(supplier);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var supplier = db.Suppliers.Find(id);
            db.Suppliers.Remove(supplier);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}