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
    
    public partial class AktivnostiEvents_Tbl
    {
        public int ID { get; set; }
        public Nullable<int> AktivnostID { get; set; }
        public Nullable<int> EventID { get; set; }
        public bool IsActive { get; set; }
    
        public virtual Aktivnosti_Tbl Aktivnosti_Tbl { get; set; }
        public virtual Events_Tbl Events_Tbl { get; set; }
    }
}
