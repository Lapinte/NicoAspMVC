using Roomax.Data;
using Roomax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Roomax.Utils;

namespace Roomax.Controllers
{
    public class UsersController : Controller
    {
        private RoomaxDbContext db = new RoomaxDbContext();
        // GET: Users
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Civilities = db.Civilities.ToList();

            return View();
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                db.Configuration.ValidateOnSaveEnabled = false;
                user.Password = user.Password.HashMD5();

                //enregistrer en bdd
                db.Users.Add(user);
                db.SaveChanges();

                //redirection
                TempData["Message"] = $"L'utilisateur {user.FirstName} est enregistré.";
                return RedirectToAction("Index", "Home");

            }
            ViewBag.Civilities = db.Civilities.ToList();
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose(); //libère la connexion à la BDD
            base.Dispose(disposing);
        }
    }
}