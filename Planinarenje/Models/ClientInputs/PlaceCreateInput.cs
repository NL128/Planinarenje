using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Planinarenje.Models.ClientInputs
{
    public class PlaceCreateInput
    {
        [Required]
        public string PlaceName { get; set; }
        [Required]
        public string Coordinates { get; set; }
       [Required]
        public string PlaceSubtitle { get; set; }
        [Required]
        public string PlaceDescription { get; set; }
        [Required]

        public HttpPostedFileBase Image { get; set; }
        
        [Required]
        public string Country { get; set; }
    }
}