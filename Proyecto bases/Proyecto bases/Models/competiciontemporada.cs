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
    
    public partial class competiciontemporada
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public competiciontemporada()
        {
            this.clubcompeticiontemporada = new HashSet<clubcompeticiontemporada>();
            this.fechacalendario = new HashSet<fechacalendario>();
            this.funcclubcomptemporada = new HashSet<funcclubcomptemporada>();
        }
    
        public string idcompeticion { get; set; }
        public int idtemporada { get; set; }
        public string usrcreador { get; set; }
        public System.DateTime fchcreacion { get; set; }
        public string usrmodificador { get; set; }
        public Nullable<System.DateTime> fchmodificacion { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<clubcompeticiontemporada> clubcompeticiontemporada { get; set; }
        public virtual competicion competicion { get; set; }
        public virtual temporada temporada { get; set; }
        public virtual usuario usuario { get; set; }
        public virtual usuario usuario1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<fechacalendario> fechacalendario { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<funcclubcomptemporada> funcclubcomptemporada { get; set; }
    }
}
