using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab6.Models
{
    public class MyAuthorize : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            try
            {
                if(httpContext.Request.QueryString[0] != null)
                {
                    int first = int.Parse(httpContext.Request.QueryString[0]);
                }
            }
            catch (FormatException)
            {
                throw new FormatException($"ID было не в формате int: {httpContext.Request.QueryString[0]}");
            }
            string second = httpContext.Request.QueryString[1];

            return true;
        }
    }
}