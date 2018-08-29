using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoPaises.Models;

namespace ProyectoPaises.Controllers
{
    public class paisMoController : Controller
    {
        private proyectoBases2Entities5 db = new proyectoBases2Entities5();

        // GET: paisMo
        public ActionResult Index()
        {
            var pais = db.pais.Include(p => p.persona);
            return View(pais.ToList());
        }

        // GET: paisMo/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pais pais = db.pais.Find(id);
            if (pais == null)
            {
                return HttpNotFound();
            }
            return View(pais);
        }

        // GET: paisMo/Create
        public ActionResult Create()
        {
            ViewBag.idPresidenteActual = new SelectList(db.persona, "cedula", "nbrPersona");
            return View();
        }

        // POST: paisMo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idPais,nbrPais,area,poblacion,idPresidenteActual")] pais pais, HttpPostedFileBase bandera, HttpPostedFileBase himno)
        {
            MemoryStream target = new MemoryStream();
            if (himno != null)
            {
                byte[] anthem;


                himno.InputStream.CopyTo(target);
                anthem = target.ToArray();
                pais.BANDERA = anthem;

            }
            if (bandera != null)
            {
                byte[] flag;
                target = new MemoryStream();
                bandera.InputStream.CopyTo(target);
                flag = target.ToArray();
                pais.HIMNO = flag;
            }

            if (ModelState.IsValid)
            {
                db.pais.Add(pais);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idPresidenteActual = new SelectList(db.persona, "cedula", "nbrPersona", pais.idPresidenteActual);
            return View(pais);
        }

        // GET: paisMo/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pais pais = db.pais.Find(id);
            if (pais == null)
            {
                return HttpNotFound();
            }
            ViewBag.idPresidenteActual = new SelectList(db.persona, "cedula", "nbrPersona", pais.idPresidenteActual);
            return View(pais);
        }

        // POST: paisMo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idPais,nbrPais,area,poblacion,idPresidenteActual")] pais pais, HttpPostedFileBase bandera, HttpPostedFileBase himno)
        {
            MemoryStream target = new MemoryStream();
            if (himno != null)
            {
                byte[] anthem;


                himno.InputStream.CopyTo(target);
                anthem = target.ToArray();
                pais.BANDERA = anthem;

            }
            if (bandera != null)
            {
                byte[] flag;
                target = new MemoryStream();
                bandera.InputStream.CopyTo(target);
                flag = target.ToArray();
                pais.HIMNO = flag;
            }
            if (ModelState.IsValid)
            {
                db.Entry(pais).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idPresidenteActual = new SelectList(db.persona.Where(x => x.paisResidencia == pais.idPais), "cedula", "nbrPersona", pais.idPresidenteActual);
            return View(pais);
        }

        // GET: paisMo/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pais pais = db.pais.Find(id);
            if (pais == null)
            {
                return HttpNotFound();
            }
            return View(pais);
        }

        // POST: paisMo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            pais pais = db.pais.Find(id);
            db.pais.Remove(pais);
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
