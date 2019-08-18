using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DnDWorld.BSL.Authorization
{
    public class UserAuth : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.Session["user"] != null)
                return true;
            else
            {
                httpContext.Response.Redirect("/Sign/SignUp");
                return false;
            }
        }
    }
}
