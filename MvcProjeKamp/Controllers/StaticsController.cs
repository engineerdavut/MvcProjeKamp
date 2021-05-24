
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKamp.Controllers
{
    public class StaticsController : Controller
    {
        // GET: Statics
        
        Context context = new Context();
        public ActionResult Index()
        {
            ViewBag.d1 = context.Categories.Count().ToString();
            ViewBag.d2 = context.Headings.Count(x => x.Category.CategoryName == "Yazılım").ToString();
            ViewBag.d3 = (from x in context.Writers select x.WriterFirstName.IndexOf("a")).Distinct().Count().ToString();
            ViewBag.d4 = context.Categories.Where(u => u.CategoryId == (context.Headings.GroupBy(x => x.CategoryId)
           .OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault())).Select(k => k.CategoryName).FirstOrDefault();
            ViewBag.d5 = (context.Categories.Count(x => x.CategoryStatus == true) - context.Categories.Count(x => x.CategoryStatus == false)).ToString();
            return View(ViewBag);
        }

    }
}