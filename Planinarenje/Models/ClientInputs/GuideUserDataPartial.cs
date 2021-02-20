using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Planinarenje.Models.ClientInputs
{
    public class GuideUserDataPartial : GuideUserData
    {
        public string ImageName { get; set; }

        public string GetFullName()
        {
            return this.FirstName + " " + this.LastName;

        }
        public UserError UserError { get; set; }
    }

    public class NotGuideUserData : NotGuideUser
    {
        public string ImageName { get; set; }
        
        public string GetFullName()
        {
            return this.FirstName + " " + this.LastName;
            
        }
        public UserError UserError { get; set; }
    }

}