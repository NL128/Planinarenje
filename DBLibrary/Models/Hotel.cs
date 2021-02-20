using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLibrary.Models
{
    public class Hotel:IModels
    {
        public int ID { get; set; }
        public string HotelName { get; set; }
    }
}
