
//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
public partial class usuario
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public usuario()
    {

        this.alineacion = new HashSet<alineacion>();

        this.alineacion1 = new HashSet<alineacion>();

        this.anotadores = new HashSet<anotadores>();

        this.anotadores1 = new HashSet<anotadores>();

        this.arbitro = new HashSet<arbitro>();

        this.arbitro1 = new HashSet<arbitro>();

        this.arbitrojuego = new HashSet<arbitrojuego>();

        this.arbitrojuego1 = new HashSet<arbitrojuego>();

        this.cambios = new HashSet<cambios>();

        this.cambios1 = new HashSet<cambios>();

        this.categoria = new HashSet<categoria>();

        this.categoria1 = new HashSet<categoria>();

        this.club = new HashSet<club>();

        this.club1 = new HashSet<club>();

        this.clubcompeticiontemporada = new HashSet<clubcompeticiontemporada>();

        this.clubcompeticiontemporada1 = new HashSet<clubcompeticiontemporada>();

        this.competicion = new HashSet<competicion>();

        this.competicion1 = new HashSet<competicion>();

        this.competiciontemporada = new HashSet<competiciontemporada>();

        this.competiciontemporada1 = new HashSet<competiciontemporada>();

        this.contrato = new HashSet<contrato>();

        this.contrato1 = new HashSet<contrato>();

        this.correo = new HashSet<correo>();

        this.correo1 = new HashSet<correo>();

        this.direccion = new HashSet<direccion>();

        this.direccion1 = new HashSet<direccion>();

        this.entrenador = new HashSet<entrenador>();

        this.entrenador1 = new HashSet<entrenador>();

        this.entrenadortitulo = new HashSet<entrenadortitulo>();

        this.entrenadortitulo1 = new HashSet<entrenadortitulo>();

        this.especialidad = new HashSet<especialidad>();

        this.especialidad1 = new HashSet<especialidad>();

        this.especialidadjugador = new HashSet<especialidadjugador>();

        this.especialidadjugador1 = new HashSet<especialidadjugador>();

        this.fechacalendario = new HashSet<fechacalendario>();

        this.fechacalendario1 = new HashSet<fechacalendario>();

        this.federacion = new HashSet<federacion>();

        this.federacion1 = new HashSet<federacion>();

        this.funcclubcomptemporada = new HashSet<funcclubcomptemporada>();

        this.funcclubcomptemporada1 = new HashSet<funcclubcomptemporada>();

        this.funcionariodeportivo = new HashSet<funcionariodeportivo>();

        this.funcionariodeportivo1 = new HashSet<funcionariodeportivo>();

        this.histalineacion = new HashSet<histalineacion>();

        this.histalineacion1 = new HashSet<histalineacion>();

        this.histanotadores = new HashSet<histanotadores>();

        this.histanotadores1 = new HashSet<histanotadores>();

        this.histarbitrojuego = new HashSet<histarbitrojuego>();

        this.histarbitrojuego1 = new HashSet<histarbitrojuego>();

        this.histcambios = new HashSet<histcambios>();

        this.histcambios1 = new HashSet<histcambios>();

        this.histclubcompeticiontemporada = new HashSet<histclubcompeticiontemporada>();

        this.histclubcompeticiontemporada1 = new HashSet<histclubcompeticiontemporada>();

        this.histcompeticiontemporada = new HashSet<histcompeticiontemporada>();

        this.histcompeticiontemporada1 = new HashSet<histcompeticiontemporada>();

        this.histfechacalendario = new HashSet<histfechacalendario>();

        this.histfechacalendario1 = new HashSet<histfechacalendario>();

        this.histfuncclubcomptemporada = new HashSet<histfuncclubcomptemporada>();

        this.histfuncclubcomptemporada1 = new HashSet<histfuncclubcomptemporada>();

        this.histjuego = new HashSet<histjuego>();

        this.histjuego1 = new HashSet<histjuego>();

        this.juego = new HashSet<juego>();

        this.juego1 = new HashSet<juego>();

        this.jugador = new HashSet<jugador>();

        this.jugador1 = new HashSet<jugador>();

        this.oferta = new HashSet<oferta>();

        this.oferta1 = new HashSet<oferta>();

        this.sociosclub = new HashSet<sociosclub>();

        this.sociosclub1 = new HashSet<sociosclub>();

        this.telefono = new HashSet<telefono>();

        this.telefono1 = new HashSet<telefono>();

        this.temporada = new HashSet<temporada>();

        this.temporada1 = new HashSet<temporada>();

        this.tituloacademico = new HashSet<tituloacademico>();

        this.tituloacademico1 = new HashSet<tituloacademico>();

        this.usuario11 = new HashSet<usuario>();

        this.usuario12 = new HashSet<usuario>();

    }


    public string usuario1 { get; set; }

    public string usrcreador { get; set; }

    public Nullable<System.DateTime> fchcreacion { get; set; }

    public string usrmodificador { get; set; }

    public Nullable<System.DateTime> fchmodificacion { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<alineacion> alineacion { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<alineacion> alineacion1 { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<anotadores> anotadores { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<anotadores> anotadores1 { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<arbitro> arbitro { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<arbitro> arbitro1 { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<arbitrojuego> arbitrojuego { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<arbitrojuego> arbitrojuego1 { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<cambios> cambios { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<cambios> cambios1 { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<categoria> categoria { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<categoria> categoria1 { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<club> club { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<club> club1 { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<clubcompeticiontemporada> clubcompeticiontemporada { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<clubcompeticiontemporada> clubcompeticiontemporada1 { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<competicion> competicion { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<competicion> competicion1 { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<competiciontemporada> competiciontemporada { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<competiciontemporada> competiciontemporada1 { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<contrato> contrato { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<contrato> contrato1 { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<correo> correo { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<correo> correo1 { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<direccion> direccion { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<direccion> direccion1 { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<entrenador> entrenador { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<entrenador> entrenador1 { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<entrenadortitulo> entrenadortitulo { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<entrenadortitulo> entrenadortitulo1 { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<especialidad> especialidad { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<especialidad> especialidad1 { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<especialidadjugador> especialidadjugador { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<especialidadjugador> especialidadjugador1 { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<fechacalendario> fechacalendario { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<fechacalendario> fechacalendario1 { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<federacion> federacion { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<federacion> federacion1 { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<funcclubcomptemporada> funcclubcomptemporada { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<funcclubcomptemporada> funcclubcomptemporada1 { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<funcionariodeportivo> funcionariodeportivo { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<funcionariodeportivo> funcionariodeportivo1 { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<histalineacion> histalineacion { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<histalineacion> histalineacion1 { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<histanotadores> histanotadores { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<histanotadores> histanotadores1 { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<histarbitrojuego> histarbitrojuego { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<histarbitrojuego> histarbitrojuego1 { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<histcambios> histcambios { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<histcambios> histcambios1 { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<histclubcompeticiontemporada> histclubcompeticiontemporada { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<histclubcompeticiontemporada> histclubcompeticiontemporada1 { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<histcompeticiontemporada> histcompeticiontemporada { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<histcompeticiontemporada> histcompeticiontemporada1 { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<histfechacalendario> histfechacalendario { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<histfechacalendario> histfechacalendario1 { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<histfuncclubcomptemporada> histfuncclubcomptemporada { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<histfuncclubcomptemporada> histfuncclubcomptemporada1 { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<histjuego> histjuego { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<histjuego> histjuego1 { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<juego> juego { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<juego> juego1 { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<jugador> jugador { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<jugador> jugador1 { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<oferta> oferta { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<oferta> oferta1 { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<sociosclub> sociosclub { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<sociosclub> sociosclub1 { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<telefono> telefono { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<telefono> telefono1 { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<temporada> temporada { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<temporada> temporada1 { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<tituloacademico> tituloacademico { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<tituloacademico> tituloacademico1 { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<usuario> usuario11 { get; set; }

    public virtual usuario usuario2 { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<usuario> usuario12 { get; set; }

    public virtual usuario usuario3 { get; set; }

}

}
