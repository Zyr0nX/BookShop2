namespace BookShop.Areas.Admin.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using BookShop.Models;

    public class AuthorListBoxViewModel
    {
        public List<SelectListItem> authors { set; get; }
        public int[] selectedauthor { set; get; }
        [Display(Name = "")]
        public string authorName { set; get; }
    }
}