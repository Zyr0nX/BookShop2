using BookShop.Areas.Admin.ViewModels;
using BookShop.Models;
using System;
using System.Collections.Generic;
using System.IO;
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



        public ActionResult Index()
        {
            var bookViewModels = new List<BookViewModel>();

            foreach (var item in _context.Books.ToList())
            {
                var book = new BookViewModel();
                book.books = item;

                var categories = new List<Category>();
                foreach (var item1 in item.CategoryBooks)
                {
                    categories.Add(_context.Categories.SingleOrDefault(x => x.Id == item1.IdCategory));
                }
                book.categories = categories;

                var authors = new List<Author>();
                foreach (var item2 in item.AuthorBooks)
                {
                    authors.Add(_context.Authors.SingleOrDefault(x => x.Id == item2.IdAuthor));
                }
                book.authors = authors;

                bookViewModels.Add(book);
            }
            return View(bookViewModels);
        }
        public ActionResult Create()
        {
            var author = _context.Authors.ToList();
            var category = _context.Categories.ToList();
            ViewBag.publisher = _context.Publishers.ToList();
            
            return View();
        }

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Book book, HttpPostedFileBase photo)
        {
            if (book.Id == 0)
            {
                if (photo != null && photo.ContentLength > 0)
                {
                    var path = Path.Combine(Server.MapPath("~/Areas/Admin/Data/BookImage/"),
                                            System.IO.Path.GetFileName(photo.FileName));
                    photo.SaveAs(path);

                    book.Photo = photo.FileName;
                }
                else
                    book.Photo = "150x200.png";
                _context.Books.Add(book);
                _context.SaveChanges();
                return Redirect("~/Admin/Book");
            }
            else
            {
                var bookInDb = _context.Books.Single(c => c.Id == book.Id);
                bookInDb.Name = book.Name;
                bookInDb.Discount = book.Discount;
                bookInDb.Price = book.Price;
                bookInDb.Amount = book.Amount;
                bookInDb.Description = book.Description;
                bookInDb.AuthorBooks = book.AuthorBooks;
                bookInDb.CategoryBooks = book.CategoryBooks;
                bookInDb.IdPublisher = book.IdPublisher;
                bookInDb.Price = book.Price;
                if (photo != null && photo.ContentLength > 0)
                {
                    var path = Path.Combine(Server.MapPath("~/Areas/Admin/Data/BookImage/"),
                                            System.IO.Path.GetFileName(photo.FileName));
                    photo.SaveAs(path);

                    bookInDb.Photo = photo.FileName;
                }
                _context.SaveChanges();
                return Redirect("~/Admin/Book");
            }


        }

        [ChildActionOnly]
        public ActionResult ListBoxCategory(int? IdBook = null)
        {
            var category = new CategoryListBoxViewModel();
            category.categories = _context.Categories.Select(a => new SelectListItem() { Value = a.Id.ToString(), Text = a.Name }).ToList();
            if (IdBook != null)
            {
                category.selectedcategory = _context.CategoryBooks.Where(x => x.IdBook == IdBook).Select(x => x.IdCategory).ToArray();
            }
            return PartialView(category);
        }

        [ChildActionOnly]
        public ActionResult ListBoxAuthor(int? IdBook = null)
        {
            var author = new AuthorListBoxViewModel();
            author.authors = _context.Authors.Select(a => new SelectListItem() { Value = a.Id.ToString(), Text = a.Name }).ToList();
            if (IdBook != null)
            {
                author.selectedauthor = _context.AuthorBooks.Where(x => x.IdBook == IdBook).Select(x => x.IdAuthor).ToArray();
            }
            return PartialView(author);
        }
    }
}