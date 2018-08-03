using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Paises.Models;
using Paises.ViewModel;

namespace Paises.Controllers
{
    public class ShowDataController : Controller
    {
        private proyectoBases2Entities db = new proyectoBases2Entities();

        // GET: ShowData
        public ActionResult Multipledata()
        {
            var mymodel = new Multipledata();
            mymodel.Paises = db.pais.ToList();
            mymodel.Personas = db.persona.ToList();
            return View(mymodel);
        }
    }
}