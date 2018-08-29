using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoPaises.Models;

namespace ProyectoPaises.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Transaccion.setConnectionString("Data Source=ecRhin.ec.tec.ac.cr\\Estudiantes;Initial Catalog=proyectoBases2;Persist Security Info=True;User ID=josepalvarado;Password=josepalvarado;MultipleActiveResultSets=True;Application Name=EntityFramework");
            Transaccion ma = Transaccion.Instance();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}