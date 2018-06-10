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
    public class funcionariodeportivoController : Controller
    {
        private ProyectoBasesJAREntities8 db = new ProyectoBasesJAREntities8();

        // GET: funcionariodeportivo
        public ActionResult Index()
        {
            var funcionariodeportivo = db.funcionariodeportivo.Include(f => f.entrenador).Include(f => f.usuario).Include(f => f.usuario1).Include(f => f.jugador);
            return View(funcionariodeportivo.ToList());
        }

        // GET: funcionariodeportivo/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            funcionariodeportivo funcionariodeportivo = db.funcionariodeportivo.Find(id);
            if (funcionariodeportivo == null)
            {
                return HttpNotFound();
            }
            return View(funcionariodeportivo);
        }

        // GET: funcionariodeportivo/Create
        public ActionResult Create()
        {
            ViewBag.idfuncionario = new SelectList(db.entrenador, "idfuncionario", "jugadorjuventud");
            ViewBag.usrcreador = new SelectList(db.usuario, "usuario1", "usrcreador");
            ViewBag.usrmodificador = new SelectList(db.usuario, "usuario1", "usrcreador");
            ViewBag.idfuncionario = new SelectList(db.jugador, "idfuncionario", "peso");
            return View();
        }

        // POST: funcionariodeportivo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idfuncionario,foto,nombre,fchnacimiento,usrcreador,fchcreacion,usrmodificador,fchmodificacion")] funcionariodeportivo funcionariodeportivo)
        {
            if (ModelState.IsValid)
            {
                db.funcionariodeportivo.Add(funcionariodeportivo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idfuncionario = new SelectList(db.entrenador, "idfuncionario", "jugadorjuventud", funcionariodeportivo.idfuncionario);
            ViewBag.usrcreador = new SelectList(db.usuario, "usuario1", "usrcreador", funcionariodeportivo.usrcreador);
            ViewBag.usrmodificador = new SelectList(db.usuario, "usuario1", "usrcreador", funcionariodeportivo.usrmodificador);
            ViewBag.idfuncionario = new SelectList(db.jugador, "idfuncionario", "peso", funcionariodeportivo.idfuncionario);
            return View(funcionariodeportivo);
        }

        // GET: funcionariodeportivo/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            funcionariodeportivo funcionariodeportivo = db.funcionariodeportivo.Find(id);
            if (funcionariodeportivo == null)
            {
                return HttpNotFound();
            }
            ViewBag.idfuncionario = new SelectList(db.entrenador, "idfuncionario", "jugadorjuventud", funcionariodeportivo.idfuncionario);
            ViewBag.usrcreador = new SelectList(db.usuario, "usuario1", "usrcreador", funcionariodeportivo.usrcreador);
            ViewBag.usrmodificador = new SelectList(db.usuario, "usuario1", "usrcreador", funcionariodeportivo.usrmodificador);
            ViewBag.idfuncionario = new SelectList(db.jugador, "idfuncionario", "peso", funcionariodeportivo.idfuncionario);
            return View(funcionariodeportivo);
        }

        // POST: funcionariodeportivo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idfuncionario,foto,nombre,fchnacimiento,usrcreador,fchcreacion,usrmodificador,fchmodificacion")] funcionariodeportivo funcionariodeportivo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(funcionariodeportivo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idfuncionario = new SelectList(db.entrenador, "idfuncionario", "jugadorjuventud", funcionariodeportivo.idfuncionario);
            ViewBag.usrcreador = new SelectList(db.usuario, "usuario1", "usrcreador", funcionariodeportivo.usrcreador);
            ViewBag.usrmodificador = new SelectList(db.usuario, "usuario1", "usrcreador", funcionariodeportivo.usrmodificador);
            ViewBag.idfuncionario = new SelectList(db.jugador, "idfuncionario", "peso", funcionariodeportivo.idfuncionario);
            return View(funcionariodeportivo);
        }

        // GET: funcionariodeportivo/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            funcionariodeportivo funcionariodeportivo = db.funcionariodeportivo.Find(id);
            if (funcionariodeportivo == null)
            {
                return HttpNotFound();
            }
            return View(funcionariodeportivo);
        }

        // POST: funcionariodeportivo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            funcionariodeportivo funcionariodeportivo = db.funcionariodeportivo.Find(id);
            db.funcionariodeportivo.Remove(funcionariodeportivo);
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
