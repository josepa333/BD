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
    
    public partial class juego
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public juego()
        {
            this.alineacions = new HashSet<alineacion>();
            this.anotadores = new HashSet<anotadore>();
            this.arbitrojuegoes = new HashSet<arbitrojuego>();
            this.cambios = new HashSet<cambio>();
        }
    
        public decimal idjuego { get; set; }
        public string jugado { get; set; }
        public Nullable<decimal> golescasa { get; set; }
        public Nullable<decimal> golesvisita { get; set; }
        public string idclubcasa { get; set; }
        public string idclubvisita { get; set; }
        public decimal idcalendario { get; set; }
        public string sinopsis { get; set; }
        public string usrcreador { get; set; }
        public Nullable<System.DateTime> fchcreacion { get; set; }
        public string usrmodificador { get; set; }
        public Nullable<System.DateTime> fchmodificacion { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<alineacion> alineacions { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<anotadore> anotadores { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<arbitrojuego> arbitrojuegoes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cambio> cambios { get; set; }
        public virtual club club { get; set; }
        public virtual club club1 { get; set; }
        public virtual fechacalendario fechacalendario { get; set; }
        public virtual usuario usuario { get; set; }
        public virtual usuario usuario1 { get; set; }
    }
}
