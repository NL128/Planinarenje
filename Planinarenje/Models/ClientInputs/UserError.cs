using DBLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Planinarenje.Models.ClientInputs
{
    public class UserError
    {
         public int StatusCode { get; set; }
        public string Message { get; set; }
    }
}