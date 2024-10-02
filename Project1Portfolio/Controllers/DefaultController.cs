using Project1Portfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project1Portfolio.Controllers
{
    public class DefaultController : Controller
    {
       MyPortfolioDbEntities context = new MyPortfolioDbEntities();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult PartialHead()
        {
            return PartialView();
        }

        public PartialViewResult PartialNavBar() 
        {
            return PartialView();
        }

        public PartialViewResult PartialHeader()
        {
            ViewBag.title=context.About.Select(x => x.Title).FirstOrDefault();
            ViewBag.detail=context.About.Select(x => x.Detail).FirstOrDefault();
            ViewBag.imageUrl=context.About.Select(x => x.ImageUrl).FirstOrDefault();

            ViewBag.address=context.Profile.Select(x => x.Address).FirstOrDefault();
            ViewBag.email=context.Profile.Select(x => x.Email).FirstOrDefault();
            ViewBag.phone=context.Profile.Select(x => x.PhoneNumber).FirstOrDefault();
            ViewBag.github=context.Profile.Select(x => x.Github).FirstOrDefault();

            return PartialView();
        }
    
        public PartialViewResult PartialAbout()
        {
            ViewBag.title=context.Profile.Select(x=>x.Title).FirstOrDefault();
            ViewBag.description=context.Profile.Select(x=>x.Description).FirstOrDefault();
            ViewBag.phone=context.Profile.Select(x=>x.PhoneNumber).FirstOrDefault();
            ViewBag.email=context.Profile.Select(x=>x.Email).FirstOrDefault();
            ViewBag.imageUrl=context.Profile.Select(x=>x.ImageUrl).FirstOrDefault();

            return PartialView();
        }
   
        public PartialViewResult PartialEducation()
        {
            var values = context.Education.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialScript()
        {
            return PartialView();
        }
    
        public PartialViewResult PartialExperience()
        {
            var values = context.Experience.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialSkills()
        {
            var values = context.Skill.ToList();
            return PartialView(values);
        }
        
    }
}