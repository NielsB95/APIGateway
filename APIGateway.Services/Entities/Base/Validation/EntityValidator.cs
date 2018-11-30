using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace APIGateway.Services.Entities.Base.Validation
{
    public static class EntityValidator
    {
        /// <summary>
        /// Validate the specified entity.
        /// </summary>
        /// <returns>The validate.</returns>
        /// <param name="entity">Entity.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static bool Validate<T>(T entity) where T : IValidatable
        {
            // Create the context wherein we test.
            ValidationContext context = new ValidationContext(entity, null, null);

            // Create a list where the results will be sotred in.
            var validationsResults = new List<ValidationResult>();

            // Validate the entity.
            bool correct = Validator.TryValidateObject(entity, context, validationsResults, true);
            return correct;
        }
    }
}
