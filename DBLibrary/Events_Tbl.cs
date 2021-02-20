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
    
    public partial class Events_Tbl
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Events_Tbl()
        {
            this.AktivnostiEvents_Tbl = new HashSet<AktivnostiEvents_Tbl>();
            this.EventOcena_Tbl = new HashSet<EventOcena_Tbl>();
        }
    
        public int EventID { get; set; }
        public string EventName { get; set; }
        public string EventDesription { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public Nullable<int> TrenutnoStanje_id { get; set; }
        public Nullable<int> Profil_Id { get; set; }
        public Nullable<int> Country_id { get; set; }
        public Nullable<int> Places_id { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public bool Verified { get; set; }
    
        public virtual Country_Tbl Country_Tbl { get; set; }
        public virtual Stanje_Tbl Stanje_Tbl { get; set; }
        public virtual Places_Tbl Places_Tbl { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AktivnostiEvents_Tbl> AktivnostiEvents_Tbl { get; set; }
        public virtual Profil_Tbl Profil_Tbl { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EventOcena_Tbl> EventOcena_Tbl { get; set; }
    }
}
