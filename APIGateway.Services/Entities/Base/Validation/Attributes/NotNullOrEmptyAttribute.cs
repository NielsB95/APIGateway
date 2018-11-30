using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace APIGateway.Services.Entities.Base.Validation.Attributes
{
    public class NotNullOrEmptyAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // No need to check if value is null.
            if (value == null)
                return new ValidationResult(string.Format("'{0}' can't be null.", validationContext.DisplayName));

            // Check if the object is of type list, otherwise this
            // attribute doesn't apply.
            if (!(value is IList))
                return new ValidationResult(string.Format("'{0}' does not inherit from IList.", validationContext.DisplayName));

            // It is save to cast here.
            var list = value as IList;
            if (list.Count == 0)
                return new ValidationResult(string.Format("'{0}' should contain atleast one element.", validationContext.DisplayName));

            return ValidationResult.Success;
        }
    }
}
