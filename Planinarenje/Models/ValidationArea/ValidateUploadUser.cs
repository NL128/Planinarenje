using Planinarenje.Models.ClientInputs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Planinarenje.Models.ValidationArea
{
    public class ValidateUploadUser : ValidationAttribute
    {
        protected override ValidationResult
              IsValid(object value, ValidationContext validationContext)
        {
              if(value != null && value is IEnumerable<HttpPostedFileBase>)
                {
                    var cast = (IEnumerable<HttpPostedFileBase>)value;
                     if(cast.Count()>0 && cast.First() != null)
                    {
                        return ValidationResult.Success;
                    }
                }

            
            return new ValidationResult(" *Files must be implemented !");

        }
    }
}