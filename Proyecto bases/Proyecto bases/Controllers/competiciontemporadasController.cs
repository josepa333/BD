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
    public class competiciontemporadasController : Controller
    {
        private ProyectoBasesJAREntities1 db = new ProyectoBasesJAREntities1();

        // GET: competiciontemporadas
        public ActionResult Index()
        {
            var competiciontemporada = db.competiciontemporada.Include(c => c.competicion).Include(c => c.temporada).Include(c => c.usuario).Include(c => c.usuario1);
            return View(competiciontemporada.ToList());
        }

        // GET: competiciontemporadas/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            competiciontemporada competiciontemporada = db.competiciontemporada.Find(id);
            if (competiciontemporada == null)
            {
                return HttpNotFound();
            }
            return View(competiciontemporada);
        }

        // GET: competiciontemporadas/Create
        public ActionResult Create()
        {
            ViewBag.idcompeticion = new SelectList(db.competicion, "idcompeticion", "tipo");
            ViewBag.idtemporada = new SelectList(db.temporada, "idtemporada", "nombre");
            ViewBag.usrcreador = new SelectList(db.usuario, "usuario1", "usrcreador");
            ViewBag.usrmodificador = new SelectList(db.usuario, "usuario1", "usrcreador");
            return View();
        }

        // POST: competiciontemporadas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idcompeticion,idtemporada,usrcreador,fchcreacion,usrmodificador,fchmodificacion")] competiciontemporada competiciontemporada)
        {
            if (ModelState.IsValid)
            {
                db.competiciontemporada.Add(competiciontemporada);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idcompeticion = new SelectList(db.competicion, "idcompeticion", "tipo", competiciontemporada.idcompeticion);
            ViewBag.idtemporada = new SelectList(db.temporada, "idtemporada", "nombre", competiciontemporada.idtemporada);
            ViewBag.usrcreador = new SelectList(db.usuario, "usuario1", "usrcreador", competiciontemporada.usrcreador);
            ViewBag.usrmodificador = new SelectList(db.usuario, "usuario1", "usrcreador", competiciontemporada.usrmodificador);
            return View(competiciontemporada);
        }

        // GET: competiciontemporadas/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            competiciontemporada competiciontemporada = db.competiciontemporada.Find(id);
            if (competiciontemporada == null)
            {
                return HttpNotFound();
            }
            ViewBag.idcompeticion = new SelectList(db.competicion, "idcompeticion", "tipo", competiciontemporada.idcompeticion);
            ViewBag.idtemporada = new SelectList(db.temporada, "idtemporada", "nombre", competiciontemporada.idtemporada);
            ViewBag.usrcreador = new SelectList(db.usuario, "usuario1", "usrcreador", competiciontemporada.usrcreador);
            ViewBag.usrmodificador = new SelectList(db.usuario, "usuario1", "usrcreador", competiciontemporada.usrmodificador);
            return View(competiciontemporada);
        }

        // POST: competiciontemporadas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idcompeticion,idtemporada,usrcreador,fchcreacion,usrmodificador,fchmodificacion")] competiciontemporada competiciontemporada)
        {
            if (ModelState.IsValid)
            {
                db.Entry(competiciontemporada).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idcompeticion = new SelectList(db.competicion, "idcompeticion", "tipo", competiciontemporada.idcompeticion);
            ViewBag.idtemporada = new SelectList(db.temporada, "idtemporada", "nombre", competiciontemporada.idtemporada);
            ViewBag.usrcreador = new SelectList(db.usuario, "usuario1", "usrcreador", competiciontemporada.usrcreador);
            ViewBag.usrmodificador = new SelectList(db.usuario, "usuario1", "usrcreador", competiciontemporada.usrmodificador);
            return View(competiciontemporada);
        }

        // GET: competiciontemporadas/Delete/5
        public ActionResult Delete(string id, int id2)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            competiciontemporada competiciontemporada = db.competiciontemporada.Find(id,id2);  
            if (competiciontemporada == null)
            {
                return HttpNotFound();
            }
            return View(competiciontemporada);
        }

        // POST: competiciontemporadas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id,int id2)
        {
            competiciontemporada competiciontemporada = db.competiciontemporada.Find(id,id2);
            db.competiciontemporada.Remove(competiciontemporada);
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

        public ActionResult Calendario(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            competiciontemporada competiciontemporada = db.competiciontemporada.Find(id);
            if (competiciontemporada == null)
            {
                return HttpNotFound();
            }
            return View(competiciontemporada);
        }
    }
}
