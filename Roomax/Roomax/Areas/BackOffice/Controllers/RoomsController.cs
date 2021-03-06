﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Roomax.Data;
using Roomax.Filters;
using Roomax.Models;

namespace Roomax.Areas.BackOffice.Controllers
{
    [AuthenticationFilter]
    public class RoomsController : BaseController
    {
        // GET: BackOffice/Rooms
        public ActionResult Index()
        {
            var rooms = db.Rooms.Include(r => r.User).Include(r => r.Category);
            return View(rooms.ToList());
        }

        // GET: BackOffice/Rooms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Room room = db.Rooms.Include(r => r.User).Include(r => r.Category).SingleOrDefault(x => x.ID == id);
            if (room == null)
            {
                return HttpNotFound();
            }
            return View(room);
        }

        // GET: BackOffice/Rooms/Create
        public ActionResult Create()
        {
            ViewBag.UserID = new SelectList(db.Users, "ID", "LastName");
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name");
            return View();
        }

        // POST: BackOffice/Rooms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Capacity,Price,Description,CreatedAt,UserID,CategoryID")] Room room)
        {
            if (ModelState.IsValid)
            {
                db.Rooms.Add(room);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserID = new SelectList(db.Users, "ID", "LastName", room.UserID);
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name", room.CategoryID);
            TempData["Message"] = "Salle créée";
            return View(room);
        }

        // GET: BackOffice/Rooms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Room room = db.Rooms.Include(x => x.Files).SingleOrDefault(x => x.ID == id);
            if (room == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserID = new SelectList(db.Users, "ID", "LastName", room.UserID);
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name", room.CategoryID);
            return View(room);
        }

        // POST: BackOffice/Rooms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Capacity,Price,Description,CreatedAt,UserID, CategoryID")] Room room)
        {
            //var old = db.Rooms.Find(room.ID);
            //room.CreatedAt = old.CreatedAt;
            //db.Entry(old).State = EntityState.Detached;

            if (ModelState.IsValid)
            {
                db.Entry(room).State = EntityState.Modified;
                db.SaveChanges();
                TempData["Message"] = "Salle modifiée";
                return RedirectToAction("Index");
            }
            ViewBag.UserID = new SelectList(db.Users, "ID", "LastName", room.UserID);
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name", room.CategoryID);
            return View(room);
        }

        // GET: BackOffice/Rooms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Room room = db.Rooms.Find(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            return View(room);
        }

        // POST: BackOffice/Rooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Room room = db.Rooms.Find(id);
            db.Rooms.Remove(room);
            db.SaveChanges();
            TempData["Message"] = "Salle supprimée";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult AddFile(int id, HttpPostedFileBase upload)
        {
            if (upload == null)
            {
                TempData["Message"] = "Aucun fichier selectionné";
                return RedirectToAction("Edit", new { id });
            }

            if (upload.ContentLength > 0)
            {
                var model = new RoomFile();

                model.RoomID = id;
                model.Name = upload.FileName;
                model.ContentType = upload.ContentType;

                using (var reader = new BinaryReader(upload.InputStream))
                {
                    model.Content = reader.ReadBytes(upload.ContentLength);
                }

                db.RoomFiles.Add(model);
                db.SaveChanges();
                TempData["Message"] = "Fichier ajouté";
                return RedirectToAction("Edit", new { id = model.RoomID });

            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }
        // GET: BackOffice/Rooms/Delete/5

        public ActionResult DeleteFile(int id)
        {
            RoomFile roomfile = db.RoomFiles.Find(id);
            db.RoomFiles.Remove(roomfile);
            db.SaveChanges();
            TempData["Message"] = "Fichier supprimé";
            return RedirectToAction("Edit", new { id = roomfile.RoomID });
        }
    }
}
