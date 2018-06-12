using Proyecto_bases.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_bases.Controllers
{
    public class rivalesAnotadoresController : Controller
    {
        private ProyectoBasesJAREntities9 db = new ProyectoBasesJAREntities9();
        // GET: rivalesAnotadores
        public ActionResult Index()
        {
            ViewBag.idclub = new SelectList(db.club, "idclub", "idclub");
            return View();
        }

        [HttpPost]
        public ActionResult anotadoresRivales(string casa, string visita, string fecha)
        {
            ViewBag.idCasa = casa;
            ViewBag.idVisita = visita;

            SqlParameter parameter1 = new SqlParameter("@fecha", fecha);
            SqlParameter parameter2 = new SqlParameter("@equipo1", casa);
            SqlParameter parameter3 = new SqlParameter("@equipo2", visita);
            List<rivalesAnotaciones_Result> lista = db.Database.SqlQuery<rivalesAnotaciones_Result>("exec rivalesAnotaciones @fecha, @equipo1, @equipo2 ", parameter1, parameter2, parameter3).ToList();
            return View(lista);
        }
    }
}