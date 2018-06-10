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
    public class funcclubcomptemporadaController : Controller
    {
        private ProyectoBasesJAREntities9 db = new ProyectoBasesJAREntities9();

        // GET: funcclubcomptemporadas
        public ActionResult Index()
        {
            var funcclubcomptemporada = db.funcclubcomptemporada.Include(f => f.club).Include(f => f.competiciontemporada).Include(f => f.usuario).Include(f => f.usuario1).Include(f => f.funcionariodeportivo);
            return View(funcclubcomptemporada.ToList());
        }

        // GET: funcclubcomptemporadas/Details/5
        public ActionResult Details(string id, string id2, int id3, string id4)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            funcclubcomptemporada funcclubcomptemporada = db.funcclubcomptemporada.Find(id,id2,id3,id4);
            if (funcclubcomptemporada == null)
            {
                return HttpNotFound();
            }
            return View(funcclubcomptemporada);
        }

        // GET: funcclubcomptemporadas/Create
        public ActionResult Create()
        {
            ViewBag.idclub = new SelectList(db.club, "idclub", "idclub");
            ViewBag.idcompeticion = new SelectList(db.competiciontemporada, "idcompeticion", "idcompeticion");
            ViewBag.usrcreador = new SelectList(db.usuario, "usuario1", "usuario1");
            ViewBag.usrmodificador = new SelectList(db.usuario, "usuario1", "usuario1");
            ViewBag.idfuncionario = new SelectList(db.funcionariodeportivo, "idfuncionario", "idfuncionario");
            return View();
        }

        // POST: funcclubcomptemporadas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idfuncionario,idclub,goles,sinopsis,idtemporada,idcompeticion,usrcreador,fchcreacion,usrmodificador,fchmodificacion")] funcclubcomptemporada funcclubcomptemporada)
        {
            if (ModelState.IsValid)
            {
                db.funcclubcomptemporada.Add(funcclubcomptemporada);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idclub = new SelectList(db.club, "idclub", "idclub", funcclubcomptemporada.idclub);
            ViewBag.idcompeticion = new SelectList(db.competiciontemporada, "idcompeticion", "idcompeticion", funcclubcomptemporada.idcompeticion);
            ViewBag.usrcreador = new SelectList(db.usuario, "usuario1", "usuario1", funcclubcomptemporada.usrcreador);
            ViewBag.usrmodificador = new SelectList(db.usuario, "usuario1", "usuario1", funcclubcomptemporada.usrmodificador);
            ViewBag.idfuncionario = new SelectList(db.funcionariodeportivo, "idfuncionario", "idfuncionario", funcclubcomptemporada.idfuncionario);
            return View(funcclubcomptemporada);
        }

        // GET: funcclubcomptemporadas/Edit/5
        public ActionResult Edit(string id, string id2, int id3, string id4)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            funcclubcomptemporada funcclubcomptemporada = db.funcclubcomptemporada.Find(id, id2, id3, id4);
            if (funcclubcomptemporada == null)
            {
                return HttpNotFound();
            }
            ViewBag.idclub = new SelectList(db.club, "idclub", "idclub", funcclubcomptemporada.idclub);
            ViewBag.idcompeticion = new SelectList(db.competiciontemporada, "idcompeticion", "idcompeticion", funcclubcomptemporada.idcompeticion);
            ViewBag.usrcreador = new SelectList(db.usuario, "usuario1", "usuario1", funcclubcomptemporada.usrcreador);
            ViewBag.usrmodificador = new SelectList(db.usuario, "usuario1", "usuario1", funcclubcomptemporada.usrmodificador);
            ViewBag.idfuncionario = new SelectList(db.funcionariodeportivo, "idfuncionario", "idfuncionario", funcclubcomptemporada.idfuncionario);
            return View(funcclubcomptemporada);
        }

        // POST: funcclubcomptemporadas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idfuncionario,idclub,goles,sinopsis,idtemporada,idcompeticion,usrcreador,fchcreacion,usrmodificador,fchmodificacion")] funcclubcomptemporada funcclubcomptemporada)
        {
            if (ModelState.IsValid)
            {
                db.Entry(funcclubcomptemporada).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idclub = new SelectList(db.club, "idclub", "idclub", funcclubcomptemporada.idclub);
            ViewBag.idcompeticion = new SelectList(db.competiciontemporada, "idcompeticion", "idcompeticion", funcclubcomptemporada.idcompeticion);
            ViewBag.usrcreador = new SelectList(db.usuario, "usuario1", "usuario1", funcclubcomptemporada.usrcreador);
            ViewBag.usrmodificador = new SelectList(db.usuario, "usuario1", "usuario1", funcclubcomptemporada.usrmodificador);
            ViewBag.idfuncionario = new SelectList(db.funcionariodeportivo, "idfuncionario", "idfuncionario", funcclubcomptemporada.idfuncionario);
            return View(funcclubcomptemporada);
        }

        // GET: funcclubcomptemporadas/Delete/5
        public ActionResult Delete(string id, string id2, int id3, string id4)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            funcclubcomptemporada funcclubcomptemporada = db.funcclubcomptemporada.Find(id, id2, id3, id4);
            if (funcclubcomptemporada == null)
            {
                return HttpNotFound();
            }
            return View(funcclubcomptemporada);
        }

        // POST: funcclubcomptemporadas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id, string id2, int id3, string id4)
        {
            funcclubcomptemporada funcclubcomptemporada = db.funcclubcomptemporada.Find(id, id2, id3, id4);
            db.funcclubcomptemporada.Remove(funcclubcomptemporada);
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
