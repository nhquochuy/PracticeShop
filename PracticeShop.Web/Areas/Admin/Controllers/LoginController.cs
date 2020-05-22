using PracticeShop.Data.Services;
using PracticeShop.Web.Common;
using PracticeShop.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PracticeShop.Web.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        IUserData db;
        public LoginController(IUserData db)
        {
            this.db = db;
        }
        // GET: Admin/Login
        public ActionResult Index()
        {
            if (Session[VariableConst._UserSession] == null)
            {
                return View();
            }
            return RedirectToAction("index","home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserModel user)
        {
            if (ModelState.IsValid)
            {
                if (db.Login(user.UserName, user.Password))
                {
                    var userLogin = db.GetUserByUserName(user.UserName);

                    Session.Add(VariableConst._UserSession, userLogin);
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("loginfail", "Login fail!!!");
            }
            return View("Index");
        }
    }
}