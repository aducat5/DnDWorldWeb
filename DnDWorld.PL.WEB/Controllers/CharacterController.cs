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
    public class CharacterController : Controller
    {
        CharacterRepo cr = new CharacterRepo();

        [UserAuth]
        public ActionResult Create()
        {
            return View();
        }

        [UserAuth, HttpPost]
        public ActionResult Create(FormCollection formElements)
        {
            User currentUser = Session["user"] as User;
            Character newChar = new Character()
            {
                CreateDate = DateTime.Now,
                UpdateDate = DateTime.Now,
                IsDead = false,
                IsDeleted = false,
                Experience = formElements["experience"].ToInt(),
                RaceID = formElements["subraceID"].ToInt(),
                Fullname = formElements["txtCharacterName"],
                OwnerID = currentUser.UserID,
                PicturePath = "~/Content/img/race/def.png"
            };
            List<int> classes = new List<int>();
            foreach (string formElement in formElements)
            {
                if (formElement.Contains("classID"))
                {
                    int classID = formElements[formElement].ToInt();
                    if (!classes.Contains(classID))
                    {
                        classes.Add(classID);
                    }
                    else
                    {
                        ViewBag.AlertMessage = "Çoklu sınfılama yaparken aynı sınıfı iki kere seçemezsiniz.";
                        ViewBag.AlertClass = "alert alert-danger";
                        return View();
                    }
                }
            }

            if (cr.InsertCharacter(newChar, out string islemSonucu))
            {
                foreach (int classID in classes)
                {
                    cr.AddClassToCharacter(classID, newChar.CharacterID);
                }

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