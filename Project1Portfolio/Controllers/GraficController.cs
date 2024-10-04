using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Project1Portfolio.Models;

namespace Project1Portfolio.Controllers
{
    public class GraficController : Controller
    {
        MyPortfolioDbEntities context = new MyPortfolioDbEntities();

        public PartialViewResult PartialChartSkill()
        {
            var values=context.Skill.ToList();
            return PartialView("PartialChartSkill",values);
        }


    }

}
