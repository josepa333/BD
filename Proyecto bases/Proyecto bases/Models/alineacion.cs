
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
    
public partial class alineacion
{

    public string idfuncionario { get; set; }

    public decimal idjuego { get; set; }

    public Nullable<decimal> rendimiento { get; set; }

    public string idclub { get; set; }

    public string tipo { get; set; }

    public string usrcreador { get; set; }

    public System.DateTime fchcreacion { get; set; }

    public string usrmodificador { get; set; }

    public Nullable<System.DateTime> fchmodificacion { get; set; }



    public virtual club club { get; set; }

    public virtual usuario usuario { get; set; }

    public virtual usuario usuario1 { get; set; }

    public virtual juego juego { get; set; }

    public virtual jugador jugador { get; set; }

}

}
