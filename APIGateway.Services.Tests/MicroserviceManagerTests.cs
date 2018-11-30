using System.Collections.Generic;
using APIGateway.Services.Entities;
using APIGateway.Services.ServiceRegistration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace APIGateway.Services.Tests
{
    [TestClass]
    public class MicroserviceManagerTests
    {
        MicroserviceManager microserviceManager;

        [TestInitialize]
        public void Initialize()
        {
            microserviceManager = new MicroserviceManager();
        }

        [TestMethod]
        public void MicroserviceValidationTest()
        {
            var service = new Microservice()
            {
                Endpoints = null
            };

            var result = service.Validate();
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void MicroserviceWithoutEndpointsTest()
        {
            var service = new Microservice()
            {
                Endpoints = new List<Endpoint>()
            };

            var result = service.Validate();
            Assert.IsFalse(result);
        }
    }
}
