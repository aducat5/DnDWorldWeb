using DnDWorld.BLL.Repositories;
using DnDWorld.BSL.Authorization;
using DnDWorld.DAL;
using System.Web.Mvc;

namespace DnDWorld.PL.WEB.Controllers
{
    public class PlanetController : Controller
    {
        PlanetRepo planetRepo = new PlanetRepo();

        [UserAuth]
        public ActionResult Create() => View();

        [UserAuth, HttpPost]
        public ActionResult Create(string txtPlanetName, string txtUniverseID, bool chkIsPublic = false)
        {
            return View();
        }

    }
}