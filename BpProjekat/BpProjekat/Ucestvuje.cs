//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BpProjekat
{
    using System;
    using System.Collections.Generic;
    
    public partial class Ucestvuje
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ucestvuje()
        {
            this.Dodeljujes = new HashSet<Dodeljuje>();
        }
    
        public int Strip_idstr5 { get; set; }
        public int Festival_idf { get; set; }
    
        public virtual Strip Strip { get; set; }
        public virtual Festival Festival { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Dodeljuje> Dodeljujes { get; set; }
    }
}
