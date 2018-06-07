﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Proyecto_bases.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class ProyectoBasesJAREntities8 : DbContext
    {
        public ProyectoBasesJAREntities8()
            : base("name=ProyectoBasesJAREntities8")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<alineacion> alineacion { get; set; }
        public virtual DbSet<anotadores> anotadores { get; set; }
        public virtual DbSet<arbitro> arbitro { get; set; }
        public virtual DbSet<arbitrojuego> arbitrojuego { get; set; }
        public virtual DbSet<cambios> cambios { get; set; }
        public virtual DbSet<categoria> categoria { get; set; }
        public virtual DbSet<club> club { get; set; }
        public virtual DbSet<clubcompeticiontemporada> clubcompeticiontemporada { get; set; }
        public virtual DbSet<competicion> competicion { get; set; }
        public virtual DbSet<competiciontemporada> competiciontemporada { get; set; }
        public virtual DbSet<contrato> contrato { get; set; }
        public virtual DbSet<correo> correo { get; set; }
        public virtual DbSet<direccion> direccion { get; set; }
        public virtual DbSet<entrenador> entrenador { get; set; }
        public virtual DbSet<entrenadortitulo> entrenadortitulo { get; set; }
        public virtual DbSet<especialidad> especialidad { get; set; }
        public virtual DbSet<especialidadjugador> especialidadjugador { get; set; }
        public virtual DbSet<fechacalendario> fechacalendario { get; set; }
        public virtual DbSet<federacion> federacion { get; set; }
        public virtual DbSet<funcclubcomptemporada> funcclubcomptemporada { get; set; }
        public virtual DbSet<funcionariodeportivo> funcionariodeportivo { get; set; }
        public virtual DbSet<histalineacion> histalineacion { get; set; }
        public virtual DbSet<histanotadores> histanotadores { get; set; }
        public virtual DbSet<histarbitrojuego> histarbitrojuego { get; set; }
        public virtual DbSet<histcambios> histcambios { get; set; }
        public virtual DbSet<histclubcompeticiontemporada> histclubcompeticiontemporada { get; set; }
        public virtual DbSet<histcompeticiontemporada> histcompeticiontemporada { get; set; }
        public virtual DbSet<histfechacalendario> histfechacalendario { get; set; }
        public virtual DbSet<histfuncclubcomptemporada> histfuncclubcomptemporada { get; set; }
        public virtual DbSet<histjuego> histjuego { get; set; }
        public virtual DbSet<juego> juego { get; set; }
        public virtual DbSet<jugador> jugador { get; set; }
        public virtual DbSet<oferta> oferta { get; set; }
        public virtual DbSet<sociosclub> sociosclub { get; set; }
        public virtual DbSet<telefono> telefono { get; set; }
        public virtual DbSet<temporada> temporada { get; set; }
        public virtual DbSet<tituloacademico> tituloacademico { get; set; }
        public virtual DbSet<usuario> usuario { get; set; }
    
        public virtual int buscaFecha(string nombreEquipo, Nullable<System.DateTime> fecha, ObjectParameter respuesta)
        {
            var nombreEquipoParameter = nombreEquipo != null ?
                new ObjectParameter("NombreEquipo", nombreEquipo) :
                new ObjectParameter("NombreEquipo", typeof(string));
    
            var fechaParameter = fecha.HasValue ?
                new ObjectParameter("Fecha", fecha) :
                new ObjectParameter("Fecha", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("buscaFecha", nombreEquipoParameter, fechaParameter, respuesta);
        }
    
        public virtual int creaResultados(string competicion, Nullable<decimal> temporada)
        {
            var competicionParameter = competicion != null ?
                new ObjectParameter("competicion", competicion) :
                new ObjectParameter("competicion", typeof(string));
    
            var temporadaParameter = temporada.HasValue ?
                new ObjectParameter("temporada", temporada) :
                new ObjectParameter("temporada", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("creaResultados", competicionParameter, temporadaParameter);
        }
    
        public virtual int determinaFecha(Nullable<int> semana, Nullable<int> dia, ObjectParameter fecha)
        {
            var semanaParameter = semana.HasValue ?
                new ObjectParameter("Semana", semana) :
                new ObjectParameter("Semana", typeof(int));
    
            var diaParameter = dia.HasValue ?
                new ObjectParameter("Dia", dia) :
                new ObjectParameter("Dia", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("determinaFecha", semanaParameter, diaParameter, fecha);
        }
    
        public virtual int generaCalendario(string competicion, Nullable<decimal> temporada, string federacion)
        {
            var competicionParameter = competicion != null ?
                new ObjectParameter("competicion", competicion) :
                new ObjectParameter("competicion", typeof(string));
    
            var temporadaParameter = temporada.HasValue ?
                new ObjectParameter("temporada", temporada) :
                new ObjectParameter("temporada", typeof(decimal));
    
            var federacionParameter = federacion != null ?
                new ObjectParameter("federacion", federacion) :
                new ObjectParameter("federacion", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("generaCalendario", competicionParameter, temporadaParameter, federacionParameter);
        }
    
        public virtual ObjectResult<infoEntrenador_Result> infoEntrenador(string idEntrenador)
        {
            var idEntrenadorParameter = idEntrenador != null ?
                new ObjectParameter("idEntrenador", idEntrenador) :
                new ObjectParameter("idEntrenador", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<infoEntrenador_Result>("infoEntrenador", idEntrenadorParameter);
        }
    
        public virtual ObjectResult<infoJugador_Result> infoJugador(string idJugador)
        {
            var idJugadorParameter = idJugador != null ?
                new ObjectParameter("idJugador", idJugador) :
                new ObjectParameter("idJugador", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<infoJugador_Result>("infoJugador", idJugadorParameter);
        }
    
        public virtual ObjectResult<juegosDeResultados_Result> juegosDeResultados(string competicion, Nullable<decimal> temporada)
        {
            var competicionParameter = competicion != null ?
                new ObjectParameter("competicion", competicion) :
                new ObjectParameter("competicion", typeof(string));
    
            var temporadaParameter = temporada.HasValue ?
                new ObjectParameter("temporada", temporada) :
                new ObjectParameter("temporada", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<juegosDeResultados_Result>("juegosDeResultados", competicionParameter, temporadaParameter);
        }
    
        public virtual int ligador(string equipo1, string equipo2, Nullable<int> dia, ObjectParameter fechaJuego)
        {
            var equipo1Parameter = equipo1 != null ?
                new ObjectParameter("equipo1", equipo1) :
                new ObjectParameter("equipo1", typeof(string));
    
            var equipo2Parameter = equipo2 != null ?
                new ObjectParameter("equipo2", equipo2) :
                new ObjectParameter("equipo2", typeof(string));
    
            var diaParameter = dia.HasValue ?
                new ObjectParameter("Dia", dia) :
                new ObjectParameter("Dia", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ligador", equipo1Parameter, equipo2Parameter, diaParameter, fechaJuego);
        }
    
        public virtual ObjectResult<tablaGeneral_Result> tablaGeneral(string idCompeticion, Nullable<decimal> idTemporada)
        {
            var idCompeticionParameter = idCompeticion != null ?
                new ObjectParameter("idCompeticion", idCompeticion) :
                new ObjectParameter("idCompeticion", typeof(string));
    
            var idTemporadaParameter = idTemporada.HasValue ?
                new ObjectParameter("idTemporada", idTemporada) :
                new ObjectParameter("idTemporada", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<tablaGeneral_Result>("tablaGeneral", idCompeticionParameter, idTemporadaParameter);
        }
    
        public virtual ObjectResult<arbitroDatos_Result> arbitroDatos(string idCompeticion, Nullable<decimal> idTemporada)
        {
            var idCompeticionParameter = idCompeticion != null ?
                new ObjectParameter("idCompeticion", idCompeticion) :
                new ObjectParameter("idCompeticion", typeof(string));
    
            var idTemporadaParameter = idTemporada.HasValue ?
                new ObjectParameter("idTemporada", idTemporada) :
                new ObjectParameter("idTemporada", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<arbitroDatos_Result>("arbitroDatos", idCompeticionParameter, idTemporadaParameter);
        }
    
        public virtual ObjectResult<equipos_2_Result> equipos_2(Nullable<System.DateTime> fecha, string equipo1, string equipo2)
        {
            var fechaParameter = fecha.HasValue ?
                new ObjectParameter("fecha", fecha) :
                new ObjectParameter("fecha", typeof(System.DateTime));
    
            var equipo1Parameter = equipo1 != null ?
                new ObjectParameter("equipo1", equipo1) :
                new ObjectParameter("equipo1", typeof(string));
    
            var equipo2Parameter = equipo2 != null ?
                new ObjectParameter("equipo2", equipo2) :
                new ObjectParameter("equipo2", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<equipos_2_Result>("equipos_2", fechaParameter, equipo1Parameter, equipo2Parameter);
        }
    }
}
