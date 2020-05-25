using PracticeShop.Data.Models;
using PracticeShop.Data.Services;
using PracticeShop.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PracticeShop.Web.Areas.Admin.Controllers
{
    [SesstionAuthorize]
    public class UserController : Controller
    {
        IUserData db;
        public UserController(IUserData db)
        {
            this.db = db;
        }
        // GET: Admin/User
        public ActionResult Index()
        {
            return HttpNotFound();
        }

        #region List
        public ActionResult List(User user)
        {
            User CurrentUser = (User)Session[VariableConst._UserSession];
            ViewBag.CurrentUsername = CurrentUser.UserName;
            var model = db.GetAll();
            return View(model);
        }
        #endregion List

        #region Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create(User user, FormCollection frm)
        {
            if (ModelState.IsValid)
            {
                string mess = db.Add(user);
                if (mess == "")
                {
                    return RedirectToAction("List");
                }
                else
                    ModelState.AddModelError(string.Empty,mess);
                
            }
            return View();
        }
        #endregion Create

        #region Detail
        public ActionResult Details(string username)
        {
            var model = db.GetUserByUserName(username);
            return View(model);
        }
        #endregion Detail

        #region Edit

        [HttpGet]
        public ActionResult Edit(string username)
        {
            var model = db.GetUserByUserName(username);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(User user)
        {
            var Us = db.GetUserByUserName(user.UserName);
            if (Us == null) return HttpNotFound();

            if(ModelState.IsValid)
            {
                db.Edit(user);
                return RedirectToAction("List");
            }
           return View();
        }
        #endregion Edit

        [HttpGet]
        public ActionResult Delete(string username)
        {
            var model = db.GetUserByUserName(username);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string username, FormCollection frm)
        {
            if(ModelState.IsValid)
            {
                db.Delete(username);
                return RedirectToAction("List");
            }
            return View();
        }
    }
}