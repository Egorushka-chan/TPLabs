using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;

namespace Lab6.Models
{
    public class MyAction : FilterAttribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var param = filterContext.ActionParameters;
            if (param.ContainsKey("id"))
            {
                int? id = int.Parse(param["id"].ToString());
                if (id < 0)
                {
                    ViewResult result = new ViewResult();
                    result.ViewName = "NegativeResult";
                    string name = param["name"].ToString();
                    bool active = param["active"].ToString() == "true";
                    result.ViewData = new ViewDataDictionary { { "id", id }, { "name", name }, { "active", active } };
                    filterContext.Result = result;
                }
            }
            
        }
    }
}