//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace studis.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class izvajanjeleto
    {
        public int id { get; set; }
        public int studijskoletoId { get; set; }
        public long izvajanjeId { get; set; }
    
        public virtual sifrant_studijskoleto sifrant_studijskoleto { get; set; }
        public virtual izvajanje izvajanje { get; set; }
    }
}