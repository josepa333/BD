//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyectoBases.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class histarbitrojuego
    {
        public decimal calificacion { get; set; }
        public string tipo { get; set; }
        public decimal idjuego { get; set; }
        public string idarbitro { get; set; }
        public string usrcreador { get; set; }
        public System.DateTime fchcreacion { get; set; }
        public string usrmodificador { get; set; }
        public Nullable<System.DateTime> fchmodificacion { get; set; }
    
        public virtual arbitro arbitro { get; set; }
        public virtual histjuego histjuego { get; set; }
        public virtual usuario usuario { get; set; }
        public virtual usuario usuario1 { get; set; }
    }
}
