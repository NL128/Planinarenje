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
    
    public partial class Aktivnosti_Tbl
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Aktivnosti_Tbl()
        {
            this.AktivnostiPlaces_Tbl = new HashSet<AktivnostiPlaces_Tbl>();
            this.AktivnostiEvents_Tbl = new HashSet<AktivnostiEvents_Tbl>();
            this.AktivnostiProfiles_Tbl = new HashSet<AktivnostiProfiles_Tbl>();
        }
    
        public int AktivnostiID { get; set; }
        public string ImeAktivnosti { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AktivnostiPlaces_Tbl> AktivnostiPlaces_Tbl { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AktivnostiEvents_Tbl> AktivnostiEvents_Tbl { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AktivnostiProfiles_Tbl> AktivnostiProfiles_Tbl { get; set; }
    }
}
