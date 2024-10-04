using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project1Portfolio.Controllers
{
    public class SettingsController : Controller
    {
        // GET: Settings
        public ActionResult SettingsIndex()
        {
            return View();
        }
    }
}