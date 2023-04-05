using eUseControl.Web1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eUseControl.Web1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            UserData u = new UserData();
            u.UserName = "Customer";
            u.Products = new List<string> { "Product #1", "Product #2", "Product #3", "Product #4" };
            return View(u);

        }

        public ActionResult IndexAdmin()
        {
            UserData a = new UserData();
            a.UserName = "Admin";
            a.Products = new List<string> { "Product #1", "Product #2", "Product #3", "Product #4" };
            return View(a);

        }

        public ActionResult policy()
        {
            return View();
        }
        public ActionResult registration()
        {
            return View();
        }

        public ActionResult accessories()
        {
            return View();
        }

        public ActionResult checkout()
        {
            return View();
        }

        public ActionResult otzivi()
        {
            return View();
        }

        public ActionResult predproduct()
        {
            return View();
        }

        public ActionResult product1()
        {
            return View();
        }

        public ActionResult product2()
        {
            return View();
        }
       
        public ActionResult product3()
        {
            return View();
        }

        public ActionResult product4()
        {
            return View();
        }
        public ActionResult Store()
        {
            return View();
        }

        public ActionResult HotProduct()
        {
            return View();
        }
    }
}