using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project1Portfolio.Models;

namespace Project1Portfolio.Controllers
{
    public class AdminController : Controller
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

        public PartialViewResult PartialSideBar()
        {
            ViewBag.imageUrl=context.About.Select(x => x.ImageUrl).FirstOrDefault();
            return PartialView();
        }

        public PartialViewResult PartialNavBar()
        {
            return PartialView();
        }

        public ActionResult DownloadCV()
        {
            // Dosya yolunu kontrol edin
            var filePath = Server.MapPath("~/Content/images/EdaGunes_CV.pdf");

            // Eğer dosya yoksa bir hata döndür
            if (!System.IO.File.Exists(filePath))
            {
                return HttpNotFound("Dosya bulunamadı.");
            }

            var fileName = "EdaGunes_CV.pdf";
            var contentType = "image/jpeg/pdf";

            // Dosya indirilebilir olarak döndür
            return File(filePath, contentType, fileName);
        }
    }
}