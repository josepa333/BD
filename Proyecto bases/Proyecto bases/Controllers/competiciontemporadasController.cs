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
    public class competiciontemporadasController : Controller
    {
        private ProyectoBasesJAREntities8 db = new ProyectoBasesJAREntities8();

        // GET: competiciontemporadas
        public ActionResult Index()
        {
            var competiciontemporada = db.competiciontemporada.Include(c => c.competicion).Include(c => c.temporada).Include(c => c.usuario).Include(c => c.usuario1);
            return View(competiciontemporada.ToList());
        }

        // GET: competiciontemporadas/Details/5
        public ActionResult Details(string id, int id2)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            competiciontemporada competiciontemporada = db.competiciontemporada.Find(id, id2);
            if (competiciontemporada == null)
            {
                return HttpNotFound();
            }
            return View(competiciontemporada);
        }

        // GET: competiciontemporadas/Create
        public ActionResult Create()
        {
            ViewBag.idcompeticion = new SelectList(db.competicion, "idcompeticion", "tipo");
            ViewBag.idtemporada = new SelectList(db.temporada, "idtemporada", "nombre");
            ViewBag.usrcreador = new SelectList(db.usuario, "usuario1", "usrcreador");
            ViewBag.usrmodificador = new SelectList(db.usuario, "usuario1", "usrcreador");
            return View();
        }

        // POST: competiciontemporadas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idcompeticion,idtemporada,usrcreador,fchcreacion,usrmodificador,fchmodificacion")] competiciontemporada competiciontemporada)
        {
            if (ModelState.IsValid)
            {
                db.competiciontemporada.Add(competiciontemporada);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idcompeticion = new SelectList(db.competicion, "idcompeticion", "tipo", competiciontemporada.idcompeticion);
            ViewBag.idtemporada = new SelectList(db.temporada, "idtemporada", "nombre", competiciontemporada.idtemporada);
            ViewBag.usrcreador = new SelectList(db.usuario, "usuario1", "usrcreador", competiciontemporada.usrcreador);
            ViewBag.usrmodificador = new SelectList(db.usuario, "usuario1", "usrcreador", competiciontemporada.usrmodificador);
            return View(competiciontemporada);
        }

        // GET: competiciontemporadas/Edit/5
        public ActionResult Edit(string id, int id2)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            competiciontemporada competiciontemporada = db.competiciontemporada.Find(id, id2);
            if (competiciontemporada == null)
            {
                return HttpNotFound();
            }
            ViewBag.idcompeticion = new SelectList(db.competicion, "idcompeticion", "tipo", competiciontemporada.idcompeticion);
            ViewBag.idtemporada = new SelectList(db.temporada, "idtemporada", "nombre", competiciontemporada.idtemporada);
            ViewBag.usrcreador = new SelectList(db.usuario, "usuario1", "usrcreador", competiciontemporada.usrcreador);
            ViewBag.usrmodificador = new SelectList(db.usuario, "usuario1", "usrcreador", competiciontemporada.usrmodificador);
            return View(competiciontemporada);
        }

        // POST: competiciontemporadas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idcompeticion,idtemporada,usrcreador,fchcreacion,usrmodificador,fchmodificacion")] competiciontemporada competiciontemporada)
        {
            if (ModelState.IsValid)
            {
                db.Entry(competiciontemporada).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idcompeticion = new SelectList(db.competicion, "idcompeticion", "tipo", competiciontemporada.idcompeticion);
            ViewBag.idtemporada = new SelectList(db.temporada, "idtemporada", "nombre", competiciontemporada.idtemporada);
            ViewBag.usrcreador = new SelectList(db.usuario, "usuario1", "usrcreador", competiciontemporada.usrcreador);
            ViewBag.usrmodificador = new SelectList(db.usuario, "usuario1", "usrcreador", competiciontemporada.usrmodificador);
            return View(competiciontemporada);
        }

        // GET: competiciontemporadas/Delete/5
        public ActionResult Delete(string id, int id2)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            competiciontemporada competiciontemporada = db.competiciontemporada.Find(id,id2);  
            if (competiciontemporada == null)
            {
                return HttpNotFound();
            }
            return View(competiciontemporada);
        }

        // POST: competiciontemporadas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id,int id2)
        {
            competiciontemporada competiciontemporada = db.competiciontemporada.Find(id,id2);
            db.competiciontemporada.Remove(competiciontemporada);
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

        public ActionResult Calendario(string id, int id2)
        {
            SqlConnection conn = new SqlConnection("data source=ecRhin.ec.tec.ac.cr\\Estudiantes;initial catalog=ProyectoBasesJAR;persist security info=True;user id=josepalvarado;password=josepalvarado;MultipleActiveResultSets=True;App=EntityFramework");
            conn.Open();
            SqlCommand cmd = new SqlCommand("generaCalendario", conn);

            SqlParameter parameter1 = new SqlParameter("@competicion", id);
            cmd.Parameters.Add(parameter1);
            SqlParameter parameter2 = new SqlParameter("@temporada", id2);
            cmd.Parameters.Add(parameter2);
            SqlParameter parameter3 = new SqlParameter("@federacion", "123");
            cmd.Parameters.Add(parameter3);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            conn.Close();

            var competiciontemporada = db.fechacalendario.Where(x => x.idcompeticion == id).Where(x => x.idtemporada == id2).ToList();
            return View(competiciontemporada);
        }

        public ActionResult Resultados(string id, int id2)
        {
            SqlConnection conn = new SqlConnection("data source=ecRhin.ec.tec.ac.cr\\Estudiantes;initial catalog=ProyectoBasesJAR;persist security info=True;user id=josepalvarado;password=josepalvarado;MultipleActiveResultSets=True;App=EntityFramework");
            conn.Open();
            SqlCommand cmd = new SqlCommand("creaResultados", conn);

            SqlParameter parameter1 = new SqlParameter("@competicion", id);
            cmd.Parameters.Add(parameter1);
            SqlParameter parameter2 = new SqlParameter("@temporada", id2);
            cmd.Parameters.Add(parameter2);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            conn.Close();


            SqlParameter parameter3 = new SqlParameter("@competicion", id);
            SqlParameter parameter4 = new SqlParameter("@temporada", id2);
            List<juego> lista = db.Database.SqlQuery<juego>("exec juegosDeResultados @competicion, @temporada", parameter3, parameter4).ToList();
            return View(lista);
        }

        
        public ActionResult TablaGeneral(string id, int id2)
        {
            SqlParameter parameter1 = new SqlParameter("@competicion", id);
            SqlParameter parameter2 = new SqlParameter("@temporada", id2);
            db.Database.SqlQuery<juego>("exec rankingLiga @competicion, @temporada", parameter1, parameter2);

            List<tablaGeneral_Result> lista = db.Database.SqlQuery<tablaGeneral_Result>("exec tablaGeneral @competicion, @temporada", parameter1, parameter2).ToList();
            return View(lista);
        }
        
    }
}


/* SqlParameter parameter1 = new SqlParameter("@competicion", id);
            SqlParameter parameter2 = new SqlParameter("@temporada", id2);
            SqlParameter parameter3 = new SqlParameter("@federacion", "123");
            db.Database.SqlQuery<fechacalendario>("exec generaCalendario @competicion, @temporada, @federacion", parameter1, parameter2, parameter3);
            db.SaveChanges();*/
