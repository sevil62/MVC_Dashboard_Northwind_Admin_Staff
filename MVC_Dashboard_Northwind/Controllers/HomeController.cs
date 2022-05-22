﻿
using MVC_Dashboard_Northwind.Models;
using MVC_Dashboard_Northwind.VMClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Dashboard_Northwind.Controllers
{
    public class HomeController : Controller
    {
        NorthwindEntities db=new NorthwindEntities();   

        // GET: Home
       
        
        public ActionResult Index()
        {
            var totalproduct=db.Products.Count();
            ViewBag.Products = totalproduct;


            var category = db.Categories.Count();
            ViewBag.Categories = category;

           
            TempData["Orders"] = db.Orders.ToList();
            TempData.Keep();


            return View();
        }
       
        public ActionResult Details(int id)
        {
            var orderDetails=db.Order_Details.FirstOrDefault(x=>x.OrderID==id);
            return View(orderDetails);
        }
       
    }
}