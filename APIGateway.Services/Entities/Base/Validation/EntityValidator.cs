using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace APIGateway.Services.Entities.Base.Validation
{
    public static class EntityValidator
    {
        public static bool Validate<T>(T entity) where T : IValidatable
        {
            // Get all properties of the current object.
            var properties = entity.GetType().GetProperties();

            // We have nothing to validate if there are no properties, but it
            // is valid.
            if (!properties.Any())
                return true;

            // Get all properties that have attributes which inherit from ValidationAttribute.
            var validatableProperties = GetValidatableProperties(properties);

            // Mark as valid when we have no validatable properties.
            if (!validatableProperties.Any())
                return true;

            // Check for each validatable property if it meets the requirements.
            // Return immidiatly if an invalid property is found.
            foreach (var prop in validatableProperties)
                foreach (ValidationAttribute attr in GetValidationAttributes(prop))
                    if (!attr.IsValid(prop.GetValue(entity)))
                        return false;

            // The object is valid if we've made it this far.
            return true;
        }

        /// <summary>
        /// Gets the validatable properties.
        /// </summary>
        /// <returns>The validatable properties.</returns>
        /// <param name="properties">Properties.</param>
        internal static IEnumerable<PropertyInfo> GetValidatableProperties(IEnumerable<PropertyInfo> properties)
        {
            return properties.Where(prop => GetValidationAttributes(prop).Any());
        }

        /// <summary>
        /// Gets the validation attributes from a property.
        /// </summary>
        /// <returns>The validation attributes.</returns>
        /// <param name="property">Property.</param>
        internal static IEnumerable<ValidationAttribute> GetValidationAttributes(PropertyInfo property)
        {
            return property.GetCustomAttributes(true).OfType<ValidationAttribute>();
        }
    }
}
