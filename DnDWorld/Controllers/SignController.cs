using DnDWorld.Models;
using DnDWorld.Models.Database;
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
        DnDWorldDBEntities db = DBTools.GetDB();
        /// <summary>
        /// Checks User from DB and returns as User if there is user. Returns null if there is not.
        /// </summary>
        /// <param name="txtEmail"></param>
        /// <param name="txtPassword"></param>
        /// <returns></returns>
        public User CheckUser(string txtEmail, string txtPassword)
        {
            User currentUser = null;
            if (db.Users.Any(u => (u.Email == txtEmail && u.Password == txtPassword))) currentUser = db.Users.Where(u => (u.Email == txtEmail && u.Password == txtPassword)).FirstOrDefault();
            return currentUser;
        }

        [NonUserAuth]
        public ActionResult SignUp() => View();
        [NonUserAuth]
        public ActionResult SignIn() => View();

        [HttpPost]
        public ActionResult SignUp(User newUser)
        {
            newUser.CreateDate = DateTime.Now;
            newUser.UpdateDate = newUser.CreateDate;
            try
            {
                if (db.Users.Any(u => (u.Email == newUser.Email)))
                {
                    ViewBag.RegState = "Bu email zaten kullanımda.";
                    ViewBag.AlertState = "alert alert-danger";
                    return View();
                }
                else
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
            }
            catch (Exception ex)
            {
                ViewBag.RegState = "Bilinmeyen bir hata oluştu" + ex.Message;
                ViewBag.AlertState = "alert alert-danger";
                return View();
            }
        }

        [HttpPost]
        public ActionResult SignIn(string txtEmail, string txtPassword)
        {
            DnDWorldDBEntities db = DBTools.GetDB();


            User currentUser = CheckUser(txtEmail, txtPassword);
            if (currentUser != null)
            {
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