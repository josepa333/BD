using System;
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
    public class clubsController : Controller
    {
        private ProyectoBasesJAREntities8 db = new ProyectoBasesJAREntities8();

        // GET: clubs
        public ActionResult Index()
        {
            var club = db.club.Include(c => c.federacion).Include(c => c.usuario).Include(c => c.usuario1);
            return View(club.ToList());
        }

        // GET: clubs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            club club = db.club.Find(id);
            if (club == null)
            {
                return HttpNotFound();
            }
            return View(club);
        }

        // GET: clubs/Create
        public ActionResult Create()
        {
            ViewBag.idfederacion = new SelectList(db.federacion, "idfederacion", "idfederacion");
            ViewBag.usrcreador = new SelectList(db.usuario, "usuario1", "usuario1");
            ViewBag.usrmodificador = new SelectList(db.usuario, "usuario1", "usuario1");
            return View();
        }

        // POST: clubs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idclub,nombre,fchfundado,idfederacion,usrcreador,fchcreacion,usrmodificador,fchmodificacion")] club club)
        {
            if (ModelState.IsValid)
            {
                db.club.Add(club);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idfederacion = new SelectList(db.federacion, "idfederacion", "idfederacion", club.idfederacion);
            ViewBag.usrcreador = new SelectList(db.usuario, "usuario1", "usuario1", club.usrcreador);
            ViewBag.usrmodificador = new SelectList(db.usuario, "usuario1", "usuario1", club.usrmodificador);
            return View(club);
        }

        // GET: clubs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            club club = db.club.Find(id);
            if (club == null)
            {
                return HttpNotFound();
            }
            ViewBag.idfederacion = new SelectList(db.federacion, "idfederacion", "idfederacion", club.idfederacion);
            ViewBag.usrcreador = new SelectList(db.usuario, "usuario1", "usuario1", club.usrcreador);
            ViewBag.usrmodificador = new SelectList(db.usuario, "usuario1", "usuario1", club.usrmodificador);
            return View(club);
        }

        // POST: clubs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idclub,nombre,fchfundado,idfederacion,usrcreador,fchcreacion,usrmodificador,fchmodificacion")] club club)
        {
            if (ModelState.IsValid)
            {
                db.Entry(club).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idfederacion = new SelectList(db.federacion, "idfederacion", "idfederacion", club.idfederacion);
            ViewBag.usrcreador = new SelectList(db.usuario, "usuario1", "usuario1", club.usrcreador);
            ViewBag.usrmodificador = new SelectList(db.usuario, "usuario1", "usuario1", club.usrmodificador);
            return View(club);
        }

        // GET: clubs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            club club = db.club.Find(id);
            if (club == null)
            {
                return HttpNotFound();
            }
            return View(club);
        }

        // POST: clubs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            club club = db.club.Find(id);
            db.club.Remove(club);
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
