using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project1Portfolio.Models;

namespace Project1Portfolio.Controllers
{
    public class CategoryController : Controller
    {
        MyPortfolioDbEntities context= new MyPortfolioDbEntities();
        public ActionResult CategoryList()
        {
            var values=context.Category.ToList();
            return View(values);
        }

        public ActionResult DeleteCategory(int id)
        {
            var values = context.Category.Find(id);
            context.Category.Remove(values);
            context.SaveChanges();
            return RedirectToAction("CategoryList");
        }

        [HttpGet]
        public ActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateCategory(Category category)
        {
            context.Category.Add(category);
            context.SaveChanges();
            return RedirectToAction("CategoryList");
        }

        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            var value = context.Category.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateCategory(Category category)
        {
            var value = context.Category.Find(category.CategoryID);
            value.CategoryName = category.CategoryName;
            value.CategoryStatus = category.CategoryStatus;
            context.SaveChanges();
            return RedirectToAction("CategoryList");
        }
    }
}