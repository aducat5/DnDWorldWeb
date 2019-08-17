using DnDWorld.Models;
using DnDWorld.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DnDWorld.Utility;

namespace DnDWorld.Controllers
{
    public class UniverseController : Controller
    {
        DnDWorldDBEntities db = DBTools.GetDB();
        // GET: Universe
        [UserAuth]
        public ActionResult Create()
        {
            return View(GetUniversesOfUser((Session["user"] as User).UserID));
        }

        [UserAuth, HttpPost]
        public ActionResult Create(string txtUniverseName, bool chkIsPublic = false)
        {
            if (db.Universes.Any(u => u.Fullname == txtUniverseName))
            {
                ViewBag.AlertMessage = "Bu isim zaten kullanımda";
                ViewBag.AlertClass = "alert alert-danger";
                return View(GetUniversesOfUser((Session["user"] as User).UserID));
            }
            else
            {
                Universe newUniverse = new Universe()
                {
                    Fullname = txtUniverseName,
                    IsPublic = !chkIsPublic,
                    OwnerID = (Session["user"] as User).UserID
                };
                try
                {
                    db.Universes.Add(newUniverse);
                    if (db.SaveChanges() > 0)
                    {
                        return RedirectToAction("View", "Profile", new { uniState = "suc" });
                    }
                    else
                    {
                        ViewBag.AlertMessage = "Kayıt esnasında bir hata oluştu";
                        ViewBag.AlertClass = "alert alert-danger";
                        return View(GetUniversesOfUser((Session["user"] as User).UserID));
                    }
                }
                catch (Exception ex)
                {

                    ViewBag.AlertMessage = "Kayıt esnasında bir çalışma zamanı hatası oluştu: " + ex.Message;
                    ViewBag.AlertClass = "alert alert-danger";
                    return View(GetUniversesOfUser((Session["user"] as User).UserID));
                }

            }
        }

        public List<Universe> GetUniversesOfUser(int userID)
        {
            List<Universe> universes = null;
            universes = db.Universes.Where(u => u.OwnerID == userID).ToList();
            return universes;
        }
    }
}