using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project1Portfolio.Models;

namespace Project1Portfolio.Controllers
{
    public class SocialMediaController : Controller
    {
        MyPortfolioDbEntities context = new MyPortfolioDbEntities();
        public ActionResult Index()
        {
            var values = context.SocialMedia.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateSocialMedia() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateSocialMedia(SocialMedia socialMedia)
        {
            context.SocialMedia.Add(socialMedia);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult StatusChangeToTrue(int id)
        {
            var value = context.SocialMedia.Where(x => x.SocialMediaID == id).FirstOrDefault();
            value.Status = true;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult StatusChangeToFalse(int id)
        {
            var value = context.SocialMedia.Where(x => x.SocialMediaID == id).FirstOrDefault();
            value.Status = false;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateSocialMedia(int id)
        {
            var value = context.SocialMedia.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateSocialMedia(SocialMedia socialMedia)
        {
            var value = context.SocialMedia.Find(socialMedia.SocialMediaID);
            value.Title = socialMedia.Title;
            value.Icon = socialMedia.Icon;
            value.SocialMediaUrl = socialMedia.SocialMediaUrl;
            value.Status = socialMedia.Status;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}