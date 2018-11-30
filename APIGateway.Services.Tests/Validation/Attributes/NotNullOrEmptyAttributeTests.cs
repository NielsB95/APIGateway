using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using APIGateway.Services.Entities.Base.Validation.Attributes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace APIGateway.Services.Tests.Validation.Attributes
{
    [TestClass]
    public class NotNullOrEmptyAttributeTests
    {
        [TestMethod]
        public void ValidateWithNull()
        {
            var classWithList = new ClassWithList();
            var context = new ValidationContext(classWithList);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(classWithList, context, validationResults, true);

            Assert.IsFalse(isValid);
            Assert.AreEqual("'MyStrings' can't be null.", validationResults.First().ErrorMessage);
        }

        [TestMethod]
        public void ValidateWithInitializedList()
        {
            var classWithList = new ClassWithList()
            {
                MyStrings = new List<string>()
            };
            var context = new ValidationContext(classWithList);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(classWithList, context, validationResults, true);

            Assert.IsFalse(isValid);
            Assert.AreEqual("'MyStrings' should contain atleast one element.", validationResults.First().ErrorMessage);
        }

        [TestMethod]
        public void ValidateWithPopulatedList()
        {
            var classWithList = new ClassWithList()
            {
                MyStrings = new List<string>()
                {
                    "Hello world"
                }
            };
            var context = new ValidationContext(classWithList);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(classWithList, context, validationResults, true);

            Assert.IsTrue(isValid);
        }
    }

    internal class ClassWithList
    {
        [NotNullOrEmpty]
        public IList<string> MyStrings { get; set; }
    }
}
