using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoPaises.Models;

namespace ProyectoPaises.Controllers
{
    public class consultaController : Controller
    {
        private proyectoBases2Entities4 db = new proyectoBases2Entities4();
        // GET: consulta
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult consulta1()
        {
            SqlConnection conn = new SqlConnection("data source=ecRhin.ec.tec.ac.cr\\Estudiantes;initial catalog=ProyectoBasesJAR;persist security info=True;user id=josepalvarado;password=josepalvarado;MultipleActiveResultSets=True;App=EntityFramework");
            conn.Open();
            SqlCommand cmd = new SqlCommand("consulta1", conn);

            List<consulta1_Result> lista = db.Database.SqlQuery<consulta1_Result>("exec consulta1").ToList();
            return View(lista);

        }

        public ActionResult consulta2()
        {
            SqlConnection conn = new SqlConnection("data source=ecRhin.ec.tec.ac.cr\\Estudiantes;initial catalog=ProyectoBasesJAR;persist security info=True;user id=josepalvarado;password=josepalvarado;MultipleActiveResultSets=True;App=EntityFramework");
            conn.Open();
            SqlCommand cmd = new SqlCommand("consulta2", conn);

            List<consulta2_Result> lista = db.Database.SqlQuery<consulta2_Result>("exec consulta2").ToList();
            return View(lista);

        }
    }
}