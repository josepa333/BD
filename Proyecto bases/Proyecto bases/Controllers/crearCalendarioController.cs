using Proyecto_bases.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_bases.Controllers
{
    public class crearCalendarioController : Controller
    {
        private ProyectoBasesJAREntities9 db = new ProyectoBasesJAREntities9();

        // GET: crearCalendario
        public ActionResult Index()
        {
            ViewBag.idfederacion = new SelectList(db.federacion, "idfederacion", "idfederacion");
            ViewBag.idcompeticion = new SelectList(db.competicion, "idcompeticion", "idcompeticion");
            ViewBag.idtemporada = new SelectList(db.temporada, "idtemporada", "idtemporada");
            return View();
        }

        [HttpPost]
        public ActionResult calendarioCreado (string idcompeticion, int idtemporada, string idfederacion)
        {
            SqlConnection conn = new SqlConnection("data source=ecRhin.ec.tec.ac.cr\\Estudiantes;initial catalog=ProyectoBasesJAR;persist security info=True;user id=josepalvarado;password=josepalvarado;MultipleActiveResultSets=True;App=EntityFramework");
            conn.Open();
            SqlCommand cmd = new SqlCommand("generaCalendario", conn);

            SqlParameter parameter1 = new SqlParameter("@competicion", idcompeticion);
            cmd.Parameters.Add(parameter1);
            SqlParameter parameter2 = new SqlParameter("@temporada", idtemporada);
            cmd.Parameters.Add(parameter2);
            SqlParameter parameter3 = new SqlParameter("@federacion", idfederacion);
            cmd.Parameters.Add(parameter3);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            conn.Close();

            ViewBag.idT = idtemporada;
            ViewBag.idC = idcompeticion;
            var competiciontemporada = db.fechacalendario.Where(x => x.idcompeticion == idcompeticion).Where(x => x.idtemporada == idtemporada).ToList();
            return View(competiciontemporada);
        }
    }
}