using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Lab6.Models
{
    public class MyError : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            if (!filterContext.ExceptionHandled &&
                filterContext.Exception is FormatException)
            {
                string[] result = new string[] {filterContext.Exception.Message, filterContext.Exception.StackTrace, filterContext.Exception.Source };
                filterContext.Result = new ViewResult
                {
                    ViewName = "FormatError",
                    ViewData = new ViewDataDictionary<string[]>(result)
                };
                filterContext.ExceptionHandled = true;
            }
        }
    }
}