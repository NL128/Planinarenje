using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Planinarenje.Models.ClientInputs
{
    public class CreateEventInput
    {
        [Required]
        public string EventName { get; set; }
        [Required]
        public string EventTitle { get; set; }
        [Required]
        public string EventDescription { get; set; }
        [Required]
        public string Coordinates { get; set; }
        [Required]
        public HttpPostedFileBase Image { get; set; }

        [Required]
        public int CountryID { get; set; }
        [Required]
        public int PlaceID { get; set; }

    }
}