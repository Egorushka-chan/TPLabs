using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab7.Areas.My
{
    public class MyAreaRegistration : AreaRegistration
    {
        public override string AreaName => "Area";

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
              "Area_default",
              "Area/{controller}/{action}/{id}",
              new { controller = "Second", action = "Index", id = UrlParameter.Optional },
              namespaces: new[] {"Lab7.Areas.My"});
        }
    }
}