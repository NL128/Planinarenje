using DBLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Planinarenje.Models.ClientInputs
{
    public class PlaceCommentOutput
    {
        public IEnumerable<ComentPlaces_Tbl> comentPlaces_Tbls { get; set; }
        public int placeID { get; set; }
    }
}