using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BookShop
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "All",
                url: "all",
                defaults: new { controller = "Home", action = "Search" }
            );

            routes.MapRoute(
                name: "Search",
                url: "search",
                defaults: new { controller = "Home", action = "Search" }
            );

            routes.MapRoute(
                name: "Cart",
                url: "thanh-cong",
                defaults: new { controller = "Cart", action = "Success" }
            );

            routes.MapRoute(
                name: "CartCheckout",
                url: "gio-hang/thanh-toan",
                defaults: new { controller = "Cart", action = "Checkout" }
            );

            routes.MapRoute(
                name: "Success",
                url: "gio-hang",
                defaults: new { controller = "Cart", action = "Index" }
            );

            routes.MapRoute(
                name: "Category",
                url: "danh-muc/{metatitle}",
                defaults: new { controller = "Categories", action = "Content", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Product",
                url: "{metatitle}-{id}",
                defaults: new { controller = "Product", action = "ProductDetail" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );


        }
    }
}
