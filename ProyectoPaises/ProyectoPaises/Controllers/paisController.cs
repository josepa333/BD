using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoPaises.Models;



namespace ProyectoPaises.Controllers
{
    public class paisController : Controller
    {
        private proyectoBases2Entities5 db = new proyectoBases2Entities5();

        // GET: pais
        public ActionResult Index(int id = 1)
        {
            return View(Buscar(id));
        }

        public ActionResult ListOrders(int id = 1)
        {
            return PartialView(Buscar(id));
        }

        public List<pais> Buscar(int pageIndex)
        {
            pais pais = new pais();
            int pageCount = 0;
            List<pais> paises = pais.Listar(pageIndex, 10, out pageCount);
            ViewBag.PageCount = pageCount;
            ViewBag.PageIndex = pageIndex;
            return paises;
        }


        //Paginacion de las personas de la ventana de cada pais
        public ActionResult Personas(decimal idPais, int id = 1)
        {
            ViewBag.totalPaises = db.pais.Count();
            pais pais = db.pais.Where(x => x.idPais == idPais).First();
            ViewBag.nombrePais = pais.nbrPais;
            ViewBag.idPais = idPais;
            ViewBag.areaPais = pais.area;
            ViewBag.poblacionPais = pais.poblacion;
            ViewBag.paisBandera = pais.BANDERA;
            ViewBag.paisHimno = pais.HIMNO;
            ViewBag.BANDERA = pais.BANDERA;
            ViewBag.HIMNO = pais.HIMNO;
            int existe = db.persona.Where(x => x.cedula == pais.idPresidenteActual).Where(x => x.paisResidencia == idPais).Count();
            if(existe != 0)
            {
                persona presi = db.persona.Where(x => x.cedula == pais.idPresidenteActual).Where(x => x.paisResidencia == idPais).First();
                String nombrePresi = presi.nbrPersona;
                ViewBag.presidentePais = nombrePresi;

            }
            else
            {
                ViewBag.presidentePais = "Sin asignar" ;
            }

            return View(BuscarPersonas(id, idPais));
        }

        public ActionResult ListPersonas(decimal idPais, int id = 1)
        {
            return PartialView(BuscarPersonas(id, idPais));
        }

        public List<persona> BuscarPersonas(int pageIndex, decimal idPais)
        {
            persona persona = new persona();
            int pageCount = 0;
            List<persona> personas = persona.Listar(idPais, pageIndex, 10, out pageCount);
            ViewBag.PageCountPersonas = pageCount;
            ViewBag.PageIndexPersonas = pageIndex;
            ViewBag.idPais = idPais;
            return personas;
        }

        //Configurar datos personas por pais

        public ActionResult CreatePersona()
        {
            ViewBag.paisNacimiento = new SelectList(db.pais, "idPais", "nbrPais");
            ViewBag.paisResidencia = new SelectList(db.pais, "idPais", "nbrPais");
            return View();
        }

        // POST: personas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePersona([Bind(Include = "cedula,nbrPersona,paisNacimiento,paisResidencia,fchNacimiento,correo")] persona persona, HttpPostedFileBase foto, HttpPostedFileBase entrevista)
        {
            MemoryStream target = new MemoryStream();

            if (foto != null)
            {
                byte[] picture;

                foto.InputStream.CopyTo(target);
                picture = target.ToArray();
                persona.FOTO = picture;
            }


            if(entrevista != null)
            {
                byte[] interview;
                target = new MemoryStream();
                entrevista.InputStream.CopyTo(target);
                interview = target.ToArray();
                persona.ENTREVISTA = interview;

            }

            if (ModelState.IsValid)
            {
                Transaccion.agregarPersona(persona);
                return RedirectToAction("Index");
            }

            ViewBag.paisNacimiento = new SelectList(db.pais, "idPais", "nbrPais", persona.paisNacimiento);
            ViewBag.paisResidencia = new SelectList(db.pais, "idPais", "nbrPais", persona.paisResidencia);
            return View(persona);
        }

        public ActionResult EditPersona(decimal id, decimal id2)
        {
            persona persona = Transaccion.Contexto().persona.Find(id,id2);
            if (persona == null)
            {
                return HttpNotFound();
            }
            ViewBag.paisNacimiento = new SelectList(db.pais, "idPais", "nbrPais", persona.paisNacimiento);
            ViewBag.paisResidencia = new SelectList(db.pais, "idPais", "nbrPais", persona.paisResidencia);
            return View(persona);
        }

        public ActionResult DeletePersona(decimal idPersona, decimal id2, decimal idPais, int page)
        {
            persona persona = db.persona.Find(idPersona,id2);
            db.persona.Remove(persona);
            db.SaveChanges();
            return RedirectToAction("Personas", "pais", new { idPais = idPais, id = page });
        }

        // POST: personas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPersona([Bind(Include = "cedula,nbrPersona,paisNacimiento,paisResidencia,fchNacimiento,correo")] persona persona, HttpPostedFileBase foto, HttpPostedFileBase entrevista)
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
                SqlConnection conexion = new SqlConnection(Transaccion.getConnectionString());
                conexion.Open();
                SqlCommand cmd = new SqlCommand("actualizaPersona", conexion);

                SqlParameter parameter1 = new SqlParameter("@cedula", persona.cedula);
                cmd.Parameters.Add(parameter1);
                SqlParameter parameter2 = new SqlParameter("@nbrPersona", persona.nbrPersona);
                cmd.Parameters.Add(parameter2);
                SqlParameter parameter3 = new SqlParameter("@paisNacimiento", persona.paisNacimiento);
                cmd.Parameters.Add(parameter3);
                SqlParameter parameter4 = new SqlParameter("@paisResidencia", persona.paisResidencia);
                cmd.Parameters.Add(parameter4);
                SqlParameter parameter5 = new SqlParameter("@fecha", persona.fchNacimiento);
                cmd.Parameters.Add(parameter5);
                SqlParameter parameter6 = new SqlParameter("@correo", persona.correo);
                cmd.Parameters.Add(parameter6);
                SqlParameter parameter7 = new SqlParameter("@foto", persona.FOTO);
                cmd.Parameters.Add(parameter7);
                SqlParameter parameter8 = new SqlParameter("@entrevista", persona.ENTREVISTA);
                cmd.Parameters.Add(parameter8);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                conexion.Close();
                
                /*
                //Transaccion.modificarPersona(persona);
                Transaccion.rollBack();
                db.Entry(persona).State = EntityState.Modified;
                db.SaveChanges();
                Transaccion.reiniciarInstancia();
                */
                return RedirectToAction("Index");
            }
            ViewBag.paisNacimiento = new SelectList(Transaccion.Contexto().pais, "idPais", "nbrPais", persona.paisNacimiento);
            ViewBag.paisResidencia = new SelectList(Transaccion.Contexto().pais, "idPais", "nbrPais", persona.paisResidencia);
            return View(persona);
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
        public ActionResult Create([Bind(Include = "idPais,nbrPais,area,poblacion,idPresidenteActual")] pais pais, HttpPostedFileBase bandera, HttpPostedFileBase himno)
        {
            MemoryStream target = new MemoryStream();
            if (himno != null)
            {
                byte[] anthem;


                himno.InputStream.CopyTo(target);
                anthem = target.ToArray();
                pais.HIMNO = anthem;

            }
            if (bandera != null)
            {
                byte[] flag;
                target = new MemoryStream();
                bandera.InputStream.CopyTo(target);
                flag = target.ToArray();
                pais.BANDERA = flag;
            }

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
            pais pais = Transaccion.Contexto().pais.Find(id);
            if (pais == null)
            {
                return HttpNotFound();
            }
            ViewBag.idPresidenteActual = new SelectList(Transaccion.Contexto().persona.Where(x => x.paisResidencia == id), "cedula", "nbrPersona", pais.idPresidenteActual);
            return View(pais);
        }

        // POST: pais/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idPais,nbrPais,area,poblacion,idPresidenteActual")] pais pais, HttpPostedFileBase bandera, HttpPostedFileBase himno)
        {
            MemoryStream target = new MemoryStream();
            if (himno != null)
            {
                byte[] anthem;
                himno.InputStream.CopyTo(target);
                anthem = target.ToArray();
                pais.HIMNO = anthem;

            }
            if (bandera != null)
            {
                byte[] flag;
                target = new MemoryStream();
                bandera.InputStream.CopyTo(target);
                flag = target.ToArray();
                pais.BANDERA = flag;
            }
            if (ModelState.IsValid)
            {
                Transaccion.rollBack();
                db.Entry(pais).State = EntityState.Modified;
                db.SaveChanges();
                Transaccion.reiniciarInstancia();
                return RedirectToAction("Index");
            }
            ViewBag.idPresidenteActual = new SelectList(db.persona.Where(x => x.paisResidencia == pais.idPais), "cedula", "nbrPersona", pais.idPresidenteActual);
            return View(pais);
        }

        // GET: pais/Delete/5
        public ActionResult Delete(decimal id)
        {
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

        /*Commit*/

        public ActionResult commitCambios()
        {

            Transaccion.commit();
            Transaccion.reiniciarInstancia();
            return RedirectToAction("Index");
        }

        public ActionResult rollBackCambios()
        {
            Transaccion.rollBack();
            Transaccion.reiniciarInstancia();
            return RedirectToAction("Index");
        }

        
    }
}
