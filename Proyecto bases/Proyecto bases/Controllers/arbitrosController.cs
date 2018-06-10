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
    public class arbitrosController : Controller
    {
        private ProyectoBasesJAREntities9 db = new ProyectoBasesJAREntities9();

        // GET: arbitroes
        public ActionResult Index()
        {
            var arbitro = db.arbitro.Include(a => a.categoria).Include(a => a.usuario).Include(a => a.usuario1);
            return View(arbitro.ToList());
        }

        // GET: arbitroes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            arbitro arbitro = db.arbitro.Find(id);
            if (arbitro == null)
            {
                return HttpNotFound();
            }
            return View(arbitro);
        }

        // GET: arbitroes/Create
        public ActionResult Create()
        {
            ViewBag.idcategoria = new SelectList(db.categoria, "idcategoria", "descripcion");
            ViewBag.usrcreador = new SelectList(db.usuario, "usuario1", "usrcreador");
            ViewBag.usrmodificador = new SelectList(db.usuario, "usuario1", "usrcreador");
            return View();
        }

        // POST: arbitroes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idarbitro,rendimiento,nombre,idcategoria,usrcreador,fchcreacion,usrmodificador,fchmodificacion")] arbitro arbitro)
        {
            if (ModelState.IsValid)
            {
                db.arbitro.Add(arbitro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idcategoria = new SelectList(db.categoria, "idcategoria", "descripcion", arbitro.idcategoria);
            ViewBag.usrcreador = new SelectList(db.usuario, "usuario1", "usrcreador", arbitro.usrcreador);
            ViewBag.usrmodificador = new SelectList(db.usuario, "usuario1", "usrcreador", arbitro.usrmodificador);
            return View(arbitro);
        }

        // GET: arbitroes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            arbitro arbitro = db.arbitro.Find(id);
            if (arbitro == null)
            {
                return HttpNotFound();
            }
            ViewBag.idcategoria = new SelectList(db.categoria, "idcategoria", "descripcion", arbitro.idcategoria);
            ViewBag.usrcreador = new SelectList(db.usuario, "usuario1", "usrcreador", arbitro.usrcreador);
            ViewBag.usrmodificador = new SelectList(db.usuario, "usuario1", "usrcreador", arbitro.usrmodificador);
            return View(arbitro);
        }

        // POST: arbitroes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idarbitro,rendimiento,nombre,idcategoria,usrcreador,fchcreacion,usrmodificador,fchmodificacion")] arbitro arbitro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(arbitro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idcategoria = new SelectList(db.categoria, "idcategoria", "descripcion", arbitro.idcategoria);
            ViewBag.usrcreador = new SelectList(db.usuario, "usuario1", "usrcreador", arbitro.usrcreador);
            ViewBag.usrmodificador = new SelectList(db.usuario, "usuario1", "usrcreador", arbitro.usrmodificador);
            return View(arbitro);
        }

        // GET: arbitroes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            arbitro arbitro = db.arbitro.Find(id);
            if (arbitro == null)
            {
                return HttpNotFound();
            }
            return View(arbitro);
        }

        // POST: arbitroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            arbitro arbitro = db.arbitro.Find(id);
            db.arbitro.Remove(arbitro);
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
