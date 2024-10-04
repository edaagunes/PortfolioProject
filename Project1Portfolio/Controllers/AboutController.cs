using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project1Portfolio.Models;

namespace Project1Portfolio.Controllers
{
    public class AboutController : Controller
    {
        MyPortfolioDbEntities context = new MyPortfolioDbEntities();
        public ActionResult AboutIndex()
        {
            var values=context.About.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateAbout()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateAbout(About about)
        {
            context.About.Add(about);
            context.SaveChanges();
            return RedirectToAction("AboutIndex");
        }

        public ActionResult DeleteAbout(int id)
        {
            var value = context.About.Find(id);
            context.About.Remove(value);
            context.SaveChanges();
            return RedirectToAction("AboutIndex");
        }

        [HttpGet]
        public ActionResult UpdateAbout(int id)
        {
            var value=context.About.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateAbout(About about)
        {
            var value = context.About.Find(about.AboutID);
            value.Title = about.Title;
            value.Detail = about.Detail;
            value.ImageUrl = about.ImageUrl;
            context.SaveChanges();
            return RedirectToAction("AboutIndex");
        }
    }
}