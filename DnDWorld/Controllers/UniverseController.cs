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

        public ActionResult ViewUniverse(string id = "0")
        {
            try
            {
                int universeID = id.ToInt();
                if (universeID > 0 && db.Universes.Any(u => u.UniverseID == universeID))
                {
                    //Bu evren mevcut
                    Universe universe = db.Universes.Find(universeID);
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
                            bool isPermitted = db.Permissions.Any(
                                p => 
                                p.PermissionTypeID == PermissionTypes.Read.ToInt() &&
                                p.ContentTypeID == ContentTypes.Universe.ToInt() &&
                                p.ContentID == universe.UniverseID &&
                                p.GrantedUserID == currentUser.UserID
                                );

                            if (isOwner || isPermitted)
                            {
                                //Kullanıcı bu içeriğin sahibi ya da görüntüleme iznine sahip
                                return View(universe);
                            }
                            else
                            {
                                //Kullanıcının bu içeriği görüntüleme izni yok.
                                return GenFunx.Go404();
                            }
                        }
                        else
                        {
                            //önce oturum aç
                            return GenFunx.Go404();
                        }
                    }
                }
                else
                {
                    //Böyle bir evren yok
                    return GenFunx.Go404();
                }
            }
            catch (Exception)
            {
                //Bir hata çıktı
                return GenFunx.Go404();
            }
        }
    }
}