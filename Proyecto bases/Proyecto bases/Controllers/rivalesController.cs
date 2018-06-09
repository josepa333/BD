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
    public class rivalesController : Controller
    {

        private ProyectoBasesJAREntities8 db = new ProyectoBasesJAREntities8();

        // GET: rivales
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult riv(string casa, string visita, string fecha)
        {

            SqlConnection conn = new SqlConnection("data source=ecRhin.ec.tec.ac.cr\\Estudiantes;initial catalog=ProyectoBasesJAR;persist security info=True;user id=josepalvarado;password=josepalvarado;MultipleActiveResultSets=True;App=EntityFramework");
            conn.Open();
            SqlCommand cmd = new SqlCommand("Rivales", conn);

            SqlParameter parameter1 = new SqlParameter("@fecha", fecha);
            SqlParameter parameter2 = new SqlParameter("@equipo1", casa);
            SqlParameter parameter3 = new SqlParameter("@equipo2", visita);

            List<Rivales_Result> lista = db.Database.SqlQuery<Rivales_Result>("exec Rivales @fecha, @equipo1, @equipo2", parameter1, parameter2, parameter3).ToList();
            return View(lista);  
        }
    }
}