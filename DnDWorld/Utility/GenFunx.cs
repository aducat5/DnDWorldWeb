using DnDWorld.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DnDWorld.Utility
{
    public static class GenFunx
    {
        public static ActionResult Go404()
        {
            HttpContext.Current.Response.Redirect("/Home/NotFound");
            return null;
        }
        public static int ToInt(this Enum enumValue)
        {
            return Convert.ToInt32(enumValue);
        }

        public static int ToInt(this string stringValue)
        {
            return Convert.ToInt32(stringValue);
        }

    }
}