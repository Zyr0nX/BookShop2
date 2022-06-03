using BookShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookShop.Controllers
{
    public class CategoryController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        public ActionResult Content()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult RenderContent(int id)
        {
            var model = from x in _context.Books
                        where x.CategoryBooks.FirstOrDefault().IdCategory == id
                        select x;
            return View(model);
        }
    }
}