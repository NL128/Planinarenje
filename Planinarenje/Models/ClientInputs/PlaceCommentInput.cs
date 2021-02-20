using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Planinarenje.Models.ClientInputs
{
    public class PlaceCommentInput
    {
        [Required]
        [StringLength(500, ErrorMessage = "The maximum is 500 characters ! ")]

        public string Comment { get; set; }
        public int Place { get; set; }
        public float Ocena { get; set; }
    }
}