using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Planinarenje.Models.ClientInputs
{
    public class GuideUserData : NotGuideUser
    {
        public string ShortDescription { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
    }
}