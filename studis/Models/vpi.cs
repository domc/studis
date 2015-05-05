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
    
    public partial class vpi
    {
        public vpi()
        {
            this.ocenas = new HashSet<ocena>();
            this.studentinpredmets = new HashSet<studentinpredmet>();
        }
    
        public int id { get; set; }
        public int studijskoLeto { get; set; }
        public int studijskiProgram { get; set; }
        public Nullable<int> smer { get; set; }
        public int krajIzvajanja { get; set; }
        public int izbirnaSkupina { get; set; }
        public Nullable<int> studijskiProgram2 { get; set; }
        public Nullable<int> smer2 { get; set; }
        public Nullable<int> krajIzvajanja2 { get; set; }
        public Nullable<int> izbirnaSkupina2 { get; set; }
        public int vrstaStudija { get; set; }
        public int vrstaVpisa { get; set; }
        public int letnikStudija { get; set; }
        public int nacinStudija { get; set; }
        public int oblikaStudija { get; set; }
        public Nullable<int> studijskoLetoPrvegaVpisa { get; set; }
        public Nullable<bool> soglasje1 { get; set; }
        public Nullable<bool> soglasje2 { get; set; }
        public bool potrjen { get; set; }
        public int vpisnaStevilka { get; set; }
    
        public virtual ICollection<ocena> ocenas { get; set; }
        public virtual sifrant_izbirnaskupina sifrant_izbirnaskupina { get; set; }
        public virtual sifrant_izbirnaskupina sifrant_izbirnaskupina1 { get; set; }
        public virtual sifrant_klasius sifrant_klasius { get; set; }
        public virtual sifrant_letnik sifrant_letnik { get; set; }
        public virtual sifrant_nacinstudija sifrant_nacinstudija { get; set; }
        public virtual sifrant_obcina sifrant_obcina { get; set; }
        public virtual sifrant_obcina sifrant_obcina1 { get; set; }
        public virtual sifrant_oblikastudija sifrant_oblikastudija { get; set; }
        public virtual sifrant_studijskiprogram sifrant_studijskiprogram { get; set; }
        public virtual sifrant_studijskiprogram sifrant_studijskiprogram1 { get; set; }
        public virtual sifrant_studijskoleto sifrant_studijskoleto { get; set; }
        public virtual sifrant_studijskoletoprvegavpisa sifrant_studijskoletoprvegavpisa { get; set; }
        public virtual sifrant_vrstavpisa sifrant_vrstavpisa { get; set; }
        public virtual student student { get; set; }
        public virtual sifrant_smer sifrant_smer { get; set; }
        public virtual ICollection<studentinpredmet> studentinpredmets { get; set; }
    }
}
