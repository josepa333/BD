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
    public class entrenadorController : Controller
    {
        private ProyectoBasesJAREntities9 db = new ProyectoBasesJAREntities9();

        // GET: entrenador
        public ActionResult Index()
        {
            var entrenador = db.entrenador.Include(e => e.funcionariodeportivo).Include(e => e.usuario).Include(e => e.usuario1);
            return View(entrenador.ToList());
        }

        // GET: entrenador/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            entrenador entrenador = db.entrenador.Find(id);
            if (entrenador == null)
            {
                return HttpNotFound();
            }
            return View(entrenador);
        }

        // GET: entrenador/Create
        public ActionResult Create()
        {
            ViewBag.idfuncionario = new SelectList(db.funcionariodeportivo, "idfuncionario", "idfuncionario");
            ViewBag.usrcreador = new SelectList(db.usuario, "usuario1", "usuario1");
            ViewBag.usrmodificador = new SelectList(db.usuario, "usuario1", "usuario1");
            return View();
        }

        // POST: entrenador/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idfuncionario,fchiniciocarrera,jugadorjuventud,usrcreador,fchcreacion,usrmodificador,fchmodificacion")] entrenador entrenador)
        {
            if (ModelState.IsValid)
            {
                db.entrenador.Add(entrenador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idfuncionario = new SelectList(db.funcionariodeportivo, "idfuncionario", "idfuncionario", entrenador.idfuncionario);
            ViewBag.usrcreador = new SelectList(db.usuario, "usuario1", "usuario1", entrenador.usrcreador);
            ViewBag.usrmodificador = new SelectList(db.usuario, "usuario1", "usuario1", entrenador.usrmodificador);
            return View(entrenador);
        }

        // GET: entrenador/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            entrenador entrenador = db.entrenador.Find(id);
            if (entrenador == null)
            {
                return HttpNotFound();
            }
            ViewBag.idfuncionario = new SelectList(db.funcionariodeportivo, "idfuncionario", "idfuncionario", entrenador.idfuncionario);
            ViewBag.usrcreador = new SelectList(db.usuario, "usuario1", "usuario1", entrenador.usrcreador);
            ViewBag.usrmodificador = new SelectList(db.usuario, "usuario1", "usuario1", entrenador.usrmodificador);
            return View(entrenador);
        }

        // POST: entrenador/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idfuncionario,fchiniciocarrera,jugadorjuventud,usrcreador,fchcreacion,usrmodificador,fchmodificacion")] entrenador entrenador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(entrenador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idfuncionario = new SelectList(db.funcionariodeportivo, "idfuncionario", "idfuncionario", entrenador.idfuncionario);
            ViewBag.usrcreador = new SelectList(db.usuario, "usuario1", "usuario1", entrenador.usrcreador);
            ViewBag.usrmodificador = new SelectList(db.usuario, "usuario1", "usuario1", entrenador.usrmodificador);
            return View(entrenador);
        }

        // GET: entrenador/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            entrenador entrenador = db.entrenador.Find(id);
            if (entrenador == null)
            {
                return HttpNotFound();
            }
            return View(entrenador);
        }

        // POST: entrenador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            entrenador entrenador = db.entrenador.Find(id);
            db.entrenador.Remove(entrenador);
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
            SqlParameter parameter1 = new SqlParameter("@idEntrenador", id);
            List<infoJugador_Result> lista = db.Database.SqlQuery<infoJugador_Result>("exec infoEntrenador @idEntrenador", parameter1).ToList();
            return View(lista);
        }

        
    }
}
