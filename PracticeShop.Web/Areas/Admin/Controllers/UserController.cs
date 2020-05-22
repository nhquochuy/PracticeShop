using PracticeShop.Data.Services;
using PracticeShop.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PracticeShop.Web.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        // GET: Admin/User
        public ActionResult Index()
        {
            return HttpNotFound();
        }

        [HttpGet]
        public ActionResult Login(UserModel userModel)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserModel userModel, FormCollection form)
        {
            IUserData userData = new UserData();
            if (ModelState.IsValid)
            {
                var re = userData.Login(userModel.UserName, userModel.Password);
                if (re != null)
                {
                    return RedirectToAction("Index","Home");
                }
                else TempData["wronguser"] = "Login Fail !!!";
            }
            return View();
        }
    }
}