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
    
    public partial class sifrant_klasius
    {
        public sifrant_klasius()
        {
            this.predmets = new HashSet<predmet>();
            this.vpis = new HashSet<vpi>();
            this.zetons = new HashSet<zeton>();
        }
    
        public int id { get; set; }
        public string naziv { get; set; }
    
        public virtual ICollection<predmet> predmets { get; set; }
        public virtual ICollection<vpi> vpis { get; set; }
        public virtual ICollection<zeton> zetons { get; set; }
    }
}
