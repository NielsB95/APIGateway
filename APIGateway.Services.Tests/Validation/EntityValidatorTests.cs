using System.Linq;
using APIGateway.Services.Entities.Base.Validation;
using APIGateway.Services.Tests.Validation.TestClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace APIGateway.Services.Tests.Validation
{
    [TestClass]
    public class EntityValidatorTests
    {
        #region Helper functions
        [TestMethod]
        public void GetValidatablePropertiesTest()
        {
            var classWithValidatableProps = new Person();
            var properties = classWithValidatableProps.GetType().GetProperties();
            var validatableProperties = EntityValidator.GetValidatableProperties(properties).ToList();

            Assert.AreEqual(2, validatableProperties.Count);

            var propertyNames = validatableProperties.Select(x => x.Name);
            Assert.IsTrue(propertyNames.Contains("Name"));
            Assert.IsTrue(propertyNames.Contains("Age"));
        }

        [TestMethod]
        public void GetValidatablePropertiesOnEmptyClassTest()
        {
            var classWithoutFields = new EmptyClass();
            var properties = classWithoutFields.GetType().GetProperties();
            var validatableProperties = EntityValidator.GetValidatableProperties(properties).ToList();

            Assert.AreEqual(0, validatableProperties.Count);
        }

        [TestMethod]
        public void GetValidationAttributesTest()
        {
            var classWithValidatableProps = new Person();
            var properties = classWithValidatableProps.GetType().GetProperties();

            var nameProp = properties.First(x => x.Name == "Name");
            var validationAttributes = EntityValidator.GetValidationAttributes(nameProp).ToList();
            Assert.AreEqual(2, validationAttributes.Count);
        }

        [TestMethod]
        public void GetValidationAttributesFromPropertyWithoutAttributesTest()
        {
            var classWithValidatableProps = new Person();
            var properties = classWithValidatableProps.GetType().GetProperties();

            var idProp = properties.First(x => x.Name == "ID");
            var validationAttributes = EntityValidator.GetValidationAttributes(idProp).ToList();
            Assert.AreEqual(0, validationAttributes.Count);
        }
        #endregion

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
                Name = "Johnnnnnnnnnnn",
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
    }
}
