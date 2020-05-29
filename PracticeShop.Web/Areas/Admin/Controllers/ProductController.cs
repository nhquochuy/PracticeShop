using PracticeShop.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PracticeShop.Web.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        IProduct db;
        public ProductController(IProduct db)
        {
            this.db = db;
        }
        // GET: Admin/Product
        public ActionResult Index(string strSearchText = null, string strSortName = null, int intSortType = 0)
        {
            var model = db.GetAll();
            if (!string.IsNullOrEmpty(strSearchText))
            {
                ViewBag.SeartText = strSearchText;
                model = model.Where(x => x.Name.ToUpper().Contains(strSearchText.ToUpper()) ||x.Code.ToUpper().Contains(strSearchText.ToUpper())
                             || x.Price.ToString().Contains(strSearchText));
            }

            if(!string.IsNullOrEmpty(strSortName))
            {
                switch (strSortName)
                {
                    case "name":
                        model = (intSortType == 0) ? model.OrderBy(x => x.Name) : model.OrderByDescending(x => x.Name);
                        break;
                    case "code":
                        model = (intSortType == 0) ? model.OrderBy(x => x.Code) : model.OrderByDescending(x => x.Code);
                        break;
                    case "price":
                        model = (intSortType == 0) ? model.OrderBy(x => x.Price) : model.OrderByDescending(x => x.Price);
                        break;
                }
                ViewBag.SortType = intSortType;
            }
            return View(model);
        }
    }
}