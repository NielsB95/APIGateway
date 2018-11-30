using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace APIGateway.Services.Entities.Base.Validation.Attributes
{
    public class ValidUrlAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
                return new ValidationResult(string.Format("'{0}' can't be null.", validationContext.MemberName));

            if (!(value is string url))
                return new ValidationResult(string.Format("'{0}' is not of type string.", validationContext.MemberName));

            if (!ValidHttpURL(url))
                return new ValidationResult(string.Format("'{0}' is not a valid URL.", url));

            return ValidationResult.Success;
        }

        internal static bool ValidHttpURL(string s)
        {
            if (!Regex.IsMatch(s, @"^https?:\/\/", RegexOptions.IgnoreCase))
                s = "http://" + s;

            if (Uri.TryCreate(s, UriKind.Absolute, out Uri resultURI))
                return (resultURI.Scheme == Uri.UriSchemeHttp ||
                        resultURI.Scheme == Uri.UriSchemeHttps);

            return false;
        }
    }
}
