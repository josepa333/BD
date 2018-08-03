﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Paises.Models;

namespace Paises.Controllers
{
    public class paisController : Controller
    {
        private proyectoBases2Entities db = new proyectoBases2Entities();

        // GET: pais
        public ActionResult Index()
        {
            var pais = db.pais.Include(p => p.persona);
            return View(pais.ToList());
        }

        // GET: pais/Details/5
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

        // GET: pais/Create
        public ActionResult Create()
        {
            ViewBag.idPresidenteActual = new SelectList(db.persona, "cedula", "nbrPersona");
            return View();
        }

        // POST: pais/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idPais,nbrPais,area,poblacion,idPresidenteActual")] pais pais)
        {
            if (ModelState.IsValid)
            {
                db.pais.Add(pais);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idPresidenteActual = new SelectList(db.persona, "cedula", "nbrPersona", pais.idPresidenteActual);
            return View(pais);
        }

        // GET: pais/Edit/5
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

        // POST: pais/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idPais,nbrPais,area,poblacion,idPresidenteActual")] pais pais)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pais).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idPresidenteActual = new SelectList(db.persona, "cedula", "nbrPersona", pais.idPresidenteActual);
            return View(pais);
        }

        // GET: pais/Delete/5
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

        // POST: pais/Delete/5
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
