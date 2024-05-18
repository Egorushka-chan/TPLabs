using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace Lab7.Models
{
    public class MyRouteConstraint : IRouteConstraint
    {
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            string controller = values["controller"].ToString();
            string action = values["action"].ToString();
            if (action == "Start" || controller != "My") // дозволяет в контроллере My вызвать только Start
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}