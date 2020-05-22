using PracticeShop.Data.Models;
using PracticeShop.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PracticeShop.Web.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        IUserData db;
        public UserController(IUserData db)
        {
            this.db = db;
        }
        // GET: Admin/User
        public ActionResult Index(User users)
        {
            var model = db.GetAll();
            return View(model);
        }
    }
}