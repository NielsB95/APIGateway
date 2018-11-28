using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace APIGateway.Services.Entities.Base.Validation.Attributes
{
    public class NotEmptyOrNullAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var result = base.IsValid(value);

            // No need to check if value is null.
            if (value == null)
                return false;

            // Check if the object is of type list, otherwise this
            // attribute doesn't apply.
            if (!(value is IList))
                return false;

            var list = value as IList;
            return list.Count > 0;
        }
    }
}
