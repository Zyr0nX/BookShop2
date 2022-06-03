using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShop.Models
{
    [Serializable]
    public class CartViewModels
    {
        public Book Book { get; set; }

        public int amount { get; set; }
    }
}