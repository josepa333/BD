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
    public class clubcompeticiontemporadaController : Controller
    {
        private ProyectoBasesJAREntities8 db = new ProyectoBasesJAREntities8();

        // GET: clubcompeticiontemporada
        public ActionResult Index()
        {
            var clubcompeticiontemporada = db.clubcompeticiontemporada.Include(c => c.club).Include(c => c.competiciontemporada).Include(c => c.usuario).Include(c => c.usuario1);
            return View(clubcompeticiontemporada.ToList());
        }

        // GET: clubcompeticiontemporada/Details/5
        public ActionResult Details(string id, string id2, int id3)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            clubcompeticiontemporada clubcompeticiontemporada = db.clubcompeticiontemporada.Find(id,id2,id3);
            if (clubcompeticiontemporada == null)
            {
                return HttpNotFound();
            }
            return View(clubcompeticiontemporada);
        }

        // GET: clubcompeticiontemporada/Create
        public ActionResult Create()
        {
            ViewBag.idclub = new SelectList(db.club, "idclub", "idclub");
            ViewBag.idcompeticion = new SelectList(db.competiciontemporada, "idcompeticion", "idcompeticion");
            ViewBag.usrcreador = new SelectList(db.usuario, "usuario1", "usuario1");
            ViewBag.usrmodificador = new SelectList(db.usuario, "usuario1", "usuario1");
            return View();
        }

        // POST: clubcompeticiontemporada/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idclub,posicion,golesafavor,golesencontra,idtemporada,idcompeticion,puntos,usrcreador,fchcreacion,usrmodificador,fchmodificacion")] clubcompeticiontemporada clubcompeticiontemporada)
        {
            if (ModelState.IsValid)
            {
                db.clubcompeticiontemporada.Add(clubcompeticiontemporada);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idclub = new SelectList(db.club, "idclub", "idclub", clubcompeticiontemporada.idclub);
            ViewBag.idcompeticion = new SelectList(db.competiciontemporada, "idcompeticion", "idcompeticion", clubcompeticiontemporada.idcompeticion);
            ViewBag.usrcreador = new SelectList(db.usuario, "usuario1", "usuario1", clubcompeticiontemporada.usrcreador);
            ViewBag.usrmodificador = new SelectList(db.usuario, "usuario1", "usuario1", clubcompeticiontemporada.usrmodificador);
            return View(clubcompeticiontemporada);
        }

        // GET: clubcompeticiontemporada/Edit/5
        public ActionResult Edit(string id, int id2, string id3)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            clubcompeticiontemporada clubcompeticiontemporada = db.clubcompeticiontemporada.Find(id, id2, id3);
            if (clubcompeticiontemporada == null)
            {
                return HttpNotFound();
            }
            ViewBag.idclub = new SelectList(db.club, "idclub", "idclub", clubcompeticiontemporada.idclub);
            ViewBag.idcompeticion = new SelectList(db.competiciontemporada, "idcompeticion", "idcompeticion", clubcompeticiontemporada.idcompeticion);
            ViewBag.usrcreador = new SelectList(db.usuario, "usuario1", "usuario1", clubcompeticiontemporada.usrcreador);
            ViewBag.usrmodificador = new SelectList(db.usuario, "usuario1", "usuario1", clubcompeticiontemporada.usrmodificador);
            return View(clubcompeticiontemporada);
        }

        // POST: clubcompeticiontemporada/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idclub,posicion,golesafavor,golesencontra,idtemporada,idcompeticion,puntos,usrcreador,fchcreacion,usrmodificador,fchmodificacion")] clubcompeticiontemporada clubcompeticiontemporada)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clubcompeticiontemporada).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idclub = new SelectList(db.club, "idclub", "idclub", clubcompeticiontemporada.idclub);
            ViewBag.idcompeticion = new SelectList(db.competiciontemporada, "idcompeticion", "idcompeticion", clubcompeticiontemporada.idcompeticion);
            ViewBag.usrcreador = new SelectList(db.usuario, "usuario1", "usuario1", clubcompeticiontemporada.usrcreador);
            ViewBag.usrmodificador = new SelectList(db.usuario, "usuario1", "usuario1", clubcompeticiontemporada.usrmodificador);
            return View(clubcompeticiontemporada);
        }

        // GET: clubcompeticiontemporada/Delete/5
        public ActionResult Delete(string id, int id2, string id3)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            clubcompeticiontemporada clubcompeticiontemporada = db.clubcompeticiontemporada.Find(id, id2, id3);
            if (clubcompeticiontemporada == null)
            {
                return HttpNotFound();
            }
            return View(clubcompeticiontemporada);
        }

        // POST: clubcompeticiontemporada/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id, int id2, string id3)
        {
            clubcompeticiontemporada clubcompeticiontemporada = db.clubcompeticiontemporada.Find(id, id2, id3);
            db.clubcompeticiontemporada.Remove(clubcompeticiontemporada);
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
