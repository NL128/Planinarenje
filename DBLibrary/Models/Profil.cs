using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLibrary.Models
{
     public class Profil : IModels
    {
        public int ProfilID { get; set; }
        
        public Nullable<int> GlavnaAktivnost_Id { get; set; }
        public Nullable<int> Ocena_Id { get; set; }
        [MaxLength(500,ErrorMessage ="Max Length is 500")]
        public string ShortDescription { get; set; }
        public string UserId { get; set; }
        public virtual ICollection<Aktivnosti> Aktivnosti { get; set; }
      
        public virtual ICollection<Event> Events { get; set; }
        public virtual Ocena Ocena_Profila { get; set; }
        
        public virtual UserInfo AspNetUser { get; set; }

        
    }
    
}
