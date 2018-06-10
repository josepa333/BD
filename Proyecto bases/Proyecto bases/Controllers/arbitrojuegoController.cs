﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Proyecto_bases.Models;

namespace Proyecto_bases.Controllers
{
    public class arbitrojuegoController : Controller
    {
        private ProyectoBasesJAREntities9 db = new ProyectoBasesJAREntities9();

        // GET: arbitrojuegoes
        public ActionResult Index()
        {
            var arbitrojuego = db.arbitrojuego.Include(a => a.arbitro).Include(a => a.usuario).Include(a => a.usuario1).Include(a => a.juego);
            return View(arbitrojuego.ToList());
        }

        // GET: arbitrojuegoes/Details/5
        public ActionResult Details(int id, string id2)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            arbitrojuego arbitrojuego = db.arbitrojuego.Find(id, id2);
            if (arbitrojuego == null)
            {
                return HttpNotFound();
            }
            return View(arbitrojuego);
        }

        // GET: arbitrojuegoes/Create
        public ActionResult Create()
        {
            ViewBag.idarbitro = new SelectList(db.arbitro, "idarbitro", "idarbitro");
            ViewBag.usrcreador = new SelectList(db.usuario, "usuario1", "usuario1");
            ViewBag.usrmodificador = new SelectList(db.usuario, "usuario1", "usuario1");
            ViewBag.idjuego = new SelectList(db.juego, "idjuego", "idjuego");
            return View();
        }

        // POST: arbitrojuegoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "calificacion,tipo,idjuego,idarbitro,usrcreador,fchcreacion,usrmodificador,fchmodificacion")] arbitrojuego arbitrojuego)
        {
            if (ModelState.IsValid)
            {
                db.arbitrojuego.Add(arbitrojuego);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idarbitro = new SelectList(db.arbitro, "idarbitro", "idarbitro", arbitrojuego.idarbitro);
            ViewBag.usrcreador = new SelectList(db.usuario, "usuario1", "usuario1", arbitrojuego.usrcreador);
            ViewBag.usrmodificador = new SelectList(db.usuario, "usuario1", "usuario1", arbitrojuego.usrmodificador);
            ViewBag.idjuego = new SelectList(db.juego, "idjuego", "idjuego", arbitrojuego.idjuego);
            return View(arbitrojuego);
        }

        // GET: arbitrojuegoes/Edit/5
        public ActionResult Edit(int id, string id2)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            arbitrojuego arbitrojuego = db.arbitrojuego.Find(id, id2);
            if (arbitrojuego == null)
            {
                return HttpNotFound();
            }
            ViewBag.idarbitro = new SelectList(db.arbitro, "idarbitro", "idarbitro", arbitrojuego.idarbitro);
            ViewBag.usrcreador = new SelectList(db.usuario, "usuario1", "usuario1", arbitrojuego.usrcreador);
            ViewBag.usrmodificador = new SelectList(db.usuario, "usuario1", "usuario1", arbitrojuego.usrmodificador);
            ViewBag.idjuego = new SelectList(db.juego, "idjuego", "idjuego", arbitrojuego.idjuego);
            return View(arbitrojuego);
        }

        // POST: arbitrojuegoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "calificacion,tipo,idjuego,idarbitro,usrcreador,fchcreacion,usrmodificador,fchmodificacion")] arbitrojuego arbitrojuego)
        {
            if (ModelState.IsValid)
            {
                db.Entry(arbitrojuego).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idarbitro = new SelectList(db.arbitro, "idarbitro", "idarbitro", arbitrojuego.idarbitro);
            ViewBag.usrcreador = new SelectList(db.usuario, "usuario1", "usuario1", arbitrojuego.usrcreador);
            ViewBag.usrmodificador = new SelectList(db.usuario, "usuario1", "usuario1", arbitrojuego.usrmodificador);
            ViewBag.idjuego = new SelectList(db.juego, "idjuego", "idjuego", arbitrojuego.idjuego);
            return View(arbitrojuego);
        }

        // GET: arbitrojuegoes/Delete/5
        public ActionResult Delete(int id, string id2)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            arbitrojuego arbitrojuego = db.arbitrojuego.Find(id, id2);
            if (arbitrojuego == null)
            {
                return HttpNotFound();
            }
            return View(arbitrojuego);
        }

        // POST: arbitrojuegoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, string id2)
        {
            arbitrojuego arbitrojuego = db.arbitrojuego.Find(id,id2);
            db.arbitrojuego.Remove(arbitrojuego);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
