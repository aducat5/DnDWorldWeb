using DnDWorld.BLL.Repositories;
using DnDWorld.BLL.Utility;
using DnDWorld.BSL.Authorization;
using DnDWorld.DAL;
using System;
using System.Web.Mvc;
using System.Linq;

namespace DnDWorld.PL.WEB.Controllers
{
    public class SignController : Controller
    {
        UserRepo userRepo = new UserRepo();

        [NonUserAuth]
        public ActionResult SignUp() => View();
        [NonUserAuth]
        public ActionResult SignIn() => View();

        [HttpPost]
        public ActionResult SignUp(User newUser)
        {
            string islemSonucu;
            bool sonuc = userRepo.InsertUser(newUser, out islemSonucu);
            if (sonuc)
            {
                return RedirectToAction("SignIn", new { regState = "suc" });
            }
            else
            {
                ViewBag.RegState = islemSonucu;
                ViewBag.AlertState = "alert alert-danger";
                return View();
            }
        }

        [HttpPost]
        public ActionResult SignIn(string txtEmail, string txtPassword)
        {
            try
            {
                Session["user"] = userRepo.GetUser(txtEmail, txtPassword);
                if (Session["user"] != null)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.LoginState = "Giriş başarısız oldu. Kullanıcı adı veya şifre yanlış.";
                    ViewBag.AlertState = "alert alert-danger";
                    return View();
                }
            }
            catch (Exception ex)
            {
                int eventLogID = LogTypes.Error.ToInt();
                EventLog loginError = new EventLog()
                {
                    LogTypeID = eventLogID,
                    LogMessage = ex.Message,
                    CreateDate = DateTime.Now,
                    MachineName = Server.MachineName,
                    Detail = ex.InnerException + " - " + ex.StackTrace  
                };
                throw;
            }
        }
        public ActionResult SignOut()
        {
            Session["user"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}