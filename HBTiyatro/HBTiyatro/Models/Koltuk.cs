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
    
    public partial class Koltuk
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Koltuk()
        {
            this.Bilet = new HashSet<Bilet>();
        }
    
        public int KoltukID { get; set; }
        public Nullable<int> BlokID { get; set; }
        public Nullable<int> SahneID { get; set; }
        public string KoltukNumarasi { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bilet> Bilet { get; set; }
        public virtual Blok Blok { get; set; }
        public virtual Sahneler Sahneler { get; set; }
    }
}
