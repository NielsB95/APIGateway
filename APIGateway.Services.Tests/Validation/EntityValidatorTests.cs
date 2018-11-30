using System.ComponentModel.DataAnnotations;
using System.Linq;
using APIGateway.Services.Entities.Base;
using APIGateway.Services.Entities.Base.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace APIGateway.Services.Tests.Validation
{
    [TestClass]
    public class EntityValidatorTests
    {
        #region Object validation
        [TestMethod]
        public void ClassWithoutFieldsValidationTest()
        {
            var classWithoutFields = new EmptyClass();
            Assert.IsTrue(EntityValidator.Validate(classWithoutFields));
        }


        [TestMethod]
        public void ValidatePerson()
        {
            var entity = new Person()
            {
                Name = "John",
                Age = 23
            };

            Assert.IsTrue(entity.Validate());
        }

        [TestMethod]
        public void ValidatePersonWithTooLongName()
        {
            var entity = new Person()
            {
                Name = "Johnnnnnnnnnnnnnnnnnnnnn",
                Age = 23
            };

            Assert.IsFalse(entity.Validate());
        }

        [TestMethod]
        public void ValidateTooOldPersonTest()
        {
            var entity = new Person()
            {
                Name = "John",
                Age = 151
            };

            Assert.IsFalse(entity.Validate());
        }

        [TestMethod]
        public void ValidatePersonWithoutName()
        {
            var entity = new Person()
            {
                Name = null,
                Age = 23
            };

            Assert.IsFalse(entity.Validate());
        }
        #endregion

        #region Helper classes
        internal class Person : BaseEntity
        {
            public int ID { get; private set; }

            [Required]
            [MaxLength(10)]
            public string Name { get; set; }

            [Range(0, 150)]
            public int Age { get; set; }
        }

        internal class EmptyClass : BaseEntity
        {

        }
        #endregion
    }
}
