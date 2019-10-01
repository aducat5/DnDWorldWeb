using DnDWorld.BSL.Authorization;
using DnDWorld.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DnDWorld.PL.WEB.Controllers
{
    public class CampaignController : Controller
    {
        [UserAuth]
        public ActionResult Create()
        {
            return View();
        }

        [UserAuth, HttpPost]
        public ActionResult Create(Campaign newCampaign)
        {
            return View();
        }

    }
}