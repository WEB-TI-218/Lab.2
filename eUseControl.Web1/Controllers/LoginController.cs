using eUseControl.BusinessLogic.Interfaces;
using eUseControl.BusinessLogic;
using eUseControl.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eUseControl.Web1.Models;
using System.Web.UI.WebControls;
using System.Data.Entity;
using eUseControl.BusinessLogic.DBModel;
using System.Web.Security;
using Microsoft.Ajax.Utilities;

namespace eUseControl.Web1.Controllers
{
    public class LoginController : Controller
    {
        private readonly ISession _session;

        public LoginController()
        {
            var bl = new BussinesLogic();
            _session = bl.GetSessionBL();
        }

        [HttpGet]
        public ActionResult SignIn()
        {
            return View();
        }

        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogIn(UserLogin model)
        {
            if (ModelState.IsValid)
            {
                // поиск пользователя в бд
                UDbTable user = null;
                using (UserContext db = new UserContext())
                {
                    user = db.Users.FirstOrDefault(u => u.Username == model.Credential && u.Password == model.Password);

                }
                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(model.Credential, true);
                    return RedirectToAction("IndexAuth", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Пользователя с таким логином и паролем нет");
                }
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(UserRegister login)
        {
            if (ModelState.IsValid)
            {
                ULoginData data = new ULoginData
                {
                    Credential = login.Credential,
                    Password = login.Password,
                    Email = login.Email,
                    LoginIP = Request.UserHostAddress,
                    LoginDateTime = DateTime.Now
                };

                var userLogin = _session.UserRegistration(data);
                if (userLogin.Status)
                {
                    //ADD COOKIE
                    HttpCookie cookie = _session.GenCookie(login.Credential);
                    ControllerContext.HttpContext.Response.Cookies.Add(cookie);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", userLogin.StatusMsg);
                    return View();
                }

            }

            return View();
        }
        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }

    //    [HttpPost]
    //    public ActionResult SignIn(UserLogin login)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            ULoginData data = new ULoginData
    //            {
    //                Credential = login.Credential,
    //                Password = login.Password,
    //                LoginIP = Request.UserHostAddress,
    //                LoginDateTime = DateTime.Now
    //            };

    //            var userLogin = _session.UserLogin(data);
    //            if (userLogin.Status)
    //            {
    //                return RedirectToAction("Index", "Home");
    //            }
    //            else
    //            {
    //                ModelState.AddModelError("", userLogin.StatusMsg);
    //                return View();//поменять
    //            }

    //        }
    //        return View();//поменять на редирект
    //    }
    //}

}
