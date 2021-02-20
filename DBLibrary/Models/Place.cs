
using DBLibrary.DBContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLibrary.Models
{
    public class Place :IModels
    {
        public int ID { get; set; }
        public string PlaceName { get; set; }
        public string PlaceImage { get; set; }
        public string Description { get; set; }
        public string Subtitle { get; set; }
        public string Coordinates { get; set; }
        public IEnumerable<Restoran> Restorans { get; set; }
        public IEnumerable<Hotel> Hotels { get; set; }
        public IEnumerable<Aktivnosti> Aktivnostis { get; set; }
        public  ICollection<ComentPlaces_Tbl> ComentPlaces_Tbl { get; set; }
        public Ocena Ocena { get; set; }
        public Country Country { get; set; }
    }
}
