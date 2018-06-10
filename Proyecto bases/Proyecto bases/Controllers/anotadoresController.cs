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
    public class anotadoresController : Controller
    {
        private ProyectoBasesJAREntities8 db = new ProyectoBasesJAREntities8();

        // GET: anotadores
        public ActionResult Index()
        {
            var anotadores = db.anotadores.Include(a => a.club).Include(a => a.usuario).Include(a => a.usuario1).Include(a => a.juego).Include(a => a.jugador);
            return View(anotadores.ToList());
        }

        // GET: anotadores/Details/5
        public ActionResult Details(int id, int id2 )
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            anotadores anotadores = db.anotadores.Find(id,id2);
            if (anotadores == null)
            {
                return HttpNotFound();
            }
            return View(anotadores);
        }

        // GET: anotadores/Create
        public ActionResult Create()
        {
            ViewBag.idclub = new SelectList(db.club, "idclub", "idclub");
            ViewBag.usrcreador = new SelectList(db.usuario, "usuario1", "usuario1");
            ViewBag.usrmodificador = new SelectList(db.usuario, "usuario1", "usuario1");
            ViewBag.idjuego = new SelectList(db.juego, "idjuego", "idjuego");
            ViewBag.idfuncionario = new SelectList(db.jugador, "idfuncionario", "idfuncionario");
            return View();
        }

        // POST: anotadores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idfuncionario,idjuego,minjuego,video,idclub,usrcreador,fchcreacion,usrmodificador,fchmodificacion")] anotadores anotadores)
        {
            if (ModelState.IsValid)
            {
                db.anotadores.Add(anotadores);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idclub = new SelectList(db.club, "idclub", "idclub", anotadores.idclub);
            ViewBag.usrcreador = new SelectList(db.usuario, "usuario1", "usuario1", anotadores.usrcreador);
            ViewBag.usrmodificador = new SelectList(db.usuario, "usuario1", "usuario1", anotadores.usrmodificador);
            ViewBag.idjuego = new SelectList(db.juego, "idjuego", "idjuego", anotadores.idjuego);
            ViewBag.idfuncionario = new SelectList(db.jugador, "idfuncionario", "idfuncionario", anotadores.idfuncionario);
            return View(anotadores);
        }

        // GET: anotadores/Edit/5
        public ActionResult Edit(int id, int id2)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            anotadores anotadores = db.anotadores.Find(id, id2);
            if (anotadores == null)
            {
                return HttpNotFound();
            }
            ViewBag.idclub = new SelectList(db.club, "idclub", "idclub", anotadores.idclub);
            ViewBag.usrcreador = new SelectList(db.usuario, "usuario1", "usuario1", anotadores.usrcreador);
            ViewBag.usrmodificador = new SelectList(db.usuario, "usuario1", "usuario1", anotadores.usrmodificador);
            ViewBag.idjuego = new SelectList(db.juego, "idjuego", "idjuego", anotadores.idjuego);
            ViewBag.idfuncionario = new SelectList(db.jugador, "idfuncionario", "idfuncionario", anotadores.idfuncionario);
            return View(anotadores);
        }

        // POST: anotadores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idfuncionario,idjuego,minjuego,video,idclub,usrcreador,fchcreacion,usrmodificador,fchmodificacion")] anotadores anotadores)
        {
            if (ModelState.IsValid)
            {
                db.Entry(anotadores).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idclub = new SelectList(db.club, "idclub", "idclub", anotadores.idclub);
            ViewBag.usrcreador = new SelectList(db.usuario, "usuario1", "usuario1", anotadores.usrcreador);
            ViewBag.usrmodificador = new SelectList(db.usuario, "usuario1", "usuario1", anotadores.usrmodificador);
            ViewBag.idjuego = new SelectList(db.juego, "idjuego", "idjuego", anotadores.idjuego);
            ViewBag.idfuncionario = new SelectList(db.jugador, "idfuncionario", "idfuncionario", anotadores.idfuncionario);
            return View(anotadores);
        }

        // GET: anotadores/Delete/5
        public ActionResult Delete(int id, int id2)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            anotadores anotadores = db.anotadores.Find(id, id2);
            if (anotadores == null)
            {
                return HttpNotFound();
            }
            return View(anotadores);
        }

        // POST: anotadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, int id2)
        {
            anotadores anotadores = db.anotadores.Find(id, id2);
            db.anotadores.Remove(anotadores);
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
