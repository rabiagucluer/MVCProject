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
    
    public partial class Fotograflar
    {
        public int FotoId { get; set; }
        public string FotoAdi { get; set; }
        public string FotoLink { get; set; }
        public Nullable<int> OyunNo { get; set; }
    
        public virtual Oyunlar Oyunlar { get; set; }
    }
}