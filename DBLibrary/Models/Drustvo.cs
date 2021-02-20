using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLibrary.Models
{
    public  class Drustvo
    {
        public int PD_ID { get; set; }
        public string ImeDrustva { get; set; }
        public string AdresaDrustva { get; set; }
        public string Koordinate { get; set; }
        public string AddressNumber { get; set; }
    }
}
