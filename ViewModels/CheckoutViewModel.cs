using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShop.Models
{
    [Serializable]
    public class CheckoutViewModels
    {
        public List<CartViewModels> CartViewModels { get; set; }

        public Information Information { get; set; }
    }
}