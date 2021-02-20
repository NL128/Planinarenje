using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLibrary.Models
{
    public class Stanje : IModels
    {
        public int StanjeID { get; set; }
        public string TrenutnoStanje { get; set; }
    }
}
