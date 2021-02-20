using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Planinarenje.Models.ClientInputs
{
    public class NotGuideUser : IGuideUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public HttpPostedFileBase Image { get; set; }

       
    }
}