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
        public ActionResult Index()
        {
            return RedirectToAction("SignIn", "Login");
        }

        [HttpGet]
        public ActionResult SignIn()
        {
            UserData user = new UserData();
            ULoginData data = new ULoginData
            {
                Credential = "Login123",
                Password = "qwerty",
                LoginIP = Request.UserHostAddress,
                LoginDateTime = DateTime.Now
            };

            var userLogin = _session.UserLogin(data);
            return View(user);

        }

        [HttpPost]
        public ActionResult SignIn(UserLogin login)
        {
            if (ModelState.IsValid)
            {
                ULoginData data = new ULoginData
                {
                    Credential = login.Credential,
                    Password = login.Password,
                    LoginIP = Request.UserHostAddress,
                    LoginDateTime = DateTime.Now
                };

                var userLogin = _session.UserLogin(data);
                if (userLogin.Status)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", userLogin.StatusMsg);
                    return View();//поменять
                }

            }
            return View();//поменять на редирект
        }
    }
}
