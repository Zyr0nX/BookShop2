using BookShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookShop.Controllers
{
    public class ProductController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ProductDetail(int id)
        {
            //var model = from book in _context.Books
            //            where book.Id == id
            //            select book;
            var model = _context.Books.Find(id);
            return View(model);
        }

        [ChildActionOnly]
        public ActionResult RenderProductContent(int id)
        {
            var model = from book in _context.Books
                        where book.Id == id
                        select book;
            return PartialView(model);
        }

        [ChildActionOnly]
        public ActionResult RenderProductDetail(int id)
        {
            var model = from book in _context.Books
                        where book.Id == id
                        select book;
            return PartialView(model);
        }
    }
}