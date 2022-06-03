namespace BookShop.Areas.Admin.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using BookShop.Models;

    public class CategoryListBoxViewModel
    {
        public List<SelectListItem> categories { set; get; }
        public int[] selectedcategory { set; get; }
        [Display(Name = "Thể loại")]
        public string categoryName { set; get; }
    }
}