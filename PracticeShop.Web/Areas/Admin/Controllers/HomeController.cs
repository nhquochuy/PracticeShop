﻿using PracticeShop.Data.Models;
using PracticeShop.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PracticeShop.Web.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            //if((User)Session[VariableConst._UserSession] == null)
            //{
            //    return RedirectToAction("Index", "Login");
            //}
            return View();
        }
    }
}