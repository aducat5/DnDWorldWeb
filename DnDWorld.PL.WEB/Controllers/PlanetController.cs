using DnDWorld.BLL.CustomExceptions;
using DnDWorld.BLL.Repositories;
using DnDWorld.BLL.Utility;
using DnDWorld.BSL.Authorization;
using DnDWorld.DAL;
using System.Web.Mvc;

namespace DnDWorld.PL.WEB.Controllers
{
    public class PlanetController : Controller
    {
        PlanetRepo planetRepo = new PlanetRepo();
        UniverseRepo universeRepo = new UniverseRepo();

        [UserAuth]
        public ActionResult Create() => View(universeRepo.GetUniverses((Session["user"] as User).UserID));


        [UserAuth, HttpPost]
        public ActionResult Create(string txtPlanetName, string universeID, bool chkIsPublic = false)
        {
            int uniID = universeID.ToInt();
            if (planetRepo.DoesPlanetExists(uniID, txtPlanetName))
            {
                ViewBag.AlertMessage = "Bu isim zaten kullanımda";
                ViewBag.AlertClass = "alert alert-danger";
                return View(universeRepo.GetUniverses((Session["user"] as User).UserID));
            }
            else
            {
                Planet newPlanet = new Planet()
                {
                    Fullname = txtPlanetName,
                    IsPublic = chkIsPublic,
                    OwnerID = (Session["user"] as User).UserID,
                    UniverseID = uniID

                };
                bool sonuc = planetRepo.InsertPlanet(newPlanet, out string islemSonucu);
                if (sonuc)
                {
                    return RedirectToAction("ViewProfile", "Profile", new { plaState = "suc" });
                }
                else
                {
                    ViewBag.AlertMessage = islemSonucu;
                    ViewBag.AlertClass = "alert alert-danger";
                    return View(universeRepo.GetUniverses((Session["user"] as User).UserID));
                }
            }
        }

        public ActionResult ViewPlanet(string id = "0")
        {
            int planetID = id.ToInt();
            if (planetID > 0 && planetRepo.DoesPlanetExists(planetID))
            {
                Planet planet = planetRepo.GetPlanet(planetID);
                return View(planet);
            }
            else throw new PageNotFoundException();
        }

    }
}