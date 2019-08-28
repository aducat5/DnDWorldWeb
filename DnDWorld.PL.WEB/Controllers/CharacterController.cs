using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DnDWorld.PL.WEB.Controllers
{
    public class CharacterController : Controller
    {
        // GET: Character
        public ActionResult Create()
        {
            return View();
        }
    }
}