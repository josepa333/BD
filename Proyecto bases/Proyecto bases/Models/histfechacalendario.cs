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
    
    public partial class histfechacalendario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public histfechacalendario()
        {
            this.histjuego = new HashSet<histjuego>();
        }
    
        public string idcompeticion { get; set; }
        public int idcalendario { get; set; }
        public System.DateTime fecha { get; set; }
        public int idtemporada { get; set; }
        public string usrcreador { get; set; }
        public System.DateTime fchcreacion { get; set; }
        public string usrmodificador { get; set; }
        public Nullable<System.DateTime> fchmodificacion { get; set; }
    
        public virtual histcompeticiontemporada histcompeticiontemporada { get; set; }
        public virtual usuario usuario { get; set; }
        public virtual usuario usuario1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<histjuego> histjuego { get; set; }
    }
}
