using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Vidly1
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //dodajemy route bo chcemy miec dodatkowa zakladke {controller}/{action}/{rok}/{id}
            //sa 3 parametry name, url i default
            //chcemy tez zeby nasze parametry okreslony w akcji ByReleaseDate mialy constrainty. uzywa sie do tego nowego anonimowego obiektu {} z regex: @"\d{4}" 4cyfrowy digit
            //routes.MapRoute(
            //    name: "MoviesByReleaseDate",
            //    url: "movies/released/{year}/{month}",
            //    defaults: new { Controller = "movies", action = "ByReleaseDate"},
            //    constraints: new { year = @"2015|2016", month = @"\d{2}" });



            //dodajemy attribute routing, lepszy sposob na dodawanie route, dlatego reszta odbywa sie w controlerze
            routes.MapMvcAttributeRoutes();


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
