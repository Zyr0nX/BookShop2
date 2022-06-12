using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookShop.Models;

namespace BookShop.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult RenderBanner()
        {
            var model = _context.Banners;
            return PartialView(model);
        }

        [ChildActionOnly]
        public ActionResult RenderCategory()
        {
            var model = _context.Categories;
            return PartialView(model);
        }

        [ChildActionOnly]
        public ActionResult RenderBestSeller()
        {
            var model = _context.Books.OrderByDescending(book => book.DetailOrders.Count);
            return PartialView(model);
        }

        [ChildActionOnly]
        public ActionResult RenderNewBook()
        {
            var model = _context.Books.OrderByDescending(book => book.Id);
            return PartialView(model);
        }

        [ChildActionOnly]
        public ActionResult RenderCategoriesHightlight()
        {
            var model = _context.Categories;
            return PartialView(model);
        }

        [ChildActionOnly]
        public ActionResult RenderCategoryContent(int? id = null)
        {
            var model = _context.Books
                .Where(book => book.IdCategory == id)
                .OrderByDescending(book => book.Id).ToList();
            return PartialView(model);
        }

        [ChildActionOnly]
        public ActionResult _RenderCart()
        {
            var cart = Session["CartSession"];
            var list = new List<CartViewModels>();
            if (cart != null)
            {
                list = (List<CartViewModels>)cart;
            }
            return PartialView(list);
        }

        public ActionResult Search()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult RenderSearchResult(string s)
        {
            var model = from x in _context.Books
                        where x.Name.Contains(s)
                        select x;
            return View(model);
        }
    }
}