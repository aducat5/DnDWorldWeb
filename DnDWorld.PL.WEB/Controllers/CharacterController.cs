using DnDWorld.BLL.Repositories;
using DnDWorld.BSL.Authorization;
using DnDWorld.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DnDWorld.PL.WEB.Controllers
{
    public class CharacterController : Controller
    {
        PlanetRepo pr = new PlanetRepo();

        [UserAuth]
        public ActionResult Create()
        {
            User currentUser = Session["user"] as User;



            return View();
        }
    }
}