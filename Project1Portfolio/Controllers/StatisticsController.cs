using Project1Portfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project1Portfolio.Controllers
{
    public class StatisticsController : Controller
    {
        MyPortfolioDbEntities context= new MyPortfolioDbEntities();
        public ActionResult Index()
        {
            int messageCount = context.Message.Count();
            int messageCountIsReadByTrue=context.Message.Where(x=>x.IsRead==true).Count();
            int messageCountIsReadByFalse=context.Message.Where(x=>x.IsRead==false).Count();
            int skillCount=context.Skill.Count();
            var totalSkillValue=context.Skill.Sum(x=>x.Value);
            var averageSkillValue=context.Skill.Average(x=>x.Value);
            var getEmailFromProfile=context.Profile.Select(x=>x.Email).FirstOrDefault();
            var getLastCategoryID=context.Category.Max(x=>x.CategoryID);
            var getLastCategoryName=context.Category.Where(x=>x.CategoryID==getLastCategoryID).Select(y=>y.CategoryName).FirstOrDefault();

            ViewBag.messageCount = messageCount;
            ViewBag.messageCountIsReadByTrue = messageCountIsReadByTrue;
            ViewBag.messageCountIsReadByFalse = messageCountIsReadByFalse;
            ViewBag.skillCount = skillCount;
            ViewBag.totalSkillValue = totalSkillValue;
            ViewBag.averageSkillValue = averageSkillValue;
            ViewBag.getEmailFromProfile = getEmailFromProfile;
            ViewBag.getLastCategoryName = getLastCategoryName;


            return View();
        }
    }
}