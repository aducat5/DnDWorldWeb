using DnDWorld.BLL.CustomExceptions;
using DnDWorld.BLL.Repositories;
using DnDWorld.BSL.Authorization;
using DnDWorld.DAL;
using DnDWorld.BLL.Utility;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;

namespace DnDWorld.PL.WEB.Controllers
{
    public class UniverseController : Controller
    {
        UniverseRepo universeRepo = new UniverseRepo();

        [UserAuth]
        public ActionResult Create() => View(universeRepo.GetUniverses((Session["user"] as User).UserID));

        [UserAuth, HttpPost]
        public ActionResult Create(string txtUniverseName, bool chkIsPublic = false)
        {
            if (universeRepo.DoesUniverseExists(txtUniverseName))
            {
                ViewBag.AlertMessage = "Bu isim zaten kullanımda";
                ViewBag.AlertClass = "alert alert-danger";
                return View(universeRepo.GetUniverses((Session["user"] as User).UserID));
            }
            else
            {
                Universe newUniverse = new Universe()
                {
                    Fullname = txtUniverseName,
                    IsPublic = chkIsPublic,
                    OwnerID = (Session["user"] as User).UserID
                };
                bool sonuc = universeRepo.InsertUniverse(newUniverse, out string islemSonucu);
                if (sonuc)
                {
                    return RedirectToAction("ViewProfile", "Profile", new { uniState = "suc" });
                }
                else
                {
                    ViewBag.AlertMessage = islemSonucu;
                    ViewBag.AlertClass = "alert alert-danger";
                    return View(universeRepo.GetUniverses((Session["user"] as User).UserID));
                }
            }
        }

        [UserAuth, HttpPost]
        public int CreateWithApi(string txtUniverseName)
        {
            if (universeRepo.DoesUniverseExists(txtUniverseName))
            {
                ViewBag.AlertMessage = "Bu isim zaten kullanımda";
                ViewBag.AlertClass = "alert alert-danger";
                return 0;
            }
            else
            {
                Universe newUniverse = new Universe()
                {
                    Fullname = txtUniverseName,
                    IsPublic = false,
                    OwnerID = (Session["user"] as User).UserID
                };

                bool sonuc = universeRepo.InsertUniverse(newUniverse, out string islemSonucu);
                return newUniverse.UniverseID;
            }
        }

        public ActionResult ViewUniverse(string id = "0")
        {
            int universeID = id.ToInt();
            if (universeID > 0 && universeRepo.DoesUniverseExists(universeID))
            {
                //Bu evren mevcut
                Universe universe = universeRepo.GetUniverse(universeID);
                return View(universe);
            }
            else throw new PageNotFoundException();
        }

        [UserAuth]
        public JsonResult GetExtendableUniverses()
        {
            User user = Session["user"] as User;
            List<Universe> universes = universeRepo.GetUniverses(user.UserID, PermissionTypes.Extend);
            List<Universe> universesDTO = new List<Universe>();
            foreach (Universe universe in universes)
            {
                universesDTO.Add(new Universe()
                {
                    Fullname = universe.Fullname,
                    IsPublic = universe.IsPublic,
                    OwnerID = universe.OwnerID,
                    UniverseID = universe.UniverseID
                });
            }
            return Json(universesDTO, JsonRequestBehavior.AllowGet);
        }
    }
}