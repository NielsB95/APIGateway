using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using APIGateway.Services.Entities.Base.Validation.Attributes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace APIGateway.Services.Tests.Validation.Attributes
{
    [TestClass]
    public class ValidUrlAttributeTests
    {
        [TestMethod]
        public void UrlValidatorTests()
        {
            Assert.IsTrue(ValidUrlAttribute.ValidHttpURL("https://www.google.com/"));
            Assert.IsTrue(ValidUrlAttribute.ValidHttpURL("http://www.google.com/"));

            Assert.IsTrue(ValidUrlAttribute.ValidHttpURL("https://google.com/"));
            Assert.IsTrue(ValidUrlAttribute.ValidHttpURL("http://google.com/"));

            Assert.IsTrue(ValidUrlAttribute.ValidHttpURL("https://google.com"));
            Assert.IsTrue(ValidUrlAttribute.ValidHttpURL("http://google.com"));

            Assert.IsFalse(ValidUrlAttribute.ValidHttpURL(""));
        }

        [TestMethod]
        public void ValidateUrl()
        {
            var classWithUrl = new ClassWithUrl();
            var context = new ValidationContext(classWithUrl);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(classWithUrl, context, validationResults, true);

            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void ValidateUrlWhenNullTest()
        {
            var classWithUrl = new ClassWithUrl();
            var context = new ValidationContext(classWithUrl);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(classWithUrl, context, validationResults, true);

            Assert.IsFalse(isValid);
            Assert.AreEqual("'Url' can't be null.", validationResults.First().ErrorMessage);
        }

        [TestMethod]
        public void ValidateEmptyStringAsUrlTest()
        {
            var classWithUrl = new ClassWithUrl()
            {
                Url = ""
            };
            var context = new ValidationContext(classWithUrl);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(classWithUrl, context, validationResults, true);

            Assert.IsFalse(isValid);
            Assert.AreEqual("'' is not a valid URL.", validationResults.First().ErrorMessage);
        }

        [TestMethod]
        public void ValidateIntUrlTest()
        {
            var classWithUrl = new ClassWithIntUrl()
            {
                Url = 0
            };
            var context = new ValidationContext(classWithUrl);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(classWithUrl, context, validationResults, true);

            Assert.IsFalse(isValid);
            Assert.AreEqual("'Url' is not of type string.", validationResults.First().ErrorMessage);
        }

        [TestMethod]
        public void ValidateUrlTest()
        {
            var classWithUrl = new ClassWithUrl()
            {
                Url = "http://google.com"
            };
            var context = new ValidationContext(classWithUrl);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(classWithUrl, context, validationResults, true);

            Assert.IsTrue(isValid);
        }
    }

    internal class ClassWithUrl
    {
        [ValidUrl]
        public string Url { get; set; }
    }

    /// <summary>
    /// This class makes no sense, but it is needed
    /// for testing.
    /// </summary>
    internal class ClassWithIntUrl
    {
        [ValidUrl]
        public int Url { get; set; }
    }
}
