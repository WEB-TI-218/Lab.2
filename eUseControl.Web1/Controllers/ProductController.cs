using eUseControl.BusinessLogic;
using eUseControl.BusinessLogic.DBModel;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.Domain.Entities.Product;
using eUseControl.Domain.Entities.Responces;
using eUseControl.Domain.Entities.User;
using eUseControl.Web1.Attributes;
using eUseControl.Web1.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace eUseControl.Web1.Controllers
{

    public class ProductController : Controller
    {

        //FeedbackContext db = new FeedbackContext();
        [HttpGet]
        public ActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        [AdminMod]
        public ActionResult AddProduct(PDbTable product)
        {
            //SessionStatus();

            //if (System.Web.HttpContext.Session["loginStatus"] as string != Login)
            //{
            //    return RedirectToAction("Index", "Home");
            //}
            PDbTable pr;
            using (var db1 = new ProductContext())
            {

                 pr = new PDbTable{
                        Id = product.Id,
                        Name= product.Name,
                        Price = product.Price,
                        Description= product.Description,
                    };

                    db1.Product.Add(pr);
                    db1.SaveChanges();
                }
                return View();

        }

        [HttpGet]
        public ActionResult otzivi()
        {
            return View();
        }

        [HttpPost]
        public ActionResult otzivi(FDbTable feedback)
        {

            //using (FeedbackContext db = new FeedbackContext())
            //{
            //    if (string.IsNullOrEmpty(feedback.Text))
            //    {
            //        ModelState.AddModelError("Text", "Пожалуйста, введите отзыв.");
            //        return View(feedback);
            //    }

            //    db.Feedback.Add(feedback);
            //    db.SaveChanges();
            //    return RedirectToAction("Index");

            //}

            FDbTable pr;
            using (var db1 = new FeedbackContext())
            {

                pr = new FDbTable
                {
                    Id = feedback.Id,
                    Text = feedback.Text,
                };

                db1.Feedback.Add(pr);
                db1.SaveChanges();
            }
            return View();
        }
    }
}