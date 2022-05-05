using BookShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookShop.Areas.Admin.Controllers
{
    //[Authorize]
    public class BookController : Controller
    {
        private ApplicationDbContext _context;

        public BookController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }



        //public ActionResult Index(string sb = null, int? sa = null, int? sp = null, int? sc = null, int? mip = null, int? map = null)
        //{
        //    ViewBag.Authors = _context.Authors.ToList();
        //    ViewBag.Categories = _context.Categories.ToList();
        //    ViewBag.Publishers = _context.Publishers.ToList();

        //    IQueryable<Book> bookQuery = _context.Books
        //        .Include("Author")
        //        .Include("Category")
        //        .Include("Publisher");

        //    if (!String.IsNullOrWhiteSpace(sb))
        //        bookQuery = bookQuery.Where(c => c.Name.Contains(sb));

        //    if (sa != null)
        //        bookQuery = bookQuery.Where(c => c.IdAuthor == sa);

        //    if (sp != null)
        //        bookQuery = bookQuery.Where(c => c.IdPublisher == sp);

        //    if (sc != null)
        //        bookQuery = bookQuery.Where(c => c.IdCategory == sc);

        //    if (mip != null)
        //        bookQuery = bookQuery.Where(c => c.Price >= mip);

        //    if (map != null)
        //        bookQuery = bookQuery.Where(c => c.Price <= map);

        //    var book = bookQuery.ToList();

        //    return View(book);
            //ViewBag.Authors = _context.Authors.ToList();
            //ViewBag.Categories = _context.Categories.ToList();
            //ViewBag.Publishers = _context.Publishers.ToList();
            //var book = _context.Books
            //    .Where(b => b.Name.Contains(sb))
            //    .Where(b => b.IdAuthor.Equals(sa))
            //    .Where(b => b.IdPublisher.Equals(sp))
            //    .Where(b => b.IdCategory.Equals(sc))
            //    .Where(b => b.Price >= mip)
            //    .Where(b => b.Price <= map)
            //    .ToList();
            //return View(book);    

        //public ActionResult Create()
        //{
        //    var author = _context.Authors.ToList();
        //    var category = _context.Categories.ToList();
        //    var publisher = _context.Publishers.ToList();
        //    var viewModel = new BookViewModel
        //    {
        //        Authors = author,
        //        Categories = category,
        //        Publishers = publisher
        //    };
        //    return View("BookForm", viewModel);
        //}

        //public ActionResult Edit(int id)
        //{
        //    var book = _context.Books.SingleOrDefault(c => c.Id == id);
        //    if (book == null)
        //        return HttpNotFound();
        //    var author = _context.Authors.ToList();
        //    var category = _context.Categories.ToList();
        //    var publisher = _context.Publishers.ToList();
        //    var viewModel = new BookViewModel(book)
        //    {
        //        Authors = author,
        //        Categories = category,
        //        Publishers = publisher
        //    };
        //    return View("BookForm", viewModel);
        //}

        //public ActionResult Delete(int id)
        //{
        //    var book = _context.Books.SingleOrDefault(c => c.Id == id);
        //    if (book == null)
        //        return HttpNotFound();
        //    else
        //    {
        //        _context.Books.Remove(book);
        //        _context.SaveChanges();
        //        return RedirectToAction("Index", "Book");
        //    }
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Save(Book book, HttpPostedFileBase photo)
        //{
        //    if (book.Id == 0)
        //    {
        //        if (photo != null && photo.ContentLength > 0)
        //        {
        //            var path = Path.Combine(Server.MapPath("~/Areas/Admin/Data/BookImage/"),
        //                                    System.IO.Path.GetFileName(photo.FileName));
        //            photo.SaveAs(path);

        //            book.Photo = photo.FileName;
        //        }
        //        else
        //            book.Photo = "150x200.png";
        //        _context.Books.Add(book);
        //        _context.SaveChanges();
        //        return Redirect("~/Admin/Book");
        //    }
        //    else
        //    {
        //        var bookInDb = _context.Books.Single(c => c.Id == book.Id);
        //        bookInDb.Name = book.Name;
        //        bookInDb.Discount = book.Discount;
        //        bookInDb.Price = book.Price;
        //        bookInDb.Amount = book.Amount;
        //        bookInDb.Description = book.Description;
        //        bookInDb.IdAuthor = book.IdAuthor;
        //        bookInDb.IdCategory = book.IdCategory;
        //        bookInDb.IdPublisher = book.IdPublisher;
        //        bookInDb.Price = book.Price;
        //        if (photo != null && photo.ContentLength > 0)
        //        {
        //            var path = Path.Combine(Server.MapPath("~/Areas/Admin/Data/BookImage/"),
        //                                    System.IO.Path.GetFileName(photo.FileName));
        //            photo.SaveAs(path);

        //            bookInDb.Photo = photo.FileName;
        //        }
        //        _context.SaveChanges();
        //        return Redirect("~/Admin/Book");
        //    }


        //}
    }
}