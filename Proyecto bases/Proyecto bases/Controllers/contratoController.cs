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
    public class contratoController : Controller
    {
        private ProyectoBasesJAREntities9 db = new ProyectoBasesJAREntities9();

        // GET: contrato
        public ActionResult Index()
        {
            var contrato = db.contrato.Include(c => c.club).Include(c => c.funcionariodeportivo).Include(c => c.usuario).Include(c => c.usuario1);
            return View(contrato.ToList());
        }

        // GET: contrato/Details/5
        public ActionResult Details(DateTime id, string id2, string id3)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            contrato contrato = db.contrato.Find(id,id2,id3);
            if (contrato == null)
            {
                return HttpNotFound();
            }
            return View(contrato);
        }

        // GET: contrato/Create
        public ActionResult Create()
        {
            ViewBag.idclub = new SelectList(db.club, "idclub", "idclub");
            ViewBag.idfuncionario = new SelectList(db.funcionariodeportivo, "idfuncionario", "idfuncionario");
            ViewBag.usrcreador = new SelectList(db.usuario, "usuario1", "usuario1");
            ViewBag.usrmodificador = new SelectList(db.usuario, "usuario1", "usuario1");
            return View();
        }

        // POST: contrato/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "validez,importe,fchinicio,fchfinal,idclub,idfuncionario,usrcreador,fchcreacion,usrmodificador,fchmodificacion")] contrato contrato)
        {
            if (ModelState.IsValid)
            {
                db.contrato.Add(contrato);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idclub = new SelectList(db.club, "idclub", "idclub", contrato.idclub);
            ViewBag.idfuncionario = new SelectList(db.funcionariodeportivo, "idfuncionario", "idfuncionario", contrato.idfuncionario);
            ViewBag.usrcreador = new SelectList(db.usuario, "usuario1", "usuario1", contrato.usrcreador);
            ViewBag.usrmodificador = new SelectList(db.usuario, "usuario1", "usuario1", contrato.usrmodificador);
            return View(contrato);
        }

        // GET: contrato/Edit/5
        public ActionResult Edit(DateTime id, string id2, string id3)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            contrato contrato = db.contrato.Find(id, id2, id3);
            if (contrato == null)
            {
                return HttpNotFound();
            }
            ViewBag.idclub = new SelectList(db.club, "idclub", "idclub", contrato.idclub);
            ViewBag.idfuncionario = new SelectList(db.funcionariodeportivo, "idfuncionario", "idfuncionario", contrato.idfuncionario);
            ViewBag.usrcreador = new SelectList(db.usuario, "usuario1", "usuario1", contrato.usrcreador);
            ViewBag.usrmodificador = new SelectList(db.usuario, "usuario1", "usuario1", contrato.usrmodificador);
            return View(contrato);
        }

        // POST: contrato/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "validez,importe,fchinicio,fchfinal,idclub,idfuncionario,usrcreador,fchcreacion,usrmodificador,fchmodificacion")] contrato contrato)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contrato).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idclub = new SelectList(db.club, "idclub", "idclub", contrato.idclub);
            ViewBag.idfuncionario = new SelectList(db.funcionariodeportivo, "idfuncionario", "idfuncionario", contrato.idfuncionario);
            ViewBag.usrcreador = new SelectList(db.usuario, "usuario1", "usuario1", contrato.usrcreador);
            ViewBag.usrmodificador = new SelectList(db.usuario, "usuario1", "usuario1", contrato.usrmodificador);
            return View(contrato);
        }

        // GET: contrato/Delete/5
        public ActionResult Delete(DateTime id, string id2, string id3)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            contrato contrato = db.contrato.Find(id, id2, id3);
            if (contrato == null)
            {
                return HttpNotFound();
            }
            return View(contrato);
        }

        // POST: contrato/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(DateTime id, string id2, string id3)
        {
            contrato contrato = db.contrato.Find(id, id2, id3);
            db.contrato.Remove(contrato);
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
