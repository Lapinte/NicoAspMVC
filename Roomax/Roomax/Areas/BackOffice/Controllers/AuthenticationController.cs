using Roomax.Areas.BackOffice.Models;
using Roomax.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Roomax.Utils;
using Roomax.Filters;


namespace Roomax.Areas.BackOffice.Controllers
{

    public class AuthenticationController : BaseController
    {
        // GET: BackOffice/Authentication/Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: BackOffice/Authentication/Login
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Login(AuthenticationLoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var passwordHash = model.Password.HashMD5();
                var user = db.Users.SingleOrDefault(x => x.Mail == model.Login && x.Password == passwordHash);
                if (user == null)
                {
                    TempData["Message"] = "Utilisateur ou Mot de passe incorrect";
                    ModelState.AddModelError("", "Utilisateur ou Mot de passe incorrect");
                    return View(model);
                }
                else
                {
                    Session.Add("USER_BO", user);
                    Session["USER_NAME"] = user.FirstName;
                    TempData["Message"] = "Login effectué";
                    return RedirectToAction("Index", "Dashboard", new { area = "BackOffice" });
                }
                
            }
            return View(model);


        }

        // GET : BackOffice/Authentication/Logout
        [AuthenticationFilter]
        public ActionResult Logout()
        {
            Session.Clear();
            TempData["Message"] = "Vous êtes déconnecté";
            
            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}