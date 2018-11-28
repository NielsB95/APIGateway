using System.ComponentModel.DataAnnotations;
using APIGateway.Services.Entities.Base;

namespace APIGateway.Services.Tests.Validation.TestClasses
{
    public class Person : BaseEntity
    {
        public int ID { get; private set; }

        [Required]
        [MaxLength(10)]
        public string Name { get; set; }

        [Range(0, 150)]
        public int Age { get; set; }
    }
}
