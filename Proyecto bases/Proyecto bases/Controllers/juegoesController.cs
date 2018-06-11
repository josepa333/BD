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
    public class juegoesController : Controller
    {
        private ProyectoBasesJAREntities9 db = new ProyectoBasesJAREntities9();

        // GET: juegoes
        public ActionResult Index()
        {
            var juego = db.juego.Include(j => j.club).Include(j => j.club1).Include(j => j.fechacalendario).Include(j => j.usuario).Include(j => j.usuario1);
            return View(juego.ToList());
        }

        // GET: juegoes/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            juego juego = db.juego.Find(id);
            if (juego == null)
            {
                return HttpNotFound();
            }
            return View(juego);
        }

        // GET: juegoes/Create
        public ActionResult Create()
        {
            ViewBag.idclubcasa = new SelectList(db.club, "idclub", "idclub");
            ViewBag.idclubvisita = new SelectList(db.club, "idclub", "idclub");
            ViewBag.idcalendario = new SelectList(db.fechacalendario, "idcalendario", "idcalendario");
            ViewBag.usrcreador = new SelectList(db.usuario, "usuario1", "usuario1");
            ViewBag.usrmodificador = new SelectList(db.usuario, "usuario1", "usuario1");
            return View();
        }

        // POST: juegoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idjuego,jugado,golescasa,golesvisita,idclubcasa,idclubvisita,idcalendario,sinopsis,usrcreador,fchcreacion,usrmodificador,fchmodificacion")] juego juego)
        {
            if (ModelState.IsValid)
            {
                db.juego.Add(juego);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idclubcasa = new SelectList(db.club, "idclub", "idclub", juego.idclubcasa);
            ViewBag.idclubvisita = new SelectList(db.club, "idclub", "idclub", juego.idclubvisita);
            ViewBag.idcalendario = new SelectList(db.fechacalendario, "idcalendario", "idcalendario", juego.idcalendario);
            ViewBag.usrcreador = new SelectList(db.usuario, "usuario1", "usuario1", juego.usrcreador);
            ViewBag.usrmodificador = new SelectList(db.usuario, "usuario1", "usuario1", juego.usrmodificador);
            return View(juego);
        }

        // GET: juegoes/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            juego juego = db.juego.Find(id);
            if (juego == null)
            {
                return HttpNotFound();
            }
            ViewBag.idclubcasa = new SelectList(db.club, "idclub", "idclub", juego.idclubcasa);
            ViewBag.idclubvisita = new SelectList(db.club, "idclub", "idclub", juego.idclubvisita);
            ViewBag.idcalendario = new SelectList(db.fechacalendario, "idcalendario", "idcalendario", juego.idcalendario);
            ViewBag.usrcreador = new SelectList(db.usuario, "usuario1", "usuario1", juego.usrcreador);
            ViewBag.usrmodificador = new SelectList(db.usuario, "usuario1", "usuario1", juego.usrmodificador);
            return View(juego);
        }

        // POST: juegoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idjuego,jugado,golescasa,golesvisita,idclubcasa,idclubvisita,idcalendario,sinopsis,usrcreador,fchcreacion,usrmodificador,fchmodificacion")] juego juego)
        {
            if (ModelState.IsValid)
            {
                db.Entry(juego).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idclubcasa = new SelectList(db.club, "idclub", "idclub", juego.idclubcasa);
            ViewBag.idclubvisita = new SelectList(db.club, "idclub", "idclub", juego.idclubvisita);
            ViewBag.idcalendario = new SelectList(db.fechacalendario, "idcalendario", "idcalendario", juego.idcalendario);
            ViewBag.usrcreador = new SelectList(db.usuario, "usuario1", "usuario1", juego.usrcreador);
            ViewBag.usrmodificador = new SelectList(db.usuario, "usuario1", "usuario1", juego.usrmodificador);
            return View(juego);
        }

        // GET: juegoes/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            juego juego = db.juego.Find(id);
            if (juego == null)
            {
                return HttpNotFound();
            }
            return View(juego);
        }

        // POST: juegoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            juego juego = db.juego.Find(id);
            db.juego.Remove(juego);
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
