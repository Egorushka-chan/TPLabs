using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab7.Controllers
{
    public class MyController : Controller
    {
        public ActionResult Start(string uvar)
        {
            if (string.IsNullOrEmpty(uvar))
            {
                ViewBag.Var = "Пользовательская переменная не задана";
            }
            else
            {
                ViewBag.Var = uvar;
            }
            return View(model:Request.RawUrl);
        }

        public ActionResult Stop(string uvar) // этот метод должен заблокировать MyRouteConstraint
        {
            if (string.IsNullOrEmpty(uvar))
            {
                ViewBag.Var = "Пользовательская переменная не задана";
            }
            else
            {
                ViewBag.Var = uvar;
            }
            return View("Start",model: Request.RawUrl);
        }
    }
}