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
    public class competicionsController : Controller
    {
        private ProyectoBasesJAREntities8 db = new ProyectoBasesJAREntities8();

        // GET: competicions
        public ActionResult Index()
        {
            var competicion = db.competicion.Include(c => c.usuario).Include(c => c.usuario1);
            return View(competicion.ToList());
        }

        // GET: competicions/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            competicion competicion = db.competicion.Find(id);
            if (competicion == null)
            {
                return HttpNotFound();
            }
            return View(competicion);
        }

        // GET: competicions/Create
        public ActionResult Create()
        {
            ViewBag.usrcreador = new SelectList(db.usuario, "usuario1", "usuario1");
            ViewBag.usrmodificador = new SelectList(db.usuario, "usuario1", "usuario1");
            return View();
        }

        // POST: competicions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idcompeticion,tipo,nombre,usrcreador,fchcreacion,usrmodificador,usrmodificacion")] competicion competicion)
        {
            if (ModelState.IsValid)
            {
                db.competicion.Add(competicion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.usrcreador = new SelectList(db.usuario, "usuario1", "usuario1", competicion.usrcreador);
            ViewBag.usrmodificador = new SelectList(db.usuario, "usuario1", "usuario1", competicion.usrmodificador);
            return View(competicion);
        }

        // GET: competicions/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            competicion competicion = db.competicion.Find(id);
            if (competicion == null)
            {
                return HttpNotFound();
            }
            ViewBag.usrcreador = new SelectList(db.usuario, "usuario1", "usuario1", competicion.usrcreador);
            ViewBag.usrmodificador = new SelectList(db.usuario, "usuario1", "usuario1", competicion.usrmodificador);
            return View(competicion);
        }

        // POST: competicions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idcompeticion,tipo,nombre,usrcreador,fchcreacion,usrmodificador,usrmodificacion")] competicion competicion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(competicion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.usrcreador = new SelectList(db.usuario, "usuario1", "usuario1", competicion.usrcreador);
            ViewBag.usrmodificador = new SelectList(db.usuario, "usuario1", "usuario1", competicion.usrmodificador);
            return View(competicion);
        }

        // GET: competicions/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            competicion competicion = db.competicion.Find(id);
            if (competicion == null)
            {
                return HttpNotFound();
            }
            return View(competicion);
        }

        // POST: competicions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            competicion competicion = db.competicion.Find(id);
            db.competicion.Remove(competicion);
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
