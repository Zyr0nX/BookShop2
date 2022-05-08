namespace BookShop.Areas.Admin.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using BookShop.Models;

    public class BookViewModel
    {
        public BookViewModel()
        {
            books = new Book();
            authors = new List<Author>();
            categories = new List<Category>();
        }
        public virtual Book books { get; set; }
        public virtual List<Author> authors { get; set; }
        public virtual List<Category> categories { get; set; }
    }
}