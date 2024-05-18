using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Lab6.Models;

namespace Lab6.Controllers
{
    public class MyController : IController
    {
        public void Execute(RequestContext requestContext)
        {
            string controller = (string)requestContext.RouteData.Values["controller"];
            string action = (string)requestContext.RouteData.Values["action"];
            string id = (string)requestContext.RouteData.Values["id"];

            if(action != "Start" || id != "0")
            {
                requestContext.HttpContext.Response.Write("<div>Ошибка, нужно /My/Start/0</div>");
                requestContext.HttpContext.Response.Write("<div>" + requestContext.HttpContext.Request.Url.ToString() + "</div>");
            }
            else
            {
                requestContext.HttpContext.Response.Redirect($"/Home/Index?id={id}&method={action}");
            }
        }
    }
}