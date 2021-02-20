using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Planinarenje.Models.ValidationArea
{
    public class MustBeSpecificType : ValidationAttribute
    {
        protected override ValidationResult
               IsValid(object value, ValidationContext validationContext)
        {
            var model = (ClientInputs.IInputGetter)validationContext.ObjectInstance;
            
            if (model.ID > 0)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Integer cannot be negative number !");
            
        }

    }
}