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
    public class temporadaController : Controller
    {
        private ProyectoBasesJAREntities9 db = new ProyectoBasesJAREntities9();

        // GET: temporadas
        public ActionResult Index()
        {
            var temporada = db.temporada.Include(t => t.usuario).Include(t => t.usuario1);
            return View(temporada.ToList());
        }

        // GET: temporadas/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            temporada temporada = db.temporada.Find(id);
            if (temporada == null)
            {
                return HttpNotFound();
            }
            return View(temporada);
        }

        // GET: temporadas/Create
        public ActionResult Create()
        {
            ViewBag.usrmodificador = new SelectList(db.usuario, "usuario1", "usuario1");
            ViewBag.usrcreador = new SelectList(db.usuario, "usuario1", "usuario1");
            return View();
        }

        // POST: temporadas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idtemporada,nombre,usrcreador,fchcreacion,usrmodificador,fchmodificacion")] temporada temporada)
        {
            if (ModelState.IsValid)
            {
                db.temporada.Add(temporada);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.usrmodificador = new SelectList(db.usuario, "usuario1", "usuario1", temporada.usrmodificador);
            ViewBag.usrcreador = new SelectList(db.usuario, "usuario1", "usuario1", temporada.usrcreador);
            return View(temporada);
        }

        // GET: temporadas/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            temporada temporada = db.temporada.Find(id);
            if (temporada == null)
            {
                return HttpNotFound();
            }
            ViewBag.usrmodificador = new SelectList(db.usuario, "usuario1", "usuario1", temporada.usrmodificador);
            ViewBag.usrcreador = new SelectList(db.usuario, "usuario1", "usuario1", temporada.usrcreador);
            return View(temporada);
        }

        // POST: temporadas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idtemporada,nombre,usrcreador,fchcreacion,usrmodificador,fchmodificacion")] temporada temporada)
        {
            if (ModelState.IsValid)
            {
                db.Entry(temporada).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.usrmodificador = new SelectList(db.usuario, "usuario1", "usuario1", temporada.usrmodificador);
            ViewBag.usrcreador = new SelectList(db.usuario, "usuario1", "usuario1", temporada.usrcreador);
            return View(temporada);
        }

        // GET: temporadas/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            temporada temporada = db.temporada.Find(id);
            if (temporada == null)
            {
                return HttpNotFound();
            }
            return View(temporada);
        }

        // POST: temporadas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            temporada temporada = db.temporada.Find(id);
            db.temporada.Remove(temporada);
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
