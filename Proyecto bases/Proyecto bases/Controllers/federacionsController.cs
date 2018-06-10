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
    public class federacionsController : Controller
    {
        private ProyectoBasesJAREntities9 db = new ProyectoBasesJAREntities9();

        // GET: federacions
        public ActionResult Index()
        {
            var federacion = db.federacion.Include(f => f.usuario).Include(f => f.usuario1);
            return View(federacion.ToList());
        }

        // GET: federacions/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            federacion federacion = db.federacion.Find(id);
            if (federacion == null)
            {
                return HttpNotFound();
            }
            return View(federacion);
        }

        // GET: federacions/Create
        public ActionResult Create()
        {
            ViewBag.usrcreador = new SelectList(db.usuario, "usuario1", "usuario1");
            ViewBag.usrmodificador = new SelectList(db.usuario, "usuario1", "usuario1");
            return View();
        }

        // POST: federacions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idfederacion,nombre,fchfundada,usrcreador,fchcreacion,usrmodificador,fchmodificacion")] federacion federacion)
        {
            if (ModelState.IsValid)
            {
                db.federacion.Add(federacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.usrcreador = new SelectList(db.usuario, "usuario1", "usuario1", federacion.usrcreador);
            ViewBag.usrmodificador = new SelectList(db.usuario, "usuario1", "usuario1", federacion.usrmodificador);
            return View(federacion);
        }

        // GET: federacions/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            federacion federacion = db.federacion.Find(id);
            if (federacion == null)
            {
                return HttpNotFound();
            }
            ViewBag.usrcreador = new SelectList(db.usuario, "usuario1", "usuario1", federacion.usrcreador);
            ViewBag.usrmodificador = new SelectList(db.usuario, "usuario1", "usuario1", federacion.usrmodificador);
            return View(federacion);
        }

        // POST: federacions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idfederacion,nombre,fchfundada,usrcreador,fchcreacion,usrmodificador,fchmodificacion")] federacion federacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(federacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.usrcreador = new SelectList(db.usuario, "usuario1", "usuario1", federacion.usrcreador);
            ViewBag.usrmodificador = new SelectList(db.usuario, "usuario1", "usuario1", federacion.usrmodificador);
            return View(federacion);
        }

        // GET: federacions/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            federacion federacion = db.federacion.Find(id);
            if (federacion == null)
            {
                return HttpNotFound();
            }
            return View(federacion);
        }

        // POST: federacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            federacion federacion = db.federacion.Find(id);
            db.federacion.Remove(federacion);
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
