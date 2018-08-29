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
        private static String connectionString;

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

        public static void rollBack()
        {
            transaction.Rollback();
        }

        public static String getConnectionString()
        {
            return connectionString;
        }

        public static void setConnectionString(String conne)
        {
            connectionString = conne;
        }






    }
}