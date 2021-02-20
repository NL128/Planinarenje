using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLibrary.Models
{
    public class Aktivnosti:IModels
    {
        public Nullable<int> AktivnostiID { get; set; }
        public string ImeAktivnosti { get; set; }
        
        public bool IsActive { get; set; }
    }
}
