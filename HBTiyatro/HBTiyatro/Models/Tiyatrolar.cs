//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HBTiyatro.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tiyatrolar
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tiyatrolar()
        {
            this.Sahneler = new HashSet<Sahneler>();
        }
    
        public int TiyatroID { get; set; }
        public string TiyatroAdi { get; set; }
        public Nullable<int> AdresID { get; set; }
    
        public virtual Adres Adres { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sahneler> Sahneler { get; set; }
    }
}