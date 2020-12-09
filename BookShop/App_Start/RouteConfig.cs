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
                name: "Book Category",
                url: "san-pham/{metatitle}-{Ca_id}",
                defaults: new { controller = "Book", action = "Category", id = UrlParameter.Optional },
                namespaces: new[] { "BookShop.Controllers" }
            );
            routes.MapRoute(
                name: "Author",
                url: "san-pham/{metatitle}-{Au_id}",
                defaults: new { controller = "Book", action = "Author", id = UrlParameter.Optional },
                namespaces: new[] { "BookShop.Controllers" }
            );
            routes.MapRoute(
                name: "Producer",
                url: "san-pham/{metatitle}-{Pro_id}",
                defaults: new { controller = "Book", action = "Producer", id = UrlParameter.Optional },
                namespaces: new[] { "BookShop.Controllers" }
            );
            routes.MapRoute(
                name: "Book Detail",
                url: "chi-tiet/{metatitle}-{id}",
                defaults: new { controller = "Book", action = "Detail", id = UrlParameter.Optional },
                namespaces: new[] { "BookShop.Controllers" }
            );
            routes.MapRoute(
               name: "Cart",
               url: "gio-hang",
               defaults: new { controller = "Cart", action = "Index", id = UrlParameter.Optional },
               namespaces: new[] { "BookShop.Controllers" }
           );
            routes.MapRoute(
               name: "Payment",
               url: "thanh-toan",
               defaults: new { controller = "Cart", action = "Payment", id = UrlParameter.Optional },
               namespaces: new[] { "BookShop.Controllers" }
           );
            routes.MapRoute(
                name: "Add Cart",
                url: "them-gio-hang",
                defaults: new { controller = "Cart", action = "AddItem", id = UrlParameter.Optional },
                namespaces: new[] { "BookShop.Controllers" }
            );
            routes.MapRoute(
                name: "Payment Success",
                url: "hoan-thanh",
                defaults: new { controller = "Cart", action = "Success", id = UrlParameter.Optional },
                namespaces: new[] { "BookShop.Controllers" }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "BookShop.Controllers" }
            );
        }
    }
}
