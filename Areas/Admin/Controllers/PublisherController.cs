using BookShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookShop.Areas.Admin.Controllers
{
    //[Authorize]
    public class PublisherController : Controller
    {
        private ApplicationDbContext _context;

        public PublisherController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var publisher = _context.Publishers.ToList();
            return View(publisher);
        }

        public ViewResult Create()
        {
            return View();
        }

        public JsonResult IsExist(string Name)
        {
            return Json(!_context.Publishers.Any(x => x.Name == Name), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Edit(int id)
        {
            var publisher = _context.Publishers.SingleOrDefault(c => c.Id == id);
            if (publisher == null)
                return HttpNotFound();
            return View(publisher);
        }

        public ActionResult Delete(int id)
        {
            var publisher = _context.Publishers.SingleOrDefault(c => c.Id == id);
            if (publisher == null)
                return HttpNotFound();
            else
            {
                _context.Publishers.Remove(publisher);
                _context.SaveChanges();
                return RedirectToAction("Index", "Publisher");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Publisher publisher)
        {
            if (publisher.Id == 0)
                _context.Publishers.Add(publisher);
            else
            {
                var publisherInDb = _context.Publishers.SingleOrDefault(c => c.Id == publisher.Id);
                publisherInDb.Name = publisher.Name;
                publisherInDb.Address = publisher.Address;
                publisherInDb.Website = publisher.Website;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Publisher");
        }
    }
}