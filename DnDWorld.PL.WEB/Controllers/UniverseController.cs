using DnDWorld.BLL.CustomExceptions;
using DnDWorld.BLL.Repositories;
using DnDWorld.BSL.Authorization;
using DnDWorld.DAL;
using DnDWorld.BLL.Utility;
using System;
using System.Linq;
using System.Web.Mvc;

namespace DnDWorld.PL.WEB.Controllers
{
    public class UniverseController : Controller
    {
        UniverseRepo universeRepo = new UniverseRepo();

        [UserAuth]
        public ActionResult Create() => View(universeRepo.GetUniversesByUser((Session["user"] as User).UserID));

        [UserAuth, HttpPost]
        public ActionResult Create(string txtUniverseName, bool chkIsPublic = false)
        {
            if (universeRepo.DoesUniverseExists(txtUniverseName))
            {
                ViewBag.AlertMessage = "Bu isim zaten kullanımda";
                ViewBag.AlertClass = "alert alert-danger";
                return View(universeRepo.GetUniversesByUser((Session["user"] as User).UserID));
            }
            else
            {
                Universe newUniverse = new Universe()
                {
                    Fullname = txtUniverseName,
                    IsPublic = !chkIsPublic,
                    OwnerID = (Session["user"] as User).UserID
                };
                bool sonuc = universeRepo.InsertUniverse(newUniverse, out string islemSonucu);
                if (sonuc)
                {
                    return RedirectToAction("View", "Profile", new { uniState = "suc" });
                }
                else
                {
                    ViewBag.AlertMessage = islemSonucu;
                    ViewBag.AlertClass = "alert alert-danger";
                    return View(universeRepo.GetUniversesByUser((Session["user"] as User).UserID));
                }
            }
        }

        public ActionResult ViewUniverse(string id = "0")
        {
            try
            {
                int universeID = id.ToInt();
                if (universeID > 0 && universeRepo.DoesUniverseExists(universeID))
                {
                    //Bu evren mevcut
                    Universe universe = universeRepo.GetUniverse(universeID);
                    if (universe.IsPublic)
                    {
                        //Evren halka açık, herkes görebilir
                        return View(universe);
                    }
                    else
                    {
                        //Evren özel
                        if (Session["user"] != null)
                        {
                            //oturum açık
                            User currentUser = Session["user"] as User;

                            bool isOwner = universe.OwnerID == currentUser.UserID;
                            bool isPermitted = UserRepo.IsUserAllowed(currentUser.UserID, universe.UniverseID, PermissionTypes.Read, ContentTypes.Universe);

                            if (isOwner || isPermitted) return View(universe);
                            else throw new PageNotFoundException();
                        }
                        else throw new PageNotFoundException();
                    }
                }
                else throw new PageNotFoundException();  
            }
            catch (Exception)
            {
                throw new PageNotFoundException();
            }
        }
    }
}