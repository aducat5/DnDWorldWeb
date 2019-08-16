using DnDWorld.Models;
using DnDWorld.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DnDWorld.Controllers
{
    public class SignController : Controller
    {

        [NonUserAuth]
        public ActionResult SignUp() => View();
        [NonUserAuth]
        public ActionResult SignIn() => View();

        [HttpPost]
        public ActionResult SignUp(User newUser)
        {
            DnDWorldDBEntities db = DBTools.GetDB();

            newUser.CreateDate = DateTime.Now;
            newUser.UpdateDate = newUser.CreateDate;
            try
            {

                db.Users.Add(newUser);
                if (db.SaveChanges() > 0)
                {
                    return RedirectToAction("SignIn", new { regState = "suc" });
                }
                else
                {
                    ViewBag.RegState = "Kayıt sırasında bir hata oluştu.";
                    ViewBag.AlertState = "alert alert-danger";
                    return View();
                }

            }
            catch (Exception ex)
            {
                ViewBag.RegState = "Bilinmeyen bir hata oluştu" + ex.Message;
                ViewBag.AlertState = "alert alert-danger";
                return View();
            }
        }

        [HttpPost]
        public ActionResult SignIn(string txtUserName, string txtPassword)
        {
            DnDWorldDBEntities db = DBTools.GetDB();

            if (db.Users.Any(u => (u.Email == txtUserName && u.Password == txtPassword)))
            {
                User currentUser = db.Users.Where(u => (u.Email == txtUserName && u.Password == txtPassword)).FirstOrDefault();

                Session["user"] = currentUser;

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.LoginState = "Giriş başarısız oldu. Kullanıcı adı veya şifre yanlış.";
                ViewBag.AlertState = "alert alert-danger";

                return View();
            }
        }
        public ActionResult SignOut()
        {
            Session["user"] = null;

            return RedirectToAction("Index", "Home");
        }
    }
}