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
    public class fechacalendariosController : Controller
    {
        private ProyectoBasesJAREntities9 db = new ProyectoBasesJAREntities9();

        // GET: fechacalendarios
        public ActionResult Index()
        {
            var fechacalendario = db.fechacalendario.Include(f => f.competiciontemporada).Include(f => f.usuario).Include(f => f.usuario1);
            return View(fechacalendario.ToList());
        }

        // GET: fechacalendarios/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fechacalendario fechacalendario = db.fechacalendario.Find(id);
            if (fechacalendario == null)
            {
                return HttpNotFound();
            }
            return View(fechacalendario);
        }

        // GET: fechacalendarios/Create
        public ActionResult Create()
        {
            ViewBag.idcompeticion = new SelectList(db.competiciontemporada, "idcompeticion", "idcompeticion");
            ViewBag.usrmodificador = new SelectList(db.usuario, "usuario1", "usuario1");
            ViewBag.usrcreador = new SelectList(db.usuario, "usuario1", "usuario1");
            return View();
        }

        // POST: fechacalendarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idcompeticion,idcalendario,fecha,idtemporada,usrcreador,fchcreacion,usrmodificador,fchmodificacion")] fechacalendario fechacalendario)
        {
            if (ModelState.IsValid)
            {
                db.fechacalendario.Add(fechacalendario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idcompeticion = new SelectList(db.competiciontemporada, "idcompeticion", "idcompeticion", fechacalendario.idcompeticion);
            ViewBag.usrmodificador = new SelectList(db.usuario, "usuario1", "usuario1", fechacalendario.usrmodificador);
            ViewBag.usrcreador = new SelectList(db.usuario, "usuario1", "usuario1", fechacalendario.usrcreador);
            return View(fechacalendario);
        }

        // GET: fechacalendarios/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fechacalendario fechacalendario = db.fechacalendario.Find(id);
            if (fechacalendario == null)
            {
                return HttpNotFound();
            }
            ViewBag.idcompeticion = new SelectList(db.competiciontemporada, "idcompeticion", "idcompeticion", fechacalendario.idcompeticion);
            ViewBag.usrmodificador = new SelectList(db.usuario, "usuario1", "usuario1", fechacalendario.usrmodificador);
            ViewBag.usrcreador = new SelectList(db.usuario, "usuario1", "usuario1", fechacalendario.usrcreador);
            return View(fechacalendario);
        }

        // POST: fechacalendarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idcompeticion,idcalendario,fecha,idtemporada,usrcreador,fchcreacion,usrmodificador,fchmodificacion")] fechacalendario fechacalendario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fechacalendario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idcompeticion = new SelectList(db.competiciontemporada, "idcompeticion", "idcompeticion", fechacalendario.idcompeticion);
            ViewBag.usrmodificador = new SelectList(db.usuario, "usuario1", "usuario1", fechacalendario.usrmodificador);
            ViewBag.usrcreador = new SelectList(db.usuario, "usuario1", "usuario1", fechacalendario.usrcreador);
            return View(fechacalendario);
        }

        // GET: fechacalendarios/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fechacalendario fechacalendario = db.fechacalendario.Find(id);
            if (fechacalendario == null)
            {
                return HttpNotFound();
            }
            return View(fechacalendario);
        }

        // POST: fechacalendarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            fechacalendario fechacalendario = db.fechacalendario.Find(id);
            db.fechacalendario.Remove(fechacalendario);
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
