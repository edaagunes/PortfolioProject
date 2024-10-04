using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project1Portfolio.Models;

namespace Project1Portfolio.Controllers
{
    public class ProfileController : Controller
    {
       MyPortfolioDbEntities context= new MyPortfolioDbEntities();
        public ActionResult ProfileIndex()
        {
            var values=context.Profile.ToList();
            return View(values);
        }

        public ActionResult DeleteProfile(int id)
        {
            var values = context.Profile.Find(id);
            context.Profile.Remove(values);
            context.SaveChanges();
            return RedirectToAction("ProfileIndex");
        }

        [HttpGet]
        public ActionResult CreateProfile()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateProfile(Profile profile)
        {
            context.Profile.Add(profile);
            context.SaveChanges();
            return RedirectToAction("ProfileIndex");
        }

        [HttpGet]
        public ActionResult UpdateProfile(int id)
        {
            var values = context.Profile.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateProfile(Profile profile)
        {
            var values = context.Profile.Find(profile.ProfileID);
            values.PhoneNumber = profile.PhoneNumber;
            values.Address = profile.Address;
            values.Email = profile.Email;
            values.Title = profile.Title;
            values.Description = profile.Description;
            values.MapLocation = profile.MapLocation;
            values.Github = profile.Github;
            values.ImageUrl = profile.ImageUrl;
            context.SaveChanges();
            return RedirectToAction("ProfileIndex");
        }
    }
}