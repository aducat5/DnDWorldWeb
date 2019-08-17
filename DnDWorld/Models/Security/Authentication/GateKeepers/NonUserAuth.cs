using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DnDWorld.Models
{
    public class NonUserAuth : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {

            if (httpContext.Session["user"] == null)
                return true;
            else
            {
                httpContext.Response.Redirect("/Home/Index");
                return false;
            }
        }
    }
}