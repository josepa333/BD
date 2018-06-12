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
    public class contratoesController : Controller
    {
        private ProyectoBasesJAREntities9 db = new ProyectoBasesJAREntities9();

        // GET: contratoes
        public ActionResult Index()
        {
            var contrato = db.contrato.Include(c => c.club).Include(c => c.funcionariodeportivo).Include(c => c.usuario).Include(c => c.usuario1);
            return View(contrato.ToList());
        }

        // GET: contratoes/Details/5
        public ActionResult Details(string id, string id2, DateTime id3)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            contrato contrato = db.contrato.Find(id3, id, id2);
            if (contrato == null)
            {
                return HttpNotFound();
            }
            return View(contrato);
        }

        // GET: contratoes/Create
        public ActionResult Create()
        {
            ViewBag.idclub = new SelectList(db.club, "idclub", "nombre");
            ViewBag.idfuncionario = new SelectList(db.funcionariodeportivo, "idfuncionario", "foto");
            ViewBag.usrcreador = new SelectList(db.usuario, "usuario1", "usrcreador");
            ViewBag.usrmodificador = new SelectList(db.usuario, "usuario1", "usrcreador");
            return View();
        }

        // POST: contratoes/Create
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

            ViewBag.idclub = new SelectList(db.club, "idclub", "nombre", contrato.idclub);
            ViewBag.idfuncionario = new SelectList(db.funcionariodeportivo, "idfuncionario", "foto", contrato.idfuncionario);
            ViewBag.usrcreador = new SelectList(db.usuario, "usuario1", "usrcreador", contrato.usrcreador);
            ViewBag.usrmodificador = new SelectList(db.usuario, "usuario1", "usrcreador", contrato.usrmodificador);
            return View(contrato);
        }

        // GET: contratoes/Edit/5
        public ActionResult Edit(string id, string id2, DateTime id3)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            contrato contrato = db.contrato.Find(id3, id, id2);
            if (contrato == null)
            {
                return HttpNotFound();
            }
            ViewBag.idclub = new SelectList(db.club, "idclub", "nombre", contrato.idclub);
            ViewBag.idfuncionario = new SelectList(db.funcionariodeportivo, "idfuncionario", "foto", contrato.idfuncionario);
            ViewBag.usrcreador = new SelectList(db.usuario, "usuario1", "usrcreador", contrato.usrcreador);
            ViewBag.usrmodificador = new SelectList(db.usuario, "usuario1", "usrcreador", contrato.usrmodificador);
            return View(contrato);
        }

        // POST: contratoes/Edit/5
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
            ViewBag.idclub = new SelectList(db.club, "idclub", "nombre", contrato.idclub);
            ViewBag.idfuncionario = new SelectList(db.funcionariodeportivo, "idfuncionario", "foto", contrato.idfuncionario);
            ViewBag.usrcreador = new SelectList(db.usuario, "usuario1", "usrcreador", contrato.usrcreador);
            ViewBag.usrmodificador = new SelectList(db.usuario, "usuario1", "usrcreador", contrato.usrmodificador);
            return View(contrato);
        }

        // GET: contratoes/Delete/5
        public ActionResult Delete(string id, string id2, DateTime id3)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            contrato contrato = db.contrato.Find(id3, id, id2);
            if (contrato == null)
            {
                return HttpNotFound();
            }
            return View(contrato);
        }

        // POST: contratoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id, string id2, DateTime id3)
        {
            contrato contrato = db.contrato.Find(id3, id, id2);
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
