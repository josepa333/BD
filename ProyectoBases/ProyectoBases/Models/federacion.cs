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
    
    public partial class federacion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public federacion()
        {
            this.clubs = new HashSet<club>();
        }
    
        public string idfederacion { get; set; }
        public string nombre { get; set; }
        public System.DateTime fchfundada { get; set; }
        public string usrcreador { get; set; }
        public System.DateTime fchcreacion { get; set; }
        public string usrmodificador { get; set; }
        public string fchmodificacion { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<club> clubs { get; set; }
        public virtual usuario usuario { get; set; }
        public virtual usuario usuario1 { get; set; }
    }
}
