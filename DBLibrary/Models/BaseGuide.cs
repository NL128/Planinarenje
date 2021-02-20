using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLibrary.Models
{
    public   abstract class BaseGuide
    {
        
        public string StandaloneMember { get; set; }
       
        
        public string InputCompany { get; set; }
    }
}
