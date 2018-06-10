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
    public class alineacionController : Controller
    {
        private ProyectoBasesJAREntities9 db = new ProyectoBasesJAREntities9();

        // GET: alineacions
        public ActionResult Index()
        {
            var alineacion = db.alineacion.Include(a => a.club).Include(a => a.usuario).Include(a => a.usuario1).Include(a => a.juego).Include(a => a.jugador);
            return View(alineacion.ToList());
        }

        // GET: alineacions/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            alineacion alineacion = db.alineacion.Find(id);
            if (alineacion == null)
            {
                return HttpNotFound();
            }
            return View(alineacion);
        }

        // GET: alineacions/Create
        public ActionResult Create()
        {
            ViewBag.idclub = new SelectList(db.club, "idclub", "nombre");
            ViewBag.usrcreador = new SelectList(db.usuario, "usuario1", "usrcreador");
            ViewBag.usrmodificador = new SelectList(db.usuario, "usuario1", "usrcreador");
            ViewBag.idjuego = new SelectList(db.juego, "idjuego", "jugado");
            ViewBag.idfuncionario = new SelectList(db.jugador, "idfuncionario", "peso");
            return View();
        }

        // POST: alineacions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idfuncionario,idjuego,rendimiento,idclub,tipo,usrcreador,fchcreacion,usrmodificador,fchmodificacion")] alineacion alineacion)
        {
            if (ModelState.IsValid)
            {
                db.alineacion.Add(alineacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idclub = new SelectList(db.club, "idclub", "nombre", alineacion.idclub);
            ViewBag.usrcreador = new SelectList(db.usuario, "usuario1", "usrcreador", alineacion.usrcreador);
            ViewBag.usrmodificador = new SelectList(db.usuario, "usuario1", "usrcreador", alineacion.usrmodificador);
            ViewBag.idjuego = new SelectList(db.juego, "idjuego", "jugado", alineacion.idjuego);
            ViewBag.idfuncionario = new SelectList(db.jugador, "idfuncionario", "peso", alineacion.idfuncionario);
            return View(alineacion);
        }

        // GET: alineacions/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            alineacion alineacion = db.alineacion.Find(id);
            if (alineacion == null)
            {
                return HttpNotFound();
            }
            ViewBag.idclub = new SelectList(db.club, "idclub", "nombre", alineacion.idclub);
            ViewBag.usrcreador = new SelectList(db.usuario, "usuario1", "usrcreador", alineacion.usrcreador);
            ViewBag.usrmodificador = new SelectList(db.usuario, "usuario1", "usrcreador", alineacion.usrmodificador);
            ViewBag.idjuego = new SelectList(db.juego, "idjuego", "jugado", alineacion.idjuego);
            ViewBag.idfuncionario = new SelectList(db.jugador, "idfuncionario", "peso", alineacion.idfuncionario);
            return View(alineacion);
        }

        // POST: alineacions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idfuncionario,idjuego,rendimiento,idclub,tipo,usrcreador,fchcreacion,usrmodificador,fchmodificacion")] alineacion alineacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(alineacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idclub = new SelectList(db.club, "idclub", "nombre", alineacion.idclub);
            ViewBag.usrcreador = new SelectList(db.usuario, "usuario1", "usrcreador", alineacion.usrcreador);
            ViewBag.usrmodificador = new SelectList(db.usuario, "usuario1", "usrcreador", alineacion.usrmodificador);
            ViewBag.idjuego = new SelectList(db.juego, "idjuego", "jugado", alineacion.idjuego);
            ViewBag.idfuncionario = new SelectList(db.jugador, "idfuncionario", "peso", alineacion.idfuncionario);
            return View(alineacion);
        }

        // GET: alineacions/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            alineacion alineacion = db.alineacion.Find(id);
            if (alineacion == null)
            {
                return HttpNotFound();
            }
            return View(alineacion);
        }

        // POST: alineacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            alineacion alineacion = db.alineacion.Find(id);
            db.alineacion.Remove(alineacion);
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
