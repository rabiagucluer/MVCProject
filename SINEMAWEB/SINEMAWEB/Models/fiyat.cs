//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SINEMAWEB.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class fiyat
    {
        public short fiyatid { get; set; }
        public Nullable<short> turid { get; set; }
        public Nullable<decimal> fiyat1 { get; set; }
    
        public virtual filmturutb filmturutb { get; set; }
        public virtual kullanicituru kullanicituru { get; set; }
        public virtual kullanicituru kullanicituru1 { get; set; }
    }
}