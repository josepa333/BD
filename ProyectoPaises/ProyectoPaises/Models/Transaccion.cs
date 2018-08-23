using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace ProyectoPaises.Models
{

    public class Transaccion
    {
        public static volatile Transaccion instance = null;
        private static proyectoBases2Entities5 contexto;
        private static DbContextTransaction transaction;
        private static List<persona> personasModificadas = new List<persona>();

        public static Transaccion Instance()
        {
            if(instance == null)
            {
                instance = new Transaccion();
            }
            return  instance;
        }


        public static proyectoBases2Entities5 Contexto()
        {
            return contexto;
        }
        private Transaccion()
        {
            contexto = new proyectoBases2Entities5();
            transaction = contexto.Database.BeginTransaction(System.Data.IsolationLevel.RepeatableRead);
        }

        public static void agregarPersona(persona cristiano)
        {
            contexto.persona.Add(cristiano);
        }

        public static void commit()
        {
            contexto.SaveChanges();
            transaction.Commit();
        }


        public static void reiniciarInstancia()
        {
            instance = new Transaccion();
        }

        public static void modificarPersona(persona cristiano)
        {
            personasModificadas.Add(cristiano);
        }


        private static void guardarCambios()
        {
            foreach(persona cambiada in personasModificadas)
            {
                contexto.Entry(cambiada).State = EntityState.Modified;
                contexto.SaveChanges();
            }

            personasModificadas.Clear();

        }







    }
}