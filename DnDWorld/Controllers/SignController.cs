using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DnDWorld.Controllers
{
    public class SignController : Controller
    {
        // GET: Sign
        public ActionResult SignUp()
        {
            return View();
        }
        public ActionResult SignIn()
        {
            return View();
        }
        public ActionResult SignOut()
        {
            return View();
        }
    }
}