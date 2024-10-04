using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project1Portfolio.Models;

namespace Project1Portfolio.Controllers
{
    public class ServiceController : Controller
    {
        MyPortfolioDbEntities context = new MyPortfolioDbEntities();
        public ActionResult ServiceIndex()
        {
            var values = context.Service.ToList();
            return View(values);
        }

        public ActionResult DeleteService(int id)
        {
            var values = context.Service.Find(id);
            context.Service.Remove(values);
            context.SaveChanges();
            return RedirectToAction("ServiceIndex");
        }

        [HttpGet]
        public ActionResult CreateService()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateService(Service service)
        {
            context.Service.Add(service);
            context.SaveChanges();
            return RedirectToAction("ServiceIndex");
        }

        [HttpGet]
        public ActionResult UpdateService(int id)
        { 
            var values = context.Service.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateService(Service service)
        {
            var values=context.Service.Find(service.ServiceID);
            values.Title = service.Title;
            values.Description = service.Description;
            values.Icon = service.Icon;
            context.SaveChanges();
            return RedirectToAction("ServiceIndex");
        }
    }
}
