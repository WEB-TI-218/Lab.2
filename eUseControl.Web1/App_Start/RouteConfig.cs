using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace eUseControl.Web1
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
                

            );

            routes.MapRoute(
               name: "policy",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Home", action = "policy", id = UrlParameter.Optional }
               );

            routes.MapRoute(
               name: "accessories",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Home", action = "accessories", id = UrlParameter.Optional }


           );

            routes.MapRoute(
               name: "registration",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Home", action = "registration", id = UrlParameter.Optional }


           );

            routes.MapRoute(
               name: "checkout",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Home", action = "checkout", id = UrlParameter.Optional }


           );

            routes.MapRoute(
               name: "otzivi",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Home", action = "otzivi", id = UrlParameter.Optional }


           );


            routes.MapRoute(
              name: "predproduct",
              url: "{controller}/{action}/{id}",
              defaults: new { controller = "Home", action = "predproduct", id = UrlParameter.Optional }


          );

            routes.MapRoute(
            name: "product1",
            url: "{controller}/{action}/{id}",
            defaults: new { controller = "Home", action = "product1", id = UrlParameter.Optional }


        );

            routes.MapRoute(
            name: "product2",
            url: "{controller}/{action}/{id}",
            defaults: new { controller = "Home", action = "product2", id = UrlParameter.Optional }


        );

            routes.MapRoute(
            name: "product3",
            url: "{controller}/{action}/{id}",
            defaults: new { controller = "Home", action = "product3", id = UrlParameter.Optional }


        );

            routes.MapRoute(
            name: "product4",
            url: "{controller}/{action}/{id}",
            defaults: new { controller = "Home", action = "product4", id = UrlParameter.Optional }


        );

            routes.MapRoute(
              name: "store",
              url: "{controller}/{action}/{id}",
              defaults: new { controller = "Home", action = "store", id = UrlParameter.Optional }


          );

            routes.MapRoute(
              name: "HotProduct",
              url: "{controller}/{action}/{id}",
              defaults: new { controller = "Home", action = "HotProduct", id = UrlParameter.Optional }


          );
        }
    }
}
