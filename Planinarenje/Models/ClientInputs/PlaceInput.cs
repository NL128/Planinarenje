using Planinarenje.Models.ValidationArea;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Planinarenje.Models.ClientInputs
{
    public class PlaceInput : IInputGetter
    {
        [Required]
        [MustBeSpecificType]
        public int ID { get; set; }
    }
}