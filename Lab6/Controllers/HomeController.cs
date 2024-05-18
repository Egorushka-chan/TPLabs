using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Lab6.Models;

namespace Lab6.Controllers
{
    public class HomeController : Controller
    {
        [HandleError(ExceptionType = typeof(ArgumentOutOfRangeException), View ="ArgumentError")]
        [MyError]
        [MyAuthorize]
        public ActionResult Index(int id, string method)
        {
            return View();
        }

        [HttpPost]
        [HandleError(ExceptionType = typeof(ArgumentOutOfRangeException), View ="ArgumentError")]
        [MyError]
        [MyAuthorize]
        [MyAction]
        public ActionResult Index(int? id, string name, bool active)
        {
            string rows = Request.Form["rows"];
            string type = Request.Form["type"];

            if(id.HasValue)
            {
                ViewBag.ID = id.Value;
                ViewBag.Name = name;
                ViewBag.Type = type;
                ViewBag.Rows = rows;
                ViewBag.Active = active;
                return View("Result");
            }
            else
            {
                return RedirectToAction("Index", new{id=0, method="Start"});
            }
        }
    }
}