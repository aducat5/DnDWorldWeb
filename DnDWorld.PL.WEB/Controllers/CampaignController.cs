using DnDWorld.BLL.Repositories;
using DnDWorld.BLL.Utility;
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
        CampaignRepo cr = new CampaignRepo();
        [UserAuth]
        public ActionResult Create()
        {
            return View();
        }

        [UserAuth, HttpPost]
        public ActionResult Create(string universeID, string planetID, string txtCampaignName, bool chkIsPublic = false)
        {
            int uniID = universeID.ToInt();
            int plaID = planetID.ToInt();


            User current = Session["user"] as User;

            Campaign newCampaign = new Campaign()
            {
                CreateDate = DateTime.Now,
                Fullname = txtCampaignName.ClearText(),
                IsOpen = false,
                IsDeleted = false,
                UpdateDate = DateTime.Now,
                UniverseID = uniID,
                PlanetID = plaID,
                OwnerID = current.UserID
            };

            bool sonuc = cr.InsertCampaign(newCampaign, out string islemSonucu);
            if (sonuc)
            {
                return RedirectToAction("ViewProfile", "Profile");
            }
            else
            {
                ViewBag.AlertMessage = islemSonucu;
                ViewBag.AlertClass = "alert alert-danger";
                return View();
            }
        }

    }
}