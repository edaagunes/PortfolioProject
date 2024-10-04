using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project1Portfolio.Models;

namespace Project1Portfolio.Controllers
{
    public class WorkController : Controller
    {
        MyPortfolioDbEntities context= new MyPortfolioDbEntities();
        public ActionResult WorkList()
        {
            var values = context.Work.ToList();
            return View(values);
        }

        public ActionResult DeleteWork(int id)
        {
            var values = context.Work.Find(id);
            context.Work.Remove(values);
            context.SaveChanges();
            return RedirectToAction("WorkList");
        }

        [HttpGet]
        public ActionResult CreateWork()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateWork(Work work)
        {
            context.Work.Add(work);
            context.SaveChanges();
            return RedirectToAction("WorkList");
        }

        [HttpGet]
        public ActionResult UpdateWork(int id)
        {
            var values = context.Work.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateWork(Work work)
        {
            var values = context.Work.Find(work.WorkID);
            values.Title = work.Title;
            values.Description = work.Description;
            values.ImageUrl = work.ImageUrl;
            values.GithubUrl = work.GithubUrl;
            context.SaveChanges();
            return RedirectToAction("WorkList");
        }
    }
}