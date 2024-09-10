using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project1Portfolio.Controllers
{
    public class CategoryController : Controller
    {

        public ActionResult CategoryList()
        {
            return View();
        }

        public ActionResult CreateCategory()
        {
            return View();
        }
    }
}