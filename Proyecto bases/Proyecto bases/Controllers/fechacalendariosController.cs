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
    public class fechacalendariosController : Controller
    {
        private ProyectoBasesJAREntities9 db = new ProyectoBasesJAREntities9();

        // GET: fechacalendarios
        public ActionResult Index()
        {
            var fechacalendario = db.fechacalendario.Include(f => f.competiciontemporada).Include(f => f.usuario).Include(f => f.usuario1);
            return View(fechacalendario.ToList());
        }

        // GET: fechacalendarios/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fechacalendario fechacalendario = db.fechacalendario.Find(id);
            if (fechacalendario == null)
            {
                return HttpNotFound();
            }
            return View(fechacalendario);
        }

        // GET: fechacalendarios/Create
        public ActionResult Create()
        {
            ViewBag.idcompeticion = new SelectList(db.competiciontemporada, "idcompeticion", "idcompeticion");
            ViewBag.usrmodificador = new SelectList(db.usuario, "usuario1", "usuario1");
            ViewBag.usrcreador = new SelectList(db.usuario, "usuario1", "usuario1");
            return View();
        }

        // POST: fechacalendarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idcompeticion,idcalendario,fecha,idtemporada,usrcreador,fchcreacion,usrmodificador,fchmodificacion")] fechacalendario fechacalendario)
        {
            if (ModelState.IsValid)
            {
                db.fechacalendario.Add(fechacalendario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idcompeticion = new SelectList(db.competiciontemporada, "idcompeticion", "idcompeticion", fechacalendario.idcompeticion);
            ViewBag.usrmodificador = new SelectList(db.usuario, "usuario1", "usuario1", fechacalendario.usrmodificador);
            ViewBag.usrcreador = new SelectList(db.usuario, "usuario1", "usuario1", fechacalendario.usrcreador);
            return View(fechacalendario);
        }

        // GET: fechacalendarios/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fechacalendario fechacalendario = db.fechacalendario.Find(id);
            if (fechacalendario == null)
            {
                return HttpNotFound();
            }
            ViewBag.idcompeticion = new SelectList(db.competiciontemporada, "idcompeticion", "idcompeticion", fechacalendario.idcompeticion);
            ViewBag.usrmodificador = new SelectList(db.usuario, "usuario1", "usuario1", fechacalendario.usrmodificador);
            ViewBag.usrcreador = new SelectList(db.usuario, "usuario1", "usuario1", fechacalendario.usrcreador);
            return View(fechacalendario);
        }

        // POST: fechacalendarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idcompeticion,idcalendario,fecha,idtemporada,usrcreador,fchcreacion,usrmodificador,fchmodificacion")] fechacalendario fechacalendario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fechacalendario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idcompeticion = new SelectList(db.competiciontemporada, "idcompeticion", "idcompeticion", fechacalendario.idcompeticion);
            ViewBag.usrmodificador = new SelectList(db.usuario, "usuario1", "usuario1", fechacalendario.usrmodificador);
            ViewBag.usrcreador = new SelectList(db.usuario, "usuario1", "usuario1", fechacalendario.usrcreador);
            return View(fechacalendario);
        }

        // GET: fechacalendarios/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fechacalendario fechacalendario = db.fechacalendario.Find(id);
            if (fechacalendario == null)
            {
                return HttpNotFound();
            }
            return View(fechacalendario);
        }

        // POST: fechacalendarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            fechacalendario fechacalendario = db.fechacalendario.Find(id);
            db.fechacalendario.Remove(fechacalendario);
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
        public ActionResult juegosFechaCalendario(int idC)
        {
            ViewBag.idC = idC;
            var juego = db.juego.Where(x => x.idcalendario == idC).ToList();
            return View(juego);
        }

        public ActionResult anotadoresJuego(int idJ)
        {
            ViewBag.idJ = idJ;
            var anotaciones = db.anotadores.Where(x => x.idjuego == idJ).ToList();
            return View(anotaciones);
        }


        public ActionResult EditarJuegos(int idJ)
        {
            if (idJ == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            juego juego = db.juego.Find(idJ);
            if (juego == null)
            {
                return HttpNotFound();
            }
            ViewBag.idclubcasa = new SelectList(db.club, "idclub", "idclub", juego.idclubcasa);
            ViewBag.idclubvisita = new SelectList(db.club, "idclub", "idclub", juego.idclubvisita);
            ViewBag.idcalendario = new SelectList(db.fechacalendario, "idcalendario", "idcalendario", juego.idcalendario);
            ViewBag.usrcreador = new SelectList(db.usuario, "usuario1", "usuario1", juego.usrcreador);
            ViewBag.usrmodificador = new SelectList(db.usuario, "usuario1", "usuario1", juego.usrmodificador);
            return View(juego);
        }

        // POST: juegoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarJuegos([Bind(Include = "idjuego,jugado,golescasa,golesvisita,idclubcasa,idclubvisita,idcalendario,sinopsis,usrcreador,fchcreacion,usrmodificador,fchmodificacion")] juego juego)
        {
            if (ModelState.IsValid)
            {
                db.Entry(juego).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idclubcasa = new SelectList(db.club, "idclub", "idclub", juego.idclubcasa);
            ViewBag.idclubvisita = new SelectList(db.club, "idclub", "idclub", juego.idclubvisita);
            ViewBag.idcalendario = new SelectList(db.fechacalendario, "idcalendario", "idcalendario", juego.idcalendario);
            ViewBag.usrcreador = new SelectList(db.usuario, "usuario1", "usuario1", juego.usrcreador);
            ViewBag.usrmodificador = new SelectList(db.usuario, "usuario1", "usuario1", juego.usrmodificador);
            return View(juego);
        }


        public ActionResult BorrarJuegos(int idJ)
        {
            if (idJ == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            juego juego = db.juego.Find(idJ);
            if (juego == null)
            {
                return HttpNotFound();
            }
            return View(juego);
        }

        // POST: juegoes/Delete/5
        [HttpPost, ActionName("BorrarJuegos")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmedJuegos(decimal idJ)
        {
            juego juego = db.juego.Find(idJ);
            db.juego.Remove(juego);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult EditarAnotadores(int id, int id2)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            anotadores anotadores = db.anotadores.Find(id, id2);
            if (anotadores == null)
            {
                return HttpNotFound();
            }
            ViewBag.idclub = new SelectList(db.club, "idclub", "idclub", anotadores.idclub);
            ViewBag.usrcreador = new SelectList(db.usuario, "usuario1", "usuario1", anotadores.usrcreador);
            ViewBag.usrmodificador = new SelectList(db.usuario, "usuario1", "usuario1", anotadores.usrmodificador);
            ViewBag.idjuego = new SelectList(db.juego, "idjuego", "idjuego", anotadores.idjuego);
            ViewBag.idfuncionario = new SelectList(db.jugador, "idfuncionario", "idfuncionario", anotadores.idfuncionario);
            return View(anotadores);
        }

        // POST: anotadores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarAnotadores([Bind(Include = "idfuncionario,idjuego,minjuego,video,idclub,usrcreador,fchcreacion,usrmodificador,fchmodificacion")] anotadores anotadores)
        {
            if (ModelState.IsValid)
            {
                db.Entry(anotadores).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idclub = new SelectList(db.club, "idclub", "idclub", anotadores.idclub);
            ViewBag.usrcreador = new SelectList(db.usuario, "usuario1", "usuario1", anotadores.usrcreador);
            ViewBag.usrmodificador = new SelectList(db.usuario, "usuario1", "usuario1", anotadores.usrmodificador);
            ViewBag.idjuego = new SelectList(db.juego, "idjuego", "idjuego", anotadores.idjuego);
            ViewBag.idfuncionario = new SelectList(db.jugador, "idfuncionario", "idfuncionario", anotadores.idfuncionario);
            return View(anotadores);
        }


        // GET: anotadores/Delete/5
        public ActionResult BorrarAnotadores(int id, int id2)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            anotadores anotadores = db.anotadores.Find(id, id2);
            if (anotadores == null)
            {
                return HttpNotFound();
            }
            return View(anotadores);
        }

        // POST: anotadores/Delete/5
        [HttpPost, ActionName("BorrarAnotadores")]
        [ValidateAntiForgeryToken]
        public ActionResult BorrarAnotadoresConfirmado(int id, int id2)
        {
            anotadores anotadores = db.anotadores.Find(id, id2);
            db.anotadores.Remove(anotadores);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }//

}
