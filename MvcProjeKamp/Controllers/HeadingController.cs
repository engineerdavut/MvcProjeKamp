using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKamp.Controllers
{
    public class HeadingController : Controller
    {
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        // GET: Heading
        public ActionResult Index()
        {
            var headingValues = headingManager.GetList();
            return View(headingValues);
        }
        [HttpGet]
        public ActionResult Add()
        {
            List<SelectListItem> categoryValue = (from x in categoryManager.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }).ToList();
            List<SelectListItem> writerValue = (from x in writerManager.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.WriterFirstName+" "+x.WriterLastName,
                                                      Value = x.WriterId.ToString()
                                                  }).ToList();

            ViewBag.vlc = categoryValue;
            ViewBag.vlw = writerValue;
            return View();
        }
        [HttpPost]
        public ActionResult Add(Heading heading)
        {
            HeadingValidator headingValidator = new HeadingValidator();

            ValidationResult results = headingValidator.Validate(heading);
            if (results.IsValid)
            {
                heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                headingManager.Add(heading);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            List<SelectListItem> categoryValue = (from x in categoryManager.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }).ToList();
            ViewBag.vlc = categoryValue;
            var headingValue = headingManager.Get(id);
            return View(headingValue);
        }
        [HttpPost]
        public ActionResult Edit(Heading heading)
        {
            headingManager.Update(heading);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var headingValue = headingManager.Get(id);
            headingValue.HeadingStatus = false;
            headingManager.Delete(headingValue);
            return RedirectToAction("Index");
        }
        public ActionResult Enable(int id)
        {
            var headingValue = headingManager.Get(id);
            headingValue.HeadingStatus = true;
            headingManager.Delete(headingValue);
            return RedirectToAction("Index");
        }
    }
}