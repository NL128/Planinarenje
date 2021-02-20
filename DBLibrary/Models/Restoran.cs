using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLibrary.Models
{
    public class Restoran :IModels
    {
        public int ID { get; set; }
        public string RestoranName { get; set; }
        public Nullable<int> CountryId { get; set; }

        public string Subtitle { get; set; }
        public string Description { get; set; }
    }
}
