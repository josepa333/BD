using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Proyecto_bases.Models;

namespace Proyecto_bases.Controllers
{
    public class jugadoresController : Controller
    {
        private ProyectoBasesJAREntities9 db = new ProyectoBasesJAREntities9();

        // GET: jugadores
        public ActionResult Index()
        {
            var jugador = db.jugador.Include(j => j.funcionariodeportivo).Include(j => j.usuario).Include(j => j.usuario1);
            return View(jugador.ToList());
        }

        // GET: jugadores/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            jugador jugador = db.jugador.Find(id);
            if (jugador == null)
            {
                return HttpNotFound();
            }
            return View(jugador);
        }

        // GET: jugadores/Create
        public ActionResult Create()
        {
            ViewBag.idfuncionario = new SelectList(db.funcionariodeportivo, "idfuncionario", "idfuncionario");
            ViewBag.usrcreador = new SelectList(db.usuario, "usuario1", "usuario1");
            ViewBag.usrmodificador = new SelectList(db.usuario, "usuario1", "usuario1");
            return View();
        }

        // POST: jugadores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idfuncionario,rendimiento,peso,altura,usrcreador,fchcreacion,usrmodificador,fchmodificacion")] jugador jugador)
        {
            if (ModelState.IsValid)
            {
                db.jugador.Add(jugador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idfuncionario = new SelectList(db.funcionariodeportivo, "idfuncionario", "idfuncionario", jugador.idfuncionario);
            ViewBag.usrcreador = new SelectList(db.usuario, "usuario1", "usuario1", jugador.usrcreador);
            ViewBag.usrmodificador = new SelectList(db.usuario, "usuario1", "usuario1", jugador.usrmodificador);
            return View(jugador);
        }

        // GET: jugadores/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            jugador jugador = db.jugador.Find(id);
            if (jugador == null)
            {
                return HttpNotFound();
            }
            ViewBag.idfuncionario = new SelectList(db.funcionariodeportivo, "idfuncionario", "idfuncionario", jugador.idfuncionario);
            ViewBag.usrcreador = new SelectList(db.usuario, "usuario1", "usuario1", jugador.usrcreador);
            ViewBag.usrmodificador = new SelectList(db.usuario, "usuario1", "usuario1", jugador.usrmodificador);
            return View(jugador);
        }

        // POST: jugadores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idfuncionario,rendimiento,peso,altura,usrcreador,fchcreacion,usrmodificador,fchmodificacion")] jugador jugador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jugador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idfuncionario = new SelectList(db.funcionariodeportivo, "idfuncionario", "idfuncionario", jugador.idfuncionario);
            ViewBag.usrcreador = new SelectList(db.usuario, "usuario1", "usuario1", jugador.usrcreador);
            ViewBag.usrmodificador = new SelectList(db.usuario, "usuario1", "usuario1", jugador.usrmodificador);
            return View(jugador);
        }

        // GET: jugadores/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            jugador jugador = db.jugador.Find(id);
            if (jugador == null)
            {
                return HttpNotFound();
            }
            return View(jugador);
        }

        // POST: jugadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            jugador jugador = db.jugador.Find(id);
            db.jugador.Remove(jugador);
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

        public ActionResult Historial(string id)
        {
            SqlParameter parameter1 = new SqlParameter("@idJugador", id);
            List<infoJugador_Result> lista = db.Database.SqlQuery<infoJugador_Result>("exec infoJugador @idJugador", parameter1).ToList();
            return View(lista);
        }
    }
}
