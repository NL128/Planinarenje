using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLibrary.Models
{
    public class Country : IModels
    {
        public int CountryID { get; set; }
        public string CountryName { get; set; }
        public string Coordinates { get; set; }
        public string ImageFlag { get; set; }
    }
}
