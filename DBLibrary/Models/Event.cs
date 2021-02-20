using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLibrary.Models
{
    public class Event : IModels
    {
        public long EventID { get; set; }
        public string EventName { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public string EventDesription { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public Nullable<int> TrenutnoStanje_id { get; set; }
        public Nullable<int> Profil_Id { get; set; }
        public Nullable<int> Country_id { get; set; }
        public bool Verified { get; set; }
        public virtual Country Country { get; set; }
        public virtual Profil_Tbl Profil_Tbl { get; set; }
        public virtual Stanje Stanje { get; set; }
        public Place Place{get;set;}
        public IEnumerable<Aktivnosti> Aktivnostis { get; set; }
    }
}
