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
    public class personaController : Controller
    {
        private proyectoBases2Entities5 db = new proyectoBases2Entities5();

        // GET: persona
        public ActionResult Index()
        {
            var persona = db.persona.Include(p => p.pais1).Include(p => p.pais2);
            return View(persona.ToList());
        }

        // GET: persona/Details/5
        public ActionResult Details(decimal id, decimal id2)
        {
            persona persona = db.persona.Find(id,id2);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        // GET: persona/Create
        public ActionResult Create()
        {
            ViewBag.paisNacimiento = new SelectList(db.pais, "idPais", "nbrPais");
            ViewBag.paisResidencia = new SelectList(db.pais, "idPais", "nbrPais");
            return View();
        }

        // POST: persona/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cedula,nbrPersona,paisNacimiento,paisResidencia,fchNacimiento,correo")] persona persona, HttpPostedFileBase foto, HttpPostedFileBase entrevista)
        {
            MemoryStream target = new MemoryStream();

            if (foto != null)
            {
                byte[] picture;

                foto.InputStream.CopyTo(target);
                picture = target.ToArray();
                persona.FOTO = picture;
            }


            if (entrevista != null)
            {
                byte[] interview;
                target = new MemoryStream();
                entrevista.InputStream.CopyTo(target);
                interview = target.ToArray();
                persona.ENTREVISTA = interview;

            }
            if (ModelState.IsValid)
            {
                db.persona.Add(persona);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.paisNacimiento = new SelectList(db.pais, "idPais", "nbrPais", persona.paisNacimiento);
            ViewBag.paisResidencia = new SelectList(db.pais, "idPais", "nbrPais", persona.paisResidencia);
            return View(persona);
        }

        // GET: persona/Edit/5
        public ActionResult Edit(decimal id, decimal id2)
        {
            persona persona = db.persona.Find(id,id2);
            if (persona == null)
            {
                return HttpNotFound();
            }
            ViewBag.paisNacimiento = new SelectList(db.pais, "idPais", "nbrPais", persona.paisNacimiento);
            ViewBag.paisResidencia = new SelectList(db.pais, "idPais", "nbrPais", persona.paisResidencia);
            return View(persona);
        }

        // POST: persona/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cedula,nbrPersona,paisNacimiento,paisResidencia,fchNacimiento,correo")] persona persona, HttpPostedFileBase foto, HttpPostedFileBase entrevista)
        {
            MemoryStream target = new MemoryStream();

            if (foto != null)
            {
                byte[] picture;

                foto.InputStream.CopyTo(target);
                picture = target.ToArray();
                persona.FOTO = picture;
            }


            if (entrevista != null)
            {
                byte[] interview;
                target = new MemoryStream();
                entrevista.InputStream.CopyTo(target);
                interview = target.ToArray();
                persona.ENTREVISTA = interview;

            }
            if (ModelState.IsValid)
            {
                db.Entry(persona).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.paisNacimiento = new SelectList(db.pais, "idPais", "nbrPais", persona.paisNacimiento);
            ViewBag.paisResidencia = new SelectList(db.pais, "idPais", "nbrPais", persona.paisResidencia);
            return View(persona);
        }

        // GET: persona/Delete/5
        public ActionResult Delete(decimal id, decimal id2)
        {
            persona persona = db.persona.Find(id,id2);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        // POST: persona/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id, decimal id2)
        {
            persona persona = db.persona.Find(id,id2);
            db.persona.Remove(persona);
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
