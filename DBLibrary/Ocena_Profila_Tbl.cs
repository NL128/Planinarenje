//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DBLibrary
{
    using System;
    using System.Collections.Generic;
    
    public partial class Ocena_Profila_Tbl
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ocena_Profila_Tbl()
        {
            this.Profil_Tbl = new HashSet<Profil_Tbl>();
        }
    
        public int OcenaID { get; set; }
        public int Nivo1 { get; set; }
        public int Nivo2 { get; set; }
        public int Nivo3 { get; set; }
        public int Nivo4 { get; set; }
        public int Nivo5 { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Profil_Tbl> Profil_Tbl { get; set; }
    }
}
