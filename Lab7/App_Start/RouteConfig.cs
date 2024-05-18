using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

using Lab7.Models;

namespace Lab7
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            RouteValueDictionary keyValuePairs = new RouteValueDictionary();
            keyValuePairs.Add("uvar", UrlParameter.Optional);
            Route myRoute = new Route(
                url: "Public/{controller}/{action}0/{uvar}", 
                defaults: keyValuePairs,
                routeHandler: new MvcRouteHandler());
            RouteValueDictionary constraints = new RouteValueDictionary();
            constraints.Add("customConstraint", new MyRouteConstraint());
            myRoute.Constraints = constraints;
            routes.Add("", myRoute);

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{uvar}",
                defaults: new { controller = "My", action = "Start", uvar = UrlParameter.Optional }
            );

            
        }
    }
}
